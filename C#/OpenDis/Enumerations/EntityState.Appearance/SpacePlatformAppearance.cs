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

namespace OpenDis.Enumerations.EntityState.Appearance
{
    /// <summary>
    /// Enumeration values for SpacePlatformAppearance (es.appear.platform.space, Platforms of the Space Domain, 
    /// section 4.3.1.5)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct SpacePlatformAppearance
    {
        /// <summary>
        /// Describes the paint scheme of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the paint scheme of an entity")]
        public enum PaintSchemeValue : uint
        {
            /// <summary>
            /// Uniform color
            /// </summary>
            UniformColor = 0,

            /// <summary>
            /// Camouflage
            /// </summary>
            Camouflage = 1
        }

        /// <summary>
        /// Describes characteristics of mobility kills
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes characteristics of mobility kills")]
        public enum MobilityValue : uint
        {
            /// <summary>
            /// No mobility kill
            /// </summary>
            NoMobilityKill = 0,

            /// <summary>
            /// Mobility kill
            /// </summary>
            MobilityKill = 1
        }

        /// <summary>
        /// Describes the damaged appearance of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the damaged appearance of an entity")]
        public enum DamageValue : uint
        {
            /// <summary>
            /// No damage
            /// </summary>
            NoDamage = 0,

            /// <summary>
            /// Slight damage
            /// </summary>
            SlightDamage = 1,

            /// <summary>
            /// Moderate damage
            /// </summary>
            ModerateDamage = 2,

            /// <summary>
            /// Destroyed
            /// </summary>
            Destroyed = 3
        }

        /// <summary>
        /// Describes status or location of smoke emanating from an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes status or location of smoke emanating from an entity")]
        public enum SmokeValue : uint
        {
            /// <summary>
            /// Not smoking
            /// </summary>
            NotSmoking = 0,

            /// <summary>
            /// Smoke plume rising from the entity
            /// </summary>
            SmokePlumeRisingFromTheEntity = 1,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 2
        }

        /// <summary>
        /// Describes whether flames are rising from an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether flames are rising from an entity")]
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

        /// <summary>
        /// Describes the frozen status of a space platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a space platform")]
        public enum FrozenStatusValue : uint
        {
            /// <summary>
            /// Not frozen
            /// </summary>
            NotFrozen = 0,

            /// <summary>
            /// Frozen (Frozen entities should not be dead-reckoned, i.e. they should be displayed as fixed at the current location even if nonzero velocity, acceleration or rotation data is received from the frozen entity)
            /// </summary>
            FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity = 1
        }

        /// <summary>
        /// Describes the power-plant status of a space platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the power-plant status of a space platform")]
        public enum PowerPlantStatusValue : uint
        {
            /// <summary>
            /// Power plant off
            /// </summary>
            PowerPlantOff = 0,

            /// <summary>
            /// Power plant on
            /// </summary>
            PowerPlantOn = 1
        }

        /// <summary>
        /// Describes the state of a space platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a space platform")]
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

        private SpacePlatformAppearance.PaintSchemeValue paintScheme;
        private SpacePlatformAppearance.MobilityValue mobility;
        private SpacePlatformAppearance.DamageValue damage;
        private SpacePlatformAppearance.SmokeValue smoke;
        private SpacePlatformAppearance.FlamingValue flaming;
        private SpacePlatformAppearance.FrozenStatusValue frozenStatus;
        private SpacePlatformAppearance.PowerPlantStatusValue powerPlantStatus;
        private SpacePlatformAppearance.StateValue state;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SpacePlatformAppearance left, SpacePlatformAppearance right)
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
        public static bool operator ==(SpacePlatformAppearance left, SpacePlatformAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(SpacePlatformAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator SpacePlatformAppearance(uint value)
        {
            return SpacePlatformAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static SpacePlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance, represented by the uint value.</returns>
        public static SpacePlatformAppearance FromUInt32(uint value)
        {
            SpacePlatformAppearance ps = new SpacePlatformAppearance();

            uint mask0 = 0x0001;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.PaintScheme = (SpacePlatformAppearance.PaintSchemeValue)newValue0;

            uint mask1 = 0x0002;
            byte shift1 = 1;
            uint newValue1 = value & mask1 >> shift1;
            ps.Mobility = (SpacePlatformAppearance.MobilityValue)newValue1;

            uint mask3 = 0x0018;
            byte shift3 = 3;
            uint newValue3 = value & mask3 >> shift3;
            ps.Damage = (SpacePlatformAppearance.DamageValue)newValue3;

            uint mask4 = 0x0060;
            byte shift4 = 5;
            uint newValue4 = value & mask4 >> shift4;
            ps.Smoke = (SpacePlatformAppearance.SmokeValue)newValue4;

            uint mask6 = 0x8000;
            byte shift6 = 15;
            uint newValue6 = value & mask6 >> shift6;
            ps.Flaming = (SpacePlatformAppearance.FlamingValue)newValue6;

            uint mask8 = 0x200000;
            byte shift8 = 21;
            uint newValue8 = value & mask8 >> shift8;
            ps.FrozenStatus = (SpacePlatformAppearance.FrozenStatusValue)newValue8;

            uint mask9 = 0x400000;
            byte shift9 = 22;
            uint newValue9 = value & mask9 >> shift9;
            ps.PowerPlantStatus = (SpacePlatformAppearance.PowerPlantStatusValue)newValue9;

            uint mask10 = 0x800000;
            byte shift10 = 23;
            uint newValue10 = value & mask10 >> shift10;
            ps.State = (SpacePlatformAppearance.StateValue)newValue10;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public SpacePlatformAppearance.PaintSchemeValue PaintScheme
        {
            get { return this.paintScheme; }
            set { this.paintScheme = value; }
        }

        /// <summary>
        /// Gets or sets the mobility.
        /// </summary>
        /// <value>The mobility.</value>
        public SpacePlatformAppearance.MobilityValue Mobility
        {
            get { return this.mobility; }
            set { this.mobility = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public SpacePlatformAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public SpacePlatformAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public SpacePlatformAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public SpacePlatformAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public SpacePlatformAppearance.PowerPlantStatusValue PowerPlantStatus
        {
            get { return this.powerPlantStatus; }
            set { this.powerPlantStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public SpacePlatformAppearance.StateValue State
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

            if (!(obj is SpacePlatformAppearance))
            {
                return false;
            }

            return this.Equals((SpacePlatformAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SpacePlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.PaintScheme == other.PaintScheme &&
                this.Mobility == other.Mobility &&
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.Flaming == other.Flaming &&
                this.FrozenStatus == other.FrozenStatus &&
                this.PowerPlantStatus == other.PowerPlantStatus &&
                this.State == other.State;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.SpacePlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.PaintScheme << 0);
            val |= (uint)((uint)this.Mobility << 1);
            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.PowerPlantStatus << 22);
            val |= (uint)((uint)this.State << 23);

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
                hash = (hash * 29) + this.PaintScheme.GetHashCode();
                hash = (hash * 29) + this.Mobility.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Smoke.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
            }

            return hash;
        }
    }
}
