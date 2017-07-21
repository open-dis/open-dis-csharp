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
    /// Section 5.3.10.1 Abstract superclass for PDUs relating to minefields. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(EntityType))]
    public partial class MinefieldStatePdu : MinefieldFamilyPdu, IEquatable<MinefieldStatePdu>
    {
        /// <summary>
        /// Minefield ID
        /// </summary>
        private EntityID _minefieldID = new EntityID();

        /// <summary>
        /// Minefield sequence
        /// </summary>
        private ushort _minefieldSequence;

        /// <summary>
        /// force ID
        /// </summary>
        private byte _forceID;

        /// <summary>
        /// Number of permieter points
        /// </summary>
        private byte _numberOfPerimeterPoints;

        /// <summary>
        /// type of minefield
        /// </summary>
        private EntityType _minefieldType = new EntityType();

        /// <summary>
        /// how many mine types
        /// </summary>
        private ushort _numberOfMineTypes;

        /// <summary>
        /// location of minefield in world coords
        /// </summary>
        private Vector3Double _minefieldLocation = new Vector3Double();

        /// <summary>
        /// orientation of minefield
        /// </summary>
        private Orientation _minefieldOrientation = new Orientation();

        /// <summary>
        /// appearance bitflags
        /// </summary>
        private ushort _appearance;

        /// <summary>
        /// protocolMode
        /// </summary>
        private ushort _protocolMode;

        /// <summary>
        /// perimeter points for the minefield
        /// </summary>
        private List<Point> _perimeterPoints = new List<Point>();

        /// <summary>
        /// Type of mines
        /// </summary>
        private List<EntityType> _mineType = new List<EntityType>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldStatePdu"/> class.
        /// </summary>
        public MinefieldStatePdu()
        {
            PduType = (byte)37;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldStatePdu left, MinefieldStatePdu right)
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
        public static bool operator ==(MinefieldStatePdu left, MinefieldStatePdu right)
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
            marshalSize += 2;  // this._minefieldSequence
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._numberOfPerimeterPoints
            marshalSize += this._minefieldType.GetMarshalledSize();  // this._minefieldType
            marshalSize += 2;  // this._numberOfMineTypes
            marshalSize += this._minefieldLocation.GetMarshalledSize();  // this._minefieldLocation
            marshalSize += this._minefieldOrientation.GetMarshalledSize();  // this._minefieldOrientation
            marshalSize += 2;  // this._appearance
            marshalSize += 2;  // this._protocolMode
            for (int idx = 0; idx < this._perimeterPoints.Count; idx++)
            {
                Point listElement = (Point)this._perimeterPoints[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._mineType.Count; idx++)
            {
                EntityType listElement = (EntityType)this._mineType[idx];
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
        /// Gets or sets the Minefield sequence
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "minefieldSequence")]
        public ushort MinefieldSequence
        {
            get
            {
                return this._minefieldSequence;
            }

            set
            {
                this._minefieldSequence = value;
            }
        }

        /// <summary>
        /// Gets or sets the force ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceID")]
        public byte ForceID
        {
            get
            {
                return this._forceID;
            }

            set
            {
                this._forceID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of permieter points
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
        /// Gets or sets the type of minefield
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "minefieldType")]
        public EntityType MinefieldType
        {
            get
            {
                return this._minefieldType;
            }

            set
            {
                this._minefieldType = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many mine types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMineTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfMineTypes")]
        public ushort NumberOfMineTypes
        {
            get
            {
                return this._numberOfMineTypes;
            }

            set
            {
                this._numberOfMineTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the location of minefield in world coords
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "minefieldLocation")]
        public Vector3Double MinefieldLocation
        {
            get
            {
                return this._minefieldLocation;
            }

            set
            {
                this._minefieldLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of minefield
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "minefieldOrientation")]
        public Orientation MinefieldOrientation
        {
            get
            {
                return this._minefieldOrientation;
            }

            set
            {
                this._minefieldOrientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the appearance bitflags
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "appearance")]
        public ushort Appearance
        {
            get
            {
                return this._appearance;
            }

            set
            {
                this._appearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the protocolMode
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "protocolMode")]
        public ushort ProtocolMode
        {
            get
            {
                return this._protocolMode;
            }

            set
            {
                this._protocolMode = value;
            }
        }

        /// <summary>
        /// Gets the perimeter points for the minefield
        /// </summary>
        [XmlElement(ElementName = "perimeterPointsList", Type = typeof(List<Point>))]
        public List<Point> PerimeterPoints
        {
            get
            {
                return this._perimeterPoints;
            }
        }

        /// <summary>
        /// Gets the Type of mines
        /// </summary>
        [XmlElement(ElementName = "mineTypeList", Type = typeof(List<EntityType>))]
        public List<EntityType> MineType
        {
            get
            {
                return this._mineType;
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
                    dos.WriteUnsignedShort((ushort)this._minefieldSequence);
                    dos.WriteUnsignedByte((byte)this._forceID);
                    dos.WriteUnsignedByte((byte)this._perimeterPoints.Count);
                    this._minefieldType.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._mineType.Count);
                    this._minefieldLocation.Marshal(dos);
                    this._minefieldOrientation.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._appearance);
                    dos.WriteUnsignedShort((ushort)this._protocolMode);

                    for (int idx = 0; idx < this._perimeterPoints.Count; idx++)
                    {
                        Point aPoint = (Point)this._perimeterPoints[idx];
                        aPoint.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._mineType.Count; idx++)
                    {
                        EntityType aEntityType = (EntityType)this._mineType[idx];
                        aEntityType.Marshal(dos);
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
                    this._minefieldSequence = dis.ReadUnsignedShort();
                    this._forceID = dis.ReadUnsignedByte();
                    this._numberOfPerimeterPoints = dis.ReadUnsignedByte();
                    this._minefieldType.Unmarshal(dis);
                    this._numberOfMineTypes = dis.ReadUnsignedShort();
                    this._minefieldLocation.Unmarshal(dis);
                    this._minefieldOrientation.Unmarshal(dis);
                    this._appearance = dis.ReadUnsignedShort();
                    this._protocolMode = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfPerimeterPoints; idx++)
                    {
                        Point anX = new Point();
                        anX.Unmarshal(dis);
                        this._perimeterPoints.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfMineTypes; idx++)
                    {
                        EntityType anX = new EntityType();
                        anX.Unmarshal(dis);
                        this._mineType.Add(anX);
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
            sb.AppendLine("<MinefieldStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                this._minefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<minefieldSequence type=\"ushort\">" + this._minefieldSequence.ToString(CultureInfo.InvariantCulture) + "</minefieldSequence>");
                sb.AppendLine("<forceID type=\"byte\">" + this._forceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<perimeterPoints type=\"byte\">" + this._perimeterPoints.Count.ToString(CultureInfo.InvariantCulture) + "</perimeterPoints>");
                sb.AppendLine("<minefieldType>");
                this._minefieldType.Reflection(sb);
                sb.AppendLine("</minefieldType>");
                sb.AppendLine("<mineType type=\"ushort\">" + this._mineType.Count.ToString(CultureInfo.InvariantCulture) + "</mineType>");
                sb.AppendLine("<minefieldLocation>");
                this._minefieldLocation.Reflection(sb);
                sb.AppendLine("</minefieldLocation>");
                sb.AppendLine("<minefieldOrientation>");
                this._minefieldOrientation.Reflection(sb);
                sb.AppendLine("</minefieldOrientation>");
                sb.AppendLine("<appearance type=\"ushort\">" + this._appearance.ToString(CultureInfo.InvariantCulture) + "</appearance>");
                sb.AppendLine("<protocolMode type=\"ushort\">" + this._protocolMode.ToString(CultureInfo.InvariantCulture) + "</protocolMode>");
                for (int idx = 0; idx < this._perimeterPoints.Count; idx++)
                {
                    sb.AppendLine("<perimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
                    Point aPoint = (Point)this._perimeterPoints[idx];
                    aPoint.Reflection(sb);
                    sb.AppendLine("</perimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._mineType.Count; idx++)
                {
                    sb.AppendLine("<mineType" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    EntityType aEntityType = (EntityType)this._mineType[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</mineType" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldStatePdu>");
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
            return this == obj as MinefieldStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(MinefieldStatePdu obj)
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

            if (this._minefieldSequence != obj._minefieldSequence)
            {
                ivarsEqual = false;
            }

            if (this._forceID != obj._forceID)
            {
                ivarsEqual = false;
            }

            if (this._numberOfPerimeterPoints != obj._numberOfPerimeterPoints)
            {
                ivarsEqual = false;
            }

            if (!this._minefieldType.Equals(obj._minefieldType))
            {
                ivarsEqual = false;
            }

            if (this._numberOfMineTypes != obj._numberOfMineTypes)
            {
                ivarsEqual = false;
            }

            if (!this._minefieldLocation.Equals(obj._minefieldLocation))
            {
                ivarsEqual = false;
            }

            if (!this._minefieldOrientation.Equals(obj._minefieldOrientation))
            {
                ivarsEqual = false;
            }

            if (this._appearance != obj._appearance)
            {
                ivarsEqual = false;
            }

            if (this._protocolMode != obj._protocolMode)
            {
                ivarsEqual = false;
            }

            if (this._perimeterPoints.Count != obj._perimeterPoints.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._perimeterPoints.Count; idx++)
                {
                    if (!this._perimeterPoints[idx].Equals(obj._perimeterPoints[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._mineType.Count != obj._mineType.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._mineType.Count; idx++)
                {
                    if (!this._mineType[idx].Equals(obj._mineType[idx]))
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
            result = GenerateHash(result) ^ this._minefieldSequence.GetHashCode();
            result = GenerateHash(result) ^ this._forceID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ this._minefieldType.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfMineTypes.GetHashCode();
            result = GenerateHash(result) ^ this._minefieldLocation.GetHashCode();
            result = GenerateHash(result) ^ this._minefieldOrientation.GetHashCode();
            result = GenerateHash(result) ^ this._appearance.GetHashCode();
            result = GenerateHash(result) ^ this._protocolMode.GetHashCode();

            if (this._perimeterPoints.Count > 0)
            {
                for (int idx = 0; idx < this._perimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._perimeterPoints[idx].GetHashCode();
                }
            }

            if (this._mineType.Count > 0)
            {
                for (int idx = 0; idx < this._mineType.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._mineType[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
