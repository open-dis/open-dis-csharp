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
    /// Effect of IO on an entity. Section 6.2.49.3
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class IOEffect
    {
        private uint _recordType = 5500;

        private ushort _recordLength = 16;

        private byte _ioStatus;

        private byte _ioLinkType;

        private EntityID _ioEffect = new EntityID();

        private byte _ioEffectDutyCycle;

        private ushort _ioEffectDuration;

        private ushort _ioProcess;

        private ushort _padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="IOEffect"/> class.
        /// </summary>
        public IOEffect()
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
        public static bool operator !=(IOEffect left, IOEffect right)
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
        public static bool operator ==(IOEffect left, IOEffect right)
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
            marshalSize += 1;  // this._ioStatus
            marshalSize += 1;  // this._ioLinkType
            marshalSize += this._ioEffect.GetMarshalledSize();  // this._ioEffect
            marshalSize += 1;  // this._ioEffectDutyCycle
            marshalSize += 2;  // this._ioEffectDuration
            marshalSize += 2;  // this._ioProcess
            marshalSize += 2;  // this._padding
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

        [XmlElement(Type = typeof(byte), ElementName = "ioStatus")]
        public byte IoStatus
        {
            get
            {
                return this._ioStatus;
            }

            set
            {
                this._ioStatus = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "ioLinkType")]
        public byte IoLinkType
        {
            get
            {
                return this._ioLinkType;
            }

            set
            {
                this._ioLinkType = value;
            }
        }

        [XmlElement(Type = typeof(EntityID), ElementName = "ioEffect")]
        public EntityID IoEffect
        {
            get
            {
                return this._ioEffect;
            }

            set
            {
                this._ioEffect = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "ioEffectDutyCycle")]
        public byte IoEffectDutyCycle
        {
            get
            {
                return this._ioEffectDutyCycle;
            }

            set
            {
                this._ioEffectDutyCycle = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "ioEffectDuration")]
        public ushort IoEffectDuration
        {
            get
            {
                return this._ioEffectDuration;
            }

            set
            {
                this._ioEffectDuration = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "ioProcess")]
        public ushort IoProcess
        {
            get
            {
                return this._ioProcess;
            }

            set
            {
                this._ioProcess = value;
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
                    dos.WriteUnsignedByte((byte)this._ioStatus);
                    dos.WriteUnsignedByte((byte)this._ioLinkType);
                    this._ioEffect.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._ioEffectDutyCycle);
                    dos.WriteUnsignedShort((ushort)this._ioEffectDuration);
                    dos.WriteUnsignedShort((ushort)this._ioProcess);
                    dos.WriteUnsignedShort((ushort)this._padding);
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
                    this._ioStatus = dis.ReadUnsignedByte();
                    this._ioLinkType = dis.ReadUnsignedByte();
                    this._ioEffect.Unmarshal(dis);
                    this._ioEffectDutyCycle = dis.ReadUnsignedByte();
                    this._ioEffectDuration = dis.ReadUnsignedShort();
                    this._ioProcess = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
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
            sb.AppendLine("<IOEffect>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<ioStatus type=\"byte\">" + this._ioStatus.ToString(CultureInfo.InvariantCulture) + "</ioStatus>");
                sb.AppendLine("<ioLinkType type=\"byte\">" + this._ioLinkType.ToString(CultureInfo.InvariantCulture) + "</ioLinkType>");
                sb.AppendLine("<ioEffect>");
                this._ioEffect.Reflection(sb);
                sb.AppendLine("</ioEffect>");
                sb.AppendLine("<ioEffectDutyCycle type=\"byte\">" + this._ioEffectDutyCycle.ToString(CultureInfo.InvariantCulture) + "</ioEffectDutyCycle>");
                sb.AppendLine("<ioEffectDuration type=\"ushort\">" + this._ioEffectDuration.ToString(CultureInfo.InvariantCulture) + "</ioEffectDuration>");
                sb.AppendLine("<ioProcess type=\"ushort\">" + this._ioProcess.ToString(CultureInfo.InvariantCulture) + "</ioProcess>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("</IOEffect>");
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
            return this == obj as IOEffect;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IOEffect obj)
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

            if (this._ioStatus != obj._ioStatus)
            {
                ivarsEqual = false;
            }

            if (this._ioLinkType != obj._ioLinkType)
            {
                ivarsEqual = false;
            }

            if (!this._ioEffect.Equals(obj._ioEffect))
            {
                ivarsEqual = false;
            }

            if (this._ioEffectDutyCycle != obj._ioEffectDutyCycle)
            {
                ivarsEqual = false;
            }

            if (this._ioEffectDuration != obj._ioEffectDuration)
            {
                ivarsEqual = false;
            }

            if (this._ioProcess != obj._ioProcess)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
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
            result = GenerateHash(result) ^ this._ioStatus.GetHashCode();
            result = GenerateHash(result) ^ this._ioLinkType.GetHashCode();
            result = GenerateHash(result) ^ this._ioEffect.GetHashCode();
            result = GenerateHash(result) ^ this._ioEffectDutyCycle.GetHashCode();
            result = GenerateHash(result) ^ this._ioEffectDuration.GetHashCode();
            result = GenerateHash(result) ^ this._ioProcess.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();

            return result;
        }
    }
}
