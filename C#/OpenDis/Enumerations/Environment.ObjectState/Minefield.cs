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
    public struct Minefield
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

        private Minefield.BreachValue breach;
        private int mineCount;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Minefield left, Minefield right)
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
        public static bool operator ==(Minefield left, Minefield right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(Minefield obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Minefield(uint value)
        {
            return Minefield.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static Minefield FromByteArray(byte[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 ||
                index > array.Length - 1 ||
                index + 4 > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return FromUInt32(BitConverter.ToUInt32(array, index));
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance, represented by the uint value.</returns>
        public static Minefield FromUInt32(uint value)
        {
            Minefield ps = new Minefield();

            uint mask0 = 0x30000;
            byte shift0 = 16;
            uint newValue0 = value & mask0 >> shift0;
            ps.Breach = (Minefield.BreachValue)newValue0;

            uint mask2 = 0x80000000;
            byte shift2 = 31;
            uint newValue2 = value & mask2 >> shift2;
            ps.MineCount = (int)newValue2;

            return ps;
        }

        /// <summary>
        /// Gets or sets the breach.
        /// </summary>
        /// <value>The breach.</value>
        public Minefield.BreachValue Breach
        {
            get { return this.breach; }
            set { this.breach = value; }
        }

        /// <summary>
        /// Gets or sets the minecount.
        /// </summary>
        /// <value>The minecount.</value>
        public int MineCount
        {
            get { return this.mineCount; }
            set { this.mineCount = value; }
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

            if (!(obj is Minefield))
            {
                return false;
            }

            return this.Equals((Minefield)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Minefield other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Breach == other.Breach &&
                this.MineCount == other.MineCount;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.Minefield"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Breach << 16);
            val |= (uint)((uint)this.MineCount << 31);

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
                hash = (hash * 29) + this.Breach.GetHashCode();
                hash = (hash * 29) + this.MineCount.GetHashCode();
            }

            return hash;
        }
    }
}
