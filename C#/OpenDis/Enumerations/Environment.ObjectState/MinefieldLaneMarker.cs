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
    /// Enumeration values for MinefieldLaneMarker (env.obj.appear.linear.marker, Minefield Lane Marker, 
    /// section 12.1.2.3.3)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct MinefieldLaneMarker
    {
        /// <summary>
        /// Describes the side of the lane marker which is visible.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Describes the side of the lane marker which is visible.")]
        public enum VisibleSideValue : uint
        {
            /// <summary>
            /// Left side is visible
            /// </summary>
            LeftSideIsVisible = 0,

            /// <summary>
            /// Right side is visible
            /// </summary>
            RightSideIsVisible = 1,

            /// <summary>
            /// Both sides are visible
            /// </summary>
            BothSidesAreVisible = 2,

            /// <summary>
            /// null
            /// </summary>
            Unknown = 3
        }

        private MinefieldLaneMarker.VisibleSideValue visibleSide;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldLaneMarker left, MinefieldLaneMarker right)
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
        public static bool operator ==(MinefieldLaneMarker left, MinefieldLaneMarker right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(MinefieldLaneMarker obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator MinefieldLaneMarker(uint value)
        {
            return MinefieldLaneMarker.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static MinefieldLaneMarker FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance, represented by the uint value.</returns>
        public static MinefieldLaneMarker FromUInt32(uint value)
        {
            MinefieldLaneMarker ps = new MinefieldLaneMarker();

            uint mask0 = 0x30000;
            byte shift0 = 16;
            uint newValue0 = value & mask0 >> shift0;
            ps.VisibleSide = (MinefieldLaneMarker.VisibleSideValue)newValue0;

            return ps;
        }

        /// <summary>
        /// Gets or sets the visibleside.
        /// </summary>
        /// <value>The visibleside.</value>
        public MinefieldLaneMarker.VisibleSideValue VisibleSide
        {
            get { return this.visibleSide; }
            set { this.visibleSide = value; }
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

            if (!(obj is MinefieldLaneMarker))
            {
                return false;
            }

            return this.Equals((MinefieldLaneMarker)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MinefieldLaneMarker other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.VisibleSide == other.VisibleSide;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.MinefieldLaneMarker"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.VisibleSide << 16);

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
                hash = (hash * 29) + this.VisibleSide.GetHashCode();
            }

            return hash;
        }
    }
}
