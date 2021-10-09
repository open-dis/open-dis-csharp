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
    /// Damage sustained by an entity due to directed energy. Location of the damage based on a relative x,y,z location from the center of the entity. Section 6.2.17.2
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(EventIdentifier))]
    public partial class DirectedEnergyDamage
    {
        /// <summary>
        /// DE Record Type.
        /// </summary>
        private uint _recordType = 4500;

        /// <summary>
        /// DE Record Length (bytes).
        /// </summary>
        private ushort _recordLength = 40;

        /// <summary>
        /// padding.
        /// </summary>
        private ushort _padding;

        /// <summary>
        /// location of damage, relative to center of entity
        /// </summary>
        private Vector3Float _damageLocation = new Vector3Float();

        /// <summary>
        /// Size of damaged area, in meters.
        /// </summary>
        private float _damageDiameter;

        /// <summary>
        /// average temp of the damaged area, in degrees celsius. If firing entitty does not model this, use a value of -273.15
        /// </summary>
        private float _temperature = -273.15;

        /// <summary>
        /// enumeration
        /// </summary>
        private byte _componentIdentification;

        /// <summary>
        /// enumeration
        /// </summary>
        private byte _componentDamageStatus;

        /// <summary>
        /// enumeration
        /// </summary>
        private byte _componentVisualDamageStatus;

        /// <summary>
        /// enumeration
        /// </summary>
        private byte _componentVisualSmokeColor;

        /// <summary>
        /// For any component damage resulting this field shall be set to the fire event ID from that PDU.
        /// </summary>
        private EventIdentifier _fireEventID = new EventIdentifier();

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding2;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEnergyDamage"/> class.
        /// </summary>
        public DirectedEnergyDamage()
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
        public static bool operator !=(DirectedEnergyDamage left, DirectedEnergyDamage right)
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
        public static bool operator ==(DirectedEnergyDamage left, DirectedEnergyDamage right)
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

            marshalSize += 4;  // this._recordType
            marshalSize += 2;  // this._recordLength
            marshalSize += 2;  // this._padding
            marshalSize += this._damageLocation.GetMarshalledSize();  // this._damageLocation
            marshalSize += 4;  // this._damageDiameter
            marshalSize += 4;  // this._temperature
            marshalSize += 1;  // this._componentIdentification
            marshalSize += 1;  // this._componentDamageStatus
            marshalSize += 1;  // this._componentVisualDamageStatus
            marshalSize += 1;  // this._componentVisualSmokeColor
            marshalSize += this._fireEventID.GetMarshalledSize();  // this._fireEventID
            marshalSize += 2;  // this._padding2
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the DE Record Type.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordType")]
        public uint RecordType
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
        /// Gets or sets the DE Record Length (bytes).
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
        public ushort RecordLength
        {
            get
            {
                return this._recordLength;
            }

            set
            {
                this._recordLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding")]
        public ushort Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        /// <summary>
        /// Gets or sets the location of damage, relative to center of entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "damageLocation")]
        public Vector3Float DamageLocation
        {
            get
            {
                return this._damageLocation;
            }

            set
            {
                this._damageLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Size of damaged area, in meters.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "damageDiameter")]
        public float DamageDiameter
        {
            get
            {
                return this._damageDiameter;
            }

            set
            {
                this._damageDiameter = value;
            }
        }

        /// <summary>
        /// Gets or sets the average temp of the damaged area, in degrees celsius. If firing entitty does not model this, use a value of -273.15
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "temperature")]
        public float Temperature
        {
            get
            {
                return this._temperature;
            }

            set
            {
                this._temperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "componentIdentification")]
        public byte ComponentIdentification
        {
            get
            {
                return this._componentIdentification;
            }

            set
            {
                this._componentIdentification = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "componentDamageStatus")]
        public byte ComponentDamageStatus
        {
            get
            {
                return this._componentDamageStatus;
            }

            set
            {
                this._componentDamageStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "componentVisualDamageStatus")]
        public byte ComponentVisualDamageStatus
        {
            get
            {
                return this._componentVisualDamageStatus;
            }

            set
            {
                this._componentVisualDamageStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "componentVisualSmokeColor")]
        public byte ComponentVisualSmokeColor
        {
            get
            {
                return this._componentVisualSmokeColor;
            }

            set
            {
                this._componentVisualSmokeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the For any component damage resulting this field shall be set to the fire event ID from that PDU.
        /// </summary>
        [XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
        public EventIdentifier FireEventID
        {
            get
            {
                return this._fireEventID;
            }

            set
            {
                this._fireEventID = value;
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
                    dos.WriteUnsignedInt((uint)this._recordType);
                    dos.WriteUnsignedShort((ushort)this._recordLength);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    this._damageLocation.Marshal(dos);
                    dos.WriteFloat((float)this._damageDiameter);
                    dos.WriteFloat((float)this._temperature);
                    dos.WriteUnsignedByte((byte)this._componentIdentification);
                    dos.WriteUnsignedByte((byte)this._componentDamageStatus);
                    dos.WriteUnsignedByte((byte)this._componentVisualDamageStatus);
                    dos.WriteUnsignedByte((byte)this._componentVisualSmokeColor);
                    this._fireEventID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._padding2);
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
                    this._recordType = dis.ReadUnsignedInt();
                    this._recordLength = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
                    this._damageLocation.Unmarshal(dis);
                    this._damageDiameter = dis.ReadFloat();
                    this._temperature = dis.ReadFloat();
                    this._componentIdentification = dis.ReadUnsignedByte();
                    this._componentDamageStatus = dis.ReadUnsignedByte();
                    this._componentVisualDamageStatus = dis.ReadUnsignedByte();
                    this._componentVisualSmokeColor = dis.ReadUnsignedByte();
                    this._fireEventID.Unmarshal(dis);
                    this._padding2 = dis.ReadUnsignedShort();
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
            sb.AppendLine("<DirectedEnergyDamage>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<damageLocation>");
                this._damageLocation.Reflection(sb);
                sb.AppendLine("</damageLocation>");
                sb.AppendLine("<damageDiameter type=\"float\">" + this._damageDiameter.ToString(CultureInfo.InvariantCulture) + "</damageDiameter>");
                sb.AppendLine("<temperature type=\"float\">" + this._temperature.ToString(CultureInfo.InvariantCulture) + "</temperature>");
                sb.AppendLine("<componentIdentification type=\"byte\">" + this._componentIdentification.ToString(CultureInfo.InvariantCulture) + "</componentIdentification>");
                sb.AppendLine("<componentDamageStatus type=\"byte\">" + this._componentDamageStatus.ToString(CultureInfo.InvariantCulture) + "</componentDamageStatus>");
                sb.AppendLine("<componentVisualDamageStatus type=\"byte\">" + this._componentVisualDamageStatus.ToString(CultureInfo.InvariantCulture) + "</componentVisualDamageStatus>");
                sb.AppendLine("<componentVisualSmokeColor type=\"byte\">" + this._componentVisualSmokeColor.ToString(CultureInfo.InvariantCulture) + "</componentVisualSmokeColor>");
                sb.AppendLine("<fireEventID>");
                this._fireEventID.Reflection(sb);
                sb.AppendLine("</fireEventID>");
                sb.AppendLine("<padding2 type=\"ushort\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("</DirectedEnergyDamage>");
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
            return this == obj as DirectedEnergyDamage;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DirectedEnergyDamage obj)
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

            if (this._recordLength != obj._recordLength)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (!this._damageLocation.Equals(obj._damageLocation))
            {
                ivarsEqual = false;
            }

            if (this._damageDiameter != obj._damageDiameter)
            {
                ivarsEqual = false;
            }

            if (this._temperature != obj._temperature)
            {
                ivarsEqual = false;
            }

            if (this._componentIdentification != obj._componentIdentification)
            {
                ivarsEqual = false;
            }

            if (this._componentDamageStatus != obj._componentDamageStatus)
            {
                ivarsEqual = false;
            }

            if (this._componentVisualDamageStatus != obj._componentVisualDamageStatus)
            {
                ivarsEqual = false;
            }

            if (this._componentVisualSmokeColor != obj._componentVisualSmokeColor)
            {
                ivarsEqual = false;
            }

            if (!this._fireEventID.Equals(obj._fireEventID))
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
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
            result = GenerateHash(result) ^ this._recordLength.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._damageLocation.GetHashCode();
            result = GenerateHash(result) ^ this._damageDiameter.GetHashCode();
            result = GenerateHash(result) ^ this._temperature.GetHashCode();
            result = GenerateHash(result) ^ this._componentIdentification.GetHashCode();
            result = GenerateHash(result) ^ this._componentDamageStatus.GetHashCode();
            result = GenerateHash(result) ^ this._componentVisualDamageStatus.GetHashCode();
            result = GenerateHash(result) ^ this._componentVisualSmokeColor.GetHashCode();
            result = GenerateHash(result) ^ this._fireEventID.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();

            return result;
        }
    }
}
