// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author: DMcG
// Modified for use with C#:
//  - Peter Smith (Naval Air Warfare Center - Training Systems Division)
//  - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// The Angle Deception attribute record may be used to communicate discrete values that are associated with angle deception jamming that cannot be referenced to an emitter mode. The values provided in the record records (provided in the associated Electromagnetic Emission PDU). (The victim radar beams are those that are targeted by the jammer.) Section 6.2.12.2
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AngleDeception
    {
        private uint _recordType = 3501;

        private ushort _recordLength = 48;

        private ushort _padding;

        private byte _emitterNumber;

        private byte _beamNumber;

        private byte _stateIndicator;

        private uint _padding2;

        private float _azimuthOffset;

        private float _azimuthWidth;

        private float _azimuthPullRate;

        private float _azimuthPullAcceleration;

        private float _elevationOffset;

        private float _elevationWidth;

        private float _elevationPullRate;

        private float _elevationPullAcceleration;

        private uint _padding3;

        /// <summary>
        /// Initializes a new instance of the <see cref="AngleDeception"/> class.
        /// </summary>
        public AngleDeception()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AngleDeception left, AngleDeception right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AngleDeception left, AngleDeception right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize += 4;  // this._recordType
            marshalSize += 2;  // this._recordLength
            marshalSize += 2;  // this._padding
            marshalSize += 1;  // this._emitterNumber
            marshalSize += 1;  // this._beamNumber
            marshalSize += 1;  // this._stateIndicator
            marshalSize += 4;  // this._padding2
            marshalSize += 4;  // this._azimuthOffset
            marshalSize += 4;  // this._azimuthWidth
            marshalSize += 4;  // this._azimuthPullRate
            marshalSize += 4;  // this._azimuthPullAcceleration
            marshalSize += 4;  // this._elevationOffset
            marshalSize += 4;  // this._elevationWidth
            marshalSize += 4;  // this._elevationPullRate
            marshalSize += 4;  // this._elevationPullAcceleration
            marshalSize += 4;  // this._padding3
            return marshalSize;
        }

        [XmlElement(Type = typeof(uint), ElementName = "recordType")]
        public uint RecordType
        {
            get
            {
                return this._recordType;
            }

            set
            {
                this._recordType = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
        public ushort RecordLength
        {
            get
            {
                return this._recordLength;
            }

            set
            {
                this._recordLength = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "padding")]
        public ushort Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "emitterNumber")]
        public byte EmitterNumber
        {
            get
            {
                return this._emitterNumber;
            }

            set
            {
                this._emitterNumber = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "beamNumber")]
        public byte BeamNumber
        {
            get
            {
                return this._beamNumber;
            }

            set
            {
                this._beamNumber = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "stateIndicator")]
        public byte StateIndicator
        {
            get
            {
                return this._stateIndicator;
            }

            set
            {
                this._stateIndicator = value;
            }
        }

        [XmlElement(Type = typeof(uint), ElementName = "padding2")]
        public uint Padding2
        {
            get
            {
                return this._padding2;
            }

            set
            {
                this._padding2 = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "azimuthOffset")]
        public float AzimuthOffset
        {
            get
            {
                return this._azimuthOffset;
            }

            set
            {
                this._azimuthOffset = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "azimuthWidth")]
        public float AzimuthWidth
        {
            get
            {
                return this._azimuthWidth;
            }

            set
            {
                this._azimuthWidth = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "azimuthPullRate")]
        public float AzimuthPullRate
        {
            get
            {
                return this._azimuthPullRate;
            }

            set
            {
                this._azimuthPullRate = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "azimuthPullAcceleration")]
        public float AzimuthPullAcceleration
        {
            get
            {
                return this._azimuthPullAcceleration;
            }

            set
            {
                this._azimuthPullAcceleration = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "elevationOffset")]
        public float ElevationOffset
        {
            get
            {
                return this._elevationOffset;
            }

            set
            {
                this._elevationOffset = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "elevationWidth")]
        public float ElevationWidth
        {
            get
            {
                return this._elevationWidth;
            }

            set
            {
                this._elevationWidth = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "elevationPullRate")]
        public float ElevationPullRate
        {
            get
            {
                return this._elevationPullRate;
            }

            set
            {
                this._elevationPullRate = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "elevationPullAcceleration")]
        public float ElevationPullAcceleration
        {
            get
            {
                return this._elevationPullAcceleration;
            }

            set
            {
                this._elevationPullAcceleration = value;
            }
        }

        [XmlElement(Type = typeof(uint), ElementName = "padding3")]
        public uint Padding3
        {
            get
            {
                return this._padding3;
            }

            set
            {
                this._padding3 = value;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt((uint)this._recordType);
                    dos.WriteUnsignedShort((ushort)this._recordLength);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    dos.WriteUnsignedByte((byte)this._emitterNumber);
                    dos.WriteUnsignedByte((byte)this._beamNumber);
                    dos.WriteUnsignedByte((byte)this._stateIndicator);
                    dos.WriteUnsignedInt((uint)this._padding2);
                    dos.WriteFloat((float)this._azimuthOffset);
                    dos.WriteFloat((float)this._azimuthWidth);
                    dos.WriteFloat((float)this._azimuthPullRate);
                    dos.WriteFloat((float)this._azimuthPullAcceleration);
                    dos.WriteFloat((float)this._elevationOffset);
                    dos.WriteFloat((float)this._elevationWidth);
                    dos.WriteFloat((float)this._elevationPullRate);
                    dos.WriteFloat((float)this._elevationPullAcceleration);
                    dos.WriteUnsignedInt((uint)this._padding3);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    this._recordType = dis.ReadUnsignedInt();
                    this._recordLength = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
                    this._emitterNumber = dis.ReadUnsignedByte();
                    this._beamNumber = dis.ReadUnsignedByte();
                    this._stateIndicator = dis.ReadUnsignedByte();
                    this._padding2 = dis.ReadUnsignedInt();
                    this._azimuthOffset = dis.ReadFloat();
                    this._azimuthWidth = dis.ReadFloat();
                    this._azimuthPullRate = dis.ReadFloat();
                    this._azimuthPullAcceleration = dis.ReadFloat();
                    this._elevationOffset = dis.ReadFloat();
                    this._elevationWidth = dis.ReadFloat();
                    this._elevationPullRate = dis.ReadFloat();
                    this._elevationPullAcceleration = dis.ReadFloat();
                    this._padding3 = dis.ReadUnsignedInt();
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
                }
            }
        }

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<AngleDeception>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<emitterNumber type=\"byte\">" + this._emitterNumber.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
                sb.AppendLine("<beamNumber type=\"byte\">" + this._beamNumber.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
                sb.AppendLine("<stateIndicator type=\"byte\">" + this._stateIndicator.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
                sb.AppendLine("<padding2 type=\"uint\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<azimuthOffset type=\"float\">" + this._azimuthOffset.ToString(CultureInfo.InvariantCulture) + "</azimuthOffset>");
                sb.AppendLine("<azimuthWidth type=\"float\">" + this._azimuthWidth.ToString(CultureInfo.InvariantCulture) + "</azimuthWidth>");
                sb.AppendLine("<azimuthPullRate type=\"float\">" + this._azimuthPullRate.ToString(CultureInfo.InvariantCulture) + "</azimuthPullRate>");
                sb.AppendLine("<azimuthPullAcceleration type=\"float\">" + this._azimuthPullAcceleration.ToString(CultureInfo.InvariantCulture) + "</azimuthPullAcceleration>");
                sb.AppendLine("<elevationOffset type=\"float\">" + this._elevationOffset.ToString(CultureInfo.InvariantCulture) + "</elevationOffset>");
                sb.AppendLine("<elevationWidth type=\"float\">" + this._elevationWidth.ToString(CultureInfo.InvariantCulture) + "</elevationWidth>");
                sb.AppendLine("<elevationPullRate type=\"float\">" + this._elevationPullRate.ToString(CultureInfo.InvariantCulture) + "</elevationPullRate>");
                sb.AppendLine("<elevationPullAcceleration type=\"float\">" + this._elevationPullAcceleration.ToString(CultureInfo.InvariantCulture) + "</elevationPullAcceleration>");
                sb.AppendLine("<padding3 type=\"uint\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                sb.AppendLine("</AngleDeception>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
            }
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
            return this == obj as AngleDeception;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AngleDeception obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._recordType != obj._recordType)
            {
                ivarsEqual = false;
            }

            if (this._recordLength != obj._recordLength)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (this._emitterNumber != obj._emitterNumber)
            {
                ivarsEqual = false;
            }

            if (this._beamNumber != obj._beamNumber)
            {
                ivarsEqual = false;
            }

            if (this._stateIndicator != obj._stateIndicator)
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (this._azimuthOffset != obj._azimuthOffset)
            {
                ivarsEqual = false;
            }

            if (this._azimuthWidth != obj._azimuthWidth)
            {
                ivarsEqual = false;
            }

            if (this._azimuthPullRate != obj._azimuthPullRate)
            {
                ivarsEqual = false;
            }

            if (this._azimuthPullAcceleration != obj._azimuthPullAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._elevationOffset != obj._elevationOffset)
            {
                ivarsEqual = false;
            }

            if (this._elevationWidth != obj._elevationWidth)
            {
                ivarsEqual = false;
            }

            if (this._elevationPullRate != obj._elevationPullRate)
            {
                ivarsEqual = false;
            }

            if (this._elevationPullAcceleration != obj._elevationPullAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._padding3 != obj._padding3)
            {
                ivarsEqual = false;
            }

            return ivarsEqual;
        }

        /// <summary>
        /// HashCode Helper
        /// </summary>
        /// <param name="hash">The hash value.</param>
        /// <returns>The new hash value.</returns>
        private static int GenerateHash(int hash)
        {
            hash = hash << (5 + hash);
            return hash;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ this._recordType.GetHashCode();
            result = GenerateHash(result) ^ this._recordLength.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._emitterNumber.GetHashCode();
            result = GenerateHash(result) ^ this._beamNumber.GetHashCode();
            result = GenerateHash(result) ^ this._stateIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthOffset.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthWidth.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthPullRate.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthPullAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._elevationOffset.GetHashCode();
            result = GenerateHash(result) ^ this._elevationWidth.GetHashCode();
            result = GenerateHash(result) ^ this._elevationPullRate.GetHashCode();
            result = GenerateHash(result) ^ this._elevationPullAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();

            return result;
        }
    }
}
