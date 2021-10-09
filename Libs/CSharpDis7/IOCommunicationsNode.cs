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
    /// A communications node that is part of a simulted communcations network. Section 6.2.49.2
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class IOCommunicationsNode
    {
        private uint _recordType = 5501;

        private ushort _recordLength = 16;

        private byte _communcationsNodeType;

        private byte _padding;

        private EntityID _communicationsNode = new EntityID();

        private ushort _elementID;

        /// <summary>
        /// Initializes a new instance of the <see cref="IOCommunicationsNode"/> class.
        /// </summary>
        public IOCommunicationsNode()
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
        public static bool operator !=(IOCommunicationsNode left, IOCommunicationsNode right)
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
        public static bool operator ==(IOCommunicationsNode left, IOCommunicationsNode right)
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
            marshalSize += 1;  // this._communcationsNodeType
            marshalSize += 1;  // this._padding
            marshalSize += this._communicationsNode.GetMarshalledSize();  // this._communicationsNode
            marshalSize += 2;  // this._elementID
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

        [XmlElement(Type = typeof(byte), ElementName = "communcationsNodeType")]
        public byte CommuncationsNodeType
        {
            get
            {
                return this._communcationsNodeType;
            }

            set
            {
                this._communcationsNodeType = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "padding")]
        public byte Padding
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

        [XmlElement(Type = typeof(EntityID), ElementName = "communicationsNode")]
        public EntityID CommunicationsNode
        {
            get
            {
                return this._communicationsNode;
            }

            set
            {
                this._communicationsNode = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "elementID")]
        public ushort ElementID
        {
            get
            {
                return this._elementID;
            }

            set
            {
                this._elementID = value;
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
                    dos.WriteUnsignedByte((byte)this._communcationsNodeType);
                    dos.WriteUnsignedByte((byte)this._padding);
                    this._communicationsNode.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._elementID);
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
                    this._communcationsNodeType = dis.ReadUnsignedByte();
                    this._padding = dis.ReadUnsignedByte();
                    this._communicationsNode.Unmarshal(dis);
                    this._elementID = dis.ReadUnsignedShort();
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
            sb.AppendLine("<IOCommunicationsNode>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<communcationsNodeType type=\"byte\">" + this._communcationsNodeType.ToString(CultureInfo.InvariantCulture) + "</communcationsNodeType>");
                sb.AppendLine("<padding type=\"byte\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<communicationsNode>");
                this._communicationsNode.Reflection(sb);
                sb.AppendLine("</communicationsNode>");
                sb.AppendLine("<elementID type=\"ushort\">" + this._elementID.ToString(CultureInfo.InvariantCulture) + "</elementID>");
                sb.AppendLine("</IOCommunicationsNode>");
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
            return this == obj as IOCommunicationsNode;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IOCommunicationsNode obj)
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

            if (this._communcationsNodeType != obj._communcationsNodeType)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (!this._communicationsNode.Equals(obj._communicationsNode))
            {
                ivarsEqual = false;
            }

            if (this._elementID != obj._elementID)
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
            result = GenerateHash(result) ^ this._communcationsNodeType.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._communicationsNode.GetHashCode();
            result = GenerateHash(result) ^ this._elementID.GetHashCode();

            return result;
        }
    }
}
