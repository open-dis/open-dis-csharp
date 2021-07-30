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
    public partial class RecordSet : IEquatable<RecordSet>, IReflectable
    {
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
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RecordSet left, RecordSet right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(RecordSet left, RecordSet right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

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
        public uint RecordID { get; set; }

        /// <summary>
        /// Gets or sets the record set serial number
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordSetSerialNumber")]
        public uint RecordSetSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the record length
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
        public ushort RecordLength { get; set; }

        /// <summary>
        /// Gets or sets the record count
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordCount")]
        public ushort RecordCount { get; set; }

        /// <summary>
        /// Gets or sets the ^^^This is wrong--variable sized data records
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordValues")]
        public ushort RecordValues { get; set; }

        /// <summary>
        /// Gets or sets the ^^^This is wrong--variable sized padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad4")]
        public byte Pad4 { get; set; }

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
            if (PduBase.FireExceptionEvents && ExceptionOccured != null)
            {
                ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt(RecordID);
                    dos.WriteUnsignedInt(RecordSetSerialNumber);
                    dos.WriteUnsignedShort(RecordLength);
                    dos.WriteUnsignedShort(RecordCount);
                    dos.WriteUnsignedShort(RecordValues);
                    dos.WriteUnsignedByte(Pad4);
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
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
                    RecordID = dis.ReadUnsignedInt();
                    RecordSetSerialNumber = dis.ReadUnsignedInt();
                    RecordLength = dis.ReadUnsignedShort();
                    RecordCount = dis.ReadUnsignedShort();
                    RecordValues = dis.ReadUnsignedShort();
                    Pad4 = dis.ReadUnsignedByte();
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        ///<inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<RecordSet>");
            try
            {
                sb.AppendLine("<recordID type=\"uint\">" + RecordID.ToString(CultureInfo.InvariantCulture) + "</recordID>");
                sb.AppendLine("<recordSetSerialNumber type=\"uint\">" + RecordSetSerialNumber.ToString(CultureInfo.InvariantCulture) + "</recordSetSerialNumber>");
                sb.AppendLine("<recordLength type=\"ushort\">" + RecordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<recordCount type=\"ushort\">" + RecordCount.ToString(CultureInfo.InvariantCulture) + "</recordCount>");
                sb.AppendLine("<recordValues type=\"ushort\">" + RecordValues.ToString(CultureInfo.InvariantCulture) + "</recordValues>");
                sb.AppendLine("<pad4 type=\"byte\">" + Pad4.ToString(CultureInfo.InvariantCulture) + "</pad4>");
                sb.AppendLine("</RecordSet>");
            }
            catch (Exception e)
            {
                if (PduBase.TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (PduBase.ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as RecordSet;

        ///<inheritdoc/>
        public bool Equals(RecordSet obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (RecordID != obj.RecordID)
            {
                ivarsEqual = false;
            }

            if (RecordSetSerialNumber != obj.RecordSetSerialNumber)
            {
                ivarsEqual = false;
            }

            if (RecordLength != obj.RecordLength)
            {
                ivarsEqual = false;
            }

            if (RecordCount != obj.RecordCount)
            {
                ivarsEqual = false;
            }

            if (RecordValues != obj.RecordValues)
            {
                ivarsEqual = false;
            }

            if (Pad4 != obj.Pad4)
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
        private static int GenerateHash(int hash) => hash << (5 + hash);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ RecordID.GetHashCode();
            result = GenerateHash(result) ^ RecordSetSerialNumber.GetHashCode();
            result = GenerateHash(result) ^ RecordLength.GetHashCode();
            result = GenerateHash(result) ^ RecordCount.GetHashCode();
            result = GenerateHash(result) ^ RecordValues.GetHashCode();
            result = GenerateHash(result) ^ Pad4.GetHashCode();

            return result;
        }
    }
}
