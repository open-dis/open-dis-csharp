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
    /// Section 5.3.7.3. Information about underwater acoustic emmissions. This requires manual cleanup. The beam data records should ALL be a the finish, rather than attached to each emitter system. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(ShaftRPMs))]
    [XmlInclude(typeof(ApaData))]
    [XmlInclude(typeof(AcousticEmitterSystemData))]
    public partial class UaPdu : DistributedEmissionsFamilyPdu, IEquatable<UaPdu>
    {
        /// <summary>
        /// ID of the entity that is the source of the emission
        /// </summary>
        private EntityID _emittingEntityID = new EntityID();

        /// <summary>
        /// ID of event
        /// </summary>
        private EventID _eventID = new EventID();

        /// <summary>
        /// This field shall be used to indicate whether the data in the UA PDU represent a state update or data that have changed since issuance of the last UA PDU
        /// </summary>
        private byte _stateChangeIndicator;

        /// <summary>
        /// padding
        /// </summary>
        private byte _pad;

        /// <summary>
        /// This field indicates which database record (or file) shall be used in the definition of passive signature (unintentional) emissions of the entity. The indicated database record (or  file) shall define all noise generated as a function of propulsion plant configurations and associated  auxiliaries.
        /// </summary>
        private ushort _passiveParameterIndex;

        /// <summary>
        /// This field shall specify the entity propulsion plant configuration. This field is used to determine the passive signature characteristics of an entity.
        /// </summary>
        private byte _propulsionPlantConfiguration;

        /// <summary>
        ///  This field shall represent the number of shafts on a platform
        /// </summary>
        private byte _numberOfShafts;

        /// <summary>
        /// This field shall indicate the number of APAs described in the current UA PDU
        /// </summary>
        private byte _numberOfAPAs;

        /// <summary>
        /// This field shall specify the number of UA emitter systems being described in the current UA PDU
        /// </summary>
        private byte _numberOfUAEmitterSystems;

        /// <summary>
        /// shaft RPM values
        /// </summary>
        private List<ShaftRPMs> _shaftRPMs = new List<ShaftRPMs>();

        /// <summary>
        /// apaData
        /// </summary>
        private List<ApaData> _apaData = new List<ApaData>();

        private List<AcousticEmitterSystemData> _emitterSystems = new List<AcousticEmitterSystemData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UaPdu"/> class.
        /// </summary>
        public UaPdu()
        {
            PduType = (byte)29;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(UaPdu left, UaPdu right)
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
        public static bool operator ==(UaPdu left, UaPdu right)
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
            marshalSize += 1;  // this._stateChangeIndicator
            marshalSize += 1;  // this._pad
            marshalSize += 2;  // this._passiveParameterIndex
            marshalSize += 1;  // this._propulsionPlantConfiguration
            marshalSize += 1;  // this._numberOfShafts
            marshalSize += 1;  // this._numberOfAPAs
            marshalSize += 1;  // this._numberOfUAEmitterSystems
            for (int idx = 0; idx < this._shaftRPMs.Count; idx++)
            {
                ShaftRPMs listElement = (ShaftRPMs)this._shaftRPMs[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._apaData.Count; idx++)
            {
                ApaData listElement = (ApaData)this._apaData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._emitterSystems.Count; idx++)
            {
                AcousticEmitterSystemData listElement = (AcousticEmitterSystemData)this._emitterSystems[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity that is the source of the emission
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
        /// Gets or sets the This field shall be used to indicate whether the data in the UA PDU represent a state update or data that have changed since issuance of the last UA PDU
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "stateChangeIndicator")]
        public byte StateChangeIndicator
        {
            get
            {
                return this._stateChangeIndicator;
            }

            set
            {
                this._stateChangeIndicator = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad")]
        public byte Pad
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
        /// Gets or sets the This field indicates which database record (or file) shall be used in the definition of passive signature (unintentional) emissions of the entity. The indicated database record (or  file) shall define all noise generated as a function of propulsion plant configurations and associated  auxiliaries.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "passiveParameterIndex")]
        public ushort PassiveParameterIndex
        {
            get
            {
                return this._passiveParameterIndex;
            }

            set
            {
                this._passiveParameterIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the entity propulsion plant configuration. This field is used to determine the passive signature characteristics of an entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "propulsionPlantConfiguration")]
        public byte PropulsionPlantConfiguration
        {
            get
            {
                return this._propulsionPlantConfiguration;
            }

            set
            {
                this._propulsionPlantConfiguration = value;
            }
        }

        /// <summary>
        /// Gets or sets the  This field shall represent the number of shafts on a platform
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfShafts method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfShafts")]
        public byte NumberOfShafts
        {
            get
            {
                return this._numberOfShafts;
            }

            set
            {
                this._numberOfShafts = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall indicate the number of APAs described in the current UA PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfAPAs method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfAPAs")]
        public byte NumberOfAPAs
        {
            get
            {
                return this._numberOfAPAs;
            }

            set
            {
                this._numberOfAPAs = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the number of UA emitter systems being described in the current UA PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfUAEmitterSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfUAEmitterSystems")]
        public byte NumberOfUAEmitterSystems
        {
            get
            {
                return this._numberOfUAEmitterSystems;
            }

            set
            {
                this._numberOfUAEmitterSystems = value;
            }
        }

        /// <summary>
        /// Gets the shaft RPM values
        /// </summary>
        [XmlElement(ElementName = "shaftRPMsList", Type = typeof(List<ShaftRPMs>))]
        public List<ShaftRPMs> ShaftRPMs
        {
            get
            {
                return this._shaftRPMs;
            }
        }

        /// <summary>
        /// Gets the apaData
        /// </summary>
        [XmlElement(ElementName = "apaDataList", Type = typeof(List<ApaData>))]
        public List<ApaData> ApaData
        {
            get
            {
                return this._apaData;
            }
        }

        /// <summary>
        /// Gets the emitterSystems
        /// </summary>
        [XmlElement(ElementName = "emitterSystemsList", Type = typeof(List<AcousticEmitterSystemData>))]
        public List<AcousticEmitterSystemData> EmitterSystems
        {
            get
            {
                return this._emitterSystems;
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
                    dos.WriteByte((byte)this._stateChangeIndicator);
                    dos.WriteByte((byte)this._pad);
                    dos.WriteUnsignedShort((ushort)this._passiveParameterIndex);
                    dos.WriteUnsignedByte((byte)this._propulsionPlantConfiguration);
                    dos.WriteUnsignedByte((byte)this._shaftRPMs.Count);
                    dos.WriteUnsignedByte((byte)this._apaData.Count);
                    dos.WriteUnsignedByte((byte)this._emitterSystems.Count);

                    for (int idx = 0; idx < this._shaftRPMs.Count; idx++)
                    {
                        ShaftRPMs aShaftRPMs = (ShaftRPMs)this._shaftRPMs[idx];
                        aShaftRPMs.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._apaData.Count; idx++)
                    {
                        ApaData aApaData = (ApaData)this._apaData[idx];
                        aApaData.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._emitterSystems.Count; idx++)
                    {
                        AcousticEmitterSystemData aAcousticEmitterSystemData = (AcousticEmitterSystemData)this._emitterSystems[idx];
                        aAcousticEmitterSystemData.Marshal(dos);
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
                    this._stateChangeIndicator = dis.ReadByte();
                    this._pad = dis.ReadByte();
                    this._passiveParameterIndex = dis.ReadUnsignedShort();
                    this._propulsionPlantConfiguration = dis.ReadUnsignedByte();
                    this._numberOfShafts = dis.ReadUnsignedByte();
                    this._numberOfAPAs = dis.ReadUnsignedByte();
                    this._numberOfUAEmitterSystems = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.NumberOfShafts; idx++)
                    {
                        ShaftRPMs anX = new ShaftRPMs();
                        anX.Unmarshal(dis);
                        this._shaftRPMs.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfAPAs; idx++)
                    {
                        ApaData anX = new ApaData();
                        anX.Unmarshal(dis);
                        this._apaData.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfUAEmitterSystems; idx++)
                    {
                        AcousticEmitterSystemData anX = new AcousticEmitterSystemData();
                        anX.Unmarshal(dis);
                        this._emitterSystems.Add(anX);
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
            sb.AppendLine("<UaPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<emittingEntityID>");
                this._emittingEntityID.Reflection(sb);
                sb.AppendLine("</emittingEntityID>");
                sb.AppendLine("<eventID>");
                this._eventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<stateChangeIndicator type=\"byte\">" + this._stateChangeIndicator.ToString(CultureInfo.InvariantCulture) + "</stateChangeIndicator>");
                sb.AppendLine("<pad type=\"byte\">" + this._pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<passiveParameterIndex type=\"ushort\">" + this._passiveParameterIndex.ToString(CultureInfo.InvariantCulture) + "</passiveParameterIndex>");
                sb.AppendLine("<propulsionPlantConfiguration type=\"byte\">" + this._propulsionPlantConfiguration.ToString(CultureInfo.InvariantCulture) + "</propulsionPlantConfiguration>");
                sb.AppendLine("<shaftRPMs type=\"byte\">" + this._shaftRPMs.Count.ToString(CultureInfo.InvariantCulture) + "</shaftRPMs>");
                sb.AppendLine("<apaData type=\"byte\">" + this._apaData.Count.ToString(CultureInfo.InvariantCulture) + "</apaData>");
                sb.AppendLine("<emitterSystems type=\"byte\">" + this._emitterSystems.Count.ToString(CultureInfo.InvariantCulture) + "</emitterSystems>");
                for (int idx = 0; idx < this._shaftRPMs.Count; idx++)
                {
                    sb.AppendLine("<shaftRPMs" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ShaftRPMs\">");
                    ShaftRPMs aShaftRPMs = (ShaftRPMs)this._shaftRPMs[idx];
                    aShaftRPMs.Reflection(sb);
                    sb.AppendLine("</shaftRPMs" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._apaData.Count; idx++)
                {
                    sb.AppendLine("<apaData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ApaData\">");
                    ApaData aApaData = (ApaData)this._apaData[idx];
                    aApaData.Reflection(sb);
                    sb.AppendLine("</apaData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._emitterSystems.Count; idx++)
                {
                    sb.AppendLine("<emitterSystems" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticEmitterSystemData\">");
                    AcousticEmitterSystemData aAcousticEmitterSystemData = (AcousticEmitterSystemData)this._emitterSystems[idx];
                    aAcousticEmitterSystemData.Reflection(sb);
                    sb.AppendLine("</emitterSystems" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</UaPdu>");
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
            return this == obj as UaPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(UaPdu obj)
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

            if (this._stateChangeIndicator != obj._stateChangeIndicator)
            {
                ivarsEqual = false;
            }

            if (this._pad != obj._pad)
            {
                ivarsEqual = false;
            }

            if (this._passiveParameterIndex != obj._passiveParameterIndex)
            {
                ivarsEqual = false;
            }

            if (this._propulsionPlantConfiguration != obj._propulsionPlantConfiguration)
            {
                ivarsEqual = false;
            }

            if (this._numberOfShafts != obj._numberOfShafts)
            {
                ivarsEqual = false;
            }

            if (this._numberOfAPAs != obj._numberOfAPAs)
            {
                ivarsEqual = false;
            }

            if (this._numberOfUAEmitterSystems != obj._numberOfUAEmitterSystems)
            {
                ivarsEqual = false;
            }

            if (this._shaftRPMs.Count != obj._shaftRPMs.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._shaftRPMs.Count; idx++)
                {
                    if (!this._shaftRPMs[idx].Equals(obj._shaftRPMs[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._apaData.Count != obj._apaData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._apaData.Count; idx++)
                {
                    if (!this._apaData[idx].Equals(obj._apaData[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._emitterSystems.Count != obj._emitterSystems.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._emitterSystems.Count; idx++)
                {
                    if (!this._emitterSystems[idx].Equals(obj._emitterSystems[idx]))
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
            result = GenerateHash(result) ^ this._stateChangeIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._pad.GetHashCode();
            result = GenerateHash(result) ^ this._passiveParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ this._propulsionPlantConfiguration.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfShafts.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfAPAs.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfUAEmitterSystems.GetHashCode();

            if (this._shaftRPMs.Count > 0)
            {
                for (int idx = 0; idx < this._shaftRPMs.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._shaftRPMs[idx].GetHashCode();
                }
            }

            if (this._apaData.Count > 0)
            {
                for (int idx = 0; idx < this._apaData.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._apaData[idx].GetHashCode();
                }
            }

            if (this._emitterSystems.Count > 0)
            {
                for (int idx = 0; idx < this._emitterSystems.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._emitterSystems[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
