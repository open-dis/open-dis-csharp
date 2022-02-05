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
    /// Enumeration values for PaintScheme (entity.mine.paintscheme, Paint Scheme,
    /// section 10.2.5)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct PaintScheme : IHashable<PaintScheme>
    {
        /// <summary>
        /// Identifies the algae build-up on the mine
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Identifies the algae build-up on the mine")]
        public enum AlgaeValue : uint
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// Light
            /// </summary>
            Light = 1,

            /// <summary>
            /// Moderate
            /// </summary>
            Moderate = 2,

            /// <summary>
            /// Heavy
            /// </summary>
            Heavy = 3
        }

        /// <summary>
        /// Identifies the paint scheme of the mine
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Identifies the paint scheme of the mine")]
        public enum PaintSchemeValue : uint
        {
            /// <summary>
            /// Other
            /// </summary>
            Other = 0,

            /// <summary>
            /// Standard
            /// </summary>
            Standard = 1,

            /// <summary>
            /// Camouflage Desert
            /// </summary>
            CamouflageDesert = 2,

            /// <summary>
            /// Camouflage Jungle
            /// </summary>
            CamouflageJungle = 3,

            /// <summary>
            /// Camouflage Snow
            /// </summary>
            CamouflageSnow = 4,

            /// <summary>
            /// Camouflage Gravel
            /// </summary>
            CamouflageGravel = 5,

            /// <summary>
            /// Camouflage Pavement
            /// </summary>
            CamouflagePavement = 6,

            /// <summary>
            /// Camouflage Sand
            /// </summary>
            CamouflageSand = 7,

            /// <summary>
            /// Natural Wood
            /// </summary>
            NaturalWood = 8,

            /// <summary>
            /// Clear
            /// </summary>
            Clear = 9,

            /// <summary>
            /// Red
            /// </summary>
            Red = 10,

            /// <summary>
            /// Blue
            /// </summary>
            Blue = 11,

            /// <summary>
            /// Green
            /// </summary>
            Green = 12,

            /// <summary>
            /// Olive
            /// </summary>
            Olive = 13,

            /// <summary>
            /// White
            /// </summary>
            White = 14,

            /// <summary>
            /// Tan
            /// </summary>
            Tan = 15,

            /// <summary>
            /// Black
            /// </summary>
            Black = 16,

            /// <summary>
            /// Yellow
            /// </summary>
            Yellow = 17,

            /// <summary>
            /// Brown
            /// </summary>
            Brown = 18
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(PaintScheme left, PaintScheme right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(PaintScheme left, PaintScheme right)
            => ReferenceEquals(left, right) || left.Equals(right);

        /// <summary>
        /// Performs an explicit conversion from <see cref="PaintScheme"/> to <see cref="byte"/>.
        /// </summary>
        /// <param name="obj">The <see cref="PaintScheme"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator byte(PaintScheme obj) => obj.ToByte();

        /// <summary>
        /// Performs an explicit conversion from <see cref="byte"/> to <see cref="PaintScheme"/>.
        /// </summary>
        /// <param name="value">The byte value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator PaintScheme(byte value) => FromByte(value);

        /// <summary>
        /// Creates the <see cref="PaintScheme"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="PaintScheme"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="PaintScheme"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number
        /// of elements in array.</exception>
        public static PaintScheme FromByteArray(byte[] array, int index)
        {
            return array == null
                ? throw new ArgumentNullException(nameof(array))
                : index < 0 ||
                index > array.Length - 1 ||
                index + 1 > array.Length - 1
                ? throw new IndexOutOfRangeException()
                : FromByte(array[index]);
        }

        /// <summary>
        /// Creates the <see cref="PaintScheme"/> instance from the byte value.
        /// </summary>
        /// <param name="value">The byte value which represents the <see cref="PaintScheme"/> instance.</param>
        /// <returns>The <see cref="PaintScheme"/> instance, represented by the byte value.</returns>
        public static PaintScheme FromByte(byte value)
        {
            var ps = new PaintScheme();

            const uint mask0 = 0x0003;
            const byte shift0 = 0;
            uint newValue0 = (value & mask0) >> shift0;
            ps.Algae = (AlgaeValue)newValue0;

            const uint mask1 = 0x00fc;
            const byte shift1 = 2;
            uint newValue1 = (value & mask1) >> shift1;
            ps.Value = (PaintSchemeValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the algae.
        /// </summary>
        /// <value>The algae.</value>
        public AlgaeValue Algae { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public PaintSchemeValue Value { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is PaintScheme other && Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="PaintScheme"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="PaintScheme"/> instance to compare with this instance.</param>
        /// <returns>
        ///    <c>true</c> if the specified <see cref="PaintScheme"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(PaintScheme other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            return Algae == other.Algae &&
                Value == other.Value;
        }

        /// <summary>
        /// Converts the instance of <see cref="PaintScheme"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="PaintScheme"/> instance.</returns>
        public byte[] ToByteArray() => BitConverter.GetBytes(ToByte());

        /// <summary>
        /// Converts the instance of <see cref="PaintScheme"/> to the byte value.
        /// </summary>
        /// <returns>The byte value representing the current <see cref="PaintScheme"/> instance.</returns>
        public byte ToByte()
        {
            byte val = 0;

            val |= (byte)((uint)Algae << 0);
            val |= (byte)((uint)Value << 2);

            return val;
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 17;

            // Overflow is fine, just wrap
            unchecked
            {
                hash = (hash * 29) + Algae.GetHashCode();
                hash = (hash * 29) + Value.GetHashCode();
            }

            return hash;
        }
    }
}
