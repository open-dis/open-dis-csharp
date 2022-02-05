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
    /// Section 5.3.8.2. Detailed information about a radio transmitter. This PDU requires       manually written code
    /// to complete. The encodingScheme field can be used in multiple        ways, which requires hand-written code to finish. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(OneByteChunk))]
    public partial class SignalPdu : RadioCommunicationsFamilyPdu, IEquatable<SignalPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalPdu"/> class.
        /// </summary>
        public SignalPdu()
        {
            PduType = 26;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SignalPdu left, SignalPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(SignalPdu left, SignalPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 2;  // this._encodingScheme
            marshalSize += 2;  // this._tdlType
            marshalSize += 4;  // this._sampleRate
            marshalSize += 2;  // this._dataLength
            marshalSize += 2;  // this._samples
            marshalSize += Data.Length;
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the encoding scheme used, and enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
        public ushort EncodingScheme { get; set; }

        /// <summary>
        /// Gets or sets the tdl type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
        public ushort TdlType { get; set; }

        /// <summary>
        /// Gets or sets the sample rate
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
        public uint SampleRate { get; set; }

        /// <summary>
        /// Gets or sets the length od data
        /// </summary>
        /// <remarks>
        /// This value must be set to the number of bits that will be used from the Data field. Normally this value would be
        /// in increments of 8.  If this is the case then multiply the number of bytes used in the Data field by 8 and store that number here.ny computations.
        /// </remarks>
        [XmlElement(Type = typeof(short), ElementName = "dataLength")]
        public short DataLength { get; set; }

        /// <summary>
        /// Gets or sets the number of samples
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "samples")]
        public short Samples { get; set; }

        /// <summary>
        /// Gets or sets the list of eight bit values
        /// </summary>
        [XmlElement(ElementName = "dataList", DataType = "hexBinary")]
        public byte[] Data { get; set; }

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
                    dos.WriteUnsignedShort(EncodingScheme);
                    dos.WriteUnsignedShort(TdlType);
                    dos.WriteUnsignedInt(SampleRate);
                    dos.WriteShort((short)((DataLength == 0 && Data.Length > 0) ? Data.Length * 8 : DataLength)); //09062009 Post processed.  If value is zero then default to every byte will use all 8 bits
                    dos.WriteShort(Samples);

                    dos.WriteByte(Data);
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
                    EncodingScheme = dis.ReadUnsignedShort();
                    TdlType = dis.ReadUnsignedShort();
                    SampleRate = dis.ReadUnsignedInt();
                    DataLength = dis.ReadShort();
                    Samples = dis.ReadShort();

                    Data = dis.ReadByteArray((DataLength / 8) + (DataLength % 8 > 0 ? 1 : 0));  //09062009 Post processed. Needed to convert from bits to bytes
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
            sb.AppendLine("<SignalPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<encodingScheme type=\"ushort\">" + EncodingScheme.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
                sb.AppendLine("<tdlType type=\"ushort\">" + TdlType.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
                sb.AppendLine("<sampleRate type=\"uint\">" + SampleRate.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
                sb.AppendLine("<data type=\"short\">" + Data.Length.ToString(CultureInfo.InvariantCulture) + "</data>");
                sb.AppendLine("<samples type=\"short\">" + Samples.ToString(CultureInfo.InvariantCulture) + "</samples>");
                sb.AppendLine("<data type=\"byte[]\">");
                foreach (byte b in Data)
                {
                    sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
                }

                sb.AppendLine("</data>");

                sb.AppendLine("</SignalPdu>");
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
        public override bool Equals(object obj) => this == obj as SignalPdu;

        ///<inheritdoc/>
        public bool Equals(SignalPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (EncodingScheme != obj.EncodingScheme)
            {
                ivarsEqual = false;
            }

            if (TdlType != obj.TdlType)
            {
                ivarsEqual = false;
            }

            if (SampleRate != obj.SampleRate)
            {
                ivarsEqual = false;
            }

            if (DataLength != obj.DataLength)
            {
                ivarsEqual = false;
            }

            if (Samples != obj.Samples)
            {
                ivarsEqual = false;
            }

            if (!Data.Equals(obj.Data))
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

            result = GenerateHash(result) ^ EncodingScheme.GetHashCode();
            result = GenerateHash(result) ^ TdlType.GetHashCode();
            result = GenerateHash(result) ^ SampleRate.GetHashCode();
            result = GenerateHash(result) ^ DataLength.GetHashCode();
            result = GenerateHash(result) ^ Samples.GetHashCode();

            if (Data.Length > 0)
            {
                for (int idx = 0; idx < Data.Length; idx++)
                {
                    result = GenerateHash(result) ^ Data[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
