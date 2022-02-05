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
    /// Section 5.3.3.1. Represents the postion and state of one entity in the world. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(DeadReckoningParameter))]
    [XmlInclude(typeof(Marking))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class EntityStatePdu : EntityInformationFamilyPdu, IEquatable<EntityStatePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStatePdu"/> class.
        /// </summary>
        public EntityStatePdu()
        {
            PduType = 1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(EntityStatePdu left, EntityStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(EntityStatePdu left, EntityStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EntityID.GetMarshalledSize();  // this._entityID
            marshalSize += 1;  // this._forceId
            marshalSize += 1;  // this._numberOfArticulationParameters
            marshalSize += EntityType.GetMarshalledSize();  // this._entityType
            marshalSize += AlternativeEntityType.GetMarshalledSize();  // this._alternativeEntityType
            marshalSize += EntityLinearVelocity.GetMarshalledSize();  // this._entityLinearVelocity
            marshalSize += EntityLocation.GetMarshalledSize();  // this._entityLocation
            marshalSize += EntityOrientation.GetMarshalledSize();  // this._entityOrientation
            marshalSize += 4;  // this._entityAppearance
            marshalSize += DeadReckoningParameters.GetMarshalledSize();  // this._deadReckoningParameters
            marshalSize += Marking.GetMarshalledSize();  // this._marking
            marshalSize += 4;  // this._capabilities
            for (int idx = 0; idx < ArticulationParameters.Count; idx++)
            {
                var listElement = ArticulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Unique ID for an entity that is tied to this state information
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
        public EntityID EntityID { get; set; } = new();

        /// <summary>
        /// Gets or sets the What force this entity is affiliated with, eg red, blue, neutral, etc
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceId")]
        public byte ForceId { get; set; }

        /// <summary>
        /// Gets or sets the How many articulation parameters are in the variable length list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters { get; set; }

        /// <summary>
        /// Gets or sets the Describes the type of entity in the world
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "entityType")]
        public EntityType EntityType { get; set; } = new();

        /// <summary>
        /// Gets or sets the alternativeEntityType
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "alternativeEntityType")]
        public EntityType AlternativeEntityType { get; set; } = new();

        /// <summary>
        /// Gets or sets the Describes the speed of the entity in the world
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearVelocity")]
        public Vector3Float EntityLinearVelocity { get; set; } = new();

        /// <summary>
        /// Gets or sets the describes the location of the entity in the world
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "entityLocation")]
        public Vector3Double EntityLocation { get; set; } = new();

        /// <summary>
        /// Gets or sets the describes the orientation of the entity, in euler angles
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "entityOrientation")]
        public Orientation EntityOrientation { get; set; } = new();

        /// <summary>
        /// Gets or sets the a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
        public int EntityAppearance { get; set; }

        /// <summary>
        /// Gets or sets the parameters used for dead reckoning
        /// </summary>
        [XmlElement(Type = typeof(DeadReckoningParameter), ElementName = "deadReckoningParameters")]
        public DeadReckoningParameter DeadReckoningParameters { get; set; } = new();

        /// <summary>
        /// Gets or sets the characters that can be used for debugging, or to draw unique strings on the side of entities in
        /// the world
        /// </summary>
        [XmlElement(Type = typeof(Marking), ElementName = "marking")]
        public Marking Marking { get; set; } = new();

        /// <summary>
        /// Gets or sets the a series of bit flags
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "capabilities")]
        public int Capabilities { get; set; }

        /// <summary>
        /// Gets the variable length list of articulation parameters
        /// </summary>
        [XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters { get; } = new();

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
                    EntityID.Marshal(dos);
                    dos.WriteUnsignedByte(ForceId);
                    dos.WriteByte((byte)ArticulationParameters.Count);
                    EntityType.Marshal(dos);
                    AlternativeEntityType.Marshal(dos);
                    EntityLinearVelocity.Marshal(dos);
                    EntityLocation.Marshal(dos);
                    EntityOrientation.Marshal(dos);
                    dos.WriteInt(EntityAppearance);
                    DeadReckoningParameters.Marshal(dos);
                    Marking.Marshal(dos);
                    dos.WriteInt(Capabilities);

                    for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                    {
                        var aArticulationParameter = ArticulationParameters[idx];
                        aArticulationParameter.Marshal(dos);
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
                    EntityID.Unmarshal(dis);
                    ForceId = dis.ReadUnsignedByte();
                    NumberOfArticulationParameters = dis.ReadByte();
                    EntityType.Unmarshal(dis);
                    AlternativeEntityType.Unmarshal(dis);
                    EntityLinearVelocity.Unmarshal(dis);
                    EntityLocation.Unmarshal(dis);
                    EntityOrientation.Unmarshal(dis);
                    EntityAppearance = dis.ReadInt();
                    DeadReckoningParameters.Unmarshal(dis);
                    Marking.Unmarshal(dis);
                    Capabilities = dis.ReadInt();

                    for (int idx = 0; idx < NumberOfArticulationParameters; idx++)
                    {
                        var anX = new ArticulationParameter();
                        anX.Unmarshal(dis);
                        ArticulationParameters.Add(anX);
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
            sb.AppendLine("<EntityStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<entityID>");
                EntityID.Reflection(sb);
                sb.AppendLine("</entityID>");
                sb.AppendLine("<forceId type=\"byte\">" + ForceId.ToString(CultureInfo.InvariantCulture) + "</forceId>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + ArticulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<entityType>");
                EntityType.Reflection(sb);
                sb.AppendLine("</entityType>");
                sb.AppendLine("<alternativeEntityType>");
                AlternativeEntityType.Reflection(sb);
                sb.AppendLine("</alternativeEntityType>");
                sb.AppendLine("<entityLinearVelocity>");
                EntityLinearVelocity.Reflection(sb);
                sb.AppendLine("</entityLinearVelocity>");
                sb.AppendLine("<entityLocation>");
                EntityLocation.Reflection(sb);
                sb.AppendLine("</entityLocation>");
                sb.AppendLine("<entityOrientation>");
                EntityOrientation.Reflection(sb);
                sb.AppendLine("</entityOrientation>");
                sb.AppendLine("<entityAppearance type=\"int\">" + EntityAppearance.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
                sb.AppendLine("<deadReckoningParameters>");
                DeadReckoningParameters.Reflection(sb);
                sb.AppendLine("</deadReckoningParameters>");
                sb.AppendLine("<marking>");
                Marking.Reflection(sb);
                sb.AppendLine("</marking>");
                sb.AppendLine("<capabilities type=\"int\">" + Capabilities.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    var aArticulationParameter = ArticulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</EntityStatePdu>");
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
        public override bool Equals(object obj) => this == obj as EntityStatePdu;

        ///<inheritdoc/>
        public bool Equals(EntityStatePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!EntityID.Equals(obj.EntityID))
            {
                ivarsEqual = false;
            }

            if (ForceId != obj.ForceId)
            {
                ivarsEqual = false;
            }

            if (NumberOfArticulationParameters != obj.NumberOfArticulationParameters)
            {
                ivarsEqual = false;
            }

            if (!EntityType.Equals(obj.EntityType))
            {
                ivarsEqual = false;
            }

            if (!AlternativeEntityType.Equals(obj.AlternativeEntityType))
            {
                ivarsEqual = false;
            }

            if (!EntityLinearVelocity.Equals(obj.EntityLinearVelocity))
            {
                ivarsEqual = false;
            }

            if (!EntityLocation.Equals(obj.EntityLocation))
            {
                ivarsEqual = false;
            }

            if (!EntityOrientation.Equals(obj.EntityOrientation))
            {
                ivarsEqual = false;
            }

            if (EntityAppearance != obj.EntityAppearance)
            {
                ivarsEqual = false;
            }

            if (!DeadReckoningParameters.Equals(obj.DeadReckoningParameters))
            {
                ivarsEqual = false;
            }

            if (!Marking.Equals(obj.Marking))
            {
                ivarsEqual = false;
            }

            if (Capabilities != obj.Capabilities)
            {
                ivarsEqual = false;
            }

            if (ArticulationParameters.Count != obj.ArticulationParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    if (!ArticulationParameters[idx].Equals(obj.ArticulationParameters[idx]))
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

            result = GenerateHash(result) ^ EntityID.GetHashCode();
            result = GenerateHash(result) ^ ForceId.GetHashCode();
            result = GenerateHash(result) ^ NumberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ EntityType.GetHashCode();
            result = GenerateHash(result) ^ AlternativeEntityType.GetHashCode();
            result = GenerateHash(result) ^ EntityLinearVelocity.GetHashCode();
            result = GenerateHash(result) ^ EntityLocation.GetHashCode();
            result = GenerateHash(result) ^ EntityOrientation.GetHashCode();
            result = GenerateHash(result) ^ EntityAppearance.GetHashCode();
            result = GenerateHash(result) ^ DeadReckoningParameters.GetHashCode();
            result = GenerateHash(result) ^ Marking.GetHashCode();
            result = GenerateHash(result) ^ Capabilities.GetHashCode();

            if (ArticulationParameters.Count > 0)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ ArticulationParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
