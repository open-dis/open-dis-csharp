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
    /// Enumeration values for SurfacePlatformAppearance (es.appear.platform.surface, Platforms of the Surface Domain,
    /// section 4.3.1.3)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct SurfacePlatformAppearance : IHashable<SurfacePlatformAppearance>
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
            /// Entity is emitting engine smoke
            /// </summary>
            EntityIsEmittingEngineSmoke = 2,

            /// <summary>
            /// Entity is emitting engine smoke, and smoke plume is rising from the entity
            /// </summary>
            EntityIsEmittingEngineSmokeAndSmokePlumeIsRisingFromTheEntity = 3
        }

        /// <summary>
        /// Describes the size of the wake trailing effect for the entity.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the size of the wake trailing effect for the entity.")]
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
        /// Describes whether Running Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Running Lights are on or off.")]
        public enum RunningLightsValue : uint
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
        /// Describes the frozen status of a Surface platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a Surface platform")]
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
        /// Describes the power-plant status of platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the power-plant status of platform")]
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
        /// Describes the state of a Surface platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a Surface platform")]
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
        /// Describes whether Spot Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Spot Lights are on or off.")]
        public enum SpotLightsValue : uint
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
        /// Describes whether Interior Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Interior Lights are on or off.")]
        public enum InteriorLightsValue : uint
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
        public static bool operator !=(SurfacePlatformAppearance left, SurfacePlatformAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(SurfacePlatformAppearance left, SurfacePlatformAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="SurfacePlatformAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="SurfacePlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(SurfacePlatformAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="SurfacePlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator SurfacePlatformAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="SurfacePlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="SurfacePlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="SurfacePlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static SurfacePlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="SurfacePlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="SurfacePlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="SurfacePlatformAppearance"/> instance, represented by the uint value.</returns>
        public static SurfacePlatformAppearance FromUInt32(uint value)
        {
            var ps = new SurfacePlatformAppearance();

            const uint mask0 = 0x0001;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.PaintScheme = (PaintSchemeValue)newValue0;

            const uint mask1 = 0x0002;
            const byte shift1 = 1;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Mobility = (MobilityValue)newValue1;

            const uint mask3 = 0x0018;
            const byte shift3 = 3;
            uint newValue3 = (value & mask3) >> shift3;
            ps.Damage = (DamageValue)newValue3;

            const uint mask4 = 0x0060;
            const byte shift4 = 5;
            uint newValue4 = (value & mask4) >> shift4;
            ps.Smoke = (SmokeValue)newValue4;

            const uint mask5 = 0x0180;
            const byte shift5 = 7;
            uint newValue5 = (value & mask5) >> shift5;
            ps.TrailingEffects = (TrailingEffectsValue)newValue5;

            const uint mask7 = 0x1000;
            const byte shift7 = 12;
            uint newValue7 = (value & mask7) >> shift7;
            ps.RunningLights = (RunningLightsValue)newValue7;

            const uint mask9 = 0x8000;
            const byte shift9 = 15;
            uint newValue9 = (value & mask9) >> shift9;
            ps.Flaming = (FlamingValue)newValue9;

            const uint mask11 = 0x200000;
            const byte shift11 = 21;
            uint newValue11 = (value & mask11) >> shift11;
            ps.FrozenStatus = (FrozenStatusValue)newValue11;

            const uint mask12 = 0x400000;
            const byte shift12 = 22;
            uint newValue12 = (value & mask12) >> shift12;
            ps.PowerPlantStatus = (PowerPlantStatusValue)newValue12;

            const uint mask13 = 0x800000;
            const byte shift13 = 23;
            uint newValue13 = (value & mask13) >> shift13;
            ps.State = (StateValue)newValue13;

            const uint mask15 = 0x10000000;
            const byte shift15 = 28;
            uint newValue15 = (value & mask15) >> shift15;
            ps.SpotLights = (SpotLightsValue)newValue15;

            const uint mask16 = 0x20000000;
            const byte shift16 = 29;
            uint newValue16 = (value & mask16) >> shift16;
            ps.InteriorLights = (InteriorLightsValue)newValue16;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public PaintSchemeValue PaintScheme { get; set; }

        /// <summary>
        /// Gets or sets the mobility.
        /// </summary>
        /// <value>The mobility.</value>
        public MobilityValue Mobility { get; set; }

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
        /// Gets or sets the runninglights.
        /// </summary>
        /// <value>The runninglights.</value>
        public RunningLightsValue RunningLights { get; set; }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public FlamingValue Flaming { get; set; }

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
        /// Gets or sets the spotlights.
        /// </summary>
        /// <value>The spotlights.</value>
        public SpotLightsValue SpotLights { get; set; }

        /// <summary>
        /// Gets or sets the interiorlights.
        /// </summary>
        /// <value>The interiorlights.</value>
        public InteriorLightsValue InteriorLights { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is SurfacePlatformAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="SurfacePlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="SurfacePlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="SurfacePlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SurfacePlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return PaintScheme == other.PaintScheme &&
                Mobility == other.Mobility &&
                Damage == other.Damage &&
                Smoke == other.Smoke &&
                TrailingEffects == other.TrailingEffects &&
                RunningLights == other.RunningLights &&
                Flaming == other.Flaming &&
                FrozenStatus == other.FrozenStatus &&
                PowerPlantStatus == other.PowerPlantStatus &&
                State == other.State &&
                SpotLights == other.SpotLights &&
                InteriorLights == other.InteriorLights;
        }

        /// <summary>
        /// Converts the instance of <see cref="SurfacePlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="SurfacePlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="SurfacePlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="SurfacePlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)PaintScheme << 0;
            val |= (uint)Mobility << 1;
            val |= (uint)Damage << 3;
            val |= (uint)Smoke << 5;
            val |= (uint)TrailingEffects << 7;
            val |= (uint)RunningLights << 12;
            val |= (uint)Flaming << 15;
            val |= (uint)FrozenStatus << 21;
            val |= (uint)PowerPlantStatus << 22;
            val |= (uint)State << 23;
            val |= (uint)SpotLights << 28;
            val |= (uint)InteriorLights << 29;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + PaintScheme.GetHashCode();
                hash = (hash * 29) + Mobility.GetHashCode();
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Smoke.GetHashCode();
                hash = (hash * 29) + TrailingEffects.GetHashCode();
                hash = (hash * 29) + RunningLights.GetHashCode();
                hash = (hash * 29) + Flaming.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + SpotLights.GetHashCode();
                hash = (hash * 29) + InteriorLights.GetHashCode();
            }

            return hash;
        }
    }
}
