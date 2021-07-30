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
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// 5.3.3.3. Information about elastic collisions in a DIS exercise shall be communicated using a Collision-Elastic
    /// PDU. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class CollisionElasticPdu : EntityInformationFamilyPdu, IEquatable<CollisionElasticPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionElasticPdu"/> class.
        /// </summary>
        public CollisionElasticPdu()
        {
            PduType = 66;
            ProtocolFamily = 1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(CollisionElasticPdu left, CollisionElasticPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(CollisionElasticPdu left, CollisionElasticPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += IssuingEntityID.GetMarshalledSize();  // this._issuingEntityID
            marshalSize += CollidingEntityID.GetMarshalledSize();  // this._collidingEntityID
            marshalSize += CollisionEventID.GetMarshalledSize();  // this._collisionEventID
            marshalSize += 2;  // this._pad
            marshalSize += ContactVelocity.GetMarshalledSize();  // this._contactVelocity
            marshalSize += 4;  // this._mass
            marshalSize += Location.GetMarshalledSize();  // this._location
            marshalSize += 4;  // this._collisionResultXX
            marshalSize += 4;  // this._collisionResultXY
            marshalSize += 4;  // this._collisionResultXZ
            marshalSize += 4;  // this._collisionResultYY
            marshalSize += 4;  // this._collisionResultYZ
            marshalSize += 4;  // this._collisionResultZZ
            marshalSize += UnitSurfaceNormal.GetMarshalledSize();  // this._unitSurfaceNormal
            marshalSize += 4;  // this._coefficientOfRestitution
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity that issued the collision PDU
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "issuingEntityID")]
        public EntityID IssuingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of entity that has collided with the issuing entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "collidingEntityID")]
        public EntityID CollidingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "collisionEventID")]
        public EventID CollisionEventID { get; set; } = new();

        /// <summary>
        /// Gets or sets the some padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "pad")]
        public short Pad { get; set; }

        /// <summary>
        /// Gets or sets the velocity at collision
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "contactVelocity")]
        public Vector3Float ContactVelocity { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the mass of issuing entity
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "mass")]
        public float Mass { get; set; }

        /// <summary>
        /// Gets or sets the Location with respect to entity the issuing entity collided with
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXX")]
        public float CollisionResultXX { get; set; }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXY")]
        public float CollisionResultXY { get; set; }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultXZ")]
        public float CollisionResultXZ { get; set; }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultYY")]
        public float CollisionResultYY { get; set; }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultYZ")]
        public float CollisionResultYZ { get; set; }

        /// <summary>
        /// Gets or sets the tensor values
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "collisionResultZZ")]
        public float CollisionResultZZ { get; set; }

        /// <summary>
        /// Gets or sets the This record shall represent the normal vector to the surface at the point of collision detection.
        /// The surface normal shall be represented in world coordinates.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "unitSurfaceNormal")]
        public Vector3Float UnitSurfaceNormal { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the This field shall represent the degree to which energy is conserved in a collision
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "coefficientOfRestitution")]
        public float CoefficientOfRestitution { get; set; }

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
                    IssuingEntityID.Marshal(dos);
                    CollidingEntityID.Marshal(dos);
                    CollisionEventID.Marshal(dos);
                    dos.WriteShort(Pad);
                    ContactVelocity.Marshal(dos);
                    dos.WriteFloat((float)Mass);
                    Location.Marshal(dos);
                    dos.WriteFloat((float)CollisionResultXX);
                    dos.WriteFloat((float)CollisionResultXY);
                    dos.WriteFloat((float)CollisionResultXZ);
                    dos.WriteFloat((float)CollisionResultYY);
                    dos.WriteFloat((float)CollisionResultYZ);
                    dos.WriteFloat(CollisionResultZZ);
                    UnitSurfaceNormal.Marshal(dos);
                    dos.WriteFloat(CoefficientOfRestitution);
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
                    IssuingEntityID.Unmarshal(dis);
                    CollidingEntityID.Unmarshal(dis);
                    CollisionEventID.Unmarshal(dis);
                    Pad = dis.ReadShort();
                    ContactVelocity.Unmarshal(dis);
                    Mass = dis.ReadFloat();
                    Location.Unmarshal(dis);
                    CollisionResultXX = dis.ReadFloat();
                    CollisionResultXY = dis.ReadFloat();
                    CollisionResultXZ = dis.ReadFloat();
                    CollisionResultYY = dis.ReadFloat();
                    CollisionResultYZ = dis.ReadFloat();
                    CollisionResultZZ = dis.ReadFloat();
                    UnitSurfaceNormal.Unmarshal(dis);
                    CoefficientOfRestitution = dis.ReadFloat();
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
            sb.AppendLine("<CollisionElasticPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<issuingEntityID>");
                IssuingEntityID.Reflection(sb);
                sb.AppendLine("</issuingEntityID>");
                sb.AppendLine("<collidingEntityID>");
                CollidingEntityID.Reflection(sb);
                sb.AppendLine("</collidingEntityID>");
                sb.AppendLine("<collisionEventID>");
                CollisionEventID.Reflection(sb);
                sb.AppendLine("</collisionEventID>");
                sb.AppendLine("<pad type=\"short\">" + Pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<contactVelocity>");
                ContactVelocity.Reflection(sb);
                sb.AppendLine("</contactVelocity>");
                sb.AppendLine("<mass type=\"float\">" + Mass.ToString(CultureInfo.InvariantCulture) + "</mass>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<collisionResultXX type=\"float\">" + CollisionResultXX.ToString(CultureInfo.InvariantCulture) + "</collisionResultXX>");
                sb.AppendLine("<collisionResultXY type=\"float\">" + CollisionResultXY.ToString(CultureInfo.InvariantCulture) + "</collisionResultXY>");
                sb.AppendLine("<collisionResultXZ type=\"float\">" + CollisionResultXZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultXZ>");
                sb.AppendLine("<collisionResultYY type=\"float\">" + CollisionResultYY.ToString(CultureInfo.InvariantCulture) + "</collisionResultYY>");
                sb.AppendLine("<collisionResultYZ type=\"float\">" + CollisionResultYZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultYZ>");
                sb.AppendLine("<collisionResultZZ type=\"float\">" + CollisionResultZZ.ToString(CultureInfo.InvariantCulture) + "</collisionResultZZ>");
                sb.AppendLine("<unitSurfaceNormal>");
                UnitSurfaceNormal.Reflection(sb);
                sb.AppendLine("</unitSurfaceNormal>");
                sb.AppendLine("<coefficientOfRestitution type=\"float\">" + CoefficientOfRestitution.ToString(CultureInfo.InvariantCulture) + "</coefficientOfRestitution>");
                sb.AppendLine("</CollisionElasticPdu>");
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
        public override bool Equals(object obj) => this == obj as CollisionElasticPdu;

        ///<inheritdoc/>
        public bool Equals(CollisionElasticPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!IssuingEntityID.Equals(obj.IssuingEntityID))
            {
                ivarsEqual = false;
            }

            if (!CollidingEntityID.Equals(obj.CollidingEntityID))
            {
                ivarsEqual = false;
            }

            if (!CollisionEventID.Equals(obj.CollisionEventID))
            {
                ivarsEqual = false;
            }

            if (Pad != obj.Pad)
            {
                ivarsEqual = false;
            }

            if (!ContactVelocity.Equals(obj.ContactVelocity))
            {
                ivarsEqual = false;
            }

            if (Mass != obj.Mass)
            {
                ivarsEqual = false;
            }

            if (!Location.Equals(obj.Location))
            {
                ivarsEqual = false;
            }

            if (CollisionResultXX != obj.CollisionResultXX)
            {
                ivarsEqual = false;
            }

            if (CollisionResultXY != obj.CollisionResultXY)
            {
                ivarsEqual = false;
            }

            if (CollisionResultXZ != obj.CollisionResultXZ)
            {
                ivarsEqual = false;
            }

            if (CollisionResultYY != obj.CollisionResultYY)
            {
                ivarsEqual = false;
            }

            if (CollisionResultYZ != obj.CollisionResultYZ)
            {
                ivarsEqual = false;
            }

            if (CollisionResultZZ != obj.CollisionResultZZ)
            {
                ivarsEqual = false;
            }

            if (!UnitSurfaceNormal.Equals(obj.UnitSurfaceNormal))
            {
                ivarsEqual = false;
            }

            if (CoefficientOfRestitution != obj.CoefficientOfRestitution)
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

            result = GenerateHash(result) ^ IssuingEntityID.GetHashCode();
            result = GenerateHash(result) ^ CollidingEntityID.GetHashCode();
            result = GenerateHash(result) ^ CollisionEventID.GetHashCode();
            result = GenerateHash(result) ^ Pad.GetHashCode();
            result = GenerateHash(result) ^ ContactVelocity.GetHashCode();
            result = GenerateHash(result) ^ Mass.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultXX.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultXY.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultXZ.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultYY.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultYZ.GetHashCode();
            result = GenerateHash(result) ^ CollisionResultZZ.GetHashCode();
            result = GenerateHash(result) ^ UnitSurfaceNormal.GetHashCode();
            result = GenerateHash(result) ^ CoefficientOfRestitution.GetHashCode();

            return result;
        }
    }
}
