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
        /// Initializes a new instance of the <see cref="MinefieldStatePdu"/> class.
        /// </summary>
        public MinefieldStatePdu()
        {
            PduType = 37;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(MinefieldStatePdu left, MinefieldStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(MinefieldStatePdu left, MinefieldStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MinefieldID.GetMarshalledSize();  // this._minefieldID
            marshalSize += 2;  // this._minefieldSequence
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._numberOfPerimeterPoints
            marshalSize += MinefieldType.GetMarshalledSize();  // this._minefieldType
            marshalSize += 2;  // this._numberOfMineTypes
            marshalSize += MinefieldLocation.GetMarshalledSize();  // this._minefieldLocation
            marshalSize += MinefieldOrientation.GetMarshalledSize();  // this._minefieldOrientation
            marshalSize += 2;  // this._appearance
            marshalSize += 2;  // this._protocolMode
            for (int idx = 0; idx < PerimeterPoints.Count; idx++)
            {
                var listElement = PerimeterPoints[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < MineType.Count; idx++)
            {
                var listElement = MineType[idx];
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
        /// Gets or sets the Minefield sequence
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "minefieldSequence")]
        public ushort MinefieldSequence { get; set; }

        /// <summary>
        /// Gets or sets the force ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceID")]
        public byte ForceID { get; set; }

        /// <summary>
        /// Gets or sets the Number of permieter points
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
        /// Gets or sets the type of minefield
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "minefieldType")]
        public EntityType MinefieldType { get; set; } = new EntityType();

        /// <summary>
        /// Gets or sets the how many mine types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfMineTypes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfMineTypes")]
        public ushort NumberOfMineTypes { get; set; }

        /// <summary>
        /// Gets or sets the location of minefield in world coords
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "minefieldLocation")]
        public Vector3Double MinefieldLocation { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the orientation of minefield
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "minefieldOrientation")]
        public Orientation MinefieldOrientation { get; set; } = new Orientation();

        /// <summary>
        /// Gets or sets the appearance bitflags
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "appearance")]
        public ushort Appearance { get; set; }

        /// <summary>
        /// Gets or sets the protocolMode
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "protocolMode")]
        public ushort ProtocolMode { get; set; }

        /// <summary>
        /// Gets the perimeter points for the minefield
        /// </summary>
        [XmlElement(ElementName = "perimeterPointsList", Type = typeof(List<Point>))]
        public List<Point> PerimeterPoints { get; } = new();

        /// <summary>
        /// Gets the Type of mines
        /// </summary>
        [XmlElement(ElementName = "mineTypeList", Type = typeof(List<EntityType>))]
        public List<EntityType> MineType { get; } = new();

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
                    dos.WriteUnsignedShort(MinefieldSequence);
                    dos.WriteUnsignedByte(ForceID);
                    dos.WriteUnsignedByte((byte)PerimeterPoints.Count);
                    MinefieldType.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)MineType.Count);
                    MinefieldLocation.Marshal(dos);
                    MinefieldOrientation.Marshal(dos);
                    dos.WriteUnsignedShort(Appearance);
                    dos.WriteUnsignedShort(ProtocolMode);

                    for (int idx = 0; idx < PerimeterPoints.Count; idx++)
                    {
                        var aPoint = PerimeterPoints[idx];
                        aPoint.Marshal(dos);
                    }

                    for (int idx = 0; idx < MineType.Count; idx++)
                    {
                        var aEntityType = MineType[idx];
                        aEntityType.Marshal(dos);
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
                    MinefieldSequence = dis.ReadUnsignedShort();
                    ForceID = dis.ReadUnsignedByte();
                    NumberOfPerimeterPoints = dis.ReadUnsignedByte();
                    MinefieldType.Unmarshal(dis);
                    NumberOfMineTypes = dis.ReadUnsignedShort();
                    MinefieldLocation.Unmarshal(dis);
                    MinefieldOrientation.Unmarshal(dis);
                    Appearance = dis.ReadUnsignedShort();
                    ProtocolMode = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < NumberOfPerimeterPoints; idx++)
                    {
                        var anX = new Point();
                        anX.Unmarshal(dis);
                        PerimeterPoints.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfMineTypes; idx++)
                    {
                        var anX = new EntityType();
                        anX.Unmarshal(dis);
                        MineType.Add(anX);
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
            sb.AppendLine("<MinefieldStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<minefieldID>");
                MinefieldID.Reflection(sb);
                sb.AppendLine("</minefieldID>");
                sb.AppendLine("<minefieldSequence type=\"ushort\">" + MinefieldSequence.ToString(CultureInfo.InvariantCulture) + "</minefieldSequence>");
                sb.AppendLine("<forceID type=\"byte\">" + ForceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<perimeterPoints type=\"byte\">" + PerimeterPoints.Count.ToString(CultureInfo.InvariantCulture) + "</perimeterPoints>");
                sb.AppendLine("<minefieldType>");
                MinefieldType.Reflection(sb);
                sb.AppendLine("</minefieldType>");
                sb.AppendLine("<mineType type=\"ushort\">" + MineType.Count.ToString(CultureInfo.InvariantCulture) + "</mineType>");
                sb.AppendLine("<minefieldLocation>");
                MinefieldLocation.Reflection(sb);
                sb.AppendLine("</minefieldLocation>");
                sb.AppendLine("<minefieldOrientation>");
                MinefieldOrientation.Reflection(sb);
                sb.AppendLine("</minefieldOrientation>");
                sb.AppendLine("<appearance type=\"ushort\">" + Appearance.ToString(CultureInfo.InvariantCulture) + "</appearance>");
                sb.AppendLine("<protocolMode type=\"ushort\">" + ProtocolMode.ToString(CultureInfo.InvariantCulture) + "</protocolMode>");
                for (int idx = 0; idx < PerimeterPoints.Count; idx++)
                {
                    sb.AppendLine("<perimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
                    var aPoint = PerimeterPoints[idx];
                    aPoint.Reflection(sb);
                    sb.AppendLine("</perimeterPoints" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < MineType.Count; idx++)
                {
                    sb.AppendLine("<mineType" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    var aEntityType = MineType[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</mineType" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</MinefieldStatePdu>");
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
        public override bool Equals(object obj) => this == obj as MinefieldStatePdu;

        ///<inheritdoc/>
        public bool Equals(MinefieldStatePdu obj)
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

            if (MinefieldSequence != obj.MinefieldSequence)
            {
                ivarsEqual = false;
            }

            if (ForceID != obj.ForceID)
            {
                ivarsEqual = false;
            }

            if (NumberOfPerimeterPoints != obj.NumberOfPerimeterPoints)
            {
                ivarsEqual = false;
            }

            if (!MinefieldType.Equals(obj.MinefieldType))
            {
                ivarsEqual = false;
            }

            if (NumberOfMineTypes != obj.NumberOfMineTypes)
            {
                ivarsEqual = false;
            }

            if (!MinefieldLocation.Equals(obj.MinefieldLocation))
            {
                ivarsEqual = false;
            }

            if (!MinefieldOrientation.Equals(obj.MinefieldOrientation))
            {
                ivarsEqual = false;
            }

            if (Appearance != obj.Appearance)
            {
                ivarsEqual = false;
            }

            if (ProtocolMode != obj.ProtocolMode)
            {
                ivarsEqual = false;
            }

            if (PerimeterPoints.Count != obj.PerimeterPoints.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < PerimeterPoints.Count; idx++)
                {
                    if (!PerimeterPoints[idx].Equals(obj.PerimeterPoints[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (MineType.Count != obj.MineType.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < MineType.Count; idx++)
                {
                    if (!MineType[idx].Equals(obj.MineType[idx]))
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
            result = GenerateHash(result) ^ MinefieldSequence.GetHashCode();
            result = GenerateHash(result) ^ ForceID.GetHashCode();
            result = GenerateHash(result) ^ NumberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ MinefieldType.GetHashCode();
            result = GenerateHash(result) ^ NumberOfMineTypes.GetHashCode();
            result = GenerateHash(result) ^ MinefieldLocation.GetHashCode();
            result = GenerateHash(result) ^ MinefieldOrientation.GetHashCode();
            result = GenerateHash(result) ^ Appearance.GetHashCode();
            result = GenerateHash(result) ^ ProtocolMode.GetHashCode();

            if (PerimeterPoints.Count > 0)
            {
                for (int idx = 0; idx < PerimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ PerimeterPoints[idx].GetHashCode();
                }
            }

            if (MineType.Count > 0)
            {
                for (int idx = 0; idx < MineType.Count; idx++)
                {
                    result = GenerateHash(result) ^ MineType[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
