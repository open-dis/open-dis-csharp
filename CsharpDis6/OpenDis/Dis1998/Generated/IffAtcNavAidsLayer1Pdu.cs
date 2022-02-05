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
    /// 5.3.7.4.1: Navigational and IFF PDU. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(SystemID))]
    [XmlInclude(typeof(IffFundamentalData))]
    public partial class IffAtcNavAidsLayer1Pdu : DistributedEmissionsFamilyPdu, IEquatable<IffAtcNavAidsLayer1Pdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IffAtcNavAidsLayer1Pdu"/> class.
        /// </summary>
        public IffAtcNavAidsLayer1Pdu()
        {
            PduType = 28;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IffAtcNavAidsLayer1Pdu left, IffAtcNavAidsLayer1Pdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IffAtcNavAidsLayer1Pdu left, IffAtcNavAidsLayer1Pdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EmittingEntityId.GetMarshalledSize();  // this._emittingEntityId
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += Location.GetMarshalledSize();  // this._location
            marshalSize += SystemID.GetMarshalledSize();  // this._systemID
            marshalSize += 2;  // this._pad2
            marshalSize += FundamentalParameters.GetMarshalledSize();  // this._fundamentalParameters
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity that is the source of the emissions
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityId")]
        public EntityID EmittingEntityId { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Number generated by the issuing simulation to associate realted events.
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the Location wrt entity. There is some ambugiuity in the standard here, but this is the order it is
        /// listed in the table.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the System ID information
        /// </summary>
        [XmlElement(Type = typeof(SystemID), ElementName = "systemID")]
        public SystemID SystemID { get; set; } = new SystemID();

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad2")]
        public ushort Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the fundamental parameters
        /// </summary>
        [XmlElement(Type = typeof(IffFundamentalData), ElementName = "fundamentalParameters")]
        public IffFundamentalData FundamentalParameters { get; set; } = new IffFundamentalData();

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
                    EmittingEntityId.Marshal(dos);
                    EventID.Marshal(dos);
                    Location.Marshal(dos);
                    SystemID.Marshal(dos);
                    dos.WriteUnsignedShort(Pad2);
                    FundamentalParameters.Marshal(dos);
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
                    EmittingEntityId.Unmarshal(dis);
                    EventID.Unmarshal(dis);
                    Location.Unmarshal(dis);
                    SystemID.Unmarshal(dis);
                    Pad2 = dis.ReadUnsignedShort();
                    FundamentalParameters.Unmarshal(dis);
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
            sb.AppendLine("<IffAtcNavAidsLayer1Pdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<emittingEntityId>");
                EmittingEntityId.Reflection(sb);
                sb.AppendLine("</emittingEntityId>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<systemID>");
                SystemID.Reflection(sb);
                sb.AppendLine("</systemID>");
                sb.AppendLine("<pad2 type=\"ushort\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<fundamentalParameters>");
                FundamentalParameters.Reflection(sb);
                sb.AppendLine("</fundamentalParameters>");
                sb.AppendLine("</IffAtcNavAidsLayer1Pdu>");
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
        public override bool Equals(object obj) => this == obj as IffAtcNavAidsLayer1Pdu;

        ///<inheritdoc/>
        public bool Equals(IffAtcNavAidsLayer1Pdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!EmittingEntityId.Equals(obj.EmittingEntityId))
            {
                ivarsEqual = false;
            }

            if (!EventID.Equals(obj.EventID))
            {
                ivarsEqual = false;
            }

            if (!Location.Equals(obj.Location))
            {
                ivarsEqual = false;
            }

            if (!SystemID.Equals(obj.SystemID))
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (!FundamentalParameters.Equals(obj.FundamentalParameters))
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

            result = GenerateHash(result) ^ EmittingEntityId.GetHashCode();
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();
            result = GenerateHash(result) ^ SystemID.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ FundamentalParameters.GetHashCode();

            return result;
        }
    }
}
