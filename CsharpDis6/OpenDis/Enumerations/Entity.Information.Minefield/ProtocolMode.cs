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

namespace OpenDis.Enumerations.Entity.Information.Minefield
{
    /// <summary>
    /// Enumeration values for ProtocolMode (entity.mine.protocolmode, Protocol Mode,
    /// section 10.2.6)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct ProtocolMode : IHashable<ProtocolMode>
    {
        /// <summary>
        /// Protocol Mode
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Protocol Mode")]
        public enum ProtocolModeValue : uint
        {
            /// <summary>
            /// Heartbeat mode
            /// </summary>
            HeartbeatMode = 0,

            /// <summary>
            /// QRP mode
            /// </summary>
            QRPMode = 1,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 2
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ProtocolMode left, ProtocolMode right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ProtocolMode left, ProtocolMode right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="ProtocolMode"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="ProtocolMode"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(ProtocolMode obj) => obj.ToUInt32();

        /// <summary>
        /// Performs an explicit conversion from <see cref="uint"/> to <see cref="ProtocolMode"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ProtocolMode(uint value) => FromUInt32(value);

        /// <summary>
        /// Creates the <see cref="ProtocolMode"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="ProtocolMode"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="ProtocolMode"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static ProtocolMode FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="ProtocolMode"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="ProtocolMode"/> instance.</param>
        /// <returns>The <see cref="ProtocolMode"/> instance, represented by the uint value.</returns>
        public static ProtocolMode FromUInt32(uint value)
        {
            var ps = new ProtocolMode();

            const uint mask0 = 0x0003;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Value = (ProtocolModeValue)newValue0;

            return ps;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public ProtocolModeValue Value { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ProtocolMode other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="ProtocolMode"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="ProtocolMode"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="ProtocolMode"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ProtocolMode other) =>
            // If parameter is null return false (cast to object to prevent recursive loop!)
            Value == other.Value;

        /// <summary>
        /// Converts the instance of <see cref="ProtocolMode"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="ProtocolMode"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToUInt32());

        /// <summary>
        /// Converts the instance of <see cref="ProtocolMode"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="ProtocolMode"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)Value << 0;

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Value.GetHashCode();
            }

            return hash;
        }
    }
}
