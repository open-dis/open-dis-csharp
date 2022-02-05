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
    /// Section 5.3.8.3. Communication of a receiver state.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class ReceiverPdu : RadioCommunicationsPdu, IEquatable<ReceiverPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverPdu"/> class.
        /// </summary>
        public ReceiverPdu()
        {
            PduType = 27;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ReceiverPdu left, ReceiverPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ReceiverPdu left, ReceiverPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 2;  // this._receiverState
            marshalSize += 2;  // this._padding1
            marshalSize += 4;  // this._receivedPoser
            marshalSize += TransmitterEntityId.GetMarshalledSize();  // this._transmitterEntityId
            marshalSize += 2;  // this._transmitterRadioId
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the encoding scheme used, and enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "receiverState")]
        public ushort ReceiverState { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the received power
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "receivedPoser")]
        public float ReceivedPoser { get; set; }

        /// <summary>
        /// Gets or sets the ID of transmitter
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "transmitterEntityId")]
        public EntityID TransmitterEntityId { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of transmitting radio
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "transmitterRadioId")]
        public ushort TransmitterRadioId { get; set; }

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
                    dos.WriteUnsignedShort(ReceiverState);
                    dos.WriteUnsignedShort(Padding1);
                    dos.WriteFloat((float)ReceivedPoser);
                    TransmitterEntityId.Marshal(dos);
                    dos.WriteUnsignedShort(TransmitterRadioId);
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
                    ReceiverState = dis.ReadUnsignedShort();
                    Padding1 = dis.ReadUnsignedShort();
                    ReceivedPoser = dis.ReadFloat();
                    TransmitterEntityId.Unmarshal(dis);
                    TransmitterRadioId = dis.ReadUnsignedShort();
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
            sb.AppendLine("<ReceiverPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<receiverState type=\"ushort\">" + ReceiverState.ToString(CultureInfo.InvariantCulture) + "</receiverState>");
                sb.AppendLine("<padding1 type=\"ushort\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<receivedPoser type=\"float\">" + ReceivedPoser.ToString(CultureInfo.InvariantCulture) + "</receivedPoser>");
                sb.AppendLine("<transmitterEntityId>");
                TransmitterEntityId.Reflection(sb);
                sb.AppendLine("</transmitterEntityId>");
                sb.AppendLine("<transmitterRadioId type=\"ushort\">" + TransmitterRadioId.ToString(CultureInfo.InvariantCulture) + "</transmitterRadioId>");
                sb.AppendLine("</ReceiverPdu>");
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
        public override bool Equals(object obj) => this == obj as ReceiverPdu;

        ///<inheritdoc/>
        public bool Equals(ReceiverPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (ReceiverState != obj.ReceiverState)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (ReceivedPoser != obj.ReceivedPoser)
            {
                ivarsEqual = false;
            }

            if (!TransmitterEntityId.Equals(obj.TransmitterEntityId))
            {
                ivarsEqual = false;
            }

            if (TransmitterRadioId != obj.TransmitterRadioId)
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

            result = GenerateHash(result) ^ ReceiverState.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ ReceivedPoser.GetHashCode();
            result = GenerateHash(result) ^ TransmitterEntityId.GetHashCode();
            result = GenerateHash(result) ^ TransmitterRadioId.GetHashCode();

            return result;
        }
    }
}
