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
    /// Section 5.2.38. Identifies the type of aggregate including kind of entity, domain (surface, subsurface, air, etc)
    /// country, category, etc.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AggregateType : IEquatable<AggregateType>, IReflectable
    {
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
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AggregateType left, AggregateType right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AggregateType left, AggregateType right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

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
        public byte AggregateKind { get; set; }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "domain")]
        public byte Domain { get; set; }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "country")]
        public ushort Country { get; set; }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "category")]
        public byte Category { get; set; }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "subcategory")]
        public byte Subcategory { get; set; }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "specific")]
        public byte Specific { get; set; }

        /// <summary>
        /// Gets or sets the extra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "extra")]
        public byte Extra { get; set; }

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
                    dos.WriteUnsignedByte(AggregateKind);
                    dos.WriteUnsignedByte(Domain);
                    dos.WriteUnsignedShort(Country);
                    dos.WriteUnsignedByte(Category);
                    dos.WriteUnsignedByte(Subcategory);
                    dos.WriteUnsignedByte(Specific);
                    dos.WriteUnsignedByte(Extra);
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
                    AggregateKind = dis.ReadUnsignedByte();
                    Domain = dis.ReadUnsignedByte();
                    Country = dis.ReadUnsignedShort();
                    Category = dis.ReadUnsignedByte();
                    Subcategory = dis.ReadUnsignedByte();
                    Specific = dis.ReadUnsignedByte();
                    Extra = dis.ReadUnsignedByte();
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
            sb.AppendLine("<AggregateType>");
            try
            {
                sb.AppendLine("<aggregateKind type=\"byte\">" + AggregateKind.ToString(CultureInfo.InvariantCulture) + "</aggregateKind>");
                sb.AppendLine("<domain type=\"byte\">" + Domain.ToString(CultureInfo.InvariantCulture) + "</domain>");
                sb.AppendLine("<country type=\"ushort\">" + Country.ToString(CultureInfo.InvariantCulture) + "</country>");
                sb.AppendLine("<category type=\"byte\">" + Category.ToString(CultureInfo.InvariantCulture) + "</category>");
                sb.AppendLine("<subcategory type=\"byte\">" + Subcategory.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
                sb.AppendLine("<specific type=\"byte\">" + Specific.ToString(CultureInfo.InvariantCulture) + "</specific>");
                sb.AppendLine("<extra type=\"byte\">" + Extra.ToString(CultureInfo.InvariantCulture) + "</extra>");
                sb.AppendLine("</AggregateType>");
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
        public override bool Equals(object obj) => this == obj as AggregateType;

        ///<inheritdoc/>
        public bool Equals(AggregateType obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (AggregateKind != obj.AggregateKind)
            {
                ivarsEqual = false;
            }

            if (Domain != obj.Domain)
            {
                ivarsEqual = false;
            }

            if (Country != obj.Country)
            {
                ivarsEqual = false;
            }

            if (Category != obj.Category)
            {
                ivarsEqual = false;
            }

            if (Subcategory != obj.Subcategory)
            {
                ivarsEqual = false;
            }

            if (Specific != obj.Specific)
            {
                ivarsEqual = false;
            }

            if (Extra != obj.Extra)
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

            result = GenerateHash(result) ^ AggregateKind.GetHashCode();
            result = GenerateHash(result) ^ Domain.GetHashCode();
            result = GenerateHash(result) ^ Country.GetHashCode();
            result = GenerateHash(result) ^ Category.GetHashCode();
            result = GenerateHash(result) ^ Subcategory.GetHashCode();
            result = GenerateHash(result) ^ Specific.GetHashCode();
            result = GenerateHash(result) ^ Extra.GetHashCode();

            return result;
        }
    }
}
