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

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic
{
    /// <summary>
    /// Enumeration values for PropulsionPlantConfiguration (der.ua.ppcfg, Propulsion Plant Configuration,
    /// section 8.4.7)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct PropulsionPlantConfiguration : IHashable<PropulsionPlantConfiguration>
    {
        /// <summary>
        /// Run internal simulation clock.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Run internal simulation clock.")]
        public enum ConfigurationValue : uint
        {
            /// <summary>
            /// Other
            /// </summary>
            Other = 0,

            /// <summary>
            /// Diesel/electric
            /// </summary>
            DieselElectric = 1,

            /// <summary>
            /// Diesel
            /// </summary>
            Diesel = 2,

            /// <summary>
            /// Battery
            /// </summary>
            Battery = 3,

            /// <summary>
            /// Turbine reduction
            /// </summary>
            TurbineReduction = 4,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 5,

            /// <summary>
            /// Steam
            /// </summary>
            Steam = 6,

            /// <summary>
            /// Gas turbine
            /// </summary>
            GasTurbine = 7,

            /// <summary>
            /// null
            /// </summary>
            Unknown2 = 8
        }

        /// <summary>
        /// Hull Mounted Masker status
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Hull Mounted Masker status")]
        public enum HullMountedMaskerValue : uint
        {
            /// <summary>
            /// Off
            /// </summary>
            Off = 0,

            /// <summary>
            /// On
            /// </summary>
            On = 1
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="PropulsionPlantConfiguration"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="PropulsionPlantConfiguration"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(PropulsionPlantConfiguration obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="PropulsionPlantConfiguration"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator PropulsionPlantConfiguration(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="PropulsionPlantConfiguration"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="PropulsionPlantConfiguration"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="PropulsionPlantConfiguration"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static PropulsionPlantConfiguration FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="PropulsionPlantConfiguration"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="PropulsionPlantConfiguration"/> instance.</param>
        /// <returns>The <see cref="PropulsionPlantConfiguration"/> instance, represented by the uint value.</returns>
        public static PropulsionPlantConfiguration FromUInt32(uint value)
        {
            var ps = new PropulsionPlantConfiguration();

            const uint mask0 = 0x007f;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Configuration = (ConfigurationValue)newValue0;

            const uint mask1 = 0x0080;
            const byte shift1 = 7;
            uint newValue1 = (value & mask1) >> shift1;
            ps.HullMountedMasker = (HullMountedMaskerValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public ConfigurationValue Configuration { get; set; }

        /// <summary>
        /// Gets or sets the hullmountedmasker.
        /// </summary>
        /// <value>The hullmountedmasker.</value>
        public HullMountedMaskerValue HullMountedMasker { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is PropulsionPlantConfiguration other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="PropulsionPlantConfiguration"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="PropulsionPlantConfiguration"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="PropulsionPlantConfiguration"/> is equal to this instance; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool Equals(PropulsionPlantConfiguration other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Configuration == other.Configuration &&
                HullMountedMasker == other.HullMountedMasker;
        }

        /// <summary>
        /// Converts the instance of <see cref="PropulsionPlantConfiguration"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="PropulsionPlantConfiguration"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="PropulsionPlantConfiguration"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="PropulsionPlantConfiguration"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Configuration << 0;
            val |= (uint)HullMountedMasker << 7;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Configuration.GetHashCode();
                hash = (hash * 29) + HullMountedMasker.GetHashCode();
            }

            return hash;
        }
    }
}
