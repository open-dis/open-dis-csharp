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
//  - Jan Birkmann (ELT Group Germany)

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// Section 5.3.7.1. Information about active electronic warfare (EW) emissions and active EW countermeasures shall be communicated using an Electromagnetic Emission PDU. NOT COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventIdentifier))]
    [XmlInclude(typeof(EmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(EmissionSystem))]
    public partial class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
    {
        /// <summary>
        /// ID of the entity emitting
        /// </summary>
        private EntityID _emittingEntityID = new EntityID();

        /// <summary>
        /// ID of event
        /// </summary>
        private EventIdentifier _eventID = new EventIdentifier();

        /// <summary>
        /// This field shall be used to indicate if the data in the PDU represents a state update or just data that has changed since issuance of the last Electromagnetic Emission PDU [relative to the identified entity and emission system(s)].
        /// </summary>
        private byte _stateUpdateIndicator;

        /// <summary>
        /// This field shall specify the number of emission systems being described in the current PDU.
        /// </summary>
        private byte _numberOfSystems;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _paddingForEmissionsPdu;

        /// <summary>
        /// Information about a particular emitter system 
        /// </summary>
        private List<EmissionSystem> _emissionSystems = new List<EmissionSystem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicEmissionsPdu"/> class.
        /// </summary>
        public ElectronicEmissionsPdu()
        {
            PduType = (byte)23;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ElectronicEmissionsPdu left, ElectronicEmissionsPdu right)
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
        public static bool operator ==(ElectronicEmissionsPdu left, ElectronicEmissionsPdu right)
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
            marshalSize += this._emittingEntityID.GetMarshalledSize();  // this._emittingEntityID
            marshalSize += this._eventID.GetMarshalledSize();  // this._eventID
            marshalSize += 1;  // this._stateUpdateIndicator
            marshalSize += 1;  // this._numberOfSystems
            marshalSize += 2;  // this._paddingForEmissionsPdu
            for (int idx = 0; idx < this._numberOfSystems; idx++)
            {
                EmissionSystem listElement = this._emissionSystems[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity emitting
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
        public EntityID EmittingEntityID
        {
            get
            {
                return this._emittingEntityID;
            }

            set
            {
                this._emittingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of event
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
        /// Gets or sets the This field shall be used to indicate if the data in the PDU represents a state update or just data that has changed since issuance of the last Electromagnetic Emission PDU [relative to the identified entity and emission system(s)].
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
        public byte StateUpdateIndicator
        {
            get
            {
                return this._stateUpdateIndicator;
            }

            set
            {
                this._stateUpdateIndicator = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
        public byte NumberOfSystems
        {
            get
            {
                return this._numberOfSystems;
            }

            set
            {
                this._numberOfSystems = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "paddingForEmissionsPdu")]
        public ushort PaddingForEmissionsPdu
        {
            get
            {
                return this._paddingForEmissionsPdu;
            }

            set
            {
                this._paddingForEmissionsPdu = value;
            }
        }

        /// <summary>
        /// Gets or sets the Electronic emmissions systems
        /// </summary>
        [XmlElement(ElementName = "emissionSystemList", Type = typeof(List<EmissionSystem>))]
        public List<EmissionSystem> EmissionSystems
        {
            get
            {
                return this._emissionSystems;
            }

            set
            {
                this._emissionSystems = value;
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
                    this._emittingEntityID.Marshal(dos);
                    this._eventID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._stateUpdateIndicator);
                    dos.WriteUnsignedByte((byte)this._numberOfSystems);
                    dos.WriteUnsignedShort((ushort)this._paddingForEmissionsPdu);

                    for (int idx = 0; idx < this._numberOfSystems; idx++)
                    {
                        EmissionSystem system = this._emissionSystems[idx];
                        system.Marshal(dos);
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
                    this._emittingEntityID.Unmarshal(dis);
                    this._eventID.Unmarshal(dis);
                    this._stateUpdateIndicator = dis.ReadUnsignedByte();
                    this._numberOfSystems = dis.ReadUnsignedByte();
                    this._paddingForEmissionsPdu = dis.ReadUnsignedShort();
                    for (int idx = 0; idx < this.NumberOfSystems; idx++)
                    {
                        EmissionSystem system = new EmissionSystem();
                        system.Unmarshal(dis);
                        this._emissionSystems.Add(system);
                    }
                    ;

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
            sb.AppendLine("<ElectronicEmissionsPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<emittingEntityID>");
                this._emittingEntityID.Reflection(sb);
                sb.AppendLine("</emittingEntityID>");
                sb.AppendLine("<eventID>");
                this._eventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<stateUpdateIndicator type=\"byte\">" + this._stateUpdateIndicator.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
                sb.AppendLine("<numberOfSystems type=\"byte\">" + this._numberOfSystems.ToString(CultureInfo.InvariantCulture) + "</numberOfSystems>");
                sb.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + this._paddingForEmissionsPdu.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
                for (int idx = 0; idx < this._emissionSystems.Count; idx++)
                {
                    sb.AppendLine("<emissionSystems" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EmissionSystem\">");
                    EmissionSystem system = this._emissionSystems[idx];
                    system.Reflection(sb);
                    sb.AppendLine("</emissionSystems" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ElectronicEmissionsPdu>");
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
            return this == obj as ElectronicEmissionsPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ElectronicEmissionsPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._emittingEntityID.Equals(obj._emittingEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._eventID.Equals(obj._eventID))
            {
                ivarsEqual = false;
            }

            if (this._stateUpdateIndicator != obj._stateUpdateIndicator)
            {
                ivarsEqual = false;
            }

            if (this._numberOfSystems != obj._numberOfSystems)
            {
                ivarsEqual = false;
            }

            if (this._paddingForEmissionsPdu != obj._paddingForEmissionsPdu)
            {
                ivarsEqual = false;
            }

            if (this._emissionSystems.Count != obj._emissionSystems.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._emissionSystems.Count; idx++)
                {
                    if (!this._emissionSystems[idx].Equals(obj._emissionSystems[idx]))
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

            result = GenerateHash(result) ^ this._emittingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._eventID.GetHashCode();
            result = GenerateHash(result) ^ this._stateUpdateIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSystems.GetHashCode();
            result = GenerateHash(result) ^ this._paddingForEmissionsPdu.GetHashCode();

            if (this._numberOfSystems > 0)
            {
                for (int idx = 0; idx < this._numberOfSystems; idx++)
                {
                    result = GenerateHash(result) ^ this._emissionSystems[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
