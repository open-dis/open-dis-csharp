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
    /// The Blanking Sector attribute record may be used to convey persistent areas within a scan volume where emitter power for a specific active emitter beam is reduced to an insignificant value. Section 6.2.12
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class BlankingSector
    {
        private uint _recordType = 3500;

        private ushort _recordLength;

        private byte _emitterNumber;

        private byte _beamNumber;

        private byte _stateIndicator;

        private float _leftAzimuth;

        private float _rightAzimuth;

        private float _lowerElevation;

        private float _upperElevation;

        private float _residualPower;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlankingSector"/> class.
        /// </summary>
        public BlankingSector()
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
        public static bool operator !=(BlankingSector left, BlankingSector right)
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
        public static bool operator ==(BlankingSector left, BlankingSector right)
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
            marshalSize += 1;  // this._emitterNumber
            marshalSize += 1;  // this._beamNumber
            marshalSize += 1;  // this._stateIndicator
            marshalSize += 4;  // this._leftAzimuth
            marshalSize += 4;  // this._rightAzimuth
            marshalSize += 4;  // this._lowerElevation
            marshalSize += 4;  // this._upperElevation
            marshalSize += 4;  // this._residualPower
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

        [XmlElement(Type = typeof(float), ElementName = "leftAzimuth")]
        public float LeftAzimuth
        {
            get
            {
                return this._leftAzimuth;
            }

            set
            {
                this._leftAzimuth = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "rightAzimuth")]
        public float RightAzimuth
        {
            get
            {
                return this._rightAzimuth;
            }

            set
            {
                this._rightAzimuth = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "lowerElevation")]
        public float LowerElevation
        {
            get
            {
                return this._lowerElevation;
            }

            set
            {
                this._lowerElevation = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "upperElevation")]
        public float UpperElevation
        {
            get
            {
                return this._upperElevation;
            }

            set
            {
                this._upperElevation = value;
            }
        }

        [XmlElement(Type = typeof(float), ElementName = "residualPower")]
        public float ResidualPower
        {
            get
            {
                return this._residualPower;
            }

            set
            {
                this._residualPower = value;
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
                    dos.WriteUnsignedByte((byte)this._emitterNumber);
                    dos.WriteUnsignedByte((byte)this._beamNumber);
                    dos.WriteUnsignedByte((byte)this._stateIndicator);
                    dos.WriteFloat((float)this._leftAzimuth);
                    dos.WriteFloat((float)this._rightAzimuth);
                    dos.WriteFloat((float)this._lowerElevation);
                    dos.WriteFloat((float)this._upperElevation);
                    dos.WriteFloat((float)this._residualPower);
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
                    this._emitterNumber = dis.ReadUnsignedByte();
                    this._beamNumber = dis.ReadUnsignedByte();
                    this._stateIndicator = dis.ReadUnsignedByte();
                    this._leftAzimuth = dis.ReadFloat();
                    this._rightAzimuth = dis.ReadFloat();
                    this._lowerElevation = dis.ReadFloat();
                    this._upperElevation = dis.ReadFloat();
                    this._residualPower = dis.ReadFloat();
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
            sb.AppendLine("<BlankingSector>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<emitterNumber type=\"byte\">" + this._emitterNumber.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
                sb.AppendLine("<beamNumber type=\"byte\">" + this._beamNumber.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
                sb.AppendLine("<stateIndicator type=\"byte\">" + this._stateIndicator.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
                sb.AppendLine("<leftAzimuth type=\"float\">" + this._leftAzimuth.ToString(CultureInfo.InvariantCulture) + "</leftAzimuth>");
                sb.AppendLine("<rightAzimuth type=\"float\">" + this._rightAzimuth.ToString(CultureInfo.InvariantCulture) + "</rightAzimuth>");
                sb.AppendLine("<lowerElevation type=\"float\">" + this._lowerElevation.ToString(CultureInfo.InvariantCulture) + "</lowerElevation>");
                sb.AppendLine("<upperElevation type=\"float\">" + this._upperElevation.ToString(CultureInfo.InvariantCulture) + "</upperElevation>");
                sb.AppendLine("<residualPower type=\"float\">" + this._residualPower.ToString(CultureInfo.InvariantCulture) + "</residualPower>");
                sb.AppendLine("</BlankingSector>");
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
            return this == obj as BlankingSector;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(BlankingSector obj)
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

            if (this._leftAzimuth != obj._leftAzimuth)
            {
                ivarsEqual = false;
            }

            if (this._rightAzimuth != obj._rightAzimuth)
            {
                ivarsEqual = false;
            }

            if (this._lowerElevation != obj._lowerElevation)
            {
                ivarsEqual = false;
            }

            if (this._upperElevation != obj._upperElevation)
            {
                ivarsEqual = false;
            }

            if (this._residualPower != obj._residualPower)
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
            result = GenerateHash(result) ^ this._emitterNumber.GetHashCode();
            result = GenerateHash(result) ^ this._beamNumber.GetHashCode();
            result = GenerateHash(result) ^ this._stateIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._leftAzimuth.GetHashCode();
            result = GenerateHash(result) ^ this._rightAzimuth.GetHashCode();
            result = GenerateHash(result) ^ this._lowerElevation.GetHashCode();
            result = GenerateHash(result) ^ this._upperElevation.GetHashCode();
            result = GenerateHash(result) ^ this._residualPower.GetHashCode();

            return result;
        }
    }
}
