// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
//  are met:
// 
//  * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//  Modeling Virtual Environments and Simulation (MOVES) Institute
// (http://www.nps.edu and http://www.MovesInstitute.org)
// nor the names of its contributors may be used to endorse or
//  promote products derived from this software without specific
// prior written permission.
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DIS1998net
{

    /**
     * Section 5.3.9.1 informationa bout aggregating entities anc communicating information about the aggregated entities.        requires manual intervention to fix the padding between entityID lists and silent aggregate sysem lists--this padding        is dependent on how many entityIDs there are, and needs to be on a 32 bit word boundary. UNFINISHED
     *
     * Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All rights reserved.
     * This work is licensed under the BSD open source license, available at https://www.movesinstitute.org/licenses/bsd.html
     *
     * @author DMcG
     * Modified for use with C#:
     * Peter Smith (Naval Air Warfare Center - Training Systems Division)
     */
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
    public partial class AggregateStatePdu : EntityManagementFamilyPdu
    {
        /** ID of aggregated entities */
        protected EntityID  _aggregateID = new EntityID(); 

        /** force ID */
        protected byte  _forceID;

        /** state of aggregate */
        protected byte  _aggregateState;

        /** entity type of the aggregated entities */
        protected EntityType  _aggregateType = new EntityType(); 

        /** formation of aggregated entities */
        protected uint  _formation;

        /** marking for aggregate; first char is charset type, rest is char data */
        protected AggregateMarking  _aggregateMarking = new AggregateMarking(); 

        /** dimensions of bounding box for the aggregated entities, origin at the center of mass */
        protected Vector3Float  _dimensions = new Vector3Float(); 

        /** orientation of the bounding box */
        protected Orientation  _orientation = new Orientation(); 

        /** center of mass of the aggregation */
        protected Vector3Double  _centerOfMass = new Vector3Double(); 

        /** velocity of aggregation */
        protected Vector3Float  _velocity = new Vector3Float(); 

        /** number of aggregates */
        protected ushort  _numberOfDisAggregates;

        /** number of entities */
        protected ushort  _numberOfDisEntities;

        /** number of silent aggregate types */
        protected ushort  _numberOfSilentAggregateTypes;

        /** number of silent entity types */
        protected ushort  _numberOfSilentEntityTypes;

        /** aggregates  list */
        protected List<AggregateID> _aggregateIDList = new List<AggregateID>(); 
        /** entity ID list */
        protected List<EntityID> _entityIDList = new List<EntityID>(); 
        /** ^^^padding to put the start of the next list on a 32 bit boundary. This needs to be fixed */
        protected byte  _pad2;

        /** silent entity types */
        protected List<EntityType> _silentAggregateSystemList = new List<EntityType>(); 
        /** silent entity types */
        protected List<EntityType> _silentEntitySystemList = new List<EntityType>(); 
        /** number of variable datum records */
        protected uint  _numberOfVariableDatumRecords;

        /** variableDatums */
        protected List<VariableDatum> _variableDatumList = new List<VariableDatum>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.9.1 informationa bout aggregating entities anc communicating information about the aggregated entities.        requires manual intervention to fix the padding between entityID lists and silent aggregate sysem lists--this padding        is dependent on how many entityIDs there are, and needs to be on a 32 bit word boundary. UNFINISHED
        ///</summary>
        public AggregateStatePdu()
        {
            PduType = (byte)33;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _aggregateID.getMarshalledSize();  // _aggregateID
            marshalSize = marshalSize + 1;  // _forceID
            marshalSize = marshalSize + 1;  // _aggregateState
            marshalSize = marshalSize + _aggregateType.getMarshalledSize();  // _aggregateType
            marshalSize = marshalSize + 4;  // _formation
            marshalSize = marshalSize + _aggregateMarking.getMarshalledSize();  // _aggregateMarking
            marshalSize = marshalSize + _dimensions.getMarshalledSize();  // _dimensions
            marshalSize = marshalSize + _orientation.getMarshalledSize();  // _orientation
            marshalSize = marshalSize + _centerOfMass.getMarshalledSize();  // _centerOfMass
            marshalSize = marshalSize + _velocity.getMarshalledSize();  // _velocity
            marshalSize = marshalSize + 2;  // _numberOfDisAggregates
            marshalSize = marshalSize + 2;  // _numberOfDisEntities
            marshalSize = marshalSize + 2;  // _numberOfSilentAggregateTypes
            marshalSize = marshalSize + 2;  // _numberOfSilentEntityTypes
            for(int idx=0; idx < _aggregateIDList.Count; idx++)
            {
                AggregateID listElement = (AggregateID)_aggregateIDList[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _entityIDList.Count; idx++)
            {
                EntityID listElement = (EntityID)_entityIDList[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            marshalSize = marshalSize + 1;  // _pad2
            for(int idx=0; idx < _silentAggregateSystemList.Count; idx++)
            {
                EntityType listElement = (EntityType)_silentAggregateSystemList[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _silentEntitySystemList.Count; idx++)
            {
                EntityType listElement = (EntityType)_silentEntitySystemList[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            marshalSize = marshalSize + 4;  // _numberOfVariableDatumRecords
            for(int idx=0; idx < _variableDatumList.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)_variableDatumList[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///ID of aggregated entities
        ///</summary>
        public void setAggregateID(EntityID pAggregateID)
        { 
            _aggregateID = pAggregateID;
        }

        ///<summary>
        ///ID of aggregated entities
        ///</summary>
        public EntityID getAggregateID()
        {
            return _aggregateID;
        }

        ///<summary>
        ///ID of aggregated entities
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="aggregateID")]
        public EntityID AggregateID
        {
            get
            {
                return _aggregateID;
            }
            set
            {
                _aggregateID = value;
            }
        }

        ///<summary>
        ///force ID
        ///</summary>
        public void setForceID(byte pForceID)
        { 
            _forceID = pForceID;
        }

        [XmlElement(Type= typeof(byte), ElementName="forceID")]
        public byte ForceID
        {
            get
            {
                return _forceID;
            }
            set
            {
                _forceID = value;
            }
        }

        ///<summary>
        ///state of aggregate
        ///</summary>
        public void setAggregateState(byte pAggregateState)
        { 
            _aggregateState = pAggregateState;
        }

        [XmlElement(Type= typeof(byte), ElementName="aggregateState")]
        public byte AggregateState
        {
            get
            {
                return _aggregateState;
            }
            set
            {
                _aggregateState = value;
            }
        }

        ///<summary>
        ///entity type of the aggregated entities
        ///</summary>
        public void setAggregateType(EntityType pAggregateType)
        { 
            _aggregateType = pAggregateType;
        }

        ///<summary>
        ///entity type of the aggregated entities
        ///</summary>
        public EntityType getAggregateType()
        {
            return _aggregateType;
        }

        ///<summary>
        ///entity type of the aggregated entities
        ///</summary>
        [XmlElement(Type= typeof(EntityType), ElementName="aggregateType")]
        public EntityType AggregateType
        {
            get
            {
                return _aggregateType;
            }
            set
            {
                _aggregateType = value;
            }
        }

        ///<summary>
        ///formation of aggregated entities
        ///</summary>
        public void setFormation(uint pFormation)
        { 
            _formation = pFormation;
        }

        [XmlElement(Type= typeof(uint), ElementName="formation")]
        public uint Formation
        {
            get
            {
                return _formation;
            }
            set
            {
                _formation = value;
            }
        }

        ///<summary>
        ///marking for aggregate; first char is charset type, rest is char data
        ///</summary>
        public void setAggregateMarking(AggregateMarking pAggregateMarking)
        { 
            _aggregateMarking = pAggregateMarking;
        }

        ///<summary>
        ///marking for aggregate; first char is charset type, rest is char data
        ///</summary>
        public AggregateMarking getAggregateMarking()
        {
            return _aggregateMarking;
        }

        ///<summary>
        ///marking for aggregate; first char is charset type, rest is char data
        ///</summary>
        [XmlElement(Type= typeof(AggregateMarking), ElementName="aggregateMarking")]
        public AggregateMarking AggregateMarking
        {
            get
            {
                return _aggregateMarking;
            }
            set
            {
                _aggregateMarking = value;
            }
        }

        ///<summary>
        ///dimensions of bounding box for the aggregated entities, origin at the center of mass
        ///</summary>
        public void setDimensions(Vector3Float pDimensions)
        { 
            _dimensions = pDimensions;
        }

        ///<summary>
        ///dimensions of bounding box for the aggregated entities, origin at the center of mass
        ///</summary>
        public Vector3Float getDimensions()
        {
            return _dimensions;
        }

        ///<summary>
        ///dimensions of bounding box for the aggregated entities, origin at the center of mass
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="dimensions")]
        public Vector3Float Dimensions
        {
            get
            {
                return _dimensions;
            }
            set
            {
                _dimensions = value;
            }
        }

        ///<summary>
        ///orientation of the bounding box
        ///</summary>
        public void setOrientation(Orientation pOrientation)
        { 
            _orientation = pOrientation;
        }

        ///<summary>
        ///orientation of the bounding box
        ///</summary>
        public Orientation getOrientation()
        {
            return _orientation;
        }

        ///<summary>
        ///orientation of the bounding box
        ///</summary>
        [XmlElement(Type= typeof(Orientation), ElementName="orientation")]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
            }
        }

        ///<summary>
        ///center of mass of the aggregation
        ///</summary>
        public void setCenterOfMass(Vector3Double pCenterOfMass)
        { 
            _centerOfMass = pCenterOfMass;
        }

        ///<summary>
        ///center of mass of the aggregation
        ///</summary>
        public Vector3Double getCenterOfMass()
        {
            return _centerOfMass;
        }

        ///<summary>
        ///center of mass of the aggregation
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="centerOfMass")]
        public Vector3Double CenterOfMass
        {
            get
            {
                return _centerOfMass;
            }
            set
            {
                _centerOfMass = value;
            }
        }

        ///<summary>
        ///velocity of aggregation
        ///</summary>
        public void setVelocity(Vector3Float pVelocity)
        { 
            _velocity = pVelocity;
        }

        ///<summary>
        ///velocity of aggregation
        ///</summary>
        public Vector3Float getVelocity()
        {
            return _velocity;
        }

        ///<summary>
        ///velocity of aggregation
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="velocity")]
        public Vector3Float Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisAggregates method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfDisAggregates(ushort pNumberOfDisAggregates)
        {
            _numberOfDisAggregates = pNumberOfDisAggregates;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisAggregates method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfDisAggregates")]
        public ushort NumberOfDisAggregates
        {
            get
            {
                return _numberOfDisAggregates;
            }
            set
            {
                _numberOfDisAggregates = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisEntities method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfDisEntities(ushort pNumberOfDisEntities)
        {
            _numberOfDisEntities = pNumberOfDisEntities;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfDisEntities method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfDisEntities")]
        public ushort NumberOfDisEntities
        {
            get
            {
                return _numberOfDisEntities;
            }
            set
            {
                _numberOfDisEntities = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentAggregateTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfSilentAggregateTypes(ushort pNumberOfSilentAggregateTypes)
        {
            _numberOfSilentAggregateTypes = pNumberOfSilentAggregateTypes;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentAggregateTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfSilentAggregateTypes")]
        public ushort NumberOfSilentAggregateTypes
        {
            get
            {
                return _numberOfSilentAggregateTypes;
            }
            set
            {
                _numberOfSilentAggregateTypes = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentEntityTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfSilentEntityTypes(ushort pNumberOfSilentEntityTypes)
        {
            _numberOfSilentEntityTypes = pNumberOfSilentEntityTypes;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSilentEntityTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfSilentEntityTypes")]
        public ushort NumberOfSilentEntityTypes
        {
            get
            {
                return _numberOfSilentEntityTypes;
            }
            set
            {
                _numberOfSilentEntityTypes = value;
            }
        }

        ///<summary>
        ///aggregates  list
        ///</summary>
        public void setAggregateIDList(List<AggregateID> pAggregateIDList)
        {
            _aggregateIDList = pAggregateIDList;
        }

        ///<summary>
        ///aggregates  list
        ///</summary>
        public List<AggregateID> getAggregateIDList()
        {
            return _aggregateIDList;
        }

        ///<summary>
        ///aggregates  list
        ///</summary>
        [XmlElement(ElementName = "aggregateIDListList",Type = typeof(List<AggregateID>))]
        public List<AggregateID> AggregateIDList
        {
            get
            {
                return _aggregateIDList;
            }
            set
            {
                _aggregateIDList = value;
            }
        }

        ///<summary>
        ///entity ID list
        ///</summary>
        public void setEntityIDList(List<EntityID> pEntityIDList)
        {
            _entityIDList = pEntityIDList;
        }

        ///<summary>
        ///entity ID list
        ///</summary>
        public List<EntityID> getEntityIDList()
        {
            return _entityIDList;
        }

        ///<summary>
        ///entity ID list
        ///</summary>
        [XmlElement(ElementName = "entityIDListList",Type = typeof(List<EntityID>))]
        public List<EntityID> EntityIDList
        {
            get
            {
                return _entityIDList;
            }
            set
            {
                _entityIDList = value;
            }
        }

        ///<summary>
        ///^^^padding to put the start of the next list on a 32 bit boundary. This needs to be fixed
        ///</summary>
        public void setPad2(byte pPad2)
        { 
            _pad2 = pPad2;
        }

        [XmlElement(Type= typeof(byte), ElementName="pad2")]
        public byte Pad2
        {
            get
            {
                return _pad2;
            }
            set
            {
                _pad2 = value;
            }
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        public void setSilentAggregateSystemList(List<EntityType> pSilentAggregateSystemList)
        {
            _silentAggregateSystemList = pSilentAggregateSystemList;
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        public List<EntityType> getSilentAggregateSystemList()
        {
            return _silentAggregateSystemList;
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        [XmlElement(ElementName = "silentAggregateSystemListList",Type = typeof(List<EntityType>))]
        public List<EntityType> SilentAggregateSystemList
        {
            get
            {
                return _silentAggregateSystemList;
            }
            set
            {
                _silentAggregateSystemList = value;
            }
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        public void setSilentEntitySystemList(List<EntityType> pSilentEntitySystemList)
        {
            _silentEntitySystemList = pSilentEntitySystemList;
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        public List<EntityType> getSilentEntitySystemList()
        {
            return _silentEntitySystemList;
        }

        ///<summary>
        ///silent entity types
        ///</summary>
        [XmlElement(ElementName = "silentEntitySystemListList",Type = typeof(List<EntityType>))]
        public List<EntityType> SilentEntitySystemList
        {
            get
            {
                return _silentEntitySystemList;
            }
            set
            {
                _silentEntitySystemList = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfVariableDatumRecords(uint pNumberOfVariableDatumRecords)
        {
            _numberOfVariableDatumRecords = pNumberOfVariableDatumRecords;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(uint), ElementName="numberOfVariableDatumRecords")]
        public uint NumberOfVariableDatumRecords
        {
            get
            {
                return _numberOfVariableDatumRecords;
            }
            set
            {
                _numberOfVariableDatumRecords = value;
            }
        }

        ///<summary>
        ///variableDatums
        ///</summary>
        public void setVariableDatumList(List<VariableDatum> pVariableDatumList)
        {
            _variableDatumList = pVariableDatumList;
        }

        ///<summary>
        ///variableDatums
        ///</summary>
        public List<VariableDatum> getVariableDatumList()
        {
            return _variableDatumList;
        }

        ///<summary>
        ///variableDatums
        ///</summary>
        [XmlElement(ElementName = "variableDatumListList",Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatumList
        {
            get
            {
                return _variableDatumList;
            }
            set
            {
                _variableDatumList = value;
            }
        }

        ///<summary>
        ///Automatically sets the length of the marshalled data, then calls the marshal method.
        ///</summary>
        new public void marshalAutoLengthSet(DataOutputStream dos)
        {
            //Set the length prior to marshalling data
            this.setLength((ushort)this.getMarshalledSize());
            this.marshal(dos);
        }

        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        new public void marshal(DataOutputStream dos)
        {
            base.marshal(dos);
            try
            {
                _aggregateID.marshal(dos);
                dos.writeByte((byte)_forceID);
                dos.writeByte((byte)_aggregateState);
                _aggregateType.marshal(dos);
                dos.writeUint((uint)_formation);
                _aggregateMarking.marshal(dos);
                _dimensions.marshal(dos);
                _orientation.marshal(dos);
                _centerOfMass.marshal(dos);
                _velocity.marshal(dos);
                dos.writeUshort((ushort)_aggregateIDList.Count);
                dos.writeUshort((ushort)_entityIDList.Count);
                dos.writeUshort((ushort)_silentAggregateSystemList.Count);
                dos.writeUshort((ushort)_silentEntitySystemList.Count);

                for(int idx = 0; idx < _aggregateIDList.Count; idx++)
                {
                    AggregateID aAggregateID = (AggregateID)_aggregateIDList[idx];
                    aAggregateID.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _entityIDList.Count; idx++)
                {
                    EntityID aEntityID = (EntityID)_entityIDList[idx];
                    aEntityID.marshal(dos);
                } // end of list marshalling

                dos.writeByte((byte)_pad2);

                for(int idx = 0; idx < _silentAggregateSystemList.Count; idx++)
                {
                    EntityType aEntityType = (EntityType)_silentAggregateSystemList[idx];
                    aEntityType.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _silentEntitySystemList.Count; idx++)
                {
                    EntityType aEntityType = (EntityType)_silentEntitySystemList[idx];
                    aEntityType.marshal(dos);
                } // end of list marshalling

                dos.writeUint((uint)_variableDatumList.Count);

                for(int idx = 0; idx < _variableDatumList.Count; idx++)
                {
                    VariableDatum aVariableDatum = (VariableDatum)_variableDatumList[idx];
                    aVariableDatum.marshal(dos);
                } // end of list marshalling

            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of marshal method

        new public void unmarshal(DataInputStream dis)
        {
            base.unmarshal(dis);

            try
            {
                _aggregateID.unmarshal(dis);
                _forceID = dis.readByte();
                _aggregateState = dis.readByte();
                _aggregateType.unmarshal(dis);
                _formation = dis.readUint();
                _aggregateMarking.unmarshal(dis);
                _dimensions.unmarshal(dis);
                _orientation.unmarshal(dis);
                _centerOfMass.unmarshal(dis);
                _velocity.unmarshal(dis);
                _numberOfDisAggregates = dis.readUshort();
                _numberOfDisEntities = dis.readUshort();
                _numberOfSilentAggregateTypes = dis.readUshort();
                _numberOfSilentEntityTypes = dis.readUshort();
                for(int idx = 0; idx < _numberOfDisAggregates; idx++)
                {
                    AggregateID anX = new AggregateID();
                    anX.unmarshal(dis);
                    _aggregateIDList.Add(anX);
                };

                for(int idx = 0; idx < _numberOfDisEntities; idx++)
                {
                    EntityID anX = new EntityID();
                    anX.unmarshal(dis);
                    _entityIDList.Add(anX);
                };

                _pad2 = dis.readByte();
                for(int idx = 0; idx < _numberOfSilentAggregateTypes; idx++)
                {
                    EntityType anX = new EntityType();
                    anX.unmarshal(dis);
                    _silentAggregateSystemList.Add(anX);
                };

                for(int idx = 0; idx < _numberOfSilentEntityTypes; idx++)
                {
                    EntityType anX = new EntityType();
                    anX.unmarshal(dis);
                    _silentEntitySystemList.Add(anX);
                };

                _numberOfVariableDatumRecords = dis.readUint();
                for(int idx = 0; idx < _numberOfVariableDatumRecords; idx++)
                {
                    VariableDatum anX = new VariableDatum();
                    anX.unmarshal(dis);
                    _variableDatumList.Add(anX);
                };

            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of unmarshal method

        ///<summary>
        ///This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        ///This will be modified in the future to provide a better display.  Usage: 
        ///pdu.GetType().InvokeMember("reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        ///where pdu is an object representing a single pdu and sb is a StringBuilder.
        ///Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        ///</summary>
        new public void reflection(StringBuilder sb)
        {
            sb.Append("<AggregateStatePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<aggregateID>"  + System.Environment.NewLine);
                _aggregateID.reflection(sb);
                sb.Append("</aggregateID>"  + System.Environment.NewLine);
                sb.Append("<forceID type=\"byte\">" + _forceID.ToString() + "</forceID> " + System.Environment.NewLine);
                sb.Append("<aggregateState type=\"byte\">" + _aggregateState.ToString() + "</aggregateState> " + System.Environment.NewLine);
                sb.Append("<aggregateType>"  + System.Environment.NewLine);
                _aggregateType.reflection(sb);
                sb.Append("</aggregateType>"  + System.Environment.NewLine);
                sb.Append("<formation type=\"uint\">" + _formation.ToString() + "</formation> " + System.Environment.NewLine);
                sb.Append("<aggregateMarking>"  + System.Environment.NewLine);
                _aggregateMarking.reflection(sb);
                sb.Append("</aggregateMarking>"  + System.Environment.NewLine);
                sb.Append("<dimensions>"  + System.Environment.NewLine);
                _dimensions.reflection(sb);
                sb.Append("</dimensions>"  + System.Environment.NewLine);
                sb.Append("<orientation>"  + System.Environment.NewLine);
                _orientation.reflection(sb);
                sb.Append("</orientation>"  + System.Environment.NewLine);
                sb.Append("<centerOfMass>"  + System.Environment.NewLine);
                _centerOfMass.reflection(sb);
                sb.Append("</centerOfMass>"  + System.Environment.NewLine);
                sb.Append("<velocity>"  + System.Environment.NewLine);
                _velocity.reflection(sb);
                sb.Append("</velocity>"  + System.Environment.NewLine);
                sb.Append("<aggregateIDList type=\"ushort\">" + _aggregateIDList.Count.ToString() + "</aggregateIDList> " + System.Environment.NewLine);
                sb.Append("<entityIDList type=\"ushort\">" + _entityIDList.Count.ToString() + "</entityIDList> " + System.Environment.NewLine);
                sb.Append("<silentAggregateSystemList type=\"ushort\">" + _silentAggregateSystemList.Count.ToString() + "</silentAggregateSystemList> " + System.Environment.NewLine);
                sb.Append("<silentEntitySystemList type=\"ushort\">" + _silentEntitySystemList.Count.ToString() + "</silentEntitySystemList> " + System.Environment.NewLine);

            for(int idx = 0; idx < _aggregateIDList.Count; idx++)
            {
                sb.Append("<aggregateIDList"+ idx.ToString() + " type=\"AggregateID\">" + System.Environment.NewLine);
                AggregateID aAggregateID = (AggregateID)_aggregateIDList[idx];
                aAggregateID.reflection(sb);
                sb.Append("</aggregateIDList"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _entityIDList.Count; idx++)
            {
                sb.Append("<entityIDList"+ idx.ToString() + " type=\"EntityID\">" + System.Environment.NewLine);
                EntityID aEntityID = (EntityID)_entityIDList[idx];
                aEntityID.reflection(sb);
                sb.Append("</entityIDList"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("<pad2 type=\"byte\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);

            for(int idx = 0; idx < _silentAggregateSystemList.Count; idx++)
            {
                sb.Append("<silentAggregateSystemList"+ idx.ToString() + " type=\"EntityType\">" + System.Environment.NewLine);
                EntityType aEntityType = (EntityType)_silentAggregateSystemList[idx];
                aEntityType.reflection(sb);
                sb.Append("</silentAggregateSystemList"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _silentEntitySystemList.Count; idx++)
            {
                sb.Append("<silentEntitySystemList"+ idx.ToString() + " type=\"EntityType\">" + System.Environment.NewLine);
                EntityType aEntityType = (EntityType)_silentEntitySystemList[idx];
                aEntityType.reflection(sb);
                sb.Append("</silentEntitySystemList"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("<variableDatumList type=\"uint\">" + _variableDatumList.Count.ToString() + "</variableDatumList> " + System.Environment.NewLine);

            for(int idx = 0; idx < _variableDatumList.Count; idx++)
            {
                sb.Append("<variableDatumList"+ idx.ToString() + " type=\"VariableDatum\">" + System.Environment.NewLine);
                VariableDatum aVariableDatum = (VariableDatum)_variableDatumList[idx];
                aVariableDatum.reflection(sb);
                sb.Append("</variableDatumList"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</AggregateStatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(AggregateStatePdu a, AggregateStatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(AggregateStatePdu a, AggregateStatePdu b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.equals(b);
        }


        public override bool Equals(object obj)
        {
            return this == obj as AggregateStatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(AggregateStatePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_aggregateID.Equals( rhs._aggregateID) )) ivarsEqual = false;
            if( ! (_forceID == rhs._forceID)) ivarsEqual = false;
            if( ! (_aggregateState == rhs._aggregateState)) ivarsEqual = false;
            if( ! (_aggregateType.Equals( rhs._aggregateType) )) ivarsEqual = false;
            if( ! (_formation == rhs._formation)) ivarsEqual = false;
            if( ! (_aggregateMarking.Equals( rhs._aggregateMarking) )) ivarsEqual = false;
            if( ! (_dimensions.Equals( rhs._dimensions) )) ivarsEqual = false;
            if( ! (_orientation.Equals( rhs._orientation) )) ivarsEqual = false;
            if( ! (_centerOfMass.Equals( rhs._centerOfMass) )) ivarsEqual = false;
            if( ! (_velocity.Equals( rhs._velocity) )) ivarsEqual = false;
            if( ! (_numberOfDisAggregates == rhs._numberOfDisAggregates)) ivarsEqual = false;
            if( ! (_numberOfDisEntities == rhs._numberOfDisEntities)) ivarsEqual = false;
            if( ! (_numberOfSilentAggregateTypes == rhs._numberOfSilentAggregateTypes)) ivarsEqual = false;
            if( ! (_numberOfSilentEntityTypes == rhs._numberOfSilentEntityTypes)) ivarsEqual = false;

            if( ! (_aggregateIDList.Count == rhs._aggregateIDList.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _aggregateIDList.Count; idx++)
                {
                    if( ! ( _aggregateIDList[idx].Equals(rhs._aggregateIDList[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_entityIDList.Count == rhs._entityIDList.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _entityIDList.Count; idx++)
                {
                    if( ! ( _entityIDList[idx].Equals(rhs._entityIDList[idx]))) ivarsEqual = false;
                }
            }

            if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;

            if( ! (_silentAggregateSystemList.Count == rhs._silentAggregateSystemList.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _silentAggregateSystemList.Count; idx++)
                {
                    if( ! ( _silentAggregateSystemList[idx].Equals(rhs._silentAggregateSystemList[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_silentEntitySystemList.Count == rhs._silentEntitySystemList.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _silentEntitySystemList.Count; idx++)
                {
                    if( ! ( _silentEntitySystemList[idx].Equals(rhs._silentEntitySystemList[idx]))) ivarsEqual = false;
                }
            }

            if( ! (_numberOfVariableDatumRecords == rhs._numberOfVariableDatumRecords)) ivarsEqual = false;

            if( ! (_variableDatumList.Count == rhs._variableDatumList.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _variableDatumList.Count; idx++)
                {
                    if( ! ( _variableDatumList[idx].Equals(rhs._variableDatumList[idx]))) ivarsEqual = false;
                }
            }


            return ivarsEqual;
        }

        /**
         * HashCode Helper
         */
        private int GenerateHash(int hash)
        {
            hash = hash << 5 + hash;
            return(hash);
        }


        /**
         * Return Hash
         */
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ _aggregateID.GetHashCode();
            result = GenerateHash(result) ^ _forceID.GetHashCode();
            result = GenerateHash(result) ^ _aggregateState.GetHashCode();
            result = GenerateHash(result) ^ _aggregateType.GetHashCode();
            result = GenerateHash(result) ^ _formation.GetHashCode();
            result = GenerateHash(result) ^ _aggregateMarking.GetHashCode();
            result = GenerateHash(result) ^ _dimensions.GetHashCode();
            result = GenerateHash(result) ^ _orientation.GetHashCode();
            result = GenerateHash(result) ^ _centerOfMass.GetHashCode();
            result = GenerateHash(result) ^ _velocity.GetHashCode();
            result = GenerateHash(result) ^ _numberOfDisAggregates.GetHashCode();
            result = GenerateHash(result) ^ _numberOfDisEntities.GetHashCode();
            result = GenerateHash(result) ^ _numberOfSilentAggregateTypes.GetHashCode();
            result = GenerateHash(result) ^ _numberOfSilentEntityTypes.GetHashCode();

            if(_aggregateIDList.Count > 0)
            {
                for(int idx = 0; idx < _aggregateIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ _aggregateIDList[idx].GetHashCode();
                }
            }


            if(_entityIDList.Count > 0)
            {
                for(int idx = 0; idx < _entityIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ _entityIDList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ _pad2.GetHashCode();

            if(_silentAggregateSystemList.Count > 0)
            {
                for(int idx = 0; idx < _silentAggregateSystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ _silentAggregateSystemList[idx].GetHashCode();
                }
            }


            if(_silentEntitySystemList.Count > 0)
            {
                for(int idx = 0; idx < _silentEntitySystemList.Count; idx++)
                {
                    result = GenerateHash(result) ^ _silentEntitySystemList[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ _numberOfVariableDatumRecords.GetHashCode();

            if(_variableDatumList.Count > 0)
            {
                for(int idx = 0; idx < _variableDatumList.Count; idx++)
                {
                    result = GenerateHash(result) ^ _variableDatumList[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
