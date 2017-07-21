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
    /// Used in UA PDU
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(AcousticBeamFundamentalParameter))]
    public partial class AcousticBeamData
    {
        /// <summary>
        /// beam data length
        /// </summary>
        private ushort _beamDataLength;

        /// <summary>
        /// beamIDNumber
        /// </summary>
        private byte _beamIDNumber;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _pad2;

        /// <summary>
        /// fundamental data parameters
        /// </summary>
        private AcousticBeamFundamentalParameter _fundamentalDataParameters = new AcousticBeamFundamentalParameter();

        /// <summary>
        /// Initializes a new instance of the <see cref="AcousticBeamData"/> class.
        /// </summary>
        public AcousticBeamData()
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
        public static bool operator !=(AcousticBeamData left, AcousticBeamData right)
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
        public static bool operator ==(AcousticBeamData left, AcousticBeamData right)
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

            marshalSize += 2;  // this._beamDataLength
            marshalSize += 1;  // this._beamIDNumber
            marshalSize += 2;  // this._pad2
            marshalSize += this._fundamentalDataParameters.GetMarshalledSize();  // this._fundamentalDataParameters
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the beam data length
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "beamDataLength")]
        public ushort BeamDataLength
        {
            get
            {
                return this._beamDataLength;
            }

            set
            {
                this._beamDataLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the beamIDNumber
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
        public byte BeamIDNumber
        {
            get
            {
                return this._beamIDNumber;
            }

            set
            {
                this._beamIDNumber = value;
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
        /// Gets or sets the fundamental data parameters
        /// </summary>
        [XmlElement(Type = typeof(AcousticBeamFundamentalParameter), ElementName = "fundamentalDataParameters")]
        public AcousticBeamFundamentalParameter FundamentalDataParameters
        {
            get
            {
                return this._fundamentalDataParameters;
            }

            set
            {
                this._fundamentalDataParameters = value;
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
                    dos.WriteUnsignedShort((ushort)this._beamDataLength);
                    dos.WriteUnsignedByte((byte)this._beamIDNumber);
                    dos.WriteUnsignedShort((ushort)this._pad2);
                    this._fundamentalDataParameters.Marshal(dos);
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
                    this._beamDataLength = dis.ReadUnsignedShort();
                    this._beamIDNumber = dis.ReadUnsignedByte();
                    this._pad2 = dis.ReadUnsignedShort();
                    this._fundamentalDataParameters.Unmarshal(dis);
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
            sb.AppendLine("<AcousticBeamData>");
            try
            {
                sb.AppendLine("<beamDataLength type=\"ushort\">" + this._beamDataLength.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
                sb.AppendLine("<beamIDNumber type=\"byte\">" + this._beamIDNumber.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
                sb.AppendLine("<pad2 type=\"ushort\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<fundamentalDataParameters>");
                this._fundamentalDataParameters.Reflection(sb);
                sb.AppendLine("</fundamentalDataParameters>");
                sb.AppendLine("</AcousticBeamData>");
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
            return this == obj as AcousticBeamData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AcousticBeamData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._beamDataLength != obj._beamDataLength)
            {
                ivarsEqual = false;
            }

            if (this._beamIDNumber != obj._beamIDNumber)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (!this._fundamentalDataParameters.Equals(obj._fundamentalDataParameters))
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

            result = GenerateHash(result) ^ this._beamDataLength.GetHashCode();
            result = GenerateHash(result) ^ this._beamIDNumber.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._fundamentalDataParameters.GetHashCode();

            return result;
        }
    }
}
