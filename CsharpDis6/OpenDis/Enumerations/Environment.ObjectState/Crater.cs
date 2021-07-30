// Copyright 2008-2011. This work is licensed under the BSD license, available at
// http://www.movesinstitute.org/licenses
//
// Orignal authors: DMcG, Jason Nelson
// Modified for use with C#:
// - Peter Smith (Naval Air Warfare Center - Training Systems Division)
// - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenDis.Enumerations.Environment.ObjectState
{
    /// <summary>
    /// Enumeration values for Crater (env.obj.appear.point.crater, Crater,
    /// section 12.1.2.2.4)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Crater : IHashable<Crater>
    {
        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Crater left, Crater right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Crater left, Crater right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="Crater"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Crater"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(Crater obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="Crater"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Crater(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="Crater"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="Crater"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="Crater"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static Crater FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="Crater"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="Crater"/> instance.</param>
        /// <returns>The <see cref="Crater"/> instance, represented by the uint value.</returns>
        public static Crater FromUInt32(uint value)
        {
            var ps = new Crater();

            const uint mask0 = 0xff0000;
            const byte shift0 = 16;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Size = (byte)newValue0;

            return ps;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public byte Size { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Crater other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="Crater"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Crater"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="Crater"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Crater other) => Size == other.Size;

        /// <summary>
        /// Converts the instance of <see cref="Crater"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="Crater"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="Crater"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="Crater"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Size << 16;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Size.GetHashCode();
            }

            return hash;
        }
    }
}
