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

namespace OpenDis.Enumerations.Environment.ObjectState
{
    /// <summary>
    /// Enumeration values for GeneralAppearance (env.obj.appear.general, General, 
    /// section 12.1.2.1)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct GeneralAppearance
    {
        /// <summary>
        /// Describes the damaged appearance of the object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the damaged appearance of the object")]
        public enum DamageValue : uint
        {
            /// <summary>
            /// No damage
            /// </summary>
            NoDamage = 0,

            /// <summary>
            /// Damaged
            /// </summary>
            Damaged = 1,

            /// <summary>
            /// Destroyed
            /// </summary>
            Destroyed = 2,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 3
        }

        /// <summary>
        /// Describes whether the object was predistributed
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether the object was predistributed")]
        public enum PredistributedValue : uint
        {
            /// <summary>
            /// Object created during the exercise
            /// </summary>
            ObjectCreatedDuringTheExercise = 0,

            /// <summary>
            /// Object predistributed prior to exercise start
            /// </summary>
            ObjectPredistributedPriorToExerciseStart = 1
        }

        /// <summary>
        /// Describes the state of the object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of the object")]
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

        /// <summary>
        /// Describes whether smoke is rising from an object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether smoke is rising from an object")]
        public enum SmokingValue : uint
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// Smoke present
            /// </summary>
            SmokePresent = 1
        }

        /// <summary>
        /// Describes whether flames are rising from an object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether flames are rising from an object")]
        public enum FlamingValue : uint
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// Flames present
            /// </summary>
            FlamesPresent = 1
        }

        private byte percentComplete;
        private GeneralAppearance.DamageValue damage;
        private GeneralAppearance.PredistributedValue predistributed;
        private GeneralAppearance.StateValue state;
        private GeneralAppearance.SmokingValue smoking;
        private GeneralAppearance.FlamingValue flaming;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(GeneralAppearance left, GeneralAppearance right)
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
        public static bool operator ==(GeneralAppearance left, GeneralAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> to <see cref="System.UInt16"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(GeneralAppearance obj)
        {
            return obj.ToUInt16();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator GeneralAppearance(ushort value)
        {
            return GeneralAppearance.FromUInt16(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static GeneralAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance, represented by the ushort value.</returns>
        public static GeneralAppearance FromUInt16(ushort value)
        {
            GeneralAppearance ps = new GeneralAppearance();

            uint mask0 = 0x00ff;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.PercentComplete = (byte)newValue0;

            uint mask1 = 0x0300;
            byte shift1 = 8;
            uint newValue1 = value & mask1 >> shift1;
            ps.Damage = (GeneralAppearance.DamageValue)newValue1;

            uint mask2 = 0x0400;
            byte shift2 = 10;
            uint newValue2 = value & mask2 >> shift2;
            ps.Predistributed = (GeneralAppearance.PredistributedValue)newValue2;

            uint mask3 = 0x0800;
            byte shift3 = 11;
            uint newValue3 = value & mask3 >> shift3;
            ps.State = (GeneralAppearance.StateValue)newValue3;

            uint mask4 = 0x1000;
            byte shift4 = 12;
            uint newValue4 = value & mask4 >> shift4;
            ps.Smoking = (GeneralAppearance.SmokingValue)newValue4;

            uint mask5 = 0x2000;
            byte shift5 = 13;
            uint newValue5 = value & mask5 >> shift5;
            ps.Flaming = (GeneralAppearance.FlamingValue)newValue5;

            return ps;
        }

        /// <summary>
        /// Gets or sets the percentcomplete.
        /// </summary>
        /// <value>The percentcomplete.</value>
        public byte PercentComplete
        {
            get { return this.percentComplete; }
            set { this.percentComplete = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public GeneralAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the predistributed.
        /// </summary>
        /// <value>The predistributed.</value>
        public GeneralAppearance.PredistributedValue Predistributed
        {
            get { return this.predistributed; }
            set { this.predistributed = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public GeneralAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the smoking.
        /// </summary>
        /// <value>The smoking.</value>
        public GeneralAppearance.SmokingValue Smoking
        {
            get { return this.smoking; }
            set { this.smoking = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public GeneralAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
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

            if (!(obj is GeneralAppearance))
            {
                return false;
            }

            return this.Equals((GeneralAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(GeneralAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.PercentComplete == other.PercentComplete &&
                this.Damage == other.Damage &&
                this.Predistributed == other.Predistributed &&
                this.State == other.State &&
                this.Smoking == other.Smoking &&
                this.Flaming == other.Flaming;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt16());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.GeneralAppearance"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)this.PercentComplete << 0);
            val |= (ushort)((uint)this.Damage << 8);
            val |= (ushort)((uint)this.Predistributed << 10);
            val |= (ushort)((uint)this.State << 11);
            val |= (ushort)((uint)this.Smoking << 12);
            val |= (ushort)((uint)this.Flaming << 13);

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
                hash = (hash * 29) + this.PercentComplete.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Predistributed.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.Smoking.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
            }

            return hash;
        }
    }
}
