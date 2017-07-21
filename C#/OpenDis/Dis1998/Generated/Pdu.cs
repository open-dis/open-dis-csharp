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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// The superclass for all PDUs. This incorporates the PduHeader record, section 5.2.29.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class Pdu : PduBase, IPdu
    {
        /// <summary>
        /// The version of the protocol. 5=DIS-1995, 6=DIS-1998.
        /// </summary>
        private byte _protocolVersion = 6;

        /// <summary>
        /// Exercise ID
        /// </summary>
        private byte _exerciseID;

        /// <summary>
        /// Type of pdu, unique for each PDU class
        /// </summary>
        private byte _pduType;

        /// <summary>
        /// value that refers to the protocol family, eg SimulationManagement, et
        /// </summary>
        private byte _protocolFamily;

        /// <summary>
        /// Timestamp value
        /// </summary>
        private uint _timestamp;

        /// <summary>
        /// Length, in bytes, of the PDU
        /// </summary>
        private ushort _length;

        /// <summary>
        /// zero-filled array of padding
        /// </summary>
        private short _padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pdu"/> class.
        /// </summary>
        public Pdu()
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
        public static bool operator !=(Pdu left, Pdu right)
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
        public static bool operator ==(Pdu left, Pdu right)
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

            marshalSize += 1;  // this._protocolVersion
            marshalSize += 1;  // this._exerciseID
            marshalSize += 1;  // this._pduType
            marshalSize += 1;  // this._protocolFamily
            marshalSize += 4;  // this._timestamp
            marshalSize += 2;  // this._length
            marshalSize += 2;  // this._padding
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the The version of the protocol. 5=DIS-1995, 6=DIS-1998.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "protocolVersion")]
        public byte ProtocolVersion
        {
            get
            {
                return this._protocolVersion;
            }

            set
            {
                this._protocolVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the Exercise ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "exerciseID")]
        public byte ExerciseID
        {
            get
            {
                return this._exerciseID;
            }

            set
            {
                this._exerciseID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Type of pdu, unique for each PDU class
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pduType")]
        public byte PduType
        {
            get
            {
                return this._pduType;
            }

            set
            {
                this._pduType = value;
            }
        }

        /// <summary>
        /// Gets or sets the value that refers to the protocol family, eg SimulationManagement, et
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "protocolFamily")]
        public byte ProtocolFamily
        {
            get
            {
                return this._protocolFamily;
            }

            set
            {
                this._protocolFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets the Timestamp value
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "timestamp")]
        public uint Timestamp
        {
            get
            {
                return this._timestamp;
            }

            set
            {
                this._timestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the Length, in bytes, of the PDU
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "length")]
        public ushort Length
        {
            get
            {
                return this._length;
            }

            set
            {
                this._length = value;
            }
        }

        /// <summary>
        /// Gets or sets the zero-filled array of padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding")]
        public short Padding
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
        public event EventHandler<PduExceptionEventArgs> ExceptionOccured;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void RaiseExceptionOccured(Exception e)
        {
            if (Pdu.FireExceptionEvents && this.ExceptionOccured != null)
            {
                this.ExceptionOccured(this, new PduExceptionEventArgs(e));
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
                    dos.WriteUnsignedByte((byte)this._protocolVersion);
                    dos.WriteUnsignedByte((byte)this._exerciseID);
                    dos.WriteUnsignedByte((byte)this._pduType);
                    dos.WriteUnsignedByte((byte)this._protocolFamily);
                    dos.WriteUnsignedInt((uint)this._timestamp);
                    dos.WriteUnsignedShort((ushort)this._length);
                    dos.WriteShort((short)this._padding);
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
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
                    this._protocolVersion = dis.ReadUnsignedByte();
                    this._exerciseID = dis.ReadUnsignedByte();
                    this._pduType = dis.ReadUnsignedByte();
                    this._protocolFamily = dis.ReadUnsignedByte();
                    this._timestamp = dis.ReadUnsignedInt();
                    this._length = dis.ReadUnsignedShort();
                    this._padding = dis.ReadShort();
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
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
            sb.AppendLine("<Pdu>");
            try
            {
                sb.AppendLine("<protocolVersion type=\"byte\">" + this._protocolVersion.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
                sb.AppendLine("<exerciseID type=\"byte\">" + this._exerciseID.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
                sb.AppendLine("<pduType type=\"byte\">" + this._pduType.ToString(CultureInfo.InvariantCulture) + "</pduType>");
                sb.AppendLine("<protocolFamily type=\"byte\">" + this._protocolFamily.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
                sb.AppendLine("<timestamp type=\"uint\">" + this._timestamp.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
                sb.AppendLine("<length type=\"ushort\">" + this._length.ToString(CultureInfo.InvariantCulture) + "</length>");
                sb.AppendLine("<padding type=\"short\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("</Pdu>");
            }
            catch (Exception e)
            {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
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
            return this == obj as Pdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Pdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._protocolVersion != obj._protocolVersion)
            {
                ivarsEqual = false;
            }

            if (this._exerciseID != obj._exerciseID)
            {
                ivarsEqual = false;
            }

            if (this._pduType != obj._pduType)
            {
                ivarsEqual = false;
            }

            if (this._protocolFamily != obj._protocolFamily)
            {
                ivarsEqual = false;
            }

            if (this._timestamp != obj._timestamp)
            {
                ivarsEqual = false;
            }

            if (this._length != obj._length)
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

            result = GenerateHash(result) ^ this._protocolVersion.GetHashCode();
            result = GenerateHash(result) ^ this._exerciseID.GetHashCode();
            result = GenerateHash(result) ^ this._pduType.GetHashCode();
            result = GenerateHash(result) ^ this._protocolFamily.GetHashCode();
            result = GenerateHash(result) ^ this._timestamp.GetHashCode();
            result = GenerateHash(result) ^ this._length.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();

            return result;
        }
    }
}
