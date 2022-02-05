using System;

namespace OpenDis.Core
{
    /// <summary>
    /// DIS time units are a pain in the ass. DIS time units are arbitrary, and set
    /// equal to 2^31 - 1 time units per hour. The DIS time is set to the number of time
    /// units since the start of the hour. The timestamp field in the PDU header is
    /// four bytes long and is specified to be an unsigned integer value.<para>
    ///
    /// There are two types of official timestamps in the PDU header: absolute time and
    /// relative time. Absolute time is used when the host is sync'd to UTC, ie the host
    /// has access to UTC via Network Time Protocol (NTP). This time can be legitimately
    /// compared to the timestamp of packets received from other hosts, since they all
    /// </para>
    /// refer to the same universal time.<para>
    ///
    /// Relative timestamps are used when the host does NOT have access to NTP, and hence
    /// the system time might not be coordinated with that of other hosts. This means that
    /// a host receiving DIS packets from several hosts might have to set up a per-host
    /// table to order packets, and that the PDU timestamp fields from one host is not
    /// directly comparable to the PDU timestamp field from another host.
    ///
    /// Absolute timestamps have their LSB set to 1, and relative timestamps have their
    /// LSB set to 0. The idea is to get the current time since the top of the hour,
    /// divide by 2^31-1, shift left one bit, then set the LSB to either 0 for relative
    /// </para>
    /// timestamps or 1 for absolute timestamps.<para>
    ///
    /// The nature of the data is such that the timestamp fields will roll over once an
    /// hour, and simulations must be prepared for that. Ie, at the top of the hour
    /// outgoing PDUs will have a timestamp of 1, just before the end of the hour the
    /// PDUs will have a timestamp of 2^31 - 1, and then they will roll back over to 1.
    /// Receiving applications should expect this behavior, and not simply expect a
    /// </para>
    /// monotonically increasing timestamp field.<para>
    ///
    /// The official DIS timestamps don't work all that well in our (NPS's) applications,
    /// which often expect a monotonically increasing timestamp field. To get around this,
    /// we use hundreds of a second since the start of the year. The maximum value for
    /// this field is 3,153,600,000, which can fit into an unsigned int. The resolution is
    /// good enough for most applications, and you typically don't have to worry about
    /// </para>
    /// rollover, instead getting only a monotonically increasing timestamp value.<para>
    ///
    /// Note that many applications in the wild have been known to completely ignore
    /// the standard and to simply put the Unix time (seconds since 1970) into the
    /// </para>
    /// field. <para>
    ///
    /// You need to be careful with the shared instance of this class--I'm not at all
    /// convinced it is thread safe. If you are using multiple threads, I suggest you
    /// create a new instance of the class for each thread to prevent the values from
    /// </para>
    /// getting stomped on.<para>
    ///
    /// @author DMcG (coverted from Java by Richard Murphy)
    /// </para>
    /// </summary>
    public static class DisTime
    {
        private const uint ABSOLUTE_TIMESTAMP_MASK = 0x00000001;
        private const uint RELATIVE_TIMESTAMP_MASK = 0xfffffffe;

        /// <summary>
        /// Returns the number of DIS time units since the top of the hour. there are 2^31-1 DIS time
        /// units per hour. </summary>
        /// <returns> integer DIS time units since the start of the hour. </returns>
        private static int DisTimeUnitsSinceTopOfHour
        {
            get
            {
                // set cal object to current time
                //long currentTime = DateTimeHelperClass.CurrentUnixTimeMillis(); // UTC milliseconds since 1970
                //cal.TimeInMillis = currentTime;

                var current = DateTime.Now;
                var currentHour = current;

                //Add methods do not change objects value.  They return new modified object
                currentHour = currentHour.AddMilliseconds(0 - current.Millisecond);
                currentHour = currentHour.AddMinutes(0 - current.Minute);
                currentHour = currentHour.AddSeconds(0 - current.Second);

                var diffSpan = current.Subtract(currentHour);
                double diff = diffSpan.TotalMilliseconds;

                // It turns out that Integer.MAX_VALUE is 2^31-1, which is the time unit value, ie there are
                // 2^31-1 DIS time units in an hour. 3600 sec/hr X 1000 msec/sec divided into the number of
                // msec since the start of the hour gives the percentage of DIS time units in the hour, times
                // the number of DIS time units per hour, equals the time value
                double val = diff / (3600.0 * 1000.0) * int.MaxValue;

                return Convert.ToInt32(val);
            }
        }

        /// <summary>
        /// Returns the absolute timestamp (31 bits of time + 1 bit set on indicating absolute),
        /// assuminng that this host is sync'd to NTP.
        /// Fix to bitshift by mvormelch. </summary>
        /// <returns> DIS time units, get absolute timestamp </returns>
        public static uint DisAbsoluteTimestamp
        {
            get
            {
                uint val = Convert.ToUInt32(DisTimeUnitsSinceTopOfHour);
                // always flip the lsb to 1
                return (val << 1) | ABSOLUTE_TIMESTAMP_MASK;
            }
        }

        /// <summary>
        /// Returns the DIS standard relative timestamp (31 bits of time + 1 bit set off indicating relative),
        /// which should be used if this host
        /// is not slaved to NTP. Fix to bitshift by mvormelch </summary>
        /// <returns> DIS time units, relative </returns>
        public static uint DisRelativeTimestamp
        {
            get
            {
                uint val = Convert.ToUInt32(DisTimeUnitsSinceTopOfHour);
                // always flip the lsb to 0
                return (val << 1) & RELATIVE_TIMESTAMP_MASK;
            }
        }

        /// <summary>
        /// Returns a useful timestamp, hundredths of a second since the start of the year.
        /// This effectively eliminates the need for receivers to handle timestamp rollover,
        /// as long as you're not working on New Year's Eve. </summary>
        /// <returns> a timestamp in hundredths of a second since the start of the year </returns>
        public static uint NpsTimestamp
        {
            get
            {
                var current = DateTime.Now;
                var currentYear = current;

                //Add methods do not change objects value.  They return new modified object
                currentYear = currentYear.AddMilliseconds(0 - current.Millisecond);
                currentYear = currentYear.AddMinutes(0 - current.Minute);
                currentYear = currentYear.AddSeconds(0 - current.Second);
                currentYear = currentYear.AddDays(1 - current.DayOfYear);  //Days are 1-366 (366 if leap)

                // Milliseconds since the top of the year
                var diffSpan = current.Subtract(currentYear);
                double diff = diffSpan.TotalMilliseconds;

                // 100ths of sec since beggining of year
                diff /= 10; // milliseconds to hundredths of a second

                return Convert.ToUInt32(diff);
            }
        }

        /// <summary>
        /// Another option for marshalling with the timestamp field set automatically. The UNIX
        /// time is conventionally seconds since January 1, 1970. UTC time is used, and leap seconds
        /// are excluded. This approach is popular in the wild, but the time resolution is not very
        /// good for high frequency updates, such as aircraft. An entity updating at 30 PDUs/second
        /// would see 30 PDUs sent out with the same timestamp, and have 29 of them discarded as
        /// duplicate packets.
        /// <para/>
        /// Note that there are other "Unix times", such milliseconds since 1/1/1970, saved in a long.
        /// This cannot be used, since the value is saved in a long. Java's System.getCurrentTimeMillis()
        /// uses this value.
        /// <para/>
        /// Unix time (in seconds) rolls over in 2038.
        /// <para/>
        /// See the wikipedia page on Unix time for gory details.
        /// <para/>
        /// </summary>
        /// <returns> seconds since 1970 </returns>
        public static uint UnixTimestamp
        {
            get
            {
                var current = DateTime.UtcNow;
                var unixStart = new DateTime(1970, 1, 1);

                var diffSpan = current.Subtract(unixStart);
                return Convert.ToUInt32(diffSpan.TotalSeconds);
            }
        }
    }
}
