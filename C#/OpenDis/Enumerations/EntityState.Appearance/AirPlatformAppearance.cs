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
    public struct AirPlatformAppearance
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
            /// Frozen (Frozen entities should not be dead-reckoned, i.e. they should be displayed as fixed at the current location even if nonzero velocity, acceleration or rotation data is received from the frozen entity)
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

        private AirPlatformAppearance.PaintSchemeValue paintScheme;
        private AirPlatformAppearance.PropulsionValue propulsion;
        private AirPlatformAppearance.DamageValue damage;
        private AirPlatformAppearance.SmokeValue smoke;
        private AirPlatformAppearance.TrailingEffectsValue trailingEffects;
        private AirPlatformAppearance.CanopyValue canopy;
        private AirPlatformAppearance.LandingLightsValue landingLights;
        private AirPlatformAppearance.NavigationLightsValue navigationLights;
        private AirPlatformAppearance.AntiCollisionLightsValue antiCollisionLights;
        private AirPlatformAppearance.FlamingValue flaming;
        private AirPlatformAppearance.AfterburnerValue afterburner;
        private AirPlatformAppearance.FrozenStatusValue frozenStatus;
        private AirPlatformAppearance.PowerPlantStatusValue powerPlantStatus;
        private AirPlatformAppearance.StateValue state;
        private AirPlatformAppearance.FormationLightsValue formationLights;
        private AirPlatformAppearance.SpotLightsValue spotLights;
        private AirPlatformAppearance.InteriorLightsValue interiorLights;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AirPlatformAppearance left, AirPlatformAppearance right)
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
        public static bool operator ==(AirPlatformAppearance left, AirPlatformAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(AirPlatformAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator AirPlatformAppearance(uint value)
        {
            return AirPlatformAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static AirPlatformAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance, represented by the uint value.</returns>
        public static AirPlatformAppearance FromUInt32(uint value)
        {
            AirPlatformAppearance ps = new AirPlatformAppearance();

            uint mask0 = 0x0001;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.PaintScheme = (AirPlatformAppearance.PaintSchemeValue)newValue0;

            uint mask1 = 0x0002;
            byte shift1 = 1;
            uint newValue1 = value & mask1 >> shift1;
            ps.Propulsion = (AirPlatformAppearance.PropulsionValue)newValue1;

            uint mask3 = 0x0018;
            byte shift3 = 3;
            uint newValue3 = value & mask3 >> shift3;
            ps.Damage = (AirPlatformAppearance.DamageValue)newValue3;

            uint mask4 = 0x0060;
            byte shift4 = 5;
            uint newValue4 = value & mask4 >> shift4;
            ps.Smoke = (AirPlatformAppearance.SmokeValue)newValue4;

            uint mask5 = 0x0180;
            byte shift5 = 7;
            uint newValue5 = value & mask5 >> shift5;
            ps.TrailingEffects = (AirPlatformAppearance.TrailingEffectsValue)newValue5;

            uint mask6 = 0x0e00;
            byte shift6 = 9;
            uint newValue6 = value & mask6 >> shift6;
            ps.Canopy = (AirPlatformAppearance.CanopyValue)newValue6;

            uint mask7 = 0x1000;
            byte shift7 = 12;
            uint newValue7 = value & mask7 >> shift7;
            ps.LandingLights = (AirPlatformAppearance.LandingLightsValue)newValue7;

            uint mask8 = 0x2000;
            byte shift8 = 13;
            uint newValue8 = value & mask8 >> shift8;
            ps.NavigationLights = (AirPlatformAppearance.NavigationLightsValue)newValue8;

            uint mask9 = 0x4000;
            byte shift9 = 14;
            uint newValue9 = value & mask9 >> shift9;
            ps.AntiCollisionLights = (AirPlatformAppearance.AntiCollisionLightsValue)newValue9;

            uint mask10 = 0x8000;
            byte shift10 = 15;
            uint newValue10 = value & mask10 >> shift10;
            ps.Flaming = (AirPlatformAppearance.FlamingValue)newValue10;

            uint mask11 = 0x10000;
            byte shift11 = 16;
            uint newValue11 = value & mask11 >> shift11;
            ps.Afterburner = (AirPlatformAppearance.AfterburnerValue)newValue11;

            uint mask13 = 0x200000;
            byte shift13 = 21;
            uint newValue13 = value & mask13 >> shift13;
            ps.FrozenStatus = (AirPlatformAppearance.FrozenStatusValue)newValue13;

            uint mask14 = 0x400000;
            byte shift14 = 22;
            uint newValue14 = value & mask14 >> shift14;
            ps.PowerPlantStatus = (AirPlatformAppearance.PowerPlantStatusValue)newValue14;

            uint mask15 = 0x800000;
            byte shift15 = 23;
            uint newValue15 = value & mask15 >> shift15;
            ps.State = (AirPlatformAppearance.StateValue)newValue15;

            uint mask16 = 0x1000000;
            byte shift16 = 24;
            uint newValue16 = value & mask16 >> shift16;
            ps.FormationLights = (AirPlatformAppearance.FormationLightsValue)newValue16;

            uint mask18 = 0x10000000;
            byte shift18 = 28;
            uint newValue18 = value & mask18 >> shift18;
            ps.SpotLights = (AirPlatformAppearance.SpotLightsValue)newValue18;

            uint mask19 = 0x20000000;
            byte shift19 = 29;
            uint newValue19 = value & mask19 >> shift19;
            ps.InteriorLights = (AirPlatformAppearance.InteriorLightsValue)newValue19;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public AirPlatformAppearance.PaintSchemeValue PaintScheme
        {
            get { return this.paintScheme; }
            set { this.paintScheme = value; }
        }

        /// <summary>
        /// Gets or sets the propulsion.
        /// </summary>
        /// <value>The propulsion.</value>
        public AirPlatformAppearance.PropulsionValue Propulsion
        {
            get { return this.propulsion; }
            set { this.propulsion = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public AirPlatformAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public AirPlatformAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the trailingeffects.
        /// </summary>
        /// <value>The trailingeffects.</value>
        public AirPlatformAppearance.TrailingEffectsValue TrailingEffects
        {
            get { return this.trailingEffects; }
            set { this.trailingEffects = value; }
        }

        /// <summary>
        /// Gets or sets the canopy.
        /// </summary>
        /// <value>The canopy.</value>
        public AirPlatformAppearance.CanopyValue Canopy
        {
            get { return this.canopy; }
            set { this.canopy = value; }
        }

        /// <summary>
        /// Gets or sets the landinglights.
        /// </summary>
        /// <value>The landinglights.</value>
        public AirPlatformAppearance.LandingLightsValue LandingLights
        {
            get { return this.landingLights; }
            set { this.landingLights = value; }
        }

        /// <summary>
        /// Gets or sets the navigationlights.
        /// </summary>
        /// <value>The navigationlights.</value>
        public AirPlatformAppearance.NavigationLightsValue NavigationLights
        {
            get { return this.navigationLights; }
            set { this.navigationLights = value; }
        }

        /// <summary>
        /// Gets or sets the anticollisionlights.
        /// </summary>
        /// <value>The anticollisionlights.</value>
        public AirPlatformAppearance.AntiCollisionLightsValue AntiCollisionLights
        {
            get { return this.antiCollisionLights; }
            set { this.antiCollisionLights = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public AirPlatformAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the afterburner.
        /// </summary>
        /// <value>The afterburner.</value>
        public AirPlatformAppearance.AfterburnerValue Afterburner
        {
            get { return this.afterburner; }
            set { this.afterburner = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public AirPlatformAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public AirPlatformAppearance.PowerPlantStatusValue PowerPlantStatus
        {
            get { return this.powerPlantStatus; }
            set { this.powerPlantStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public AirPlatformAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the formationlights.
        /// </summary>
        /// <value>The formationlights.</value>
        public AirPlatformAppearance.FormationLightsValue FormationLights
        {
            get { return this.formationLights; }
            set { this.formationLights = value; }
        }

        /// <summary>
        /// Gets or sets the spotlights.
        /// </summary>
        /// <value>The spotlights.</value>
        public AirPlatformAppearance.SpotLightsValue SpotLights
        {
            get { return this.spotLights; }
            set { this.spotLights = value; }
        }

        /// <summary>
        /// Gets or sets the interiorlights.
        /// </summary>
        /// <value>The interiorlights.</value>
        public AirPlatformAppearance.InteriorLightsValue InteriorLights
        {
            get { return this.interiorLights; }
            set { this.interiorLights = value; }
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

            if (!(obj is AirPlatformAppearance))
            {
                return false;
            }

            return this.Equals((AirPlatformAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AirPlatformAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.PaintScheme == other.PaintScheme &&
                this.Propulsion == other.Propulsion &&
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.TrailingEffects == other.TrailingEffects &&
                this.Canopy == other.Canopy &&
                this.LandingLights == other.LandingLights &&
                this.NavigationLights == other.NavigationLights &&
                this.AntiCollisionLights == other.AntiCollisionLights &&
                this.Flaming == other.Flaming &&
                this.Afterburner == other.Afterburner &&
                this.FrozenStatus == other.FrozenStatus &&
                this.PowerPlantStatus == other.PowerPlantStatus &&
                this.State == other.State &&
                this.FormationLights == other.FormationLights &&
                this.SpotLights == other.SpotLights &&
                this.InteriorLights == other.InteriorLights;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.AirPlatformAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.PaintScheme << 0);
            val |= (uint)((uint)this.Propulsion << 1);
            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.TrailingEffects << 7);
            val |= (uint)((uint)this.Canopy << 9);
            val |= (uint)((uint)this.LandingLights << 12);
            val |= (uint)((uint)this.NavigationLights << 13);
            val |= (uint)((uint)this.AntiCollisionLights << 14);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.Afterburner << 16);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.PowerPlantStatus << 22);
            val |= (uint)((uint)this.State << 23);
            val |= (uint)((uint)this.FormationLights << 24);
            val |= (uint)((uint)this.SpotLights << 28);
            val |= (uint)((uint)this.InteriorLights << 29);

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
                hash = (hash * 29) + this.Propulsion.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Smoke.GetHashCode();
                hash = (hash * 29) + this.TrailingEffects.GetHashCode();
                hash = (hash * 29) + this.Canopy.GetHashCode();
                hash = (hash * 29) + this.LandingLights.GetHashCode();
                hash = (hash * 29) + this.NavigationLights.GetHashCode();
                hash = (hash * 29) + this.AntiCollisionLights.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.Afterburner.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.FormationLights.GetHashCode();
                hash = (hash * 29) + this.SpotLights.GetHashCode();
                hash = (hash * 29) + this.InteriorLights.GetHashCode();
            }

            return hash;
        }
    }
}
