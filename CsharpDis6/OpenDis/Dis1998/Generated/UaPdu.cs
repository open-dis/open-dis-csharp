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
    /// Section 5.3.7.3. Information about underwater acoustic emmissions. This requires manual cleanup. The beam data
    /// records should ALL be a the finish, rather than attached to each emitter system. UNFINISHED
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
        /// Initializes a new instance of the <see cref="UaPdu"/> class.
        /// </summary>
        public UaPdu()
        {
            PduType = 29;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(UaPdu left, UaPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(UaPdu left, UaPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EmittingEntityID.GetMarshalledSize();  // this._emittingEntityID
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += 1;  // this._stateChangeIndicator
            marshalSize += 1;  // this._pad
            marshalSize += 2;  // this._passiveParameterIndex
            marshalSize += 1;  // this._propulsionPlantConfiguration
            marshalSize += 1;  // this._numberOfShafts
            marshalSize += 1;  // this._numberOfAPAs
            marshalSize += 1;  // this._numberOfUAEmitterSystems
            for (int idx = 0; idx < ShaftRPMs.Count; idx++)
            {
                var listElement = ShaftRPMs[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < ApaData.Count; idx++)
            {
                var listElement = ApaData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < EmitterSystems.Count; idx++)
            {
                var listElement = EmitterSystems[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity that is the source of the emission
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
        public EntityID EmittingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the This field shall be used to indicate whether the data in the UA PDU represent a state update or
        /// data that have changed since issuance of the last UA PDU
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "stateChangeIndicator")]
        public byte StateChangeIndicator { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad")]
        public byte Pad { get; set; }

        /// <summary>
        /// Gets or sets the This field indicates which database record (or file) shall be used in the definition of passive
        /// signature (unintentional) emissions of the entity. The indicated database record (or file) shall define all noise generated as a function of propulsion plant configurations and associated  auxiliaries.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "passiveParameterIndex")]
        public ushort PassiveParameterIndex { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the entity propulsion plant configuration. This field is used to determine
        /// the passive signature characteristics of an entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "propulsionPlantConfiguration")]
        public byte PropulsionPlantConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the This field shall represent the number of shafts on a platform
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfShafts method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfShafts")]
        public byte NumberOfShafts { get; set; }

        /// <summary>
        /// Gets or sets the This field shall indicate the number of APAs described in the current UA PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfAPAs method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfAPAs")]
        public byte NumberOfAPAs { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the number of UA emitter systems being described in the current UA PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfUAEmitterSystems method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfUAEmitterSystems")]
        public byte NumberOfUAEmitterSystems { get; set; }

        /// <summary>
        /// Gets the shaft RPM values
        /// </summary>
        [XmlElement(ElementName = "shaftRPMsList", Type = typeof(List<ShaftRPMs>))]
        public List<ShaftRPMs> ShaftRPMs { get; } = new();

        /// <summary>
        /// Gets the apaData
        /// </summary>
        [XmlElement(ElementName = "apaDataList", Type = typeof(List<ApaData>))]
        public List<ApaData> ApaData { get; } = new();

        /// <summary>
        /// Gets the emitterSystems
        /// </summary>
        [XmlElement(ElementName = "emitterSystemsList", Type = typeof(List<AcousticEmitterSystemData>))]
        public List<AcousticEmitterSystemData> EmitterSystems { get; } = new();

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
                    EmittingEntityID.Marshal(dos);
                    EventID.Marshal(dos);
                    dos.WriteByte(StateChangeIndicator);
                    dos.WriteByte(Pad);
                    dos.WriteUnsignedShort(PassiveParameterIndex);
                    dos.WriteUnsignedByte(PropulsionPlantConfiguration);
                    dos.WriteUnsignedByte((byte)ShaftRPMs.Count);
                    dos.WriteUnsignedByte((byte)ApaData.Count);
                    dos.WriteUnsignedByte((byte)EmitterSystems.Count);

                    for (int idx = 0; idx < ShaftRPMs.Count; idx++)
                    {
                        var aShaftRPMs = ShaftRPMs[idx];
                        aShaftRPMs.Marshal(dos);
                    }

                    for (int idx = 0; idx < ApaData.Count; idx++)
                    {
                        var aApaData = ApaData[idx];
                        aApaData.Marshal(dos);
                    }

                    for (int idx = 0; idx < EmitterSystems.Count; idx++)
                    {
                        var aAcousticEmitterSystemData = EmitterSystems[idx];
                        aAcousticEmitterSystemData.Marshal(dos);
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
                    EmittingEntityID.Unmarshal(dis);
                    EventID.Unmarshal(dis);
                    StateChangeIndicator = dis.ReadByte();
                    Pad = dis.ReadByte();
                    PassiveParameterIndex = dis.ReadUnsignedShort();
                    PropulsionPlantConfiguration = dis.ReadUnsignedByte();
                    NumberOfShafts = dis.ReadUnsignedByte();
                    NumberOfAPAs = dis.ReadUnsignedByte();
                    NumberOfUAEmitterSystems = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfShafts; idx++)
                    {
                        var anX = new ShaftRPMs();
                        anX.Unmarshal(dis);
                        ShaftRPMs.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfAPAs; idx++)
                    {
                        var anX = new ApaData();
                        anX.Unmarshal(dis);
                        ApaData.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfUAEmitterSystems; idx++)
                    {
                        var anX = new AcousticEmitterSystemData();
                        anX.Unmarshal(dis);
                        EmitterSystems.Add(anX);
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
            sb.AppendLine("<UaPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<emittingEntityID>");
                EmittingEntityID.Reflection(sb);
                sb.AppendLine("</emittingEntityID>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<stateChangeIndicator type=\"byte\">" + StateChangeIndicator.ToString(CultureInfo.InvariantCulture) + "</stateChangeIndicator>");
                sb.AppendLine("<pad type=\"byte\">" + Pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                sb.AppendLine("<passiveParameterIndex type=\"ushort\">" + PassiveParameterIndex.ToString(CultureInfo.InvariantCulture) + "</passiveParameterIndex>");
                sb.AppendLine("<propulsionPlantConfiguration type=\"byte\">" + PropulsionPlantConfiguration.ToString(CultureInfo.InvariantCulture) + "</propulsionPlantConfiguration>");
                sb.AppendLine("<shaftRPMs type=\"byte\">" + ShaftRPMs.Count.ToString(CultureInfo.InvariantCulture) + "</shaftRPMs>");
                sb.AppendLine("<apaData type=\"byte\">" + ApaData.Count.ToString(CultureInfo.InvariantCulture) + "</apaData>");
                sb.AppendLine("<emitterSystems type=\"byte\">" + EmitterSystems.Count.ToString(CultureInfo.InvariantCulture) + "</emitterSystems>");
                for (int idx = 0; idx < ShaftRPMs.Count; idx++)
                {
                    sb.AppendLine("<shaftRPMs" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ShaftRPMs\">");
                    var aShaftRPMs = ShaftRPMs[idx];
                    aShaftRPMs.Reflection(sb);
                    sb.AppendLine("</shaftRPMs" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < ApaData.Count; idx++)
                {
                    sb.AppendLine("<apaData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ApaData\">");
                    var aApaData = ApaData[idx];
                    aApaData.Reflection(sb);
                    sb.AppendLine("</apaData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < EmitterSystems.Count; idx++)
                {
                    sb.AppendLine("<emitterSystems" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticEmitterSystemData\">");
                    var aAcousticEmitterSystemData = EmitterSystems[idx];
                    aAcousticEmitterSystemData.Reflection(sb);
                    sb.AppendLine("</emitterSystems" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</UaPdu>");
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
        public override bool Equals(object obj) => this == obj as UaPdu;

        ///<inheritdoc/>
        public bool Equals(UaPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!EmittingEntityID.Equals(obj.EmittingEntityID))
            {
                ivarsEqual = false;
            }

            if (!EventID.Equals(obj.EventID))
            {
                ivarsEqual = false;
            }

            if (StateChangeIndicator != obj.StateChangeIndicator)
            {
                ivarsEqual = false;
            }

            if (Pad != obj.Pad)
            {
                ivarsEqual = false;
            }

            if (PassiveParameterIndex != obj.PassiveParameterIndex)
            {
                ivarsEqual = false;
            }

            if (PropulsionPlantConfiguration != obj.PropulsionPlantConfiguration)
            {
                ivarsEqual = false;
            }

            if (NumberOfShafts != obj.NumberOfShafts)
            {
                ivarsEqual = false;
            }

            if (NumberOfAPAs != obj.NumberOfAPAs)
            {
                ivarsEqual = false;
            }

            if (NumberOfUAEmitterSystems != obj.NumberOfUAEmitterSystems)
            {
                ivarsEqual = false;
            }

            if (ShaftRPMs.Count != obj.ShaftRPMs.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ShaftRPMs.Count; idx++)
                {
                    if (!ShaftRPMs[idx].Equals(obj.ShaftRPMs[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (ApaData.Count != obj.ApaData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ApaData.Count; idx++)
                {
                    if (!ApaData[idx].Equals(obj.ApaData[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (EmitterSystems.Count != obj.EmitterSystems.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < EmitterSystems.Count; idx++)
                {
                    if (!EmitterSystems[idx].Equals(obj.EmitterSystems[idx]))
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

            result = GenerateHash(result) ^ EmittingEntityID.GetHashCode();
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ StateChangeIndicator.GetHashCode();
            result = GenerateHash(result) ^ Pad.GetHashCode();
            result = GenerateHash(result) ^ PassiveParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ PropulsionPlantConfiguration.GetHashCode();
            result = GenerateHash(result) ^ NumberOfShafts.GetHashCode();
            result = GenerateHash(result) ^ NumberOfAPAs.GetHashCode();
            result = GenerateHash(result) ^ NumberOfUAEmitterSystems.GetHashCode();

            if (ShaftRPMs.Count > 0)
            {
                for (int idx = 0; idx < ShaftRPMs.Count; idx++)
                {
                    result = GenerateHash(result) ^ ShaftRPMs[idx].GetHashCode();
                }
            }

            if (ApaData.Count > 0)
            {
                for (int idx = 0; idx < ApaData.Count; idx++)
                {
                    result = GenerateHash(result) ^ ApaData[idx].GetHashCode();
                }
            }

            if (EmitterSystems.Count > 0)
            {
                for (int idx = 0; idx < EmitterSystems.Count; idx++)
                {
                    result = GenerateHash(result) ^ EmitterSystems[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
