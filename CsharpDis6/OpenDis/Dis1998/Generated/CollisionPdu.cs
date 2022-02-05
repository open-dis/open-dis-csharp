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
        /// Initializes a new instance of the <see cref="CollisionPdu"/> class.
        /// </summary>
        public CollisionPdu()
        {
            PduType = 4;
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
        public static bool operator !=(CollisionPdu left, CollisionPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(CollisionPdu left, CollisionPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += IssuingEntityID.GetMarshalledSize();  // this._issuingEntityID
            marshalSize += CollidingEntityID.GetMarshalledSize();  // this._collidingEntityID
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += 1;  // this._collisionType
            marshalSize += 1;  // this._pad
            marshalSize += Velocity.GetMarshalledSize();  // this._velocity
            marshalSize += 4;  // this._mass
            marshalSize += Location.GetMarshalledSize();  // this._location
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
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "collisionType")]
        public byte CollisionType { get; set; }

        /// <summary>
        /// Gets or sets the some padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad")]
        public byte Pad { get; set; }

        /// <summary>
        /// Gets or sets the velocity at collision
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity { get; set; } = new Vector3Float();

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
                    EventID.Marshal(dos);
                    dos.WriteUnsignedByte(CollisionType);
                    dos.WriteByte(Pad);
                    Velocity.Marshal(dos);
                    dos.WriteFloat((float)Mass);
                    Location.Marshal(dos);
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
                    EventID.Unmarshal(dis);
                    CollisionType = dis.ReadUnsignedByte();
                    Pad = dis.ReadByte();
                    Velocity.Unmarshal(dis);
                    Mass = dis.ReadFloat();
                    Location.Unmarshal(dis);
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
            sb.AppendLine("<CollisionPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<issuingEntityID>");
                IssuingEntityID.Reflection(sb);
                sb.AppendLine("</issuingEntityID>");
                sb.AppendLine("<collidingEntityID>");
                CollidingEntityID.Reflection(sb);
                sb.AppendLine("</collidingEntityID>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<collisionType type=\"byte\">" + CollisionType.ToString(CultureInfo.InvariantCulture) + "</collisionType>");
                sb.AppendLine("<pad type=\"byte\">" + Pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<velocity>");
                Velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<mass type=\"float\">" + Mass.ToString(CultureInfo.InvariantCulture) + "</mass>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("</CollisionPdu>");
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
        public override bool Equals(object obj) => this == obj as CollisionPdu;

        ///<inheritdoc/>
        public bool Equals(CollisionPdu obj)
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

            if (!EventID.Equals(obj.EventID))
            {
                ivarsEqual = false;
            }

            if (CollisionType != obj.CollisionType)
            {
                ivarsEqual = false;
            }

            if (Pad != obj.Pad)
            {
                ivarsEqual = false;
            }

            if (!Velocity.Equals(obj.Velocity))
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
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ CollisionType.GetHashCode();
            result = GenerateHash(result) ^ Pad.GetHashCode();
            result = GenerateHash(result) ^ Velocity.GetHashCode();
            result = GenerateHash(result) ^ Mass.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();

            return result;
        }
    }
}
