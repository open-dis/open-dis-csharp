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
    /// Section 5.3.11.2: Information about globat, spatially varying enviornmental effects. This requires manual cleanup;
    /// the grid axis       records are variable sized. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(GridAxisRecord))]
    public partial class GriddedDataPdu : SyntheticEnvironmentFamilyPdu, IEquatable<GriddedDataPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GriddedDataPdu"/> class.
        /// </summary>
        public GriddedDataPdu()
        {
            PduType = 42;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(GriddedDataPdu left, GriddedDataPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(GriddedDataPdu left, GriddedDataPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EnvironmentalSimulationApplicationID.GetMarshalledSize();  // this._environmentalSimulationApplicationID
            marshalSize += 2;  // this._fieldNumber
            marshalSize += 2;  // this._pduNumber
            marshalSize += 2;  // this._pduTotal
            marshalSize += 2;  // this._coordinateSystem
            marshalSize += 1;  // this._numberOfGridAxes
            marshalSize += 1;  // this._constantGrid
            marshalSize += EnvironmentType.GetMarshalledSize();  // this._environmentType
            marshalSize += Orientation.GetMarshalledSize();  // this._orientation
            marshalSize += 8;  // this._sampleTime
            marshalSize += 4;  // this._totalValues
            marshalSize += 1;  // this._vectorDimension
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            for (int idx = 0; idx < GridDataList.Count; idx++)
            {
                var listElement = GridDataList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the environmental simulation application ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "environmentalSimulationApplicationID")]
        public EntityID EnvironmentalSimulationApplicationID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the unique identifier for each piece of enviornmental data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "fieldNumber")]
        public ushort FieldNumber { get; set; }

        /// <summary>
        /// Gets or sets the sequence number for the total set of PDUS used to transmit the data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pduNumber")]
        public ushort PduNumber { get; set; }

        /// <summary>
        /// Gets or sets the Total number of PDUS used to transmit the data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pduTotal")]
        public ushort PduTotal { get; set; }

        /// <summary>
        /// Gets or sets the coordinate system of the grid
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "coordinateSystem")]
        public ushort CoordinateSystem { get; set; }

        /// <summary>
        /// Gets or sets the number of grid axes for the environmental data
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfGridAxes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfGridAxes")]
        public byte NumberOfGridAxes { get; set; }

        /// <summary>
        /// Gets or sets the are domain grid axes identidal to those of the priveious domain update?
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "constantGrid")]
        public byte ConstantGrid { get; set; }

        /// <summary>
        /// Gets or sets the type of environment
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
        public EntityType EnvironmentType { get; set; } = new EntityType();

        /// <summary>
        /// Gets or sets the orientation of the data grid
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
        public Orientation Orientation { get; set; } = new Orientation();

        /// <summary>
        /// Gets or sets the valid time of the enviormental data sample, 64 bit unsigned int
        /// </summary>
        [XmlElement(Type = typeof(long), ElementName = "sampleTime")]
        public long SampleTime { get; set; }

        /// <summary>
        /// Gets or sets the total number of all data values for all pdus for an environmental sample
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "totalValues")]
        public uint TotalValues { get; set; }

        /// <summary>
        /// Gets or sets the total number of data values at each grid point.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "vectorDimension")]
        public byte VectorDimension { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2 { get; set; }

        /// <summary>
        /// Gets the Grid data ^^^This is wrong
        /// </summary>
        [XmlElement(ElementName = "gridDataListList", Type = typeof(List<GridAxisRecord>))]
        public List<GridAxisRecord> GridDataList { get; } = new();

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
                    EnvironmentalSimulationApplicationID.Marshal(dos);
                    dos.WriteUnsignedShort(FieldNumber);
                    dos.WriteUnsignedShort(PduNumber);
                    dos.WriteUnsignedShort(PduTotal);
                    dos.WriteUnsignedShort(CoordinateSystem);
                    dos.WriteUnsignedByte((byte)GridDataList.Count);
                    dos.WriteUnsignedByte(ConstantGrid);
                    EnvironmentType.Marshal(dos);
                    Orientation.Marshal(dos);
                    dos.WriteLong(SampleTime);
                    dos.WriteUnsignedInt(TotalValues);
                    dos.WriteUnsignedByte(VectorDimension);
                    dos.WriteUnsignedShort(Padding1);
                    dos.WriteUnsignedByte(Padding2);

                    for (int idx = 0; idx < GridDataList.Count; idx++)
                    {
                        var aGridAxisRecord = GridDataList[idx];
                        aGridAxisRecord.Marshal(dos);
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
                    EnvironmentalSimulationApplicationID.Unmarshal(dis);
                    FieldNumber = dis.ReadUnsignedShort();
                    PduNumber = dis.ReadUnsignedShort();
                    PduTotal = dis.ReadUnsignedShort();
                    CoordinateSystem = dis.ReadUnsignedShort();
                    NumberOfGridAxes = dis.ReadUnsignedByte();
                    ConstantGrid = dis.ReadUnsignedByte();
                    EnvironmentType.Unmarshal(dis);
                    Orientation.Unmarshal(dis);
                    SampleTime = dis.ReadLong();
                    TotalValues = dis.ReadUnsignedInt();
                    VectorDimension = dis.ReadUnsignedByte();
                    Padding1 = dis.ReadUnsignedShort();
                    Padding2 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfGridAxes; idx++)
                    {
                        var anX = new GridAxisRecord();
                        anX.Unmarshal(dis);
                        GridDataList.Add(anX);
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
            sb.AppendLine("<GriddedDataPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<environmentalSimulationApplicationID>");
                EnvironmentalSimulationApplicationID.Reflection(sb);
                sb.AppendLine("</environmentalSimulationApplicationID>");
                sb.AppendLine("<fieldNumber type=\"ushort\">" + FieldNumber.ToString(CultureInfo.InvariantCulture) + "</fieldNumber>");
                sb.AppendLine("<pduNumber type=\"ushort\">" + PduNumber.ToString(CultureInfo.InvariantCulture) + "</pduNumber>");
                sb.AppendLine("<pduTotal type=\"ushort\">" + PduTotal.ToString(CultureInfo.InvariantCulture) + "</pduTotal>");
                sb.AppendLine("<coordinateSystem type=\"ushort\">" + CoordinateSystem.ToString(CultureInfo.InvariantCulture) + "</coordinateSystem>");
                sb.AppendLine("<gridDataList type=\"byte\">" + GridDataList.Count.ToString(CultureInfo.InvariantCulture) + "</gridDataList>");
                sb.AppendLine("<constantGrid type=\"byte\">" + ConstantGrid.ToString(CultureInfo.InvariantCulture) + "</constantGrid>");
                sb.AppendLine("<environmentType>");
                EnvironmentType.Reflection(sb);
                sb.AppendLine("</environmentType>");
                sb.AppendLine("<orientation>");
                Orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<sampleTime type=\"long\">" + SampleTime.ToString(CultureInfo.InvariantCulture) + "</sampleTime>");
                sb.AppendLine("<totalValues type=\"uint\">" + TotalValues.ToString(CultureInfo.InvariantCulture) + "</totalValues>");
                sb.AppendLine("<vectorDimension type=\"byte\">" + VectorDimension.ToString(CultureInfo.InvariantCulture) + "</vectorDimension>");
                sb.AppendLine("<padding1 type=\"ushort\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                for (int idx = 0; idx < GridDataList.Count; idx++)
                {
                    sb.AppendLine("<gridDataList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"GridAxisRecord\">");
                    var aGridAxisRecord = GridDataList[idx];
                    aGridAxisRecord.Reflection(sb);
                    sb.AppendLine("</gridDataList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</GriddedDataPdu>");
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
        public override bool Equals(object obj) => this == obj as GriddedDataPdu;

        ///<inheritdoc/>
        public bool Equals(GriddedDataPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!EnvironmentalSimulationApplicationID.Equals(obj.EnvironmentalSimulationApplicationID))
            {
                ivarsEqual = false;
            }

            if (FieldNumber != obj.FieldNumber)
            {
                ivarsEqual = false;
            }

            if (PduNumber != obj.PduNumber)
            {
                ivarsEqual = false;
            }

            if (PduTotal != obj.PduTotal)
            {
                ivarsEqual = false;
            }

            if (CoordinateSystem != obj.CoordinateSystem)
            {
                ivarsEqual = false;
            }

            if (NumberOfGridAxes != obj.NumberOfGridAxes)
            {
                ivarsEqual = false;
            }

            if (ConstantGrid != obj.ConstantGrid)
            {
                ivarsEqual = false;
            }

            if (!EnvironmentType.Equals(obj.EnvironmentType))
            {
                ivarsEqual = false;
            }

            if (!Orientation.Equals(obj.Orientation))
            {
                ivarsEqual = false;
            }

            if (SampleTime != obj.SampleTime)
            {
                ivarsEqual = false;
            }

            if (TotalValues != obj.TotalValues)
            {
                ivarsEqual = false;
            }

            if (VectorDimension != obj.VectorDimension)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (Padding2 != obj.Padding2)
            {
                ivarsEqual = false;
            }

            if (GridDataList.Count != obj.GridDataList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < GridDataList.Count; idx++)
                {
                    if (!GridDataList[idx].Equals(obj.GridDataList[idx]))
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

            result = GenerateHash(result) ^ EnvironmentalSimulationApplicationID.GetHashCode();
            result = GenerateHash(result) ^ FieldNumber.GetHashCode();
            result = GenerateHash(result) ^ PduNumber.GetHashCode();
            result = GenerateHash(result) ^ PduTotal.GetHashCode();
            result = GenerateHash(result) ^ CoordinateSystem.GetHashCode();
            result = GenerateHash(result) ^ NumberOfGridAxes.GetHashCode();
            result = GenerateHash(result) ^ ConstantGrid.GetHashCode();
            result = GenerateHash(result) ^ EnvironmentType.GetHashCode();
            result = GenerateHash(result) ^ Orientation.GetHashCode();
            result = GenerateHash(result) ^ SampleTime.GetHashCode();
            result = GenerateHash(result) ^ TotalValues.GetHashCode();
            result = GenerateHash(result) ^ VectorDimension.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();

            if (GridDataList.Count > 0)
            {
                for (int idx = 0; idx < GridDataList.Count; idx++)
                {
                    result = GenerateHash(result) ^ GridDataList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
