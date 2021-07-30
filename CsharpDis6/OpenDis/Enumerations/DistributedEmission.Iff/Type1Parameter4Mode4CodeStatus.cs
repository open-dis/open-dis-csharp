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
    /// Enumeration values for Type1Parameter4Mode4CodeStatus (der.iff.type.1.fop.param4, Parameter 4 - Mode 4 Code/Status,
    /// section 8.3.1.2.5)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Type1Parameter4Mode4CodeStatus : IHashable<Type1Parameter4Mode4CodeStatus>
    {
        /// <summary>
        /// Code element 1
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Code element 1")]
        public enum CodeElement1Value : uint
        {
            /// <summary>
            /// Pseudo-Crypto value
            /// </summary>
            PseudoCryptoValue = 0,

            /// <summary>
            /// No Pseudo-Crypto value. Use Alternate Mode 4 value
            /// </summary>
            NoPseudoCryptoValueUseAlternateMode4Value = 4095
        }

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
        public static bool operator !=(Type1Parameter4Mode4CodeStatus left, Type1Parameter4Mode4CodeStatus right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Type1Parameter4Mode4CodeStatus left, Type1Parameter4Mode4CodeStatus right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="Type1Parameter4Mode4CodeStatus"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Type1Parameter4Mode4CodeStatus"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(Type1Parameter4Mode4CodeStatus obj) => obj.ToUInt16();

        /// <summary>
        /// Performs an explicit conversion from <see cref="ushort"/> to <see cref="Type1Parameter4Mode4CodeStatus"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Type1Parameter4Mode4CodeStatus(ushort value) => FromUInt16(value);

        /// <summary>
        /// Creates the <see cref="Type1Parameter4Mode4CodeStatus"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="Type1Parameter4Mode4CodeStatus"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="Type1Parameter4Mode4CodeStatus"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static Type1Parameter4Mode4CodeStatus FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="Type1Parameter4Mode4CodeStatus"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="Type1Parameter4Mode4CodeStatus"/> instance.</param>
        /// <returns>The <see cref="Type1Parameter4Mode4CodeStatus"/> instance, represented by the ushort value.</returns>
        public static Type1Parameter4Mode4CodeStatus FromUInt16(ushort value)
        {
            var ps = new Type1Parameter4Mode4CodeStatus();

            const uint mask0 = 0x0fff;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.CodeElement1 = (CodeElement1Value)newValue0;

            const uint mask2 = 0x2000;
            const byte shift2 = 13;
            uint newValue2 = (value & mask2) >> shift2;
            ps.Status = (StatusValue)newValue2;

            const uint mask3 = 0x4000;
            const byte shift3 = 14;
            uint newValue3 = (value & mask3) >> shift3;
            ps.Damage = (DamageValue)newValue3;

            const uint mask4 = 0x8000;
            const byte shift4 = 15;
            uint newValue4 = (value & mask4) >> shift4;
            ps.Malfunction = (MalfunctionValue)newValue4;

            return ps;
        }

        /// <summary>
        /// Gets or sets the codeelement1.
        /// </summary>
        /// <value>The codeelement1.</value>
        public CodeElement1Value CodeElement1 { get; set; }

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
        public override bool Equals(object obj) => obj is Type1Parameter4Mode4CodeStatus other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="Type1Parameter4Mode4CodeStatus"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Type1Parameter4Mode4CodeStatus"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="Type1Parameter4Mode4CodeStatus"/> is equal to this instance; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool Equals(Type1Parameter4Mode4CodeStatus other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return CodeElement1 == other.CodeElement1 &&
                Status == other.Status &&
                Damage == other.Damage &&
                Malfunction == other.Malfunction;
        }

        /// <summary>
        /// Converts the instance of <see cref="Type1Parameter4Mode4CodeStatus"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="Type1Parameter4Mode4CodeStatus"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt16());

        /// <summary>
        /// Converts the instance of <see cref="Type1Parameter4Mode4CodeStatus"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="Type1Parameter4Mode4CodeStatus"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)CodeElement1 << 0);
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
                hash = (hash * 29) + Status.GetHashCode();
                hash = (hash * 29) + Damage.GetHashCode();
                hash = (hash * 29) + Malfunction.GetHashCode();
            }

            return hash;
        }
    }
}
