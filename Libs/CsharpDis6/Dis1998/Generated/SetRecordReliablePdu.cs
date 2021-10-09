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
    /// Section 5.3.12.14: Initializing or changing internal parameter info. Needs manual intervention     to fix padding in recrod set PDUs. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(RecordSet))]
    public partial class SetRecordReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<SetRecordReliablePdu>
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
        /// Number of record sets in list
        /// </summary>
        private uint _numberOfRecordSets;

        /// <summary>
        /// record sets
        /// </summary>
        private List<RecordSet> _recordSets = new List<RecordSet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SetRecordReliablePdu"/> class.
        /// </summary>
        public SetRecordReliablePdu()
        {
            PduType = (byte)64;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SetRecordReliablePdu left, SetRecordReliablePdu right)
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
        public static bool operator ==(SetRecordReliablePdu left, SetRecordReliablePdu right)
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
            marshalSize += 4;  // this._numberOfRecordSets
            for (int idx = 0; idx < this._recordSets.Count; idx++)
            {
                RecordSet listElement = (RecordSet)this._recordSets[idx];
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
        /// Gets or sets the Number of record sets in list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfRecordSets")]
        public uint NumberOfRecordSets
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
        /// Gets the record sets
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
                    dos.WriteUnsignedInt((uint)this._requestID);
                    dos.WriteUnsignedByte((byte)this._requiredReliabilityService);
                    dos.WriteUnsignedShort((ushort)this._pad1);
                    dos.WriteUnsignedByte((byte)this._pad2);
                    dos.WriteUnsignedInt((uint)this._recordSets.Count);

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
                    this._requestID = dis.ReadUnsignedInt();
                    this._requiredReliabilityService = dis.ReadUnsignedByte();
                    this._pad1 = dis.ReadUnsignedShort();
                    this._pad2 = dis.ReadUnsignedByte();
                    this._numberOfRecordSets = dis.ReadUnsignedInt();

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
            sb.AppendLine("<SetRecordReliablePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestID type=\"uint\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requiredReliabilityService type=\"byte\">" + this._requiredReliabilityService.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
                sb.AppendLine("<pad1 type=\"ushort\">" + this._pad1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
                sb.AppendLine("<pad2 type=\"byte\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<recordSets type=\"uint\">" + this._recordSets.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
                for (int idx = 0; idx < this._recordSets.Count; idx++)
                {
                    sb.AppendLine("<recordSets" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
                    RecordSet aRecordSet = (RecordSet)this._recordSets[idx];
                    aRecordSet.Reflection(sb);
                    sb.AppendLine("</recordSets" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</SetRecordReliablePdu>");
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
            return this == obj as SetRecordReliablePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SetRecordReliablePdu obj)
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

            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._requiredReliabilityService.GetHashCode();
            result = GenerateHash(result) ^ this._pad1.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
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
