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
    /// Section 5.3.9.1 informationa bout aggregating entities anc communicating information about the aggregated entities.
    ///       requires manual intervention to fix the padding between entityID lists and silent aggregate sysem lists--this padding        is dependent on how many entityIDs there are, and needs to be on a 32 bit word boundary. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(AggregateMarking))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(AggregateID))]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class AggregateStatePdu : EntityManagementFamilyPdu, IEquatable<AggregateStatePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateStatePdu"/> class.
        /// </summary>
        public AggregateStatePdu()
        {
            PduType = 33;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AggregateStatePdu left, AggregateStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AggregateStatePdu left, AggregateStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += AggregateID.GetMarshalledSize();  // this._aggregateID
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._aggregateState
            marshalSize += AggregateType.GetMarshalledSize();  // this._aggregateType
            marshalSize += 4;  // this._formation
            marshalSize += AggregateMarking.GetMarshalledSize();  // this._aggregateMarking
            marshalSize += Dimensions.GetMarshalledSize();  // this._dimensions
            marshalSize += Orientation.GetMarshalledSize();  // this._orientation
            marshalSize += CenterOfMass.GetMarshalledSize();  // this._centerOfMass
            marshalSize += Velocity.GetMarshalledSize();  // this._velocity
            marshalSize += 2;  // this._numberOfDisAggregates
            marshalSize += 2;  // this._numberOfDisEntities
            marshalSize += 2;  // this._numberOfSilentAggregateTypes
            marshalSize += 2;  // this._numberOfSilentEntityTypes
            for (int idx = 0; idx < AggregateIDList.Count; idx++)
            {
                var listElement = AggregateIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < EntityIDList.Count; idx++)
            {
                var listElement = EntityIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            marshalSize += 1;  // this._pad2
            for (int idx = 0; idx < SilentAggregateSystemList.Count; idx++)
            {
                var listElement = SilentAggregateSystemList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < SilentEntitySystemList.Count; idx++)
            {
                var listElement = SilentEntitySystemList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            marshalSize += 4;  // this._numberOfVariableDatumRecords
            for (int idx = 0; idx < VariableDatumList.Count; idx++)
            {
                var listElement = VariableDatumList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "aggregateID")]
        public EntityID AggregateID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the force ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceID")]
        public byte ForceID { get; set; }

        /// <summary>
        /// Gets or sets the state of aggregate
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "aggregateState")]
        public byte AggregateState { get; set; }

        /// <summary>
        /// Gets or sets the entity type of the aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "aggregateType")]
        public EntityType AggregateType { get; set; } = new EntityType();

        /// <summary>
        /// Gets or sets the formation of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "formation")]
        public uint Formation { get; set; }

        /// <summary>
        /// Gets or sets the marking for aggregate; first char is charset type, rest is char data
        /// </summary>
        [XmlElement(Type = typeof(AggregateMarking), ElementName = "aggregateMarking")]
        public AggregateMarking AggregateMarking { get; set; } = new AggregateMarking();

        /// <summary>
        /// Gets or sets the dimensions of bounding box for the aggregated entities, origin at the center of mass
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "dimensions")]
        public Vector3Float Dimensions { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the orientation of the bounding box
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
        public Orientation Orientation { get; set; } = new Orientation();

        /// <summary>
        /// Gets or sets the center of mass of the aggregation
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "centerOfMass")]
        public Vector3Double CenterOfMass { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the velocity of aggregation
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the number of aggregates
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfDisAggregates method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfDisAggregates")]
        public ushort NumberOfDisAggregates { get; set; }

        /// <summary>
        /// Gets or sets the number of entities
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfDisEntities method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfDisEntities")]
        public ushort NumberOfDisEntities { get; set; }

        /// <summary>
        /// Gets or sets the number of silent aggregate types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfSilentAggregateTypes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentAggregateTypes")]
        public ushort NumberOfSilentAggregateTypes { get; set; }

        /// <summary>
        /// Gets or sets the number of silent entity types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfSilentEntityTypes method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentEntityTypes")]
        public ushort NumberOfSilentEntityTypes { get; set; }

        /// <summary>
        /// Gets the aggregates list
        /// </summary>
        [XmlElement(ElementName = "aggregateIDListList", Type = typeof(List<AggregateID>))]
        public List<AggregateID> AggregateIDList { get; } = new();

        /// <summary>
        /// Gets the entity ID list
        /// </summary>
        [XmlElement(ElementName = "entityIDListList", Type = typeof(List<EntityID>))]
        public List<EntityID> EntityIDList { get; } = new();

        /// <summary>
        /// Gets or sets the ^^^padding to put the start of the next list on a 32 bit boundary. This needs to be fixed
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad2")]
        public byte Pad2 { get; set; }

        /// <summary>
        /// Gets the silent entity types
        /// </summary>
        [XmlElement(ElementName = "silentAggregateSystemListList", Type = typeof(List<EntityType>))]
        public List<EntityType> SilentAggregateSystemList { get; } = new();

        /// <summary>
        /// Gets the silent entity types
        /// </summary>
        [XmlElement(ElementName = "silentEntitySystemListList", Type = typeof(List<EntityType>))]
        public List<EntityType> SilentEntitySystemList { get; } = new();

        /// <summary>
        /// Gets or sets the number of variable datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
        public uint NumberOfVariableDatumRecords { get; set; }

        /// <summary>
        /// Gets the variableDatums
        /// </summary>
        [XmlElement(ElementName = "variableDatumListList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatumList { get; } = new();

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
                    AggregateID.Marshal(dos);
                    dos.WriteUnsignedByte(ForceID);
                    dos.WriteUnsignedByte(AggregateState);
                    AggregateType.Marshal(dos);
                    dos.WriteUnsignedInt(Formation);
                    AggregateMarking.Marshal(dos);
                    Dimensions.Marshal(dos);
                    Orientation.Marshal(dos);
                    CenterOfMass.Marshal(dos);
                    Velocity.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)AggregateIDList.Count);
                    dos.WriteUnsignedShort((ushort)EntityIDList.Count);
                    dos.WriteUnsignedShort((ushort)SilentAggregateSystemList.Count);
                    dos.WriteUnsignedShort((ushort)SilentEntitySystemList.Count);

                    for (int idx = 0; idx < AggregateIDList.Count; idx++)
                    {
                        var aAggregateID = AggregateIDList[idx];
                        aAggregateID.Marshal(dos);
                    }

                    for (int idx = 0; idx < EntityIDList.Count; idx++)
                    {
                        var aEntityID = EntityIDList[idx];
                        aEntityID.Marshal(dos);
                    }

                    dos.WriteUnsignedByte(Pad2);

                    for (int idx = 0; idx < SilentAggregateSystemList.Count; idx++)
                    {
                        var aEntityType = SilentAggregateSystemList[idx];
                        aEntityType.Marshal(dos);
                    }

                    for (int idx = 0; idx < SilentEntitySystemList.Count; idx++)
                    {
                        var aEntityType = SilentEntitySystemList[idx];
                        aEntityType.Marshal(dos);
                    }

                    dos.WriteUnsignedInt((uint)VariableDatumList.Count);

                    for (int idx = 0; idx < VariableDatumList.Count; idx++)
                    {
                        var aVariableDatum = VariableDatumList[idx];
                        aVariableDatum.Marshal(dos);
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
                    AggregateID.Unmarshal(dis);
                    ForceID = dis.ReadUnsignedByte();
                    AggregateState = dis.ReadUnsignedByte();
                    AggregateType.Unmarshal(dis);
                    Formation = dis.ReadUnsignedInt();
                    AggregateMarking.Unmarshal(dis);
                    Dimensions.Unmarshal(dis);
                    Orientation.Unmarshal(dis);
                    CenterOfMass.Unmarshal(dis);
                    Velocity.Unmarshal(dis);
                    NumberOfDisAggregates = dis.ReadUnsignedShort();
                    NumberOfDisEntities = dis.ReadUnsignedShort();
                    NumberOfSilentAggregateTypes = dis.ReadUnsignedShort();
                    NumberOfSilentEntityTypes = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < NumberOfDisAggregates; idx++)
                    {
                        var anX = new AggregateID();
                        anX.Unmarshal(dis);
                        AggregateIDList.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfDisEntities; idx++)
                    {
                        var anX = new EntityID();
                        anX.Unmarshal(dis);
                        EntityIDList.Add(anX);
                    }

                    Pad2 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < NumberOfSilentAggregateTypes; idx++)
                    {
                        var anX = new EntityType();
                        anX.Unmarshal(dis);
                        SilentAggregateSystemList.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfSilentEntityTypes; idx++)
                    {
                        var anX = new EntityType();
                        anX.Unmarshal(dis);
                        SilentEntitySystemList.Add(anX);
                    }

                    NumberOfVariableDatumRecords = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < NumberOfVariableDatumRecords; idx++)
                    {
                        var anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        VariableDatumList.Add(anX);
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
            sb.AppendLine("<AggregateStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<aggregateID>");
                AggregateID.Reflection(sb);
                sb.AppendLine("</aggregateID>");
                sb.AppendLine("<forceID type=\"byte\">" + ForceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<aggregateState type=\"byte\">" + AggregateState.ToString(CultureInfo.InvariantCulture) + "</aggregateState>");
                sb.AppendLine("<aggregateType>");
                AggregateType.Reflection(sb);
                sb.AppendLine("</aggregateType>");
                sb.AppendLine("<formation type=\"uint\">" + Formation.ToString(CultureInfo.InvariantCulture) + "</formation>");
                sb.AppendLine("<aggregateMarking>");
                AggregateMarking.Reflection(sb);
                sb.AppendLine("</aggregateMarking>");
                sb.AppendLine("<dimensions>");
                Dimensions.Reflection(sb);
                sb.AppendLine("</dimensions>");
                sb.AppendLine("<orientation>");
                Orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<centerOfMass>");
                CenterOfMass.Reflection(sb);
                sb.AppendLine("</centerOfMass>");
                sb.AppendLine("<velocity>");
                Velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<aggregateIDList type=\"ushort\">" + AggregateIDList.Count.ToString(CultureInfo.InvariantCulture) + "</aggregateIDList>");
                sb.AppendLine("<entityIDList type=\"ushort\">" + EntityIDList.Count.ToString(CultureInfo.InvariantCulture) + "</entityIDList>");
                sb.AppendLine("<silentAggregateSystemList type=\"ushort\">" + SilentAggregateSystemList.Count.ToString(CultureInfo.InvariantCulture) + "</silentAggregateSystemList>");
                sb.AppendLine("<silentEntitySystemList type=\"ushort\">" + SilentEntitySystemList.Count.ToString(CultureInfo.InvariantCulture) + "</silentEntitySystemList>");
                for (int idx = 0; idx < AggregateIDList.Count; idx++)
                {
                    sb.AppendLine("<aggregateIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AggregateID\">");
                    var aAggregateID = AggregateIDList[idx];
                    aAggregateID.Reflection(sb);
                    sb.AppendLine("</aggregateIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < EntityIDList.Count; idx++)
                {
                    sb.AppendLine("<entityIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityID\">");
                    var aEntityID = EntityIDList[idx];
                    aEntityID.Reflection(sb);
                    sb.AppendLine("</entityIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<pad2 type=\"byte\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                for (int idx = 0; idx < SilentAggregateSystemList.Count; idx++)
                {
                    sb.AppendLine("<silentAggregateSystemList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    var aEntityType = SilentAggregateSystemList[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</silentAggregateSystemList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < SilentEntitySystemList.Count; idx++)
                {
                    sb.AppendLine("<silentEntitySystemList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    var aEntityType = SilentEntitySystemList[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</silentEntitySystemList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<variableDatumList type=\"uint\">" + VariableDatumList.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumList>");
                for (int idx = 0; idx < VariableDatumList.Count; idx++)
                {
                    sb.AppendLine("<variableDatumList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    var aVariableDatum = VariableDatumList[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</variableDatumList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</AggregateStatePdu>");
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
        public override bool Equals(object obj) => this == obj as AggregateStatePdu;

        ///<inheritdoc/>
        public bool Equals(AggregateStatePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!AggregateID.Equals(obj.AggregateID))
            {
                ivarsEqual = false;
            }

            if (ForceID != obj.ForceID)
            {
                ivarsEqual = false;
            }

            if (AggregateState != obj.AggregateState)
            {
                ivarsEqual = false;
            }

            if (!AggregateType.Equals(obj.AggregateType))
            {
                ivarsEqual = false;
            }

            if (Formation != obj.Formation)
            {
                ivarsEqual = false;
            }

            if (!AggregateMarking.Equals(obj.AggregateMarking))
            {
                ivarsEqual = false;
            }

            if (!Dimensions.Equals(obj.Dimensions))
            {
                ivarsEqual = false;
            }

            if (!Orientation.Equals(obj.Orientation))
            {
                ivarsEqual = false;
            }

            if (!CenterOfMass.Equals(obj.CenterOfMass))
            {
                ivarsEqual = false;
            }

            if (!Velocity.Equals(obj.Velocity))
            {
                ivarsEqual = false;
            }

            if (NumberOfDisAggregates != obj.NumberOfDisAggregates)
            {
                ivarsEqual = false;
            }

            if (NumberOfDisEntities != obj.NumberOfDisEntities)
            {
                ivarsEqual = false;
            }

            if (NumberOfSilentAggregateTypes != obj.NumberOfSilentAggregateTypes)
            {
                ivarsEqual = false;
            }

            if (NumberOfSilentEntityTypes != obj.NumberOfSilentEntityTypes)
            {
                ivarsEqual = false;
            }

            if (AggregateIDList.Count != obj.AggregateIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < AggregateIDList.Count; idx++)
                {
                    if (!AggregateIDList[idx].Equals(obj.AggregateIDList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (EntityIDList.Count != obj.EntityIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < EntityIDList.Count; idx++)
                {
                    if (!EntityIDList[idx].Equals(obj.EntityIDList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (SilentAggregateSystemList.Count != obj.SilentAggregateSystemList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < SilentAggregateSystemList.Count; idx++)
                {
                    if (!SilentAggregateSystemList[idx].Equals(obj.SilentAggregateSystemList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (SilentEntitySystemList.Count != obj.SilentEntitySystemList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < SilentEntitySystemList.Count; idx++)
                {
                    if (!SilentEntitySystemList[idx].Equals(obj.SilentEntitySystemList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (NumberOfVariableDatumRecords != obj.NumberOfVariableDatumRecords)
            {
                ivarsEqual = false;
            }

            if (VariableDatumList.Count != obj.VariableDatumList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < VariableDatumList.Count; idx++)
                {
                    if (!VariableDatumList[idx].Equals(obj.VariableDatumList[idx]))
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

            result = GenerateHash(result) ^ AggregateID.GetHashCode();
            result = GenerateHash(result) ^ ForceID.GetHashCode();
            result = GenerateHash(result) ^ AggregateState.GetHashCode();
            result = GenerateHash(result) ^ AggregateType.GetHashCode();
            result = GenerateHash(result) ^ Formation.GetHashCode();
            result = GenerateHash(result) ^ AggregateMarking.GetHashCode();
            result = GenerateHash(result) ^ Dimensions.GetHashCode();
            result = GenerateHash(result) ^ Orientation.GetHashCode();
            result = GenerateHash(result) ^ CenterOfMass.GetHashCode();
            result = GenerateHash(result) ^ Velocity.GetHashCode();
            result = GenerateHash(result) ^ NumberOfDisAggregates.GetHashCode();
            result = GenerateHash(result) ^ NumberOfDisEntities.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSilentAggregateTypes.GetHashCode();
            result = GenerateHash(result) ^ NumberOfSilentEntityTypes.GetHashCode();

            if (AggregateIDList.Count > 0)
            {
                for (int idx = 0; idx < AggregateIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ AggregateIDList[idx].GetHashCode();
                }
            }

            if (EntityIDList.Count > 0)
            {
                for (int idx = 0; idx < EntityIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ EntityIDList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ Pad2.GetHashCode();

            if (SilentAggregateSystemList.Count > 0)
            {
                for (int idx = 0; idx < SilentAggregateSystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ SilentAggregateSystemList[idx].GetHashCode();
                }
            }

            if (SilentEntitySystemList.Count > 0)
            {
                for (int idx = 0; idx < SilentEntitySystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ SilentEntitySystemList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ NumberOfVariableDatumRecords.GetHashCode();

            if (VariableDatumList.Count > 0)
            {
                for (int idx = 0; idx < VariableDatumList.Count; idx++)
                {
                    result = GenerateHash(result) ^ VariableDatumList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
