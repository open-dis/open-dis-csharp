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
    /// Section 5.3.7.2. Handles designating operations
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class DesignatorPdu : DistributedEmissionsPdu, IEquatable<DesignatorPdu>
    {
        /// <summary>
        /// ID of the entity designating
        /// </summary>
        private EntityID _designatingEntityID = new EntityID();

        /// <summary>
        /// This field shall specify a unique emitter database number assigned to  differentiate between otherwise similar or identical emitter beams within an emitter  system.
        /// </summary>
        private ushort _codeName;

        /// <summary>
        /// ID of the entity being designated
        /// </summary>
        private EntityID _designatedEntityID = new EntityID();

        /// <summary>
        /// This field shall identify the designator code being used by the designating entity 
        /// </summary>
        private ushort _designatorCode;

        /// <summary>
        /// This field shall identify the designator output power in watts
        /// </summary>
        private float _designatorPower;

        /// <summary>
        /// This field shall identify the designator wavelength in units of microns
        /// </summary>
        private float _designatorWavelength;

        /// <summary>
        /// designtor spot wrt the designated entity
        /// </summary>
        private Vector3Float _designatorSpotWrtDesignated = new Vector3Float();

        /// <summary>
        /// designtor spot wrt the designated entity
        /// </summary>
        private Vector3Double _designatorSpotLocation = new Vector3Double();

        /// <summary>
        /// Dead reckoning algorithm
        /// </summary>
        private byte _deadReckoningAlgorithm;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding1;

        /// <summary>
        /// padding
        /// </summary>
        private byte _padding2;

        /// <summary>
        /// linear accelleration of entity
        /// </summary>
        private Vector3Float _entityLinearAcceleration = new Vector3Float();

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignatorPdu"/> class.
        /// </summary>
        public DesignatorPdu()
        {
            PduType = (byte)24;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DesignatorPdu left, DesignatorPdu right)
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
        public static bool operator ==(DesignatorPdu left, DesignatorPdu right)
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
            marshalSize += this._designatingEntityID.GetMarshalledSize();  // this._designatingEntityID
            marshalSize += 2;  // this._codeName
            marshalSize += this._designatedEntityID.GetMarshalledSize();  // this._designatedEntityID
            marshalSize += 2;  // this._designatorCode
            marshalSize += 4;  // this._designatorPower
            marshalSize += 4;  // this._designatorWavelength
            marshalSize += this._designatorSpotWrtDesignated.GetMarshalledSize();  // this._designatorSpotWrtDesignated
            marshalSize += this._designatorSpotLocation.GetMarshalledSize();  // this._designatorSpotLocation
            marshalSize += 1;  // this._deadReckoningAlgorithm
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            marshalSize += this._entityLinearAcceleration.GetMarshalledSize();  // this._entityLinearAcceleration
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity designating
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "designatingEntityID")]
        public EntityID DesignatingEntityID
        {
            get
            {
                return this._designatingEntityID;
            }

            set
            {
                this._designatingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify a unique emitter database number assigned to  differentiate between otherwise similar or identical emitter beams within an emitter  system.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "codeName")]
        public ushort CodeName
        {
            get
            {
                return this._codeName;
            }

            set
            {
                this._codeName = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the entity being designated
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "designatedEntityID")]
        public EntityID DesignatedEntityID
        {
            get
            {
                return this._designatedEntityID;
            }

            set
            {
                this._designatedEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall identify the designator code being used by the designating entity 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "designatorCode")]
        public ushort DesignatorCode
        {
            get
            {
                return this._designatorCode;
            }

            set
            {
                this._designatorCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall identify the designator output power in watts
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "designatorPower")]
        public float DesignatorPower
        {
            get
            {
                return this._designatorPower;
            }

            set
            {
                this._designatorPower = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall identify the designator wavelength in units of microns
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "designatorWavelength")]
        public float DesignatorWavelength
        {
            get
            {
                return this._designatorWavelength;
            }

            set
            {
                this._designatorWavelength = value;
            }
        }

        /// <summary>
        /// Gets or sets the designtor spot wrt the designated entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "designatorSpotWrtDesignated")]
        public Vector3Float DesignatorSpotWrtDesignated
        {
            get
            {
                return this._designatorSpotWrtDesignated;
            }

            set
            {
                this._designatorSpotWrtDesignated = value;
            }
        }

        /// <summary>
        /// Gets or sets the designtor spot wrt the designated entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "designatorSpotLocation")]
        public Vector3Double DesignatorSpotLocation
        {
            get
            {
                return this._designatorSpotLocation;
            }

            set
            {
                this._designatorSpotLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dead reckoning algorithm
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm
        {
            get
            {
                return this._deadReckoningAlgorithm;
            }

            set
            {
                this._deadReckoningAlgorithm = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1
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
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2
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
        /// Gets or sets the linear accelleration of entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
        public Vector3Float EntityLinearAcceleration
        {
            get
            {
                return this._entityLinearAcceleration;
            }

            set
            {
                this._entityLinearAcceleration = value;
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
                    this._designatingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._codeName);
                    this._designatedEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._designatorCode);
                    dos.WriteFloat((float)this._designatorPower);
                    dos.WriteFloat((float)this._designatorWavelength);
                    this._designatorSpotWrtDesignated.Marshal(dos);
                    this._designatorSpotLocation.Marshal(dos);
                    dos.WriteByte((byte)this._deadReckoningAlgorithm);
                    dos.WriteUnsignedShort((ushort)this._padding1);
                    dos.WriteByte((byte)this._padding2);
                    this._entityLinearAcceleration.Marshal(dos);
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
                    this._designatingEntityID.Unmarshal(dis);
                    this._codeName = dis.ReadUnsignedShort();
                    this._designatedEntityID.Unmarshal(dis);
                    this._designatorCode = dis.ReadUnsignedShort();
                    this._designatorPower = dis.ReadFloat();
                    this._designatorWavelength = dis.ReadFloat();
                    this._designatorSpotWrtDesignated.Unmarshal(dis);
                    this._designatorSpotLocation.Unmarshal(dis);
                    this._deadReckoningAlgorithm = dis.ReadByte();
                    this._padding1 = dis.ReadUnsignedShort();
                    this._padding2 = dis.ReadByte();
                    this._entityLinearAcceleration.Unmarshal(dis);
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
            sb.AppendLine("<DesignatorPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<designatingEntityID>");
                this._designatingEntityID.Reflection(sb);
                sb.AppendLine("</designatingEntityID>");
                sb.AppendLine("<codeName type=\"ushort\">" + this._codeName.ToString(CultureInfo.InvariantCulture) + "</codeName>");
                sb.AppendLine("<designatedEntityID>");
                this._designatedEntityID.Reflection(sb);
                sb.AppendLine("</designatedEntityID>");
                sb.AppendLine("<designatorCode type=\"ushort\">" + this._designatorCode.ToString(CultureInfo.InvariantCulture) + "</designatorCode>");
                sb.AppendLine("<designatorPower type=\"float\">" + this._designatorPower.ToString(CultureInfo.InvariantCulture) + "</designatorPower>");
                sb.AppendLine("<designatorWavelength type=\"float\">" + this._designatorWavelength.ToString(CultureInfo.InvariantCulture) + "</designatorWavelength>");
                sb.AppendLine("<designatorSpotWrtDesignated>");
                this._designatorSpotWrtDesignated.Reflection(sb);
                sb.AppendLine("</designatorSpotWrtDesignated>");
                sb.AppendLine("<designatorSpotLocation>");
                this._designatorSpotLocation.Reflection(sb);
                sb.AppendLine("</designatorSpotLocation>");
                sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + this._deadReckoningAlgorithm.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
                sb.AppendLine("<padding1 type=\"ushort\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<entityLinearAcceleration>");
                this._entityLinearAcceleration.Reflection(sb);
                sb.AppendLine("</entityLinearAcceleration>");
                sb.AppendLine("</DesignatorPdu>");
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
            return this == obj as DesignatorPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DesignatorPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._designatingEntityID.Equals(obj._designatingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._codeName != obj._codeName)
            {
                ivarsEqual = false;
            }

            if (!this._designatedEntityID.Equals(obj._designatedEntityID))
            {
                ivarsEqual = false;
            }

            if (this._designatorCode != obj._designatorCode)
            {
                ivarsEqual = false;
            }

            if (this._designatorPower != obj._designatorPower)
            {
                ivarsEqual = false;
            }

            if (this._designatorWavelength != obj._designatorWavelength)
            {
                ivarsEqual = false;
            }

            if (!this._designatorSpotWrtDesignated.Equals(obj._designatorSpotWrtDesignated))
            {
                ivarsEqual = false;
            }

            if (!this._designatorSpotLocation.Equals(obj._designatorSpotLocation))
            {
                ivarsEqual = false;
            }

            if (this._deadReckoningAlgorithm != obj._deadReckoningAlgorithm)
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

            if (!this._entityLinearAcceleration.Equals(obj._entityLinearAcceleration))
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

            result = GenerateHash(result) ^ this._designatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._codeName.GetHashCode();
            result = GenerateHash(result) ^ this._designatedEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._designatorCode.GetHashCode();
            result = GenerateHash(result) ^ this._designatorPower.GetHashCode();
            result = GenerateHash(result) ^ this._designatorWavelength.GetHashCode();
            result = GenerateHash(result) ^ this._designatorSpotWrtDesignated.GetHashCode();
            result = GenerateHash(result) ^ this._designatorSpotLocation.GetHashCode();
            result = GenerateHash(result) ^ this._deadReckoningAlgorithm.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._entityLinearAcceleration.GetHashCode();

            return result;
        }
    }
}
