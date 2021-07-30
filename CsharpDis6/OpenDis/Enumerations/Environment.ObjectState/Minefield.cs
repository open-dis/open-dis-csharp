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

namespace OpenDis.Enumerations.Environment.ObjectState
{
    /// <summary>
    /// Enumeration values for Minefield (env.obj.appear.areal.minefield, Minefield,
    /// section 12.1.2.4.1)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Minefield : IHashable<Minefield>
    {
        /// <summary>
        /// Describes the breached appearance of the object
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the breached appearance of the object")]
        public enum BreachValue : uint
        {
            /// <summary>
            /// No breaching
            /// </summary>
            NoBreaching = 0,

            /// <summary>
            /// Breached
            /// </summary>
            Breached = 1,

            /// <summary>
            /// Cleared
            /// </summary>
            Cleared = 2,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 3
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Minefield left, Minefield right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Minefield left, Minefield right) => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="Minefield"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Minefield"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(Minefield obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="Minefield"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Minefield(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="Minefield"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="Minefield"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="Minefield"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static Minefield FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="Minefield"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="Minefield"/> instance.</param>
        /// <returns>The <see cref="Minefield"/> instance, represented by the uint value.</returns>
        public static Minefield FromUInt32(uint value)
        {
            var ps = new Minefield();

            const uint mask0 = 0x30000;
            const byte shift0 = 16;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Breach = (BreachValue)newValue0;

            const uint mask2 = 0x80000000;
            const byte shift2 = 31;
            uint newValue2 = (value & mask2) >> shift2;
            ps.MineCount = (int)newValue2;

            return ps;
        }

        /// <summary>
        /// Gets or sets the breach.
        /// </summary>
        /// <value>The breach.</value>
        public BreachValue Breach { get; set; }

        /// <summary>
        /// Gets or sets the minecount.
        /// </summary>
        /// <value>The minecount.</value>
        public int MineCount { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Minefield other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="Minefield"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Minefield"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="Minefield"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Minefield other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Breach == other.Breach &&
                MineCount == other.MineCount;
        }

        /// <summary>
        /// Converts the instance of <see cref="Minefield"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="Minefield"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="Minefield"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="Minefield"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Breach << 16;
            val |= (uint)MineCount << 31;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Breach.GetHashCode();
                hash = (hash * 29) + MineCount.GetHashCode();
            }

            return hash;
        }
    }
}
