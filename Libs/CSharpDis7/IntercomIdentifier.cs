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
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// Unique designation of an attached or unattached intercom in an event or exercirse. Section 6.2.48
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class IntercomIdentifier
    {
        private ushort _siteNumber;

        private ushort _applicationNumber;

        private ushort _referenceNumber;

        private ushort _intercomNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntercomIdentifier"/> class.
        /// </summary>
        public IntercomIdentifier()
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
        public static bool operator !=(IntercomIdentifier left, IntercomIdentifier right)
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
        public static bool operator ==(IntercomIdentifier left, IntercomIdentifier right)
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

            marshalSize += 2;  // this._siteNumber
            marshalSize += 2;  // this._applicationNumber
            marshalSize += 2;  // this._referenceNumber
            marshalSize += 2;  // this._intercomNumber
            return marshalSize;
        }

        [XmlElement(Type = typeof(ushort), ElementName = "siteNumber")]
        public ushort SiteNumber
        {
            get
            {
                return this._siteNumber;
            }

            set
            {
                this._siteNumber = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "applicationNumber")]
        public ushort ApplicationNumber
        {
            get
            {
                return this._applicationNumber;
            }

            set
            {
                this._applicationNumber = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "referenceNumber")]
        public ushort ReferenceNumber
        {
            get
            {
                return this._referenceNumber;
            }

            set
            {
                this._referenceNumber = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "intercomNumber")]
        public ushort IntercomNumber
        {
            get
            {
                return this._intercomNumber;
            }

            set
            {
                this._intercomNumber = value;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
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
                    dos.WriteUnsignedShort((ushort)this._siteNumber);
                    dos.WriteUnsignedShort((ushort)this._applicationNumber);
                    dos.WriteUnsignedShort((ushort)this._referenceNumber);
                    dos.WriteUnsignedShort((ushort)this._intercomNumber);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                    this._siteNumber = dis.ReadUnsignedShort();
                    this._applicationNumber = dis.ReadUnsignedShort();
                    this._referenceNumber = dis.ReadUnsignedShort();
                    this._intercomNumber = dis.ReadUnsignedShort();
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
            sb.AppendLine("<IntercomIdentifier>");
            try
            {
                sb.AppendLine("<siteNumber type=\"ushort\">" + this._siteNumber.ToString(CultureInfo.InvariantCulture) + "</siteNumber>");
                sb.AppendLine("<applicationNumber type=\"ushort\">" + this._applicationNumber.ToString(CultureInfo.InvariantCulture) + "</applicationNumber>");
                sb.AppendLine("<referenceNumber type=\"ushort\">" + this._referenceNumber.ToString(CultureInfo.InvariantCulture) + "</referenceNumber>");
                sb.AppendLine("<intercomNumber type=\"ushort\">" + this._intercomNumber.ToString(CultureInfo.InvariantCulture) + "</intercomNumber>");
                sb.AppendLine("</IntercomIdentifier>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
            return this == obj as IntercomIdentifier;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IntercomIdentifier obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._siteNumber != obj._siteNumber)
            {
                ivarsEqual = false;
            }

            if (this._applicationNumber != obj._applicationNumber)
            {
                ivarsEqual = false;
            }

            if (this._referenceNumber != obj._referenceNumber)
            {
                ivarsEqual = false;
            }

            if (this._intercomNumber != obj._intercomNumber)
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

            result = GenerateHash(result) ^ this._siteNumber.GetHashCode();
            result = GenerateHash(result) ^ this._applicationNumber.GetHashCode();
            result = GenerateHash(result) ^ this._referenceNumber.GetHashCode();
            result = GenerateHash(result) ^ this._intercomNumber.GetHashCode();

            return result;
        }
    }
}
