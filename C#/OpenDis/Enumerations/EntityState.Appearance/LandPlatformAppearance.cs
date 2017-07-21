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
    public struct LandPlatformAppearance
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
            /// Frozen (Frozen entities should not be dead-reckoned, i.e. should be displayed as fixed at the current location even if non-zero velocity, acceleration or rotation data received from the frozen entity)
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

        private LandPlatformAppearance.PaintSchemeValue paintScheme;
        private LandPlatformAppearance.MobilityValue mobility;
        private LandPlatformAppearance.FirePowerValue firePower;
        private LandPlatformAppearance.DamageValue damage;
        private LandPlatformAppearance.SmokeValue smoke;
        private LandPlatformAppearance.TrailingEffectsValue trailingEffects;
        private LandPlatformAppearance.HatchValue hatch;
        private LandPlatformAppearance.HeadLightsValue headLights;
        private LandPlatformAppearance.TailLightsValue tailLights;
        private LandPlatformAppearance.BrakeLightsValue brakeLights;
        private LandPlatformAppearance.FlamingValue flaming;
        private LandPlatformAppearance.LauncherValue launcher;
        private LandPlatformAppearance.CamouflageTypeValue camouflageType;
        private LandPlatformAppearance.ConcealedValue concealed;
        private LandPlatformAppearance.FrozenStatusValue frozenStatus;
        private LandPlatformAppearance.PowerPlantStatusValue powerPlantStatus;
        private LandPlatformAppearance.StateValue state;
        private LandPlatformAppearance.TentValue tent;
        private LandPlatformAppearance.RampValue ramp;
        private LandPlatformAppearance.BlackoutLightsValue blackoutLights;
        private LandPlatformAppearance.BlackoutBrakeLightsValue blackoutBrakeLights;
        private LandPlatformAppearance.SpotLightsValue spotLights;
        private LandPlatformAppearance.InteriorLightsValue interiorLights;
        private LandPlatformAppearance.SurrenderStateValue surrenderState;
        private LandPlatformAppearance.MaskedCloakedValue maskedCloaked;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LandPlatformAppearance left, LandPlatformAppearance right)
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
        public static bool operator ==(LandPlatformAppearance left, LandPlatformAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(LandPlatformAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator LandPlatformAppearance(uint value)
        {
            return LandPlatformAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static LandPlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance, represented by the uint value.</returns>
        public static LandPlatformAppearance FromUInt32(uint value)
        {
            LandPlatformAppearance ps = new LandPlatformAppearance();

            uint mask0 = 0x0001;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.PaintScheme = (LandPlatformAppearance.PaintSchemeValue)newValue0;

            uint mask1 = 0x0002;
            byte shift1 = 1;
            uint newValue1 = value & mask1 >> shift1;
            ps.Mobility = (LandPlatformAppearance.MobilityValue)newValue1;

            uint mask2 = 0x0004;
            byte shift2 = 2;
            uint newValue2 = value & mask2 >> shift2;
            ps.FirePower = (LandPlatformAppearance.FirePowerValue)newValue2;

            uint mask3 = 0x0018;
            byte shift3 = 3;
            uint newValue3 = value & mask3 >> shift3;
            ps.Damage = (LandPlatformAppearance.DamageValue)newValue3;

            uint mask4 = 0x0060;
            byte shift4 = 5;
            uint newValue4 = value & mask4 >> shift4;
            ps.Smoke = (LandPlatformAppearance.SmokeValue)newValue4;

            uint mask5 = 0x0180;
            byte shift5 = 7;
            uint newValue5 = value & mask5 >> shift5;
            ps.TrailingEffects = (LandPlatformAppearance.TrailingEffectsValue)newValue5;

            uint mask6 = 0x0e00;
            byte shift6 = 9;
            uint newValue6 = value & mask6 >> shift6;
            ps.Hatch = (LandPlatformAppearance.HatchValue)newValue6;

            uint mask7 = 0x1000;
            byte shift7 = 12;
            uint newValue7 = value & mask7 >> shift7;
            ps.HeadLights = (LandPlatformAppearance.HeadLightsValue)newValue7;

            uint mask8 = 0x2000;
            byte shift8 = 13;
            uint newValue8 = value & mask8 >> shift8;
            ps.TailLights = (LandPlatformAppearance.TailLightsValue)newValue8;

            uint mask9 = 0x4000;
            byte shift9 = 14;
            uint newValue9 = value & mask9 >> shift9;
            ps.BrakeLights = (LandPlatformAppearance.BrakeLightsValue)newValue9;

            uint mask10 = 0x8000;
            byte shift10 = 15;
            uint newValue10 = value & mask10 >> shift10;
            ps.Flaming = (LandPlatformAppearance.FlamingValue)newValue10;

            uint mask11 = 0x10000;
            byte shift11 = 16;
            uint newValue11 = value & mask11 >> shift11;
            ps.Launcher = (LandPlatformAppearance.LauncherValue)newValue11;

            uint mask12 = 0x60000;
            byte shift12 = 17;
            uint newValue12 = value & mask12 >> shift12;
            ps.CamouflageType = (LandPlatformAppearance.CamouflageTypeValue)newValue12;

            uint mask13 = 0x80000;
            byte shift13 = 19;
            uint newValue13 = value & mask13 >> shift13;
            ps.Concealed = (LandPlatformAppearance.ConcealedValue)newValue13;

            uint mask15 = 0x200000;
            byte shift15 = 21;
            uint newValue15 = value & mask15 >> shift15;
            ps.FrozenStatus = (LandPlatformAppearance.FrozenStatusValue)newValue15;

            uint mask16 = 0x400000;
            byte shift16 = 22;
            uint newValue16 = value & mask16 >> shift16;
            ps.PowerPlantStatus = (LandPlatformAppearance.PowerPlantStatusValue)newValue16;

            uint mask17 = 0x800000;
            byte shift17 = 23;
            uint newValue17 = value & mask17 >> shift17;
            ps.State = (LandPlatformAppearance.StateValue)newValue17;

            uint mask18 = 0x1000000;
            byte shift18 = 24;
            uint newValue18 = value & mask18 >> shift18;
            ps.Tent = (LandPlatformAppearance.TentValue)newValue18;

            uint mask19 = 0x2000000;
            byte shift19 = 25;
            uint newValue19 = value & mask19 >> shift19;
            ps.Ramp = (LandPlatformAppearance.RampValue)newValue19;

            uint mask20 = 0x4000000;
            byte shift20 = 26;
            uint newValue20 = value & mask20 >> shift20;
            ps.BlackoutLights = (LandPlatformAppearance.BlackoutLightsValue)newValue20;

            uint mask21 = 0x8000000;
            byte shift21 = 27;
            uint newValue21 = value & mask21 >> shift21;
            ps.BlackoutBrakeLights = (LandPlatformAppearance.BlackoutBrakeLightsValue)newValue21;

            uint mask22 = 0x10000000;
            byte shift22 = 28;
            uint newValue22 = value & mask22 >> shift22;
            ps.SpotLights = (LandPlatformAppearance.SpotLightsValue)newValue22;

            uint mask23 = 0x20000000;
            byte shift23 = 29;
            uint newValue23 = value & mask23 >> shift23;
            ps.InteriorLights = (LandPlatformAppearance.InteriorLightsValue)newValue23;

            uint mask24 = 0x40000000;
            byte shift24 = 30;
            uint newValue24 = value & mask24 >> shift24;
            ps.SurrenderState = (LandPlatformAppearance.SurrenderStateValue)newValue24;

            uint mask25 = 0x80000000;
            byte shift25 = 31;
            uint newValue25 = value & mask25 >> shift25;
            ps.MaskedCloaked = (LandPlatformAppearance.MaskedCloakedValue)newValue25;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public LandPlatformAppearance.PaintSchemeValue PaintScheme
        {
            get { return this.paintScheme; }
            set { this.paintScheme = value; }
        }

        /// <summary>
        /// Gets or sets the mobility.
        /// </summary>
        /// <value>The mobility.</value>
        public LandPlatformAppearance.MobilityValue Mobility
        {
            get { return this.mobility; }
            set { this.mobility = value; }
        }

        /// <summary>
        /// Gets or sets the firepower.
        /// </summary>
        /// <value>The firepower.</value>
        public LandPlatformAppearance.FirePowerValue FirePower
        {
            get { return this.firePower; }
            set { this.firePower = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public LandPlatformAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public LandPlatformAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the trailingeffects.
        /// </summary>
        /// <value>The trailingeffects.</value>
        public LandPlatformAppearance.TrailingEffectsValue TrailingEffects
        {
            get { return this.trailingEffects; }
            set { this.trailingEffects = value; }
        }

        /// <summary>
        /// Gets or sets the hatch.
        /// </summary>
        /// <value>The hatch.</value>
        public LandPlatformAppearance.HatchValue Hatch
        {
            get { return this.hatch; }
            set { this.hatch = value; }
        }

        /// <summary>
        /// Gets or sets the headlights.
        /// </summary>
        /// <value>The headlights.</value>
        public LandPlatformAppearance.HeadLightsValue HeadLights
        {
            get { return this.headLights; }
            set { this.headLights = value; }
        }

        /// <summary>
        /// Gets or sets the taillights.
        /// </summary>
        /// <value>The taillights.</value>
        public LandPlatformAppearance.TailLightsValue TailLights
        {
            get { return this.tailLights; }
            set { this.tailLights = value; }
        }

        /// <summary>
        /// Gets or sets the brakelights.
        /// </summary>
        /// <value>The brakelights.</value>
        public LandPlatformAppearance.BrakeLightsValue BrakeLights
        {
            get { return this.brakeLights; }
            set { this.brakeLights = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public LandPlatformAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the launcher.
        /// </summary>
        /// <value>The launcher.</value>
        public LandPlatformAppearance.LauncherValue Launcher
        {
            get { return this.launcher; }
            set { this.launcher = value; }
        }

        /// <summary>
        /// Gets or sets the camouflagetype.
        /// </summary>
        /// <value>The camouflagetype.</value>
        public LandPlatformAppearance.CamouflageTypeValue CamouflageType
        {
            get { return this.camouflageType; }
            set { this.camouflageType = value; }
        }

        /// <summary>
        /// Gets or sets the concealed.
        /// </summary>
        /// <value>The concealed.</value>
        public LandPlatformAppearance.ConcealedValue Concealed
        {
            get { return this.concealed; }
            set { this.concealed = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public LandPlatformAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public LandPlatformAppearance.PowerPlantStatusValue PowerPlantStatus
        {
            get { return this.powerPlantStatus; }
            set { this.powerPlantStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public LandPlatformAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the tent.
        /// </summary>
        /// <value>The tent.</value>
        public LandPlatformAppearance.TentValue Tent
        {
            get { return this.tent; }
            set { this.tent = value; }
        }

        /// <summary>
        /// Gets or sets the ramp.
        /// </summary>
        /// <value>The ramp.</value>
        public LandPlatformAppearance.RampValue Ramp
        {
            get { return this.ramp; }
            set { this.ramp = value; }
        }

        /// <summary>
        /// Gets or sets the blackoutlights.
        /// </summary>
        /// <value>The blackoutlights.</value>
        public LandPlatformAppearance.BlackoutLightsValue BlackoutLights
        {
            get { return this.blackoutLights; }
            set { this.blackoutLights = value; }
        }

        /// <summary>
        /// Gets or sets the blackoutbrakelights.
        /// </summary>
        /// <value>The blackoutbrakelights.</value>
        public LandPlatformAppearance.BlackoutBrakeLightsValue BlackoutBrakeLights
        {
            get { return this.blackoutBrakeLights; }
            set { this.blackoutBrakeLights = value; }
        }

        /// <summary>
        /// Gets or sets the spotlights.
        /// </summary>
        /// <value>The spotlights.</value>
        public LandPlatformAppearance.SpotLightsValue SpotLights
        {
            get { return this.spotLights; }
            set { this.spotLights = value; }
        }

        /// <summary>
        /// Gets or sets the interiorlights.
        /// </summary>
        /// <value>The interiorlights.</value>
        public LandPlatformAppearance.InteriorLightsValue InteriorLights
        {
            get { return this.interiorLights; }
            set { this.interiorLights = value; }
        }

        /// <summary>
        /// Gets or sets the surrenderstate.
        /// </summary>
        /// <value>The surrenderstate.</value>
        public LandPlatformAppearance.SurrenderStateValue SurrenderState
        {
            get { return this.surrenderState; }
            set { this.surrenderState = value; }
        }

        /// <summary>
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public LandPlatformAppearance.MaskedCloakedValue MaskedCloaked
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

            if (!(obj is LandPlatformAppearance))
            {
                return false;
            }

            return this.Equals((LandPlatformAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LandPlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.PaintScheme == other.PaintScheme &&
                this.Mobility == other.Mobility &&
                this.FirePower == other.FirePower &&
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.TrailingEffects == other.TrailingEffects &&
                this.Hatch == other.Hatch &&
                this.HeadLights == other.HeadLights &&
                this.TailLights == other.TailLights &&
                this.BrakeLights == other.BrakeLights &&
                this.Flaming == other.Flaming &&
                this.Launcher == other.Launcher &&
                this.CamouflageType == other.CamouflageType &&
                this.Concealed == other.Concealed &&
                this.FrozenStatus == other.FrozenStatus &&
                this.PowerPlantStatus == other.PowerPlantStatus &&
                this.State == other.State &&
                this.Tent == other.Tent &&
                this.Ramp == other.Ramp &&
                this.BlackoutLights == other.BlackoutLights &&
                this.BlackoutBrakeLights == other.BlackoutBrakeLights &&
                this.SpotLights == other.SpotLights &&
                this.InteriorLights == other.InteriorLights &&
                this.SurrenderState == other.SurrenderState &&
                this.MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.LandPlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.PaintScheme << 0);
            val |= (uint)((uint)this.Mobility << 1);
            val |= (uint)((uint)this.FirePower << 2);
            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.TrailingEffects << 7);
            val |= (uint)((uint)this.Hatch << 9);
            val |= (uint)((uint)this.HeadLights << 12);
            val |= (uint)((uint)this.TailLights << 13);
            val |= (uint)((uint)this.BrakeLights << 14);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.Launcher << 16);
            val |= (uint)((uint)this.CamouflageType << 17);
            val |= (uint)((uint)this.Concealed << 19);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.PowerPlantStatus << 22);
            val |= (uint)((uint)this.State << 23);
            val |= (uint)((uint)this.Tent << 24);
            val |= (uint)((uint)this.Ramp << 25);
            val |= (uint)((uint)this.BlackoutLights << 26);
            val |= (uint)((uint)this.BlackoutBrakeLights << 27);
            val |= (uint)((uint)this.SpotLights << 28);
            val |= (uint)((uint)this.InteriorLights << 29);
            val |= (uint)((uint)this.SurrenderState << 30);
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
                hash = (hash * 29) + this.PaintScheme.GetHashCode();
                hash = (hash * 29) + this.Mobility.GetHashCode();
                hash = (hash * 29) + this.FirePower.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Smoke.GetHashCode();
                hash = (hash * 29) + this.TrailingEffects.GetHashCode();
                hash = (hash * 29) + this.Hatch.GetHashCode();
                hash = (hash * 29) + this.HeadLights.GetHashCode();
                hash = (hash * 29) + this.TailLights.GetHashCode();
                hash = (hash * 29) + this.BrakeLights.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.Launcher.GetHashCode();
                hash = (hash * 29) + this.CamouflageType.GetHashCode();
                hash = (hash * 29) + this.Concealed.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.Tent.GetHashCode();
                hash = (hash * 29) + this.Ramp.GetHashCode();
                hash = (hash * 29) + this.BlackoutLights.GetHashCode();
                hash = (hash * 29) + this.BlackoutBrakeLights.GetHashCode();
                hash = (hash * 29) + this.SpotLights.GetHashCode();
                hash = (hash * 29) + this.InteriorLights.GetHashCode();
                hash = (hash * 29) + this.SurrenderState.GetHashCode();
                hash = (hash * 29) + this.MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
