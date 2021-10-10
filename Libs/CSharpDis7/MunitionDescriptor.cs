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
    /// Represents the firing or detonation of a munition. Section 6.2.20.2
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityType))]
    public partial class MunitionDescriptor
    {
        /// <summary>
        /// What munition was used in the burst
        /// </summary>
        private EntityType _munitionType = new EntityType();

        /// <summary>
        /// type of warhead
        /// </summary>
        private ushort _warhead;

        /// <summary>
        /// type of fuse used
        /// </summary>
        private ushort _fuse;

        /// <summary>
        /// how many of the munition were fired
        /// </summary>
        private ushort _quantity;

        /// <summary>
        /// rate at which the munition was fired
        /// </summary>
        private ushort _rate;

        /// <summary>
        /// Initializes a new instance of the <see cref="MunitionDescriptor"/> class.
        /// </summary>
        public MunitionDescriptor()
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
        public static bool operator !=(MunitionDescriptor left, MunitionDescriptor right)
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
        public static bool operator ==(MunitionDescriptor left, MunitionDescriptor right)
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

            marshalSize += this._munitionType.GetMarshalledSize();  // this._munitionType
            marshalSize += 2;  // this._warhead
            marshalSize += 2;  // this._fuse
            marshalSize += 2;  // this._quantity
            marshalSize += 2;  // this._rate
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the What munition was used in the burst
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "munitionType")]
        public EntityType MunitionType
        {
            get
            {
                return this._munitionType;
            }

            set
            {
                this._munitionType = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of warhead
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "warhead")]
        public ushort Warhead
        {
            get
            {
                return this._warhead;
            }

            set
            {
                this._warhead = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of fuse used
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "fuse")]
        public ushort Fuse
        {
            get
            {
                return this._fuse;
            }

            set
            {
                this._fuse = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many of the munition were fired
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "quantity")]
        public ushort Quantity
        {
            get
            {
                return this._quantity;
            }

            set
            {
                this._quantity = value;
            }
        }

        /// <summary>
        /// Gets or sets the rate at which the munition was fired
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "rate")]
        public ushort Rate
        {
            get
            {
                return this._rate;
            }

            set
            {
                this._rate = value;
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
                    this._munitionType.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._warhead);
                    dos.WriteUnsignedShort((ushort)this._fuse);
                    dos.WriteUnsignedShort((ushort)this._quantity);
                    dos.WriteUnsignedShort((ushort)this._rate);
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
                    this._munitionType.Unmarshal(dis);
                    this._warhead = dis.ReadUnsignedShort();
                    this._fuse = dis.ReadUnsignedShort();
                    this._quantity = dis.ReadUnsignedShort();
                    this._rate = dis.ReadUnsignedShort();
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
            sb.AppendLine("<MunitionDescriptor>");
            try
            {
                sb.AppendLine("<munitionType>");
                this._munitionType.Reflection(sb);
                sb.AppendLine("</munitionType>");
                sb.AppendLine("<warhead type=\"ushort\">" + this._warhead.ToString(CultureInfo.InvariantCulture) + "</warhead>");
                sb.AppendLine("<fuse type=\"ushort\">" + this._fuse.ToString(CultureInfo.InvariantCulture) + "</fuse>");
                sb.AppendLine("<quantity type=\"ushort\">" + this._quantity.ToString(CultureInfo.InvariantCulture) + "</quantity>");
                sb.AppendLine("<rate type=\"ushort\">" + this._rate.ToString(CultureInfo.InvariantCulture) + "</rate>");
                sb.AppendLine("</MunitionDescriptor>");
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
            return this == obj as MunitionDescriptor;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MunitionDescriptor obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!this._munitionType.Equals(obj._munitionType))
            {
                ivarsEqual = false;
            }

            if (this._warhead != obj._warhead)
            {
                ivarsEqual = false;
            }

            if (this._fuse != obj._fuse)
            {
                ivarsEqual = false;
            }

            if (this._quantity != obj._quantity)
            {
                ivarsEqual = false;
            }

            if (this._rate != obj._rate)
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

            result = GenerateHash(result) ^ this._munitionType.GetHashCode();
            result = GenerateHash(result) ^ this._warhead.GetHashCode();
            result = GenerateHash(result) ^ this._fuse.GetHashCode();
            result = GenerateHash(result) ^ this._quantity.GetHashCode();
            result = GenerateHash(result) ^ this._rate.GetHashCode();

            return result;
        }
    }
}
