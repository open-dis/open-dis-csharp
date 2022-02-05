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
    public struct MunitionAppearance : IHashable<MunitionAppearance>
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
            /// Frozen (Frozen entities should not be dead-reckoned, i.e. they should be displayed as fixed at the current location
            /// even if nonzero velocity, acceleration or rotation data is received from the frozen entity)
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

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MunitionAppearance left, MunitionAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MunitionAppearance left, MunitionAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="MunitionAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="MunitionAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(MunitionAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="MunitionAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator MunitionAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="MunitionAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="MunitionAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="MunitionAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static MunitionAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="MunitionAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="MunitionAppearance"/> instance.</param>
        /// <returns>The <see cref="MunitionAppearance"/> instance, represented by the uint value.</returns>
        public static MunitionAppearance FromUInt32(uint value)
        {
            var ps = new MunitionAppearance();

            const uint mask1 = 0x0018;
            const byte shift1 = 3;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Damage = (DamageValue)newValue1;

            const uint mask2 = 0x0060;
            const byte shift2 = 5;
            uint newValue2 = (value & mask2) >> shift2;
            ps.Smoke = (SmokeValue)newValue2;

            const uint mask3 = 0x0180;
            const byte shift3 = 7;
            uint newValue3 = (value & mask3) >> shift3;
            ps.TrailingEffects = (TrailingEffectsValue)newValue3;

            const uint mask5 = 0x8000;
            const byte shift5 = 15;
            uint newValue5 = (value & mask5) >> shift5;
            ps.Flaming = (FlamingValue)newValue5;

            const uint mask6 = 0x10000;
            const byte shift6 = 16;
            uint newValue6 = (value & mask6) >> shift6;
            ps.LaunchFlash = (LaunchFlashValue)newValue6;

            const uint mask8 = 0x200000;
            const byte shift8 = 21;
            uint newValue8 = (value & mask8) >> shift8;
            ps.FrozenStatus = (FrozenStatusValue)newValue8;

            const uint mask9 = 0x400000;
            const byte shift9 = 22;
            uint newValue9 = (value & mask9) >> shift9;
            ps.PowerPlantStatus = (PowerPlantStatusValue)newValue9;

            const uint mask10 = 0x800000;
            const byte shift10 = 23;
            uint newValue10 = (value & mask10) >> shift10;
            ps.State = (StateValue)newValue10;

            const uint mask12 = 0x80000000;
            const byte shift12 = 31;
            uint newValue12 = (value & mask12) >> shift12;
            ps.MaskedCloaked = (MaskedCloakedValue)newValue12;

            return ps;
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public DamageValue Damage { get; set; }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public SmokeValue Smoke { get; set; }

        /// <summary>
        /// Gets or sets the trailingeffects.
        /// </summary>
        /// <value>The trailingeffects.</value>
        public TrailingEffectsValue TrailingEffects { get; set; }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public FlamingValue Flaming { get; set; }

        /// <summary>
        /// Gets or sets the launchflash.
        /// </summary>
        /// <value>The launchflash.</value>
        public LaunchFlashValue LaunchFlash { get; set; }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public FrozenStatusValue FrozenStatus { get; set; }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public PowerPlantStatusValue PowerPlantStatus { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public StateValue State { get; set; }

        /// <summary>
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public MaskedCloakedValue MaskedCloaked { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is MunitionAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="MunitionAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="MunitionAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="MunitionAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MunitionAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Damage == other.Damage &&
                Smoke == other.Smoke &&
                TrailingEffects == other.TrailingEffects &&
                Flaming == other.Flaming &&
                LaunchFlash == other.LaunchFlash &&
                FrozenStatus == other.FrozenStatus &&
                PowerPlantStatus == other.PowerPlantStatus &&
                State == other.State &&
                MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="MunitionAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="MunitionAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="MunitionAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="MunitionAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Damage << 3;
            val |= (uint)Smoke << 5;
            val |= (uint)TrailingEffects << 7;
            val |= (uint)Flaming << 15;
            val |= (uint)LaunchFlash << 16;
            val |= (uint)FrozenStatus << 21;
            val |= (uint)PowerPlantStatus << 22;
            val |= (uint)State << 23;
            val |= (uint)MaskedCloaked << 31;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Smoke.GetHashCode();
                hash = (hash * 29) + TrailingEffects.GetHashCode();
                hash = (hash * 29) + Flaming.GetHashCode();
                hash = (hash * 29) + LaunchFlash.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
