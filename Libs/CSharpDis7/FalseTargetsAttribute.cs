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
    /// The False Targets attribute record shall be used to communicate discrete values that are associated with false targets jamming that cannot be referenced to an emitter mode. The values provided in the False Targets attri- bute record shall be considered valid only for the victim radar beams listed in the jamming beam's Track/Jam Data records (provided in the associated Electromagnetic Emission PDU). Section 6.2.12.3
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class FalseTargetsAttribute
    {
        private uint _recordType = 3502;

        private ushort _recordLength = 40;

        private ushort _padding;

        private byte _emitterNumber;

        private byte _beamNumber;

        private byte _stateIndicator;

        private byte _padding2;

        private float _falseTargetCount;

        private float _walkSpeed;

        private float _walkAcceleration;

        private float _maximumWalkDistance;

        private float _keepTime;

        private float _echoSpacing;

        private uint _padding3;

        /// <summary>
        /// Initializes a new instance of the <see cref="FalseTargetsAttribute"/> class.
        /// </summary>
        public FalseTargetsAttribute()
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
        public static bool operator !=(FalseTargetsAttribute left, FalseTargetsAttribute right)
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
        public static bool operator ==(FalseTargetsAttribute left, FalseTargetsAttribute right)
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
            marshalSize += 1;  // this._padding2
            marshalSize += 4;  // this._falseTargetCount
            marshalSize += 4;  // this._walkSpeed
            marshalSize += 4;  // this._walkAcceleration
            marshalSize += 4;  // this._maximumWalkDistance
            marshalSize += 4;  // this._keepTime
            marshalSize += 4;  // this._echoSpacing
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

        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2
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

        [XmlElement(Type = typeof(float), ElementName = "falseTargetCount")]
        public float FalseTargetCount
        {
            get
            {
                return this._falseTargetCount;
            }

            set
            {
                this._falseTargetCount = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "walkSpeed")]
        public float WalkSpeed
        {
            get
            {
                return this._walkSpeed;
            }

            set
            {
                this._walkSpeed = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "walkAcceleration")]
        public float WalkAcceleration
        {
            get
            {
                return this._walkAcceleration;
            }

            set
            {
                this._walkAcceleration = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "maximumWalkDistance")]
        public float MaximumWalkDistance
        {
            get
            {
                return this._maximumWalkDistance;
            }

            set
            {
                this._maximumWalkDistance = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "keepTime")]
        public float KeepTime
        {
            get
            {
                return this._keepTime;
            }

            set
            {
                this._keepTime = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "echoSpacing")]
        public float EchoSpacing
        {
            get
            {
                return this._echoSpacing;
            }

            set
            {
                this._echoSpacing = value;
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
                    dos.WriteUnsignedByte((byte)this._padding2);
                    dos.WriteFloat((float)this._falseTargetCount);
                    dos.WriteFloat((float)this._walkSpeed);
                    dos.WriteFloat((float)this._walkAcceleration);
                    dos.WriteFloat((float)this._maximumWalkDistance);
                    dos.WriteFloat((float)this._keepTime);
                    dos.WriteFloat((float)this._echoSpacing);
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
                    this._padding2 = dis.ReadUnsignedByte();
                    this._falseTargetCount = dis.ReadFloat();
                    this._walkSpeed = dis.ReadFloat();
                    this._walkAcceleration = dis.ReadFloat();
                    this._maximumWalkDistance = dis.ReadFloat();
                    this._keepTime = dis.ReadFloat();
                    this._echoSpacing = dis.ReadFloat();
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
            sb.AppendLine("<FalseTargetsAttribute>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<emitterNumber type=\"byte\">" + this._emitterNumber.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
                sb.AppendLine("<beamNumber type=\"byte\">" + this._beamNumber.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
                sb.AppendLine("<stateIndicator type=\"byte\">" + this._stateIndicator.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
                sb.AppendLine("<padding2 type=\"byte\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<falseTargetCount type=\"float\">" + this._falseTargetCount.ToString(CultureInfo.InvariantCulture) + "</falseTargetCount>");
                sb.AppendLine("<walkSpeed type=\"float\">" + this._walkSpeed.ToString(CultureInfo.InvariantCulture) + "</walkSpeed>");
                sb.AppendLine("<walkAcceleration type=\"float\">" + this._walkAcceleration.ToString(CultureInfo.InvariantCulture) + "</walkAcceleration>");
                sb.AppendLine("<maximumWalkDistance type=\"float\">" + this._maximumWalkDistance.ToString(CultureInfo.InvariantCulture) + "</maximumWalkDistance>");
                sb.AppendLine("<keepTime type=\"float\">" + this._keepTime.ToString(CultureInfo.InvariantCulture) + "</keepTime>");
                sb.AppendLine("<echoSpacing type=\"float\">" + this._echoSpacing.ToString(CultureInfo.InvariantCulture) + "</echoSpacing>");
                sb.AppendLine("<padding3 type=\"uint\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                sb.AppendLine("</FalseTargetsAttribute>");
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
            return this == obj as FalseTargetsAttribute;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(FalseTargetsAttribute obj)
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

            if (this._falseTargetCount != obj._falseTargetCount)
            {
                ivarsEqual = false;
            }

            if (this._walkSpeed != obj._walkSpeed)
            {
                ivarsEqual = false;
            }

            if (this._walkAcceleration != obj._walkAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._maximumWalkDistance != obj._maximumWalkDistance)
            {
                ivarsEqual = false;
            }

            if (this._keepTime != obj._keepTime)
            {
                ivarsEqual = false;
            }

            if (this._echoSpacing != obj._echoSpacing)
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
            result = GenerateHash(result) ^ this._falseTargetCount.GetHashCode();
            result = GenerateHash(result) ^ this._walkSpeed.GetHashCode();
            result = GenerateHash(result) ^ this._walkAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._maximumWalkDistance.GetHashCode();
            result = GenerateHash(result) ^ this._keepTime.GetHashCode();
            result = GenerateHash(result) ^ this._echoSpacing.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();

            return result;
        }
    }
}
