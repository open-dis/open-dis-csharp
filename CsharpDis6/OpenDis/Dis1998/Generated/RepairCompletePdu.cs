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

namespace OpenDis.Dis1998
{
    /// <summary>
    /// Section 5.2.5.5. Repair is complete. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class RepairCompletePdu : LogisticsFamilyPdu, IEquatable<RepairCompletePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepairCompletePdu"/> class.
        /// </summary>
        public RepairCompletePdu()
        {
            PduType = 9;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(RepairCompletePdu left, RepairCompletePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(RepairCompletePdu left, RepairCompletePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += ReceivingEntityID.GetMarshalledSize();  // this._receivingEntityID
            marshalSize += RepairingEntityID.GetMarshalledSize();  // this._repairingEntityID
            marshalSize += 2;  // this._repair
            marshalSize += 2;  // this._padding2
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Entity that is receiving service
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
        public EntityID ReceivingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Entity that is supplying
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "repairingEntityID")]
        public EntityID RepairingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Enumeration for type of repair
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "repair")]
        public ushort Repair { get; set; }

        /// <summary>
        /// Gets or sets the padding, number prevents conflict with superclass ivar name
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding2")]
        public short Padding2 { get; set; }

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
                    ReceivingEntityID.Marshal(dos);
                    RepairingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(Repair);
                    dos.WriteShort(Padding2);
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
                    ReceivingEntityID.Unmarshal(dis);
                    RepairingEntityID.Unmarshal(dis);
                    Repair = dis.ReadUnsignedShort();
                    Padding2 = dis.ReadShort();
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
            sb.AppendLine("<RepairCompletePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<receivingEntityID>");
                ReceivingEntityID.Reflection(sb);
                sb.AppendLine("</receivingEntityID>");
                sb.AppendLine("<repairingEntityID>");
                RepairingEntityID.Reflection(sb);
                sb.AppendLine("</repairingEntityID>");
                sb.AppendLine("<repair type=\"ushort\">" + Repair.ToString(CultureInfo.InvariantCulture) + "</repair>");
                sb.AppendLine("<padding2 type=\"short\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("</RepairCompletePdu>");
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
        public override bool Equals(object obj) => this == obj as RepairCompletePdu;

        ///<inheritdoc/>
        public bool Equals(RepairCompletePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!ReceivingEntityID.Equals(obj.ReceivingEntityID))
            {
                ivarsEqual = false;
            }

            if (!RepairingEntityID.Equals(obj.RepairingEntityID))
            {
                ivarsEqual = false;
            }

            if (Repair != obj.Repair)
            {
                ivarsEqual = false;
            }

            if (Padding2 != obj.Padding2)
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

            result = GenerateHash(result) ^ ReceivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ RepairingEntityID.GetHashCode();
            result = GenerateHash(result) ^ Repair.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();

            return result;
        }
    }
}
