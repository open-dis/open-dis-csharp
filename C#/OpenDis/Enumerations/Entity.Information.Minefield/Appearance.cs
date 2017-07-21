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

namespace OpenDis.Enumerations.Entity.Information.Minefield
{
    /// <summary>
    /// Enumeration values for Appearance (entity.mine.appear, Appearance Bit Map, 
    /// section 10.2.1)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Appearance
    {
        /// <summary>
        /// Identifies the type of minefield
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Identifies the type of minefield")]
        public enum MinefieldTypeValue : uint
        {
            /// <summary>
            /// Mixed anti-personnel and anti-tank minefield
            /// </summary>
            MixedAntiPersonnelAndAntiTankMinefield = 0,

            /// <summary>
            /// Pure anti-personnel minefield
            /// </summary>
            PureAntiPersonnelMinefield = 1,

            /// <summary>
            /// Pure anti-tank minefield
            /// </summary>
            PureAntiTankMinefield = 2,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 3
        }

        /// <summary>
        /// Identifies the active status of the minefield
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Identifies the active status of the minefield")]
        public enum ActiveStatusValue : uint
        {
            /// <summary>
            /// Active
            /// </summary>
            Active = 0,

            /// <summary>
            /// Inactive
            /// </summary>
            Inactive = 1
        }

        /// <summary>
        /// Identifies whether the minefield has an active lane
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Identifies whether the minefield has an active lane")]
        public enum LaneValue : uint
        {
            /// <summary>
            /// Minefield has active lane
            /// </summary>
            MinefieldHasActiveLane = 0,

            /// <summary>
            /// Minefield has an inactive lane
            /// </summary>
            MinefieldHasAnInactiveLane = 1
        }

        /// <summary>
        /// Describes the state of the minefield
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of the minefield")]
        public enum StateValue : uint
        {
            /// <summary>
            /// Active
            /// </summary>
            Active = 0,

            /// <summary>
            /// Deactivated
            /// </summary>
            Deactivated = 1
        }

        private Appearance.MinefieldTypeValue minefieldType;
        private Appearance.ActiveStatusValue activeStatus;
        private Appearance.LaneValue lane;
        private Appearance.StateValue state;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Appearance left, Appearance right)
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
        public static bool operator ==(Appearance left, Appearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> to <see cref="System.UInt16"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(Appearance obj)
        {
            return obj.ToUInt16();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Appearance(ushort value)
        {
            return Appearance.FromUInt16(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static Appearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance, represented by the ushort value.</returns>
        public static Appearance FromUInt16(ushort value)
        {
            Appearance ps = new Appearance();

            uint mask0 = 0x0003;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.MinefieldType = (Appearance.MinefieldTypeValue)newValue0;

            uint mask1 = 0x0004;
            byte shift1 = 2;
            uint newValue1 = value & mask1 >> shift1;
            ps.ActiveStatus = (Appearance.ActiveStatusValue)newValue1;

            uint mask2 = 0x0008;
            byte shift2 = 3;
            uint newValue2 = value & mask2 >> shift2;
            ps.Lane = (Appearance.LaneValue)newValue2;

            uint mask4 = 0x2000;
            byte shift4 = 13;
            uint newValue4 = value & mask4 >> shift4;
            ps.State = (Appearance.StateValue)newValue4;

            return ps;
        }

        /// <summary>
        /// Gets or sets the minefieldtype.
        /// </summary>
        /// <value>The minefieldtype.</value>
        public Appearance.MinefieldTypeValue MinefieldType
        {
            get { return this.minefieldType; }
            set { this.minefieldType = value; }
        }

        /// <summary>
        /// Gets or sets the activestatus.
        /// </summary>
        /// <value>The activestatus.</value>
        public Appearance.ActiveStatusValue ActiveStatus
        {
            get { return this.activeStatus; }
            set { this.activeStatus = value; }
        }

        /// <summary>
        /// Gets or sets the lane.
        /// </summary>
        /// <value>The lane.</value>
        public Appearance.LaneValue Lane
        {
            get { return this.lane; }
            set { this.lane = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public Appearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
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

            if (!(obj is Appearance))
            {
                return false;
            }

            return this.Equals((Appearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Appearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.MinefieldType == other.MinefieldType &&
                this.ActiveStatus == other.ActiveStatus &&
                this.Lane == other.Lane &&
                this.State == other.State;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt16());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="OpenDis.Enumerations.Entity.Information.Minefield.Appearance"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)this.MinefieldType << 0);
            val |= (ushort)((uint)this.ActiveStatus << 2);
            val |= (ushort)((uint)this.Lane << 3);
            val |= (ushort)((uint)this.State << 13);

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
                hash = (hash * 29) + this.MinefieldType.GetHashCode();
                hash = (hash * 29) + this.ActiveStatus.GetHashCode();
                hash = (hash * 29) + this.Lane.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
            }

            return hash;
        }
    }
}
