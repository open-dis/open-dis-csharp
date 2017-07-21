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
    /// Section 5.3.8.5. Detailed inofrmation about the state of an intercom device and the actions it is requestion         of another intercom device, or the response to a requested action. Required manual intervention to fix the intercom parameters,        which can be of varialbe length. UNFINSISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(IntercomCommunicationsParameters))]
    public partial class IntercomControlPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomControlPdu>
    {
        /// <summary>
        /// control type
        /// </summary>
        private byte _controlType;

        /// <summary>
        /// control type
        /// </summary>
        private byte _communicationsChannelType;

        /// <summary>
        /// Source entity ID
        /// </summary>
        private EntityID _sourceEntityID = new EntityID();

        /// <summary>
        /// The specific intercom device being simulated within an entity.
        /// </summary>
        private byte _sourceCommunicationsDeviceID;

        /// <summary>
        /// Line number to which the intercom control refers
        /// </summary>
        private byte _sourceLineID;

        /// <summary>
        /// priority of this message relative to transmissons from other intercom devices
        /// </summary>
        private byte _transmitPriority;

        /// <summary>
        /// current transmit state of the line
        /// </summary>
        private byte _transmitLineState;

        /// <summary>
        /// detailed type requested.
        /// </summary>
        private byte _command;

        /// <summary>
        /// eid of the entity that has created this intercom channel.
        /// </summary>
        private EntityID _masterEntityID = new EntityID();

        /// <summary>
        /// specific intercom device that has created this intercom channel
        /// </summary>
        private ushort _masterCommunicationsDeviceID;

        /// <summary>
        /// number of intercom parameters
        /// </summary>
        private uint _intercomParametersLength;

        /// <summary>
        /// ^^^This is wrong--the length of the data field is variable. Using a long for now.
        /// </summary>
        private List<IntercomCommunicationsParameters> _intercomParameters = new List<IntercomCommunicationsParameters>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IntercomControlPdu"/> class.
        /// </summary>
        public IntercomControlPdu()
        {
            PduType = (byte)32;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IntercomControlPdu left, IntercomControlPdu right)
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
        public static bool operator ==(IntercomControlPdu left, IntercomControlPdu right)
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
            marshalSize += 1;  // this._controlType
            marshalSize += 1;  // this._communicationsChannelType
            marshalSize += this._sourceEntityID.GetMarshalledSize();  // this._sourceEntityID
            marshalSize += 1;  // this._sourceCommunicationsDeviceID
            marshalSize += 1;  // this._sourceLineID
            marshalSize += 1;  // this._transmitPriority
            marshalSize += 1;  // this._transmitLineState
            marshalSize += 1;  // this._command
            marshalSize += this._masterEntityID.GetMarshalledSize();  // this._masterEntityID
            marshalSize += 2;  // this._masterCommunicationsDeviceID
            marshalSize += 4;  // this._intercomParametersLength
            for (int idx = 0; idx < this._intercomParameters.Count; idx++)
            {
                IntercomCommunicationsParameters listElement = (IntercomCommunicationsParameters)this._intercomParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "controlType")]
        public byte ControlType
        {
            get
            {
                return this._controlType;
            }

            set
            {
                this._controlType = value;
            }
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "communicationsChannelType")]
        public byte CommunicationsChannelType
        {
            get
            {
                return this._communicationsChannelType;
            }

            set
            {
                this._communicationsChannelType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Source entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "sourceEntityID")]
        public EntityID SourceEntityID
        {
            get
            {
                return this._sourceEntityID;
            }

            set
            {
                this._sourceEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the The specific intercom device being simulated within an entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sourceCommunicationsDeviceID")]
        public byte SourceCommunicationsDeviceID
        {
            get
            {
                return this._sourceCommunicationsDeviceID;
            }

            set
            {
                this._sourceCommunicationsDeviceID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Line number to which the intercom control refers
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sourceLineID")]
        public byte SourceLineID
        {
            get
            {
                return this._sourceLineID;
            }

            set
            {
                this._sourceLineID = value;
            }
        }

        /// <summary>
        /// Gets or sets the priority of this message relative to transmissons from other intercom devices
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitPriority")]
        public byte TransmitPriority
        {
            get
            {
                return this._transmitPriority;
            }

            set
            {
                this._transmitPriority = value;
            }
        }

        /// <summary>
        /// Gets or sets the current transmit state of the line
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitLineState")]
        public byte TransmitLineState
        {
            get
            {
                return this._transmitLineState;
            }

            set
            {
                this._transmitLineState = value;
            }
        }

        /// <summary>
        /// Gets or sets the detailed type requested.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "command")]
        public byte Command
        {
            get
            {
                return this._command;
            }

            set
            {
                this._command = value;
            }
        }

        /// <summary>
        /// Gets or sets the eid of the entity that has created this intercom channel.
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "masterEntityID")]
        public EntityID MasterEntityID
        {
            get
            {
                return this._masterEntityID;
            }

            set
            {
                this._masterEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the specific intercom device that has created this intercom channel
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "masterCommunicationsDeviceID")]
        public ushort MasterCommunicationsDeviceID
        {
            get
            {
                return this._masterCommunicationsDeviceID;
            }

            set
            {
                this._masterCommunicationsDeviceID = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of intercom parameters
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getintercomParametersLength method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "intercomParametersLength")]
        public uint IntercomParametersLength
        {
            get
            {
                return this._intercomParametersLength;
            }

            set
            {
                this._intercomParametersLength = value;
            }
        }

        /// <summary>
        /// Gets the ^^^This is wrong--the length of the data field is variable. Using a long for now.
        /// </summary>
        [XmlElement(ElementName = "intercomParametersList", Type = typeof(List<IntercomCommunicationsParameters>))]
        public List<IntercomCommunicationsParameters> IntercomParameters
        {
            get
            {
                return this._intercomParameters;
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
                    dos.WriteUnsignedByte((byte)this._controlType);
                    dos.WriteUnsignedByte((byte)this._communicationsChannelType);
                    this._sourceEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._sourceCommunicationsDeviceID);
                    dos.WriteUnsignedByte((byte)this._sourceLineID);
                    dos.WriteUnsignedByte((byte)this._transmitPriority);
                    dos.WriteUnsignedByte((byte)this._transmitLineState);
                    dos.WriteUnsignedByte((byte)this._command);
                    this._masterEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._masterCommunicationsDeviceID);
                    dos.WriteUnsignedInt((uint)this._intercomParameters.Count);

                    for (int idx = 0; idx < this._intercomParameters.Count; idx++)
                    {
                        IntercomCommunicationsParameters aIntercomCommunicationsParameters = (IntercomCommunicationsParameters)this._intercomParameters[idx];
                        aIntercomCommunicationsParameters.Marshal(dos);
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
                    this._controlType = dis.ReadUnsignedByte();
                    this._communicationsChannelType = dis.ReadUnsignedByte();
                    this._sourceEntityID.Unmarshal(dis);
                    this._sourceCommunicationsDeviceID = dis.ReadUnsignedByte();
                    this._sourceLineID = dis.ReadUnsignedByte();
                    this._transmitPriority = dis.ReadUnsignedByte();
                    this._transmitLineState = dis.ReadUnsignedByte();
                    this._command = dis.ReadUnsignedByte();
                    this._masterEntityID.Unmarshal(dis);
                    this._masterCommunicationsDeviceID = dis.ReadUnsignedShort();
                    this._intercomParametersLength = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < this.IntercomParametersLength; idx++)
                    {
                        IntercomCommunicationsParameters anX = new IntercomCommunicationsParameters();
                        anX.Unmarshal(dis);
                        this._intercomParameters.Add(anX);
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
            sb.AppendLine("<IntercomControlPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<controlType type=\"byte\">" + this._controlType.ToString(CultureInfo.InvariantCulture) + "</controlType>");
                sb.AppendLine("<communicationsChannelType type=\"byte\">" + this._communicationsChannelType.ToString(CultureInfo.InvariantCulture) + "</communicationsChannelType>");
                sb.AppendLine("<sourceEntityID>");
                this._sourceEntityID.Reflection(sb);
                sb.AppendLine("</sourceEntityID>");
                sb.AppendLine("<sourceCommunicationsDeviceID type=\"byte\">" + this._sourceCommunicationsDeviceID.ToString(CultureInfo.InvariantCulture) + "</sourceCommunicationsDeviceID>");
                sb.AppendLine("<sourceLineID type=\"byte\">" + this._sourceLineID.ToString(CultureInfo.InvariantCulture) + "</sourceLineID>");
                sb.AppendLine("<transmitPriority type=\"byte\">" + this._transmitPriority.ToString(CultureInfo.InvariantCulture) + "</transmitPriority>");
                sb.AppendLine("<transmitLineState type=\"byte\">" + this._transmitLineState.ToString(CultureInfo.InvariantCulture) + "</transmitLineState>");
                sb.AppendLine("<command type=\"byte\">" + this._command.ToString(CultureInfo.InvariantCulture) + "</command>");
                sb.AppendLine("<masterEntityID>");
                this._masterEntityID.Reflection(sb);
                sb.AppendLine("</masterEntityID>");
                sb.AppendLine("<masterCommunicationsDeviceID type=\"ushort\">" + this._masterCommunicationsDeviceID.ToString(CultureInfo.InvariantCulture) + "</masterCommunicationsDeviceID>");
                sb.AppendLine("<intercomParameters type=\"uint\">" + this._intercomParameters.Count.ToString(CultureInfo.InvariantCulture) + "</intercomParameters>");
                for (int idx = 0; idx < this._intercomParameters.Count; idx++)
                {
                    sb.AppendLine("<intercomParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"IntercomCommunicationsParameters\">");
                    IntercomCommunicationsParameters aIntercomCommunicationsParameters = (IntercomCommunicationsParameters)this._intercomParameters[idx];
                    aIntercomCommunicationsParameters.Reflection(sb);
                    sb.AppendLine("</intercomParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IntercomControlPdu>");
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
            return this == obj as IntercomControlPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IntercomControlPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._controlType != obj._controlType)
            {
                ivarsEqual = false;
            }

            if (this._communicationsChannelType != obj._communicationsChannelType)
            {
                ivarsEqual = false;
            }

            if (!this._sourceEntityID.Equals(obj._sourceEntityID))
            {
                ivarsEqual = false;
            }

            if (this._sourceCommunicationsDeviceID != obj._sourceCommunicationsDeviceID)
            {
                ivarsEqual = false;
            }

            if (this._sourceLineID != obj._sourceLineID)
            {
                ivarsEqual = false;
            }

            if (this._transmitPriority != obj._transmitPriority)
            {
                ivarsEqual = false;
            }

            if (this._transmitLineState != obj._transmitLineState)
            {
                ivarsEqual = false;
            }

            if (this._command != obj._command)
            {
                ivarsEqual = false;
            }

            if (!this._masterEntityID.Equals(obj._masterEntityID))
            {
                ivarsEqual = false;
            }

            if (this._masterCommunicationsDeviceID != obj._masterCommunicationsDeviceID)
            {
                ivarsEqual = false;
            }

            if (this._intercomParametersLength != obj._intercomParametersLength)
            {
                ivarsEqual = false;
            }

            if (this._intercomParameters.Count != obj._intercomParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._intercomParameters.Count; idx++)
                {
                    if (!this._intercomParameters[idx].Equals(obj._intercomParameters[idx]))
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

            result = GenerateHash(result) ^ this._controlType.GetHashCode();
            result = GenerateHash(result) ^ this._communicationsChannelType.GetHashCode();
            result = GenerateHash(result) ^ this._sourceEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._sourceCommunicationsDeviceID.GetHashCode();
            result = GenerateHash(result) ^ this._sourceLineID.GetHashCode();
            result = GenerateHash(result) ^ this._transmitPriority.GetHashCode();
            result = GenerateHash(result) ^ this._transmitLineState.GetHashCode();
            result = GenerateHash(result) ^ this._command.GetHashCode();
            result = GenerateHash(result) ^ this._masterEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._masterCommunicationsDeviceID.GetHashCode();
            result = GenerateHash(result) ^ this._intercomParametersLength.GetHashCode();

            if (this._intercomParameters.Count > 0)
            {
                for (int idx = 0; idx < this._intercomParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._intercomParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
