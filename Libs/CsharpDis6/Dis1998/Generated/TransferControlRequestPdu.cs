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
    /// Section 5.3.9.3 Information initiating the dyanic allocation and control of simulation entities         between two simulation applications. Requires manual cleanup. The padding between record sets is variable. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(RecordSet))]
    public partial class TransferControlRequestPdu : EntityManagementFamilyPdu, IEquatable<TransferControlRequestPdu>
    {
        /// <summary>
        /// ID of entity originating request
        /// </summary>
        private EntityID _orginatingEntityID = new EntityID();

        /// <summary>
        /// ID of entity receiving request
        /// </summary>
        private EntityID _recevingEntityID = new EntityID();

        /// <summary>
        /// ID ofrequest
        /// </summary>
        private uint _requestID;

        /// <summary>
        /// required level of reliabliity service.
        /// </summary>
        private byte _requiredReliabilityService;

        /// <summary>
        /// type of transfer desired
        /// </summary>
        private byte _tranferType;

        /// <summary>
        /// The entity for which control is being requested to transfer
        /// </summary>
        private EntityID _transferEntityID = new EntityID();

        /// <summary>
        /// number of record sets to transfer
        /// </summary>
        private byte _numberOfRecordSets;

        /// <summary>
        /// ^^^This is wrong--the RecordSet class needs more work
        /// </summary>
        private List<RecordSet> _recordSets = new List<RecordSet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferControlRequestPdu"/> class.
        /// </summary>
        public TransferControlRequestPdu()
        {
            PduType = (byte)35;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(TransferControlRequestPdu left, TransferControlRequestPdu right)
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
        public static bool operator ==(TransferControlRequestPdu left, TransferControlRequestPdu right)
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

        public override int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.GetMarshalledSize();
            marshalSize += this._orginatingEntityID.GetMarshalledSize();  // this._orginatingEntityID
            marshalSize += this._recevingEntityID.GetMarshalledSize();  // this._recevingEntityID
            marshalSize += 4;  // this._requestID
            marshalSize += 1;  // this._requiredReliabilityService
            marshalSize += 1;  // this._tranferType
            marshalSize += this._transferEntityID.GetMarshalledSize();  // this._transferEntityID
            marshalSize += 1;  // this._numberOfRecordSets
            for (int idx = 0; idx < this._recordSets.Count; idx++)
            {
                RecordSet listElement = (RecordSet)this._recordSets[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of entity originating request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
        public EntityID OrginatingEntityID
        {
            get
            {
                return this._orginatingEntityID;
            }

            set
            {
                this._orginatingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of entity receiving request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "recevingEntityID")]
        public EntityID RecevingEntityID
        {
            get
            {
                return this._recevingEntityID;
            }

            set
            {
                this._recevingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID ofrequest
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID
        {
            get
            {
                return this._requestID;
            }

            set
            {
                this._requestID = value;
            }
        }

        /// <summary>
        /// Gets or sets the required level of reliabliity service.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
        public byte RequiredReliabilityService
        {
            get
            {
                return this._requiredReliabilityService;
            }

            set
            {
                this._requiredReliabilityService = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of transfer desired
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "tranferType")]
        public byte TranferType
        {
            get
            {
                return this._tranferType;
            }

            set
            {
                this._tranferType = value;
            }
        }

        /// <summary>
        /// Gets or sets the The entity for which control is being requested to transfer
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "transferEntityID")]
        public EntityID TransferEntityID
        {
            get
            {
                return this._transferEntityID;
            }

            set
            {
                this._transferEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of record sets to transfer
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfRecordSets")]
        public byte NumberOfRecordSets
        {
            get
            {
                return this._numberOfRecordSets;
            }

            set
            {
                this._numberOfRecordSets = value;
            }
        }

        /// <summary>
        /// Gets the ^^^This is wrong--the RecordSet class needs more work
        /// </summary>
        [XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
        public List<RecordSet> RecordSets
        {
            get
            {
                return this._recordSets;
            }
        }

        /// <summary>
        /// Automatically sets the length of the marshalled data, then calls the marshal method.
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            this.Length = (ushort)this.GetMarshalledSize();
            this.Marshal(dos);
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    this._orginatingEntityID.Marshal(dos);
                    this._recevingEntityID.Marshal(dos);
                    dos.WriteUnsignedInt((uint)this._requestID);
                    dos.WriteUnsignedByte((byte)this._requiredReliabilityService);
                    dos.WriteUnsignedByte((byte)this._tranferType);
                    this._transferEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._recordSets.Count);

                    for (int idx = 0; idx < this._recordSets.Count; idx++)
                    {
                        RecordSet aRecordSet = (RecordSet)this._recordSets[idx];
                        aRecordSet.Marshal(dos);
                    }
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
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    this._orginatingEntityID.Unmarshal(dis);
                    this._recevingEntityID.Unmarshal(dis);
                    this._requestID = dis.ReadUnsignedInt();
                    this._requiredReliabilityService = dis.ReadUnsignedByte();
                    this._tranferType = dis.ReadUnsignedByte();
                    this._transferEntityID.Unmarshal(dis);
                    this._numberOfRecordSets = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.NumberOfRecordSets; idx++)
                    {
                        RecordSet anX = new RecordSet();
                        anX.Unmarshal(dis);
                        this._recordSets.Add(anX);
                    }
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
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<TransferControlRequestPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                this._orginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<recevingEntityID>");
                this._recevingEntityID.Reflection(sb);
                sb.AppendLine("</recevingEntityID>");
                sb.AppendLine("<requestID type=\"uint\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requiredReliabilityService type=\"byte\">" + this._requiredReliabilityService.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
                sb.AppendLine("<tranferType type=\"byte\">" + this._tranferType.ToString(CultureInfo.InvariantCulture) + "</tranferType>");
                sb.AppendLine("<transferEntityID>");
                this._transferEntityID.Reflection(sb);
                sb.AppendLine("</transferEntityID>");
                sb.AppendLine("<recordSets type=\"byte\">" + this._recordSets.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
                for (int idx = 0; idx < this._recordSets.Count; idx++)
                {
                    sb.AppendLine("<recordSets" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
                    RecordSet aRecordSet = (RecordSet)this._recordSets[idx];
                    aRecordSet.Reflection(sb);
                    sb.AppendLine("</recordSets" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</TransferControlRequestPdu>");
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
            return this == obj as TransferControlRequestPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(TransferControlRequestPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._orginatingEntityID.Equals(obj._orginatingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._recevingEntityID.Equals(obj._recevingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._requestID != obj._requestID)
            {
                ivarsEqual = false;
            }

            if (this._requiredReliabilityService != obj._requiredReliabilityService)
            {
                ivarsEqual = false;
            }

            if (this._tranferType != obj._tranferType)
            {
                ivarsEqual = false;
            }

            if (!this._transferEntityID.Equals(obj._transferEntityID))
            {
                ivarsEqual = false;
            }

            if (this._numberOfRecordSets != obj._numberOfRecordSets)
            {
                ivarsEqual = false;
            }

            if (this._recordSets.Count != obj._recordSets.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._recordSets.Count; idx++)
                {
                    if (!this._recordSets[idx].Equals(obj._recordSets[idx]))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ this._orginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._recevingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._requiredReliabilityService.GetHashCode();
            result = GenerateHash(result) ^ this._tranferType.GetHashCode();
            result = GenerateHash(result) ^ this._transferEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfRecordSets.GetHashCode();

            if (this._recordSets.Count > 0)
            {
                for (int idx = 0; idx < this._recordSets.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._recordSets[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
