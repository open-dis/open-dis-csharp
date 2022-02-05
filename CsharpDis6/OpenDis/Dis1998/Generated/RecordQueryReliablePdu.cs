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
    /// Section 5.3.12.13: A request for one or more records of data from an entity. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FourByteChunk))]
    public partial class RecordQueryReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<RecordQueryReliablePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecordQueryReliablePdu"/> class.
        /// </summary>
        public RecordQueryReliablePdu()
        {
            PduType = 63;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RecordQueryReliablePdu left, RecordQueryReliablePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(RecordQueryReliablePdu left, RecordQueryReliablePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 4;  // this._requestID
            marshalSize += 1;  // this._requiredReliabilityService
            marshalSize += 2;  // this._pad1
            marshalSize += 1;  // this._pad2
            marshalSize += 2;  // this._eventType
            marshalSize += 4;  // this._time
            marshalSize += 4;  // this._numberOfRecords
            for (int idx = 0; idx < RecordIDs.Count; idx++)
            {
                var listElement = RecordIDs[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID { get; set; }

        /// <summary>
        /// Gets or sets the level of reliability service used for this transaction
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
        public byte RequiredReliabilityService { get; set; }

        /// <summary>
        /// Gets or sets the padding. The spec is unclear and contradictory here.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad1")]
        public ushort Pad1 { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "eventType")]
        public ushort EventType { get; set; }

        /// <summary>
        /// Gets or sets the time
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "time")]
        public uint Time { get; set; }

        /// <summary>
        /// Gets or sets the numberOfRecords
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfRecords method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
        public uint NumberOfRecords { get; set; }

        /// <summary>
        /// Gets the record IDs
        /// </summary>
        [XmlElement(ElementName = "recordIDsList", Type = typeof(List<FourByteChunk>))]
        public List<FourByteChunk> RecordIDs { get; } = new();

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt(RequestID);
                    dos.WriteUnsignedByte(RequiredReliabilityService);
                    dos.WriteUnsignedShort(Pad1);
                    dos.WriteUnsignedByte(Pad2);
                    dos.WriteUnsignedShort(EventType);
                    dos.WriteUnsignedInt(Time);
                    dos.WriteUnsignedInt((uint)RecordIDs.Count);

                    for (int idx = 0; idx < RecordIDs.Count; idx++)
                    {
                        var aFourByteChunk = RecordIDs[idx];
                        aFourByteChunk.Marshal(dos);
                    }
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
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    RequestID = dis.ReadUnsignedInt();
                    RequiredReliabilityService = dis.ReadUnsignedByte();
                    Pad1 = dis.ReadUnsignedShort();
                    Pad2 = dis.ReadUnsignedByte();
                    EventType = dis.ReadUnsignedShort();
                    Time = dis.ReadUnsignedInt();
                    NumberOfRecords = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < NumberOfRecords; idx++)
                    {
                        var anX = new FourByteChunk();
                        anX.Unmarshal(dis);
                        RecordIDs.Add(anX);
                    }
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

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<RecordQueryReliablePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestID type=\"uint\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requiredReliabilityService type=\"byte\">" + RequiredReliabilityService.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
                sb.AppendLine("<pad1 type=\"ushort\">" + Pad1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
                sb.AppendLine("<pad2 type=\"byte\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<eventType type=\"ushort\">" + EventType.ToString(CultureInfo.InvariantCulture) + "</eventType>");
                sb.AppendLine("<time type=\"uint\">" + Time.ToString(CultureInfo.InvariantCulture) + "</time>");
                sb.AppendLine("<recordIDs type=\"uint\">" + RecordIDs.Count.ToString(CultureInfo.InvariantCulture) + "</recordIDs>");
                for (int idx = 0; idx < RecordIDs.Count; idx++)
                {
                    sb.AppendLine("<recordIDs" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
                    var aFourByteChunk = RecordIDs[idx];
                    aFourByteChunk.Reflection(sb);
                    sb.AppendLine("</recordIDs" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</RecordQueryReliablePdu>");
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
        public override bool Equals(object obj) => this == obj as RecordQueryReliablePdu;

        ///<inheritdoc/>
        public bool Equals(RecordQueryReliablePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (RequiredReliabilityService != obj.RequiredReliabilityService)
            {
                ivarsEqual = false;
            }

            if (Pad1 != obj.Pad1)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (EventType != obj.EventType)
            {
                ivarsEqual = false;
            }

            if (Time != obj.Time)
            {
                ivarsEqual = false;
            }

            if (NumberOfRecords != obj.NumberOfRecords)
            {
                ivarsEqual = false;
            }

            if (RecordIDs.Count != obj.RecordIDs.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < RecordIDs.Count; idx++)
                {
                    if (!RecordIDs[idx].Equals(obj.RecordIDs[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ RequiredReliabilityService.GetHashCode();
            result = GenerateHash(result) ^ Pad1.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ EventType.GetHashCode();
            result = GenerateHash(result) ^ Time.GetHashCode();
            result = GenerateHash(result) ^ NumberOfRecords.GetHashCode();

            if (RecordIDs.Count > 0)
            {
                for (int idx = 0; idx < RecordIDs.Count; idx++)
                {
                    result = GenerateHash(result) ^ RecordIDs[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
