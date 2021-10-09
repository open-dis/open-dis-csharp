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
    /// Information about individual attributes for a particular entity, other object, or event may be communicated using an Attribute PDU. The Attribute PDU shall not be used to exchange data available in any other PDU except where explicitly mentioned in the PDU issuance instructions within this standard. See 5.3.6 for the information requirements and issuance and receipt rules for this PDU. Section 7.2.6. INCOMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(SimulationAddress))]
    public partial class AttributePdu : EntityInformationFamilyPdu, IEquatable<AttributePdu>
    {
        /// <summary>
        /// This field shall identify the simulation issuing the Attribute PDU. It shall be represented by a Simulation Address record (see 6.2.79).
        /// </summary>
        private SimulationAddress _originatingSimulationAddress = new SimulationAddress();

        /// <summary>
        /// Padding
        /// </summary>
        private int _padding1;

        /// <summary>
        /// Padding
        /// </summary>
        private short _padding2;

        /// <summary>
        /// This field shall represent the type of the PDU that is being extended or updated, if applicable. It shall be represented by an 8-bit enumeration.
        /// </summary>
        private byte _attributeRecordPduType;

        /// <summary>
        /// This field shall indicate the Protocol Version associated with the Attribute Record PDU Type. It shall be represented by an 8-bit enumeration.
        /// </summary>
        private byte _attributeRecordProtocolVersion;

        /// <summary>
        /// This field shall contain the Attribute record type of the Attribute records in the PDU if they all have the same Attribute record type. It shall be represented by a 32-bit enumeration.
        /// </summary>
        private uint _masterAttributeRecordType;

        /// <summary>
        /// This field shall identify the action code applicable to this Attribute PDU. The Action Code shall apply to all Attribute records contained in the PDU. It shall be represented by an 8-bit enumeration.
        /// </summary>
        private byte _actionCode;

        /// <summary>
        /// Padding
        /// </summary>
        private byte _padding3;

        /// <summary>
        /// This field shall specify the number of Attribute Record Sets that make up the remainder of the PDU. It shall be represented by a 16-bit unsigned integer.
        /// </summary>
        private ushort _numberAttributeRecordSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributePdu"/> class.
        /// </summary>
        public AttributePdu()
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
        public static bool operator !=(AttributePdu left, AttributePdu right)
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
        public static bool operator ==(AttributePdu left, AttributePdu right)
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
            marshalSize += this._originatingSimulationAddress.GetMarshalledSize();  // this._originatingSimulationAddress
            marshalSize += 4;  // this._padding1
            marshalSize += 2;  // this._padding2
            marshalSize += 1;  // this._attributeRecordPduType
            marshalSize += 1;  // this._attributeRecordProtocolVersion
            marshalSize += 4;  // this._masterAttributeRecordType
            marshalSize += 1;  // this._actionCode
            marshalSize += 1;  // this._padding3
            marshalSize += 2;  // this._numberAttributeRecordSet
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall identify the simulation issuing the Attribute PDU. It shall be represented by a Simulation Address record (see 6.2.79).
        /// </summary>
        [XmlElement(Type = typeof(SimulationAddress), ElementName = "originatingSimulationAddress")]
        public SimulationAddress OriginatingSimulationAddress
        {
            get
            {
                return this._originatingSimulationAddress;
            }

            set
            {
                this._originatingSimulationAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "padding1")]
        public int Padding1
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
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding2")]
        public short Padding2
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
        /// Gets or sets the This field shall represent the type of the PDU that is being extended or updated, if applicable. It shall be represented by an 8-bit enumeration.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "attributeRecordPduType")]
        public byte AttributeRecordPduType
        {
            get
            {
                return this._attributeRecordPduType;
            }

            set
            {
                this._attributeRecordPduType = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall indicate the Protocol Version associated with the Attribute Record PDU Type. It shall be represented by an 8-bit enumeration.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "attributeRecordProtocolVersion")]
        public byte AttributeRecordProtocolVersion
        {
            get
            {
                return this._attributeRecordProtocolVersion;
            }

            set
            {
                this._attributeRecordProtocolVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall contain the Attribute record type of the Attribute records in the PDU if they all have the same Attribute record type. It shall be represented by a 32-bit enumeration.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "masterAttributeRecordType")]
        public uint MasterAttributeRecordType
        {
            get
            {
                return this._masterAttributeRecordType;
            }

            set
            {
                this._masterAttributeRecordType = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall identify the action code applicable to this Attribute PDU. The Action Code shall apply to all Attribute records contained in the PDU. It shall be represented by an 8-bit enumeration.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "actionCode")]
        public byte ActionCode
        {
            get
            {
                return this._actionCode;
            }

            set
            {
                this._actionCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding3")]
        public byte Padding3
        {
            get
            {
                return this._padding3;
            }

            set
            {
                this._padding3 = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the number of Attribute Record Sets that make up the remainder of the PDU. It shall be represented by a 16-bit unsigned integer.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "numberAttributeRecordSet")]
        public ushort NumberAttributeRecordSet
        {
            get
            {
                return this._numberAttributeRecordSet;
            }

            set
            {
                this._numberAttributeRecordSet = value;
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
                    this._originatingSimulationAddress.Marshal(dos);
                    dos.WriteInt((int)this._padding1);
                    dos.WriteShort((short)this._padding2);
                    dos.WriteUnsignedByte((byte)this._attributeRecordPduType);
                    dos.WriteUnsignedByte((byte)this._attributeRecordProtocolVersion);
                    dos.WriteUnsignedInt((uint)this._masterAttributeRecordType);
                    dos.WriteUnsignedByte((byte)this._actionCode);
                    dos.WriteByte((byte)this._padding3);
                    dos.WriteUnsignedShort((ushort)this._numberAttributeRecordSet);
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
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    this._originatingSimulationAddress.Unmarshal(dis);
                    this._padding1 = dis.ReadInt();
                    this._padding2 = dis.ReadShort();
                    this._attributeRecordPduType = dis.ReadUnsignedByte();
                    this._attributeRecordProtocolVersion = dis.ReadUnsignedByte();
                    this._masterAttributeRecordType = dis.ReadUnsignedInt();
                    this._actionCode = dis.ReadUnsignedByte();
                    this._padding3 = dis.ReadByte();
                    this._numberAttributeRecordSet = dis.ReadUnsignedShort();
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
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<AttributePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<originatingSimulationAddress>");
                this._originatingSimulationAddress.Reflection(sb);
                sb.AppendLine("</originatingSimulationAddress>");
                sb.AppendLine("<padding1 type=\"int\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"short\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<attributeRecordPduType type=\"byte\">" + this._attributeRecordPduType.ToString(CultureInfo.InvariantCulture) + "</attributeRecordPduType>");
                sb.AppendLine("<attributeRecordProtocolVersion type=\"byte\">" + this._attributeRecordProtocolVersion.ToString(CultureInfo.InvariantCulture) + "</attributeRecordProtocolVersion>");
                sb.AppendLine("<masterAttributeRecordType type=\"uint\">" + this._masterAttributeRecordType.ToString(CultureInfo.InvariantCulture) + "</masterAttributeRecordType>");
                sb.AppendLine("<actionCode type=\"byte\">" + this._actionCode.ToString(CultureInfo.InvariantCulture) + "</actionCode>");
                sb.AppendLine("<padding3 type=\"byte\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                sb.AppendLine("<numberAttributeRecordSet type=\"ushort\">" + this._numberAttributeRecordSet.ToString(CultureInfo.InvariantCulture) + "</numberAttributeRecordSet>");
                sb.AppendLine("</AttributePdu>");
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
            return this == obj as AttributePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AttributePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._originatingSimulationAddress.Equals(obj._originatingSimulationAddress))
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (this._attributeRecordPduType != obj._attributeRecordPduType)
            {
                ivarsEqual = false;
            }

            if (this._attributeRecordProtocolVersion != obj._attributeRecordProtocolVersion)
            {
                ivarsEqual = false;
            }

            if (this._masterAttributeRecordType != obj._masterAttributeRecordType)
            {
                ivarsEqual = false;
            }

            if (this._actionCode != obj._actionCode)
            {
                ivarsEqual = false;
            }

            if (this._padding3 != obj._padding3)
            {
                ivarsEqual = false;
            }

            if (this._numberAttributeRecordSet != obj._numberAttributeRecordSet)
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

            result = GenerateHash(result) ^ this._originatingSimulationAddress.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._attributeRecordPduType.GetHashCode();
            result = GenerateHash(result) ^ this._attributeRecordProtocolVersion.GetHashCode();
            result = GenerateHash(result) ^ this._masterAttributeRecordType.GetHashCode();
            result = GenerateHash(result) ^ this._actionCode.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();
            result = GenerateHash(result) ^ this._numberAttributeRecordSet.GetHashCode();

            return result;
        }
    }
}
