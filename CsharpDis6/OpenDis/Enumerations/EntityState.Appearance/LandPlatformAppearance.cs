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
    /// Enumeration values for LandPlatformAppearance (es.appear.platform.land, Platforms of the Land Domain,
    /// section 4.3.1.1)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct LandPlatformAppearance : IHashable<LandPlatformAppearance>
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
        /// Describes characteristics of fire-power kill
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes characteristics of fire-power kill")]
        public enum FirePowerValue : uint
        {
            /// <summary>
            /// No fire-power kill
            /// </summary>
            NoFirePowerKill = 0,

            /// <summary>
            /// Fire-power kill
            /// </summary>
            FirePowerKill = 1
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
        /// Describes the size of the dust cloud trailing effect for the Effects entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the size of the dust cloud trailing effect for the Effects entity")]
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
        /// Describes the state of the primary hatch
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of the primary hatch")]
        public enum HatchValue : uint
        {
            /// <summary>
            /// Not applicable
            /// </summary>
            NotApplicable = 0,

            /// <summary>
            /// Primary hatch is closed
            /// </summary>
            PrimaryHatchIsClosed = 1,

            /// <summary>
            /// Primary hatch is popped
            /// </summary>
            PrimaryHatchIsPopped = 2,

            /// <summary>
            /// Primary hatch is popped and a person is visible under hatch
            /// </summary>
            PrimaryHatchIsPoppedAndAPersonIsVisibleUnderHatch = 3,

            /// <summary>
            /// Primary hatch is open
            /// </summary>
            PrimaryHatchIsOpen = 4,

            /// <summary>
            /// Primary hatch is open and person is visible
            /// </summary>
            PrimaryHatchIsOpenAndPersonIsVisible = 5,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 6
        }

        /// <summary>
        /// Describes whether Head Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Head Lights are on or off.")]
        public enum HeadLightsValue : uint
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
        /// Describes whether Tail Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Tail Lights are on or off.")]
        public enum TailLightsValue : uint
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
        /// Describes whether Brake Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Brake Lights are on or off.")]
        public enum BrakeLightsValue : uint
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
            /// Off
            /// </summary>
            Off = 0,

            /// <summary>
            /// On
            /// </summary>
            On = 1
        }

        /// <summary>
        /// Describes the elevated status of the platform's primary launcher
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the elevated status of the platform's primary launcher")]
        public enum LauncherValue : uint
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
        /// Describes the type of camouflage
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the type of camouflage")]
        public enum CamouflageTypeValue : uint
        {
            /// <summary>
            /// Desert camouflage
            /// </summary>
            DesertCamouflage = 0,

            /// <summary>
            /// Winter camouflage
            /// </summary>
            WinterCamouflage = 1,

            /// <summary>
            /// Forest camouflage
            /// </summary>
            ForestCamouflage = 2,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 3
        }

        /// <summary>
        /// Describes the type of concealment
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the type of concealment")]
        public enum ConcealedValue : uint
        {
            /// <summary>
            /// Not concealed
            /// </summary>
            NotConcealed = 0,

            /// <summary>
            /// Entity in a prepared concealed position (with netting, etc.)
            /// </summary>
            EntityInAPreparedConcealedPositionWithNettingEtc = 1
        }

        /// <summary>
        /// Describes the frozen status of a Land Entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a Land Entity")]
        public enum FrozenStatusValue : uint
        {
            /// <summary>
            /// Not frozen
            /// </summary>
            NotFrozen = 0,

            /// <summary>
            /// Frozen (Frozen entities should not be dead-reckoned, i.e. should be displayed as fixed at the current location
            /// even if non-zero velocity, acceleration or rotation data received from the frozen entity)
            /// </summary>
            FrozenFrozenEntitiesShouldNotBeDeadReckonedIEShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonZeroVelocityAccelerationOrRotationDataReceivedFromTheFrozenEntity = 1
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
        /// Describes the state of a Land Entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a Land Entity")]
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
        /// Describes the status of a tent extension
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the status of a tent extension")]
        public enum TentValue : uint
        {
            /// <summary>
            /// Not extended
            /// </summary>
            NotExtended = 0,

            /// <summary>
            /// Extended
            /// </summary>
            Extended = 1
        }

        /// <summary>
        /// Describes the status of a ramp
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the status of a ramp")]
        public enum RampValue : uint
        {
            /// <summary>
            /// Up
            /// </summary>
            Up = 0,

            /// <summary>
            /// Down
            /// </summary>
            Down = 1
        }

        /// <summary>
        /// Describes whether Blackout Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Blackout Lights are on or off.")]
        public enum BlackoutLightsValue : uint
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
        /// Describes whether Blackout Brake Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Blackout Brake Lights are on or off.")]
        public enum BlackoutBrakeLightsValue : uint
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
        /// Describes the surrender state of the vehicle occupants
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the surrender state of the vehicle occupants")]
        public enum SurrenderStateValue : uint
        {
            /// <summary>
            /// Not surrendered
            /// </summary>
            NotSurrendered = 0,

            /// <summary>
            /// Surrender
            /// </summary>
            Surrender = 1
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
        public static bool operator !=(LandPlatformAppearance left, LandPlatformAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(LandPlatformAppearance left, LandPlatformAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="LandPlatformAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="LandPlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(LandPlatformAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="LandPlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator LandPlatformAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="LandPlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="LandPlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="LandPlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static LandPlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="LandPlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="LandPlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="LandPlatformAppearance"/> instance, represented by the uint value.</returns>
        public static LandPlatformAppearance FromUInt32(uint value)
        {
            var ps = new LandPlatformAppearance();

            const uint mask0 = 0x0001;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.PaintScheme = (PaintSchemeValue)newValue0;

            const uint mask1 = 0x0002;
            const byte shift1 = 1;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Mobility = (MobilityValue)newValue1;

            const uint mask2 = 0x0004;
            const byte shift2 = 2;
            uint newValue2 = (value & mask2) >> shift2;
            ps.FirePower = (FirePowerValue)newValue2;

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
            ps.Hatch = (HatchValue)newValue6;

            const uint mask7 = 0x1000;
            const byte shift7 = 12;
            uint newValue7 = (value & mask7) >> shift7;
            ps.HeadLights = (HeadLightsValue)newValue7;

            const uint mask8 = 0x2000;
            const byte shift8 = 13;
            uint newValue8 = (value & mask8) >> shift8;
            ps.TailLights = (TailLightsValue)newValue8;

            const uint mask9 = 0x4000;
            const byte shift9 = 14;
            uint newValue9 = (value & mask9) >> shift9;
            ps.BrakeLights = (BrakeLightsValue)newValue9;

            const uint mask10 = 0x8000;
            const byte shift10 = 15;
            uint newValue10 = (value & mask10) >> shift10;
            ps.Flaming = (FlamingValue)newValue10;

            const uint mask11 = 0x10000;
            const byte shift11 = 16;
            uint newValue11 = (value & mask11) >> shift11;
            ps.Launcher = (LauncherValue)newValue11;

            const uint mask12 = 0x60000;
            const byte shift12 = 17;
            uint newValue12 = (value & mask12) >> shift12;
            ps.CamouflageType = (CamouflageTypeValue)newValue12;

            const uint mask13 = 0x80000;
            const byte shift13 = 19;
            uint newValue13 = (value & mask13) >> shift13;
            ps.Concealed = (ConcealedValue)newValue13;

            const uint mask15 = 0x200000;
            const byte shift15 = 21;
            uint newValue15 = (value & mask15) >> shift15;
            ps.FrozenStatus = (FrozenStatusValue)newValue15;

            const uint mask16 = 0x400000;
            const byte shift16 = 22;
            uint newValue16 = (value & mask16) >> shift16;
            ps.PowerPlantStatus = (PowerPlantStatusValue)newValue16;

            const uint mask17 = 0x800000;
            const byte shift17 = 23;
            uint newValue17 = (value & mask17) >> shift17;
            ps.State = (StateValue)newValue17;

            const uint mask18 = 0x1000000;
            const byte shift18 = 24;
            uint newValue18 = (value & mask18) >> shift18;
            ps.Tent = (TentValue)newValue18;

            const uint mask19 = 0x2000000;
            const byte shift19 = 25;
            uint newValue19 = (value & mask19) >> shift19;
            ps.Ramp = (RampValue)newValue19;

            const uint mask20 = 0x4000000;
            const byte shift20 = 26;
            uint newValue20 = (value & mask20) >> shift20;
            ps.BlackoutLights = (BlackoutLightsValue)newValue20;

            const uint mask21 = 0x8000000;
            const byte shift21 = 27;
            uint newValue21 = (value & mask21) >> shift21;
            ps.BlackoutBrakeLights = (BlackoutBrakeLightsValue)newValue21;

            const uint mask22 = 0x10000000;
            const byte shift22 = 28;
            uint newValue22 = (value & mask22) >> shift22;
            ps.SpotLights = (SpotLightsValue)newValue22;

            const uint mask23 = 0x20000000;
            const byte shift23 = 29;
            uint newValue23 = (value & mask23) >> shift23;
            ps.InteriorLights = (InteriorLightsValue)newValue23;

            const uint mask24 = 0x40000000;
            const byte shift24 = 30;
            uint newValue24 = (value & mask24) >> shift24;
            ps.SurrenderState = (SurrenderStateValue)newValue24;

            const uint mask25 = 0x80000000;
            const byte shift25 = 31;
            uint newValue25 = (value & mask25) >> shift25;
            ps.MaskedCloaked = (MaskedCloakedValue)newValue25;

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
        /// Gets or sets the firepower.
        /// </summary>
        /// <value>The firepower.</value>
        public FirePowerValue FirePower { get; set; }

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
        /// Gets or sets the hatch.
        /// </summary>
        /// <value>The hatch.</value>
        public HatchValue Hatch { get; set; }

        /// <summary>
        /// Gets or sets the headlights.
        /// </summary>
        /// <value>The headlights.</value>
        public HeadLightsValue HeadLights { get; set; }

        /// <summary>
        /// Gets or sets the taillights.
        /// </summary>
        /// <value>The taillights.</value>
        public TailLightsValue TailLights { get; set; }

        /// <summary>
        /// Gets or sets the brakelights.
        /// </summary>
        /// <value>The brakelights.</value>
        public BrakeLightsValue BrakeLights { get; set; }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public FlamingValue Flaming { get; set; }

        /// <summary>
        /// Gets or sets the launcher.
        /// </summary>
        /// <value>The launcher.</value>
        public LauncherValue Launcher { get; set; }

        /// <summary>
        /// Gets or sets the camouflagetype.
        /// </summary>
        /// <value>The camouflagetype.</value>
        public CamouflageTypeValue CamouflageType { get; set; }

        /// <summary>
        /// Gets or sets the concealed.
        /// </summary>
        /// <value>The concealed.</value>
        public ConcealedValue Concealed { get; set; }

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
        /// Gets or sets the tent.
        /// </summary>
        /// <value>The tent.</value>
        public TentValue Tent { get; set; }

        /// <summary>
        /// Gets or sets the ramp.
        /// </summary>
        /// <value>The ramp.</value>
        public RampValue Ramp { get; set; }

        /// <summary>
        /// Gets or sets the blackoutlights.
        /// </summary>
        /// <value>The blackoutlights.</value>
        public BlackoutLightsValue BlackoutLights { get; set; }

        /// <summary>
        /// Gets or sets the blackoutbrakelights.
        /// </summary>
        /// <value>The blackoutbrakelights.</value>
        public BlackoutBrakeLightsValue BlackoutBrakeLights { get; set; }

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

        /// <summary>
        /// Gets or sets the surrenderstate.
        /// </summary>
        /// <value>The surrenderstate.</value>
        public SurrenderStateValue SurrenderState { get; set; }

        /// <summary>
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public MaskedCloakedValue MaskedCloaked { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is LandPlatformAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="LandPlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="LandPlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="LandPlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LandPlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return PaintScheme == other.PaintScheme &&
                Mobility == other.Mobility &&
                FirePower == other.FirePower &&
                Damage == other.Damage &&
                Smoke == other.Smoke &&
                TrailingEffects == other.TrailingEffects &&
                Hatch == other.Hatch &&
                HeadLights == other.HeadLights &&
                TailLights == other.TailLights &&
                BrakeLights == other.BrakeLights &&
                Flaming == other.Flaming &&
                Launcher == other.Launcher &&
                CamouflageType == other.CamouflageType &&
                Concealed == other.Concealed &&
                FrozenStatus == other.FrozenStatus &&
                PowerPlantStatus == other.PowerPlantStatus &&
                State == other.State &&
                Tent == other.Tent &&
                Ramp == other.Ramp &&
                BlackoutLights == other.BlackoutLights &&
                BlackoutBrakeLights == other.BlackoutBrakeLights &&
                SpotLights == other.SpotLights &&
                InteriorLights == other.InteriorLights &&
                SurrenderState == other.SurrenderState &&
                MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="LandPlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="LandPlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="LandPlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="LandPlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)PaintScheme << 0;
            val |= (uint)Mobility << 1;
            val |= (uint)FirePower << 2;
            val |= (uint)Damage << 3;
            val |= (uint)Smoke << 5;
            val |= (uint)TrailingEffects << 7;
            val |= (uint)Hatch << 9;
            val |= (uint)HeadLights << 12;
            val |= (uint)TailLights << 13;
            val |= (uint)BrakeLights << 14;
            val |= (uint)Flaming << 15;
            val |= (uint)Launcher << 16;
            val |= (uint)CamouflageType << 17;
            val |= (uint)Concealed << 19;
            val |= (uint)FrozenStatus << 21;
            val |= (uint)PowerPlantStatus << 22;
            val |= (uint)State << 23;
            val |= (uint)Tent << 24;
            val |= (uint)Ramp << 25;
            val |= (uint)BlackoutLights << 26;
            val |= (uint)BlackoutBrakeLights << 27;
            val |= (uint)SpotLights << 28;
            val |= (uint)InteriorLights << 29;
            val |= (uint)SurrenderState << 30;
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
                hash = (hash * 29) + PaintScheme.GetHashCode();
                hash = (hash * 29) + Mobility.GetHashCode();
                hash = (hash * 29) + FirePower.GetHashCode();
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Smoke.GetHashCode();
                hash = (hash * 29) + TrailingEffects.GetHashCode();
                hash = (hash * 29) + Hatch.GetHashCode();
                hash = (hash * 29) + HeadLights.GetHashCode();
                hash = (hash * 29) + TailLights.GetHashCode();
                hash = (hash * 29) + BrakeLights.GetHashCode();
                hash = (hash * 29) + Flaming.GetHashCode();
                hash = (hash * 29) + Launcher.GetHashCode();
                hash = (hash * 29) + CamouflageType.GetHashCode();
                hash = (hash * 29) + Concealed.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + Tent.GetHashCode();
                hash = (hash * 29) + Ramp.GetHashCode();
                hash = (hash * 29) + BlackoutLights.GetHashCode();
                hash = (hash * 29) + BlackoutBrakeLights.GetHashCode();
                hash = (hash * 29) + SpotLights.GetHashCode();
                hash = (hash * 29) + InteriorLights.GetHashCode();
                hash = (hash * 29) + SurrenderState.GetHashCode();
                hash = (hash * 29) + MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
