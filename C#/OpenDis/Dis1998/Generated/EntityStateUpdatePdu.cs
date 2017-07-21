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
    /// 5.3.3.4. Nonstatic information about a particular entity may be communicated by issuing an Entity State Update PDU. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class EntityStateUpdatePdu : EntityInformationFamilyPdu, IEquatable<EntityStateUpdatePdu>
    {
        /// <summary>
        /// This field shall identify the entity issuing the PDU
        /// </summary>
        private EntityID _entityID = new EntityID();

        /// <summary>
        /// Padding
        /// </summary>
        private byte _padding1;

        /// <summary>
        /// How many articulation parameters are in the variable length list
        /// </summary>
        private byte _numberOfArticulationParameters;

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

        private List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStateUpdatePdu"/> class.
        /// </summary>
        public EntityStateUpdatePdu()
        {
            PduType = (byte)67;
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
        public static bool operator !=(EntityStateUpdatePdu left, EntityStateUpdatePdu right)
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
        public static bool operator ==(EntityStateUpdatePdu left, EntityStateUpdatePdu right)
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
            marshalSize += 1;  // this._padding1
            marshalSize += 1;  // this._numberOfArticulationParameters
            marshalSize += this._entityLinearVelocity.GetMarshalledSize();  // this._entityLinearVelocity
            marshalSize += this._entityLocation.GetMarshalledSize();  // this._entityLocation
            marshalSize += this._entityOrientation.GetMarshalledSize();  // this._entityOrientation
            marshalSize += 4;  // this._entityAppearance
            for (int idx = 0; idx < this._articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)this._articulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall identify the entity issuing the PDU
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
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding1")]
        public byte Padding1
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
        /// Gets or sets the How many articulation parameters are in the variable length list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters
        {
            get
            {
                return this._numberOfArticulationParameters;
            }

            set
            {
                this._numberOfArticulationParameters = value;
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
        /// Gets the articulationParameters
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
                    dos.WriteByte((byte)this._padding1);
                    dos.WriteUnsignedByte((byte)this._articulationParameters.Count);
                    this._entityLinearVelocity.Marshal(dos);
                    this._entityLocation.Marshal(dos);
                    this._entityOrientation.Marshal(dos);
                    dos.WriteInt((int)this._entityAppearance);

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
                    this._padding1 = dis.ReadByte();
                    this._numberOfArticulationParameters = dis.ReadUnsignedByte();
                    this._entityLinearVelocity.Unmarshal(dis);
                    this._entityLocation.Unmarshal(dis);
                    this._entityOrientation.Unmarshal(dis);
                    this._entityAppearance = dis.ReadInt();

                    for (int idx = 0; idx < this.NumberOfArticulationParameters; idx++)
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
            sb.AppendLine("<EntityStateUpdatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<entityID>");
                this._entityID.Reflection(sb);
                sb.AppendLine("</entityID>");
                sb.AppendLine("<padding1 type=\"byte\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + this._articulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
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
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</EntityStateUpdatePdu>");
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
            return this == obj as EntityStateUpdatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EntityStateUpdatePdu obj)
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

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (this._numberOfArticulationParameters != obj._numberOfArticulationParameters)
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
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ this._entityLinearVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._entityLocation.GetHashCode();
            result = GenerateHash(result) ^ this._entityOrientation.GetHashCode();
            result = GenerateHash(result) ^ this._entityAppearance.GetHashCode();

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
