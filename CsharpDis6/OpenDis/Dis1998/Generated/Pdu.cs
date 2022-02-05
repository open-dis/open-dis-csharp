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
    /// The superclass for all PDUs. This incorporates the PduHeader record, section 5.2.29.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class Pdu : PduBase, IPdu
    {
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
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Pdu left, Pdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Pdu left, Pdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

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
        /// Gets or sets the version of the protocol. 5=DIS-1995, 6=DIS-1998.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "protocolVersion")]
        public byte ProtocolVersion { get; set; } = 6;

        /// <summary>
        /// Gets or sets the Exercise ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "exerciseID")]
        public byte ExerciseID { get; set; }

        /// <summary>
        /// Gets or sets the Type of pdu, unique for each PDU class
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pduType")]
        public byte PduType { get; set; }

        /// <summary>
        /// Gets or sets the value that refers to the protocol family, eg SimulationManagement, et
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "protocolFamily")]
        public byte ProtocolFamily { get; set; }

        /// <summary>
        /// Gets or sets the Timestamp value
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "timestamp")]
        public uint Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the Length, in bytes, of the PDU
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "length")]
        public ushort Length { get; set; }

        /// <summary>
        /// Gets or sets the zero-filled array of padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding")]
        public short Padding { get; set; }

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
            if (FireExceptionEvents && ExceptionOccured != null)
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
                    dos.WriteUnsignedByte(ProtocolVersion);
                    dos.WriteUnsignedByte(ExerciseID);
                    dos.WriteUnsignedByte(PduType);
                    dos.WriteUnsignedByte(ProtocolFamily);
                    dos.WriteUnsignedInt(Timestamp);
                    dos.WriteUnsignedShort(Length);
                    dos.WriteShort(Padding);
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
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
                    ProtocolVersion = dis.ReadUnsignedByte();
                    ExerciseID = dis.ReadUnsignedByte();
                    PduType = dis.ReadUnsignedByte();
                    ProtocolFamily = dis.ReadUnsignedByte();
                    Timestamp = dis.ReadUnsignedInt();
                    Length = dis.ReadUnsignedShort();
                    Padding = dis.ReadShort();
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
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
            sb.AppendLine("<Pdu>");
            try
            {
                sb.AppendLine("<protocolVersion type=\"byte\">" + ProtocolVersion.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
                sb.AppendLine("<exerciseID type=\"byte\">" + ExerciseID.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
                sb.AppendLine("<pduType type=\"byte\">" + PduType.ToString(CultureInfo.InvariantCulture) + "</pduType>");
                sb.AppendLine("<protocolFamily type=\"byte\">" + ProtocolFamily.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
                sb.AppendLine("<timestamp type=\"uint\">" + Timestamp.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
                sb.AppendLine("<length type=\"ushort\">" + Length.ToString(CultureInfo.InvariantCulture) + "</length>");
                sb.AppendLine("<padding type=\"short\">" + Padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("</Pdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as Pdu;

        ///<inheritdoc/>
        public bool Equals(Pdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (ProtocolVersion != obj.ProtocolVersion)
            {
                ivarsEqual = false;
            }

            if (ExerciseID != obj.ExerciseID)
            {
                ivarsEqual = false;
            }

            if (PduType != obj.PduType)
            {
                ivarsEqual = false;
            }

            if (ProtocolFamily != obj.ProtocolFamily)
            {
                ivarsEqual = false;
            }

            if (Timestamp != obj.Timestamp)
            {
                ivarsEqual = false;
            }

            if (Length != obj.Length)
            {
                ivarsEqual = false;
            }

            if (Padding != obj.Padding)
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

            result = GenerateHash(result) ^ ProtocolVersion.GetHashCode();
            result = GenerateHash(result) ^ ExerciseID.GetHashCode();
            result = GenerateHash(result) ^ PduType.GetHashCode();
            result = GenerateHash(result) ^ ProtocolFamily.GetHashCode();
            result = GenerateHash(result) ^ Timestamp.GetHashCode();
            result = GenerateHash(result) ^ Length.GetHashCode();
            result = GenerateHash(result) ^ Padding.GetHashCode();

            return result;
        }
    }
}
