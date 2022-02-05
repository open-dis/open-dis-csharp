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
    /// Enumeration values for ExhaustSmoke (env.obj.appear.linear.exhaust, Exhaust smoke,
    /// section 12.1.2.3.2)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct ExhaustSmoke : IHashable<ExhaustSmoke>
    {
        /// <summary>
        /// Describes whether the smoke is attached to the vehicle
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes whether the smoke is attached to the vehicle")]
        public enum AttachedValue : uint
        {
            /// <summary>
            /// Not attached
            /// </summary>
            NotAttached = 0,

            /// <summary>
            /// Attached
            /// </summary>
            Attached = 1
        }

        /// <summary>
        /// Describes the chemical content of the smoke
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the chemical content of the smoke")]
        public enum ChemicalValue : uint
        {
            /// <summary>
            /// Other
            /// </summary>
            Other = 0,

            /// <summary>
            /// Hydrochloric
            /// </summary>
            Hydrochloric = 1,

            /// <summary>
            /// White phosphorous
            /// </summary>
            WhitePhosphorous = 2,

            /// <summary>
            /// Red phosphorous
            /// </summary>
            RedPhosphorous = 3
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ExhaustSmoke left, ExhaustSmoke right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ExhaustSmoke left, ExhaustSmoke right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="ExhaustSmoke"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="ExhaustSmoke"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(ExhaustSmoke obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="ExhaustSmoke"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ExhaustSmoke(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="ExhaustSmoke"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="ExhaustSmoke"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="ExhaustSmoke"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static ExhaustSmoke FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="ExhaustSmoke"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="ExhaustSmoke"/> instance.</param>
        /// <returns>The <see cref="ExhaustSmoke"/> instance, represented by the uint value.</returns>
        public static ExhaustSmoke FromUInt32(uint value)
        {
            var ps = new ExhaustSmoke();

            const uint mask0 = 0xff0000;
            const byte shift0 = 16;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Opacity = (byte)newValue0;

            const uint mask1 = 0x1000000;
            const byte shift1 = 24;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Attached = (AttachedValue)newValue1;

            const uint mask2 = 0x6000000;
            const byte shift2 = 25;
            uint newValue2 = (value & mask2) >> shift2;
            ps.Chemical = (ChemicalValue)newValue2;

            return ps;
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public byte Opacity { get; set; }

        /// <summary>
        /// Gets or sets the attached.
        /// </summary>
        /// <value>The attached.</value>
        public AttachedValue Attached { get; set; }

        /// <summary>
        /// Gets or sets the chemical.
        /// </summary>
        /// <value>The chemical.</value>
        public ChemicalValue Chemical { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ExhaustSmoke other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="ExhaustSmoke"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="ExhaustSmoke"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="ExhaustSmoke"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ExhaustSmoke other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Opacity == other.Opacity &&
                Attached == other.Attached &&
                Chemical == other.Chemical;
        }

        /// <summary>
        /// Converts the instance of <see cref="ExhaustSmoke"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="ExhaustSmoke"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="ExhaustSmoke"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="ExhaustSmoke"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Opacity << 16;
            val |= (uint)Attached << 24;
            val |= (uint)Chemical << 25;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Opacity.GetHashCode();
                hash = (hash * 29) + Attached.GetHashCode();
                hash = (hash * 29) + Chemical.GetHashCode();
            }

            return hash;
        }
    }
}
