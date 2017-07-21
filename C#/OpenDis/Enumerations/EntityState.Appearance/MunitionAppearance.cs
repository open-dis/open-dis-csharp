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
    /// Enumeration values for MunitionAppearance (es.appear.munition, Munition Kind, 
    /// section 4.3.2)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct MunitionAppearance
    {
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
        /// Describes status or location of smoke and vapor emanating from an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes status or location of smoke and vapor emanating from an entity")]
        public enum SmokeValue : uint
        {
            /// <summary>
            /// Not smoking
            /// </summary>
            NotSmoking = 0,

            /// <summary>
            /// Smoke or vapor is emanating from the entity
            /// </summary>
            SmokeOrVaporIsEmanatingFromTheEntity = 1,

            /// <summary>
            /// Entity is emitting motor smoke
            /// </summary>
            EntityIsEmittingMotorSmoke = 2,

            /// <summary>
            /// Entity is emitting motor smoke, and smoke or vapor is emanating from the entity
            /// </summary>
            EntityIsEmittingMotorSmokeAndSmokeOrVaporIsEmanatingFromTheEntity = 3
        }

        /// <summary>
        /// Describes the size of the vapor trail trailing effect for the effectsentity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the size of the vapor trail trailing effect for the effectsentity")]
        public enum TrailingEffectsValue : uint
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// Small
            /// </summary>
            Small = 1,

            /// <summary>
            /// Medium
            /// </summary>
            Medium = 2,

            /// <summary>
            /// Large
            /// </summary>
            Large = 3
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
        /// Describes the presence of a guided munition's launch flash
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the presence of a guided munition's launch flash")]
        public enum LaunchFlashValue : uint
        {
            /// <summary>
            /// No launch flash present
            /// </summary>
            NoLaunchFlashPresent = 0,

            /// <summary>
            /// Launch flash present
            /// </summary>
            LaunchFlashPresent = 1
        }

        /// <summary>
        /// Describes the frozen status of a guided munition
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a guided munition")]
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
        /// Describes the power-plant status of a guided munition
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the power-plant status of a guided munition")]
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
        /// Describes the state of a guided munition
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a guided munition")]
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
        /// Describes if the entity is Masked / Cloaked or Not
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes if the entity is Masked / Cloaked or Not")]
        public enum MaskedCloakedValue : uint
        {
            /// <summary>
            /// Not Masked / Not Cloaked
            /// </summary>
            NotMaskedNotCloaked = 0,

            /// <summary>
            /// Masked / Cloaked
            /// </summary>
            MaskedCloaked = 1
        }

        private MunitionAppearance.DamageValue damage;
        private MunitionAppearance.SmokeValue smoke;
        private MunitionAppearance.TrailingEffectsValue trailingEffects;
        private MunitionAppearance.FlamingValue flaming;
        private MunitionAppearance.LaunchFlashValue launchFlash;
        private MunitionAppearance.FrozenStatusValue frozenStatus;
        private MunitionAppearance.PowerPlantStatusValue powerPlantStatus;
        private MunitionAppearance.StateValue state;
        private MunitionAppearance.MaskedCloakedValue maskedCloaked;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MunitionAppearance left, MunitionAppearance right)
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
        public static bool operator ==(MunitionAppearance left, MunitionAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(MunitionAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator MunitionAppearance(uint value)
        {
            return MunitionAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static MunitionAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance, represented by the uint value.</returns>
        public static MunitionAppearance FromUInt32(uint value)
        {
            MunitionAppearance ps = new MunitionAppearance();

            uint mask1 = 0x0018;
            byte shift1 = 3;
            uint newValue1 = value & mask1 >> shift1;
            ps.Damage = (MunitionAppearance.DamageValue)newValue1;

            uint mask2 = 0x0060;
            byte shift2 = 5;
            uint newValue2 = value & mask2 >> shift2;
            ps.Smoke = (MunitionAppearance.SmokeValue)newValue2;

            uint mask3 = 0x0180;
            byte shift3 = 7;
            uint newValue3 = value & mask3 >> shift3;
            ps.TrailingEffects = (MunitionAppearance.TrailingEffectsValue)newValue3;

            uint mask5 = 0x8000;
            byte shift5 = 15;
            uint newValue5 = value & mask5 >> shift5;
            ps.Flaming = (MunitionAppearance.FlamingValue)newValue5;

            uint mask6 = 0x10000;
            byte shift6 = 16;
            uint newValue6 = value & mask6 >> shift6;
            ps.LaunchFlash = (MunitionAppearance.LaunchFlashValue)newValue6;

            uint mask8 = 0x200000;
            byte shift8 = 21;
            uint newValue8 = value & mask8 >> shift8;
            ps.FrozenStatus = (MunitionAppearance.FrozenStatusValue)newValue8;

            uint mask9 = 0x400000;
            byte shift9 = 22;
            uint newValue9 = value & mask9 >> shift9;
            ps.PowerPlantStatus = (MunitionAppearance.PowerPlantStatusValue)newValue9;

            uint mask10 = 0x800000;
            byte shift10 = 23;
            uint newValue10 = value & mask10 >> shift10;
            ps.State = (MunitionAppearance.StateValue)newValue10;

            uint mask12 = 0x80000000;
            byte shift12 = 31;
            uint newValue12 = value & mask12 >> shift12;
            ps.MaskedCloaked = (MunitionAppearance.MaskedCloakedValue)newValue12;

            return ps;
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public MunitionAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public MunitionAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the trailingeffects.
        /// </summary>
        /// <value>The trailingeffects.</value>
        public MunitionAppearance.TrailingEffectsValue TrailingEffects
        {
            get { return this.trailingEffects; }
            set { this.trailingEffects = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public MunitionAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the launchflash.
        /// </summary>
        /// <value>The launchflash.</value>
        public MunitionAppearance.LaunchFlashValue LaunchFlash
        {
            get { return this.launchFlash; }
            set { this.launchFlash = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public MunitionAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public MunitionAppearance.PowerPlantStatusValue PowerPlantStatus
        {
            get { return this.powerPlantStatus; }
            set { this.powerPlantStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public MunitionAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public MunitionAppearance.MaskedCloakedValue MaskedCloaked
        {
            get { return this.maskedCloaked; }
            set { this.maskedCloaked = value; }
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

            if (!(obj is MunitionAppearance))
            {
                return false;
            }

            return this.Equals((MunitionAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MunitionAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.TrailingEffects == other.TrailingEffects &&
                this.Flaming == other.Flaming &&
                this.LaunchFlash == other.LaunchFlash &&
                this.FrozenStatus == other.FrozenStatus &&
                this.PowerPlantStatus == other.PowerPlantStatus &&
                this.State == other.State &&
                this.MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.MunitionAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.TrailingEffects << 7);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.LaunchFlash << 16);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.PowerPlantStatus << 22);
            val |= (uint)((uint)this.State << 23);
            val |= (uint)((uint)this.MaskedCloaked << 31);

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
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Smoke.GetHashCode();
                hash = (hash * 29) + this.TrailingEffects.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.LaunchFlash.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
