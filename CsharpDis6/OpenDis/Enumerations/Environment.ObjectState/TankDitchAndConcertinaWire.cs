// Copyright 2008-2011. This work is licensed under the BSD license, available at
// http://www.movesinstitute.org/licenses
//
// Orignal authors: DMcG, Jason Nelson
// Modified for use with C#:
// - Peter Smith (Naval Air Warfare Center - Training Systems Division)
// - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenDis.Enumerations.Environment.ObjectState
{
    /// <summary>
    /// Enumeration values for TankDitchAndConcertinaWire (env.obj.appear.linear.tankditch, Tank ditch, and Concertina
    /// Wire,
    /// section 12.1.2.3.1)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct TankDitchAndConcertinaWire : IHashable<TankDitchAndConcertinaWire>
    {
        /// <summary>
        /// Describes the breached appearance of the object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the breached appearance of the object")]
        public enum BreachValue : uint
        {
            /// <summary>
            /// No breaching
            /// </summary>
            NoBreaching = 0,

            /// <summary>
            /// Slight breaching
            /// </summary>
            SlightBreaching = 1,

            /// <summary>
            /// Moderate breached
            /// </summary>
            ModerateBreached = 2,

            /// <summary>
            /// Cleared
            /// </summary>
            Cleared = 3
        }

        /// <summary>
        /// Each bit indicates whether its associated segment is breached or not. Bit 40+i indicates whether the portion of
        /// the segment beginning at the segment origin + (i*Breach Length) and extending i* Breach Length meters is breached or not. For each bit:
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Each bit indicates whether its associated segment is breached or not. Bit 40+i indicates whether the portion of the segment beginning at the segment origin + (i*Breach Length) and extending i* Breach Length meters is breached or not. For each bit:")]
        public enum BreachLocationValue : uint
        {
            /// <summary>
            /// Associated portion of segment is not breached
            /// </summary>
            AssociatedPortionOfSegmentIsNotBreached = 0,

            /// <summary>
            /// Associated portion of segment is breached
            /// </summary>
            AssociatedPortionOfSegmentIsBreached = 1
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(TankDitchAndConcertinaWire left, TankDitchAndConcertinaWire right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(TankDitchAndConcertinaWire left, TankDitchAndConcertinaWire right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="TankDitchAndConcertinaWire"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="TankDitchAndConcertinaWire"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(TankDitchAndConcertinaWire obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="TankDitchAndConcertinaWire"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator TankDitchAndConcertinaWire(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="TankDitchAndConcertinaWire"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="TankDitchAndConcertinaWire"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="TankDitchAndConcertinaWire"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static TankDitchAndConcertinaWire FromByteArray(byte[] array, int index)
        {
            return array == null
                ? throw new ArgumentNullException(nameof(array))
                : index < 0 ||
                index > array.Length - 1 ||
                index + 4 > array.Length - 1
                ? throw new IndexOutOfRangeException()
                : FromUInt32(BitConverter.ToUInt32(array, index));
        }

        /// <summary>
        /// Creates the <see cref="TankDitchAndConcertinaWire"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="TankDitchAndConcertinaWire"/> instance.</param>
        /// <returns>The <see cref="TankDitchAndConcertinaWire"/> instance, represented by the uint value.</returns>
        public static TankDitchAndConcertinaWire FromUInt32(uint value)
        {
            var ps = new TankDitchAndConcertinaWire();

            const uint mask0 = 0x30000;
            const byte shift0 = 16;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Breach = (BreachValue)newValue0;

            const uint mask2 = 0x00ff;
            const byte shift2 = 32;
            uint newValue2 = (value & mask2) >> shift2;
            ps.BreachLength = (byte)newValue2;

            const uint mask3 = 0xff00;
            const byte shift3 = 40;
            uint newValue3 = (value & mask3) >> shift3;
            ps.BreachLocation = (BreachLocationValue)newValue3;

            return ps;
        }

        /// <summary>
        /// Gets or sets the breach.
        /// </summary>
        /// <value>The breach.</value>
        public BreachValue Breach { get; set; }

        /// <summary>
        /// Gets or sets the breachlength.
        /// </summary>
        /// <value>The breachlength.</value>
        public byte BreachLength { get; set; }

        /// <summary>
        /// Gets or sets the breachlocation.
        /// </summary>
        /// <value>The breachlocation.</value>
        public BreachLocationValue BreachLocation { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is TankDitchAndConcertinaWire other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="TankDitchAndConcertinaWire"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="TankDitchAndConcertinaWire"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="TankDitchAndConcertinaWire"/> is equal to this instance; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool Equals(TankDitchAndConcertinaWire other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Breach == other.Breach &&
                BreachLength == other.BreachLength &&
                BreachLocation == other.BreachLocation;
        }

        /// <summary>
        /// Converts the instance of <see cref="TankDitchAndConcertinaWire"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="TankDitchAndConcertinaWire"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="TankDitchAndConcertinaWire"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="TankDitchAndConcertinaWire"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Breach << 16;
            val |= (uint)BreachLength << 32;
            val |= (uint)BreachLocation << 40;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Breach.GetHashCode();
                hash = (hash * 29) + BreachLength.GetHashCode();
                hash = (hash * 29) + BreachLocation.GetHashCode();
            }

            return hash;
        }
    }
}
