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
    /// Firing of a directed energy weapon shall be communicated by issuing a Directed Energy Fire PDU Section 7.3.4  COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(ClockTime))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(StandardVariableSpecification))]
    public partial class DirectedEnergyFirePdu : WarfareFamilyPdu, IEquatable<DirectedEnergyFirePdu>
    {
        /// <summary>
        /// Field shall identify the munition type enumeration for the DE weapon beam, Section 7.3.4 
        /// </summary>
        private EntityType _munitionType = new EntityType();

        /// <summary>
        /// Field shall indicate the simulation time at start of the shot, Section 7.3.4 
        /// </summary>
        private ClockTime _shotStartTime = new ClockTime();

        /// <summary>
        /// Field shall indicate the current cumulative duration of the shot, Section 7.3.4 
        /// </summary>
        private float _commulativeShotTime;

        /// <summary>
        /// Field shall identify the location of the DE weapon aperture/emitter, Section 7.3.4 
        /// </summary>
        private Vector3Float _ApertureEmitterLocation = new Vector3Float();

        /// <summary>
        /// Field shall identify the beam diameter at the aperture/emitter, Section 7.3.4 
        /// </summary>
        private float _apertureDiameter;

        /// <summary>
        /// Field shall identify the emissions wavelength in units of meters, Section 7.3.4 
        /// </summary>
        private float _wavelength;

        /// <summary>
        /// Field shall identify the current peak irradiance of emissions in units of Watts per square meter, Section 7.3.4 
        /// </summary>
        private float _peakIrradiance;

        /// <summary>
        /// field shall identify the current pulse repetition frequency in units of cycles per second (Hertz), Section 7.3.4 
        /// </summary>
        private float _pulseRepetitionFrequency;

        /// <summary>
        /// field shall identify the pulse width emissions in units of seconds, Section 7.3.4
        /// </summary>
        private int _pulseWidth;

        /// <summary>
        /// 16bit Boolean field shall contain various flags to indicate status information needed to process a DE, Section 7.3.4 
        /// </summary>
        private int _flags;

        /// <summary>
        /// Field shall identify the pulse shape and shall be represented as an 8-bit enumeration, Section 7.3.4 
        /// </summary>
        private byte _pulseShape;

        /// <summary>
        /// padding, Section 7.3.4 
        /// </summary>
        private byte _padding1;

        /// <summary>
        /// padding, Section 7.3.4 
        /// </summary>
        private uint _padding2;

        /// <summary>
        /// padding, Section 7.3.4 
        /// </summary>
        private ushort _padding3;

        /// <summary>
        /// Field shall specify the number of DE records, Section 7.3.4 
        /// </summary>
        private ushort _numberOfDERecords;

        /// <summary>
        /// Fields shall contain one or more DE records, records shall conform to the variable record format (Section6.2.82), Section 7.3.4
        /// </summary>
        private List<StandardVariableSpecification> _dERecords = new List<StandardVariableSpecification>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEnergyFirePdu"/> class.
        /// </summary>
        public DirectedEnergyFirePdu()
        {
            PduType = (byte)68;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DirectedEnergyFirePdu left, DirectedEnergyFirePdu right)
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
        public static bool operator ==(DirectedEnergyFirePdu left, DirectedEnergyFirePdu right)
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
            marshalSize += this._munitionType.GetMarshalledSize();  // this._munitionType
            marshalSize += this._shotStartTime.GetMarshalledSize();  // this._shotStartTime
            marshalSize += 4;  // this._commulativeShotTime
            marshalSize += this._ApertureEmitterLocation.GetMarshalledSize();  // this._ApertureEmitterLocation
            marshalSize += 4;  // this._apertureDiameter
            marshalSize += 4;  // this._wavelength
            marshalSize += 4;  // this._peakIrradiance
            marshalSize += 4;  // this._pulseRepetitionFrequency
            marshalSize += 4;  // this._pulseWidth
            marshalSize += 4;  // this._flags
            marshalSize += 1;  // this._pulseShape
            marshalSize += 1;  // this._padding1
            marshalSize += 4;  // this._padding2
            marshalSize += 2;  // this._padding3
            marshalSize += 2;  // this._numberOfDERecords
            for (int idx = 0; idx < this._dERecords.Count; idx++)
            {
                StandardVariableSpecification listElement = (StandardVariableSpecification)this._dERecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Field shall identify the munition type enumeration for the DE weapon beam, Section 7.3.4 
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
        /// Gets or sets the Field shall indicate the simulation time at start of the shot, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(ClockTime), ElementName = "shotStartTime")]
        public ClockTime ShotStartTime
        {
            get
            {
                return this._shotStartTime;
            }

            set
            {
                this._shotStartTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall indicate the current cumulative duration of the shot, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "commulativeShotTime")]
        public float CommulativeShotTime
        {
            get
            {
                return this._commulativeShotTime;
            }

            set
            {
                this._commulativeShotTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall identify the location of the DE weapon aperture/emitter, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "ApertureEmitterLocation")]
        public Vector3Float ApertureEmitterLocation
        {
            get
            {
                return this._ApertureEmitterLocation;
            }

            set
            {
                this._ApertureEmitterLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall identify the beam diameter at the aperture/emitter, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "apertureDiameter")]
        public float ApertureDiameter
        {
            get
            {
                return this._apertureDiameter;
            }

            set
            {
                this._apertureDiameter = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall identify the emissions wavelength in units of meters, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "wavelength")]
        public float Wavelength
        {
            get
            {
                return this._wavelength;
            }

            set
            {
                this._wavelength = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall identify the current peak irradiance of emissions in units of Watts per square meter, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "peakIrradiance")]
        public float PeakIrradiance
        {
            get
            {
                return this._peakIrradiance;
            }

            set
            {
                this._peakIrradiance = value;
            }
        }

        /// <summary>
        /// Gets or sets the field shall identify the current pulse repetition frequency in units of cycles per second (Hertz), Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
        public float PulseRepetitionFrequency
        {
            get
            {
                return this._pulseRepetitionFrequency;
            }

            set
            {
                this._pulseRepetitionFrequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the field shall identify the pulse width emissions in units of seconds, Section 7.3.4
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "pulseWidth")]
        public int PulseWidth
        {
            get
            {
                return this._pulseWidth;
            }

            set
            {
                this._pulseWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the 16bit Boolean field shall contain various flags to indicate status information needed to process a DE, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "flags")]
        public int Flags
        {
            get
            {
                return this._flags;
            }

            set
            {
                this._flags = value;
            }
        }

        /// <summary>
        /// Gets or sets the Field shall identify the pulse shape and shall be represented as an 8-bit enumeration, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pulseShape")]
        public byte PulseShape
        {
            get
            {
                return this._pulseShape;
            }

            set
            {
                this._pulseShape = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding, Section 7.3.4 
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
        /// Gets or sets the padding, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "padding2")]
        public uint Padding2
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
        /// Gets or sets the padding, Section 7.3.4 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding3")]
        public ushort Padding3
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
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDERecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfDERecords")]
        public ushort NumberOfDERecords
        {
            get
            {
                return this._numberOfDERecords;
            }

            set
            {
                this._numberOfDERecords = value;
            }
        }

        /// <summary>
        /// Gets or sets the Fields shall contain one or more DE records, records shall conform to the variable record format (Section6.2.82), Section 7.3.4
        /// </summary>
        [XmlElement(ElementName = "dERecordsList", Type = typeof(List<StandardVariableSpecification>))]
        public List<StandardVariableSpecification> DERecords
        {
            get
            {
                return this._dERecords;
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
                    this._munitionType.Marshal(dos);
                    this._shotStartTime.Marshal(dos);
                    dos.WriteFloat((float)this._commulativeShotTime);
                    this._ApertureEmitterLocation.Marshal(dos);
                    dos.WriteFloat((float)this._apertureDiameter);
                    dos.WriteFloat((float)this._wavelength);
                    dos.WriteFloat((float)this._peakIrradiance);
                    dos.WriteFloat((float)this._pulseRepetitionFrequency);
                    dos.WriteInt((int)this._pulseWidth);
                    dos.WriteInt((int)this._flags);
                    dos.WriteByte((byte)this._pulseShape);
                    dos.WriteUnsignedByte((byte)this._padding1);
                    dos.WriteUnsignedInt((uint)this._padding2);
                    dos.WriteUnsignedShort((ushort)this._padding3);
                    dos.WriteUnsignedShort((ushort)this._dERecords.Count);

                    for (int idx = 0; idx < this._dERecords.Count; idx++)
                    {
                        StandardVariableSpecification aStandardVariableSpecification = (StandardVariableSpecification)this._dERecords[idx];
                        aStandardVariableSpecification.Marshal(dos);
                    }
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
                    this._munitionType.Unmarshal(dis);
                    this._shotStartTime.Unmarshal(dis);
                    this._commulativeShotTime = dis.ReadFloat();
                    this._ApertureEmitterLocation.Unmarshal(dis);
                    this._apertureDiameter = dis.ReadFloat();
                    this._wavelength = dis.ReadFloat();
                    this._peakIrradiance = dis.ReadFloat();
                    this._pulseRepetitionFrequency = dis.ReadFloat();
                    this._pulseWidth = dis.ReadInt();
                    this._flags = dis.ReadInt();
                    this._pulseShape = dis.ReadByte();
                    this._padding1 = dis.ReadUnsignedByte();
                    this._padding2 = dis.ReadUnsignedInt();
                    this._padding3 = dis.ReadUnsignedShort();
                    this._numberOfDERecords = dis.ReadUnsignedShort();
                    for (int idx = 0; idx < this.NumberOfDERecords; idx++)
                    {
                        StandardVariableSpecification anX = new StandardVariableSpecification();
                        anX.Unmarshal(dis);
                        this._dERecords.Add(anX);
                    };

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
            sb.AppendLine("<DirectedEnergyFirePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<munitionType>");
                this._munitionType.Reflection(sb);
                sb.AppendLine("</munitionType>");
                sb.AppendLine("<shotStartTime>");
                this._shotStartTime.Reflection(sb);
                sb.AppendLine("</shotStartTime>");
                sb.AppendLine("<commulativeShotTime type=\"float\">" + this._commulativeShotTime.ToString(CultureInfo.InvariantCulture) + "</commulativeShotTime>");
                sb.AppendLine("<ApertureEmitterLocation>");
                this._ApertureEmitterLocation.Reflection(sb);
                sb.AppendLine("</ApertureEmitterLocation>");
                sb.AppendLine("<apertureDiameter type=\"float\">" + this._apertureDiameter.ToString(CultureInfo.InvariantCulture) + "</apertureDiameter>");
                sb.AppendLine("<wavelength type=\"float\">" + this._wavelength.ToString(CultureInfo.InvariantCulture) + "</wavelength>");
                sb.AppendLine("<peakIrradiance type=\"float\">" + this._peakIrradiance.ToString(CultureInfo.InvariantCulture) + "</peakIrradiance>");
                sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + this._pulseRepetitionFrequency.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
                sb.AppendLine("<pulseWidth type=\"int\">" + this._pulseWidth.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
                sb.AppendLine("<flags type=\"int\">" + this._flags.ToString(CultureInfo.InvariantCulture) + "</flags>");
                sb.AppendLine("<pulseShape type=\"byte\">" + this._pulseShape.ToString(CultureInfo.InvariantCulture) + "</pulseShape>");
                sb.AppendLine("<padding1 type=\"byte\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"uint\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<padding3 type=\"ushort\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                sb.AppendLine("<dERecords type=\"ushort\">" + this._dERecords.Count.ToString(CultureInfo.InvariantCulture) + "</dERecords>");
                for (int idx = 0; idx < this._dERecords.Count; idx++)
                {
                    sb.AppendLine("<dERecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"StandardVariableSpecification\">");
                    StandardVariableSpecification aStandardVariableSpecification = (StandardVariableSpecification)this._dERecords[idx];
                    aStandardVariableSpecification.Reflection(sb);
                    sb.AppendLine("</dERecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DirectedEnergyFirePdu>");
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
            return this == obj as DirectedEnergyFirePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DirectedEnergyFirePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._munitionType.Equals(obj._munitionType))
            {
                ivarsEqual = false;
            }

            if (!this._shotStartTime.Equals(obj._shotStartTime))
            {
                ivarsEqual = false;
            }

            if (this._commulativeShotTime != obj._commulativeShotTime)
            {
                ivarsEqual = false;
            }

            if (!this._ApertureEmitterLocation.Equals(obj._ApertureEmitterLocation))
            {
                ivarsEqual = false;
            }

            if (this._apertureDiameter != obj._apertureDiameter)
            {
                ivarsEqual = false;
            }

            if (this._wavelength != obj._wavelength)
            {
                ivarsEqual = false;
            }

            if (this._peakIrradiance != obj._peakIrradiance)
            {
                ivarsEqual = false;
            }

            if (this._pulseRepetitionFrequency != obj._pulseRepetitionFrequency)
            {
                ivarsEqual = false;
            }

            if (this._pulseWidth != obj._pulseWidth)
            {
                ivarsEqual = false;
            }

            if (this._flags != obj._flags)
            {
                ivarsEqual = false;
            }

            if (this._pulseShape != obj._pulseShape)
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

            if (this._padding3 != obj._padding3)
            {
                ivarsEqual = false;
            }

            if (this._numberOfDERecords != obj._numberOfDERecords)
            {
                ivarsEqual = false;
            }

            if (this._dERecords.Count != obj._dERecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._dERecords.Count; idx++)
                {
                    if (!this._dERecords[idx].Equals(obj._dERecords[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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

            result = GenerateHash(result) ^ this._munitionType.GetHashCode();
            result = GenerateHash(result) ^ this._shotStartTime.GetHashCode();
            result = GenerateHash(result) ^ this._commulativeShotTime.GetHashCode();
            result = GenerateHash(result) ^ this._ApertureEmitterLocation.GetHashCode();
            result = GenerateHash(result) ^ this._apertureDiameter.GetHashCode();
            result = GenerateHash(result) ^ this._wavelength.GetHashCode();
            result = GenerateHash(result) ^ this._peakIrradiance.GetHashCode();
            result = GenerateHash(result) ^ this._pulseRepetitionFrequency.GetHashCode();
            result = GenerateHash(result) ^ this._pulseWidth.GetHashCode();
            result = GenerateHash(result) ^ this._flags.GetHashCode();
            result = GenerateHash(result) ^ this._pulseShape.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfDERecords.GetHashCode();

            if (this._dERecords.Count > 0)
            {
                for (int idx = 0; idx < this._dERecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._dERecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
