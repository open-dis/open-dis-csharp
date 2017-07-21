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

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Section 5.3.6.5. Acknowledge the receiptof a start/resume, stop/freeze, or RemoveEntityPDU
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AcknowledgePdu : SimulationManagementPdu, IEquatable<AcknowledgePdu>
    {
        /// <summary>
        /// type of message being acknowledged
        /// </summary>
        private ushort _acknowledgeFlag;

        /// <summary>
        /// Whether or not the receiving entity was able to comply with the request
        /// </summary>
        private ushort _responseFlag;

        /// <summary>
        /// Request ID that is unique
        /// </summary>
        private uint _requestID;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcknowledgePdu"/> class.
        /// </summary>
        public AcknowledgePdu()
        {
            PduType = (byte)15;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AcknowledgePdu left, AcknowledgePdu right)
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
        public static bool operator ==(AcknowledgePdu left, AcknowledgePdu right)
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
            marshalSize += 2;  // this._acknowledgeFlag
            marshalSize += 2;  // this._responseFlag
            marshalSize += 4;  // this._requestID
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the type of message being acknowledged
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "acknowledgeFlag")]
        public ushort AcknowledgeFlag
        {
            get
            {
                return this._acknowledgeFlag;
            }

            set
            {
                this._acknowledgeFlag = value;
            }
        }

        /// <summary>
        /// Gets or sets the Whether or not the receiving entity was able to comply with the request
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "responseFlag")]
        public ushort ResponseFlag
        {
            get
            {
                return this._responseFlag;
            }

            set
            {
                this._responseFlag = value;
            }
        }

        /// <summary>
        /// Gets or sets the Request ID that is unique
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID
        {
            get
            {
                return this._requestID;
            }

            set
            {
                this._requestID = value;
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
                    dos.WriteUnsignedShort((ushort)this._acknowledgeFlag);
                    dos.WriteUnsignedShort((ushort)this._responseFlag);
                    dos.WriteUnsignedInt((uint)this._requestID);
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
                    this._acknowledgeFlag = dis.ReadUnsignedShort();
                    this._responseFlag = dis.ReadUnsignedShort();
                    this._requestID = dis.ReadUnsignedInt();
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
            sb.AppendLine("<AcknowledgePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<acknowledgeFlag type=\"ushort\">" + this._acknowledgeFlag.ToString(CultureInfo.InvariantCulture) + "</acknowledgeFlag>");
                sb.AppendLine("<responseFlag type=\"ushort\">" + this._responseFlag.ToString(CultureInfo.InvariantCulture) + "</responseFlag>");
                sb.AppendLine("<requestID type=\"uint\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("</AcknowledgePdu>");
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
            return this == obj as AcknowledgePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AcknowledgePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._acknowledgeFlag != obj._acknowledgeFlag)
            {
                ivarsEqual = false;
            }

            if (this._responseFlag != obj._responseFlag)
            {
                ivarsEqual = false;
            }

            if (this._requestID != obj._requestID)
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

            result = GenerateHash(result) ^ this._acknowledgeFlag.GetHashCode();
            result = GenerateHash(result) ^ this._responseFlag.GetHashCode();
            result = GenerateHash(result) ^ this._requestID.GetHashCode();

            return result;
        }
    }
}
