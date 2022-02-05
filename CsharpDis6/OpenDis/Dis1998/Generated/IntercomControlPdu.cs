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
    /// Section 5.3.8.5. Detailed inofrmation about the state of an intercom device and the actions it is requestion
    ///      of another intercom device, or the response to a requested action. Required manual intervention to fix the intercom parameters,        which can be of varialbe length. UNFINSISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(IntercomCommunicationsParameters))]
    public partial class IntercomControlPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomControlPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntercomControlPdu"/> class.
        /// </summary>
        public IntercomControlPdu()
        {
            PduType = 32;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IntercomControlPdu left, IntercomControlPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IntercomControlPdu left, IntercomControlPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 1;  // this._controlType
            marshalSize += 1;  // this._communicationsChannelType
            marshalSize += SourceEntityID.GetMarshalledSize();  // this._sourceEntityID
            marshalSize += 1;  // this._sourceCommunicationsDeviceID
            marshalSize += 1;  // this._sourceLineID
            marshalSize += 1;  // this._transmitPriority
            marshalSize += 1;  // this._transmitLineState
            marshalSize += 1;  // this._command
            marshalSize += MasterEntityID.GetMarshalledSize();  // this._masterEntityID
            marshalSize += 2;  // this._masterCommunicationsDeviceID
            marshalSize += 4;  // this._intercomParametersLength
            for (int idx = 0; idx < IntercomParameters.Count; idx++)
            {
                var listElement = IntercomParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "controlType")]
        public byte ControlType { get; set; }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "communicationsChannelType")]
        public byte CommunicationsChannelType { get; set; }

        /// <summary>
        /// Gets or sets the Source entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "sourceEntityID")]
        public EntityID SourceEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the specific intercom device being simulated within an entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sourceCommunicationsDeviceID")]
        public byte SourceCommunicationsDeviceID { get; set; }

        /// <summary>
        /// Gets or sets the Line number to which the intercom control refers
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sourceLineID")]
        public byte SourceLineID { get; set; }

        /// <summary>
        /// Gets or sets the priority of this message relative to transmissons from other intercom devices
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitPriority")]
        public byte TransmitPriority { get; set; }

        /// <summary>
        /// Gets or sets the current transmit state of the line
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitLineState")]
        public byte TransmitLineState { get; set; }

        /// <summary>
        /// Gets or sets the detailed type requested.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "command")]
        public byte Command { get; set; }

        /// <summary>
        /// Gets or sets the eid of the entity that has created this intercom channel.
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "masterEntityID")]
        public EntityID MasterEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the specific intercom device that has created this intercom channel
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "masterCommunicationsDeviceID")]
        public ushort MasterCommunicationsDeviceID { get; set; }

        /// <summary>
        /// Gets or sets the number of intercom parameters
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getintercomParametersLength method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "intercomParametersLength")]
        public uint IntercomParametersLength { get; set; }

        /// <summary>
        /// Gets the ^^^This is wrong--the length of the data field is variable. Using a long for now.
        /// </summary>
        [XmlElement(ElementName = "intercomParametersList", Type = typeof(List<IntercomCommunicationsParameters>))]
        public List<IntercomCommunicationsParameters> IntercomParameters { get; } = new();

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
                    dos.WriteUnsignedByte(ControlType);
                    dos.WriteUnsignedByte(CommunicationsChannelType);
                    SourceEntityID.Marshal(dos);
                    dos.WriteUnsignedByte(SourceCommunicationsDeviceID);
                    dos.WriteUnsignedByte(SourceLineID);
                    dos.WriteUnsignedByte(TransmitPriority);
                    dos.WriteUnsignedByte(TransmitLineState);
                    dos.WriteUnsignedByte(Command);
                    MasterEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(MasterCommunicationsDeviceID);
                    dos.WriteUnsignedInt((uint)IntercomParameters.Count);

                    for (int idx = 0; idx < IntercomParameters.Count; idx++)
                    {
                        var aIntercomCommunicationsParameters = IntercomParameters[idx];
                        aIntercomCommunicationsParameters.Marshal(dos);
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
                    ControlType = dis.ReadUnsignedByte();
                    CommunicationsChannelType = dis.ReadUnsignedByte();
                    SourceEntityID.Unmarshal(dis);
                    SourceCommunicationsDeviceID = dis.ReadUnsignedByte();
                    SourceLineID = dis.ReadUnsignedByte();
                    TransmitPriority = dis.ReadUnsignedByte();
                    TransmitLineState = dis.ReadUnsignedByte();
                    Command = dis.ReadUnsignedByte();
                    MasterEntityID.Unmarshal(dis);
                    MasterCommunicationsDeviceID = dis.ReadUnsignedShort();
                    IntercomParametersLength = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < IntercomParametersLength; idx++)
                    {
                        var anX = new IntercomCommunicationsParameters();
                        anX.Unmarshal(dis);
                        IntercomParameters.Add(anX);
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
            sb.AppendLine("<IntercomControlPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<controlType type=\"byte\">" + ControlType.ToString(CultureInfo.InvariantCulture) + "</controlType>");
                sb.AppendLine("<communicationsChannelType type=\"byte\">" + CommunicationsChannelType.ToString(CultureInfo.InvariantCulture) + "</communicationsChannelType>");
                sb.AppendLine("<sourceEntityID>");
                SourceEntityID.Reflection(sb);
                sb.AppendLine("</sourceEntityID>");
                sb.AppendLine("<sourceCommunicationsDeviceID type=\"byte\">" + SourceCommunicationsDeviceID.ToString(CultureInfo.InvariantCulture) + "</sourceCommunicationsDeviceID>");
                sb.AppendLine("<sourceLineID type=\"byte\">" + SourceLineID.ToString(CultureInfo.InvariantCulture) + "</sourceLineID>");
                sb.AppendLine("<transmitPriority type=\"byte\">" + TransmitPriority.ToString(CultureInfo.InvariantCulture) + "</transmitPriority>");
                sb.AppendLine("<transmitLineState type=\"byte\">" + TransmitLineState.ToString(CultureInfo.InvariantCulture) + "</transmitLineState>");
                sb.AppendLine("<command type=\"byte\">" + Command.ToString(CultureInfo.InvariantCulture) + "</command>");
                sb.AppendLine("<masterEntityID>");
                MasterEntityID.Reflection(sb);
                sb.AppendLine("</masterEntityID>");
                sb.AppendLine("<masterCommunicationsDeviceID type=\"ushort\">" + MasterCommunicationsDeviceID.ToString(CultureInfo.InvariantCulture) + "</masterCommunicationsDeviceID>");
                sb.AppendLine("<intercomParameters type=\"uint\">" + IntercomParameters.Count.ToString(CultureInfo.InvariantCulture) + "</intercomParameters>");
                for (int idx = 0; idx < IntercomParameters.Count; idx++)
                {
                    sb.AppendLine("<intercomParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"IntercomCommunicationsParameters\">");
                    var aIntercomCommunicationsParameters = IntercomParameters[idx];
                    aIntercomCommunicationsParameters.Reflection(sb);
                    sb.AppendLine("</intercomParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IntercomControlPdu>");
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
        public override bool Equals(object obj) => this == obj as IntercomControlPdu;

        ///<inheritdoc/>
        public bool Equals(IntercomControlPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (ControlType != obj.ControlType)
            {
                ivarsEqual = false;
            }

            if (CommunicationsChannelType != obj.CommunicationsChannelType)
            {
                ivarsEqual = false;
            }

            if (!SourceEntityID.Equals(obj.SourceEntityID))
            {
                ivarsEqual = false;
            }

            if (SourceCommunicationsDeviceID != obj.SourceCommunicationsDeviceID)
            {
                ivarsEqual = false;
            }

            if (SourceLineID != obj.SourceLineID)
            {
                ivarsEqual = false;
            }

            if (TransmitPriority != obj.TransmitPriority)
            {
                ivarsEqual = false;
            }

            if (TransmitLineState != obj.TransmitLineState)
            {
                ivarsEqual = false;
            }

            if (Command != obj.Command)
            {
                ivarsEqual = false;
            }

            if (!MasterEntityID.Equals(obj.MasterEntityID))
            {
                ivarsEqual = false;
            }

            if (MasterCommunicationsDeviceID != obj.MasterCommunicationsDeviceID)
            {
                ivarsEqual = false;
            }

            if (IntercomParametersLength != obj.IntercomParametersLength)
            {
                ivarsEqual = false;
            }

            if (IntercomParameters.Count != obj.IntercomParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < IntercomParameters.Count; idx++)
                {
                    if (!IntercomParameters[idx].Equals(obj.IntercomParameters[idx]))
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

            result = GenerateHash(result) ^ ControlType.GetHashCode();
            result = GenerateHash(result) ^ CommunicationsChannelType.GetHashCode();
            result = GenerateHash(result) ^ SourceEntityID.GetHashCode();
            result = GenerateHash(result) ^ SourceCommunicationsDeviceID.GetHashCode();
            result = GenerateHash(result) ^ SourceLineID.GetHashCode();
            result = GenerateHash(result) ^ TransmitPriority.GetHashCode();
            result = GenerateHash(result) ^ TransmitLineState.GetHashCode();
            result = GenerateHash(result) ^ Command.GetHashCode();
            result = GenerateHash(result) ^ MasterEntityID.GetHashCode();
            result = GenerateHash(result) ^ MasterCommunicationsDeviceID.GetHashCode();
            result = GenerateHash(result) ^ IntercomParametersLength.GetHashCode();

            if (IntercomParameters.Count > 0)
            {
                for (int idx = 0; idx < IntercomParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ IntercomParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
