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
    public struct ExhaustSmoke
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

        private byte opacity;
        private ExhaustSmoke.AttachedValue attached;
        private ExhaustSmoke.ChemicalValue chemical;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ExhaustSmoke left, ExhaustSmoke right)
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
        public static bool operator ==(ExhaustSmoke left, ExhaustSmoke right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator uint(ExhaustSmoke obj)
        {
            return obj.ToUInt32();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/>.
        /// </summary>
        /// <param name="value">The uint value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ExhaustSmoke(uint value)
        {
            return ExhaustSmoke.FromUInt32(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static ExhaustSmoke FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance from the uint value.
        /// </summary>
        /// <param name="value">The uint value which represents the <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance, represented by the uint value.</returns>
        public static ExhaustSmoke FromUInt32(uint value)
        {
            ExhaustSmoke ps = new ExhaustSmoke();

            uint mask0 = 0xff0000;
            byte shift0 = 16;
            uint newValue0 = value & mask0 >> shift0;
            ps.Opacity = (byte)newValue0;

            uint mask1 = 0x1000000;
            byte shift1 = 24;
            uint newValue1 = value & mask1 >> shift1;
            ps.Attached = (ExhaustSmoke.AttachedValue)newValue1;

            uint mask2 = 0x6000000;
            byte shift2 = 25;
            uint newValue2 = value & mask2 >> shift2;
            ps.Chemical = (ExhaustSmoke.ChemicalValue)newValue2;

            return ps;
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public byte Opacity
        {
            get { return this.opacity; }
            set { this.opacity = value; }
        }

        /// <summary>
        /// Gets or sets the attached.
        /// </summary>
        /// <value>The attached.</value>
        public ExhaustSmoke.AttachedValue Attached
        {
            get { return this.attached; }
            set { this.attached = value; }
        }

        /// <summary>
        /// Gets or sets the chemical.
        /// </summary>
        /// <value>The chemical.</value>
        public ExhaustSmoke.ChemicalValue Chemical
        {
            get { return this.chemical; }
            set { this.chemical = value; }
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

            if (!(obj is ExhaustSmoke))
            {
                return false;
            }

            return this.Equals((ExhaustSmoke)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ExhaustSmoke other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Opacity == other.Opacity &&
                this.Attached == other.Attached &&
                this.Chemical == other.Chemical;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt32());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> to the uint value.
        /// </summary>
        /// <returns>The uint value representing the current <see cref="OpenDis.Enumerations.Environment.ObjectState.ExhaustSmoke"/> instance.</returns>
        public uint ToUInt32()
        {
            uint val = 0;

            val |= (uint)((uint)this.Opacity << 16);
            val |= (uint)((uint)this.Attached << 24);
            val |= (uint)((uint)this.Chemical << 25);

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
                hash = (hash * 29) + this.Opacity.GetHashCode();
                hash = (hash * 29) + this.Attached.GetHashCode();
                hash = (hash * 29) + this.Chemical.GetHashCode();
            }

            return hash;
        }
    }
}
