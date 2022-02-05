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

namespace OpenDis.Enumerations.DistributedEmission.Iff
{
    /// <summary>
    /// Enumeration values for Type1Parameter2Mode2CodeStatus (der.iff.type.1.fop.param2, Parameter 2 - Mode 2 Code/Status,
    /// section 8.3.1.2.3)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Type1Parameter2Mode2CodeStatus : IHashable<Type1Parameter2Mode2CodeStatus>
    {
        /// <summary>
        /// Status
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Status")]
        public enum StatusValue : uint
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
        /// Damage
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Damage")]
        public enum DamageValue : uint
        {
            /// <summary>
            /// No damage
            /// </summary>
            NoDamage = 0,

            /// <summary>
            /// Damage
            /// </summary>
            Damage = 1
        }

        /// <summary>
        /// Malfunction
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Malfunction")]
        public enum MalfunctionValue : uint
        {
            /// <summary>
            /// No malfunction
            /// </summary>
            NoMalfunction = 0,

            /// <summary>
            /// Malfunction
            /// </summary>
            Malfunction = 1
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Type1Parameter2Mode2CodeStatus left, Type1Parameter2Mode2CodeStatus right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Type1Parameter2Mode2CodeStatus left, Type1Parameter2Mode2CodeStatus right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="Type1Parameter2Mode2CodeStatus"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Type1Parameter2Mode2CodeStatus"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(Type1Parameter2Mode2CodeStatus obj) => obj.ToUInt16();

        /// <summary>
        /// Performs an explicit conversion from <see cref="ushort"/> to <see cref="Type1Parameter2Mode2CodeStatus"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Type1Parameter2Mode2CodeStatus(ushort value) => FromUInt16(value);

        /// <summary>
        /// Creates the <see cref="Type1Parameter2Mode2CodeStatus"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="Type1Parameter2Mode2CodeStatus"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="Type1Parameter2Mode2CodeStatus"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static Type1Parameter2Mode2CodeStatus FromByteArray(byte[] array, int index)
        {
            return array == null
                ? throw new ArgumentNullException(nameof(array))
                : index < 0 ||
                index > array.Length - 1 ||
                index + 2 > array.Length - 1
                ? throw new IndexOutOfRangeException()
                : FromUInt16(BitConverter.ToUInt16(array, index));
        }

        /// <summary>
        /// Creates the <see cref="Type1Parameter2Mode2CodeStatus"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="Type1Parameter2Mode2CodeStatus"/> instance.</param>
        /// <returns>The <see cref="Type1Parameter2Mode2CodeStatus"/> instance, represented by the ushort value.</returns>
        public static Type1Parameter2Mode2CodeStatus FromUInt16(ushort value)
        {
            var ps = new Type1Parameter2Mode2CodeStatus();

            const uint mask0 = 0x0007;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.CodeElement1 = (byte)newValue0;

            const uint mask1 = 0x0038;
            const byte shift1 = 3;
            uint newValue1 = (value & mask1) >> shift1;
            ps.CodeElement2 = (byte)newValue1;

            const uint mask2 = 0x01c0;
            const byte shift2 = 6;
            uint newValue2 = (value & mask2) >> shift2;
            ps.CodeElement3 = (byte)newValue2;

            const uint mask3 = 0x0e00;
            const byte shift3 = 9;
            uint newValue3 = (value & mask3) >> shift3;
            ps.CodeElement4 = (byte)newValue3;

            const uint mask5 = 0x2000;
            const byte shift5 = 13;
            uint newValue5 = (value & mask5) >> shift5;
            ps.Status = (StatusValue)newValue5;

            const uint mask6 = 0x4000;
            const byte shift6 = 14;
            uint newValue6 = (value & mask6) >> shift6;
            ps.Damage = (DamageValue)newValue6;

            const uint mask7 = 0x8000;
            const byte shift7 = 15;
            uint newValue7 = (value & mask7) >> shift7;
            ps.Malfunction = (MalfunctionValue)newValue7;

            return ps;
        }

        /// <summary>
        /// Gets or sets the codeelement1.
        /// </summary>
        /// <value>The codeelement1.</value>
        public byte CodeElement1 { get; set; }

        /// <summary>
        /// Gets or sets the codeelement2.
        /// </summary>
        /// <value>The codeelement2.</value>
        public byte CodeElement2 { get; set; }

        /// <summary>
        /// Gets or sets the codeelement3.
        /// </summary>
        /// <value>The codeelement3.</value>
        public byte CodeElement3 { get; set; }

        /// <summary>
        /// Gets or sets the codeelement4.
        /// </summary>
        /// <value>The codeelement4.</value>
        public byte CodeElement4 { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public StatusValue Status { get; set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public DamageValue Damage { get; set; }

        /// <summary>
        /// Gets or sets the malfunction.
        /// </summary>
        /// <value>The malfunction.</value>
        public MalfunctionValue Malfunction { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Type1Parameter2Mode2CodeStatus other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="Type1Parameter2Mode2CodeStatus"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Type1Parameter2Mode2CodeStatus"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="Type1Parameter2Mode2CodeStatus"/> is equal to this instance; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool Equals(Type1Parameter2Mode2CodeStatus other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return CodeElement1 == other.CodeElement1 &&
                CodeElement2 == other.CodeElement2 &&
                CodeElement3 == other.CodeElement3 &&
                CodeElement4 == other.CodeElement4 &&
                Status == other.Status &&
                Damage == other.Damage &&
                Malfunction == other.Malfunction;
        }

        /// <summary>
        /// Converts the instance of <see cref="Type1Parameter2Mode2CodeStatus"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="Type1Parameter2Mode2CodeStatus"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt16());

        /// <summary>
        /// Converts the instance of <see cref="Type1Parameter2Mode2CodeStatus"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="Type1Parameter2Mode2CodeStatus"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)CodeElement1 << 0);
            val |= (ushort)((uint)CodeElement2 << 3);
            val |= (ushort)((uint)CodeElement3 << 6);
            val |= (ushort)((uint)CodeElement4 << 9);
            val |= (ushort)((uint)Status << 13);
            val |= (ushort)((uint)Damage << 14);
            val |= (ushort)((uint)Malfunction << 15);

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + CodeElement1.GetHashCode();
                hash = (hash * 29) + CodeElement2.GetHashCode();
                hash = (hash * 29) + CodeElement3.GetHashCode();
                hash = (hash * 29) + CodeElement4.GetHashCode();
                hash = (hash * 29) + Status.GetHashCode();
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Malfunction.GetHashCode();
            }

            return hash;
        }
    }
}
