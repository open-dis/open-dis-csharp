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
    /// Enumeration values for CulturalAppearance (es.appear.cultural, Cultural Features Kind, 
    /// section 4.3.5)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct CulturalAppearance
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
        /// Describes status of smoke emanating from a Cultural Features object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes status of smoke emanating from a Cultural Features object")]
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
        /// Describes whether flames are rising from a Cultural Features object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether flames are rising from a Cultural Features object")]
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
        /// Describes the frozen status of a Cultural Features object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a Cultural Features object")]
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
        /// Describes the Internal-Heat status
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the Internal-Heat status")]
        public enum InternalHeatStatusValue : uint
        {
            /// <summary>
            /// Internal-Heat off
            /// </summary>
            InternalHeatOff = 0,

            /// <summary>
            /// Internal-Heat on
            /// </summary>
            InternalHeatOn = 1
        }

        /// <summary>
        /// Describes the state of a Cultural object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a Cultural object")]
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
        /// Describes whether Exterior Lights are on or off.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether Exterior Lights are on or off.")]
        public enum ExteriorLightsValue : uint
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

        private CulturalAppearance.DamageValue damage;
        private CulturalAppearance.SmokeValue smoke;
        private CulturalAppearance.FlamingValue flaming;
        private CulturalAppearance.FrozenStatusValue frozenStatus;
        private CulturalAppearance.InternalHeatStatusValue internalHeatStatus;
        private CulturalAppearance.StateValue state;
        private CulturalAppearance.ExteriorLightsValue exteriorLights;
        private CulturalAppearance.InteriorLightsValue interiorLights;
        private CulturalAppearance.MaskedCloakedValue maskedCloaked;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(CulturalAppearance left, CulturalAppearance right)
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
        public static bool operator ==(CulturalAppearance left, CulturalAppearance right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(CulturalAppearance obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator CulturalAppearance(uint value)
        {
            return CulturalAppearance.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static CulturalAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance, represented by the uint value.</returns>
        public static CulturalAppearance FromUInt32(uint value)
        {
            CulturalAppearance ps = new CulturalAppearance();

            uint mask1 = 0x0018;
            byte shift1 = 3;
            uint newValue1 = value & mask1 >> shift1;
            ps.Damage = (CulturalAppearance.DamageValue)newValue1;

            uint mask2 = 0x0060;
            byte shift2 = 5;
            uint newValue2 = value & mask2 >> shift2;
            ps.Smoke = (CulturalAppearance.SmokeValue)newValue2;

            uint mask4 = 0x8000;
            byte shift4 = 15;
            uint newValue4 = value & mask4 >> shift4;
            ps.Flaming = (CulturalAppearance.FlamingValue)newValue4;

            uint mask6 = 0x200000;
            byte shift6 = 21;
            uint newValue6 = value & mask6 >> shift6;
            ps.FrozenStatus = (CulturalAppearance.FrozenStatusValue)newValue6;

            uint mask7 = 0x400000;
            byte shift7 = 22;
            uint newValue7 = value & mask7 >> shift7;
            ps.InternalHeatStatus = (CulturalAppearance.InternalHeatStatusValue)newValue7;

            uint mask8 = 0x800000;
            byte shift8 = 23;
            uint newValue8 = value & mask8 >> shift8;
            ps.State = (CulturalAppearance.StateValue)newValue8;

            uint mask10 = 0x10000000;
            byte shift10 = 28;
            uint newValue10 = value & mask10 >> shift10;
            ps.ExteriorLights = (CulturalAppearance.ExteriorLightsValue)newValue10;

            uint mask11 = 0x20000000;
            byte shift11 = 29;
            uint newValue11 = value & mask11 >> shift11;
            ps.InteriorLights = (CulturalAppearance.InteriorLightsValue)newValue11;

            uint mask13 = 0x80000000;
            byte shift13 = 31;
            uint newValue13 = value & mask13 >> shift13;
            ps.MaskedCloaked = (CulturalAppearance.MaskedCloakedValue)newValue13;

            return ps;
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public CulturalAppearance.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the smoke.
        /// </summary>
        /// <value>The smoke.</value>
        public CulturalAppearance.SmokeValue Smoke
        {
            get { return this.smoke; }
            set { this.smoke = value; }
        }

        /// <summary>
        /// Gets or sets the flaming.
        /// </summary>
        /// <value>The flaming.</value>
        public CulturalAppearance.FlamingValue Flaming
        {
            get { return this.flaming; }
            set { this.flaming = value; }
        }

        /// <summary>
        /// Gets or sets the frozenstatus.
        /// </summary>
        /// <value>The frozenstatus.</value>
        public CulturalAppearance.FrozenStatusValue FrozenStatus
        {
            get { return this.frozenStatus; }
            set { this.frozenStatus = value; }
        }

        /// <summary>
        /// Gets or sets the internalheatstatus.
        /// </summary>
        /// <value>The internalheatstatus.</value>
        public CulturalAppearance.InternalHeatStatusValue InternalHeatStatus
        {
            get { return this.internalHeatStatus; }
            set { this.internalHeatStatus = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public CulturalAppearance.StateValue State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the exteriorlights.
        /// </summary>
        /// <value>The exteriorlights.</value>
        public CulturalAppearance.ExteriorLightsValue ExteriorLights
        {
            get { return this.exteriorLights; }
            set { this.exteriorLights = value; }
        }

        /// <summary>
        /// Gets or sets the interiorlights.
        /// </summary>
        /// <value>The interiorlights.</value>
        public CulturalAppearance.InteriorLightsValue InteriorLights
        {
            get { return this.interiorLights; }
            set { this.interiorLights = value; }
        }

        /// <summary>
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public CulturalAppearance.MaskedCloakedValue MaskedCloaked
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

            if (!(obj is CulturalAppearance))
            {
                return false;
            }

            return this.Equals((CulturalAppearance)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CulturalAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Damage == other.Damage &&
                this.Smoke == other.Smoke &&
                this.Flaming == other.Flaming &&
                this.FrozenStatus == other.FrozenStatus &&
                this.InternalHeatStatus == other.InternalHeatStatus &&
                this.State == other.State &&
                this.ExteriorLights == other.ExteriorLights &&
                this.InteriorLights == other.InteriorLights &&
                this.MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.EntityState.Appearance.CulturalAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Damage << 3);
            val |= (uint)((uint)this.Smoke << 5);
            val |= (uint)((uint)this.Flaming << 15);
            val |= (uint)((uint)this.FrozenStatus << 21);
            val |= (uint)((uint)this.InternalHeatStatus << 22);
            val |= (uint)((uint)this.State << 23);
            val |= (uint)((uint)this.ExteriorLights << 28);
            val |= (uint)((uint)this.InteriorLights << 29);
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
                hash = (hash * 29) + this.Flaming.GetHashCode();
                hash = (hash * 29) + this.FrozenStatus.GetHashCode();
                hash = (hash * 29) + this.InternalHeatStatus.GetHashCode();
                hash = (hash * 29) + this.State.GetHashCode();
                hash = (hash * 29) + this.ExteriorLights.GetHashCode();
                hash = (hash * 29) + this.InteriorLights.GetHashCode();
                hash = (hash * 29) + this.MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
