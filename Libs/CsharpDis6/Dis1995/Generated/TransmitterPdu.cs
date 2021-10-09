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
    /// Section 5.3.8.1. Detailed information about a radio transmitter. This PDU requires        manually written code to complete.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(RadioEntityType))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(ModulationType))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class TransmitterPdu : RadioCommunicationsPdu, IEquatable<TransmitterPdu>
    {
        /// <summary>
        /// linear accelleration of entity
        /// </summary>
        private RadioEntityType _radioEntityType = new RadioEntityType();

        /// <summary>
        /// transmit state
        /// </summary>
        private byte _transmitState;

        /// <summary>
        /// input source
        /// </summary>
        private byte _inputSource;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding1;

        /// <summary>
        /// Location of antenna
        /// </summary>
        private Vector3Double _antennaLocation = new Vector3Double();

        /// <summary>
        /// relative location of antenna
        /// </summary>
        private Vector3Double _relativeAntennaLocation = new Vector3Double();

        /// <summary>
        /// atenna pattern type
        /// </summary>
        private ushort _antennaPatternType;

        /// <summary>
        /// atenna pattern length
        /// </summary>
        private ushort _antennaPatternCount;

        /// <summary>
        /// frequency
        /// </summary>
        private double _frequency;

        /// <summary>
        /// transmit frequency Bandwidth
        /// </summary>
        private float _transmitFrequencyBandwidth;

        /// <summary>
        /// transmission power
        /// </summary>
        private float _power;

        /// <summary>
        /// modulation
        /// </summary>
        private ModulationType _modulationType = new ModulationType();

        /// <summary>
        /// crypto system enumeration
        /// </summary>
        private ushort _cryptoSystem;

        /// <summary>
        /// crypto system key identifer
        /// </summary>
        private ushort _cryptoKeyId;

        /// <summary>
        /// how many modulation parameters we have
        /// </summary>
        private byte _modulationParameterCount;

        /// <summary>
        /// padding2
        /// </summary>
        private ushort _padding2;

        /// <summary>
        /// padding3
        /// </summary>
        private byte _padding3;

        /// <summary>
        /// variable length list of modulation parameters
        /// </summary>
        private List<Vector3Float> _modulationParametersList = new List<Vector3Float>();

        /// <summary>
        /// variable length list of antenna pattern records
        /// </summary>
        private List<Vector3Float> _antennaPatternList = new List<Vector3Float>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransmitterPdu"/> class.
        /// </summary>
        public TransmitterPdu()
        {
            PduType = (byte)25;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(TransmitterPdu left, TransmitterPdu right)
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
        public static bool operator ==(TransmitterPdu left, TransmitterPdu right)
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
            marshalSize += this._radioEntityType.GetMarshalledSize();  // this._radioEntityType
            marshalSize += 1;  // this._transmitState
            marshalSize += 1;  // this._inputSource
            marshalSize += 2;  // this._padding1
            marshalSize += this._antennaLocation.GetMarshalledSize();  // this._antennaLocation
            marshalSize += this._relativeAntennaLocation.GetMarshalledSize();  // this._relativeAntennaLocation
            marshalSize += 2;  // this._antennaPatternType
            marshalSize += 2;  // this._antennaPatternCount
            marshalSize += 8;  // this._frequency
            marshalSize += 4;  // this._transmitFrequencyBandwidth
            marshalSize += 4;  // this._power
            marshalSize += this._modulationType.GetMarshalledSize();  // this._modulationType
            marshalSize += 2;  // this._cryptoSystem
            marshalSize += 2;  // this._cryptoKeyId
            marshalSize += 1;  // this._modulationParameterCount
            marshalSize += 2;  // this._padding2
            marshalSize += 1;  // this._padding3
            for (int idx = 0; idx < this._modulationParametersList.Count; idx++)
            {
                Vector3Float listElement = (Vector3Float)this._modulationParametersList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._antennaPatternList.Count; idx++)
            {
                Vector3Float listElement = (Vector3Float)this._antennaPatternList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the linear accelleration of entity
        /// </summary>
        [XmlElement(Type = typeof(RadioEntityType), ElementName = "radioEntityType")]
        public RadioEntityType RadioEntityType
        {
            get
            {
                return this._radioEntityType;
            }

            set
            {
                this._radioEntityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the transmit state
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitState")]
        public byte TransmitState
        {
            get
            {
                return this._transmitState;
            }

            set
            {
                this._transmitState = value;
            }
        }

        /// <summary>
        /// Gets or sets the input source
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "inputSource")]
        public byte InputSource
        {
            get
            {
                return this._inputSource;
            }

            set
            {
                this._inputSource = value;
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
        /// Gets or sets the Location of antenna
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
        public Vector3Double AntennaLocation
        {
            get
            {
                return this._antennaLocation;
            }

            set
            {
                this._antennaLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the relative location of antenna
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "relativeAntennaLocation")]
        public Vector3Double RelativeAntennaLocation
        {
            get
            {
                return this._relativeAntennaLocation;
            }

            set
            {
                this._relativeAntennaLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the atenna pattern type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "antennaPatternType")]
        public ushort AntennaPatternType
        {
            get
            {
                return this._antennaPatternType;
            }

            set
            {
                this._antennaPatternType = value;
            }
        }

        /// <summary>
        /// Gets or sets the atenna pattern length
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getantennaPatternCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "antennaPatternCount")]
        public ushort AntennaPatternCount
        {
            get
            {
                return this._antennaPatternCount;
            }

            set
            {
                this._antennaPatternCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "frequency")]
        public double Frequency
        {
            get
            {
                return this._frequency;
            }

            set
            {
                this._frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the transmit frequency Bandwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "transmitFrequencyBandwidth")]
        public float TransmitFrequencyBandwidth
        {
            get
            {
                return this._transmitFrequencyBandwidth;
            }

            set
            {
                this._transmitFrequencyBandwidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the transmission power
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "power")]
        public float Power
        {
            get
            {
                return this._power;
            }

            set
            {
                this._power = value;
            }
        }

        /// <summary>
        /// Gets or sets the modulation
        /// </summary>
        [XmlElement(Type = typeof(ModulationType), ElementName = "modulationType")]
        public ModulationType ModulationType
        {
            get
            {
                return this._modulationType;
            }

            set
            {
                this._modulationType = value;
            }
        }

        /// <summary>
        /// Gets or sets the crypto system enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "cryptoSystem")]
        public ushort CryptoSystem
        {
            get
            {
                return this._cryptoSystem;
            }

            set
            {
                this._cryptoSystem = value;
            }
        }

        /// <summary>
        /// Gets or sets the crypto system key identifer
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "cryptoKeyId")]
        public ushort CryptoKeyId
        {
            get
            {
                return this._cryptoKeyId;
            }

            set
            {
                this._cryptoKeyId = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many modulation parameters we have
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getmodulationParameterCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "modulationParameterCount")]
        public byte ModulationParameterCount
        {
            get
            {
                return this._modulationParameterCount;
            }

            set
            {
                this._modulationParameterCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding2
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
        /// Gets or sets the padding3
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
        /// Gets the variable length list of modulation parameters
        /// </summary>
        [XmlElement(ElementName = "modulationParametersListList", Type = typeof(List<Vector3Float>))]
        public List<Vector3Float> ModulationParametersList
        {
            get
            {
                return this._modulationParametersList;
            }
        }

        /// <summary>
        /// Gets the variable length list of antenna pattern records
        /// </summary>
        [XmlElement(ElementName = "antennaPatternListList", Type = typeof(List<Vector3Float>))]
        public List<Vector3Float> AntennaPatternList
        {
            get
            {
                return this._antennaPatternList;
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
                    this._radioEntityType.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._transmitState);
                    dos.WriteUnsignedByte((byte)this._inputSource);
                    dos.WriteUnsignedShort((ushort)this._padding1);
                    this._antennaLocation.Marshal(dos);
                    this._relativeAntennaLocation.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._antennaPatternType);
                    dos.WriteUnsignedShort((ushort)this._antennaPatternList.Count);
                    dos.WriteDouble((double)this._frequency);
                    dos.WriteFloat((float)this._transmitFrequencyBandwidth);
                    dos.WriteFloat((float)this._power);
                    this._modulationType.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._cryptoSystem);
                    dos.WriteUnsignedShort((ushort)this._cryptoKeyId);
                    dos.WriteUnsignedByte((byte)this._modulationParametersList.Count);
                    dos.WriteUnsignedShort((ushort)this._padding2);
                    dos.WriteUnsignedByte((byte)this._padding3);

                    for (int idx = 0; idx < this._modulationParametersList.Count; idx++)
                    {
                        Vector3Float aVector3Float = (Vector3Float)this._modulationParametersList[idx];
                        aVector3Float.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._antennaPatternList.Count; idx++)
                    {
                        Vector3Float aVector3Float = (Vector3Float)this._antennaPatternList[idx];
                        aVector3Float.Marshal(dos);
                    }
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
                    this._radioEntityType.Unmarshal(dis);
                    this._transmitState = dis.ReadUnsignedByte();
                    this._inputSource = dis.ReadUnsignedByte();
                    this._padding1 = dis.ReadUnsignedShort();
                    this._antennaLocation.Unmarshal(dis);
                    this._relativeAntennaLocation.Unmarshal(dis);
                    this._antennaPatternType = dis.ReadUnsignedShort();
                    this._antennaPatternCount = dis.ReadUnsignedShort();
                    this._frequency = dis.ReadDouble();
                    this._transmitFrequencyBandwidth = dis.ReadFloat();
                    this._power = dis.ReadFloat();
                    this._modulationType.Unmarshal(dis);
                    this._cryptoSystem = dis.ReadUnsignedShort();
                    this._cryptoKeyId = dis.ReadUnsignedShort();
                    this._modulationParameterCount = dis.ReadUnsignedByte();
                    this._padding2 = dis.ReadUnsignedShort();
                    this._padding3 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.ModulationParameterCount; idx++)
                    {
                        Vector3Float anX = new Vector3Float();
                        anX.Unmarshal(dis);
                        this._modulationParametersList.Add(anX);
                    }

                    for (int idx = 0; idx < this.AntennaPatternCount; idx++)
                    {
                        Vector3Float anX = new Vector3Float();
                        anX.Unmarshal(dis);
                        this._antennaPatternList.Add(anX);
                    }
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
            sb.AppendLine("<TransmitterPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<radioEntityType>");
                this._radioEntityType.Reflection(sb);
                sb.AppendLine("</radioEntityType>");
                sb.AppendLine("<transmitState type=\"byte\">" + this._transmitState.ToString(CultureInfo.InvariantCulture) + "</transmitState>");
                sb.AppendLine("<inputSource type=\"byte\">" + this._inputSource.ToString(CultureInfo.InvariantCulture) + "</inputSource>");
                sb.AppendLine("<padding1 type=\"ushort\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<antennaLocation>");
                this._antennaLocation.Reflection(sb);
                sb.AppendLine("</antennaLocation>");
                sb.AppendLine("<relativeAntennaLocation>");
                this._relativeAntennaLocation.Reflection(sb);
                sb.AppendLine("</relativeAntennaLocation>");
                sb.AppendLine("<antennaPatternType type=\"ushort\">" + this._antennaPatternType.ToString(CultureInfo.InvariantCulture) + "</antennaPatternType>");
                sb.AppendLine("<antennaPatternList type=\"ushort\">" + this._antennaPatternList.Count.ToString(CultureInfo.InvariantCulture) + "</antennaPatternList>");
                sb.AppendLine("<frequency type=\"double\">" + this._frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<transmitFrequencyBandwidth type=\"float\">" + this._transmitFrequencyBandwidth.ToString(CultureInfo.InvariantCulture) + "</transmitFrequencyBandwidth>");
                sb.AppendLine("<power type=\"float\">" + this._power.ToString(CultureInfo.InvariantCulture) + "</power>");
                sb.AppendLine("<modulationType>");
                this._modulationType.Reflection(sb);
                sb.AppendLine("</modulationType>");
                sb.AppendLine("<cryptoSystem type=\"ushort\">" + this._cryptoSystem.ToString(CultureInfo.InvariantCulture) + "</cryptoSystem>");
                sb.AppendLine("<cryptoKeyId type=\"ushort\">" + this._cryptoKeyId.ToString(CultureInfo.InvariantCulture) + "</cryptoKeyId>");
                sb.AppendLine("<modulationParametersList type=\"byte\">" + this._modulationParametersList.Count.ToString(CultureInfo.InvariantCulture) + "</modulationParametersList>");
                sb.AppendLine("<padding2 type=\"ushort\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<padding3 type=\"byte\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                for (int idx = 0; idx < this._modulationParametersList.Count; idx++)
                {
                    sb.AppendLine("<modulationParametersList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
                    Vector3Float aVector3Float = (Vector3Float)this._modulationParametersList[idx];
                    aVector3Float.Reflection(sb);
                    sb.AppendLine("</modulationParametersList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._antennaPatternList.Count; idx++)
                {
                    sb.AppendLine("<antennaPatternList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
                    Vector3Float aVector3Float = (Vector3Float)this._antennaPatternList[idx];
                    aVector3Float.Reflection(sb);
                    sb.AppendLine("</antennaPatternList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</TransmitterPdu>");
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
            return this == obj as TransmitterPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(TransmitterPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._radioEntityType.Equals(obj._radioEntityType))
            {
                ivarsEqual = false;
            }

            if (this._transmitState != obj._transmitState)
            {
                ivarsEqual = false;
            }

            if (this._inputSource != obj._inputSource)
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (!this._antennaLocation.Equals(obj._antennaLocation))
            {
                ivarsEqual = false;
            }

            if (!this._relativeAntennaLocation.Equals(obj._relativeAntennaLocation))
            {
                ivarsEqual = false;
            }

            if (this._antennaPatternType != obj._antennaPatternType)
            {
                ivarsEqual = false;
            }

            if (this._antennaPatternCount != obj._antennaPatternCount)
            {
                ivarsEqual = false;
            }

            if (this._frequency != obj._frequency)
            {
                ivarsEqual = false;
            }

            if (this._transmitFrequencyBandwidth != obj._transmitFrequencyBandwidth)
            {
                ivarsEqual = false;
            }

            if (this._power != obj._power)
            {
                ivarsEqual = false;
            }

            if (!this._modulationType.Equals(obj._modulationType))
            {
                ivarsEqual = false;
            }

            if (this._cryptoSystem != obj._cryptoSystem)
            {
                ivarsEqual = false;
            }

            if (this._cryptoKeyId != obj._cryptoKeyId)
            {
                ivarsEqual = false;
            }

            if (this._modulationParameterCount != obj._modulationParameterCount)
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

            if (this._modulationParametersList.Count != obj._modulationParametersList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._modulationParametersList.Count; idx++)
                {
                    if (!this._modulationParametersList[idx].Equals(obj._modulationParametersList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._antennaPatternList.Count != obj._antennaPatternList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._antennaPatternList.Count; idx++)
                {
                    if (!this._antennaPatternList[idx].Equals(obj._antennaPatternList[idx]))
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

            result = GenerateHash(result) ^ this._radioEntityType.GetHashCode();
            result = GenerateHash(result) ^ this._transmitState.GetHashCode();
            result = GenerateHash(result) ^ this._inputSource.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._antennaLocation.GetHashCode();
            result = GenerateHash(result) ^ this._relativeAntennaLocation.GetHashCode();
            result = GenerateHash(result) ^ this._antennaPatternType.GetHashCode();
            result = GenerateHash(result) ^ this._antennaPatternCount.GetHashCode();
            result = GenerateHash(result) ^ this._frequency.GetHashCode();
            result = GenerateHash(result) ^ this._transmitFrequencyBandwidth.GetHashCode();
            result = GenerateHash(result) ^ this._power.GetHashCode();
            result = GenerateHash(result) ^ this._modulationType.GetHashCode();
            result = GenerateHash(result) ^ this._cryptoSystem.GetHashCode();
            result = GenerateHash(result) ^ this._cryptoKeyId.GetHashCode();
            result = GenerateHash(result) ^ this._modulationParameterCount.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();

            if (this._modulationParametersList.Count > 0)
            {
                for (int idx = 0; idx < this._modulationParametersList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._modulationParametersList[idx].GetHashCode();
                }
            }

            if (this._antennaPatternList.Count > 0)
            {
                for (int idx = 0; idx < this._antennaPatternList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._antennaPatternList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
