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
    /// Removable parts that may be attached to an entity.  Section 6.2.93.3
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AttachedParts
    {
        /// <summary>
        /// the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        private byte _recordType = 1;

        /// <summary>
        /// 0 = attached, 1 = detached. See I.2.3.1 for state transition diagram
        /// </summary>
        private byte _detachedIndicator;

        /// <summary>
        /// the identification of the articulated part to which this articulation parameter is attached. This field shall be specified by a 16-bit unsigned integer. This field shall contain the value zero if the articulated part is attached directly to the entity.
        /// </summary>
        private ushort _partAttachedTo;

        /// <summary>
        /// The location or station to which the part is attached
        /// </summary>
        private uint _parameterType;

        /// <summary>
        /// The definition of the 64 bits shall be determined based on the type of parameter specified in the Parameter Type field 
        /// </summary>
        private ulong _parameterValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachedParts"/> class.
        /// </summary>
        public AttachedParts()
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
        public static bool operator !=(AttachedParts left, AttachedParts right)
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
        public static bool operator ==(AttachedParts left, AttachedParts right)
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

            marshalSize += 1;  // this._recordType
            marshalSize += 1;  // this._detachedIndicator
            marshalSize += 2;  // this._partAttachedTo
            marshalSize += 4;  // this._parameterType
            marshalSize += 8;  // this._parameterValue
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "recordType")]
        public byte RecordType
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

        /// <summary>
        /// Gets or sets the 0 = attached, 1 = detached. See I.2.3.1 for state transition diagram
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "detachedIndicator")]
        public byte DetachedIndicator
        {
            get
            {
                return this._detachedIndicator;
            }

            set
            {
                this._detachedIndicator = value;
            }
        }

        /// <summary>
        /// Gets or sets the the identification of the articulated part to which this articulation parameter is attached. This field shall be specified by a 16-bit unsigned integer. This field shall contain the value zero if the articulated part is attached directly to the entity.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "partAttachedTo")]
        public ushort PartAttachedTo
        {
            get
            {
                return this._partAttachedTo;
            }

            set
            {
                this._partAttachedTo = value;
            }
        }

        /// <summary>
        /// Gets or sets the The location or station to which the part is attached
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "parameterType")]
        public uint ParameterType
        {
            get
            {
                return this._parameterType;
            }

            set
            {
                this._parameterType = value;
            }
        }

        /// <summary>
        /// Gets or sets the The definition of the 64 bits shall be determined based on the type of parameter specified in the Parameter Type field 
        /// </summary>
        [XmlElement(Type = typeof(ulong), ElementName = "parameterValue")]
        public ulong ParameterValue
        {
            get
            {
                return this._parameterValue;
            }

            set
            {
                this._parameterValue = value;
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
                    dos.WriteUnsignedByte((byte)this._recordType);
                    dos.WriteUnsignedByte((byte)this._detachedIndicator);
                    dos.WriteUnsignedShort((ushort)this._partAttachedTo);
                    dos.WriteUnsignedInt((uint)this._parameterType);
                    dos.WriteUnsignedLong((ulong)this._parameterValue);
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
                    this._recordType = dis.ReadUnsignedByte();
                    this._detachedIndicator = dis.ReadUnsignedByte();
                    this._partAttachedTo = dis.ReadUnsignedShort();
                    this._parameterType = dis.ReadUnsignedInt();
                    this._parameterValue = dis.ReadUnsignedLong();
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
            sb.AppendLine("<AttachedParts>");
            try
            {
                sb.AppendLine("<recordType type=\"byte\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<detachedIndicator type=\"byte\">" + this._detachedIndicator.ToString(CultureInfo.InvariantCulture) + "</detachedIndicator>");
                sb.AppendLine("<partAttachedTo type=\"ushort\">" + this._partAttachedTo.ToString(CultureInfo.InvariantCulture) + "</partAttachedTo>");
                sb.AppendLine("<parameterType type=\"uint\">" + this._parameterType.ToString(CultureInfo.InvariantCulture) + "</parameterType>");
                sb.AppendLine("<parameterValue type=\"ulong\">" + this._parameterValue.ToString(CultureInfo.InvariantCulture) + "</parameterValue>");
                sb.AppendLine("</AttachedParts>");
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
            return this == obj as AttachedParts;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AttachedParts obj)
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

            if (this._detachedIndicator != obj._detachedIndicator)
            {
                ivarsEqual = false;
            }

            if (this._partAttachedTo != obj._partAttachedTo)
            {
                ivarsEqual = false;
            }

            if (this._parameterType != obj._parameterType)
            {
                ivarsEqual = false;
            }

            if (this._parameterValue != obj._parameterValue)
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
            result = GenerateHash(result) ^ this._detachedIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._partAttachedTo.GetHashCode();
            result = GenerateHash(result) ^ this._parameterType.GetHashCode();
            result = GenerateHash(result) ^ this._parameterValue.GetHashCode();

            return result;
        }
    }
}
