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
    /// Section 5.3.8.3. Communication of a receiver state. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class ReceiverPdu : RadioCommunicationsFamilyPdu, IEquatable<ReceiverPdu>
    {
        /// <summary>
        /// encoding scheme used, and enumeration
        /// </summary>
        private ushort _receiverState;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding1;

        /// <summary>
        /// received power
        /// </summary>
        private float _receivedPoser;

        /// <summary>
        /// ID of transmitter
        /// </summary>
        private EntityID _transmitterEntityId = new EntityID();

        /// <summary>
        /// ID of transmitting radio
        /// </summary>
        private ushort _transmitterRadioId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverPdu"/> class.
        /// </summary>
        public ReceiverPdu()
        {
            PduType = (byte)27;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ReceiverPdu left, ReceiverPdu right)
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
        public static bool operator ==(ReceiverPdu left, ReceiverPdu right)
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
            marshalSize += 2;  // this._receiverState
            marshalSize += 2;  // this._padding1
            marshalSize += 4;  // this._receivedPoser
            marshalSize += this._transmitterEntityId.GetMarshalledSize();  // this._transmitterEntityId
            marshalSize += 2;  // this._transmitterRadioId
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the encoding scheme used, and enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "receiverState")]
        public ushort ReceiverState
        {
            get
            {
                return this._receiverState;
            }

            set
            {
                this._receiverState = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1
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
        /// Gets or sets the received power
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "receivedPoser")]
        public float ReceivedPoser
        {
            get
            {
                return this._receivedPoser;
            }

            set
            {
                this._receivedPoser = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of transmitter
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "transmitterEntityId")]
        public EntityID TransmitterEntityId
        {
            get
            {
                return this._transmitterEntityId;
            }

            set
            {
                this._transmitterEntityId = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of transmitting radio
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "transmitterRadioId")]
        public ushort TransmitterRadioId
        {
            get
            {
                return this._transmitterRadioId;
            }

            set
            {
                this._transmitterRadioId = value;
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
                    dos.WriteUnsignedShort((ushort)this._receiverState);
                    dos.WriteUnsignedShort((ushort)this._padding1);
                    dos.WriteFloat((float)this._receivedPoser);
                    this._transmitterEntityId.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._transmitterRadioId);
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
                    this._receiverState = dis.ReadUnsignedShort();
                    this._padding1 = dis.ReadUnsignedShort();
                    this._receivedPoser = dis.ReadFloat();
                    this._transmitterEntityId.Unmarshal(dis);
                    this._transmitterRadioId = dis.ReadUnsignedShort();
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
            sb.AppendLine("<ReceiverPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<receiverState type=\"ushort\">" + this._receiverState.ToString(CultureInfo.InvariantCulture) + "</receiverState>");
                sb.AppendLine("<padding1 type=\"ushort\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<receivedPoser type=\"float\">" + this._receivedPoser.ToString(CultureInfo.InvariantCulture) + "</receivedPoser>");
                sb.AppendLine("<transmitterEntityId>");
                this._transmitterEntityId.Reflection(sb);
                sb.AppendLine("</transmitterEntityId>");
                sb.AppendLine("<transmitterRadioId type=\"ushort\">" + this._transmitterRadioId.ToString(CultureInfo.InvariantCulture) + "</transmitterRadioId>");
                sb.AppendLine("</ReceiverPdu>");
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
            return this == obj as ReceiverPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ReceiverPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._receiverState != obj._receiverState)
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (this._receivedPoser != obj._receivedPoser)
            {
                ivarsEqual = false;
            }

            if (!this._transmitterEntityId.Equals(obj._transmitterEntityId))
            {
                ivarsEqual = false;
            }

            if (this._transmitterRadioId != obj._transmitterRadioId)
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

            result = GenerateHash(result) ^ this._receiverState.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._receivedPoser.GetHashCode();
            result = GenerateHash(result) ^ this._transmitterEntityId.GetHashCode();
            result = GenerateHash(result) ^ this._transmitterRadioId.GetHashCode();

            return result;
        }
    }
}
