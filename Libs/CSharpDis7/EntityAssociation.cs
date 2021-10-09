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
    /// Association or disassociation of two entities.  Section 6.2.93.4
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    public partial class EntityAssociation
    {
        /// <summary>
        /// the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        private byte _recordType = 2;

        /// <summary>
        /// Indicates if this VP has changed since last issuance
        /// </summary>
        private byte _changeIndicator;

        /// <summary>
        /// Indicates association status between two entities; 8 bit enum
        /// </summary>
        private byte _associationStatus;

        /// <summary>
        /// Type of association; 8 bit enum
        /// </summary>
        private byte _associationType;

        /// <summary>
        /// Object ID of entity associated with this entity
        /// </summary>
        private EntityID _entityID = new EntityID();

        /// <summary>
        /// Station location on one's own entity. EBV doc.
        /// </summary>
        private ushort _owsSttionLocation;

        /// <summary>
        /// Type of physical connection. EBV doc
        /// </summary>
        private ushort _physicalConnectionType;

        /// <summary>
        /// Type of member the entity is within th egroup
        /// </summary>
        private byte _groupMemberType;

        /// <summary>
        /// Group if any to which the entity belongs
        /// </summary>
        private ushort _groupNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAssociation"/> class.
        /// </summary>
        public EntityAssociation()
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
        public static bool operator !=(EntityAssociation left, EntityAssociation right)
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
        public static bool operator ==(EntityAssociation left, EntityAssociation right)
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
            marshalSize += 1;  // this._changeIndicator
            marshalSize += 1;  // this._associationStatus
            marshalSize += 1;  // this._associationType
            marshalSize += this._entityID.GetMarshalledSize();  // this._entityID
            marshalSize += 2;  // this._owsSttionLocation
            marshalSize += 2;  // this._physicalConnectionType
            marshalSize += 1;  // this._groupMemberType
            marshalSize += 2;  // this._groupNumber
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
        /// Gets or sets the Indicates if this VP has changed since last issuance
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "changeIndicator")]
        public byte ChangeIndicator
        {
            get
            {
                return this._changeIndicator;
            }

            set
            {
                this._changeIndicator = value;
            }
        }

        /// <summary>
        /// Gets or sets the Indicates association status between two entities; 8 bit enum
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "associationStatus")]
        public byte AssociationStatus
        {
            get
            {
                return this._associationStatus;
            }

            set
            {
                this._associationStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the Type of association; 8 bit enum
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "associationType")]
        public byte AssociationType
        {
            get
            {
                return this._associationType;
            }

            set
            {
                this._associationType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Object ID of entity associated with this entity
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
        public EntityID EntityID
        {
            get
            {
                return this._entityID;
            }

            set
            {
                this._entityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Station location on one's own entity. EBV doc.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "owsSttionLocation")]
        public ushort OwsSttionLocation
        {
            get
            {
                return this._owsSttionLocation;
            }

            set
            {
                this._owsSttionLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Type of physical connection. EBV doc
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "physicalConnectionType")]
        public ushort PhysicalConnectionType
        {
            get
            {
                return this._physicalConnectionType;
            }

            set
            {
                this._physicalConnectionType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Type of member the entity is within th egroup
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "groupMemberType")]
        public byte GroupMemberType
        {
            get
            {
                return this._groupMemberType;
            }

            set
            {
                this._groupMemberType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Group if any to which the entity belongs
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "groupNumber")]
        public ushort GroupNumber
        {
            get
            {
                return this._groupNumber;
            }

            set
            {
                this._groupNumber = value;
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
                    dos.WriteUnsignedByte((byte)this._changeIndicator);
                    dos.WriteUnsignedByte((byte)this._associationStatus);
                    dos.WriteUnsignedByte((byte)this._associationType);
                    this._entityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._owsSttionLocation);
                    dos.WriteUnsignedShort((ushort)this._physicalConnectionType);
                    dos.WriteUnsignedByte((byte)this._groupMemberType);
                    dos.WriteUnsignedShort((ushort)this._groupNumber);
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
                    this._changeIndicator = dis.ReadUnsignedByte();
                    this._associationStatus = dis.ReadUnsignedByte();
                    this._associationType = dis.ReadUnsignedByte();
                    this._entityID.Unmarshal(dis);
                    this._owsSttionLocation = dis.ReadUnsignedShort();
                    this._physicalConnectionType = dis.ReadUnsignedShort();
                    this._groupMemberType = dis.ReadUnsignedByte();
                    this._groupNumber = dis.ReadUnsignedShort();
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
            sb.AppendLine("<EntityAssociation>");
            try
            {
                sb.AppendLine("<recordType type=\"byte\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<changeIndicator type=\"byte\">" + this._changeIndicator.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
                sb.AppendLine("<associationStatus type=\"byte\">" + this._associationStatus.ToString(CultureInfo.InvariantCulture) + "</associationStatus>");
                sb.AppendLine("<associationType type=\"byte\">" + this._associationType.ToString(CultureInfo.InvariantCulture) + "</associationType>");
                sb.AppendLine("<entityID>");
                this._entityID.Reflection(sb);
                sb.AppendLine("</entityID>");
                sb.AppendLine("<owsSttionLocation type=\"ushort\">" + this._owsSttionLocation.ToString(CultureInfo.InvariantCulture) + "</owsSttionLocation>");
                sb.AppendLine("<physicalConnectionType type=\"ushort\">" + this._physicalConnectionType.ToString(CultureInfo.InvariantCulture) + "</physicalConnectionType>");
                sb.AppendLine("<groupMemberType type=\"byte\">" + this._groupMemberType.ToString(CultureInfo.InvariantCulture) + "</groupMemberType>");
                sb.AppendLine("<groupNumber type=\"ushort\">" + this._groupNumber.ToString(CultureInfo.InvariantCulture) + "</groupNumber>");
                sb.AppendLine("</EntityAssociation>");
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
            return this == obj as EntityAssociation;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EntityAssociation obj)
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

            if (this._changeIndicator != obj._changeIndicator)
            {
                ivarsEqual = false;
            }

            if (this._associationStatus != obj._associationStatus)
            {
                ivarsEqual = false;
            }

            if (this._associationType != obj._associationType)
            {
                ivarsEqual = false;
            }

            if (!this._entityID.Equals(obj._entityID))
            {
                ivarsEqual = false;
            }

            if (this._owsSttionLocation != obj._owsSttionLocation)
            {
                ivarsEqual = false;
            }

            if (this._physicalConnectionType != obj._physicalConnectionType)
            {
                ivarsEqual = false;
            }

            if (this._groupMemberType != obj._groupMemberType)
            {
                ivarsEqual = false;
            }

            if (this._groupNumber != obj._groupNumber)
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
            result = GenerateHash(result) ^ this._changeIndicator.GetHashCode();
            result = GenerateHash(result) ^ this._associationStatus.GetHashCode();
            result = GenerateHash(result) ^ this._associationType.GetHashCode();
            result = GenerateHash(result) ^ this._entityID.GetHashCode();
            result = GenerateHash(result) ^ this._owsSttionLocation.GetHashCode();
            result = GenerateHash(result) ^ this._physicalConnectionType.GetHashCode();
            result = GenerateHash(result) ^ this._groupMemberType.GetHashCode();
            result = GenerateHash(result) ^ this._groupNumber.GetHashCode();

            return result;
        }
    }
}
