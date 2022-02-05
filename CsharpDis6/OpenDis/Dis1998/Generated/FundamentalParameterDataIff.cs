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
    /// 5.2.45. Fundamental IFF atc data
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class FundamentalParameterDataIff : IEquatable<FundamentalParameterDataIff>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundamentalParameterDataIff"/> class.
        /// </summary>
        public FundamentalParameterDataIff()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FundamentalParameterDataIff left, FundamentalParameterDataIff right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(FundamentalParameterDataIff left, FundamentalParameterDataIff right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 4;  // this._erp
            marshalSize += 4;  // this._frequency
            marshalSize += 4;  // this._pgrf
            marshalSize += 4;  // this._pulseWidth
            marshalSize += 4;  // this._burstLength
            marshalSize += 1;  // this._applicableModes
            marshalSize += 2;  // this._pad2
            marshalSize += 1;  // this._pad3
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ERP
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "erp")]
        public float Erp { get; set; }

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "frequency")]
        public float Frequency { get; set; }

        /// <summary>
        /// Gets or sets the pgrf
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pgrf")]
        public float Pgrf { get; set; }

        /// <summary>
        /// Gets or sets the Pulse width
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
        public float PulseWidth { get; set; }

        /// <summary>
        /// Gets or sets the Burst length
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "burstLength")]
        public uint BurstLength { get; set; }

        /// <summary>
        /// Gets or sets the Applicable modes enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "applicableModes")]
        public byte ApplicableModes { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad2")]
        public ushort Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad3")]
        public byte Pad3 { get; set; }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event EventHandler<PduExceptionEventArgs> ExceptionOccured;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void RaiseExceptionOccured(Exception e)
        {
            if (PduBase.FireExceptionEvents && ExceptionOccured != null)
            {
                ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteFloat((float)Erp);
                    dos.WriteFloat((float)Frequency);
                    dos.WriteFloat((float)Pgrf);
                    dos.WriteFloat((float)PulseWidth);
                    dos.WriteUnsignedInt(BurstLength);
                    dos.WriteUnsignedByte(ApplicableModes);
                    dos.WriteUnsignedShort(Pad2);
                    dos.WriteUnsignedByte(Pad3);
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    Erp = dis.ReadFloat();
                    Frequency = dis.ReadFloat();
                    Pgrf = dis.ReadFloat();
                    PulseWidth = dis.ReadFloat();
                    BurstLength = dis.ReadUnsignedInt();
                    ApplicableModes = dis.ReadUnsignedByte();
                    Pad2 = dis.ReadUnsignedShort();
                    Pad3 = dis.ReadUnsignedByte();
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        ///<inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<FundamentalParameterDataIff>");
            try
            {
                sb.AppendLine("<erp type=\"float\">" + Erp.ToString(CultureInfo.InvariantCulture) + "</erp>");
                sb.AppendLine("<frequency type=\"float\">" + Frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<pgrf type=\"float\">" + Pgrf.ToString(CultureInfo.InvariantCulture) + "</pgrf>");
                sb.AppendLine("<pulseWidth type=\"float\">" + PulseWidth.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
                sb.AppendLine("<burstLength type=\"uint\">" + BurstLength.ToString(CultureInfo.InvariantCulture) + "</burstLength>");
                sb.AppendLine("<applicableModes type=\"byte\">" + ApplicableModes.ToString(CultureInfo.InvariantCulture) + "</applicableModes>");
                sb.AppendLine("<pad2 type=\"ushort\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<pad3 type=\"byte\">" + Pad3.ToString(CultureInfo.InvariantCulture) + "</pad3>");
                sb.AppendLine("</FundamentalParameterDataIff>");
            }
            catch (Exception e)
            {
                if (PduBase.TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (PduBase.ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as FundamentalParameterDataIff;

        ///<inheritdoc/>
        public bool Equals(FundamentalParameterDataIff obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (Erp != obj.Erp)
            {
                ivarsEqual = false;
            }

            if (Frequency != obj.Frequency)
            {
                ivarsEqual = false;
            }

            if (Pgrf != obj.Pgrf)
            {
                ivarsEqual = false;
            }

            if (PulseWidth != obj.PulseWidth)
            {
                ivarsEqual = false;
            }

            if (BurstLength != obj.BurstLength)
            {
                ivarsEqual = false;
            }

            if (ApplicableModes != obj.ApplicableModes)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (Pad3 != obj.Pad3)
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

            result = GenerateHash(result) ^ Erp.GetHashCode();
            result = GenerateHash(result) ^ Frequency.GetHashCode();
            result = GenerateHash(result) ^ Pgrf.GetHashCode();
            result = GenerateHash(result) ^ PulseWidth.GetHashCode();
            result = GenerateHash(result) ^ BurstLength.GetHashCode();
            result = GenerateHash(result) ^ ApplicableModes.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ Pad3.GetHashCode();

            return result;
        }
    }
}
