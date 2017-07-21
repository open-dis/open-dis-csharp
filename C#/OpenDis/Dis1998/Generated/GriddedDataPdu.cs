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
    /// Section 5.3.11.2: Information about globat, spatially varying enviornmental effects. This requires manual cleanup; the grid axis        records are variable sized. UNFINISHED
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
        /// environmental simulation application ID
        /// </summary>
        private EntityID _environmentalSimulationApplicationID = new EntityID();

        /// <summary>
        /// unique identifier for each piece of enviornmental data
        /// </summary>
        private ushort _fieldNumber;

        /// <summary>
        /// sequence number for the total set of PDUS used to transmit the data
        /// </summary>
        private ushort _pduNumber;

        /// <summary>
        /// Total number of PDUS used to transmit the data
        /// </summary>
        private ushort _pduTotal;

        /// <summary>
        /// coordinate system of the grid
        /// </summary>
        private ushort _coordinateSystem;

        /// <summary>
        /// number of grid axes for the environmental data
        /// </summary>
        private byte _numberOfGridAxes;

        /// <summary>
        /// are domain grid axes identidal to those of the priveious domain update?
        /// </summary>
        private byte _constantGrid;

        /// <summary>
        /// type of environment
        /// </summary>
        private EntityType _environmentType = new EntityType();

        /// <summary>
        /// orientation of the data grid
        /// </summary>
        private Orientation _orientation = new Orientation();

        /// <summary>
        /// valid time of the enviormental data sample, 64 bit unsigned int
        /// </summary>
        private long _sampleTime;

        /// <summary>
        /// total number of all data values for all pdus for an environmental sample
        /// </summary>
        private uint _totalValues;

        /// <summary>
        /// total number of data values at each grid point.
        /// </summary>
        private byte _vectorDimension;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding1;

        /// <summary>
        /// padding
        /// </summary>
        private byte _padding2;

        /// <summary>
        /// Grid data ^^^This is wrong
        /// </summary>
        private List<GridAxisRecord> _gridDataList = new List<GridAxisRecord>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GriddedDataPdu"/> class.
        /// </summary>
        public GriddedDataPdu()
        {
            PduType = (byte)42;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(GriddedDataPdu left, GriddedDataPdu right)
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
        public static bool operator ==(GriddedDataPdu left, GriddedDataPdu right)
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
            marshalSize += this._environmentalSimulationApplicationID.GetMarshalledSize();  // this._environmentalSimulationApplicationID
            marshalSize += 2;  // this._fieldNumber
            marshalSize += 2;  // this._pduNumber
            marshalSize += 2;  // this._pduTotal
            marshalSize += 2;  // this._coordinateSystem
            marshalSize += 1;  // this._numberOfGridAxes
            marshalSize += 1;  // this._constantGrid
            marshalSize += this._environmentType.GetMarshalledSize();  // this._environmentType
            marshalSize += this._orientation.GetMarshalledSize();  // this._orientation
            marshalSize += 8;  // this._sampleTime
            marshalSize += 4;  // this._totalValues
            marshalSize += 1;  // this._vectorDimension
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            for (int idx = 0; idx < this._gridDataList.Count; idx++)
            {
                GridAxisRecord listElement = (GridAxisRecord)this._gridDataList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the environmental simulation application ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "environmentalSimulationApplicationID")]
        public EntityID EnvironmentalSimulationApplicationID
        {
            get
            {
                return this._environmentalSimulationApplicationID;
            }

            set
            {
                this._environmentalSimulationApplicationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier for each piece of enviornmental data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "fieldNumber")]
        public ushort FieldNumber
        {
            get
            {
                return this._fieldNumber;
            }

            set
            {
                this._fieldNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the sequence number for the total set of PDUS used to transmit the data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pduNumber")]
        public ushort PduNumber
        {
            get
            {
                return this._pduNumber;
            }

            set
            {
                this._pduNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the Total number of PDUS used to transmit the data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pduTotal")]
        public ushort PduTotal
        {
            get
            {
                return this._pduTotal;
            }

            set
            {
                this._pduTotal = value;
            }
        }

        /// <summary>
        /// Gets or sets the coordinate system of the grid
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "coordinateSystem")]
        public ushort CoordinateSystem
        {
            get
            {
                return this._coordinateSystem;
            }

            set
            {
                this._coordinateSystem = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of grid axes for the environmental data
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfGridAxes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfGridAxes")]
        public byte NumberOfGridAxes
        {
            get
            {
                return this._numberOfGridAxes;
            }

            set
            {
                this._numberOfGridAxes = value;
            }
        }

        /// <summary>
        /// Gets or sets the are domain grid axes identidal to those of the priveious domain update?
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "constantGrid")]
        public byte ConstantGrid
        {
            get
            {
                return this._constantGrid;
            }

            set
            {
                this._constantGrid = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of environment
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
        public EntityType EnvironmentType
        {
            get
            {
                return this._environmentType;
            }

            set
            {
                this._environmentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the data grid
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
        public Orientation Orientation
        {
            get
            {
                return this._orientation;
            }

            set
            {
                this._orientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the valid time of the enviormental data sample, 64 bit unsigned int
        /// </summary>
        [XmlElement(Type = typeof(long), ElementName = "sampleTime")]
        public long SampleTime
        {
            get
            {
                return this._sampleTime;
            }

            set
            {
                this._sampleTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the total number of all data values for all pdus for an environmental sample
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "totalValues")]
        public uint TotalValues
        {
            get
            {
                return this._totalValues;
            }

            set
            {
                this._totalValues = value;
            }
        }

        /// <summary>
        /// Gets or sets the total number of data values at each grid point.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "vectorDimension")]
        public byte VectorDimension
        {
            get
            {
                return this._vectorDimension;
            }

            set
            {
                this._vectorDimension = value;
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
        /// Gets the Grid data ^^^This is wrong
        /// </summary>
        [XmlElement(ElementName = "gridDataListList", Type = typeof(List<GridAxisRecord>))]
        public List<GridAxisRecord> GridDataList
        {
            get
            {
                return this._gridDataList;
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
                    this._environmentalSimulationApplicationID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._fieldNumber);
                    dos.WriteUnsignedShort((ushort)this._pduNumber);
                    dos.WriteUnsignedShort((ushort)this._pduTotal);
                    dos.WriteUnsignedShort((ushort)this._coordinateSystem);
                    dos.WriteUnsignedByte((byte)this._gridDataList.Count);
                    dos.WriteUnsignedByte((byte)this._constantGrid);
                    this._environmentType.Marshal(dos);
                    this._orientation.Marshal(dos);
                    dos.WriteLong((long)this._sampleTime);
                    dos.WriteUnsignedInt((uint)this._totalValues);
                    dos.WriteUnsignedByte((byte)this._vectorDimension);
                    dos.WriteUnsignedShort((ushort)this._padding1);
                    dos.WriteUnsignedByte((byte)this._padding2);

                    for (int idx = 0; idx < this._gridDataList.Count; idx++)
                    {
                        GridAxisRecord aGridAxisRecord = (GridAxisRecord)this._gridDataList[idx];
                        aGridAxisRecord.Marshal(dos);
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
                    this._environmentalSimulationApplicationID.Unmarshal(dis);
                    this._fieldNumber = dis.ReadUnsignedShort();
                    this._pduNumber = dis.ReadUnsignedShort();
                    this._pduTotal = dis.ReadUnsignedShort();
                    this._coordinateSystem = dis.ReadUnsignedShort();
                    this._numberOfGridAxes = dis.ReadUnsignedByte();
                    this._constantGrid = dis.ReadUnsignedByte();
                    this._environmentType.Unmarshal(dis);
                    this._orientation.Unmarshal(dis);
                    this._sampleTime = dis.ReadLong();
                    this._totalValues = dis.ReadUnsignedInt();
                    this._vectorDimension = dis.ReadUnsignedByte();
                    this._padding1 = dis.ReadUnsignedShort();
                    this._padding2 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.NumberOfGridAxes; idx++)
                    {
                        GridAxisRecord anX = new GridAxisRecord();
                        anX.Unmarshal(dis);
                        this._gridDataList.Add(anX);
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
            sb.AppendLine("<GriddedDataPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<environmentalSimulationApplicationID>");
                this._environmentalSimulationApplicationID.Reflection(sb);
                sb.AppendLine("</environmentalSimulationApplicationID>");
                sb.AppendLine("<fieldNumber type=\"ushort\">" + this._fieldNumber.ToString(CultureInfo.InvariantCulture) + "</fieldNumber>");
                sb.AppendLine("<pduNumber type=\"ushort\">" + this._pduNumber.ToString(CultureInfo.InvariantCulture) + "</pduNumber>");
                sb.AppendLine("<pduTotal type=\"ushort\">" + this._pduTotal.ToString(CultureInfo.InvariantCulture) + "</pduTotal>");
                sb.AppendLine("<coordinateSystem type=\"ushort\">" + this._coordinateSystem.ToString(CultureInfo.InvariantCulture) + "</coordinateSystem>");
                sb.AppendLine("<gridDataList type=\"byte\">" + this._gridDataList.Count.ToString(CultureInfo.InvariantCulture) + "</gridDataList>");
                sb.AppendLine("<constantGrid type=\"byte\">" + this._constantGrid.ToString(CultureInfo.InvariantCulture) + "</constantGrid>");
                sb.AppendLine("<environmentType>");
                this._environmentType.Reflection(sb);
                sb.AppendLine("</environmentType>");
                sb.AppendLine("<orientation>");
                this._orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<sampleTime type=\"long\">" + this._sampleTime.ToString(CultureInfo.InvariantCulture) + "</sampleTime>");
                sb.AppendLine("<totalValues type=\"uint\">" + this._totalValues.ToString(CultureInfo.InvariantCulture) + "</totalValues>");
                sb.AppendLine("<vectorDimension type=\"byte\">" + this._vectorDimension.ToString(CultureInfo.InvariantCulture) + "</vectorDimension>");
                sb.AppendLine("<padding1 type=\"ushort\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                for (int idx = 0; idx < this._gridDataList.Count; idx++)
                {
                    sb.AppendLine("<gridDataList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"GridAxisRecord\">");
                    GridAxisRecord aGridAxisRecord = (GridAxisRecord)this._gridDataList[idx];
                    aGridAxisRecord.Reflection(sb);
                    sb.AppendLine("</gridDataList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</GriddedDataPdu>");
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
            return this == obj as GriddedDataPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(GriddedDataPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._environmentalSimulationApplicationID.Equals(obj._environmentalSimulationApplicationID))
            {
                ivarsEqual = false;
            }

            if (this._fieldNumber != obj._fieldNumber)
            {
                ivarsEqual = false;
            }

            if (this._pduNumber != obj._pduNumber)
            {
                ivarsEqual = false;
            }

            if (this._pduTotal != obj._pduTotal)
            {
                ivarsEqual = false;
            }

            if (this._coordinateSystem != obj._coordinateSystem)
            {
                ivarsEqual = false;
            }

            if (this._numberOfGridAxes != obj._numberOfGridAxes)
            {
                ivarsEqual = false;
            }

            if (this._constantGrid != obj._constantGrid)
            {
                ivarsEqual = false;
            }

            if (!this._environmentType.Equals(obj._environmentType))
            {
                ivarsEqual = false;
            }

            if (!this._orientation.Equals(obj._orientation))
            {
                ivarsEqual = false;
            }

            if (this._sampleTime != obj._sampleTime)
            {
                ivarsEqual = false;
            }

            if (this._totalValues != obj._totalValues)
            {
                ivarsEqual = false;
            }

            if (this._vectorDimension != obj._vectorDimension)
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

            if (this._gridDataList.Count != obj._gridDataList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._gridDataList.Count; idx++)
                {
                    if (!this._gridDataList[idx].Equals(obj._gridDataList[idx]))
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

            result = GenerateHash(result) ^ this._environmentalSimulationApplicationID.GetHashCode();
            result = GenerateHash(result) ^ this._fieldNumber.GetHashCode();
            result = GenerateHash(result) ^ this._pduNumber.GetHashCode();
            result = GenerateHash(result) ^ this._pduTotal.GetHashCode();
            result = GenerateHash(result) ^ this._coordinateSystem.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfGridAxes.GetHashCode();
            result = GenerateHash(result) ^ this._constantGrid.GetHashCode();
            result = GenerateHash(result) ^ this._environmentType.GetHashCode();
            result = GenerateHash(result) ^ this._orientation.GetHashCode();
            result = GenerateHash(result) ^ this._sampleTime.GetHashCode();
            result = GenerateHash(result) ^ this._totalValues.GetHashCode();
            result = GenerateHash(result) ^ this._vectorDimension.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();

            if (this._gridDataList.Count > 0)
            {
                for (int idx = 0; idx < this._gridDataList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._gridDataList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
