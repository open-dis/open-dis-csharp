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
    /// Section 5.3.9.3 Information initiating the dyanic allocation and control of simulation entities        between
    /// two simulation applications. Requires manual cleanup. The padding between record sets is variable. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(RecordSet))]
    public partial class TransferControlRequestPdu : EntityManagementFamilyPdu, IEquatable<TransferControlRequestPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferControlRequestPdu"/> class.
        /// </summary>
        public TransferControlRequestPdu()
        {
            PduType = 35;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(TransferControlRequestPdu left, TransferControlRequestPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(TransferControlRequestPdu left, TransferControlRequestPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += OrginatingEntityID.GetMarshalledSize();  // this._orginatingEntityID
            marshalSize += RecevingEntityID.GetMarshalledSize();  // this._recevingEntityID
            marshalSize += 4;  // this._requestID
            marshalSize += 1;  // this._requiredReliabilityService
            marshalSize += 1;  // this._tranferType
            marshalSize += TransferEntityID.GetMarshalledSize();  // this._transferEntityID
            marshalSize += 1;  // this._numberOfRecordSets
            for (int idx = 0; idx < RecordSets.Count; idx++)
            {
                var listElement = RecordSets[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of entity originating request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
        public EntityID OrginatingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of entity receiving request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "recevingEntityID")]
        public EntityID RecevingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID ofrequest
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID { get; set; }

        /// <summary>
        /// Gets or sets the required level of reliabliity service.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
        public byte RequiredReliabilityService { get; set; }

        /// <summary>
        /// Gets or sets the type of transfer desired
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "tranferType")]
        public byte TranferType { get; set; }

        /// <summary>
        /// Gets or sets the entity for which control is being requested to transfer
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "transferEntityID")]
        public EntityID TransferEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the number of record sets to transfer
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfRecordSets method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfRecordSets")]
        public byte NumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets the ^^^This is wrong--the RecordSet class needs more work
        /// </summary>
        [XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
        public List<RecordSet> RecordSets { get; } = new();

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
                    OrginatingEntityID.Marshal(dos);
                    RecevingEntityID.Marshal(dos);
                    dos.WriteUnsignedInt(RequestID);
                    dos.WriteUnsignedByte(RequiredReliabilityService);
                    dos.WriteUnsignedByte(TranferType);
                    TransferEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)RecordSets.Count);

                    for (int idx = 0; idx < RecordSets.Count; idx++)
                    {
                        var aRecordSet = RecordSets[idx];
                        aRecordSet.Marshal(dos);
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
                    OrginatingEntityID.Unmarshal(dis);
                    RecevingEntityID.Unmarshal(dis);
                    RequestID = dis.ReadUnsignedInt();
                    RequiredReliabilityService = dis.ReadUnsignedByte();
                    TranferType = dis.ReadUnsignedByte();
                    TransferEntityID.Unmarshal(dis);
                    NumberOfRecordSets = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfRecordSets; idx++)
                    {
                        var anX = new RecordSet();
                        anX.Unmarshal(dis);
                        RecordSets.Add(anX);
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
            sb.AppendLine("<TransferControlRequestPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                OrginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<recevingEntityID>");
                RecevingEntityID.Reflection(sb);
                sb.AppendLine("</recevingEntityID>");
                sb.AppendLine("<requestID type=\"uint\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requiredReliabilityService type=\"byte\">" + RequiredReliabilityService.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
                sb.AppendLine("<tranferType type=\"byte\">" + TranferType.ToString(CultureInfo.InvariantCulture) + "</tranferType>");
                sb.AppendLine("<transferEntityID>");
                TransferEntityID.Reflection(sb);
                sb.AppendLine("</transferEntityID>");
                sb.AppendLine("<recordSets type=\"byte\">" + RecordSets.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
                for (int idx = 0; idx < RecordSets.Count; idx++)
                {
                    sb.AppendLine("<recordSets" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
                    var aRecordSet = RecordSets[idx];
                    aRecordSet.Reflection(sb);
                    sb.AppendLine("</recordSets" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</TransferControlRequestPdu>");
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
        public override bool Equals(object obj) => this == obj as TransferControlRequestPdu;

        ///<inheritdoc/>
        public bool Equals(TransferControlRequestPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!OrginatingEntityID.Equals(obj.OrginatingEntityID))
            {
                ivarsEqual = false;
            }

            if (!RecevingEntityID.Equals(obj.RecevingEntityID))
            {
                ivarsEqual = false;
            }

            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (RequiredReliabilityService != obj.RequiredReliabilityService)
            {
                ivarsEqual = false;
            }

            if (TranferType != obj.TranferType)
            {
                ivarsEqual = false;
            }

            if (!TransferEntityID.Equals(obj.TransferEntityID))
            {
                ivarsEqual = false;
            }

            if (NumberOfRecordSets != obj.NumberOfRecordSets)
            {
                ivarsEqual = false;
            }

            if (RecordSets.Count != obj.RecordSets.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < RecordSets.Count; idx++)
                {
                    if (!RecordSets[idx].Equals(obj.RecordSets[idx]))
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

            result = GenerateHash(result) ^ OrginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ RecevingEntityID.GetHashCode();
            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ RequiredReliabilityService.GetHashCode();
            result = GenerateHash(result) ^ TranferType.GetHashCode();
            result = GenerateHash(result) ^ TransferEntityID.GetHashCode();
            result = GenerateHash(result) ^ NumberOfRecordSets.GetHashCode();

            if (RecordSets.Count > 0)
            {
                for (int idx = 0; idx < RecordSets.Count; idx++)
                {
                    result = GenerateHash(result) ^ RecordSets[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
