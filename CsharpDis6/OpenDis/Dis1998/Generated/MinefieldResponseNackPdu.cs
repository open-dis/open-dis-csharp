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
    /// Section 5.3.10.4 proivde the means to request a retransmit of a minefield data pdu. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EightByteChunk))]
    public partial class MinefieldResponseNackPdu : MinefieldFamilyPdu, IEquatable<MinefieldResponseNackPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldResponseNackPdu"/> class.
        /// </summary>
        public MinefieldResponseNackPdu()
        {
            PduType = 40;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MinefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += RequestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += 1;  // this._requestID
            marshalSize += 1;  // this._numberOfMissingPdus
            for (int idx = 0; idx < MissingPduSequenceNumbers.Count; idx++)
            {
                var listElement = MissingPduSequenceNumbers[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Minefield ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
        public EntityID MinefieldID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the entity ID making the request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requestID")]
        public byte RequestID { get; set; }

        /// <summary>
        /// Gets or sets the how many pdus were missing
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfMissingPdus method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfMissingPdus")]
        public byte NumberOfMissingPdus { get; set; }

        /// <summary>
        /// Gets the PDU sequence numbers that were missing
        /// </summary>
        [XmlElement(ElementName = "missingPduSequenceNumbersList", Type = typeof(List<EightByteChunk>))]
        public List<EightByteChunk> MissingPduSequenceNumbers { get; } = new();

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
                    MinefieldID.Marshal(dos);
                    RequestingEntityID.Marshal(dos);
                    dos.WriteUnsignedByte(RequestID);
                    dos.WriteUnsignedByte((byte)MissingPduSequenceNumbers.Count);

                    for (int idx = 0; idx < MissingPduSequenceNumbers.Count; idx++)
                    {
                        var aEightByteChunk = MissingPduSequenceNumbers[idx];
                        aEightByteChunk.Marshal(dos);
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
                    MinefieldID.Unmarshal(dis);
                    RequestingEntityID.Unmarshal(dis);
                    RequestID = dis.ReadUnsignedByte();
                    NumberOfMissingPdus = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfMissingPdus; idx++)
                    {
                        var anX = new EightByteChunk();
                        anX.Unmarshal(dis);
                        MissingPduSequenceNumbers.Add(anX);
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
            sb.AppendLine("<MinefieldResponseNackPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                MinefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<requestingEntityID>");
                RequestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<requestID type=\"byte\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<missingPduSequenceNumbers type=\"byte\">" + MissingPduSequenceNumbers.Count.ToString(CultureInfo.InvariantCulture) + "</missingPduSequenceNumbers>");
                for (int idx = 0; idx < MissingPduSequenceNumbers.Count; idx++)
                {
                    sb.AppendLine("<missingPduSequenceNumbers" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
                    var aEightByteChunk = MissingPduSequenceNumbers[idx];
                    aEightByteChunk.Reflection(sb);
                    sb.AppendLine("</missingPduSequenceNumbers" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldResponseNackPdu>");
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
        public override bool Equals(object obj) => this == obj as MinefieldResponseNackPdu;

        ///<inheritdoc/>
        public bool Equals(MinefieldResponseNackPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!MinefieldID.Equals(obj.MinefieldID))
            {
                ivarsEqual = false;
            }

            if (!RequestingEntityID.Equals(obj.RequestingEntityID))
            {
                ivarsEqual = false;
            }

            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (NumberOfMissingPdus != obj.NumberOfMissingPdus)
            {
                ivarsEqual = false;
            }

            if (MissingPduSequenceNumbers.Count != obj.MissingPduSequenceNumbers.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < MissingPduSequenceNumbers.Count; idx++)
                {
                    if (!MissingPduSequenceNumbers[idx].Equals(obj.MissingPduSequenceNumbers[idx]))
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

            result = GenerateHash(result) ^ MinefieldID.GetHashCode();
            result = GenerateHash(result) ^ RequestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ NumberOfMissingPdus.GetHashCode();

            if (MissingPduSequenceNumbers.Count > 0)
            {
                for (int idx = 0; idx < MissingPduSequenceNumbers.Count; idx++)
                {
                    result = GenerateHash(result) ^ MissingPduSequenceNumbers[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
