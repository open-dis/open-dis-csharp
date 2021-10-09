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

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Section 5.3.3.1. Represents the postion and state of one entity in the world
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(DeadReckoningParameter))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class EntityStatePdu : EntityInformationPdu, IEquatable<EntityStatePdu>
    {
        /// <summary>
        /// Unique ID for an entity that is tied to this state information
        /// </summary>
        private EntityID _entityID = new EntityID();

        private byte _forceId;

        /// <summary>
        /// How many articulation parameters are in the variable length list
        /// </summary>
        private byte _articulationParameterCount;

        /// <summary>
        /// Describes the type of entity in the world
        /// </summary>
        private EntityType _entityType = new EntityType();

        private EntityType _alternativeEntityType = new EntityType();

        /// <summary>
        /// Describes the speed of the entity in the world
        /// </summary>
        private Vector3Float _entityLinearVelocity = new Vector3Float();

        /// <summary>
        /// describes the location of the entity in the world
        /// </summary>
        private Vector3Double _entityLocation = new Vector3Double();

        /// <summary>
        /// describes the orientation of the entity, in euler angles
        /// </summary>
        private Orientation _entityOrientation = new Orientation();

        /// <summary>
        /// a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        private int _entityAppearance;

        /// <summary>
        /// parameters used for dead reckoning
        /// </summary>
        private DeadReckoningParameter _deadReckoningParameters = new DeadReckoningParameter();

        /// <summary>
        /// characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        /// </summary>
        private byte[] _marking = new byte[12];

        /// <summary>
        /// a series of bit flags
        /// </summary>
        private int _capabilities;

        /// <summary>
        /// variable length list of articulation parameters
        /// </summary>
        private List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStatePdu"/> class.
        /// </summary>
        public EntityStatePdu()
        {
            PduType = (byte)1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(EntityStatePdu left, EntityStatePdu right)
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
        public static bool operator ==(EntityStatePdu left, EntityStatePdu right)
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
            marshalSize += this._entityID.GetMarshalledSize();  // this._entityID
            marshalSize += 1;  // this._forceId
            marshalSize += 1;  // this._articulationParameterCount
            marshalSize += this._entityType.GetMarshalledSize();  // this._entityType
            marshalSize += this._alternativeEntityType.GetMarshalledSize();  // this._alternativeEntityType
            marshalSize += this._entityLinearVelocity.GetMarshalledSize();  // this._entityLinearVelocity
            marshalSize += this._entityLocation.GetMarshalledSize();  // this._entityLocation
            marshalSize += this._entityOrientation.GetMarshalledSize();  // this._entityOrientation
            marshalSize += 4;  // this._entityAppearance
            marshalSize += this._deadReckoningParameters.GetMarshalledSize();  // this._deadReckoningParameters
            marshalSize += 12 * 1;  // _marking
            marshalSize += 4;  // this._capabilities
            for (int idx = 0; idx < this._articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)this._articulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Unique ID for an entity that is tied to this state information
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
        public EntityID EntityID
        {
            get
            {
                return this._entityID;
            }

            set
            {
                this._entityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the forceId
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceId")]
        public byte ForceId
        {
            get
            {
                return this._forceId;
            }

            set
            {
                this._forceId = value;
            }
        }

        /// <summary>
        /// Gets or sets the How many articulation parameters are in the variable length list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getarticulationParameterCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "articulationParameterCount")]
        public byte ArticulationParameterCount
        {
            get
            {
                return this._articulationParameterCount;
            }

            set
            {
                this._articulationParameterCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the Describes the type of entity in the world
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "entityType")]
        public EntityType EntityType
        {
            get
            {
                return this._entityType;
            }

            set
            {
                this._entityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the alternativeEntityType
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "alternativeEntityType")]
        public EntityType AlternativeEntityType
        {
            get
            {
                return this._alternativeEntityType;
            }

            set
            {
                this._alternativeEntityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Describes the speed of the entity in the world
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearVelocity")]
        public Vector3Float EntityLinearVelocity
        {
            get
            {
                return this._entityLinearVelocity;
            }

            set
            {
                this._entityLinearVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the describes the location of the entity in the world
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "entityLocation")]
        public Vector3Double EntityLocation
        {
            get
            {
                return this._entityLocation;
            }

            set
            {
                this._entityLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the describes the orientation of the entity, in euler angles
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "entityOrientation")]
        public Orientation EntityOrientation
        {
            get
            {
                return this._entityOrientation;
            }

            set
            {
                this._entityOrientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
        public int EntityAppearance
        {
            get
            {
                return this._entityAppearance;
            }

            set
            {
                this._entityAppearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameters used for dead reckoning
        /// </summary>
        [XmlElement(Type = typeof(DeadReckoningParameter), ElementName = "deadReckoningParameters")]
        public DeadReckoningParameter DeadReckoningParameters
        {
            get
            {
                return this._deadReckoningParameters;
            }

            set
            {
                this._deadReckoningParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        /// </summary>
        [XmlArray(ElementName = "marking")]
        public byte[] Marking
        {
            get
            {
                return this._marking;
            }

            set
            {
                this._marking = value;
            }
}

        /// <summary>
        /// Gets or sets the a series of bit flags
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "capabilities")]
        public int Capabilities
        {
            get
            {
                return this._capabilities;
            }

            set
            {
                this._capabilities = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of articulation parameters
        /// </summary>
        [XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters
        {
            get
            {
                return this._articulationParameters;
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
                    this._entityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._forceId);
                    dos.WriteByte((byte)this._articulationParameters.Count);
                    this._entityType.Marshal(dos);
                    this._alternativeEntityType.Marshal(dos);
                    this._entityLinearVelocity.Marshal(dos);
                    this._entityLocation.Marshal(dos);
                    this._entityOrientation.Marshal(dos);
                    dos.WriteInt((int)this._entityAppearance);
                    this._deadReckoningParameters.Marshal(dos);

                    for (int idx = 0; idx < this._marking.Length; idx++)
                    {
                        dos.WriteByte(this._marking[idx]);
                    }

                    dos.WriteInt((int)this._capabilities);

                    for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                    {
                        ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                        aArticulationParameter.Marshal(dos);
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
                    this._entityID.Unmarshal(dis);
                    this._forceId = dis.ReadUnsignedByte();
                    this._articulationParameterCount = dis.ReadByte();
                    this._entityType.Unmarshal(dis);
                    this._alternativeEntityType.Unmarshal(dis);
                    this._entityLinearVelocity.Unmarshal(dis);
                    this._entityLocation.Unmarshal(dis);
                    this._entityOrientation.Unmarshal(dis);
                    this._entityAppearance = dis.ReadInt();
                    this._deadReckoningParameters.Unmarshal(dis);

                    for (int idx = 0; idx < this._marking.Length; idx++)
                    {
                        this._marking[idx] = dis.ReadByte();
                    }

                    this._capabilities = dis.ReadInt();

                    for (int idx = 0; idx < this.ArticulationParameterCount; idx++)
                    {
                        ArticulationParameter anX = new ArticulationParameter();
                        anX.Unmarshal(dis);
                        this._articulationParameters.Add(anX);
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
            sb.AppendLine("<EntityStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<entityID>");
                this._entityID.Reflection(sb);
                sb.AppendLine("</entityID>");
                sb.AppendLine("<forceId type=\"byte\">" + this._forceId.ToString(CultureInfo.InvariantCulture) + "</forceId>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + this._articulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<entityType>");
                this._entityType.Reflection(sb);
                sb.AppendLine("</entityType>");
                sb.AppendLine("<alternativeEntityType>");
                this._alternativeEntityType.Reflection(sb);
                sb.AppendLine("</alternativeEntityType>");
                sb.AppendLine("<entityLinearVelocity>");
                this._entityLinearVelocity.Reflection(sb);
                sb.AppendLine("</entityLinearVelocity>");
                sb.AppendLine("<entityLocation>");
                this._entityLocation.Reflection(sb);
                sb.AppendLine("</entityLocation>");
                sb.AppendLine("<entityOrientation>");
                this._entityOrientation.Reflection(sb);
                sb.AppendLine("</entityOrientation>");
                sb.AppendLine("<entityAppearance type=\"int\">" + this._entityAppearance.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
                sb.AppendLine("<deadReckoningParameters>");
                this._deadReckoningParameters.Reflection(sb);
                sb.AppendLine("</deadReckoningParameters>");
                for (int idx = 0; idx < this._marking.Length; idx++)
                {
                    sb.AppendLine("<marking" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + this._marking[idx] + "</marking" + idx.ToString(CultureInfo.InvariantCulture) + ">");
            }

                sb.AppendLine("<capabilities type=\"int\">" + this._capabilities.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</EntityStatePdu>");
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
            return this == obj as EntityStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EntityStatePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._entityID.Equals(obj._entityID))
            {
                ivarsEqual = false;
            }

            if (this._forceId != obj._forceId)
            {
                ivarsEqual = false;
            }

            if (this._articulationParameterCount != obj._articulationParameterCount)
            {
                ivarsEqual = false;
            }

            if (!this._entityType.Equals(obj._entityType))
            {
                ivarsEqual = false;
            }

            if (!this._alternativeEntityType.Equals(obj._alternativeEntityType))
            {
                ivarsEqual = false;
            }

            if (!this._entityLinearVelocity.Equals(obj._entityLinearVelocity))
            {
                ivarsEqual = false;
            }

            if (!this._entityLocation.Equals(obj._entityLocation))
            {
                ivarsEqual = false;
            }

            if (!this._entityOrientation.Equals(obj._entityOrientation))
            {
                ivarsEqual = false;
            }

            if (this._entityAppearance != obj._entityAppearance)
            {
                ivarsEqual = false;
            }

            if (!this._deadReckoningParameters.Equals(obj._deadReckoningParameters))
            {
                ivarsEqual = false;
            }

            if (obj._marking.Length != 12) 
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 12; idx++)
                {
                    if (this._marking[idx] != obj._marking[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._capabilities != obj._capabilities)
            {
                ivarsEqual = false;
            }

            if (this._articulationParameters.Count != obj._articulationParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    if (!this._articulationParameters[idx].Equals(obj._articulationParameters[idx]))
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

            result = GenerateHash(result) ^ this._entityID.GetHashCode();
            result = GenerateHash(result) ^ this._forceId.GetHashCode();
            result = GenerateHash(result) ^ this._articulationParameterCount.GetHashCode();
            result = GenerateHash(result) ^ this._entityType.GetHashCode();
            result = GenerateHash(result) ^ this._alternativeEntityType.GetHashCode();
            result = GenerateHash(result) ^ this._entityLinearVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._entityLocation.GetHashCode();
            result = GenerateHash(result) ^ this._entityOrientation.GetHashCode();
            result = GenerateHash(result) ^ this._entityAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._deadReckoningParameters.GetHashCode();

            for (int idx = 0; idx < 12; idx++)
            {
                result = GenerateHash(result) ^ this._marking[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ this._capabilities.GetHashCode();

            if (this._articulationParameters.Count > 0)
            {
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._articulationParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
