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
    /// Physical separation of an entity from another entity.  Section 6.2.93.6
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class SeparationVP
    {
        /// <summary>
        /// the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        private byte _recordType = 4;

        /// <summary>
        /// Reason for separation. EBV
        /// </summary>
        private byte _reasonForSeparation;

        /// <summary>
        /// Whether the entity existed prior to separation EBV
        /// </summary>
        private byte _preEntityIndicator;

        /// <summary>
        /// padding
        /// </summary>
        private byte _padding1;

        /// <summary>
        /// ID of parent
        /// </summary>
        private EntityID _parentEntityID = new EntityID();

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding2;

        /// <summary>
        /// Station separated from
        /// </summary>
        private uint _stationLocation;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeparationVP"/> class.
        /// </summary>
        public SeparationVP()
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
        public static bool operator !=(SeparationVP left, SeparationVP right)
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
        public static bool operator ==(SeparationVP left, SeparationVP right)
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

            marshalSize += 1;  // this._recordType
            marshalSize += 1;  // this._reasonForSeparation
            marshalSize += 1;  // this._preEntityIndicator
            marshalSize += 1;  // this._padding1
            marshalSize += this._parentEntityID.GetMarshalledSize();  // this._parentEntityID
            marshalSize += 2;  // this._padding2
            marshalSize += 4;  // this._stationLocation
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "recordType")]
        public byte RecordType
        {
            get
            {
                return this._recordType;
            }

            set
            {
                this._recordType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Reason for separation. EBV
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "reasonForSeparation")]
        public byte ReasonForSeparation
        {
            get
            {
                return this._reasonForSeparation;
            }

            set
            {
                this._reasonForSeparation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Whether the entity existed prior to separation EBV
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "preEntityIndicator")]
        public byte PreEntityIndicator
        {
            get
            {
                return this._preEntityIndicator;
            }

            set
            {
                this._preEntityIndicator = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding1")]
        public byte Padding1
        {
            get
            {
                return this._padding1;
            }

            set
            {
                this._padding1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of parent
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "parentEntityID")]
        public EntityID ParentEntityID
        {
            get
            {
                return this._parentEntityID;
            }

            set
            {
                this._parentEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding2")]
        public ushort Padding2
        {
            get
            {
                return this._padding2;
            }

            set
            {
                this._padding2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Station separated from
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "stationLocation")]
        public uint StationLocation
        {
            get
            {
                return this._stationLocation;
            }

            set
            {
                this._stationLocation = value;
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
                    dos.WriteUnsignedByte((byte)this._recordType);
                    dos.WriteUnsignedByte((byte)this._reasonForSeparation);
                    dos.WriteUnsignedByte((byte)this._preEntityIndicator);
                    dos.WriteUnsignedByte((byte)this._padding1);
                    this._parentEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._padding2);
                    dos.WriteUnsignedInt((uint)this._stationLocation);
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
                    this._recordType = dis.ReadUnsignedByte();
                    this._reasonForSeparation = dis.ReadUnsignedByte();
                    this._preEntityIndicator = dis.ReadUnsignedByte();
                    this._padding1 = dis.ReadUnsignedByte();
                    this._parentEntityID.Unmarshal(dis);
                    this._padding2 = dis.ReadUnsignedShort();
                    this._stationLocation = dis.ReadUnsignedInt();
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
            sb.AppendLine("<SeparationVP>");
            try
            {
                sb.AppendLine("<recordType type=\"byte\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<reasonForSeparation type=\"byte\">" + this._reasonForSeparation.ToString(CultureInfo.InvariantCulture) + "</reasonForSeparation>");
                sb.AppendLine("<preEntityIndicator type=\"byte\">" + this._preEntityIndicator.ToString(CultureInfo.InvariantCulture) + "</preEntityIndicator>");
                sb.AppendLine("<padding1 type=\"byte\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<parentEntityID>");
                this._parentEntityID.Reflection(sb);
                sb.AppendLine("</parentEntityID>");
                sb.AppendLine("<padding2 type=\"ushort\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<stationLocation type=\"uint\">" + this._stationLocation.ToString(CultureInfo.InvariantCulture) + "</stationLocation>");
                sb.AppendLine("</SeparationVP>");
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
            return this == obj as SeparationVP;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SeparationVP obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._recordType != obj._recordType)
            {
                ivarsEqual = false;
            }

            if (this._reasonForSeparation != obj._reasonForSeparation)
            {
                ivarsEqual = false;
            }

            if (this._preEntityIndicator != obj._preEntityIndicator)
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (!this._parentEntityID.Equals(obj._parentEntityID))
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (this._stationLocation != obj._stationLocation)
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

            result = GenerateHash(result) ^ this._recordType.GetHashCode();
            result = GenerateHash(result) ^ this._reasonForSeparation.GetHashCode();
            result = GenerateHash(result) ^ this._preEntityIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._parentEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._stationLocation.GetHashCode();

            return result;
        }
    }
}
