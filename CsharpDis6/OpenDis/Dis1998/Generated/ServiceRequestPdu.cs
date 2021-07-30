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
    /// Section 5.3.5.1. Information about a request for supplies. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(SupplyQuantity))]
    public partial class ServiceRequestPdu : LogisticsFamilyPdu, IEquatable<ServiceRequestPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRequestPdu"/> class.
        /// </summary>
        public ServiceRequestPdu()
        {
            PduType = 5;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ServiceRequestPdu left, ServiceRequestPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ServiceRequestPdu left, ServiceRequestPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += RequestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += ServicingEntityID.GetMarshalledSize();  // this._servicingEntityID
            marshalSize += 1;  // this._serviceTypeRequested
            marshalSize += 1;  // this._numberOfSupplyTypes
            marshalSize += 2;  // this._serviceRequestPadding
            for (int idx = 0; idx < Supplies.Count; idx++)
            {
                var listElement = Supplies[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Entity that is requesting service
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Entity that is providing the service
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "servicingEntityID")]
        public EntityID ServicingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the type of service requested
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "serviceTypeRequested")]
        public byte ServiceTypeRequested { get; set; }

        /// <summary>
        /// Gets or sets the How many requested
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfSupplyTypes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
        public byte NumberOfSupplyTypes { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "serviceRequestPadding")]
        public short ServiceRequestPadding { get; set; }

        /// <summary>
        /// Gets the supplies
        /// </summary>
        [XmlElement(ElementName = "suppliesList", Type = typeof(List<SupplyQuantity>))]
        public List<SupplyQuantity> Supplies { get; } = new();

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
                    RequestingEntityID.Marshal(dos);
                    ServicingEntityID.Marshal(dos);
                    dos.WriteUnsignedByte(ServiceTypeRequested);
                    dos.WriteUnsignedByte((byte)Supplies.Count);
                    dos.WriteShort(ServiceRequestPadding);

                    for (int idx = 0; idx < Supplies.Count; idx++)
                    {
                        var aSupplyQuantity = Supplies[idx];
                        aSupplyQuantity.Marshal(dos);
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
                    RequestingEntityID.Unmarshal(dis);
                    ServicingEntityID.Unmarshal(dis);
                    ServiceTypeRequested = dis.ReadUnsignedByte();
                    NumberOfSupplyTypes = dis.ReadUnsignedByte();
                    ServiceRequestPadding = dis.ReadShort();

                    for (int idx = 0; idx < NumberOfSupplyTypes; idx++)
                    {
                        var anX = new SupplyQuantity();
                        anX.Unmarshal(dis);
                        Supplies.Add(anX);
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
            sb.AppendLine("<ServiceRequestPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestingEntityID>");
                RequestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<servicingEntityID>");
                ServicingEntityID.Reflection(sb);
                sb.AppendLine("</servicingEntityID>");
                sb.AppendLine("<serviceTypeRequested type=\"byte\">" + ServiceTypeRequested.ToString(CultureInfo.InvariantCulture) + "</serviceTypeRequested>");
                sb.AppendLine("<supplies type=\"byte\">" + Supplies.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
                sb.AppendLine("<serviceRequestPadding type=\"short\">" + ServiceRequestPadding.ToString(CultureInfo.InvariantCulture) + "</serviceRequestPadding>");
                for (int idx = 0; idx < Supplies.Count; idx++)
                {
                    sb.AppendLine("<supplies" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
                    var aSupplyQuantity = Supplies[idx];
                    aSupplyQuantity.Reflection(sb);
                    sb.AppendLine("</supplies" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ServiceRequestPdu>");
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
        public override bool Equals(object obj) => this == obj as ServiceRequestPdu;

        ///<inheritdoc/>
        public bool Equals(ServiceRequestPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!RequestingEntityID.Equals(obj.RequestingEntityID))
            {
                ivarsEqual = false;
            }

            if (!ServicingEntityID.Equals(obj.ServicingEntityID))
            {
                ivarsEqual = false;
            }

            if (ServiceTypeRequested != obj.ServiceTypeRequested)
            {
                ivarsEqual = false;
            }

            if (NumberOfSupplyTypes != obj.NumberOfSupplyTypes)
            {
                ivarsEqual = false;
            }

            if (ServiceRequestPadding != obj.ServiceRequestPadding)
            {
                ivarsEqual = false;
            }

            if (Supplies.Count != obj.Supplies.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < Supplies.Count; idx++)
                {
                    if (!Supplies[idx].Equals(obj.Supplies[idx]))
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

            result = GenerateHash(result) ^ RequestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ ServicingEntityID.GetHashCode();
            result = GenerateHash(result) ^ ServiceTypeRequested.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSupplyTypes.GetHashCode();
            result = GenerateHash(result) ^ ServiceRequestPadding.GetHashCode();

            if (Supplies.Count > 0)
            {
                for (int idx = 0; idx < Supplies.Count; idx++)
                {
                    result = GenerateHash(result) ^ Supplies[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
