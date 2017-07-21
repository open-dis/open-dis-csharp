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
    /// Section 5.3.5.3. Receipt of supplies is communiated. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(SupplyQuantity))]
    public partial class ResupplyReceivedPdu : LogisticsFamilyPdu, IEquatable<ResupplyReceivedPdu>
    {
        /// <summary>
        /// Entity that is receiving service
        /// </summary>
        private EntityID _receivingEntityID = new EntityID();

        /// <summary>
        /// Entity that is supplying
        /// </summary>
        private EntityID _supplyingEntityID = new EntityID();

        /// <summary>
        /// how many supplies are being offered
        /// </summary>
        private byte _numberOfSupplyTypes;

        /// <summary>
        /// padding
        /// </summary>
        private short _padding1;

        /// <summary>
        /// padding
        /// </summary>
        private byte _padding2;

        private List<SupplyQuantity> _supplies = new List<SupplyQuantity>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ResupplyReceivedPdu"/> class.
        /// </summary>
        public ResupplyReceivedPdu()
        {
            PduType = (byte)7;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ResupplyReceivedPdu left, ResupplyReceivedPdu right)
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
        public static bool operator ==(ResupplyReceivedPdu left, ResupplyReceivedPdu right)
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
            marshalSize += this._receivingEntityID.GetMarshalledSize();  // this._receivingEntityID
            marshalSize += this._supplyingEntityID.GetMarshalledSize();  // this._supplyingEntityID
            marshalSize += 1;  // this._numberOfSupplyTypes
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            for (int idx = 0; idx < this._supplies.Count; idx++)
            {
                SupplyQuantity listElement = (SupplyQuantity)this._supplies[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Entity that is receiving service
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
        public EntityID ReceivingEntityID
        {
            get
            {
                return this._receivingEntityID;
            }

            set
            {
                this._receivingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Entity that is supplying
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "supplyingEntityID")]
        public EntityID SupplyingEntityID
        {
            get
            {
                return this._supplyingEntityID;
            }

            set
            {
                this._supplyingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many supplies are being offered
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSupplyTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
        public byte NumberOfSupplyTypes
        {
            get
            {
                return this._numberOfSupplyTypes;
            }

            set
            {
                this._numberOfSupplyTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding1")]
        public short Padding1
        {
            get
            {
                return this._padding1;
            }

            set
            {
                this._padding1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2
        {
            get
            {
                return this._padding2;
            }

            set
            {
                this._padding2 = value;
            }
        }

        /// <summary>
        /// Gets the supplies
        /// </summary>
        [XmlElement(ElementName = "suppliesList", Type = typeof(List<SupplyQuantity>))]
        public List<SupplyQuantity> Supplies
        {
            get
            {
                return this._supplies;
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
                    this._receivingEntityID.Marshal(dos);
                    this._supplyingEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._supplies.Count);
                    dos.WriteShort((short)this._padding1);
                    dos.WriteByte((byte)this._padding2);

                    for (int idx = 0; idx < this._supplies.Count; idx++)
                    {
                        SupplyQuantity aSupplyQuantity = (SupplyQuantity)this._supplies[idx];
                        aSupplyQuantity.Marshal(dos);
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
                    this._receivingEntityID.Unmarshal(dis);
                    this._supplyingEntityID.Unmarshal(dis);
                    this._numberOfSupplyTypes = dis.ReadUnsignedByte();
                    this._padding1 = dis.ReadShort();
                    this._padding2 = dis.ReadByte();

                    for (int idx = 0; idx < this.NumberOfSupplyTypes; idx++)
                    {
                        SupplyQuantity anX = new SupplyQuantity();
                        anX.Unmarshal(dis);
                        this._supplies.Add(anX);
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
            sb.AppendLine("<ResupplyReceivedPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<receivingEntityID>");
                this._receivingEntityID.Reflection(sb);
                sb.AppendLine("</receivingEntityID>");
                sb.AppendLine("<supplyingEntityID>");
                this._supplyingEntityID.Reflection(sb);
                sb.AppendLine("</supplyingEntityID>");
                sb.AppendLine("<supplies type=\"byte\">" + this._supplies.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
                sb.AppendLine("<padding1 type=\"short\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                for (int idx = 0; idx < this._supplies.Count; idx++)
                {
                    sb.AppendLine("<supplies" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
                    SupplyQuantity aSupplyQuantity = (SupplyQuantity)this._supplies[idx];
                    aSupplyQuantity.Reflection(sb);
                    sb.AppendLine("</supplies" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ResupplyReceivedPdu>");
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
            return this == obj as ResupplyReceivedPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ResupplyReceivedPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._receivingEntityID.Equals(obj._receivingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._supplyingEntityID.Equals(obj._supplyingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._numberOfSupplyTypes != obj._numberOfSupplyTypes)
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (this._supplies.Count != obj._supplies.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._supplies.Count; idx++)
                {
                    if (!this._supplies[idx].Equals(obj._supplies[idx]))
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

            result = GenerateHash(result) ^ this._receivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._supplyingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSupplyTypes.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();

            if (this._supplies.Count > 0)
            {
                for (int idx = 0; idx < this._supplies.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._supplies[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
