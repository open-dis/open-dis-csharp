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
    /// Section 5.3.10.2 Query a minefield for information about individual mines. Requires manual clean up to get the padding right. UNFINISHED
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
        /// Minefield ID
        /// </summary>
        private EntityID _minefieldID = new EntityID();

        /// <summary>
        /// EID of entity making the request
        /// </summary>
        private EntityID _requestingEntityID = new EntityID();

        /// <summary>
        /// request ID
        /// </summary>
        private byte _requestID;

        /// <summary>
        /// Number of perimeter points for the minefield
        /// </summary>
        private byte _numberOfPerimeterPoints;

        /// <summary>
        /// Padding
        /// </summary>
        private byte _pad2;

        /// <summary>
        /// Number of sensor types
        /// </summary>
        private byte _numberOfSensorTypes;

        /// <summary>
        /// data filter, 32 boolean fields
        /// </summary>
        private uint _dataFilter;

        /// <summary>
        /// Entity type of mine being requested
        /// </summary>
        private EntityType _requestedMineType = new EntityType();

        /// <summary>
        /// perimeter points of request
        /// </summary>
        private List<Point> _requestedPerimeterPoints = new List<Point>();

        /// <summary>
        /// Sensor types, each 16 bits long
        /// </summary>
        private List<TwoByteChunk> _sensorTypes = new List<TwoByteChunk>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldQueryPdu"/> class.
        /// </summary>
        public MinefieldQueryPdu()
        {
            PduType = (byte)38;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldQueryPdu left, MinefieldQueryPdu right)
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
        public static bool operator ==(MinefieldQueryPdu left, MinefieldQueryPdu right)
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
            marshalSize += this._minefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += this._requestingEntityID.GetMarshalledSize();  // this._requestingEntityID
            marshalSize += 1;  // this._requestID
            marshalSize += 1;  // this._numberOfPerimeterPoints
            marshalSize += 1;  // this._pad2
            marshalSize += 1;  // this._numberOfSensorTypes
            marshalSize += 4;  // this._dataFilter
            marshalSize += this._requestedMineType.GetMarshalledSize();  // this._requestedMineType
            for (int idx = 0; idx < this._requestedPerimeterPoints.Count; idx++)
            {
                Point listElement = (Point)this._requestedPerimeterPoints[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._sensorTypes.Count; idx++)
            {
                TwoByteChunk listElement = (TwoByteChunk)this._sensorTypes[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Minefield ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
        public EntityID MinefieldID
        {
            get
            {
                return this._minefieldID;
            }

            set
            {
                this._minefieldID = value;
            }
        }

        /// <summary>
        /// Gets or sets the EID of entity making the request
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
        public EntityID RequestingEntityID
        {
            get
            {
                return this._requestingEntityID;
            }

            set
            {
                this._requestingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the request ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "requestID")]
        public byte RequestID
        {
            get
            {
                return this._requestID;
            }

            set
            {
                this._requestID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of perimeter points for the minefield
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPerimeterPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfPerimeterPoints")]
        public byte NumberOfPerimeterPoints
        {
            get
            {
                return this._numberOfPerimeterPoints;
            }

            set
            {
                this._numberOfPerimeterPoints = value;
            }
        }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2
        {
            get
            {
                return this._pad2;
            }

            set
            {
                this._pad2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of sensor types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSensorTypes")]
        public byte NumberOfSensorTypes
        {
            get
            {
                return this._numberOfSensorTypes;
            }

            set
            {
                this._numberOfSensorTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the data filter, 32 boolean fields
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "dataFilter")]
        public uint DataFilter
        {
            get
            {
                return this._dataFilter;
            }

            set
            {
                this._dataFilter = value;
            }
        }

        /// <summary>
        /// Gets or sets the Entity type of mine being requested
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "requestedMineType")]
        public EntityType RequestedMineType
        {
            get
            {
                return this._requestedMineType;
            }

            set
            {
                this._requestedMineType = value;
            }
        }

        /// <summary>
        /// Gets the perimeter points of request
        /// </summary>
        [XmlElement(ElementName = "requestedPerimeterPointsList", Type = typeof(List<Point>))]
        public List<Point> RequestedPerimeterPoints
        {
            get
            {
                return this._requestedPerimeterPoints;
            }
        }

        /// <summary>
        /// Gets the Sensor types, each 16 bits long
        /// </summary>
        [XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> SensorTypes
        {
            get
            {
                return this._sensorTypes;
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
                    this._minefieldID.Marshal(dos);
                    this._requestingEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._requestID);
                    dos.WriteUnsignedByte((byte)this._requestedPerimeterPoints.Count);
                    dos.WriteUnsignedByte((byte)this._pad2);
                    dos.WriteUnsignedByte((byte)this._sensorTypes.Count);
                    dos.WriteUnsignedInt((uint)this._dataFilter);
                    this._requestedMineType.Marshal(dos);

                    for (int idx = 0; idx < this._requestedPerimeterPoints.Count; idx++)
                    {
                        Point aPoint = (Point)this._requestedPerimeterPoints[idx];
                        aPoint.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._sensorTypes.Count; idx++)
                    {
                        TwoByteChunk aTwoByteChunk = (TwoByteChunk)this._sensorTypes[idx];
                        aTwoByteChunk.Marshal(dos);
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
                    this._minefieldID.Unmarshal(dis);
                    this._requestingEntityID.Unmarshal(dis);
                    this._requestID = dis.ReadUnsignedByte();
                    this._numberOfPerimeterPoints = dis.ReadUnsignedByte();
                    this._pad2 = dis.ReadUnsignedByte();
                    this._numberOfSensorTypes = dis.ReadUnsignedByte();
                    this._dataFilter = dis.ReadUnsignedInt();
                    this._requestedMineType.Unmarshal(dis);

                    for (int idx = 0; idx < this.NumberOfPerimeterPoints; idx++)
                    {
                        Point anX = new Point();
                        anX.Unmarshal(dis);
                        this._requestedPerimeterPoints.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfSensorTypes; idx++)
                    {
                        TwoByteChunk anX = new TwoByteChunk();
                        anX.Unmarshal(dis);
                        this._sensorTypes.Add(anX);
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
            sb.AppendLine("<MinefieldQueryPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                this._minefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<requestingEntityID>");
                this._requestingEntityID.Reflection(sb);
                sb.AppendLine("</requestingEntityID>");
                sb.AppendLine("<requestID type=\"byte\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<requestedPerimeterPoints type=\"byte\">" + this._requestedPerimeterPoints.Count.ToString(CultureInfo.InvariantCulture) + "</requestedPerimeterPoints>");
                sb.AppendLine("<pad2 type=\"byte\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<sensorTypes type=\"byte\">" + this._sensorTypes.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
                sb.AppendLine("<dataFilter type=\"uint\">" + this._dataFilter.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
                sb.AppendLine("<requestedMineType>");
                this._requestedMineType.Reflection(sb);
                sb.AppendLine("</requestedMineType>");
                for (int idx = 0; idx < this._requestedPerimeterPoints.Count; idx++)
                {
                    sb.AppendLine("<requestedPerimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
                    Point aPoint = (Point)this._requestedPerimeterPoints[idx];
                    aPoint.Reflection(sb);
                    sb.AppendLine("</requestedPerimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._sensorTypes.Count; idx++)
                {
                    sb.AppendLine("<sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
                    TwoByteChunk aTwoByteChunk = (TwoByteChunk)this._sensorTypes[idx];
                    aTwoByteChunk.Reflection(sb);
                    sb.AppendLine("</sensorTypes" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldQueryPdu>");
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
            return this == obj as MinefieldQueryPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MinefieldQueryPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._minefieldID.Equals(obj._minefieldID))
            {
                ivarsEqual = false;
            }

            if (!this._requestingEntityID.Equals(obj._requestingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._requestID != obj._requestID)
            {
                ivarsEqual = false;
            }

            if (this._numberOfPerimeterPoints != obj._numberOfPerimeterPoints)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (this._numberOfSensorTypes != obj._numberOfSensorTypes)
            {
                ivarsEqual = false;
            }

            if (this._dataFilter != obj._dataFilter)
            {
                ivarsEqual = false;
            }

            if (!this._requestedMineType.Equals(obj._requestedMineType))
            {
                ivarsEqual = false;
            }

            if (this._requestedPerimeterPoints.Count != obj._requestedPerimeterPoints.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._requestedPerimeterPoints.Count; idx++)
                {
                    if (!this._requestedPerimeterPoints[idx].Equals(obj._requestedPerimeterPoints[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._sensorTypes.Count != obj._sensorTypes.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._sensorTypes.Count; idx++)
                {
                    if (!this._sensorTypes[idx].Equals(obj._sensorTypes[idx]))
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

            result = GenerateHash(result) ^ this._minefieldID.GetHashCode();
            result = GenerateHash(result) ^ this._requestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSensorTypes.GetHashCode();
            result = GenerateHash(result) ^ this._dataFilter.GetHashCode();
            result = GenerateHash(result) ^ this._requestedMineType.GetHashCode();

            if (this._requestedPerimeterPoints.Count > 0)
            {
                for (int idx = 0; idx < this._requestedPerimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._requestedPerimeterPoints[idx].GetHashCode();
                }
            }

            if (this._sensorTypes.Count > 0)
            {
                for (int idx = 0; idx < this._sensorTypes.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._sensorTypes[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
