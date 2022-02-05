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
    /// Enumeration values for EnvironmentalAppearance (es.appear.environmental, Environmentals Kind,
    /// section 4.3.4)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct EnvironmentalAppearance : IHashable<EnvironmentalAppearance>
    {
        /// <summary>
        /// Describes the density of the environmentals
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the density of the environmentals")]
        public enum DensityValue : uint
        {
            /// <summary>
            /// Clear
            /// </summary>
            Clear = 0,

            /// <summary>
            /// Hazy
            /// </summary>
            Hazy = 1,

            /// <summary>
            /// Dense
            /// </summary>
            Dense = 2,

            /// <summary>
            /// Very dense
            /// </summary>
            VeryDense = 3,

            /// <summary>
            /// Opaque
            /// </summary>
            Opaque = 4,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 5
        }

        /// <summary>
        /// Describes the frozen status of a environmental object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the frozen status of a environmental object")]
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
        /// Describes the state of a environmental object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the state of a environmental object")]
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
        public static bool operator !=(EnvironmentalAppearance left, EnvironmentalAppearance right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(EnvironmentalAppearance left, EnvironmentalAppearance right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="EnvironmentalAppearance"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="EnvironmentalAppearance"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(EnvironmentalAppearance obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="EnvironmentalAppearance"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator EnvironmentalAppearance(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="EnvironmentalAppearance"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="EnvironmentalAppearance"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="EnvironmentalAppearance"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static EnvironmentalAppearance FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="EnvironmentalAppearance"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="EnvironmentalAppearance"/> instance.</param>
        /// <returns>The <see cref="EnvironmentalAppearance"/> instance, represented by the uint value.</returns>
        public static EnvironmentalAppearance FromUInt32(uint value)
        {
            var ps = new EnvironmentalAppearance();

            const uint mask1 = 0xf0000;
            const byte shift1 = 16;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Density = (DensityValue)newValue1;

            const uint mask3 = 0x200000;
            const byte shift3 = 21;
            uint newValue3 = (value & mask3) >> shift3;
            ps.FrozenStatus = (FrozenStatusValue)newValue3;

            const uint mask5 = 0x800000;
            const byte shift5 = 23;
            uint newValue5 = (value & mask5) >> shift5;
            ps.State = (StateValue)newValue5;

            const uint mask7 = 0x80000000;
            const byte shift7 = 31;
            uint newValue7 = (value & mask7) >> shift7;
            ps.MaskedCloaked = (MaskedCloakedValue)newValue7;

            return ps;
        }

        /// <summary>
        /// Gets or sets the density.
        /// </summary>
        /// <value>The density.</value>
        public DensityValue Density { get; set; }

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
        /// Gets or sets the maskedcloaked.
        /// </summary>
        /// <value>The maskedcloaked.</value>
        public MaskedCloakedValue MaskedCloaked { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is EnvironmentalAppearance other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="EnvironmentalAppearance"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="EnvironmentalAppearance"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="EnvironmentalAppearance"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EnvironmentalAppearance other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Density == other.Density &&
                FrozenStatus == other.FrozenStatus &&
                State == other.State &&
                MaskedCloaked == other.MaskedCloaked;
        }

        /// <summary>
        /// Converts the instance of <see cref="EnvironmentalAppearance"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="EnvironmentalAppearance"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="EnvironmentalAppearance"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="EnvironmentalAppearance"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Density << 16;
            val |= (uint)FrozenStatus << 21;
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
                hash = (hash * 29) + Density.GetHashCode();
                hash = (hash * 29) + FrozenStatus.GetHashCode();
                hash = (hash * 29) + State.GetHashCode();
                hash = (hash * 29) + MaskedCloaked.GetHashCode();
            }

            return hash;
        }
    }
}
