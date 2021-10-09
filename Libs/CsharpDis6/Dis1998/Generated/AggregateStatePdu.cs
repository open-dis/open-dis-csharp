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
    /// Section 5.3.9.1 informationa bout aggregating entities anc communicating information about the aggregated entities.        requires manual intervention to fix the padding between entityID lists and silent aggregate sysem lists--this padding        is dependent on how many entityIDs there are, and needs to be on a 32 bit word boundary. UNFINISHED
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
        /// ID of aggregated entities
        /// </summary>
        private EntityID _aggregateID = new EntityID();

        /// <summary>
        /// force ID
        /// </summary>
        private byte _forceID;

        /// <summary>
        /// state of aggregate
        /// </summary>
        private byte _aggregateState;

        /// <summary>
        /// entity type of the aggregated entities
        /// </summary>
        private EntityType _aggregateType = new EntityType();

        /// <summary>
        /// formation of aggregated entities
        /// </summary>
        private uint _formation;

        /// <summary>
        /// marking for aggregate; first char is charset type, rest is char data
        /// </summary>
        private AggregateMarking _aggregateMarking = new AggregateMarking();

        /// <summary>
        /// dimensions of bounding box for the aggregated entities, origin at the center of mass
        /// </summary>
        private Vector3Float _dimensions = new Vector3Float();

        /// <summary>
        /// orientation of the bounding box
        /// </summary>
        private Orientation _orientation = new Orientation();

        /// <summary>
        /// center of mass of the aggregation
        /// </summary>
        private Vector3Double _centerOfMass = new Vector3Double();

        /// <summary>
        /// velocity of aggregation
        /// </summary>
        private Vector3Float _velocity = new Vector3Float();

        /// <summary>
        /// number of aggregates
        /// </summary>
        private ushort _numberOfDisAggregates;

        /// <summary>
        /// number of entities
        /// </summary>
        private ushort _numberOfDisEntities;

        /// <summary>
        /// number of silent aggregate types
        /// </summary>
        private ushort _numberOfSilentAggregateTypes;

        /// <summary>
        /// number of silent entity types
        /// </summary>
        private ushort _numberOfSilentEntityTypes;

        /// <summary>
        /// aggregates  list
        /// </summary>
        private List<AggregateID> _aggregateIDList = new List<AggregateID>();

        /// <summary>
        /// entity ID list
        /// </summary>
        private List<EntityID> _entityIDList = new List<EntityID>();

        /// <summary>
        /// ^^^padding to put the start of the next list on a 32 bit boundary. This needs to be fixed
        /// </summary>
        private byte _pad2;

        /// <summary>
        /// silent entity types
        /// </summary>
        private List<EntityType> _silentAggregateSystemList = new List<EntityType>();

        /// <summary>
        /// silent entity types
        /// </summary>
        private List<EntityType> _silentEntitySystemList = new List<EntityType>();

        /// <summary>
        /// number of variable datum records
        /// </summary>
        private uint _numberOfVariableDatumRecords;

        /// <summary>
        /// variableDatums
        /// </summary>
        private List<VariableDatum> _variableDatumList = new List<VariableDatum>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateStatePdu"/> class.
        /// </summary>
        public AggregateStatePdu()
        {
            PduType = (byte)33;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AggregateStatePdu left, AggregateStatePdu right)
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
        public static bool operator ==(AggregateStatePdu left, AggregateStatePdu right)
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
            marshalSize += this._aggregateID.GetMarshalledSize();  // this._aggregateID
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._aggregateState
            marshalSize += this._aggregateType.GetMarshalledSize();  // this._aggregateType
            marshalSize += 4;  // this._formation
            marshalSize += this._aggregateMarking.GetMarshalledSize();  // this._aggregateMarking
            marshalSize += this._dimensions.GetMarshalledSize();  // this._dimensions
            marshalSize += this._orientation.GetMarshalledSize();  // this._orientation
            marshalSize += this._centerOfMass.GetMarshalledSize();  // this._centerOfMass
            marshalSize += this._velocity.GetMarshalledSize();  // this._velocity
            marshalSize += 2;  // this._numberOfDisAggregates
            marshalSize += 2;  // this._numberOfDisEntities
            marshalSize += 2;  // this._numberOfSilentAggregateTypes
            marshalSize += 2;  // this._numberOfSilentEntityTypes
            for (int idx = 0; idx < this._aggregateIDList.Count; idx++)
            {
                AggregateID listElement = (AggregateID)this._aggregateIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._entityIDList.Count; idx++)
            {
                EntityID listElement = (EntityID)this._entityIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            marshalSize += 1;  // this._pad2
            for (int idx = 0; idx < this._silentAggregateSystemList.Count; idx++)
            {
                EntityType listElement = (EntityType)this._silentAggregateSystemList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._silentEntitySystemList.Count; idx++)
            {
                EntityType listElement = (EntityType)this._silentEntitySystemList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            marshalSize += 4;  // this._numberOfVariableDatumRecords
            for (int idx = 0; idx < this._variableDatumList.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)this._variableDatumList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "aggregateID")]
        public EntityID AggregateID
        {
            get
            {
                return this._aggregateID;
            }

            set
            {
                this._aggregateID = value;
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
        /// Gets or sets the state of aggregate
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "aggregateState")]
        public byte AggregateState
        {
            get
            {
                return this._aggregateState;
            }

            set
            {
                this._aggregateState = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity type of the aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "aggregateType")]
        public EntityType AggregateType
        {
            get
            {
                return this._aggregateType;
            }

            set
            {
                this._aggregateType = value;
            }
        }

        /// <summary>
        /// Gets or sets the formation of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "formation")]
        public uint Formation
        {
            get
            {
                return this._formation;
            }

            set
            {
                this._formation = value;
            }
        }

        /// <summary>
        /// Gets or sets the marking for aggregate; first char is charset type, rest is char data
        /// </summary>
        [XmlElement(Type = typeof(AggregateMarking), ElementName = "aggregateMarking")]
        public AggregateMarking AggregateMarking
        {
            get
            {
                return this._aggregateMarking;
            }

            set
            {
                this._aggregateMarking = value;
            }
        }

        /// <summary>
        /// Gets or sets the dimensions of bounding box for the aggregated entities, origin at the center of mass
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "dimensions")]
        public Vector3Float Dimensions
        {
            get
            {
                return this._dimensions;
            }

            set
            {
                this._dimensions = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the bounding box
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
        /// Gets or sets the center of mass of the aggregation
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "centerOfMass")]
        public Vector3Double CenterOfMass
        {
            get
            {
                return this._centerOfMass;
            }

            set
            {
                this._centerOfMass = value;
            }
        }

        /// <summary>
        /// Gets or sets the velocity of aggregation
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity
        {
            get
            {
                return this._velocity;
            }

            set
            {
                this._velocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of aggregates
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisAggregates method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfDisAggregates")]
        public ushort NumberOfDisAggregates
        {
            get
            {
                return this._numberOfDisAggregates;
            }

            set
            {
                this._numberOfDisAggregates = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of entities
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisEntities method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfDisEntities")]
        public ushort NumberOfDisEntities
        {
            get
            {
                return this._numberOfDisEntities;
            }

            set
            {
                this._numberOfDisEntities = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of silent aggregate types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentAggregateTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentAggregateTypes")]
        public ushort NumberOfSilentAggregateTypes
        {
            get
            {
                return this._numberOfSilentAggregateTypes;
            }

            set
            {
                this._numberOfSilentAggregateTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of silent entity types
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentEntityTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentEntityTypes")]
        public ushort NumberOfSilentEntityTypes
        {
            get
            {
                return this._numberOfSilentEntityTypes;
            }

            set
            {
                this._numberOfSilentEntityTypes = value;
            }
        }

        /// <summary>
        /// Gets the aggregates  list
        /// </summary>
        [XmlElement(ElementName = "aggregateIDListList", Type = typeof(List<AggregateID>))]
        public List<AggregateID> AggregateIDList
        {
            get
            {
                return this._aggregateIDList;
            }
        }

        /// <summary>
        /// Gets the entity ID list
        /// </summary>
        [XmlElement(ElementName = "entityIDListList", Type = typeof(List<EntityID>))]
        public List<EntityID> EntityIDList
        {
            get
            {
                return this._entityIDList;
            }
        }

        /// <summary>
        /// Gets or sets the ^^^padding to put the start of the next list on a 32 bit boundary. This needs to be fixed
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
        /// Gets the silent entity types
        /// </summary>
        [XmlElement(ElementName = "silentAggregateSystemListList", Type = typeof(List<EntityType>))]
        public List<EntityType> SilentAggregateSystemList
        {
            get
            {
                return this._silentAggregateSystemList;
            }
        }

        /// <summary>
        /// Gets the silent entity types
        /// </summary>
        [XmlElement(ElementName = "silentEntitySystemListList", Type = typeof(List<EntityType>))]
        public List<EntityType> SilentEntitySystemList
        {
            get
            {
                return this._silentEntitySystemList;
            }
        }

        /// <summary>
        /// Gets or sets the number of variable datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
        public uint NumberOfVariableDatumRecords
        {
            get
            {
                return this._numberOfVariableDatumRecords;
            }

            set
            {
                this._numberOfVariableDatumRecords = value;
            }
        }

        /// <summary>
        /// Gets the variableDatums
        /// </summary>
        [XmlElement(ElementName = "variableDatumListList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatumList
        {
            get
            {
                return this._variableDatumList;
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
                    this._aggregateID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._forceID);
                    dos.WriteUnsignedByte((byte)this._aggregateState);
                    this._aggregateType.Marshal(dos);
                    dos.WriteUnsignedInt((uint)this._formation);
                    this._aggregateMarking.Marshal(dos);
                    this._dimensions.Marshal(dos);
                    this._orientation.Marshal(dos);
                    this._centerOfMass.Marshal(dos);
                    this._velocity.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._aggregateIDList.Count);
                    dos.WriteUnsignedShort((ushort)this._entityIDList.Count);
                    dos.WriteUnsignedShort((ushort)this._silentAggregateSystemList.Count);
                    dos.WriteUnsignedShort((ushort)this._silentEntitySystemList.Count);

                    for (int idx = 0; idx < this._aggregateIDList.Count; idx++)
                    {
                        AggregateID aAggregateID = (AggregateID)this._aggregateIDList[idx];
                        aAggregateID.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._entityIDList.Count; idx++)
                    {
                        EntityID aEntityID = (EntityID)this._entityIDList[idx];
                        aEntityID.Marshal(dos);
                    }

                    dos.WriteUnsignedByte((byte)this._pad2);

                    for (int idx = 0; idx < this._silentAggregateSystemList.Count; idx++)
                    {
                        EntityType aEntityType = (EntityType)this._silentAggregateSystemList[idx];
                        aEntityType.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._silentEntitySystemList.Count; idx++)
                    {
                        EntityType aEntityType = (EntityType)this._silentEntitySystemList[idx];
                        aEntityType.Marshal(dos);
                    }

                    dos.WriteUnsignedInt((uint)this._variableDatumList.Count);

                    for (int idx = 0; idx < this._variableDatumList.Count; idx++)
                    {
                        VariableDatum aVariableDatum = (VariableDatum)this._variableDatumList[idx];
                        aVariableDatum.Marshal(dos);
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
                    this._aggregateID.Unmarshal(dis);
                    this._forceID = dis.ReadUnsignedByte();
                    this._aggregateState = dis.ReadUnsignedByte();
                    this._aggregateType.Unmarshal(dis);
                    this._formation = dis.ReadUnsignedInt();
                    this._aggregateMarking.Unmarshal(dis);
                    this._dimensions.Unmarshal(dis);
                    this._orientation.Unmarshal(dis);
                    this._centerOfMass.Unmarshal(dis);
                    this._velocity.Unmarshal(dis);
                    this._numberOfDisAggregates = dis.ReadUnsignedShort();
                    this._numberOfDisEntities = dis.ReadUnsignedShort();
                    this._numberOfSilentAggregateTypes = dis.ReadUnsignedShort();
                    this._numberOfSilentEntityTypes = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfDisAggregates; idx++)
                    {
                        AggregateID anX = new AggregateID();
                        anX.Unmarshal(dis);
                        this._aggregateIDList.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfDisEntities; idx++)
                    {
                        EntityID anX = new EntityID();
                        anX.Unmarshal(dis);
                        this._entityIDList.Add(anX);
                    }

                    this._pad2 = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this.NumberOfSilentAggregateTypes; idx++)
                    {
                        EntityType anX = new EntityType();
                        anX.Unmarshal(dis);
                        this._silentAggregateSystemList.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfSilentEntityTypes; idx++)
                    {
                        EntityType anX = new EntityType();
                        anX.Unmarshal(dis);
                        this._silentEntitySystemList.Add(anX);
                    }

                    this._numberOfVariableDatumRecords = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < this.NumberOfVariableDatumRecords; idx++)
                    {
                        VariableDatum anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        this._variableDatumList.Add(anX);
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
            sb.AppendLine("<AggregateStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<aggregateID>");
                this._aggregateID.Reflection(sb);
                sb.AppendLine("</aggregateID>");
                sb.AppendLine("<forceID type=\"byte\">" + this._forceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<aggregateState type=\"byte\">" + this._aggregateState.ToString(CultureInfo.InvariantCulture) + "</aggregateState>");
                sb.AppendLine("<aggregateType>");
                this._aggregateType.Reflection(sb);
                sb.AppendLine("</aggregateType>");
                sb.AppendLine("<formation type=\"uint\">" + this._formation.ToString(CultureInfo.InvariantCulture) + "</formation>");
                sb.AppendLine("<aggregateMarking>");
                this._aggregateMarking.Reflection(sb);
                sb.AppendLine("</aggregateMarking>");
                sb.AppendLine("<dimensions>");
                this._dimensions.Reflection(sb);
                sb.AppendLine("</dimensions>");
                sb.AppendLine("<orientation>");
                this._orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<centerOfMass>");
                this._centerOfMass.Reflection(sb);
                sb.AppendLine("</centerOfMass>");
                sb.AppendLine("<velocity>");
                this._velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<aggregateIDList type=\"ushort\">" + this._aggregateIDList.Count.ToString(CultureInfo.InvariantCulture) + "</aggregateIDList>");
                sb.AppendLine("<entityIDList type=\"ushort\">" + this._entityIDList.Count.ToString(CultureInfo.InvariantCulture) + "</entityIDList>");
                sb.AppendLine("<silentAggregateSystemList type=\"ushort\">" + this._silentAggregateSystemList.Count.ToString(CultureInfo.InvariantCulture) + "</silentAggregateSystemList>");
                sb.AppendLine("<silentEntitySystemList type=\"ushort\">" + this._silentEntitySystemList.Count.ToString(CultureInfo.InvariantCulture) + "</silentEntitySystemList>");
                for (int idx = 0; idx < this._aggregateIDList.Count; idx++)
                {
                    sb.AppendLine("<aggregateIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AggregateID\">");
                    AggregateID aAggregateID = (AggregateID)this._aggregateIDList[idx];
                    aAggregateID.Reflection(sb);
                    sb.AppendLine("</aggregateIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._entityIDList.Count; idx++)
                {
                    sb.AppendLine("<entityIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityID\">");
                    EntityID aEntityID = (EntityID)this._entityIDList[idx];
                    aEntityID.Reflection(sb);
                    sb.AppendLine("</entityIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<pad2 type=\"byte\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                for (int idx = 0; idx < this._silentAggregateSystemList.Count; idx++)
                {
                    sb.AppendLine("<silentAggregateSystemList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    EntityType aEntityType = (EntityType)this._silentAggregateSystemList[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</silentAggregateSystemList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._silentEntitySystemList.Count; idx++)
                {
                    sb.AppendLine("<silentEntitySystemList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
                    EntityType aEntityType = (EntityType)this._silentEntitySystemList[idx];
                    aEntityType.Reflection(sb);
                    sb.AppendLine("</silentEntitySystemList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<variableDatumList type=\"uint\">" + this._variableDatumList.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumList>");
                for (int idx = 0; idx < this._variableDatumList.Count; idx++)
                {
                    sb.AppendLine("<variableDatumList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    VariableDatum aVariableDatum = (VariableDatum)this._variableDatumList[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</variableDatumList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</AggregateStatePdu>");
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
            return this == obj as AggregateStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AggregateStatePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._aggregateID.Equals(obj._aggregateID))
            {
                ivarsEqual = false;
            }

            if (this._forceID != obj._forceID)
            {
                ivarsEqual = false;
            }

            if (this._aggregateState != obj._aggregateState)
            {
                ivarsEqual = false;
            }

            if (!this._aggregateType.Equals(obj._aggregateType))
            {
                ivarsEqual = false;
            }

            if (this._formation != obj._formation)
            {
                ivarsEqual = false;
            }

            if (!this._aggregateMarking.Equals(obj._aggregateMarking))
            {
                ivarsEqual = false;
            }

            if (!this._dimensions.Equals(obj._dimensions))
            {
                ivarsEqual = false;
            }

            if (!this._orientation.Equals(obj._orientation))
            {
                ivarsEqual = false;
            }

            if (!this._centerOfMass.Equals(obj._centerOfMass))
            {
                ivarsEqual = false;
            }

            if (!this._velocity.Equals(obj._velocity))
            {
                ivarsEqual = false;
            }

            if (this._numberOfDisAggregates != obj._numberOfDisAggregates)
            {
                ivarsEqual = false;
            }

            if (this._numberOfDisEntities != obj._numberOfDisEntities)
            {
                ivarsEqual = false;
            }

            if (this._numberOfSilentAggregateTypes != obj._numberOfSilentAggregateTypes)
            {
                ivarsEqual = false;
            }

            if (this._numberOfSilentEntityTypes != obj._numberOfSilentEntityTypes)
            {
                ivarsEqual = false;
            }

            if (this._aggregateIDList.Count != obj._aggregateIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._aggregateIDList.Count; idx++)
                {
                    if (!this._aggregateIDList[idx].Equals(obj._aggregateIDList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._entityIDList.Count != obj._entityIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._entityIDList.Count; idx++)
                {
                    if (!this._entityIDList[idx].Equals(obj._entityIDList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (this._silentAggregateSystemList.Count != obj._silentAggregateSystemList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._silentAggregateSystemList.Count; idx++)
                {
                    if (!this._silentAggregateSystemList[idx].Equals(obj._silentAggregateSystemList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._silentEntitySystemList.Count != obj._silentEntitySystemList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._silentEntitySystemList.Count; idx++)
                {
                    if (!this._silentEntitySystemList[idx].Equals(obj._silentEntitySystemList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._numberOfVariableDatumRecords != obj._numberOfVariableDatumRecords)
            {
                ivarsEqual = false;
            }

            if (this._variableDatumList.Count != obj._variableDatumList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._variableDatumList.Count; idx++)
                {
                    if (!this._variableDatumList[idx].Equals(obj._variableDatumList[idx]))
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

            result = GenerateHash(result) ^ this._aggregateID.GetHashCode();
            result = GenerateHash(result) ^ this._forceID.GetHashCode();
            result = GenerateHash(result) ^ this._aggregateState.GetHashCode();
            result = GenerateHash(result) ^ this._aggregateType.GetHashCode();
            result = GenerateHash(result) ^ this._formation.GetHashCode();
            result = GenerateHash(result) ^ this._aggregateMarking.GetHashCode();
            result = GenerateHash(result) ^ this._dimensions.GetHashCode();
            result = GenerateHash(result) ^ this._orientation.GetHashCode();
            result = GenerateHash(result) ^ this._centerOfMass.GetHashCode();
            result = GenerateHash(result) ^ this._velocity.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfDisAggregates.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfDisEntities.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSilentAggregateTypes.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSilentEntityTypes.GetHashCode();

            if (this._aggregateIDList.Count > 0)
            {
                for (int idx = 0; idx < this._aggregateIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._aggregateIDList[idx].GetHashCode();
                }
            }

            if (this._entityIDList.Count > 0)
            {
                for (int idx = 0; idx < this._entityIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._entityIDList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ this._pad2.GetHashCode();

            if (this._silentAggregateSystemList.Count > 0)
            {
                for (int idx = 0; idx < this._silentAggregateSystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._silentAggregateSystemList[idx].GetHashCode();
                }
            }

            if (this._silentEntitySystemList.Count > 0)
            {
                for (int idx = 0; idx < this._silentEntitySystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._silentEntitySystemList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ this._numberOfVariableDatumRecords.GetHashCode();

            if (this._variableDatumList.Count > 0)
            {
                for (int idx = 0; idx < this._variableDatumList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._variableDatumList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
