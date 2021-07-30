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
    /// Section 5.3.8.1. Detailed information about a radio transmitter. This PDU requires manually        written code
    /// to complete, since the modulation parameters are of variable length. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(RadioEntityType))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(ModulationType))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class TransmitterPdu : RadioCommunicationsFamilyPdu, IEquatable<TransmitterPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmitterPdu"/> class.
        /// </summary>
        public TransmitterPdu()
        {
            PduType = 25;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(TransmitterPdu left, TransmitterPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(TransmitterPdu left, TransmitterPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += RadioEntityType.GetMarshalledSize();  // this._radioEntityType
            marshalSize += 1;  // this._transmitState
            marshalSize += 1;  // this._inputSource
            marshalSize += 2;  // this._padding1
            marshalSize += AntennaLocation.GetMarshalledSize();  // this._antennaLocation
            marshalSize += RelativeAntennaLocation.GetMarshalledSize();  // this._relativeAntennaLocation
            marshalSize += 2;  // this._antennaPatternType
            marshalSize += 2;  // this._antennaPatternCount
            marshalSize += 8;  // this._frequency
            marshalSize += 4;  // this._transmitFrequencyBandwidth
            marshalSize += 4;  // this._power
            marshalSize += ModulationType.GetMarshalledSize();  // this._modulationType
            marshalSize += 2;  // this._cryptoSystem
            marshalSize += 2;  // this._cryptoKeyId
            marshalSize += 1;  // this._modulationParameterCount
            marshalSize += 2;  // this._padding2
            marshalSize += 1;  // this._padding3
            for (int idx = 0; idx < ModulationParametersList.Count; idx++)
            {
                var listElement = ModulationParametersList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < AntennaPatternList.Count; idx++)
            {
                var listElement = AntennaPatternList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the linear accelleration of entity
        /// </summary>
        [XmlElement(Type = typeof(RadioEntityType), ElementName = "radioEntityType")]
        public RadioEntityType RadioEntityType { get; set; } = new RadioEntityType();

        /// <summary>
        /// Gets or sets the transmit state
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "transmitState")]
        public byte TransmitState { get; set; }

        /// <summary>
        /// Gets or sets the input source
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "inputSource")]
        public byte InputSource { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the Location of antenna
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
        public Vector3Double AntennaLocation { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the relative location of antenna
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
        public Vector3Float RelativeAntennaLocation { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the antenna pattern type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "antennaPatternType")]
        public ushort AntennaPatternType { get; set; }

        /// <summary>
        /// Gets or sets the atenna pattern length
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getantennaPatternCount method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "antennaPatternCount")]
        public ushort AntennaPatternCount { get; set; }

        /// <summary>
        /// Gets or sets the frequency
        /// </summary>
        [XmlElement(Type = typeof(ulong), ElementName = "frequency")]
        public ulong Frequency { get; set; }

        /// <summary>
        /// Gets or sets the transmit frequency Bandwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "transmitFrequencyBandwidth")]
        public float TransmitFrequencyBandwidth { get; set; }

        /// <summary>
        /// Gets or sets the transmission power
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "power")]
        public float Power { get; set; }

        /// <summary>
        /// Gets or sets the modulation
        /// </summary>
        [XmlElement(Type = typeof(ModulationType), ElementName = "modulationType")]
        public ModulationType ModulationType { get; set; } = new ModulationType();

        /// <summary>
        /// Gets or sets the crypto system enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "cryptoSystem")]
        public ushort CryptoSystem { get; set; }

        /// <summary>
        /// Gets or sets the crypto system key identifer
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "cryptoKeyId")]
        public ushort CryptoKeyId { get; set; }

        /// <summary>
        /// Gets or sets the how many modulation parameters we have
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getmodulationParameterCount method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "modulationParameterCount")]
        public byte ModulationParameterCount { get; set; }

        /// <summary>
        /// Gets or sets the padding2
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding2")]
        public ushort Padding2 { get; set; }

        /// <summary>
        /// Gets or sets the padding3
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding3")]
        public byte Padding3 { get; set; }

        /// <summary>
        /// Gets the variable length list of modulation parameters
        /// </summary>
        [XmlElement(ElementName = "modulationParametersListList", Type = typeof(List<Vector3Float>))]
        public List<Vector3Float> ModulationParametersList { get; } = new();

        /// <summary>
        /// Gets the variable length list of antenna pattern records
        /// </summary>
        [XmlElement(ElementName = "antennaPatternListList", Type = typeof(List<Vector3Float>))]
        public List<Vector3Float> AntennaPatternList { get; } = new();

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    RadioEntityType.Marshal(dos);
                    dos.WriteUnsignedByte(TransmitState);
                    dos.WriteUnsignedByte(InputSource);
                    dos.WriteUnsignedShort(Padding1);
                    AntennaLocation.Marshal(dos);
                    RelativeAntennaLocation.Marshal(dos);
                    dos.WriteUnsignedShort(AntennaPatternType);
                    dos.WriteUnsignedShort((ushort)AntennaPatternList.Count);
                    dos.WriteUnsignedLong(Frequency);
                    dos.WriteFloat((float)TransmitFrequencyBandwidth);
                    dos.WriteFloat((float)Power);
                    ModulationType.Marshal(dos);
                    dos.WriteUnsignedShort(CryptoSystem);
                    dos.WriteUnsignedShort(CryptoKeyId);
                    dos.WriteUnsignedByte((byte)ModulationParametersList.Count);
                    dos.WriteUnsignedShort(Padding2);
                    dos.WriteUnsignedByte(Padding3);

                    for (int idx = 0; idx < ModulationParametersList.Count; idx++)
                    {
                        var aVector3Float = ModulationParametersList[idx];
                        aVector3Float.Marshal(dos);
                    }

                    for (int idx = 0; idx < AntennaPatternList.Count; idx++)
                    {
                        var aVector3Float = AntennaPatternList[idx];
                        aVector3Float.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
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
                    RadioEntityType.Unmarshal(dis);
                    TransmitState = dis.ReadUnsignedByte();
                    InputSource = dis.ReadUnsignedByte();
                    Padding1 = dis.ReadUnsignedShort();
                    AntennaLocation.Unmarshal(dis);
                    RelativeAntennaLocation.Unmarshal(dis);
                    AntennaPatternType = dis.ReadUnsignedShort();
                    AntennaPatternCount = dis.ReadUnsignedShort();
                    Frequency = dis.ReadUnsignedLong();
                    TransmitFrequencyBandwidth = dis.ReadFloat();
                    Power = dis.ReadFloat();
                    ModulationType.Unmarshal(dis);
                    CryptoSystem = dis.ReadUnsignedShort();
                    CryptoKeyId = dis.ReadUnsignedShort();
                    ModulationParameterCount = dis.ReadUnsignedByte();
                    Padding2 = dis.ReadUnsignedShort();
                    Padding3 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < ModulationParameterCount; idx++)
                    {
                        var anX = new Vector3Float();
                        anX.Unmarshal(dis);
                        ModulationParametersList.Add(anX);
                    }

                    for (int idx = 0; idx < AntennaPatternCount; idx++)
                    {
                        var anX = new Vector3Float();
                        anX.Unmarshal(dis);
                        AntennaPatternList.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<TransmitterPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<radioEntityType>");
                RadioEntityType.Reflection(sb);
                sb.AppendLine("</radioEntityType>");
                sb.AppendLine("<transmitState type=\"byte\">" + TransmitState.ToString(CultureInfo.InvariantCulture) + "</transmitState>");
                sb.AppendLine("<inputSource type=\"byte\">" + InputSource.ToString(CultureInfo.InvariantCulture) + "</inputSource>");
                sb.AppendLine("<padding1 type=\"ushort\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<antennaLocation>");
                AntennaLocation.Reflection(sb);
                sb.AppendLine("</antennaLocation>");
                sb.AppendLine("<relativeAntennaLocation>");
                RelativeAntennaLocation.Reflection(sb);
                sb.AppendLine("</relativeAntennaLocation>");
                sb.AppendLine("<antennaPatternType type=\"ushort\">" + AntennaPatternType.ToString(CultureInfo.InvariantCulture) + "</antennaPatternType>");
                sb.AppendLine("<antennaPatternList type=\"ushort\">" + AntennaPatternList.Count.ToString(CultureInfo.InvariantCulture) + "</antennaPatternList>");
                sb.AppendLine("<frequency type=\"ulong\">" + Frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<transmitFrequencyBandwidth type=\"float\">" + TransmitFrequencyBandwidth.ToString(CultureInfo.InvariantCulture) + "</transmitFrequencyBandwidth>");
                sb.AppendLine("<power type=\"float\">" + Power.ToString(CultureInfo.InvariantCulture) + "</power>");
                sb.AppendLine("<modulationType>");
                ModulationType.Reflection(sb);
                sb.AppendLine("</modulationType>");
                sb.AppendLine("<cryptoSystem type=\"ushort\">" + CryptoSystem.ToString(CultureInfo.InvariantCulture) + "</cryptoSystem>");
                sb.AppendLine("<cryptoKeyId type=\"ushort\">" + CryptoKeyId.ToString(CultureInfo.InvariantCulture) + "</cryptoKeyId>");
                sb.AppendLine("<modulationParametersList type=\"byte\">" + ModulationParametersList.Count.ToString(CultureInfo.InvariantCulture) + "</modulationParametersList>");
                sb.AppendLine("<padding2 type=\"ushort\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<padding3 type=\"byte\">" + Padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                for (int idx = 0; idx < ModulationParametersList.Count; idx++)
                {
                    sb.AppendLine("<modulationParametersList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
                    var aVector3Float = ModulationParametersList[idx];
                    aVector3Float.Reflection(sb);
                    sb.AppendLine("</modulationParametersList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < AntennaPatternList.Count; idx++)
                {
                    sb.AppendLine("<antennaPatternList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
                    var aVector3Float = AntennaPatternList[idx];
                    aVector3Float.Reflection(sb);
                    sb.AppendLine("</antennaPatternList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</TransmitterPdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as TransmitterPdu;

        ///<inheritdoc/>
        public bool Equals(TransmitterPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!RadioEntityType.Equals(obj.RadioEntityType))
            {
                ivarsEqual = false;
            }

            if (TransmitState != obj.TransmitState)
            {
                ivarsEqual = false;
            }

            if (InputSource != obj.InputSource)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (!AntennaLocation.Equals(obj.AntennaLocation))
            {
                ivarsEqual = false;
            }

            if (!RelativeAntennaLocation.Equals(obj.RelativeAntennaLocation))
            {
                ivarsEqual = false;
            }

            if (AntennaPatternType != obj.AntennaPatternType)
            {
                ivarsEqual = false;
            }

            if (AntennaPatternCount != obj.AntennaPatternCount)
            {
                ivarsEqual = false;
            }

            if (Frequency != obj.Frequency)
            {
                ivarsEqual = false;
            }

            if (TransmitFrequencyBandwidth != obj.TransmitFrequencyBandwidth)
            {
                ivarsEqual = false;
            }

            if (Power != obj.Power)
            {
                ivarsEqual = false;
            }

            if (!ModulationType.Equals(obj.ModulationType))
            {
                ivarsEqual = false;
            }

            if (CryptoSystem != obj.CryptoSystem)
            {
                ivarsEqual = false;
            }

            if (CryptoKeyId != obj.CryptoKeyId)
            {
                ivarsEqual = false;
            }

            if (ModulationParameterCount != obj.ModulationParameterCount)
            {
                ivarsEqual = false;
            }

            if (Padding2 != obj.Padding2)
            {
                ivarsEqual = false;
            }

            if (Padding3 != obj.Padding3)
            {
                ivarsEqual = false;
            }

            if (ModulationParametersList.Count != obj.ModulationParametersList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ModulationParametersList.Count; idx++)
                {
                    if (!ModulationParametersList[idx].Equals(obj.ModulationParametersList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (AntennaPatternList.Count != obj.AntennaPatternList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < AntennaPatternList.Count; idx++)
                {
                    if (!AntennaPatternList[idx].Equals(obj.AntennaPatternList[idx]))
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
        private static int GenerateHash(int hash) => hash << (5 + hash);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ RadioEntityType.GetHashCode();
            result = GenerateHash(result) ^ TransmitState.GetHashCode();
            result = GenerateHash(result) ^ InputSource.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ AntennaLocation.GetHashCode();
            result = GenerateHash(result) ^ RelativeAntennaLocation.GetHashCode();
            result = GenerateHash(result) ^ AntennaPatternType.GetHashCode();
            result = GenerateHash(result) ^ AntennaPatternCount.GetHashCode();
            result = GenerateHash(result) ^ Frequency.GetHashCode();
            result = GenerateHash(result) ^ TransmitFrequencyBandwidth.GetHashCode();
            result = GenerateHash(result) ^ Power.GetHashCode();
            result = GenerateHash(result) ^ ModulationType.GetHashCode();
            result = GenerateHash(result) ^ CryptoSystem.GetHashCode();
            result = GenerateHash(result) ^ CryptoKeyId.GetHashCode();
            result = GenerateHash(result) ^ ModulationParameterCount.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();
            result = GenerateHash(result) ^ Padding3.GetHashCode();

            if (ModulationParametersList.Count > 0)
            {
                for (int idx = 0; idx < ModulationParametersList.Count; idx++)
                {
                    result = GenerateHash(result) ^ ModulationParametersList[idx].GetHashCode();
                }
            }

            if (AntennaPatternList.Count > 0)
            {
                for (int idx = 0; idx < AntennaPatternList.Count; idx++)
                {
                    result = GenerateHash(result) ^ AntennaPatternList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
