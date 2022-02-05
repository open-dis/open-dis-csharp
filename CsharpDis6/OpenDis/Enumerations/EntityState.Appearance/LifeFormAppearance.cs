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
    /// Enumeration values for LifeFormAppearance (es.appear.lifeform, Life Forms Kind,
    /// section 4.3.3)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct LifeFormAppearance : IHashable<LifeFormAppearance>
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
        /// Describes the damaged visual appearance of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the damaged visual appearance of an entity")]
        public enum HealthValue : uint
        {
            /// <summary>
            /// No injury
            /// </summary>
            NoInjury = 0,

            /// <summary>
            /// Slight injury
            /// </summary>
            SlightInjury = 1,

            /// <summary>
            /// Moderate injury
            /// </summary>
            ModerateInjury = 2,

            /// <summary>
            /// Fatal injury
            /// </summary>
            FatalInjury = 3
        }

        /// <summary>
        /// Describes compliance of life form
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes compliance of life form")]
        public enum ComplianceValue : uint
        {
            /// <summary>
            /// null
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// Detained
            /// </summary>
            Detained = 1,

            /// <summary>
            /// Surrender
            /// </summary>
            Surrender = 2,

            /// <summary>
            /// Using fists
            /// </summary>
            UsingFists = 3,

            /// <summary>
            /// Verbal abuse level 1
            /// </summary>
            VerbalAbuseLevel1 = 4,

            /// <summary>
            /// Verbal abuse level 2
            /// </summary>
            VerbalAbuseLevel2 = 5,

            /// <summary>
            /// Verbal abuse level 3
            /// </summary>
            VerbalAbuseLevel3 = 6,

            /// <summary>
            /// Passive resistance level 1
            /// </summary>
            PassiveResistanceLevel1 = 7,

            /// <summary>
            /// Passive resistance level 2
            /// </summary>
            PassiveResistanceLevel2 = 8,

            /// <summary>
            /// Passive resistance level 3
            /// </summary>
            PassiveResistanceLevel3 = 9,

            /// <summary>
            /// Using non-lethal weapon 1
            /// </summary>
            UsingNonLethalWeapon1 = 10,

            /// <summary>
            /// Using non-lethal weapon 2
            /// </summary>
            UsingNonLethalWeapon2 = 11,

            /// <summary>
            /// Using non-lethal weapon 3
            /// </summary>
            UsingNonLethalWeapon3 = 12,

            /// <summary>
            /// Using non-lethal weapon 4
            /// </summary>
            UsingNonLethalWeapon4 = 13,

            /// <summary>
            /// Using non-lethal weapon 5
            /// </summary>
            UsingNonLethalWeapon5 = 14,

            /// <summary>
            /// Using non-lethal weapon 6
            /// </summary>
            UsingNonLethalWeapon6 = 15
        }

        /// <summary>
        /// Describes whether Flash Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Flash Lights are on or off.")]
        public enum FlashLightsValue : uint
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
        /// Describes the state of the life form
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of the life form")]
        public enum LifeFormStateValue : uint
        {
            /// <summary>
            /// null
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// Upright, standing still
            /// </summary>
            UprightStandingStill = 1,

            /// <summary>
            /// Upright, walking
            /// </summary>
            UprightWalking = 2,

            /// <summary>
            /// Upright, running
            /// </summary>
            UprightRunning = 3,

            /// <summary>
            /// Kneeling
            /// </summary>
            Kneeling = 4,

            /// <summary>
            /// Prone
            /// </summary>
            Prone = 5,

            /// <summary>
            /// Crawling
            /// </summary>
            Crawling = 6,

            /// <summary>
            /// Swimming
            /// </summary>
            Swimming = 7,

            /// <summary>
            /// Parachuting
            /// </summary>
            Parachuting = 8,

            /// <summary>
            /// Jumping
            /// </summary>
            Jumping = 9,

            /// <summary>
            /// Sitting
            /// </summary>
            Sitting = 10,

            /// <summary>
            /// Squatting
            /// </summary>
            Squatting = 11,

            /// <summary>
            /// Crouching
            /// </summary>
            Crouching = 12,

            /// <summary>
            /// Wading
            /// </summary>
            Wading = 13,

            /// <summary>
            /// Surrender
            /// </summary>
            Surrender = 14,

            /// <summary>
            /// Detained
            /// </summary>
            Detained = 15
        }

        /// <summary>
        /// Describes the frozen status of a life form
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a life form")]
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
        /// Describes the state of a life form
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a life form")]
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
        /// Describes the position of the life form's primary weapon
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the position of the life form's primary weapon")]
        public enum Weapon1Value : uint
        {
            /// <summary>
            /// No primary weapon present
            /// </summary>
            NoPrimaryWeaponPresent = 0,

            /// <summary>
            /// Primary weapon is stowed
            /// </summary>
            PrimaryWeaponIsStowed = 1,

            /// <summary>
            /// Primary weapon is deployed
            /// </summary>
            PrimaryWeaponIsDeployed = 2,

            /// <summary>
            /// Primary weapon is in firing position
            /// </summary>
            PrimaryWeaponIsInFiringPosition = 3
        }

        /// <summary>
        /// Describes the position of the life form's secondary weapon
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the position of the life form's secondary weapon")]
        public enum Weapon2Value : uint
        {
            /// <summary>
            /// No secondary weapon present
            /// </summary>
            NoSecondaryWeaponPresent = 0,

            /// <summary>
            /// Secondary weapon is stowed
            /// </summary>
            SecondaryWeaponIsStowed = 1,

            /// <summary>
            /// Secondary weapon is deployed
            /// </summary>
            SecondaryWeaponIsDeployed = 2,

            /// <summary>
            /// Secondary weapon is in firing position
            /// </summary>
            SecondaryWeaponIsInFiringPosition = 3
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
        /// Describes the type of stationary concealment
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the type of stationary concealment")]
        public enum ConcealedStationaryValue : uint
        {
            /// <summary>
            /// Not concealed
            /// </summary>
            NotConcealed = 0,

            /// <summary>
            /// Entity in a prepared concealed position
            /// </summary>
            EntityInAPreparedConcealedPosition = 1
        }

        /// <summary>
        /// Describes the type of concealed movement
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the type of concealed movement")]
        public enum ConcealedMovementValue : uint
        {
            /// <summary>
            /// Open movement
            /// </summary>
            OpenMovement = 0,

            /// <summary>
            /// Rushes between covered positions
            /// </summary>
            RushesBetweenCoveredPositions = 1
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LifeFormAppearance left, LifeFormAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(LifeFormAppearance left, LifeFormAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="LifeFormAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="LifeFormAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(LifeFormAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="LifeFormAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator LifeFormAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="LifeFormAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="LifeFormAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="LifeFormAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static LifeFormAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="LifeFormAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="LifeFormAppearance"/> instance.</param>
        /// <returns>The <see cref="LifeFormAppearance"/> instance, represented by the uint value.</returns>
        public static LifeFormAppearance FromUInt32(uint value)
        {
            var ps = new LifeFormAppearance();

            const uint mask0 = 0x0001;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.PaintScheme = (PaintSchemeValue)newValue0;

            const uint mask2 = 0x0018;
            const byte shift2 = 3;
            uint newValue2 = (value & mask2) >> shift2;
            ps.Health = (HealthValue)newValue2;

            const uint mask3 = 0x01e0;
            const byte shift3 = 5;
            uint newValue3 = (value & mask3) >> shift3;
            ps.Compliance = (ComplianceValue)newValue3;

            const uint mask5 = 0x1000;
            const byte shift5 = 12;
            uint newValue5 = (value & mask5) >> shift5;
            ps.FlashLights = (FlashLightsValue)newValue5;

            const uint mask7 = 0xf0000;
            const byte shift7 = 16;
            uint newValue7 = (value & mask7) >> shift7;
            ps.LifeFormState = (LifeFormStateValue)newValue7;

            const uint mask9 = 0x200000;
            const byte shift9 = 21;
            uint newValue9 = (value & mask9) >> shift9;
            ps.FrozenStatus = (FrozenStatusValue)newValue9;

            const uint mask11 = 0x800000;
            const byte shift11 = 23;
            uint newValue11 = (value & mask11) >> shift11;
            ps.State = (StateValue)newValue11;

            const uint mask12 = 0x3000000;
            const byte shift12 = 24;
            uint newValue12 = (value & mask12) >> shift12;
            ps.Weapon1 = (Weapon1Value)newValue12;

            const uint mask13 = 0xc000000;
            const byte shift13 = 26;
            uint newValue13 = (value & mask13) >> shift13;
            ps.Weapon2 = (Weapon2Value)newValue13;

            const uint mask14 = 0x30000000;
            const byte shift14 = 28;
            uint newValue14 = (value & mask14) >> shift14;
            ps.CamouflageType = (CamouflageTypeValue)newValue14;

            const uint mask15 = 0x40000000;
            const byte shift15 = 30;
            uint newValue15 = (value & mask15) >> shift15;
            ps.ConcealedStationary = (ConcealedStationaryValue)newValue15;

            const uint mask16 = 0x80000000;
            const byte shift16 = 31;
            uint newValue16 = (value & mask16) >> shift16;
            ps.ConcealedMovement = (ConcealedMovementValue)newValue16;

            return ps;
        }

        /// <summary>
        /// Gets or sets the paintscheme.
        /// </summary>
        /// <value>The paintscheme.</value>
        public PaintSchemeValue PaintScheme { get; set; }

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>The health.</value>
        public HealthValue Health { get; set; }

        /// <summary>
        /// Gets or sets the compliance.
        /// </summary>
        /// <value>The compliance.</value>
        public ComplianceValue Compliance { get; set; }

        /// <summary>
        /// Gets or sets the flashlights.
        /// </summary>
        /// <value>The flashlights.</value>
        public FlashLightsValue FlashLights { get; set; }

        /// <summary>
        /// Gets or sets the lifeformstate.
        /// </summary>
        /// <value>The lifeformstate.</value>
        public LifeFormStateValue LifeFormState { get; set; }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public FrozenStatusValue FrozenStatus { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public StateValue State { get; set; }

        /// <summary>
        /// Gets or sets the weapon1.
        /// </summary>
        /// <value>The weapon1.</value>
        public Weapon1Value Weapon1 { get; set; }

        /// <summary>
        /// Gets or sets the weapon2.
        /// </summary>
        /// <value>The weapon2.</value>
        public Weapon2Value Weapon2 { get; set; }

        /// <summary>
        /// Gets or sets the camouflagetype.
        /// </summary>
        /// <value>The camouflagetype.</value>
        public CamouflageTypeValue CamouflageType { get; set; }

        /// <summary>
        /// Gets or sets the concealedstationary.
        /// </summary>
        /// <value>The concealedstationary.</value>
        public ConcealedStationaryValue ConcealedStationary { get; set; }

        /// <summary>
        /// Gets or sets the concealedmovement.
        /// </summary>
        /// <value>The concealedmovement.</value>
        public ConcealedMovementValue ConcealedMovement { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is LifeFormAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="LifeFormAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="LifeFormAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="LifeFormAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LifeFormAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return PaintScheme == other.PaintScheme &&
                Health == other.Health &&
                Compliance == other.Compliance &&
                FlashLights == other.FlashLights &&
                LifeFormState == other.LifeFormState &&
                FrozenStatus == other.FrozenStatus &&
                State == other.State &&
                Weapon1 == other.Weapon1 &&
                Weapon2 == other.Weapon2 &&
                CamouflageType == other.CamouflageType &&
                ConcealedStationary == other.ConcealedStationary &&
                ConcealedMovement == other.ConcealedMovement;
        }

        /// <summary>
        /// Converts the instance of <see cref="LifeFormAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="LifeFormAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="LifeFormAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="LifeFormAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)PaintScheme << 0;
            val |= (uint)Health << 3;
            val |= (uint)Compliance << 5;
            val |= (uint)FlashLights << 12;
            val |= (uint)LifeFormState << 16;
            val |= (uint)FrozenStatus << 21;
            val |= (uint)State << 23;
            val |= (uint)Weapon1 << 24;
            val |= (uint)Weapon2 << 26;
            val |= (uint)CamouflageType << 28;
            val |= (uint)ConcealedStationary << 30;
            val |= (uint)ConcealedMovement << 31;

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
                hash = (hash * 29) + Health.GetHashCode();
                hash = (hash * 29) + Compliance.GetHashCode();
                hash = (hash * 29) + FlashLights.GetHashCode();
                hash = (hash * 29) + LifeFormState.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + Weapon1.GetHashCode();
                hash = (hash * 29) + Weapon2.GetHashCode();
                hash = (hash * 29) + CamouflageType.GetHashCode();
                hash = (hash * 29) + ConcealedStationary.GetHashCode();
                hash = (hash * 29) + ConcealedMovement.GetHashCode();
            }

            return hash;
        }
    }
}
