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
    /// Enumeration values for AirPlatformAppearance (es.appear.platform.air, Platforms of the Air Domain,
    /// section 4.3.1.2)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct AirPlatformAppearance : IHashable<AirPlatformAppearance>
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
        /// Describes characteristics of Propulsion kill
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes characteristics of Propulsion kill")]
        public enum PropulsionValue : uint
        {
            /// <summary>
            /// No Propulsion kill
            /// </summary>
            NoPropulsionKill = 0,

            /// <summary>
            /// Propulsion kill
            /// </summary>
            PropulsionKill = 1
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
        /// Describes the size of the contrails or ionization trailing effects from an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the size of the contrails or ionization trailing effects from an entity")]
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
        /// Describes the state of the canopy
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of the canopy")]
        public enum CanopyValue : uint
        {
            /// <summary>
            /// Not applicable
            /// </summary>
            NotApplicable = 0,

            /// <summary>
            /// Canopy is closed
            /// </summary>
            CanopyIsClosed = 1,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 2,

            /// <summary>
            /// Canopy is open
            /// </summary>
            CanopyIsOpen = 4,

            /// <summary>
            /// null
            /// </summary>
            Unknown2 = 5
        }

        /// <summary>
        /// Describes whether Landing Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Landing Lights are on or off.")]
        public enum LandingLightsValue : uint
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
        /// Describes whether Navigation Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Navigation Lights are on or off.")]
        public enum NavigationLightsValue : uint
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
        /// Describes whether Anti-Collision Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Anti-Collision Lights are on or off.")]
        public enum AntiCollisionLightsValue : uint
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
        /// Describes whether flames are trailing from an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether flames are trailing from an entity")]
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
        /// Describes the status of an air platform's afterburner
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the status of an air platform's afterburner")]
        public enum AfterburnerValue : uint
        {
            /// <summary>
            /// Afterburner not on
            /// </summary>
            AfterburnerNotOn = 0,

            /// <summary>
            /// Afterburner on
            /// </summary>
            AfterburnerOn = 1
        }

        /// <summary>
        /// Describes the frozen status of a air platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a air platform")]
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
        /// Describes the state of a air platform
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a air platform")]
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
        /// Describes whether Formation Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Formation Lights are on or off.")]
        public enum FormationLightsValue : uint
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
        public static bool operator !=(AirPlatformAppearance left, AirPlatformAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AirPlatformAppearance left, AirPlatformAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="AirPlatformAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="AirPlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(AirPlatformAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="AirPlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator AirPlatformAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="AirPlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="AirPlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="AirPlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static AirPlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="AirPlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="AirPlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="AirPlatformAppearance"/> instance, represented by the uint value.</returns>
        public static AirPlatformAppearance FromUInt32(uint value)
        {
            var ps = new AirPlatformAppearance();

            const uint mask0 = 0x0001;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.PaintScheme = (PaintSchemeValue)newValue0;

            const uint mask1 = 0x0002;
            const byte shift1 = 1;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Propulsion = (PropulsionValue)newValue1;

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

            const uint mask6 = 0x0e00;
            const byte shift6 = 9;
            uint newValue6 = (value & mask6) >> shift6;
            ps.Canopy = (CanopyValue)newValue6;

            const uint mask7 = 0x1000;
            const byte shift7 = 12;
            uint newValue7 = (value & mask7) >> shift7;
            ps.LandingLights = (LandingLightsValue)newValue7;

            const uint mask8 = 0x2000;
            const byte shift8 = 13;
            uint newValue8 = (value & mask8) >> shift8;
            ps.NavigationLights = (NavigationLightsValue)newValue8;

            const uint mask9 = 0x4000;
            const byte shift9 = 14;
            uint newValue9 = (value & mask9) >> shift9;
            ps.AntiCollisionLights = (AntiCollisionLightsValue)newValue9;

            const uint mask10 = 0x8000;
            const byte shift10 = 15;
            uint newValue10 = (value & mask10) >> shift10;
            ps.Flaming = (FlamingValue)newValue10;

            const uint mask11 = 0x10000;
            const byte shift11 = 16;
            uint newValue11 = (value & mask11) >> shift11;
            ps.Afterburner = (AfterburnerValue)newValue11;

            const uint mask13 = 0x200000;
            const byte shift13 = 21;
            uint newValue13 = (value & mask13) >> shift13;
            ps.FrozenStatus = (FrozenStatusValue)newValue13;

            const uint mask14 = 0x400000;
            const byte shift14 = 22;
            uint newValue14 = (value & mask14) >> shift14;
            ps.PowerPlantStatus = (PowerPlantStatusValue)newValue14;

            const uint mask15 = 0x800000;
            const byte shift15 = 23;
            uint newValue15 = (value & mask15) >> shift15;
            ps.State = (StateValue)newValue15;

            const uint mask16 = 0x1000000;
            const byte shift16 = 24;
            uint newValue16 = (value & mask16) >> shift16;
            ps.FormationLights = (FormationLightsValue)newValue16;

            const uint mask18 = 0x10000000;
            const byte shift18 = 28;
            uint newValue18 = (value & mask18) >> shift18;
            ps.SpotLights = (SpotLightsValue)newValue18;

            const uint mask19 = 0x20000000;
            const byte shift19 = 29;
            uint newValue19 = (value & mask19) >> shift19;
            ps.InteriorLights = (InteriorLightsValue)newValue19;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public PaintSchemeValue PaintScheme { get; set; }

        /// <summary>
        /// Gets or sets the propulsion.
        /// </summary>
        /// <value>The propulsion.</value>
        public PropulsionValue Propulsion { get; set; }

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
        /// Gets or sets the canopy.
        /// </summary>
        /// <value>The canopy.</value>
        public CanopyValue Canopy { get; set; }

        /// <summary>
        /// Gets or sets the landinglights.
        /// </summary>
        /// <value>The landinglights.</value>
        public LandingLightsValue LandingLights { get; set; }

        /// <summary>
        /// Gets or sets the navigationlights.
        /// </summary>
        /// <value>The navigationlights.</value>
        public NavigationLightsValue NavigationLights { get; set; }

        /// <summary>
        /// Gets or sets the anticollisionlights.
        /// </summary>
        /// <value>The anticollisionlights.</value>
        public AntiCollisionLightsValue AntiCollisionLights { get; set; }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public FlamingValue Flaming { get; set; }

        /// <summary>
        /// Gets or sets the afterburner.
        /// </summary>
        /// <value>The afterburner.</value>
        public AfterburnerValue Afterburner { get; set; }

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
        /// Gets or sets the formationlights.
        /// </summary>
        /// <value>The formationlights.</value>
        public FormationLightsValue FormationLights { get; set; }

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
        public override bool Equals(object obj)
            => obj is AirPlatformAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="AirPlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="AirPlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="AirPlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AirPlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return PaintScheme == other.PaintScheme &&
                Propulsion == other.Propulsion &&
                Damage == other.Damage &&
                Smoke == other.Smoke &&
                TrailingEffects == other.TrailingEffects &&
                Canopy == other.Canopy &&
                LandingLights == other.LandingLights &&
                NavigationLights == other.NavigationLights &&
                AntiCollisionLights == other.AntiCollisionLights &&
                Flaming == other.Flaming &&
                Afterburner == other.Afterburner &&
                FrozenStatus == other.FrozenStatus &&
                PowerPlantStatus == other.PowerPlantStatus &&
                State == other.State &&
                FormationLights == other.FormationLights &&
                SpotLights == other.SpotLights &&
                InteriorLights == other.InteriorLights;
        }

        /// <summary>
        /// Converts the instance of <see cref="AirPlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="AirPlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="AirPlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="AirPlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)PaintScheme << 0;
            val |= (uint)Propulsion << 1;
            val |= (uint)Damage << 3;
            val |= (uint)Smoke << 5;
            val |= (uint)TrailingEffects << 7;
            val |= (uint)Canopy << 9;
            val |= (uint)LandingLights << 12;
            val |= (uint)NavigationLights << 13;
            val |= (uint)AntiCollisionLights << 14;
            val |= (uint)Flaming << 15;
            val |= (uint)Afterburner << 16;
            val |= (uint)FrozenStatus << 21;
            val |= (uint)PowerPlantStatus << 22;
            val |= (uint)State << 23;
            val |= (uint)FormationLights << 24;
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
                hash = (hash * 29) + Propulsion.GetHashCode();
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Smoke.GetHashCode();
                hash = (hash * 29) + TrailingEffects.GetHashCode();
                hash = (hash * 29) + Canopy.GetHashCode();
                hash = (hash * 29) + LandingLights.GetHashCode();
                hash = (hash * 29) + NavigationLights.GetHashCode();
                hash = (hash * 29) + AntiCollisionLights.GetHashCode();
                hash = (hash * 29) + Flaming.GetHashCode();
                hash = (hash * 29) + Afterburner.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + FormationLights.GetHashCode();
                hash = (hash * 29) + SpotLights.GetHashCode();
                hash = (hash * 29) + InteriorLights.GetHashCode();
            }

            return hash;
        }
    }
}
