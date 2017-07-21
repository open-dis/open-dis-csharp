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
    public struct PaintScheme
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

        private PaintScheme.AlgaeValue algae;
        private PaintScheme.PaintSchemeValue paintScheme;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(PaintScheme left, PaintScheme right)
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
        public static bool operator ==(PaintScheme left, PaintScheme right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> to <see cref="System.Byte"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator byte(PaintScheme obj)
        {
            return obj.ToByte();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Byte"/> to <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/>.
        /// </summary>
        /// <param name="value">The byte value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator PaintScheme(byte value)
        {
            return PaintScheme.FromByte(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static PaintScheme FromByteArray(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 ||
                index > array.Length - 1 ||
                index + 1 > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return FromByte(array[index]);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance from the byte value.
        /// </summary>
        /// <param name="value">The byte value which represents the <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance, represented by the byte value.</returns>
        public static PaintScheme FromByte(byte value)
        {
            PaintScheme ps = new PaintScheme();

            uint mask0 = 0x0003;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.Algae = (PaintScheme.AlgaeValue)newValue0;

            uint mask1 = 0x00fc;
            byte shift1 = 2;
            uint newValue1 = value & mask1 >> shift1;
            ps.Value = (PaintScheme.PaintSchemeValue)newValue1;

            return ps;
        }

        /// <summary>
        /// Gets or sets the algae.
        /// </summary>
        /// <value>The algae.</value>
        public PaintScheme.AlgaeValue Algae
        {
            get { return this.algae; }
            set { this.algae = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public PaintScheme.PaintSchemeValue Value
        {
            get { return this.paintScheme; }
            set { this.paintScheme = value; }
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

            if (!(obj is PaintScheme))
            {
                return false;
            }

            return this.Equals((PaintScheme)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(PaintScheme other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Algae == other.Algae &&
                this.Value == other.Value;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToByte());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> to the byte value.
        /// </summary>
        /// <returns>The byte value representing the current <see cref="OpenDis.Enumerations.Entity.Information.Minefield.PaintScheme"/> instance.</returns>
        public byte ToByte()
        {
            byte val = 0;

            val |= (byte)((uint)this.Algae << 0);
            val |= (byte)((uint)this.Value << 2);

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
                hash = (hash * 29) + this.Algae.GetHashCode();
                hash = (hash * 29) + this.Value.GetHashCode();
            }

            return hash;
        }
    }
}
