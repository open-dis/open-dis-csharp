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
    /// Section 5.3.8.2. Detailed information about a radio transmitter. This PDU requires        manually written code to complete. The encodingScheme field can be used in multiple        ways, which requires hand-written code to finish. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(OneByteChunk))]
    public partial class SignalPdu : RadioCommunicationsFamilyPdu, IEquatable<SignalPdu>
    {
        /// <summary>
        /// encoding scheme used, and enumeration
        /// </summary>
        private ushort _encodingScheme;

        /// <summary>
        /// tdl type
        /// </summary>
        private ushort _tdlType;

        /// <summary>
        /// sample rate
        /// </summary>
        private uint _sampleRate;

        /// <summary>
        /// length od data
        /// </summary>
        private short _dataLength;

        /// <summary>
        /// number of samples
        /// </summary>
        private short _samples;

        /// <summary>
        /// list of eight bit values
        /// </summary>
        private byte[] _data; 

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalPdu"/> class.
        /// </summary>
        public SignalPdu()
        {
            PduType = (byte)26;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SignalPdu left, SignalPdu right)
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
        public static bool operator ==(SignalPdu left, SignalPdu right)
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
            marshalSize += 2;  // this._encodingScheme
            marshalSize += 2;  // this._tdlType
            marshalSize += 4;  // this._sampleRate
            marshalSize += 2;  // this._dataLength
            marshalSize += 2;  // this._samples
            marshalSize += this._data.Length;
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the encoding scheme used, and enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
        public ushort EncodingScheme
        {
            get
            {
                return this._encodingScheme;
            }

            set
            {
                this._encodingScheme = value;
            }
        }

        /// <summary>
        /// Gets or sets the tdl type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
        public ushort TdlType
        {
            get
            {
                return this._tdlType;
            }

            set
            {
                this._tdlType = value;
            }
        }

        /// <summary>
        /// Gets or sets the sample rate
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
        public uint SampleRate
        {
            get
            {
                return this._sampleRate;
            }

            set
            {
                this._sampleRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the length od data
        /// </summary>
        /// <remarks>
        /// This value must be set to the number of bits that will be used from the Data field.  Normally this value would be in increments of 8.  If this is the case then multiply the number of bytes used in the Data field by 8 and store that number here.ny computations.
        /// </remarks>
        [XmlElement(Type = typeof(short), ElementName = "dataLength")]
        public short DataLength
        {
            get
            {
                return this._dataLength;
            }

            set
            {
                this._dataLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of samples
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "samples")]
        public short Samples
        {
            get
            {
                return this._samples;
            }

            set
            {
                this._samples = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of eight bit values
        /// </summary>
        [XmlElement(ElementName = "dataList", DataType = "hexBinary")]
        public byte[] Data
        {
            get
            {
                return this._data;
            }

            set
            {
                this._data = value;
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
                    dos.WriteUnsignedShort((ushort)this._encodingScheme);
                    dos.WriteUnsignedShort((ushort)this._tdlType);
                    dos.WriteUnsignedInt((uint)this._sampleRate);
                    dos.WriteShort((short)((this._dataLength == 0 && this._data.Length > 0) ? this._data.Length * 8 : this._dataLength)); //09062009 Post processed.  If value is zero then default to every byte will use all 8 bits
                    dos.WriteShort((short)this._samples);

                    dos.WriteByte(this._data);
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
                    this._encodingScheme = dis.ReadUnsignedShort();
                    this._tdlType = dis.ReadUnsignedShort();
                    this._sampleRate = dis.ReadUnsignedInt();
                    this._dataLength = dis.ReadShort();
                    this._samples = dis.ReadShort();

                    this._data = dis.ReadByteArray((this._dataLength / 8) + (this._dataLength % 8 > 0 ? 1 : 0));  //09062009 Post processed. Needed to convert from bits to bytes
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
            sb.AppendLine("<SignalPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<encodingScheme type=\"ushort\">" + this._encodingScheme.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
                sb.AppendLine("<tdlType type=\"ushort\">" + this._tdlType.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
                sb.AppendLine("<sampleRate type=\"uint\">" + this._sampleRate.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
                sb.AppendLine("<data type=\"short\">" + this._data.Length.ToString(CultureInfo.InvariantCulture) + "</data>");
                sb.AppendLine("<samples type=\"short\">" + this._samples.ToString(CultureInfo.InvariantCulture) + "</samples>");
                sb.AppendLine("<data type=\"byte[]\">");
                foreach (byte b in this._data)
                {
                    sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
                }

                sb.AppendLine("</data>");

                sb.AppendLine("</SignalPdu>");
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
            return this == obj as SignalPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SignalPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._encodingScheme != obj._encodingScheme)
            {
                ivarsEqual = false;
            }

            if (this._tdlType != obj._tdlType)
            {
                ivarsEqual = false;
            }

            if (this._sampleRate != obj._sampleRate)
            {
                ivarsEqual = false;
            }

            if (this._dataLength != obj._dataLength)
            {
                ivarsEqual = false;
            }

            if (this._samples != obj._samples)
            {
                ivarsEqual = false;
            }

            if (!this._data.Equals(obj._data))
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

            result = GenerateHash(result) ^ this._encodingScheme.GetHashCode();
            result = GenerateHash(result) ^ this._tdlType.GetHashCode();
            result = GenerateHash(result) ^ this._sampleRate.GetHashCode();
            result = GenerateHash(result) ^ this._dataLength.GetHashCode();
            result = GenerateHash(result) ^ this._samples.GetHashCode();

            if (this._data.Length > 0)
            {
                for (int idx = 0; idx < this._data.Length; idx++)
                {
                    result = GenerateHash(result) ^ this._data[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
