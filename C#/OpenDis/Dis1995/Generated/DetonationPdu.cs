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
    /// Section 5.3.4.2. Information about Stuff Exploding
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(BurstDescriptor))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class DetonationPdu : Warfare, IEquatable<DetonationPdu>
    {
        /// <summary>
        /// ID of muntion that was fired
        /// </summary>
        private EntityID _munitionID = new EntityID();

        /// <summary>
        /// ID firing event
        /// </summary>
        private EventID _eventID = new EventID();

        /// <summary>
        /// ID firing event
        /// </summary>
        private Vector3Float _velocity = new Vector3Float();

        /// <summary>
        /// where the detonation is, in world coordinates
        /// </summary>
        private Vector3Double _locationInWorldCoordinates = new Vector3Double();

        /// <summary>
        /// Describes munition used
        /// </summary>
        private BurstDescriptor _burstDescriptor = new BurstDescriptor();

        /// <summary>
        /// result of the explosion
        /// </summary>
        private byte _detonationResult;

        /// <summary>
        /// How many articulation parameters we have
        /// </summary>
        private byte _numberOfArticulationParameters;

        /// <summary>
        /// padding
        /// </summary>
        private short _pad;

        private List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DetonationPdu"/> class.
        /// </summary>
        public DetonationPdu()
        {
            PduType = (byte)3;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DetonationPdu left, DetonationPdu right)
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
        public static bool operator ==(DetonationPdu left, DetonationPdu right)
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
            marshalSize += this._munitionID.GetMarshalledSize();  // this._munitionID
            marshalSize += this._eventID.GetMarshalledSize();  // this._eventID
            marshalSize += this._velocity.GetMarshalledSize();  // this._velocity
            marshalSize += this._locationInWorldCoordinates.GetMarshalledSize();  // this._locationInWorldCoordinates
            marshalSize += this._burstDescriptor.GetMarshalledSize();  // this._burstDescriptor
            marshalSize += 1;  // this._detonationResult
            marshalSize += 1;  // this._numberOfArticulationParameters
            marshalSize += 2;  // this._pad
            for (int idx = 0; idx < this._articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)this._articulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of muntion that was fired
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "munitionID")]
        public EntityID MunitionID
        {
            get
            {
                return this._munitionID;
            }

            set
            {
                this._munitionID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID firing event
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
        /// Gets or sets the ID firing event
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
        /// Gets or sets the where the detonation is, in world coordinates
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
        public Vector3Double LocationInWorldCoordinates
        {
            get
            {
                return this._locationInWorldCoordinates;
            }

            set
            {
                this._locationInWorldCoordinates = value;
            }
        }

        /// <summary>
        /// Gets or sets the Describes munition used
        /// </summary>
        [XmlElement(Type = typeof(BurstDescriptor), ElementName = "burstDescriptor")]
        public BurstDescriptor BurstDescriptor
        {
            get
            {
                return this._burstDescriptor;
            }

            set
            {
                this._burstDescriptor = value;
            }
        }

        /// <summary>
        /// Gets or sets the result of the explosion
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "detonationResult")]
        public byte DetonationResult
        {
            get
            {
                return this._detonationResult;
            }

            set
            {
                this._detonationResult = value;
            }
        }

        /// <summary>
        /// Gets or sets the How many articulation parameters we have
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
        /// Gets or sets the padding
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
                    this._munitionID.Marshal(dos);
                    this._eventID.Marshal(dos);
                    this._velocity.Marshal(dos);
                    this._locationInWorldCoordinates.Marshal(dos);
                    this._burstDescriptor.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._detonationResult);
                    dos.WriteUnsignedByte((byte)this._articulationParameters.Count);
                    dos.WriteShort((short)this._pad);

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
                    this._munitionID.Unmarshal(dis);
                    this._eventID.Unmarshal(dis);
                    this._velocity.Unmarshal(dis);
                    this._locationInWorldCoordinates.Unmarshal(dis);
                    this._burstDescriptor.Unmarshal(dis);
                    this._detonationResult = dis.ReadUnsignedByte();
                    this._numberOfArticulationParameters = dis.ReadUnsignedByte();
                    this._pad = dis.ReadShort();

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
            sb.AppendLine("<DetonationPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<munitionID>");
                this._munitionID.Reflection(sb);
                sb.AppendLine("</munitionID>");
                sb.AppendLine("<eventID>");
                this._eventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<velocity>");
                this._velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<locationInWorldCoordinates>");
                this._locationInWorldCoordinates.Reflection(sb);
                sb.AppendLine("</locationInWorldCoordinates>");
                sb.AppendLine("<burstDescriptor>");
                this._burstDescriptor.Reflection(sb);
                sb.AppendLine("</burstDescriptor>");
                sb.AppendLine("<detonationResult type=\"byte\">" + this._detonationResult.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + this._articulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<pad type=\"short\">" + this._pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DetonationPdu>");
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
            return this == obj as DetonationPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DetonationPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._munitionID.Equals(obj._munitionID))
            {
                ivarsEqual = false;
            }

            if (!this._eventID.Equals(obj._eventID))
            {
                ivarsEqual = false;
            }

            if (!this._velocity.Equals(obj._velocity))
            {
                ivarsEqual = false;
            }

            if (!this._locationInWorldCoordinates.Equals(obj._locationInWorldCoordinates))
            {
                ivarsEqual = false;
            }

            if (!this._burstDescriptor.Equals(obj._burstDescriptor))
            {
                ivarsEqual = false;
            }

            if (this._detonationResult != obj._detonationResult)
            {
                ivarsEqual = false;
            }

            if (this._numberOfArticulationParameters != obj._numberOfArticulationParameters)
            {
                ivarsEqual = false;
            }

            if (this._pad != obj._pad)
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

            result = GenerateHash(result) ^ this._munitionID.GetHashCode();
            result = GenerateHash(result) ^ this._eventID.GetHashCode();
            result = GenerateHash(result) ^ this._velocity.GetHashCode();
            result = GenerateHash(result) ^ this._locationInWorldCoordinates.GetHashCode();
            result = GenerateHash(result) ^ this._burstDescriptor.GetHashCode();
            result = GenerateHash(result) ^ this._detonationResult.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ this._pad.GetHashCode();

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
