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
using System.Reflection;

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
    public struct PropulsionPlantConfiguration
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

        private PropulsionPlantConfiguration.ConfigurationValue configuration;
        private PropulsionPlantConfiguration.HullMountedMaskerValue hullMountedMasker;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If parameters are null return false (cast to object to prevent recursive loop!)
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(PropulsionPlantConfiguration obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator PropulsionPlantConfiguration(uint value)
        {
            return PropulsionPlantConfiguration.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static PropulsionPlantConfiguration FromByteArray(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 ||
                index > array.Length - 1 ||
                index + 4 > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return FromUInt32(BitConverter.ToUInt32(array, index));
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance, represented by the uint value.</returns>
        public static PropulsionPlantConfiguration FromUInt32(uint value)
        {
            PropulsionPlantConfiguration ps = new PropulsionPlantConfiguration();

            uint mask0 = 0x007f;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.Configuration = (PropulsionPlantConfiguration.ConfigurationValue)newValue0;

            uint mask1 = 0x0080;
            byte shift1 = 7;
            uint newValue1 = value & mask1 >> shift1;
            ps.HullMountedMasker = (PropulsionPlantConfiguration.HullMountedMaskerValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public PropulsionPlantConfiguration.ConfigurationValue Configuration
        {
            get { return this.configuration; }
            set { this.configuration = value; }
        }

        /// <summary>
        /// Gets or sets the hullmountedmasker.
        /// </summary>
        /// <value>The hullmountedmasker.</value>
        public PropulsionPlantConfiguration.HullMountedMaskerValue HullMountedMasker
        {
            get { return this.hullMountedMasker; }
            set { this.hullMountedMasker = value; }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is PropulsionPlantConfiguration))
            {
                return false;
            }

            return this.Equals((PropulsionPlantConfiguration)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(PropulsionPlantConfiguration other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Configuration == other.Configuration &&
                this.HullMountedMasker == other.HullMountedMasker;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic.PropulsionPlantConfiguration"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Configuration << 0);
            val |= (uint)((uint)this.HullMountedMasker << 7);

            return val;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// 	A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + this.Configuration.GetHashCode();
                hash = (hash * 29) + this.HullMountedMasker.GetHashCode();
            }

            return hash;
        }
    }
}
