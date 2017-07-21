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
    /// 5.3.3.3. Information about elastic collisions in a DIS exercise shall be communicated using a Collision-Elastic PDU. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class CollisionElasticPdu : EntityInformationFamilyPdu, IEquatable<CollisionElasticPdu>
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
        private EventID _collisionEventID = new EventID();

        /// <summary>
        /// some padding
        /// </summary>
        private short _pad;

        /// <summary>
        /// velocity at collision
        /// </summary>
        private Vector3Float _contactVelocity = new Vector3Float();

        /// <summary>
        /// mass of issuing entity
        /// </summary>
        private float _mass;

        /// <summary>
        /// Location with respect to entity the issuing entity collided with
        /// </summary>
        private Vector3Float _location = new Vector3Float();

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultXX;

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultXY;

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultXZ;

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultYY;

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultYZ;

        /// <summary>
        /// tensor values
        /// </summary>
        private float _collisionResultZZ;

        /// <summary>
        /// This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates.
        /// </summary>
        private Vector3Float _unitSurfaceNormal = new Vector3Float();

        /// <summary>
        /// This field shall represent the degree to which energy is conserved in a collision
        /// </summary>
        private float _coefficientOfRestitution;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionElasticPdu"/> class.
        /// </summary>
        public CollisionElasticPdu()
        {
            PduType = (byte)66;
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
        public static bool operator !=(CollisionElasticPdu left, CollisionElasticPdu right)
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
        public static bool operator ==(CollisionElasticPdu left, CollisionElasticPdu right)
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
            marshalSize += this._collisionEventID.GetMarshalledSize();  // this._collisionEventID
            marshalSize += 2;  // this._pad
            marshalSize += this._contactVelocity.GetMarshalledSize();  // this._contactVelocity
            marshalSize += 4;  // this._mass
            marshalSize += this._location.GetMarshalledSize();  // this._location
            marshalSize += 4;  // this._collisionResultXX
            marshalSize += 4;  // this._collisionResultXY
            marshalSize += 4;  // this._collisionResultXZ
            marshalSize += 4;  // this._collisionResultYY
            marshalSize += 4;  // this._collisionResultYZ
            marshalSize += 4;  // this._collisionResultZZ
            marshalSize += this._unitSurfaceNormal.GetMarshalledSize();  // this._unitSurfaceNormal
            marshalSize += 4;  // this._coefficientOfRestitution
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
        [XmlElement(Type = typeof(EventID), ElementName = "collisionEventID")]
        public EventID CollisionEventID
        {
            get
            {
                return this._collisionEventID;
            }

            set
            {
                this._collisionEventID = value;
            }
        }

        /// <summary>
        /// Gets or sets the some padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "pad")]
        public short Pad
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
        [XmlElement(Type = typeof(Vector3Float), ElementName = "contactVelocity")]
        public Vector3Float ContactVelocity
        {
            get
            {
                return this._contactVelocity;
            }

            set
            {
                this._contactVelocity = value;
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
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXX")]
        public float CollisionResultXX
        {
            get
            {
                return this._collisionResultXX;
            }

            set
            {
                this._collisionResultXX = value;
            }
        }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXY")]
        public float CollisionResultXY
        {
            get
            {
                return this._collisionResultXY;
            }

            set
            {
                this._collisionResultXY = value;
            }
        }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXZ")]
        public float CollisionResultXZ
        {
            get
            {
                return this._collisionResultXZ;
            }

            set
            {
                this._collisionResultXZ = value;
            }
        }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultYY")]
        public float CollisionResultYY
        {
            get
            {
                return this._collisionResultYY;
            }

            set
            {
                this._collisionResultYY = value;
            }
        }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultYZ")]
        public float CollisionResultYZ
        {
            get
            {
                return this._collisionResultYZ;
            }

            set
            {
                this._collisionResultYZ = value;
            }
        }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultZZ")]
        public float CollisionResultZZ
        {
            get
            {
                return this._collisionResultZZ;
            }

            set
            {
                this._collisionResultZZ = value;
            }
        }

        /// <summary>
        /// Gets or sets the This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "unitSurfaceNormal")]
        public Vector3Float UnitSurfaceNormal
        {
            get
            {
                return this._unitSurfaceNormal;
            }

            set
            {
                this._unitSurfaceNormal = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall represent the degree to which energy is conserved in a collision
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "coefficientOfRestitution")]
        public float CoefficientOfRestitution
        {
            get
            {
                return this._coefficientOfRestitution;
            }

            set
            {
                this._coefficientOfRestitution = value;
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
                    this._collisionEventID.Marshal(dos);
                    dos.WriteShort((short)this._pad);
                    this._contactVelocity.Marshal(dos);
                    dos.WriteFloat((float)this._mass);
                    this._location.Marshal(dos);
                    dos.WriteFloat((float)this._collisionResultXX);
                    dos.WriteFloat((float)this._collisionResultXY);
                    dos.WriteFloat((float)this._collisionResultXZ);
                    dos.WriteFloat((float)this._collisionResultYY);
                    dos.WriteFloat((float)this._collisionResultYZ);
                    dos.WriteFloat((float)this._collisionResultZZ);
                    this._unitSurfaceNormal.Marshal(dos);
                    dos.WriteFloat((float)this._coefficientOfRestitution);
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
                    this._collisionEventID.Unmarshal(dis);
                    this._pad = dis.ReadShort();
                    this._contactVelocity.Unmarshal(dis);
                    this._mass = dis.ReadFloat();
                    this._location.Unmarshal(dis);
                    this._collisionResultXX = dis.ReadFloat();
                    this._collisionResultXY = dis.ReadFloat();
                    this._collisionResultXZ = dis.ReadFloat();
                    this._collisionResultYY = dis.ReadFloat();
                    this._collisionResultYZ = dis.ReadFloat();
                    this._collisionResultZZ = dis.ReadFloat();
                    this._unitSurfaceNormal.Unmarshal(dis);
                    this._coefficientOfRestitution = dis.ReadFloat();
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
            sb.AppendLine("<CollisionElasticPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<issuingEntityID>");
                this._issuingEntityID.Reflection(sb);
                sb.AppendLine("</issuingEntityID>");
                sb.AppendLine("<collidingEntityID>");
                this._collidingEntityID.Reflection(sb);
                sb.AppendLine("</collidingEntityID>");
                sb.AppendLine("<collisionEventID>");
                this._collisionEventID.Reflection(sb);
                sb.AppendLine("</collisionEventID>");
                sb.AppendLine("<pad type=\"short\">" + this._pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<contactVelocity>");
                this._contactVelocity.Reflection(sb);
                sb.AppendLine("</contactVelocity>");
                sb.AppendLine("<mass type=\"float\">" + this._mass.ToString(CultureInfo.InvariantCulture) + "</mass>");
                sb.AppendLine("<location>");
                this._location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<collisionResultXX type=\"float\">" + this._collisionResultXX.ToString(CultureInfo.InvariantCulture) + "</collisionResultXX>");
                sb.AppendLine("<collisionResultXY type=\"float\">" + this._collisionResultXY.ToString(CultureInfo.InvariantCulture) + "</collisionResultXY>");
                sb.AppendLine("<collisionResultXZ type=\"float\">" + this._collisionResultXZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultXZ>");
                sb.AppendLine("<collisionResultYY type=\"float\">" + this._collisionResultYY.ToString(CultureInfo.InvariantCulture) + "</collisionResultYY>");
                sb.AppendLine("<collisionResultYZ type=\"float\">" + this._collisionResultYZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultYZ>");
                sb.AppendLine("<collisionResultZZ type=\"float\">" + this._collisionResultZZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultZZ>");
                sb.AppendLine("<unitSurfaceNormal>");
                this._unitSurfaceNormal.Reflection(sb);
                sb.AppendLine("</unitSurfaceNormal>");
                sb.AppendLine("<coefficientOfRestitution type=\"float\">" + this._coefficientOfRestitution.ToString(CultureInfo.InvariantCulture) + "</coefficientOfRestitution>");
                sb.AppendLine("</CollisionElasticPdu>");
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
            return this == obj as CollisionElasticPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CollisionElasticPdu obj)
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

            if (!this._collisionEventID.Equals(obj._collisionEventID))
            {
                ivarsEqual = false;
            }

            if (this._pad != obj._pad)
            {
                ivarsEqual = false;
            }

            if (!this._contactVelocity.Equals(obj._contactVelocity))
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

            if (this._collisionResultXX != obj._collisionResultXX)
            {
                ivarsEqual = false;
            }

            if (this._collisionResultXY != obj._collisionResultXY)
            {
                ivarsEqual = false;
            }

            if (this._collisionResultXZ != obj._collisionResultXZ)
            {
                ivarsEqual = false;
            }

            if (this._collisionResultYY != obj._collisionResultYY)
            {
                ivarsEqual = false;
            }

            if (this._collisionResultYZ != obj._collisionResultYZ)
            {
                ivarsEqual = false;
            }

            if (this._collisionResultZZ != obj._collisionResultZZ)
            {
                ivarsEqual = false;
            }

            if (!this._unitSurfaceNormal.Equals(obj._unitSurfaceNormal))
            {
                ivarsEqual = false;
            }

            if (this._coefficientOfRestitution != obj._coefficientOfRestitution)
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
            result = GenerateHash(result) ^ this._collisionEventID.GetHashCode();
            result = GenerateHash(result) ^ this._pad.GetHashCode();
            result = GenerateHash(result) ^ this._contactVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._mass.GetHashCode();
            result = GenerateHash(result) ^ this._location.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultXX.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultXY.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultXZ.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultYY.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultYZ.GetHashCode();
            result = GenerateHash(result) ^ this._collisionResultZZ.GetHashCode();
            result = GenerateHash(result) ^ this._unitSurfaceNormal.GetHashCode();
            result = GenerateHash(result) ^ this._coefficientOfRestitution.GetHashCode();

            return result;
        }
    }
}
