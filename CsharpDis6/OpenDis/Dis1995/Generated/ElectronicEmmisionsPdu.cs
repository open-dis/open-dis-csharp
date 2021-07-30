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

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Section 5.3.7.1. Information about active electronic warfare (EW) emissions and active EW countermeasures shall
    /// be com- municated using an Electromagnetic Emission PDU.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(EmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(FundamentalParameterData))]
    public partial class ElectronicEmmisionsPdu : DistributedEmissionsPdu, IEquatable<ElectronicEmmisionsPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicEmmisionsPdu"/> class.
        /// </summary>
        public ElectronicEmmisionsPdu()
        {
            PduType = 23;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ElectronicEmmisionsPdu left, ElectronicEmmisionsPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ElectronicEmmisionsPdu left, ElectronicEmmisionsPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EmittingEntityID.GetMarshalledSize();  // this._emittingEntityID
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += 1;  // this._stateUpdateIndicator
            marshalSize += 1;  // this._numberOfSystems
            marshalSize += 2;  // this._emissionsPadding
            marshalSize += 1;  // this._systemDataLength
            marshalSize += 1;  // this._numberOfBeams
            marshalSize += 2;  // this._emissionsPadding2
            marshalSize += EmitterSystem.GetMarshalledSize();  // this._emitterSystem
            marshalSize += Location.GetMarshalledSize();  // this._location
            marshalSize += 1;  // this._beamDataLength
            marshalSize += 1;  // this._beamIdNumber
            marshalSize += 2;  // this._beamParameterIndex
            marshalSize += FundamentalParameterData.GetMarshalledSize();  // this._fundamentalParameterData
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity emitting
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
        public EntityID EmittingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the This field shall be used to indicate if the data in the PDU represents a state update or just
        /// data that has changed since issuance of the last Electromagnetic Emission PDU [rela-  tive to the identified entity and emission system(s)].
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
        public byte StateUpdateIndicator { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the number of emission systems being described in the current PDU.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
        public byte NumberOfSystems { get; set; }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding")]
        public ushort EmissionsPadding { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the length of this emitter system’s data (including beam data and its
        /// track/jam information) in 32-bit words. The length shall include the System Data Length field.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
        public byte SystemDataLength { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the number of beams being described in the current PDU for the system
        /// being described.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
        public byte NumberOfBeams { get; set; }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
        public ushort EmissionsPadding2 { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify information about a particular emitter system
        /// </summary>
        [XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
        public EmitterSystem EmitterSystem { get; set; } = new EmitterSystem();

        /// <summary>
        /// Gets or sets the Location with respect to the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the This field shall specify the length of this beam’s data (including track/ jam information) in
        /// 32-bit words. The length shall include the Beam Data Length field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
        public byte BeamDataLength { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify a unique emitter database number assigned to differentiate between otherwise
        /// similar or identical emitter beams within an emitter  system.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamIdNumber")]
        public byte BeamIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify a Beam Parameter Index number that shall be used by receiving entities
        /// in conjunction with the Emitter Name field to provide a  pointer to the stored database parameters required to regenerate the beam.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
        public ushort BeamParameterIndex { get; set; }

        /// <summary>
        /// Gets or sets the Fundamental parameter data such as frequency range, beam sweep, etc.
        /// </summary>
        [XmlElement(Type = typeof(FundamentalParameterData), ElementName = "fundamentalParameterData")]
        public FundamentalParameterData FundamentalParameterData { get; set; } = new FundamentalParameterData();

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
                    dos.WriteUnsignedByte(StateUpdateIndicator);
                    dos.WriteUnsignedByte(NumberOfSystems);
                    dos.WriteUnsignedShort(EmissionsPadding);
                    dos.WriteUnsignedByte(SystemDataLength);
                    dos.WriteUnsignedByte(NumberOfBeams);
                    dos.WriteUnsignedShort(EmissionsPadding2);
                    EmitterSystem.Marshal(dos);
                    Location.Marshal(dos);
                    dos.WriteUnsignedByte(BeamDataLength);
                    dos.WriteUnsignedByte(BeamIdNumber);
                    dos.WriteUnsignedShort(BeamParameterIndex);
                    FundamentalParameterData.Marshal(dos);
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
                    StateUpdateIndicator = dis.ReadUnsignedByte();
                    NumberOfSystems = dis.ReadUnsignedByte();
                    EmissionsPadding = dis.ReadUnsignedShort();
                    SystemDataLength = dis.ReadUnsignedByte();
                    NumberOfBeams = dis.ReadUnsignedByte();
                    EmissionsPadding2 = dis.ReadUnsignedShort();
                    EmitterSystem.Unmarshal(dis);
                    Location.Unmarshal(dis);
                    BeamDataLength = dis.ReadUnsignedByte();
                    BeamIdNumber = dis.ReadUnsignedByte();
                    BeamParameterIndex = dis.ReadUnsignedShort();
                    FundamentalParameterData.Unmarshal(dis);
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
            sb.AppendLine("<ElectronicEmmisionsPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<emittingEntityID>");
                EmittingEntityID.Reflection(sb);
                sb.AppendLine("</emittingEntityID>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<stateUpdateIndicator type=\"byte\">" + StateUpdateIndicator.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
                sb.AppendLine("<numberOfSystems type=\"byte\">" + NumberOfSystems.ToString(CultureInfo.InvariantCulture) + "</numberOfSystems>");
                sb.AppendLine("<emissionsPadding type=\"ushort\">" + EmissionsPadding.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding>");
                sb.AppendLine("<systemDataLength type=\"byte\">" + SystemDataLength.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
                sb.AppendLine("<numberOfBeams type=\"byte\">" + NumberOfBeams.ToString(CultureInfo.InvariantCulture) + "</numberOfBeams>");
                sb.AppendLine("<emissionsPadding2 type=\"ushort\">" + EmissionsPadding2.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
                sb.AppendLine("<emitterSystem>");
                EmitterSystem.Reflection(sb);
                sb.AppendLine("</emitterSystem>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<beamDataLength type=\"byte\">" + BeamDataLength.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
                sb.AppendLine("<beamIdNumber type=\"byte\">" + BeamIdNumber.ToString(CultureInfo.InvariantCulture) + "</beamIdNumber>");
                sb.AppendLine("<beamParameterIndex type=\"ushort\">" + BeamParameterIndex.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
                sb.AppendLine("<fundamentalParameterData>");
                FundamentalParameterData.Reflection(sb);
                sb.AppendLine("</fundamentalParameterData>");
                sb.AppendLine("</ElectronicEmmisionsPdu>");
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
        public override bool Equals(object obj) => this == obj as ElectronicEmmisionsPdu;

        ///<inheritdoc/>
        public bool Equals(ElectronicEmmisionsPdu obj)
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

            if (StateUpdateIndicator != obj.StateUpdateIndicator)
            {
                ivarsEqual = false;
            }

            if (NumberOfSystems != obj.NumberOfSystems)
            {
                ivarsEqual = false;
            }

            if (EmissionsPadding != obj.EmissionsPadding)
            {
                ivarsEqual = false;
            }

            if (SystemDataLength != obj.SystemDataLength)
            {
                ivarsEqual = false;
            }

            if (NumberOfBeams != obj.NumberOfBeams)
            {
                ivarsEqual = false;
            }

            if (EmissionsPadding2 != obj.EmissionsPadding2)
            {
                ivarsEqual = false;
            }

            if (!EmitterSystem.Equals(obj.EmitterSystem))
            {
                ivarsEqual = false;
            }

            if (!Location.Equals(obj.Location))
            {
                ivarsEqual = false;
            }

            if (BeamDataLength != obj.BeamDataLength)
            {
                ivarsEqual = false;
            }

            if (BeamIdNumber != obj.BeamIdNumber)
            {
                ivarsEqual = false;
            }

            if (BeamParameterIndex != obj.BeamParameterIndex)
            {
                ivarsEqual = false;
            }

            if (!FundamentalParameterData.Equals(obj.FundamentalParameterData))
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

            result = GenerateHash(result) ^ EmittingEntityID.GetHashCode();
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ StateUpdateIndicator.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSystems.GetHashCode();
            result = GenerateHash(result) ^ EmissionsPadding.GetHashCode();
            result = GenerateHash(result) ^ SystemDataLength.GetHashCode();
            result = GenerateHash(result) ^ NumberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ EmissionsPadding2.GetHashCode();
            result = GenerateHash(result) ^ EmitterSystem.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();
            result = GenerateHash(result) ^ BeamDataLength.GetHashCode();
            result = GenerateHash(result) ^ BeamIdNumber.GetHashCode();
            result = GenerateHash(result) ^ BeamParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ FundamentalParameterData.GetHashCode();

            return result;
        }
    }
}
