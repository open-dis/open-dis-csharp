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
    /// Enumeration values for AirBurstAndGroundBurst (env.obj.appear.point.burst, Air burst, Ground burst,
    /// section 12.1.2.2.3)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct AirBurstAndGroundBurst : IHashable<AirBurstAndGroundBurst>
    {
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
        public static bool operator !=(AirBurstAndGroundBurst left, AirBurstAndGroundBurst right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AirBurstAndGroundBurst left, AirBurstAndGroundBurst right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="AirBurstAndGroundBurst"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="AirBurstAndGroundBurst"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(AirBurstAndGroundBurst obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="AirBurstAndGroundBurst"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator AirBurstAndGroundBurst(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="AirBurstAndGroundBurst"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="AirBurstAndGroundBurst"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="AirBurstAndGroundBurst"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static AirBurstAndGroundBurst FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="AirBurstAndGroundBurst"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="AirBurstAndGroundBurst"/> instance.</param>
        /// <returns>The <see cref="AirBurstAndGroundBurst"/> instance, represented by the uint value.</returns>
        public static AirBurstAndGroundBurst FromUInt32(uint value)
        {
            var ps = new AirBurstAndGroundBurst();

            const uint mask0 = 0xff0000;
            const byte shift0 = 16;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Opacity = (byte)newValue0;

            const uint mask1 = 0xff000000;
            const byte shift1 = 24;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Size = (byte)newValue1;

            const uint mask2 = 0x00ff;
            const byte shift2 = 32;
            uint newValue2 = (value & mask2) >> shift2;
            ps.Height = (byte)newValue2;

            const uint mask3 = 0x3f00;
            const byte shift3 = 40;
            uint newValue3 = (value & mask3) >> shift3;
            ps.NumOfBursts = (byte)newValue3;

            const uint mask4 = 0xc000;
            const byte shift4 = 46;
            uint newValue4 = (value & mask4) >> shift4;
            ps.Chemical = (ChemicalValue)newValue4;

            return ps;
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public byte Opacity { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public byte Size { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public byte Height { get; set; }

        /// <summary>
        /// Gets or sets the numofbursts.
        /// </summary>
        /// <value>The numofbursts.</value>
        public byte NumOfBursts { get; set; }

        /// <summary>
        /// Gets or sets the chemical.
        /// </summary>
        /// <value>The chemical.</value>
        public ChemicalValue Chemical { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
            => obj is AirBurstAndGroundBurst other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="AirBurstAndGroundBurst"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="AirBurstAndGroundBurst"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="AirBurstAndGroundBurst"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AirBurstAndGroundBurst other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Opacity == other.Opacity &&
                Size == other.Size &&
                Height == other.Height &&
                NumOfBursts == other.NumOfBursts &&
                Chemical == other.Chemical;
        }

        /// <summary>
        /// Converts the instance of <see cref="AirBurstAndGroundBurst"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="AirBurstAndGroundBurst"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="AirBurstAndGroundBurst"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="AirBurstAndGroundBurst"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Opacity << 16;
            val |= (uint)Size << 24;
            val |= (uint)Height << 32;
            val |= (uint)NumOfBursts << 40;
            val |= (uint)Chemical << 46;

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
                hash = (hash * 29) + Size.GetHashCode();
                hash = (hash * 29) + Height.GetHashCode();
                hash = (hash * 29) + NumOfBursts.GetHashCode();
                hash = (hash * 29) + Chemical.GetHashCode();
            }

            return hash;
        }
    }
}
