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
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// Section 5.3.9.4 The joining of two or more simulation entities is communicated by this PDU. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(Relationship))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(NamedLocation))]
    [XmlInclude(typeof(EntityType))]
    public partial class IsPartOfPdu : EntityManagementFamilyPdu, IEquatable<IsPartOfPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsPartOfPdu"/> class.
        /// </summary>
        public IsPartOfPdu()
        {
            PduType = 36;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IsPartOfPdu left, IsPartOfPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IsPartOfPdu left, IsPartOfPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += OrginatingEntityID.GetMarshalledSize();  // this._orginatingEntityID
            marshalSize += ReceivingEntityID.GetMarshalledSize();  // this._receivingEntityID
            marshalSize += Relationship.GetMarshalledSize();  // this._relationship
            marshalSize += PartLocation.GetMarshalledSize();  // this._partLocation
            marshalSize += NamedLocationID.GetMarshalledSize();  // this._namedLocationID
            marshalSize += PartEntityType.GetMarshalledSize();  // this._partEntityType
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of entity originating PDU
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
        public EntityID OrginatingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of entity receiving PDU
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
        public EntityID ReceivingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the relationship of joined parts
        /// </summary>
        [XmlElement(Type = typeof(Relationship), ElementName = "relationship")]
        public Relationship Relationship { get; set; } = new Relationship();

        /// <summary>
        /// Gets or sets the location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "partLocation")]
        public Vector3Float PartLocation { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the named location
        /// </summary>
        [XmlElement(Type = typeof(NamedLocation), ElementName = "namedLocationID")]
        public NamedLocation NamedLocationID { get; set; } = new NamedLocation();

        /// <summary>
        /// Gets or sets the entity type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "partEntityType")]
        public EntityType PartEntityType { get; set; } = new EntityType();

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
                    ReceivingEntityID.Marshal(dos);
                    Relationship.Marshal(dos);
                    PartLocation.Marshal(dos);
                    NamedLocationID.Marshal(dos);
                    PartEntityType.Marshal(dos);
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
                    ReceivingEntityID.Unmarshal(dis);
                    Relationship.Unmarshal(dis);
                    PartLocation.Unmarshal(dis);
                    NamedLocationID.Unmarshal(dis);
                    PartEntityType.Unmarshal(dis);
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
            sb.AppendLine("<IsPartOfPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                OrginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<receivingEntityID>");
                ReceivingEntityID.Reflection(sb);
                sb.AppendLine("</receivingEntityID>");
                sb.AppendLine("<relationship>");
                Relationship.Reflection(sb);
                sb.AppendLine("</relationship>");
                sb.AppendLine("<partLocation>");
                PartLocation.Reflection(sb);
                sb.AppendLine("</partLocation>");
                sb.AppendLine("<namedLocationID>");
                NamedLocationID.Reflection(sb);
                sb.AppendLine("</namedLocationID>");
                sb.AppendLine("<partEntityType>");
                PartEntityType.Reflection(sb);
                sb.AppendLine("</partEntityType>");
                sb.AppendLine("</IsPartOfPdu>");
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
        public override bool Equals(object obj) => this == obj as IsPartOfPdu;

        ///<inheritdoc/>
        public bool Equals(IsPartOfPdu obj)
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

            if (!ReceivingEntityID.Equals(obj.ReceivingEntityID))
            {
                ivarsEqual = false;
            }

            if (!Relationship.Equals(obj.Relationship))
            {
                ivarsEqual = false;
            }

            if (!PartLocation.Equals(obj.PartLocation))
            {
                ivarsEqual = false;
            }

            if (!NamedLocationID.Equals(obj.NamedLocationID))
            {
                ivarsEqual = false;
            }

            if (!PartEntityType.Equals(obj.PartEntityType))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ OrginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ ReceivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ Relationship.GetHashCode();
            result = GenerateHash(result) ^ PartLocation.GetHashCode();
            result = GenerateHash(result) ^ NamedLocationID.GetHashCode();
            result = GenerateHash(result) ^ PartEntityType.GetHashCode();

            return result;
        }
    }
}
