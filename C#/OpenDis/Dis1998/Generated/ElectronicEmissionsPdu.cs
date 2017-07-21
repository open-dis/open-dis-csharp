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
    /// Section 5.3.7.1. Information about active electronic warfare (EW) emissions and active EW countermeasures shall be communicated using an Electromagnetic Emission PDU. COMPLETE (I think)
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(ElectronicEmissionSystemData))]
    public partial class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
    {
        /// <summary>
        /// ID of the entity emitting
        /// </summary>
        private EntityID _emittingEntityID = new EntityID();

        /// <summary>
        /// ID of event
        /// </summary>
        private EventID _eventID = new EventID();

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
        /// Electronic emmissions systems
        /// </summary>
        private List<ElectronicEmissionSystemData> _systems = new List<ElectronicEmissionSystemData>();

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
            for (int idx = 0; idx < this._systems.Count; idx++)
            {
                ElectronicEmissionSystemData listElement = (ElectronicEmissionSystemData)this._systems[idx];
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
        /// Gets or sets the This field shall specify the number of emission systems being described in the current PDU.
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
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
        /// Gets the Electronic emmissions systems
        /// </summary>
        [XmlElement(ElementName = "systemsList", Type = typeof(List<ElectronicEmissionSystemData>))]
        public List<ElectronicEmissionSystemData> Systems
        {
            get
            {
                return this._systems;
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
                    dos.WriteUnsignedByte((byte)this._systems.Count);
                    dos.WriteUnsignedShort((ushort)this._paddingForEmissionsPdu);

                    for (int idx = 0; idx < this._systems.Count; idx++)
                    {
                        ElectronicEmissionSystemData aElectronicEmissionSystemData = (ElectronicEmissionSystemData)this._systems[idx];
                        aElectronicEmissionSystemData.Marshal(dos);
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
                    this._emittingEntityID.Unmarshal(dis);
                    this._eventID.Unmarshal(dis);
                    this._stateUpdateIndicator = dis.ReadUnsignedByte();
                    this._numberOfSystems = dis.ReadUnsignedByte();
                    this._paddingForEmissionsPdu = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfSystems; idx++)
                    {
                        ElectronicEmissionSystemData anX = new ElectronicEmissionSystemData();
                        anX.Unmarshal(dis);
                        this._systems.Add(anX);
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
                sb.AppendLine("<systems type=\"byte\">" + this._systems.Count.ToString(CultureInfo.InvariantCulture) + "</systems>");
                sb.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + this._paddingForEmissionsPdu.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
                for (int idx = 0; idx < this._systems.Count; idx++)
                {
                    sb.AppendLine("<systems" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionSystemData\">");
                    ElectronicEmissionSystemData aElectronicEmissionSystemData = (ElectronicEmissionSystemData)this._systems[idx];
                    aElectronicEmissionSystemData.Reflection(sb);
                    sb.AppendLine("</systems" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ElectronicEmissionsPdu>");
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

            if (this._systems.Count != obj._systems.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._systems.Count; idx++)
                {
                    if (!this._systems[idx].Equals(obj._systems[idx]))
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

            if (this._systems.Count > 0)
            {
                for (int idx = 0; idx < this._systems.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._systems[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
