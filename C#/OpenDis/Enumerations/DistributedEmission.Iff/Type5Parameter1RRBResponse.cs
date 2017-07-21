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

namespace OpenDis.Enumerations.DistributedEmission.Iff
{
    /// <summary>
    /// Enumeration values for Type5Parameter1RRBResponse (der.iff.type.5.fop.param1, Parameter 1 - RRB Response, 
    /// section 8.3.5.2.2)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public struct Type5Parameter1RRBResponse
    {
        /// <summary>
        /// Power Reduction
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Power Reduction")]
        public enum PowerReductionValue : uint
        {
            /// <summary>
            /// Off
            /// </summary>
            Off = 0,

            /// <summary>
            /// On
            /// </summary>
            On = 1
        }

        /// <summary>
        /// Radar Enhancement
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Radar Enhancement")]
        public enum RadarEnhancementValue : uint
        {
            /// <summary>
            /// Off
            /// </summary>
            Off = 0,

            /// <summary>
            /// On
            /// </summary>
            On = 1
        }

        /// <summary>
        /// Status
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Status")]
        public enum StatusValue : uint
        {
            /// <summary>
            /// Off
            /// </summary>
            Off = 0,

            /// <summary>
            /// On
            /// </summary>
            On = 1
        }

        /// <summary>
        /// Damage
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Damage")]
        public enum DamageValue : uint
        {
            /// <summary>
            /// No damage
            /// </summary>
            NoDamage = 0,

            /// <summary>
            /// Damage
            /// </summary>
            Damage = 1
        }

        /// <summary>
        /// Malfunction
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Malfunction")]
        public enum MalfunctionValue : uint
        {
            /// <summary>
            /// No malfunction
            /// </summary>
            NoMalfunction = 0,

            /// <summary>
            /// Malfunction
            /// </summary>
            Malfunction = 1
        }

        private byte code;
        private Type5Parameter1RRBResponse.PowerReductionValue powerReduction;
        private Type5Parameter1RRBResponse.RadarEnhancementValue radarEnhancement;
        private Type5Parameter1RRBResponse.StatusValue status;
        private Type5Parameter1RRBResponse.DamageValue damage;
        private Type5Parameter1RRBResponse.MalfunctionValue malfunction;

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Type5Parameter1RRBResponse left, Type5Parameter1RRBResponse right)
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
        public static bool operator ==(Type5Parameter1RRBResponse left, Type5Parameter1RRBResponse right)
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
        /// Performs an explicit conversion from <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> to <see cref="System.UInt16"/>.
        /// </summary>
        /// <param name="obj">The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> scheme instance.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ushort(Type5Parameter1RRBResponse obj)
        {
            return obj.ToUInt16();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/>.
        /// </summary>
        /// <param name="value">The ushort value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Type5Parameter1RRBResponse(ushort value)
        {
            return Type5Parameter1RRBResponse.FromUInt16(value);
        }

        /// <summary>
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance from the byte array.
        /// </summary>
        /// <param name="array">The array which holds the values for the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/>.</param>
        /// <param name="index">The starting position within value.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance, represented by a byte array.</returns>
        /// <exception cref="ArgumentNullException">if the <c>array</c> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">if the <c>index</c> is lower than 0 or greater or equal than number of elements in array.</exception>
        public static Type5Parameter1RRBResponse FromByteArray(byte[] array, int index)
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
        /// Creates the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance from the ushort value.
        /// </summary>
        /// <param name="value">The ushort value which represents the <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance.</param>
        /// <returns>The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance, represented by the ushort value.</returns>
        public static Type5Parameter1RRBResponse FromUInt16(ushort value)
        {
            Type5Parameter1RRBResponse ps = new Type5Parameter1RRBResponse();

            uint mask0 = 0x001f;
            byte shift0 = 0;
            uint newValue0 = value & mask0 >> shift0;
            ps.Code = (byte)newValue0;

            uint mask2 = 0x0800;
            byte shift2 = 11;
            uint newValue2 = value & mask2 >> shift2;
            ps.PowerReduction = (Type5Parameter1RRBResponse.PowerReductionValue)newValue2;

            uint mask3 = 0x1000;
            byte shift3 = 12;
            uint newValue3 = value & mask3 >> shift3;
            ps.RadarEnhancement = (Type5Parameter1RRBResponse.RadarEnhancementValue)newValue3;

            uint mask4 = 0x2000;
            byte shift4 = 13;
            uint newValue4 = value & mask4 >> shift4;
            ps.Status = (Type5Parameter1RRBResponse.StatusValue)newValue4;

            uint mask5 = 0x4000;
            byte shift5 = 14;
            uint newValue5 = value & mask5 >> shift5;
            ps.Damage = (Type5Parameter1RRBResponse.DamageValue)newValue5;

            uint mask6 = 0x8000;
            byte shift6 = 15;
            uint newValue6 = value & mask6 >> shift6;
            ps.Malfunction = (Type5Parameter1RRBResponse.MalfunctionValue)newValue6;

            return ps;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public byte Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        /// <summary>
        /// Gets or sets the powerreduction.
        /// </summary>
        /// <value>The powerreduction.</value>
        public Type5Parameter1RRBResponse.PowerReductionValue PowerReduction
        {
            get { return this.powerReduction; }
            set { this.powerReduction = value; }
        }

        /// <summary>
        /// Gets or sets the radarenhancement.
        /// </summary>
        /// <value>The radarenhancement.</value>
        public Type5Parameter1RRBResponse.RadarEnhancementValue RadarEnhancement
        {
            get { return this.radarEnhancement; }
            set { this.radarEnhancement = value; }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public Type5Parameter1RRBResponse.StatusValue Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public Type5Parameter1RRBResponse.DamageValue Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        /// <summary>
        /// Gets or sets the malfunction.
        /// </summary>
        /// <value>The malfunction.</value>
        public Type5Parameter1RRBResponse.MalfunctionValue Malfunction
        {
            get { return this.malfunction; }
            set { this.malfunction = value; }
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

            if (!(obj is Type5Parameter1RRBResponse))
            {
                return false;
            }

            return this.Equals((Type5Parameter1RRBResponse)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Type5Parameter1RRBResponse other)
        {
            // If parameter is null return false (cast to object to prevent recursive loop!)
            if ((object)other == null)
            {
                return false;
            }

            return
                this.Code == other.Code &&
                this.PowerReduction == other.PowerReduction &&
                this.RadarEnhancement == other.RadarEnhancement &&
                this.Status == other.Status &&
                this.Damage == other.Damage &&
                this.Malfunction == other.Malfunction;
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> to the byte array.
        /// </summary>
        /// <returns>The byte array representing the current <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance.</returns>
        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(this.ToUInt16());
        }

        /// <summary>
        /// Converts the instance of <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> to the ushort value.
        /// </summary>
        /// <returns>The ushort value representing the current <see cref="OpenDis.Enumerations.DistributedEmission.Iff.Type5Parameter1RRBResponse"/> instance.</returns>
        public ushort ToUInt16()
        {
            ushort val = 0;

            val |= (ushort)((uint)this.Code << 0);
            val |= (ushort)((uint)this.PowerReduction << 11);
            val |= (ushort)((uint)this.RadarEnhancement << 12);
            val |= (ushort)((uint)this.Status << 13);
            val |= (ushort)((uint)this.Damage << 14);
            val |= (ushort)((uint)this.Malfunction << 15);

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
                hash = (hash * 29) + this.Code.GetHashCode();
                hash = (hash * 29) + this.PowerReduction.GetHashCode();
                hash = (hash * 29) + this.RadarEnhancement.GetHashCode();
                hash = (hash * 29) + this.Status.GetHashCode();
                hash = (hash * 29) + this.Damage.GetHashCode();
                hash = (hash * 29) + this.Malfunction.GetHashCode();
            }

            return hash;
        }
    }
}
