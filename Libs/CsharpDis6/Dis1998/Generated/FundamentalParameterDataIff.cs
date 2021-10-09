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
    /// 5.2.45. Fundamental IFF atc data
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class FundamentalParameterDataIff
    {
        /// <summary>
        /// ERP
        /// </summary>
        private float _erp;

        /// <summary>
        /// frequency
        /// </summary>
        private float _frequency;

        /// <summary>
        /// pgrf
        /// </summary>
        private float _pgrf;

        /// <summary>
        /// Pulse width
        /// </summary>
        private float _pulseWidth;

        /// <summary>
        /// Burst length
        /// </summary>
        private uint _burstLength;

        /// <summary>
        /// Applicable modes enumeration
        /// </summary>
        private byte _applicableModes;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _pad2;

        /// <summary>
        /// padding
        /// </summary>
        private byte _pad3;

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FundamentalParameterDataIff left, FundamentalParameterDataIff right)
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
        public static bool operator ==(FundamentalParameterDataIff left, FundamentalParameterDataIff right)
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
        public float Erp
        {
            get
            {
                return this._erp;
            }

            set
            {
                this._erp = value;
            }
        }

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "frequency")]
        public float Frequency
        {
            get
            {
                return this._frequency;
            }

            set
            {
                this._frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the pgrf
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pgrf")]
        public float Pgrf
        {
            get
            {
                return this._pgrf;
            }

            set
            {
                this._pgrf = value;
            }
        }

        /// <summary>
        /// Gets or sets the Pulse width
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
        public float PulseWidth
        {
            get
            {
                return this._pulseWidth;
            }

            set
            {
                this._pulseWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the Burst length
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "burstLength")]
        public uint BurstLength
        {
            get
            {
                return this._burstLength;
            }

            set
            {
                this._burstLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the Applicable modes enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "applicableModes")]
        public byte ApplicableModes
        {
            get
            {
                return this._applicableModes;
            }

            set
            {
                this._applicableModes = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad2")]
        public ushort Pad2
        {
            get
            {
                return this._pad2;
            }

            set
            {
                this._pad2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad3")]
        public byte Pad3
        {
            get
            {
                return this._pad3;
            }

            set
            {
                this._pad3 = value;
            }
        }

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
            if (Pdu.FireExceptionEvents && this.ExceptionOccured != null)
            {
                this.ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteFloat((float)this._erp);
                    dos.WriteFloat((float)this._frequency);
                    dos.WriteFloat((float)this._pgrf);
                    dos.WriteFloat((float)this._pulseWidth);
                    dos.WriteUnsignedInt((uint)this._burstLength);
                    dos.WriteUnsignedByte((byte)this._applicableModes);
                    dos.WriteUnsignedShort((ushort)this._pad2);
                    dos.WriteUnsignedByte((byte)this._pad3);
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
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    this._erp = dis.ReadFloat();
                    this._frequency = dis.ReadFloat();
                    this._pgrf = dis.ReadFloat();
                    this._pulseWidth = dis.ReadFloat();
                    this._burstLength = dis.ReadUnsignedInt();
                    this._applicableModes = dis.ReadUnsignedByte();
                    this._pad2 = dis.ReadUnsignedShort();
                    this._pad3 = dis.ReadUnsignedByte();
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
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<FundamentalParameterDataIff>");
            try
            {
                sb.AppendLine("<erp type=\"float\">" + this._erp.ToString(CultureInfo.InvariantCulture) + "</erp>");
                sb.AppendLine("<frequency type=\"float\">" + this._frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<pgrf type=\"float\">" + this._pgrf.ToString(CultureInfo.InvariantCulture) + "</pgrf>");
                sb.AppendLine("<pulseWidth type=\"float\">" + this._pulseWidth.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
                sb.AppendLine("<burstLength type=\"uint\">" + this._burstLength.ToString(CultureInfo.InvariantCulture) + "</burstLength>");
                sb.AppendLine("<applicableModes type=\"byte\">" + this._applicableModes.ToString(CultureInfo.InvariantCulture) + "</applicableModes>");
                sb.AppendLine("<pad2 type=\"ushort\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<pad3 type=\"byte\">" + this._pad3.ToString(CultureInfo.InvariantCulture) + "</pad3>");
                sb.AppendLine("</FundamentalParameterDataIff>");
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
            return this == obj as FundamentalParameterDataIff;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(FundamentalParameterDataIff obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._erp != obj._erp)
            {
                ivarsEqual = false;
            }

            if (this._frequency != obj._frequency)
            {
                ivarsEqual = false;
            }

            if (this._pgrf != obj._pgrf)
            {
                ivarsEqual = false;
            }

            if (this._pulseWidth != obj._pulseWidth)
            {
                ivarsEqual = false;
            }

            if (this._burstLength != obj._burstLength)
            {
                ivarsEqual = false;
            }

            if (this._applicableModes != obj._applicableModes)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (this._pad3 != obj._pad3)
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

            result = GenerateHash(result) ^ this._erp.GetHashCode();
            result = GenerateHash(result) ^ this._frequency.GetHashCode();
            result = GenerateHash(result) ^ this._pgrf.GetHashCode();
            result = GenerateHash(result) ^ this._pulseWidth.GetHashCode();
            result = GenerateHash(result) ^ this._burstLength.GetHashCode();
            result = GenerateHash(result) ^ this._applicableModes.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._pad3.GetHashCode();

            return result;
        }
    }
}
