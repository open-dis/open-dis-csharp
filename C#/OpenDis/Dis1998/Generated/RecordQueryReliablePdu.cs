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
        /// request ID
        /// </summary>
        private uint _requestID;

        /// <summary>
        /// level of reliability service used for this transaction
        /// </summary>
        private byte _requiredReliabilityService;

        /// <summary>
        /// padding. The spec is unclear and contradictory here.
        /// </summary>
        private ushort _pad1;

        /// <summary>
        /// padding
        /// </summary>
        private byte _pad2;

        /// <summary>
        /// event type
        /// </summary>
        private ushort _eventType;

        /// <summary>
        /// time
        /// </summary>
        private uint _time;

        /// <summary>
        /// numberOfRecords
        /// </summary>
        private uint _numberOfRecords;

        /// <summary>
        /// record IDs
        /// </summary>
        private List<FourByteChunk> _recordIDs = new List<FourByteChunk>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordQueryReliablePdu"/> class.
        /// </summary>
        public RecordQueryReliablePdu()
        {
            PduType = (byte)63;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RecordQueryReliablePdu left, RecordQueryReliablePdu right)
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
        public static bool operator ==(RecordQueryReliablePdu left, RecordQueryReliablePdu right)
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
            marshalSize += 4;  // this._requestID
            marshalSize += 1;  // this._requiredReliabilityService
            marshalSize += 2;  // this._pad1
            marshalSize += 1;  // this._pad2
            marshalSize += 2;  // this._eventType
            marshalSize += 4;  // this._time
            marshalSize += 4;  // this._numberOfRecords
            for (int idx = 0; idx < this._recordIDs.Count; idx++)
            {
                FourByteChunk listElement = (FourByteChunk)this._recordIDs[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the request ID
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
        /// Gets or sets the level of reliability service used for this transaction
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
        /// Gets or sets the padding. The spec is unclear and contradictory here.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad1")]
        public ushort Pad1
        {
            get
            {
                return this._pad1;
            }

            set
            {
                this._pad1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2
        {
            get
            {
                return this._pad2;
            }

            set
            {
                this._pad2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "eventType")]
        public ushort EventType
        {
            get
            {
                return this._eventType;
            }

            set
            {
                this._eventType = value;
            }
        }

        /// <summary>
        /// Gets or sets the time
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "time")]
        public uint Time
        {
            get
            {
                return this._time;
            }

            set
            {
                this._time = value;
            }
        }

        /// <summary>
        /// Gets or sets the numberOfRecords
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
        public uint NumberOfRecords
        {
            get
            {
                return this._numberOfRecords;
            }

            set
            {
                this._numberOfRecords = value;
            }
        }

        /// <summary>
        /// Gets the record IDs
        /// </summary>
        [XmlElement(ElementName = "recordIDsList", Type = typeof(List<FourByteChunk>))]
        public List<FourByteChunk> RecordIDs
        {
            get
            {
                return this._recordIDs;
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
                    dos.WriteUnsignedInt((uint)this._requestID);
                    dos.WriteUnsignedByte((byte)this._requiredReliabilityService);
                    dos.WriteUnsignedShort((ushort)this._pad1);
                    dos.WriteUnsignedByte((byte)this._pad2);
                    dos.WriteUnsignedShort((ushort)this._eventType);
                    dos.WriteUnsignedInt((uint)this._time);
                    dos.WriteUnsignedInt((uint)this._recordIDs.Count);

                    for (int idx = 0; idx < this._recordIDs.Count; idx++)
                    {
                        FourByteChunk aFourByteChunk = (FourByteChunk)this._recordIDs[idx];
                        aFourByteChunk.Marshal(dos);
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
                    this._requestID = dis.ReadUnsignedInt();
                    this._requiredReliabilityService = dis.ReadUnsignedByte();
                    this._pad1 = dis.ReadUnsignedShort();
                    this._pad2 = dis.ReadUnsignedByte();
                    this._eventType = dis.ReadUnsignedShort();
                    this._time = dis.ReadUnsignedInt();
                    this._numberOfRecords = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < this.NumberOfRecords; idx++)
                    {
                        FourByteChunk anX = new FourByteChunk();
                        anX.Unmarshal(dis);
                        this._recordIDs.Add(anX);
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
            sb.AppendLine("<RecordQueryReliablePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestID type=\"uint\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requiredReliabilityService type=\"byte\">" + this._requiredReliabilityService.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
                sb.AppendLine("<pad1 type=\"ushort\">" + this._pad1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
                sb.AppendLine("<pad2 type=\"byte\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<eventType type=\"ushort\">" + this._eventType.ToString(CultureInfo.InvariantCulture) + "</eventType>");
                sb.AppendLine("<time type=\"uint\">" + this._time.ToString(CultureInfo.InvariantCulture) + "</time>");
                sb.AppendLine("<recordIDs type=\"uint\">" + this._recordIDs.Count.ToString(CultureInfo.InvariantCulture) + "</recordIDs>");
                for (int idx = 0; idx < this._recordIDs.Count; idx++)
                {
                    sb.AppendLine("<recordIDs" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
                    FourByteChunk aFourByteChunk = (FourByteChunk)this._recordIDs[idx];
                    aFourByteChunk.Reflection(sb);
                    sb.AppendLine("</recordIDs" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</RecordQueryReliablePdu>");
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
            return this == obj as RecordQueryReliablePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(RecordQueryReliablePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._requestID != obj._requestID)
            {
                ivarsEqual = false;
            }

            if (this._requiredReliabilityService != obj._requiredReliabilityService)
            {
                ivarsEqual = false;
            }

            if (this._pad1 != obj._pad1)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (this._eventType != obj._eventType)
            {
                ivarsEqual = false;
            }

            if (this._time != obj._time)
            {
                ivarsEqual = false;
            }

            if (this._numberOfRecords != obj._numberOfRecords)
            {
                ivarsEqual = false;
            }

            if (this._recordIDs.Count != obj._recordIDs.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._recordIDs.Count; idx++)
                {
                    if (!this._recordIDs[idx].Equals(obj._recordIDs[idx]))
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

            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._requiredReliabilityService.GetHashCode();
            result = GenerateHash(result) ^ this._pad1.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._eventType.GetHashCode();
            result = GenerateHash(result) ^ this._time.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfRecords.GetHashCode();

            if (this._recordIDs.Count > 0)
            {
                for (int idx = 0; idx < this._recordIDs.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._recordIDs[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
