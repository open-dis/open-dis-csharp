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
    /// Enumeration values for SensorEmitterAppearance (es.appear.sensoremitter, Sensor/Emitter Kind, 
    /// section 4.3.9)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct SensorEmitterAppearance
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
        /// Describes characteristics of mobility kill
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes characteristics of mobility kill")]
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
        /// Describes characteristics of mission kill (e.g. damaged antenna)
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes characteristics of mission kill (e.g. damaged antenna)")]
        public enum MissionValue : uint
        {
            /// <summary>
            /// No mission kill
            /// </summary>
            NoMissionKill = 0,

            /// <summary>
            /// Mission kill
            /// </summary>
            MissionKill = 1
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
        /// Describes the size of the dust cloud trailing effect for the Sensor/Emitter entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the size of the dust cloud trailing effect for the Sensor/Emitter entity")]
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
        /// Describes the status of lights on the sensor
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the status of lights on the sensor")]
        public enum LightsValue : uint
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
        /// Describes whether flames are rising from the entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether flames are rising from the entity")]
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
        /// Describes the elevated status of the sensor's antenna
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the elevated status of the sensor's antenna")]
        public enum AntennaValue : uint
        {
            /// <summary>
            /// Not raised
            /// </summary>
            NotRaised = 0,

            /// <summary>
            /// Raised
            /// </summary>
            Raised = 1
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
        /// Describes the frozen status of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of an entity")]
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
        /// Describes the power-plant status of the sensor
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the power-plant status of the sensor")]
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
        /// Describes the state of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of an entity")]
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

        private SensorEmitterAppearance.PaintSchemeValue paintScheme;
        private SensorEmitterAppearance.MobilityValue mobility;
        private SensorEmitterAppearance.MissionValue mission;
        private SensorEmitterAppearance.DamageValue damage;
        private SensorEmitterAppearance.SmokeValue smoke;
        private SensorEmitterAppearance.TrailingEffectsValue trailingEffects;
        private SensorEmitterAppearance.LightsValue lights;
        private SensorEmitterAppearance.FlamingValue flaming;
        private SensorEmitterAppearance.AntennaValue antenna;
        private SensorEmitterAppearance.CamouflageTypeValue camouflageType;
        private SensorEmitterAppearance.ConcealedValue concealed;
        private SensorEmitterAppearance.FrozenStatusValue frozenStatus;
        private SensorEmitterAppearance.PowerPlantStatusValue powerPlantStatus;
        private SensorEmitterAppearance.StateValue state;
        private SensorEmitterAppearance.TentValue tent;
        private SensorEmitterAppearance.BlackoutLightsValue blackoutLights;
        private SensorEmitterAppearance.InteriorLightsValue interiorLights;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SensorEmitterAppearance left, SensorEmitterAppearance right)
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
        public static bool operator ==(SensorEmitterAppearance left, SensorEmitterAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(SensorEmitterAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator SensorEmitterAppearance(uint value)
        {
            return SensorEmitterAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static SensorEmitterAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance, represented by the uint value.</returns>
        public static SensorEmitterAppearance FromUInt32(uint value)
        {
            SensorEmitterAppearance ps = new SensorEmitterAppearance();

            uint mask0 = 0x0001;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.PaintScheme = (SensorEmitterAppearance.PaintSchemeValue)newValue0;

            uint mask1 = 0x0002;
            byte shift1 = 1;
            uint newValue1 = value & mask1 >> shift1;
            ps.Mobility = (SensorEmitterAppearance.MobilityValue)newValue1;

            uint mask2 = 0x0004;
            byte shift2 = 2;
            uint newValue2 = value & mask2 >> shift2;
            ps.Mission = (SensorEmitterAppearance.MissionValue)newValue2;

            uint mask3 = 0x0018;
            byte shift3 = 3;
            uint newValue3 = value & mask3 >> shift3;
            ps.Damage = (SensorEmitterAppearance.DamageValue)newValue3;

            uint mask4 = 0x0060;
            byte shift4 = 5;
            uint newValue4 = value & mask4 >> shift4;
            ps.Smoke = (SensorEmitterAppearance.SmokeValue)newValue4;

            uint mask5 = 0x0180;
            byte shift5 = 7;
            uint newValue5 = value & mask5 >> shift5;
            ps.TrailingEffects = (SensorEmitterAppearance.TrailingEffectsValue)newValue5;

            uint mask7 = 0x1000;
            byte shift7 = 12;
            uint newValue7 = value & mask7 >> shift7;
            ps.Lights = (SensorEmitterAppearance.LightsValue)newValue7;

            uint mask9 = 0x8000;
            byte shift9 = 15;
            uint newValue9 = value & mask9 >> shift9;
            ps.Flaming = (SensorEmitterAppearance.FlamingValue)newValue9;

            uint mask10 = 0x10000;
            byte shift10 = 16;
            uint newValue10 = value & mask10 >> shift10;
            ps.Antenna = (SensorEmitterAppearance.AntennaValue)newValue10;

            uint mask11 = 0x60000;
            byte shift11 = 17;
            uint newValue11 = value & mask11 >> shift11;
            ps.CamouflageType = (SensorEmitterAppearance.CamouflageTypeValue)newValue11;

            uint mask12 = 0x80000;
            byte shift12 = 19;
            uint newValue12 = value & mask12 >> shift12;
            ps.Concealed = (SensorEmitterAppearance.ConcealedValue)newValue12;

            uint mask14 = 0x200000;
            byte shift14 = 21;
            uint newValue14 = value & mask14 >> shift14;
            ps.FrozenStatus = (SensorEmitterAppearance.FrozenStatusValue)newValue14;

            uint mask15 = 0x400000;
            byte shift15 = 22;
            uint newValue15 = value & mask15 >> shift15;
            ps.PowerPlantStatus = (SensorEmitterAppearance.PowerPlantStatusValue)newValue15;

            uint mask16 = 0x800000;
            byte shift16 = 23;
            uint newValue16 = value & mask16 >> shift16;
            ps.State = (SensorEmitterAppearance.StateValue)newValue16;

            uint mask17 = 0x1000000;
            byte shift17 = 24;
            uint newValue17 = value & mask17 >> shift17;
            ps.Tent = (SensorEmitterAppearance.TentValue)newValue17;

            uint mask19 = 0x4000000;
            byte shift19 = 26;
            uint newValue19 = value & mask19 >> shift19;
            ps.BlackoutLights = (SensorEmitterAppearance.BlackoutLightsValue)newValue19;

            uint mask21 = 0x20000000;
            byte shift21 = 29;
            uint newValue21 = value & mask21 >> shift21;
            ps.InteriorLights = (SensorEmitterAppearance.InteriorLightsValue)newValue21;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public SensorEmitterAppearance.PaintSchemeValue PaintScheme
        {
            get { return this.paintScheme; }
            set { this.paintScheme = value; }
        }

        /// <summary>
        /// Gets or sets the mobility.
        /// </summary>
        /// <value>The mobility.</value>
        public SensorEmitterAppearance.MobilityValue Mobility
        {
            get { return this.mobility; }
            set { this.mobility = value; }
        }

        /// <summary>
        /// Gets or sets the mission.
        /// </summary>
        /// <value>The mission.</value>
        public SensorEmitterAppearance.MissionValue Mission
        {
            get { return this.mission; }
            set { this.mission = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public SensorEmitterAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public SensorEmitterAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the trailingeffects.
        /// </summary>
        /// <value>The trailingeffects.</value>
        public SensorEmitterAppearance.TrailingEffectsValue TrailingEffects
        {
            get { return this.trailingEffects; }
            set { this.trailingEffects = value; }
        }

        /// <summary>
        /// Gets or sets the lights.
        /// </summary>
        /// <value>The lights.</value>
        public SensorEmitterAppearance.LightsValue Lights
        {
            get { return this.lights; }
            set { this.lights = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public SensorEmitterAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the antenna.
        /// </summary>
        /// <value>The antenna.</value>
        public SensorEmitterAppearance.AntennaValue Antenna
        {
            get { return this.antenna; }
            set { this.antenna = value; }
        }

        /// <summary>
        /// Gets or sets the camouflagetype.
        /// </summary>
        /// <value>The camouflagetype.</value>
        public SensorEmitterAppearance.CamouflageTypeValue CamouflageType
        {
            get { return this.camouflageType; }
            set { this.camouflageType = value; }
        }

        /// <summary>
        /// Gets or sets the concealed.
        /// </summary>
        /// <value>The concealed.</value>
        public SensorEmitterAppearance.ConcealedValue Concealed
        {
            get { return this.concealed; }
            set { this.concealed = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public SensorEmitterAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the powerplantstatus.
        /// </summary>
        /// <value>The powerplantstatus.</value>
        public SensorEmitterAppearance.PowerPlantStatusValue PowerPlantStatus
        {
            get { return this.powerPlantStatus; }
            set { this.powerPlantStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public SensorEmitterAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the tent.
        /// </summary>
        /// <value>The tent.</value>
        public SensorEmitterAppearance.TentValue Tent
        {
            get { return this.tent; }
            set { this.tent = value; }
        }

        /// <summary>
        /// Gets or sets the blackoutlights.
        /// </summary>
        /// <value>The blackoutlights.</value>
        public SensorEmitterAppearance.BlackoutLightsValue BlackoutLights
        {
            get { return this.blackoutLights; }
            set { this.blackoutLights = value; }
        }

        /// <summary>
        /// Gets or sets the interiorlights.
        /// </summary>
        /// <value>The interiorlights.</value>
        public SensorEmitterAppearance.InteriorLightsValue InteriorLights
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

            if (!(obj is SensorEmitterAppearance))
            {
                return false;
            }

            return this.Equals((SensorEmitterAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SensorEmitterAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.PaintScheme == other.PaintScheme &&
                this.Mobility == other.Mobility &&
                this.Mission == other.Mission &&
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.TrailingEffects == other.TrailingEffects &&
                this.Lights == other.Lights &&
                this.Flaming == other.Flaming &&
                this.Antenna == other.Antenna &&
                this.CamouflageType == other.CamouflageType &&
                this.Concealed == other.Concealed &&
                this.FrozenStatus == other.FrozenStatus &&
                this.PowerPlantStatus == other.PowerPlantStatus &&
                this.State == other.State &&
                this.Tent == other.Tent &&
                this.BlackoutLights == other.BlackoutLights &&
                this.InteriorLights == other.InteriorLights;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.SensorEmitterAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.PaintScheme << 0);
            val |= (uint)((uint)this.Mobility << 1);
            val |= (uint)((uint)this.Mission << 2);
            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.TrailingEffects << 7);
            val |= (uint)((uint)this.Lights << 12);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.Antenna << 16);
            val |= (uint)((uint)this.CamouflageType << 17);
            val |= (uint)((uint)this.Concealed << 19);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.PowerPlantStatus << 22);
            val |= (uint)((uint)this.State << 23);
            val |= (uint)((uint)this.Tent << 24);
            val |= (uint)((uint)this.BlackoutLights << 26);
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
                hash = (hash * 29) + this.Mobility.GetHashCode();
                hash = (hash * 29) + this.Mission.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Smoke.GetHashCode();
                hash = (hash * 29) + this.TrailingEffects.GetHashCode();
                hash = (hash * 29) + this.Lights.GetHashCode();
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.Antenna.GetHashCode();
                hash = (hash * 29) + this.CamouflageType.GetHashCode();
                hash = (hash * 29) + this.Concealed.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.PowerPlantStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.Tent.GetHashCode();
                hash = (hash * 29) + this.BlackoutLights.GetHashCode();
                hash = (hash * 29) + this.InteriorLights.GetHashCode();
            }

            return hash;
        }
    }
}
