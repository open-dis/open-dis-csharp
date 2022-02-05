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
    /// Section 5.3.10.2 Query a minefield for information about individual mines. Requires manual clean up to get the
    /// padding right. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(TwoByteChunk))]
    public partial class MinefieldQueryPdu : MinefieldFamilyPdu, IEquatable<MinefieldQueryPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldQueryPdu"/> class.
        /// </summary>
        public MinefieldQueryPdu()
        {
            PduType = 38;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldQueryPdu left, MinefieldQueryPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MinefieldQueryPdu left, MinefieldQueryPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MinefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += RequestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += 1;  // this._requestID
            marshalSize += 1;  // this._numberOfPerimeterPoints
            marshalSize += 1;  // this._pad2
            marshalSize += 1;  // this._numberOfSensorTypes
            marshalSize += 4;  // this._dataFilter
            marshalSize += RequestedMineType.GetMarshalledSize();  // this._requestedMineType
            for (int idx = 0; idx < RequestedPerimeterPoints.Count; idx++)
            {
                var listElement = RequestedPerimeterPoints[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < SensorTypes.Count; idx++)
            {
                var listElement = SensorTypes[idx];
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
        /// Gets or sets the EID of entity making the request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requestID")]
        public byte RequestID { get; set; }

        /// <summary>
        /// Gets or sets the Number of perimeter points for the minefield
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfPerimeterPoints method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfPerimeterPoints")]
        public byte NumberOfPerimeterPoints { get; set; }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the Number of sensor types
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
        /// Gets or sets the data filter, 32 boolean fields
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "dataFilter")]
        public uint DataFilter { get; set; }

        /// <summary>
        /// Gets or sets the Entity type of mine being requested
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "requestedMineType")]
        public EntityType RequestedMineType { get; set; } = new EntityType();

        /// <summary>
        /// Gets the perimeter points of request
        /// </summary>
        [XmlElement(ElementName = "requestedPerimeterPointsList", Type = typeof(List<Point>))]
        public List<Point> RequestedPerimeterPoints { get; } = new();

        /// <summary>
        /// Gets the Sensor types, each 16 bits long
        /// </summary>
        [XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> SensorTypes { get; } = new();

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
                    dos.WriteUnsignedByte(RequestID);
                    dos.WriteUnsignedByte((byte)RequestedPerimeterPoints.Count);
                    dos.WriteUnsignedByte(Pad2);
                    dos.WriteUnsignedByte((byte)SensorTypes.Count);
                    dos.WriteUnsignedInt(DataFilter);
                    RequestedMineType.Marshal(dos);

                    for (int idx = 0; idx < RequestedPerimeterPoints.Count; idx++)
                    {
                        var aPoint = RequestedPerimeterPoints[idx];
                        aPoint.Marshal(dos);
                    }

                    for (int idx = 0; idx < SensorTypes.Count; idx++)
                    {
                        var aTwoByteChunk = SensorTypes[idx];
                        aTwoByteChunk.Marshal(dos);
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
                    RequestID = dis.ReadUnsignedByte();
                    NumberOfPerimeterPoints = dis.ReadUnsignedByte();
                    Pad2 = dis.ReadUnsignedByte();
                    NumberOfSensorTypes = dis.ReadUnsignedByte();
                    DataFilter = dis.ReadUnsignedInt();
                    RequestedMineType.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfPerimeterPoints; idx++)
                    {
                        var anX = new Point();
                        anX.Unmarshal(dis);
                        RequestedPerimeterPoints.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfSensorTypes; idx++)
                    {
                        var anX = new TwoByteChunk();
                        anX.Unmarshal(dis);
                        SensorTypes.Add(anX);
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
            sb.AppendLine("<MinefieldQueryPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                MinefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<requestingEntityID>");
                RequestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<requestID type=\"byte\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requestedPerimeterPoints type=\"byte\">" + RequestedPerimeterPoints.Count.ToString(CultureInfo.InvariantCulture) + "</requestedPerimeterPoints>");
                sb.AppendLine("<pad2 type=\"byte\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<sensorTypes type=\"byte\">" + SensorTypes.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
                sb.AppendLine("<dataFilter type=\"uint\">" + DataFilter.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
                sb.AppendLine("<requestedMineType>");
                RequestedMineType.Reflection(sb);
                sb.AppendLine("</requestedMineType>");
                for (int idx = 0; idx < RequestedPerimeterPoints.Count; idx++)
                {
                    sb.AppendLine("<requestedPerimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
                    var aPoint = RequestedPerimeterPoints[idx];
                    aPoint.Reflection(sb);
                    sb.AppendLine("</requestedPerimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < SensorTypes.Count; idx++)
                {
                    sb.AppendLine("<sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
                    var aTwoByteChunk = SensorTypes[idx];
                    aTwoByteChunk.Reflection(sb);
                    sb.AppendLine("</sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldQueryPdu>");
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
        public override bool Equals(object obj) => this == obj as MinefieldQueryPdu;

        ///<inheritdoc/>
        public bool Equals(MinefieldQueryPdu obj)
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

            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (NumberOfPerimeterPoints != obj.NumberOfPerimeterPoints)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (NumberOfSensorTypes != obj.NumberOfSensorTypes)
            {
                ivarsEqual = false;
            }

            if (DataFilter != obj.DataFilter)
            {
                ivarsEqual = false;
            }

            if (!RequestedMineType.Equals(obj.RequestedMineType))
            {
                ivarsEqual = false;
            }

            if (RequestedPerimeterPoints.Count != obj.RequestedPerimeterPoints.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < RequestedPerimeterPoints.Count; idx++)
                {
                    if (!RequestedPerimeterPoints[idx].Equals(obj.RequestedPerimeterPoints[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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
            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ NumberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSensorTypes.GetHashCode();
            result = GenerateHash(result) ^ DataFilter.GetHashCode();
            result = GenerateHash(result) ^ RequestedMineType.GetHashCode();

            if (RequestedPerimeterPoints.Count > 0)
            {
                for (int idx = 0; idx < RequestedPerimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ RequestedPerimeterPoints[idx].GetHashCode();
                }
            }

            if (SensorTypes.Count > 0)
            {
                for (int idx = 0; idx < SensorTypes.Count; idx++)
                {
                    result = GenerateHash(result) ^ SensorTypes[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
