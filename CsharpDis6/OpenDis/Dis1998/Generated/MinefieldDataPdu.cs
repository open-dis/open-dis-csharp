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
    /// Section 5.3.10.3 Information about individual mines within a minefield. This is very, very wrong. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(TwoByteChunk))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class MinefieldDataPdu : MinefieldFamilyPdu, IEquatable<MinefieldDataPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldDataPdu"/> class.
        /// </summary>
        public MinefieldDataPdu()
        {
            PduType = 39;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldDataPdu left, MinefieldDataPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MinefieldDataPdu left, MinefieldDataPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MinefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += RequestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += 2;  // this._minefieldSequenceNumbeer
            marshalSize += 1;  // this._requestID
            marshalSize += 1;  // this._pduSequenceNumber
            marshalSize += 1;  // this._numberOfPdus
            marshalSize += 1;  // this._numberOfMinesInThisPdu
            marshalSize += 1;  // this._numberOfSensorTypes
            marshalSize += 1;  // this._pad2
            marshalSize += 4;  // this._dataFilter
            marshalSize += MineType.GetMarshalledSize();  // this._mineType
            for (int idx = 0; idx < SensorTypes.Count; idx++)
            {
                var listElement = SensorTypes[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            marshalSize += 1;  // this._pad3
            for (int idx = 0; idx < MineLocation.Count; idx++)
            {
                var listElement = MineLocation[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Minefield ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
        public EntityID MinefieldID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of entity making request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Minefield sequence number
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "minefieldSequenceNumbeer")]
        public ushort MinefieldSequenceNumbeer { get; set; }

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requestID")]
        public byte RequestID { get; set; }

        /// <summary>
        /// Gets or sets the pdu sequence number
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pduSequenceNumber")]
        public byte PduSequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of pdus in response
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfPdus")]
        public byte NumberOfPdus { get; set; }

        /// <summary>
        /// Gets or sets the how many mines are in this PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfMinesInThisPdu method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfMinesInThisPdu")]
        public byte NumberOfMinesInThisPdu { get; set; }

        /// <summary>
        /// Gets or sets the how many sensor type are in this PDU
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSensorTypes")]
        public byte NumberOfSensorTypes { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the 32 boolean fields
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "dataFilter")]
        public uint DataFilter { get; set; }

        /// <summary>
        /// Gets or sets the Mine type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "mineType")]
        public EntityType MineType { get; set; } = new EntityType();

        /// <summary>
        /// Gets the Sensor types, each 16 bits long
        /// </summary>
        [XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> SensorTypes { get; } = new();

        /// <summary>
        /// Gets or sets the Padding to get things 32-bit aligned. ^^^this is wrong--dyanmically sized padding needed
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad3")]
        public byte Pad3 { get; set; }

        /// <summary>
        /// Gets the Mine locations
        /// </summary>
        [XmlElement(ElementName = "mineLocationList", Type = typeof(List<Vector3Float>))]
        public List<Vector3Float> MineLocation { get; } = new();

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
                    MinefieldID.Marshal(dos);
                    RequestingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(MinefieldSequenceNumbeer);
                    dos.WriteUnsignedByte(RequestID);
                    dos.WriteUnsignedByte(PduSequenceNumber);
                    dos.WriteUnsignedByte(NumberOfPdus);
                    dos.WriteUnsignedByte((byte)MineLocation.Count);
                    dos.WriteUnsignedByte((byte)SensorTypes.Count);
                    dos.WriteUnsignedByte(Pad2);
                    dos.WriteUnsignedInt(DataFilter);
                    MineType.Marshal(dos);

                    for (int idx = 0; idx < SensorTypes.Count; idx++)
                    {
                        var aTwoByteChunk = SensorTypes[idx];
                        aTwoByteChunk.Marshal(dos);
                    }

                    dos.WriteUnsignedByte(Pad3);

                    for (int idx = 0; idx < MineLocation.Count; idx++)
                    {
                        var aVector3Float = MineLocation[idx];
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
                    MinefieldID.Unmarshal(dis);
                    RequestingEntityID.Unmarshal(dis);
                    MinefieldSequenceNumbeer = dis.ReadUnsignedShort();
                    RequestID = dis.ReadUnsignedByte();
                    PduSequenceNumber = dis.ReadUnsignedByte();
                    NumberOfPdus = dis.ReadUnsignedByte();
                    NumberOfMinesInThisPdu = dis.ReadUnsignedByte();
                    NumberOfSensorTypes = dis.ReadUnsignedByte();
                    Pad2 = dis.ReadUnsignedByte();
                    DataFilter = dis.ReadUnsignedInt();
                    MineType.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfSensorTypes; idx++)
                    {
                        var anX = new TwoByteChunk();
                        anX.Unmarshal(dis);
                        SensorTypes.Add(anX);
                    }

                    Pad3 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfMinesInThisPdu; idx++)
                    {
                        var anX = new Vector3Float();
                        anX.Unmarshal(dis);
                        MineLocation.Add(anX);
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
            sb.AppendLine("<MinefieldDataPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                MinefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<requestingEntityID>");
                RequestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<minefieldSequenceNumbeer type=\"ushort\">" + MinefieldSequenceNumbeer.ToString(CultureInfo.InvariantCulture) + "</minefieldSequenceNumbeer>");
                sb.AppendLine("<requestID type=\"byte\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<pduSequenceNumber type=\"byte\">" + PduSequenceNumber.ToString(CultureInfo.InvariantCulture) + "</pduSequenceNumber>");
                sb.AppendLine("<numberOfPdus type=\"byte\">" + NumberOfPdus.ToString(CultureInfo.InvariantCulture) + "</numberOfPdus>");
                sb.AppendLine("<mineLocation type=\"byte\">" + MineLocation.Count.ToString(CultureInfo.InvariantCulture) + "</mineLocation>");
                sb.AppendLine("<sensorTypes type=\"byte\">" + SensorTypes.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
                sb.AppendLine("<pad2 type=\"byte\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<dataFilter type=\"uint\">" + DataFilter.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
                sb.AppendLine("<mineType>");
                MineType.Reflection(sb);
                sb.AppendLine("</mineType>");
                for (int idx = 0; idx < SensorTypes.Count; idx++)
                {
                    sb.AppendLine("<sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
                    var aTwoByteChunk = SensorTypes[idx];
                    aTwoByteChunk.Reflection(sb);
                    sb.AppendLine("</sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<pad3 type=\"byte\">" + Pad3.ToString(CultureInfo.InvariantCulture) + "</pad3>");
                for (int idx = 0; idx < MineLocation.Count; idx++)
                {
                    sb.AppendLine("<mineLocation" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
                    var aVector3Float = MineLocation[idx];
                    aVector3Float.Reflection(sb);
                    sb.AppendLine("</mineLocation" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldDataPdu>");
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
        public override bool Equals(object obj) => this == obj as MinefieldDataPdu;

        ///<inheritdoc/>
        public bool Equals(MinefieldDataPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!MinefieldID.Equals(obj.MinefieldID))
            {
                ivarsEqual = false;
            }

            if (!RequestingEntityID.Equals(obj.RequestingEntityID))
            {
                ivarsEqual = false;
            }

            if (MinefieldSequenceNumbeer != obj.MinefieldSequenceNumbeer)
            {
                ivarsEqual = false;
            }

            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (PduSequenceNumber != obj.PduSequenceNumber)
            {
                ivarsEqual = false;
            }

            if (NumberOfPdus != obj.NumberOfPdus)
            {
                ivarsEqual = false;
            }

            if (NumberOfMinesInThisPdu != obj.NumberOfMinesInThisPdu)
            {
                ivarsEqual = false;
            }

            if (NumberOfSensorTypes != obj.NumberOfSensorTypes)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (DataFilter != obj.DataFilter)
            {
                ivarsEqual = false;
            }

            if (!MineType.Equals(obj.MineType))
            {
                ivarsEqual = false;
            }

            if (SensorTypes.Count != obj.SensorTypes.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < SensorTypes.Count; idx++)
                {
                    if (!SensorTypes[idx].Equals(obj.SensorTypes[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (Pad3 != obj.Pad3)
            {
                ivarsEqual = false;
            }

            if (MineLocation.Count != obj.MineLocation.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < MineLocation.Count; idx++)
                {
                    if (!MineLocation[idx].Equals(obj.MineLocation[idx]))
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

            result = GenerateHash(result) ^ MinefieldID.GetHashCode();
            result = GenerateHash(result) ^ RequestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ MinefieldSequenceNumbeer.GetHashCode();
            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ PduSequenceNumber.GetHashCode();
            result = GenerateHash(result) ^ NumberOfPdus.GetHashCode();
            result = GenerateHash(result) ^ NumberOfMinesInThisPdu.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSensorTypes.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ DataFilter.GetHashCode();
            result = GenerateHash(result) ^ MineType.GetHashCode();

            if (SensorTypes.Count > 0)
            {
                for (int idx = 0; idx < SensorTypes.Count; idx++)
                {
                    result = GenerateHash(result) ^ SensorTypes[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ Pad3.GetHashCode();

            if (MineLocation.Count > 0)
            {
                for (int idx = 0; idx < MineLocation.Count; idx++)
                {
                    result = GenerateHash(result) ^ MineLocation[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
