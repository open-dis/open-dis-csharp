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

namespace OpenDis.Enumerations.DistributedEmission.Iff
{
    /// <summary>
    /// Enumeration values for Type1Parameter5ModeCCodeStatus (der.iff.type.1.fop.param5, Parameter 5 - Mode C Code/Status, 
    /// section 8.3.1.2.6)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Type1Parameter5ModeCCodeStatus
    {
        /// <summary>
        /// Negative Altitude
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Negative Altitude")]
        public enum NegativeAltitudeValue : uint
        {
            /// <summary>
            /// Positive altitude above mean sea level Indicator if Mode C altitude is contained in Bits 1-11
            /// </summary>
            PositiveAltitudeAboveMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111 = 0,

            /// <summary>
            /// Negative altitude below mean sea level Indicator if Mode C altitude is contained in Bits 1-11, or, Alternate Mode 5 if altitude Bits 1-11 = 2047.
            /// </summary>
            NegativeAltitudeBelowMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111OrAlternateMode5IfAltitudeBits1112047 = 1
        }

        /// <summary>
        /// Mode C altitude
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Mode C altitude")]
        public enum ModeCAltitudeValue : uint
        {
            /// <summary>
            /// Actual Mode C altitude in the range 0-126,000 feet in 100-foot increments (Bit 0 - Negative / Positive Indicator must be set appropriately)
            /// </summary>
            ActualModeCAltitudeInTheRange0126000FeetIn100FootIncrementsBit0NegativePositiveIndicatorMustBeSetAppropriately = 0,

            /// <summary>
            /// Not actual Mode C altitude value. Use alternate Mode 5 (Bits 0-11 = 4095 i.e. all 1-s)
            /// </summary>
            NotActualModeCAltitudeValueUseAlternateMode5Bits0114095IEAll1S = 2047
        }

        /// <summary>
        /// Status
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Status")]
        public enum StatusValue : uint
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
        /// Damage
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Damage")]
        public enum DamageValue : uint
        {
            /// <summary>
            /// No damage
            /// </summary>
            NoDamage = 0,

            /// <summary>
            /// Damage
            /// </summary>
            Damage = 1
        }

        /// <summary>
        /// Malfunction
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Malfunction")]
        public enum MalfunctionValue : uint
        {
            /// <summary>
            /// No malfunction
            /// </summary>
            NoMalfunction = 0,

            /// <summary>
            /// Malfunction
            /// </summary>
            Malfunction = 1
        }

        private Type1Parameter5ModeCCodeStatus.NegativeAltitudeValue negativeAltitude;
        private Type1Parameter5ModeCCodeStatus.ModeCAltitudeValue modeCAltitude;
        private Type1Parameter5ModeCCodeStatus.StatusValue status;
        private Type1Parameter5ModeCCodeStatus.DamageValue damage;
        private Type1Parameter5ModeCCodeStatus.MalfunctionValue malfunction;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Type1Parameter5ModeCCodeStatus left, Type1Parameter5ModeCCodeStatus right)
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
        public static bool operator ==(Type1Parameter5ModeCCodeStatus left, Type1Parameter5ModeCCodeStatus right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> to <see cref="System.UInt16"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(Type1Parameter5ModeCCodeStatus obj)
        {
            return obj.ToUInt16();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Type1Parameter5ModeCCodeStatus(ushort value)
        {
            return Type1Parameter5ModeCCodeStatus.FromUInt16(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static Type1Parameter5ModeCCodeStatus FromByteArray(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 ||
                index > array.Length - 1 ||
                index + 2 > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return FromUInt16(BitConverter.ToUInt16(array, index));
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance, represented by the ushort value.</returns>
        public static Type1Parameter5ModeCCodeStatus FromUInt16(ushort value)
        {
            Type1Parameter5ModeCCodeStatus ps = new Type1Parameter5ModeCCodeStatus();

            uint mask0 = 0x0001;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.NegativeAltitude = (Type1Parameter5ModeCCodeStatus.NegativeAltitudeValue)newValue0;

            uint mask1 = 0x0ffe;
            byte shift1 = 1;
            uint newValue1 = value & mask1 >> shift1;
            ps.ModeCAltitude = (Type1Parameter5ModeCCodeStatus.ModeCAltitudeValue)newValue1;

            uint mask3 = 0x2000;
            byte shift3 = 13;
            uint newValue3 = value & mask3 >> shift3;
            ps.Status = (Type1Parameter5ModeCCodeStatus.StatusValue)newValue3;

            uint mask4 = 0x4000;
            byte shift4 = 14;
            uint newValue4 = value & mask4 >> shift4;
            ps.Damage = (Type1Parameter5ModeCCodeStatus.DamageValue)newValue4;

            uint mask5 = 0x8000;
            byte shift5 = 15;
            uint newValue5 = value & mask5 >> shift5;
            ps.Malfunction = (Type1Parameter5ModeCCodeStatus.MalfunctionValue)newValue5;

            return ps;
        }

        /// <summary>
        /// Gets or sets the negativealtitude.
        /// </summary>
        /// <value>The negativealtitude.</value>
        public Type1Parameter5ModeCCodeStatus.NegativeAltitudeValue NegativeAltitude
        {
            get { return this.negativeAltitude; }
            set { this.negativeAltitude = value; }
        }

        /// <summary>
        /// Gets or sets the modecaltitude.
        /// </summary>
        /// <value>The modecaltitude.</value>
        public Type1Parameter5ModeCCodeStatus.ModeCAltitudeValue ModeCAltitude
        {
            get { return this.modeCAltitude; }
            set { this.modeCAltitude = value; }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public Type1Parameter5ModeCCodeStatus.StatusValue Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public Type1Parameter5ModeCCodeStatus.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the malfunction.
        /// </summary>
        /// <value>The malfunction.</value>
        public Type1Parameter5ModeCCodeStatus.MalfunctionValue Malfunction
        {
            get { return this.malfunction; }
            set { this.malfunction = value; }
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

            if (!(obj is Type1Parameter5ModeCCodeStatus))
            {
                return false;
            }

            return this.Equals((Type1Parameter5ModeCCodeStatus)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Type1Parameter5ModeCCodeStatus other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.NegativeAltitude == other.NegativeAltitude &&
                this.ModeCAltitude == other.ModeCAltitude &&
                this.Status == other.Status &&
                this.Damage == other.Damage &&
                this.Malfunction == other.Malfunction;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt16());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type1Parameter5ModeCCodeStatus"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)this.NegativeAltitude << 0);
            val |= (ushort)((uint)this.ModeCAltitude << 1);
            val |= (ushort)((uint)this.Status << 13);
            val |= (ushort)((uint)this.Damage << 14);
            val |= (ushort)((uint)this.Malfunction << 15);

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
                hash = (hash * 29) + this.NegativeAltitude.GetHashCode();
                hash = (hash * 29) + this.ModeCAltitude.GetHashCode();
                hash = (hash * 29) + this.Status.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Malfunction.GetHashCode();
            }

            return hash;
        }
    }
}
