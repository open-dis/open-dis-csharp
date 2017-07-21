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
    public struct RadioSignalEncoding
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

        private RadioSignalEncoding.EncodingTypeValue encodingType;
        private RadioSignalEncoding.EncodingClassValue encodingClass;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RadioSignalEncoding left, RadioSignalEncoding right)
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
        public static bool operator ==(RadioSignalEncoding left, RadioSignalEncoding right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> to <see cref="System.UInt16"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(RadioSignalEncoding obj)
        {
            return obj.ToUInt16();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator RadioSignalEncoding(ushort value)
        {
            return RadioSignalEncoding.FromUInt16(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static RadioSignalEncoding FromByteArray(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 ||
                index > array.Length - 1 ||
                index + 2 > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return FromUInt16(BitConverter.ToUInt16(array, index));
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance, represented by the ushort value.</returns>
        public static RadioSignalEncoding FromUInt16(ushort value)
        {
            RadioSignalEncoding ps = new RadioSignalEncoding();

            uint mask0 = 0x3fff;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.EncodingType = (RadioSignalEncoding.EncodingTypeValue)newValue0;

            uint mask1 = 0xc000;
            byte shift1 = 14;
            uint newValue1 = value & mask1 >> shift1;
            ps.EncodingClass = (RadioSignalEncoding.EncodingClassValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the encodingtype.
        /// </summary>
        /// <value>The encodingtype.</value>
        public RadioSignalEncoding.EncodingTypeValue EncodingType
        {
            get { return this.encodingType; }
            set { this.encodingType = value; }
        }

        /// <summary>
        /// Gets or sets the encodingclass.
        /// </summary>
        /// <value>The encodingclass.</value>
        public RadioSignalEncoding.EncodingClassValue EncodingClass
        {
            get { return this.encodingClass; }
            set { this.encodingClass = value; }
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

            if (!(obj is RadioSignalEncoding))
            {
                return false;
            }

            return this.Equals((RadioSignalEncoding)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(RadioSignalEncoding other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.EncodingType == other.EncodingType &&
                this.EncodingClass == other.EncodingClass;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt16());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="OpenDis.Enumerations.Radio.Transmitter.RadioSignalEncoding"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)this.EncodingType << 0);
            val |= (ushort)((uint)this.EncodingClass << 14);

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
                hash = (hash * 29) + this.EncodingType.GetHashCode();
                hash = (hash * 29) + this.EncodingClass.GetHashCode();
            }

            return hash;
        }
    }
}
