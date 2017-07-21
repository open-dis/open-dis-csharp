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
        /// ID of entity originating PDU
        /// </summary>
        private EntityID _orginatingEntityID = new EntityID();

        /// <summary>
        /// ID of entity receiving PDU
        /// </summary>
        private EntityID _receivingEntityID = new EntityID();

        /// <summary>
        /// relationship of joined parts
        /// </summary>
        private Relationship _relationship = new Relationship();

        /// <summary>
        /// location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        /// </summary>
        private Vector3Float _partLocation = new Vector3Float();

        /// <summary>
        /// named location
        /// </summary>
        private NamedLocation _namedLocationID = new NamedLocation();

        /// <summary>
        /// entity type
        /// </summary>
        private EntityType _partEntityType = new EntityType();

        /// <summary>
        /// Initializes a new instance of the <see cref="IsPartOfPdu"/> class.
        /// </summary>
        public IsPartOfPdu()
        {
            PduType = (byte)36;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IsPartOfPdu left, IsPartOfPdu right)
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
        public static bool operator ==(IsPartOfPdu left, IsPartOfPdu right)
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
            marshalSize += this._receivingEntityID.GetMarshalledSize();  // this._receivingEntityID
            marshalSize += this._relationship.GetMarshalledSize();  // this._relationship
            marshalSize += this._partLocation.GetMarshalledSize();  // this._partLocation
            marshalSize += this._namedLocationID.GetMarshalledSize();  // this._namedLocationID
            marshalSize += this._partEntityType.GetMarshalledSize();  // this._partEntityType
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of entity originating PDU
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
        /// Gets or sets the ID of entity receiving PDU
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
        /// Gets or sets the relationship of joined parts
        /// </summary>
        [XmlElement(Type = typeof(Relationship), ElementName = "relationship")]
        public Relationship Relationship
        {
            get
            {
                return this._relationship;
            }

            set
            {
                this._relationship = value;
            }
        }

        /// <summary>
        /// Gets or sets the location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "partLocation")]
        public Vector3Float PartLocation
        {
            get
            {
                return this._partLocation;
            }

            set
            {
                this._partLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the named location
        /// </summary>
        [XmlElement(Type = typeof(NamedLocation), ElementName = "namedLocationID")]
        public NamedLocation NamedLocationID
        {
            get
            {
                return this._namedLocationID;
            }

            set
            {
                this._namedLocationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "partEntityType")]
        public EntityType PartEntityType
        {
            get
            {
                return this._partEntityType;
            }

            set
            {
                this._partEntityType = value;
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
                    this._receivingEntityID.Marshal(dos);
                    this._relationship.Marshal(dos);
                    this._partLocation.Marshal(dos);
                    this._namedLocationID.Marshal(dos);
                    this._partEntityType.Marshal(dos);
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
                    this._receivingEntityID.Unmarshal(dis);
                    this._relationship.Unmarshal(dis);
                    this._partLocation.Unmarshal(dis);
                    this._namedLocationID.Unmarshal(dis);
                    this._partEntityType.Unmarshal(dis);
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
            sb.AppendLine("<IsPartOfPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                this._orginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<receivingEntityID>");
                this._receivingEntityID.Reflection(sb);
                sb.AppendLine("</receivingEntityID>");
                sb.AppendLine("<relationship>");
                this._relationship.Reflection(sb);
                sb.AppendLine("</relationship>");
                sb.AppendLine("<partLocation>");
                this._partLocation.Reflection(sb);
                sb.AppendLine("</partLocation>");
                sb.AppendLine("<namedLocationID>");
                this._namedLocationID.Reflection(sb);
                sb.AppendLine("</namedLocationID>");
                sb.AppendLine("<partEntityType>");
                this._partEntityType.Reflection(sb);
                sb.AppendLine("</partEntityType>");
                sb.AppendLine("</IsPartOfPdu>");
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
            return this == obj as IsPartOfPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IsPartOfPdu obj)
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

            if (!this._receivingEntityID.Equals(obj._receivingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._relationship.Equals(obj._relationship))
            {
                ivarsEqual = false;
            }

            if (!this._partLocation.Equals(obj._partLocation))
            {
                ivarsEqual = false;
            }

            if (!this._namedLocationID.Equals(obj._namedLocationID))
            {
                ivarsEqual = false;
            }

            if (!this._partEntityType.Equals(obj._partEntityType))
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
            result = GenerateHash(result) ^ this._receivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._relationship.GetHashCode();
            result = GenerateHash(result) ^ this._partLocation.GetHashCode();
            result = GenerateHash(result) ^ this._namedLocationID.GetHashCode();
            result = GenerateHash(result) ^ this._partEntityType.GetHashCode();

            return result;
        }
    }
}
