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

namespace OpenDis.Enumerations.Radio.Transmitter
{
    /// <summary>
    /// Enumeration values for RadioSignalEncoding (radio.tx.encoding, Radio signal encoding,
    /// section 9.1.8 - 9.1.9)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct RadioSignalEncoding : IHashable<RadioSignalEncoding>
    {
        /// <summary>
        /// Encoding type
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Encoding type")]
        public enum EncodingTypeValue : uint
        {
            /// <summary>
            /// 8-bit mu-law
            /// </summary>
            _8BitMuLaw = 1,

            /// <summary>
            /// CVSD per MIL-STD-188-113
            /// </summary>
            CVSDPerMILSTD188113 = 2,

            /// <summary>
            /// ADPCM per CCITT G.721
            /// </summary>
            ADPCMPerCCITTG721 = 3,

            /// <summary>
            /// 16-bit linear PCM
            /// </summary>
            _16BitLinearPCM = 4,

            /// <summary>
            /// 8-bit linear PCM
            /// </summary>
            _8BitLinearPCM = 5,

            /// <summary>
            /// VQ (Vector Quantization)
            /// </summary>
            VQVectorQuantization = 6
        }

        /// <summary>
        /// Encoding class
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Encoding class")]
        public enum EncodingClassValue : uint
        {
            /// <summary>
            /// Encoded audio
            /// </summary>
            EncodedAudio = 0,

            /// <summary>
            /// Raw Binary Data
            /// </summary>
            RawBinaryData = 1,

            /// <summary>
            /// Application-Specific Data
            /// </summary>
            ApplicationSpecificData = 2,

            /// <summary>
            /// Database index
            /// </summary>
            DatabaseIndex = 3
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RadioSignalEncoding left, RadioSignalEncoding right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(RadioSignalEncoding left, RadioSignalEncoding right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="RadioSignalEncoding"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj">The <see cref="RadioSignalEncoding"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(RadioSignalEncoding obj) => obj.ToUInt16();

        /// <summary>
        /// Performs an explicit conversion from <see cref="ushort"/> to <see cref="RadioSignalEncoding"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator RadioSignalEncoding(ushort value) => FromUInt16(value);

        /// <summary>
        /// Creates the <see cref="RadioSignalEncoding"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="RadioSignalEncoding"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="RadioSignalEncoding"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static RadioSignalEncoding FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="RadioSignalEncoding"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="RadioSignalEncoding"/> instance.</param>
        /// <returns>The <see cref="RadioSignalEncoding"/> instance, represented by the ushort value.</returns>
        public static RadioSignalEncoding FromUInt16(ushort value)
        {
            var ps = new RadioSignalEncoding();

            const uint mask0 = 0x3fff;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.EncodingType = (EncodingTypeValue)newValue0;

            const uint mask1 = 0xc000;
            const byte shift1 = 14;
            uint newValue1 = (value & mask1) >> shift1;
            ps.EncodingClass = (EncodingClassValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the encodingtype.
        /// </summary>
        /// <value>The encodingtype.</value>
        public EncodingTypeValue EncodingType { get; set; }

        /// <summary>
        /// Gets or sets the encodingclass.
        /// </summary>
        /// <value>The encodingclass.</value>
        public EncodingClassValue EncodingClass { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is RadioSignalEncoding other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="RadioSignalEncoding"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="RadioSignalEncoding"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="RadioSignalEncoding"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(RadioSignalEncoding other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return EncodingType == other.EncodingType &&
                EncodingClass == other.EncodingClass;
        }

        /// <summary>
        /// Converts the instance of <see cref="RadioSignalEncoding"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="RadioSignalEncoding"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt16());

        /// <summary>
        /// Converts the instance of <see cref="RadioSignalEncoding"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="RadioSignalEncoding"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)EncodingType << 0);
            val |= (ushort)((uint)EncodingClass << 14);

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + EncodingType.GetHashCode();
                hash = (hash * 29) + EncodingClass.GetHashCode();
            }

            return hash;
        }
    }
}
