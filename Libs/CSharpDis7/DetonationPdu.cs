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
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// Detonation or impact of munitions, as well as, non-munition explosions, the burst or initial bloom of chaff, and the ignition of a flare shall be indicated. Section 7.3.3  COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventIdentifier))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(MunitionDescriptor))]
    [XmlInclude(typeof(VariableParameter))]
    public partial class DetonationPdu : WarfareFamilyPdu, IEquatable<DetonationPdu>
    {
        /// <summary>
        /// ID of the expendable entity, Section 7.3.3 
        /// </summary>
        private EntityID _explodingEntityID = new EntityID();

        /// <summary>
        /// ID of event, Section 7.3.3
        /// </summary>
        private EventIdentifier _eventID = new EventIdentifier();

        /// <summary>
        /// velocity of the munition immediately before detonation/impact, Section 7.3.3 
        /// </summary>
        private Vector3Float _velocity = new Vector3Float();

        /// <summary>
        /// location of the munition detonation, the expendable detonation, Section 7.3.3 
        /// </summary>
        private Vector3Double _locationInWorldCoordinates = new Vector3Double();

        /// <summary>
        /// Describes the detonation represented, Section 7.3.3 
        /// </summary>
        private MunitionDescriptor _descriptor = new MunitionDescriptor();

        /// <summary>
        /// Velocity of the ammunition, Section 7.3.3 
        /// </summary>
        private Vector3Float _locationOfEntityCoordinates = new Vector3Float();

        /// <summary>
        /// result of the detonation, Section 7.3.3 
        /// </summary>
        private byte _detonationResult;

        /// <summary>
        /// How many articulation parameters we have, Section 7.3.3 
        /// </summary>
        private byte _numberOfVariableParameters;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _pad;

        /// <summary>
        /// specify the parameter values for each Variable Parameter record, Section 7.3.3 
        /// </summary>
        private List<VariableParameter> _variableParameters = new List<VariableParameter>();

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
            marshalSize += this._explodingEntityID.GetMarshalledSize();  // this._explodingEntityID
            marshalSize += this._eventID.GetMarshalledSize();  // this._eventID
            marshalSize += this._velocity.GetMarshalledSize();  // this._velocity
            marshalSize += this._locationInWorldCoordinates.GetMarshalledSize();  // this._locationInWorldCoordinates
            marshalSize += this._descriptor.GetMarshalledSize();  // this._descriptor
            marshalSize += this._locationOfEntityCoordinates.GetMarshalledSize();  // this._locationOfEntityCoordinates
            marshalSize += 1;  // this._detonationResult
            marshalSize += 1;  // this._numberOfVariableParameters
            marshalSize += 2;  // this._pad
            for (int idx = 0; idx < this._variableParameters.Count; idx++)
            {
                VariableParameter listElement = (VariableParameter)this._variableParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the expendable entity, Section 7.3.3 
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "explodingEntityID")]
        public EntityID ExplodingEntityID
        {
            get
            {
                return this._explodingEntityID;
            }

            set
            {
                this._explodingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of event, Section 7.3.3
        /// </summary>
        [XmlElement(Type = typeof(EventIdentifier), ElementName = "eventID")]
        public EventIdentifier EventID
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
        /// Gets or sets the velocity of the munition immediately before detonation/impact, Section 7.3.3 
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
        /// Gets or sets the location of the munition detonation, the expendable detonation, Section 7.3.3 
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
        /// Gets or sets the Describes the detonation represented, Section 7.3.3 
        /// </summary>
        [XmlElement(Type = typeof(MunitionDescriptor), ElementName = "descriptor")]
        public MunitionDescriptor Descriptor
        {
            get
            {
                return this._descriptor;
            }

            set
            {
                this._descriptor = value;
            }
        }

        /// <summary>
        /// Gets or sets the Velocity of the ammunition, Section 7.3.3 
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "locationOfEntityCoordinates")]
        public Vector3Float LocationOfEntityCoordinates
        {
            get
            {
                return this._locationOfEntityCoordinates;
            }

            set
            {
                this._locationOfEntityCoordinates = value;
            }
        }

        /// <summary>
        /// Gets or sets the result of the detonation, Section 7.3.3 
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
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableParameters method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfVariableParameters")]
        public byte NumberOfVariableParameters
        {
            get
            {
                return this._numberOfVariableParameters;
            }

            set
            {
                this._numberOfVariableParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad")]
        public ushort Pad
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
        /// Gets or sets the specify the parameter values for each Variable Parameter record, Section 7.3.3 
        /// </summary>
        [XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
        public List<VariableParameter> VariableParameters
        {
            get
            {
                return this._variableParameters;
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
                    this._explodingEntityID.Marshal(dos);
                    this._eventID.Marshal(dos);
                    this._velocity.Marshal(dos);
                    this._locationInWorldCoordinates.Marshal(dos);
                    this._descriptor.Marshal(dos);
                    this._locationOfEntityCoordinates.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._detonationResult);
                    dos.WriteUnsignedByte((byte)this._variableParameters.Count);
                    dos.WriteUnsignedShort((ushort)this._pad);

                    for (int idx = 0; idx < this._variableParameters.Count; idx++)
                    {
                        VariableParameter aVariableParameter = (VariableParameter)this._variableParameters[idx];
                        aVariableParameter.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                    this._explodingEntityID.Unmarshal(dis);
                    this._eventID.Unmarshal(dis);
                    this._velocity.Unmarshal(dis);
                    this._locationInWorldCoordinates.Unmarshal(dis);
                    this._descriptor.Unmarshal(dis);
                    this._locationOfEntityCoordinates.Unmarshal(dis);
                    this._detonationResult = dis.ReadUnsignedByte();
                    this._numberOfVariableParameters = dis.ReadUnsignedByte();
                    this._pad = dis.ReadUnsignedShort();
                    for (int idx = 0; idx < this.NumberOfVariableParameters; idx++)
                    {
                        VariableParameter anX = new VariableParameter();
                        anX.Unmarshal(dis);
                        this._variableParameters.Add(anX);
                    };

                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                sb.AppendLine("<explodingEntityID>");
                this._explodingEntityID.Reflection(sb);
                sb.AppendLine("</explodingEntityID>");
                sb.AppendLine("<eventID>");
                this._eventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<velocity>");
                this._velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<locationInWorldCoordinates>");
                this._locationInWorldCoordinates.Reflection(sb);
                sb.AppendLine("</locationInWorldCoordinates>");
                sb.AppendLine("<descriptor>");
                this._descriptor.Reflection(sb);
                sb.AppendLine("</descriptor>");
                sb.AppendLine("<locationOfEntityCoordinates>");
                this._locationOfEntityCoordinates.Reflection(sb);
                sb.AppendLine("</locationOfEntityCoordinates>");
                sb.AppendLine("<detonationResult type=\"byte\">" + this._detonationResult.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
                sb.AppendLine("<variableParameters type=\"byte\">" + this._variableParameters.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
                sb.AppendLine("<pad type=\"ushort\">" + this._pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                for (int idx = 0; idx < this._variableParameters.Count; idx++)
                {
                    sb.AppendLine("<variableParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
                    VariableParameter aVariableParameter = (VariableParameter)this._variableParameters[idx];
                    aVariableParameter.Reflection(sb);
                    sb.AppendLine("</variableParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DetonationPdu>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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

            if (!this._explodingEntityID.Equals(obj._explodingEntityID))
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

            if (!this._descriptor.Equals(obj._descriptor))
            {
                ivarsEqual = false;
            }

            if (!this._locationOfEntityCoordinates.Equals(obj._locationOfEntityCoordinates))
            {
                ivarsEqual = false;
            }

            if (this._detonationResult != obj._detonationResult)
            {
                ivarsEqual = false;
            }

            if (this._numberOfVariableParameters != obj._numberOfVariableParameters)
            {
                ivarsEqual = false;
            }

            if (this._pad != obj._pad)
            {
                ivarsEqual = false;
            }

            if (this._variableParameters.Count != obj._variableParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._variableParameters.Count; idx++)
                {
                    if (!this._variableParameters[idx].Equals(obj._variableParameters[idx]))
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

            result = GenerateHash(result) ^ this._explodingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._eventID.GetHashCode();
            result = GenerateHash(result) ^ this._velocity.GetHashCode();
            result = GenerateHash(result) ^ this._locationInWorldCoordinates.GetHashCode();
            result = GenerateHash(result) ^ this._descriptor.GetHashCode();
            result = GenerateHash(result) ^ this._locationOfEntityCoordinates.GetHashCode();
            result = GenerateHash(result) ^ this._detonationResult.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfVariableParameters.GetHashCode();
            result = GenerateHash(result) ^ this._pad.GetHashCode();

            if (this._variableParameters.Count > 0)
            {
                for (int idx = 0; idx < this._variableParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._variableParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
