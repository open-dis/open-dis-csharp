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
    /// Section 5.2.38. Identifies the type of aggregate including kind of entity, domain (surface, subsurface, air, etc) country, category, etc.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AggregateType
    {
        /// <summary>
        /// Kind of entity
        /// </summary>
        private byte _aggregateKind;

        /// <summary>
        /// Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        private byte _domain;

        /// <summary>
        /// country to which the design of the entity is attributed
        /// </summary>
        private ushort _country;

        /// <summary>
        /// category of entity
        /// </summary>
        private byte _category;

        /// <summary>
        /// subcategory of entity
        /// </summary>
        private byte _subcategory;

        /// <summary>
        /// specific info based on subcategory field
        /// </summary>
        private byte _specific;

        private byte _extra;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateType"/> class.
        /// </summary>
        public AggregateType()
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
        public static bool operator !=(AggregateType left, AggregateType right)
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
        public static bool operator ==(AggregateType left, AggregateType right)
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

            marshalSize += 1;  // this._aggregateKind
            marshalSize += 1;  // this._domain
            marshalSize += 2;  // this._country
            marshalSize += 1;  // this._category
            marshalSize += 1;  // this._subcategory
            marshalSize += 1;  // this._specific
            marshalSize += 1;  // this._extra
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Kind of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "aggregateKind")]
        public byte AggregateKind
        {
            get
            {
                return this._aggregateKind;
            }

            set
            {
                this._aggregateKind = value;
            }
        }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "domain")]
        public byte Domain
        {
            get
            {
                return this._domain;
            }

            set
            {
                this._domain = value;
            }
        }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "country")]
        public ushort Country
        {
            get
            {
                return this._country;
            }

            set
            {
                this._country = value;
            }
        }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "category")]
        public byte Category
        {
            get
            {
                return this._category;
            }

            set
            {
                this._category = value;
            }
        }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "subcategory")]
        public byte Subcategory
        {
            get
            {
                return this._subcategory;
            }

            set
            {
                this._subcategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "specific")]
        public byte Specific
        {
            get
            {
                return this._specific;
            }

            set
            {
                this._specific = value;
            }
        }

        /// <summary>
        /// Gets or sets the extra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "extra")]
        public byte Extra
        {
            get
            {
                return this._extra;
            }

            set
            {
                this._extra = value;
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
                    dos.WriteUnsignedByte((byte)this._aggregateKind);
                    dos.WriteUnsignedByte((byte)this._domain);
                    dos.WriteUnsignedShort((ushort)this._country);
                    dos.WriteUnsignedByte((byte)this._category);
                    dos.WriteUnsignedByte((byte)this._subcategory);
                    dos.WriteUnsignedByte((byte)this._specific);
                    dos.WriteUnsignedByte((byte)this._extra);
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
                    this._aggregateKind = dis.ReadUnsignedByte();
                    this._domain = dis.ReadUnsignedByte();
                    this._country = dis.ReadUnsignedShort();
                    this._category = dis.ReadUnsignedByte();
                    this._subcategory = dis.ReadUnsignedByte();
                    this._specific = dis.ReadUnsignedByte();
                    this._extra = dis.ReadUnsignedByte();
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
            sb.AppendLine("<AggregateType>");
            try
            {
                sb.AppendLine("<aggregateKind type=\"byte\">" + this._aggregateKind.ToString(CultureInfo.InvariantCulture) + "</aggregateKind>");
                sb.AppendLine("<domain type=\"byte\">" + this._domain.ToString(CultureInfo.InvariantCulture) + "</domain>");
                sb.AppendLine("<country type=\"ushort\">" + this._country.ToString(CultureInfo.InvariantCulture) + "</country>");
                sb.AppendLine("<category type=\"byte\">" + this._category.ToString(CultureInfo.InvariantCulture) + "</category>");
                sb.AppendLine("<subcategory type=\"byte\">" + this._subcategory.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
                sb.AppendLine("<specific type=\"byte\">" + this._specific.ToString(CultureInfo.InvariantCulture) + "</specific>");
                sb.AppendLine("<extra type=\"byte\">" + this._extra.ToString(CultureInfo.InvariantCulture) + "</extra>");
                sb.AppendLine("</AggregateType>");
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
            return this == obj as AggregateType;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AggregateType obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._aggregateKind != obj._aggregateKind)
            {
                ivarsEqual = false;
            }

            if (this._domain != obj._domain)
            {
                ivarsEqual = false;
            }

            if (this._country != obj._country)
            {
                ivarsEqual = false;
            }

            if (this._category != obj._category)
            {
                ivarsEqual = false;
            }

            if (this._subcategory != obj._subcategory)
            {
                ivarsEqual = false;
            }

            if (this._specific != obj._specific)
            {
                ivarsEqual = false;
            }

            if (this._extra != obj._extra)
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

            result = GenerateHash(result) ^ this._aggregateKind.GetHashCode();
            result = GenerateHash(result) ^ this._domain.GetHashCode();
            result = GenerateHash(result) ^ this._country.GetHashCode();
            result = GenerateHash(result) ^ this._category.GetHashCode();
            result = GenerateHash(result) ^ this._subcategory.GetHashCode();
            result = GenerateHash(result) ^ this._specific.GetHashCode();
            result = GenerateHash(result) ^ this._extra.GetHashCode();

            return result;
        }
    }
}
