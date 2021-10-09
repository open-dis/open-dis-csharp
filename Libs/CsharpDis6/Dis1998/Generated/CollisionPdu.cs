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
    /// Section 5.3.3.2. Information about a collision. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class CollisionPdu : EntityInformationFamilyPdu, IEquatable<CollisionPdu>
    {
        /// <summary>
        /// ID of the entity that issued the collision PDU
        /// </summary>
        private EntityID _issuingEntityID = new EntityID();

        /// <summary>
        /// ID of entity that has collided with the issuing entity ID
        /// </summary>
        private EntityID _collidingEntityID = new EntityID();

        /// <summary>
        /// ID of event
        /// </summary>
        private EventID _eventID = new EventID();

        /// <summary>
        /// ID of event
        /// </summary>
        private byte _collisionType;

        /// <summary>
        /// some padding
        /// </summary>
        private byte _pad;

        /// <summary>
        /// velocity at collision
        /// </summary>
        private Vector3Float _velocity = new Vector3Float();

        /// <summary>
        /// mass of issuing entity
        /// </summary>
        private float _mass;

        /// <summary>
        /// Location with respect to entity the issuing entity collided with
        /// </summary>
        private Vector3Float _location = new Vector3Float();

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionPdu"/> class.
        /// </summary>
        public CollisionPdu()
        {
            PduType = (byte)4;
            ProtocolFamily = (byte)1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(CollisionPdu left, CollisionPdu right)
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
        public static bool operator ==(CollisionPdu left, CollisionPdu right)
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
            marshalSize += this._issuingEntityID.GetMarshalledSize();  // this._issuingEntityID
            marshalSize += this._collidingEntityID.GetMarshalledSize();  // this._collidingEntityID
            marshalSize += this._eventID.GetMarshalledSize();  // this._eventID
            marshalSize += 1;  // this._collisionType
            marshalSize += 1;  // this._pad
            marshalSize += this._velocity.GetMarshalledSize();  // this._velocity
            marshalSize += 4;  // this._mass
            marshalSize += this._location.GetMarshalledSize();  // this._location
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity that issued the collision PDU
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "issuingEntityID")]
        public EntityID IssuingEntityID
        {
            get
            {
                return this._issuingEntityID;
            }

            set
            {
                this._issuingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of entity that has collided with the issuing entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "collidingEntityID")]
        public EntityID CollidingEntityID
        {
            get
            {
                return this._collidingEntityID;
            }

            set
            {
                this._collidingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID
        {
            get
            {
                return this._eventID;
            }

            set
            {
                this._eventID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "collisionType")]
        public byte CollisionType
        {
            get
            {
                return this._collisionType;
            }

            set
            {
                this._collisionType = value;
            }
        }

        /// <summary>
        /// Gets or sets the some padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad")]
        public byte Pad
        {
            get
            {
                return this._pad;
            }

            set
            {
                this._pad = value;
            }
        }

        /// <summary>
        /// Gets or sets the velocity at collision
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity
        {
            get
            {
                return this._velocity;
            }

            set
            {
                this._velocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the mass of issuing entity
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "mass")]
        public float Mass
        {
            get
            {
                return this._mass;
            }

            set
            {
                this._mass = value;
            }
        }

        /// <summary>
        /// Gets or sets the Location with respect to entity the issuing entity collided with
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location
        {
            get
            {
                return this._location;
            }

            set
            {
                this._location = value;
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
                    this._issuingEntityID.Marshal(dos);
                    this._collidingEntityID.Marshal(dos);
                    this._eventID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._collisionType);
                    dos.WriteByte((byte)this._pad);
                    this._velocity.Marshal(dos);
                    dos.WriteFloat((float)this._mass);
                    this._location.Marshal(dos);
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
                    this._issuingEntityID.Unmarshal(dis);
                    this._collidingEntityID.Unmarshal(dis);
                    this._eventID.Unmarshal(dis);
                    this._collisionType = dis.ReadUnsignedByte();
                    this._pad = dis.ReadByte();
                    this._velocity.Unmarshal(dis);
                    this._mass = dis.ReadFloat();
                    this._location.Unmarshal(dis);
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
            sb.AppendLine("<CollisionPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<issuingEntityID>");
                this._issuingEntityID.Reflection(sb);
                sb.AppendLine("</issuingEntityID>");
                sb.AppendLine("<collidingEntityID>");
                this._collidingEntityID.Reflection(sb);
                sb.AppendLine("</collidingEntityID>");
                sb.AppendLine("<eventID>");
                this._eventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<collisionType type=\"byte\">" + this._collisionType.ToString(CultureInfo.InvariantCulture) + "</collisionType>");
                sb.AppendLine("<pad type=\"byte\">" + this._pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<velocity>");
                this._velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<mass type=\"float\">" + this._mass.ToString(CultureInfo.InvariantCulture) + "</mass>");
                sb.AppendLine("<location>");
                this._location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("</CollisionPdu>");
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
            return this == obj as CollisionPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CollisionPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._issuingEntityID.Equals(obj._issuingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._collidingEntityID.Equals(obj._collidingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._eventID.Equals(obj._eventID))
            {
                ivarsEqual = false;
            }

            if (this._collisionType != obj._collisionType)
            {
                ivarsEqual = false;
            }

            if (this._pad != obj._pad)
            {
                ivarsEqual = false;
            }

            if (!this._velocity.Equals(obj._velocity))
            {
                ivarsEqual = false;
            }

            if (this._mass != obj._mass)
            {
                ivarsEqual = false;
            }

            if (!this._location.Equals(obj._location))
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

            result = GenerateHash(result) ^ this._issuingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._collidingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._eventID.GetHashCode();
            result = GenerateHash(result) ^ this._collisionType.GetHashCode();
            result = GenerateHash(result) ^ this._pad.GetHashCode();
            result = GenerateHash(result) ^ this._velocity.GetHashCode();
            result = GenerateHash(result) ^ this._mass.GetHashCode();
            result = GenerateHash(result) ^ this._location.GetHashCode();

            return result;
        }
    }
}
