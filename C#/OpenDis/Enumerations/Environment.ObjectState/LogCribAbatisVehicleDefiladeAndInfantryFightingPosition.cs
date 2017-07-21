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
    /// Enumeration values for LogCribAbatisVehicleDefiladeAndInfantryFightingPosition (env.obj.appear.point.breach, Log crib, Abatis, Vehicle defilade, and Infantry fighting position, 
    /// section 12.1.2.2.2)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct LogCribAbatisVehicleDefiladeAndInfantryFightingPosition
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

        private LogCribAbatisVehicleDefiladeAndInfantryFightingPosition.BreachValue breach;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition left, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition right)
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
        public static bool operator ==(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition left, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator LogCribAbatisVehicleDefiladeAndInfantryFightingPosition(uint value)
        {
            return LogCribAbatisVehicleDefiladeAndInfantryFightingPosition.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance, represented by the uint value.</returns>
        public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition FromUInt32(uint value)
        {
            LogCribAbatisVehicleDefiladeAndInfantryFightingPosition ps = new LogCribAbatisVehicleDefiladeAndInfantryFightingPosition();

            uint mask0 = 0x30000;
            byte shift0 = 16;
            uint newValue0 = value & mask0 >> shift0;
            ps.Breach = (LogCribAbatisVehicleDefiladeAndInfantryFightingPosition.BreachValue)newValue0;

            return ps;
        }

        /// <summary>
        /// Gets or sets the breach.
        /// </summary>
        /// <value>The breach.</value>
        public LogCribAbatisVehicleDefiladeAndInfantryFightingPosition.BreachValue Breach
        {
            get { return this.breach; }
            set { this.breach = value; }
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

            if (!(obj is LogCribAbatisVehicleDefiladeAndInfantryFightingPosition))
            {
                return false;
            }

            return this.Equals((LogCribAbatisVehicleDefiladeAndInfantryFightingPosition)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Breach == other.Breach;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.LogCribAbatisVehicleDefiladeAndInfantryFightingPosition"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Breach << 16);

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
            }

            return hash;
        }
    }
}
