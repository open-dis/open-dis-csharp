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
    /// Record sets, used in transfer control request PDU
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class RecordSet
    {
        /// <summary>
        /// record ID
        /// </summary>
        private uint _recordID;

        /// <summary>
        /// record set serial number
        /// </summary>
        private uint _recordSetSerialNumber;

        /// <summary>
        /// record length
        /// </summary>
        private ushort _recordLength;

        /// <summary>
        /// record count
        /// </summary>
        private ushort _recordCount;

        /// <summary>
        /// ^^^This is wrong--variable sized data records
        /// </summary>
        private ushort _recordValues;

        /// <summary>
        /// ^^^This is wrong--variable sized padding
        /// </summary>
        private byte _pad4;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordSet"/> class.
        /// </summary>
        public RecordSet()
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
        public static bool operator !=(RecordSet left, RecordSet right)
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
        public static bool operator ==(RecordSet left, RecordSet right)
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

            marshalSize += 4;  // this._recordID
            marshalSize += 4;  // this._recordSetSerialNumber
            marshalSize += 2;  // this._recordLength
            marshalSize += 2;  // this._recordCount
            marshalSize += 2;  // this._recordValues
            marshalSize += 1;  // this._pad4
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the record ID
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordID")]
        public uint RecordID
        {
            get
            {
                return this._recordID;
            }

            set
            {
                this._recordID = value;
            }
        }

        /// <summary>
        /// Gets or sets the record set serial number
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordSetSerialNumber")]
        public uint RecordSetSerialNumber
        {
            get
            {
                return this._recordSetSerialNumber;
            }

            set
            {
                this._recordSetSerialNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the record length
        /// </summary>
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

        /// <summary>
        /// Gets or sets the record count
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordCount")]
        public ushort RecordCount
        {
            get
            {
                return this._recordCount;
            }

            set
            {
                this._recordCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the ^^^This is wrong--variable sized data records
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordValues")]
        public ushort RecordValues
        {
            get
            {
                return this._recordValues;
            }

            set
            {
                this._recordValues = value;
            }
        }

        /// <summary>
        /// Gets or sets the ^^^This is wrong--variable sized padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad4")]
        public byte Pad4
        {
            get
            {
                return this._pad4;
            }

            set
            {
                this._pad4 = value;
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
                    dos.WriteUnsignedInt((uint)this._recordID);
                    dos.WriteUnsignedInt((uint)this._recordSetSerialNumber);
                    dos.WriteUnsignedShort((ushort)this._recordLength);
                    dos.WriteUnsignedShort((ushort)this._recordCount);
                    dos.WriteUnsignedShort((ushort)this._recordValues);
                    dos.WriteUnsignedByte((byte)this._pad4);
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
                    this._recordID = dis.ReadUnsignedInt();
                    this._recordSetSerialNumber = dis.ReadUnsignedInt();
                    this._recordLength = dis.ReadUnsignedShort();
                    this._recordCount = dis.ReadUnsignedShort();
                    this._recordValues = dis.ReadUnsignedShort();
                    this._pad4 = dis.ReadUnsignedByte();
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
            sb.AppendLine("<RecordSet>");
            try
            {
                sb.AppendLine("<recordID type=\"uint\">" + this._recordID.ToString(CultureInfo.InvariantCulture) + "</recordID>");
                sb.AppendLine("<recordSetSerialNumber type=\"uint\">" + this._recordSetSerialNumber.ToString(CultureInfo.InvariantCulture) + "</recordSetSerialNumber>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<recordCount type=\"ushort\">" + this._recordCount.ToString(CultureInfo.InvariantCulture) + "</recordCount>");
                sb.AppendLine("<recordValues type=\"ushort\">" + this._recordValues.ToString(CultureInfo.InvariantCulture) + "</recordValues>");
                sb.AppendLine("<pad4 type=\"byte\">" + this._pad4.ToString(CultureInfo.InvariantCulture) + "</pad4>");
                sb.AppendLine("</RecordSet>");
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
            return this == obj as RecordSet;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(RecordSet obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._recordID != obj._recordID)
            {
                ivarsEqual = false;
            }

            if (this._recordSetSerialNumber != obj._recordSetSerialNumber)
            {
                ivarsEqual = false;
            }

            if (this._recordLength != obj._recordLength)
            {
                ivarsEqual = false;
            }

            if (this._recordCount != obj._recordCount)
            {
                ivarsEqual = false;
            }

            if (this._recordValues != obj._recordValues)
            {
                ivarsEqual = false;
            }

            if (this._pad4 != obj._pad4)
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

            result = GenerateHash(result) ^ this._recordID.GetHashCode();
            result = GenerateHash(result) ^ this._recordSetSerialNumber.GetHashCode();
            result = GenerateHash(result) ^ this._recordLength.GetHashCode();
            result = GenerateHash(result) ^ this._recordCount.GetHashCode();
            result = GenerateHash(result) ^ this._recordValues.GetHashCode();
            result = GenerateHash(result) ^ this._pad4.GetHashCode();

            return result;
        }
    }
}
