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
     * Section 5.3.3.1. Represents the postion and state of one entity in the world. This is identical in function to entity state pdu, but generates less garbage to collect in the Java world. COMPLETE
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
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class FastEntityStatePdu : EntityInformationFamilyPdu
    {
        /** The site ID */
        protected ushort  _site;

        /** The application ID */
        protected ushort  _application;

        /** the entity ID */
        protected ushort  _entity;

        /** what force this entity is affiliated with, eg red, blue, neutral, etc */
        protected byte  _forceId;

        /** How many articulation parameters are in the variable length list */
        protected byte  _numberOfArticulationParameters;

        /** Kind of entity */
        protected byte  _entityKind;

        /** Domain of entity (air, surface, subsurface, space, etc) */
        protected byte  _domain;

        /** country to which the design of the entity is attributed */
        protected ushort  _country;

        /** category of entity */
        protected byte  _category;

        /** subcategory of entity */
        protected byte  _subcategory;

        /** specific info based on subcategory field */
        protected byte  _specific;

        protected byte  _extra;

        /** Kind of entity */
        protected byte  _altEntityKind;

        /** Domain of entity (air, surface, subsurface, space, etc) */
        protected byte  _altDomain;

        /** country to which the design of the entity is attributed */
        protected ushort  _altCountry;

        /** category of entity */
        protected byte  _altCategory;

        /** subcategory of entity */
        protected byte  _altSubcategory;

        /** specific info based on subcategory field */
        protected byte  _altSpecific;

        protected byte  _altExtra;

        /** X velo */
        protected float  _xVelocity;

        /** y Value */
        protected float  _yVelocity;

        /** Z value */
        protected float  _zVelocity;

        /** X value */
        protected double  _xLocation;

        /** y Value */
        protected double  _yLocation;

        /** Z value */
        protected double  _zLocation;

        protected float  _psi;

        protected float  _theta;

        protected float  _phi;

        /** a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc. */
        protected uint  _entityAppearance;

        /** enumeration of what dead reckoning algorighm to use */
        protected byte  _deadReckoningAlgorithm;

        /** other parameters to use in the dead reckoning algorithm */
        protected byte[]  _otherParameters = new byte[15]; 

        /** X value */
        protected float  _xAcceleration;

        /** y Value */
        protected float  _yAcceleration;

        /** Z value */
        protected float  _zAcceleration;

        /** X value */
        protected float  _xAngularVelocity;

        /** y Value */
        protected float  _yAngularVelocity;

        /** Z value */
        protected float  _zAngularVelocity;

        /** characters that can be used for debugging, or to draw unique strings on the side of entities in the world */
        protected byte[]  _marking = new byte[12]; 

        /** a series of bit flags */
        protected uint  _capabilities;

        /** variable length list of articulation parameters */
        protected List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.3.1. Represents the postion and state of one entity in the world. This is identical in function to entity state pdu, but generates less garbage to collect in the Java world. COMPLETE
        ///</summary>
        public FastEntityStatePdu()
        {
            PduType = (byte)1;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + 2;  // _site
            marshalSize = marshalSize + 2;  // _application
            marshalSize = marshalSize + 2;  // _entity
            marshalSize = marshalSize + 1;  // _forceId
            marshalSize = marshalSize + 1;  // _numberOfArticulationParameters
            marshalSize = marshalSize + 1;  // _entityKind
            marshalSize = marshalSize + 1;  // _domain
            marshalSize = marshalSize + 2;  // _country
            marshalSize = marshalSize + 1;  // _category
            marshalSize = marshalSize + 1;  // _subcategory
            marshalSize = marshalSize + 1;  // _specific
            marshalSize = marshalSize + 1;  // _extra
            marshalSize = marshalSize + 1;  // _altEntityKind
            marshalSize = marshalSize + 1;  // _altDomain
            marshalSize = marshalSize + 2;  // _altCountry
            marshalSize = marshalSize + 1;  // _altCategory
            marshalSize = marshalSize + 1;  // _altSubcategory
            marshalSize = marshalSize + 1;  // _altSpecific
            marshalSize = marshalSize + 1;  // _altExtra
            marshalSize = marshalSize + 4;  // _xVelocity
            marshalSize = marshalSize + 4;  // _yVelocity
            marshalSize = marshalSize + 4;  // _zVelocity
            marshalSize = marshalSize + 8;  // _xLocation
            marshalSize = marshalSize + 8;  // _yLocation
            marshalSize = marshalSize + 8;  // _zLocation
            marshalSize = marshalSize + 4;  // _psi
            marshalSize = marshalSize + 4;  // _theta
            marshalSize = marshalSize + 4;  // _phi
            marshalSize = marshalSize + 4;  // _entityAppearance
            marshalSize = marshalSize + 1;  // _deadReckoningAlgorithm
            marshalSize = marshalSize + 15 * 1;  // _otherParameters
            marshalSize = marshalSize + 4;  // _xAcceleration
            marshalSize = marshalSize + 4;  // _yAcceleration
            marshalSize = marshalSize + 4;  // _zAcceleration
            marshalSize = marshalSize + 4;  // _xAngularVelocity
            marshalSize = marshalSize + 4;  // _yAngularVelocity
            marshalSize = marshalSize + 4;  // _zAngularVelocity
            marshalSize = marshalSize + 12 * 1;  // _marking
            marshalSize = marshalSize + 4;  // _capabilities
            for(int idx=0; idx < _articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)_articulationParameters[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///The site ID
        ///</summary>
        public void setSite(ushort pSite)
        { 
            _site = pSite;
        }

        [XmlElement(Type= typeof(ushort), ElementName="site")]
        public ushort Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }

        ///<summary>
        ///The application ID
        ///</summary>
        public void setApplication(ushort pApplication)
        { 
            _application = pApplication;
        }

        [XmlElement(Type= typeof(ushort), ElementName="application")]
        public ushort Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }

        ///<summary>
        ///the entity ID
        ///</summary>
        public void setEntity(ushort pEntity)
        { 
            _entity = pEntity;
        }

        [XmlElement(Type= typeof(ushort), ElementName="entity")]
        public ushort Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }

        ///<summary>
        ///what force this entity is affiliated with, eg red, blue, neutral, etc
        ///</summary>
        public void setForceId(byte pForceId)
        { 
            _forceId = pForceId;
        }

        [XmlElement(Type= typeof(byte), ElementName="forceId")]
        public byte ForceId
        {
            get
            {
                return _forceId;
            }
            set
            {
                _forceId = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfArticulationParameters(byte pNumberOfArticulationParameters)
        {
            _numberOfArticulationParameters = pNumberOfArticulationParameters;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters
        {
            get
            {
                return _numberOfArticulationParameters;
            }
            set
            {
                _numberOfArticulationParameters = value;
            }
        }

        ///<summary>
        ///Kind of entity
        ///</summary>
        public void setEntityKind(byte pEntityKind)
        { 
            _entityKind = pEntityKind;
        }

        [XmlElement(Type= typeof(byte), ElementName="entityKind")]
        public byte EntityKind
        {
            get
            {
                return _entityKind;
            }
            set
            {
                _entityKind = value;
            }
        }

        ///<summary>
        ///Domain of entity (air, surface, subsurface, space, etc)
        ///</summary>
        public void setDomain(byte pDomain)
        { 
            _domain = pDomain;
        }

        [XmlElement(Type= typeof(byte), ElementName="domain")]
        public byte Domain
        {
            get
            {
                return _domain;
            }
            set
            {
                _domain = value;
            }
        }

        ///<summary>
        ///country to which the design of the entity is attributed
        ///</summary>
        public void setCountry(ushort pCountry)
        { 
            _country = pCountry;
        }

        [XmlElement(Type= typeof(ushort), ElementName="country")]
        public ushort Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        ///<summary>
        ///category of entity
        ///</summary>
        public void setCategory(byte pCategory)
        { 
            _category = pCategory;
        }

        [XmlElement(Type= typeof(byte), ElementName="category")]
        public byte Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        ///<summary>
        ///subcategory of entity
        ///</summary>
        public void setSubcategory(byte pSubcategory)
        { 
            _subcategory = pSubcategory;
        }

        [XmlElement(Type= typeof(byte), ElementName="subcategory")]
        public byte Subcategory
        {
            get
            {
                return _subcategory;
            }
            set
            {
                _subcategory = value;
            }
        }

        ///<summary>
        ///specific info based on subcategory field
        ///</summary>
        public void setSpecific(byte pSpecific)
        { 
            _specific = pSpecific;
        }

        [XmlElement(Type= typeof(byte), ElementName="specific")]
        public byte Specific
        {
            get
            {
                return _specific;
            }
            set
            {
                _specific = value;
            }
        }

        public void setExtra(byte pExtra)
        { 
            _extra = pExtra;
        }

        [XmlElement(Type= typeof(byte), ElementName="extra")]
        public byte Extra
        {
            get
            {
                return _extra;
            }
            set
            {
                _extra = value;
            }
        }

        ///<summary>
        ///Kind of entity
        ///</summary>
        public void setAltEntityKind(byte pAltEntityKind)
        { 
            _altEntityKind = pAltEntityKind;
        }

        [XmlElement(Type= typeof(byte), ElementName="altEntityKind")]
        public byte AltEntityKind
        {
            get
            {
                return _altEntityKind;
            }
            set
            {
                _altEntityKind = value;
            }
        }

        ///<summary>
        ///Domain of entity (air, surface, subsurface, space, etc)
        ///</summary>
        public void setAltDomain(byte pAltDomain)
        { 
            _altDomain = pAltDomain;
        }

        [XmlElement(Type= typeof(byte), ElementName="altDomain")]
        public byte AltDomain
        {
            get
            {
                return _altDomain;
            }
            set
            {
                _altDomain = value;
            }
        }

        ///<summary>
        ///country to which the design of the entity is attributed
        ///</summary>
        public void setAltCountry(ushort pAltCountry)
        { 
            _altCountry = pAltCountry;
        }

        [XmlElement(Type= typeof(ushort), ElementName="altCountry")]
        public ushort AltCountry
        {
            get
            {
                return _altCountry;
            }
            set
            {
                _altCountry = value;
            }
        }

        ///<summary>
        ///category of entity
        ///</summary>
        public void setAltCategory(byte pAltCategory)
        { 
            _altCategory = pAltCategory;
        }

        [XmlElement(Type= typeof(byte), ElementName="altCategory")]
        public byte AltCategory
        {
            get
            {
                return _altCategory;
            }
            set
            {
                _altCategory = value;
            }
        }

        ///<summary>
        ///subcategory of entity
        ///</summary>
        public void setAltSubcategory(byte pAltSubcategory)
        { 
            _altSubcategory = pAltSubcategory;
        }

        [XmlElement(Type= typeof(byte), ElementName="altSubcategory")]
        public byte AltSubcategory
        {
            get
            {
                return _altSubcategory;
            }
            set
            {
                _altSubcategory = value;
            }
        }

        ///<summary>
        ///specific info based on subcategory field
        ///</summary>
        public void setAltSpecific(byte pAltSpecific)
        { 
            _altSpecific = pAltSpecific;
        }

        [XmlElement(Type= typeof(byte), ElementName="altSpecific")]
        public byte AltSpecific
        {
            get
            {
                return _altSpecific;
            }
            set
            {
                _altSpecific = value;
            }
        }

        public void setAltExtra(byte pAltExtra)
        { 
            _altExtra = pAltExtra;
        }

        [XmlElement(Type= typeof(byte), ElementName="altExtra")]
        public byte AltExtra
        {
            get
            {
                return _altExtra;
            }
            set
            {
                _altExtra = value;
            }
        }

        ///<summary>
        ///X velo
        ///</summary>
        public void setXVelocity(float pXVelocity)
        { 
            _xVelocity = pXVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="xVelocity")]
        public float XVelocity
        {
            get
            {
                return _xVelocity;
            }
            set
            {
                _xVelocity = value;
            }
        }

        ///<summary>
        ///y Value
        ///</summary>
        public void setYVelocity(float pYVelocity)
        { 
            _yVelocity = pYVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="yVelocity")]
        public float YVelocity
        {
            get
            {
                return _yVelocity;
            }
            set
            {
                _yVelocity = value;
            }
        }

        ///<summary>
        ///Z value
        ///</summary>
        public void setZVelocity(float pZVelocity)
        { 
            _zVelocity = pZVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="zVelocity")]
        public float ZVelocity
        {
            get
            {
                return _zVelocity;
            }
            set
            {
                _zVelocity = value;
            }
        }

        ///<summary>
        ///X value
        ///</summary>
        public void setXLocation(double pXLocation)
        { 
            _xLocation = pXLocation;
        }

        [XmlElement(Type= typeof(double), ElementName="xLocation")]
        public double XLocation
        {
            get
            {
                return _xLocation;
            }
            set
            {
                _xLocation = value;
            }
        }

        ///<summary>
        ///y Value
        ///</summary>
        public void setYLocation(double pYLocation)
        { 
            _yLocation = pYLocation;
        }

        [XmlElement(Type= typeof(double), ElementName="yLocation")]
        public double YLocation
        {
            get
            {
                return _yLocation;
            }
            set
            {
                _yLocation = value;
            }
        }

        ///<summary>
        ///Z value
        ///</summary>
        public void setZLocation(double pZLocation)
        { 
            _zLocation = pZLocation;
        }

        [XmlElement(Type= typeof(double), ElementName="zLocation")]
        public double ZLocation
        {
            get
            {
                return _zLocation;
            }
            set
            {
                _zLocation = value;
            }
        }

        public void setPsi(float pPsi)
        { 
            _psi = pPsi;
        }

        [XmlElement(Type= typeof(float), ElementName="psi")]
        public float Psi
        {
            get
            {
                return _psi;
            }
            set
            {
                _psi = value;
            }
        }

        public void setTheta(float pTheta)
        { 
            _theta = pTheta;
        }

        [XmlElement(Type= typeof(float), ElementName="theta")]
        public float Theta
        {
            get
            {
                return _theta;
            }
            set
            {
                _theta = value;
            }
        }

        public void setPhi(float pPhi)
        { 
            _phi = pPhi;
        }

        [XmlElement(Type= typeof(float), ElementName="phi")]
        public float Phi
        {
            get
            {
                return _phi;
            }
            set
            {
                _phi = value;
            }
        }

        ///<summary>
        ///a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        ///</summary>
        public void setEntityAppearance(uint pEntityAppearance)
        { 
            _entityAppearance = pEntityAppearance;
        }

        [XmlElement(Type= typeof(uint), ElementName="entityAppearance")]
        public uint EntityAppearance
        {
            get
            {
                return _entityAppearance;
            }
            set
            {
                _entityAppearance = value;
            }
        }

        ///<summary>
        ///enumeration of what dead reckoning algorighm to use
        ///</summary>
        public void setDeadReckoningAlgorithm(byte pDeadReckoningAlgorithm)
        { 
            _deadReckoningAlgorithm = pDeadReckoningAlgorithm;
        }

        [XmlElement(Type= typeof(byte), ElementName="deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm
        {
            get
            {
                return _deadReckoningAlgorithm;
            }
            set
            {
                _deadReckoningAlgorithm = value;
            }
        }

        ///<summary>
        ///other parameters to use in the dead reckoning algorithm
        ///</summary>
        public void setOtherParameters(byte[] pOtherParameters)
        {
            _otherParameters = pOtherParameters;
        }

        ///<summary>
        ///other parameters to use in the dead reckoning algorithm
        ///</summary>
        public byte[] getOtherParameters()
        {
            return _otherParameters;
        }

        ///<summary>
        ///other parameters to use in the dead reckoning algorithm
        ///</summary>
        [XmlArray(ElementName="otherParameters")]
        public byte[] OtherParameters
        {
            get
            {
                return _otherParameters;
            }
            set
            {
                _otherParameters = value;
            }
}

        ///<summary>
        ///X value
        ///</summary>
        public void setXAcceleration(float pXAcceleration)
        { 
            _xAcceleration = pXAcceleration;
        }

        [XmlElement(Type= typeof(float), ElementName="xAcceleration")]
        public float XAcceleration
        {
            get
            {
                return _xAcceleration;
            }
            set
            {
                _xAcceleration = value;
            }
        }

        ///<summary>
        ///y Value
        ///</summary>
        public void setYAcceleration(float pYAcceleration)
        { 
            _yAcceleration = pYAcceleration;
        }

        [XmlElement(Type= typeof(float), ElementName="yAcceleration")]
        public float YAcceleration
        {
            get
            {
                return _yAcceleration;
            }
            set
            {
                _yAcceleration = value;
            }
        }

        ///<summary>
        ///Z value
        ///</summary>
        public void setZAcceleration(float pZAcceleration)
        { 
            _zAcceleration = pZAcceleration;
        }

        [XmlElement(Type= typeof(float), ElementName="zAcceleration")]
        public float ZAcceleration
        {
            get
            {
                return _zAcceleration;
            }
            set
            {
                _zAcceleration = value;
            }
        }

        ///<summary>
        ///X value
        ///</summary>
        public void setXAngularVelocity(float pXAngularVelocity)
        { 
            _xAngularVelocity = pXAngularVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="xAngularVelocity")]
        public float XAngularVelocity
        {
            get
            {
                return _xAngularVelocity;
            }
            set
            {
                _xAngularVelocity = value;
            }
        }

        ///<summary>
        ///y Value
        ///</summary>
        public void setYAngularVelocity(float pYAngularVelocity)
        { 
            _yAngularVelocity = pYAngularVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="yAngularVelocity")]
        public float YAngularVelocity
        {
            get
            {
                return _yAngularVelocity;
            }
            set
            {
                _yAngularVelocity = value;
            }
        }

        ///<summary>
        ///Z value
        ///</summary>
        public void setZAngularVelocity(float pZAngularVelocity)
        { 
            _zAngularVelocity = pZAngularVelocity;
        }

        [XmlElement(Type= typeof(float), ElementName="zAngularVelocity")]
        public float ZAngularVelocity
        {
            get
            {
                return _zAngularVelocity;
            }
            set
            {
                _zAngularVelocity = value;
            }
        }

        ///<summary>
        ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        ///</summary>
        public void setMarking(byte[] pMarking)
        {
            _marking = pMarking;
        }

        ///<summary>
        ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        ///</summary>
        public byte[] getMarking()
        {
            return _marking;
        }

        ///<summary>
        ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        ///</summary>
        [XmlArray(ElementName="marking")]
        public byte[] Marking
        {
            get
            {
                return _marking;
            }
            set
            {
                _marking = value;
            }
}

        ///<summary>
        ///a series of bit flags
        ///</summary>
        public void setCapabilities(uint pCapabilities)
        { 
            _capabilities = pCapabilities;
        }

        [XmlElement(Type= typeof(uint), ElementName="capabilities")]
        public uint Capabilities
        {
            get
            {
                return _capabilities;
            }
            set
            {
                _capabilities = value;
            }
        }

        ///<summary>
        ///variable length list of articulation parameters
        ///</summary>
        public void setArticulationParameters(List<ArticulationParameter> pArticulationParameters)
        {
            _articulationParameters = pArticulationParameters;
        }

        ///<summary>
        ///variable length list of articulation parameters
        ///</summary>
        public List<ArticulationParameter> getArticulationParameters()
        {
            return _articulationParameters;
        }

        ///<summary>
        ///variable length list of articulation parameters
        ///</summary>
        [XmlElement(ElementName = "articulationParametersList",Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters
        {
            get
            {
                return _articulationParameters;
            }
            set
            {
                _articulationParameters = value;
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
                dos.writeUshort((ushort)_site);
                dos.writeUshort((ushort)_application);
                dos.writeUshort((ushort)_entity);
                dos.writeByte((byte)_forceId);
                dos.writeByte((byte)_articulationParameters.Count);
                dos.writeByte((byte)_entityKind);
                dos.writeByte((byte)_domain);
                dos.writeUshort((ushort)_country);
                dos.writeByte((byte)_category);
                dos.writeByte((byte)_subcategory);
                dos.writeByte((byte)_specific);
                dos.writeByte((byte)_extra);
                dos.writeByte((byte)_altEntityKind);
                dos.writeByte((byte)_altDomain);
                dos.writeUshort((ushort)_altCountry);
                dos.writeByte((byte)_altCategory);
                dos.writeByte((byte)_altSubcategory);
                dos.writeByte((byte)_altSpecific);
                dos.writeByte((byte)_altExtra);
                dos.writeFloat((float)_xVelocity);
                dos.writeFloat((float)_yVelocity);
                dos.writeFloat((float)_zVelocity);
                dos.writeDouble((double)_xLocation);
                dos.writeDouble((double)_yLocation);
                dos.writeDouble((double)_zLocation);
                dos.writeFloat((float)_psi);
                dos.writeFloat((float)_theta);
                dos.writeFloat((float)_phi);
                dos.writeUint((uint)_entityAppearance);
                dos.writeByte((byte)_deadReckoningAlgorithm);

                for(int idx = 0; idx < _otherParameters.Length; idx++)
                {
                    dos.writeByte(_otherParameters[idx]);
                } // end of array marshaling

                dos.writeFloat((float)_xAcceleration);
                dos.writeFloat((float)_yAcceleration);
                dos.writeFloat((float)_zAcceleration);
                dos.writeFloat((float)_xAngularVelocity);
                dos.writeFloat((float)_yAngularVelocity);
                dos.writeFloat((float)_zAngularVelocity);

                for(int idx = 0; idx < _marking.Length; idx++)
                {
                    dos.writeByte(_marking[idx]);
                } // end of array marshaling

                dos.writeUint((uint)_capabilities);

                for(int idx = 0; idx < _articulationParameters.Count; idx++)
                {
                    ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
                    aArticulationParameter.marshal(dos);
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
                _site = dis.readUshort();
                _application = dis.readUshort();
                _entity = dis.readUshort();
                _forceId = dis.readByte();
                _numberOfArticulationParameters = dis.readByte();
                _entityKind = dis.readByte();
                _domain = dis.readByte();
                _country = dis.readUshort();
                _category = dis.readByte();
                _subcategory = dis.readByte();
                _specific = dis.readByte();
                _extra = dis.readByte();
                _altEntityKind = dis.readByte();
                _altDomain = dis.readByte();
                _altCountry = dis.readUshort();
                _altCategory = dis.readByte();
                _altSubcategory = dis.readByte();
                _altSpecific = dis.readByte();
                _altExtra = dis.readByte();
                _xVelocity = dis.readFloat();
                _yVelocity = dis.readFloat();
                _zVelocity = dis.readFloat();
                _xLocation = dis.readDouble();
                _yLocation = dis.readDouble();
                _zLocation = dis.readDouble();
                _psi = dis.readFloat();
                _theta = dis.readFloat();
                _phi = dis.readFloat();
                _entityAppearance = dis.readUint();
                _deadReckoningAlgorithm = dis.readByte();
                for(int idx = 0; idx < _otherParameters.Length; idx++)
                {
                    _otherParameters[idx] = dis.readByte();
                } // end of array unmarshaling
                _xAcceleration = dis.readFloat();
                _yAcceleration = dis.readFloat();
                _zAcceleration = dis.readFloat();
                _xAngularVelocity = dis.readFloat();
                _yAngularVelocity = dis.readFloat();
                _zAngularVelocity = dis.readFloat();
                for(int idx = 0; idx < _marking.Length; idx++)
                {
                    _marking[idx] = dis.readByte();
                } // end of array unmarshaling
                _capabilities = dis.readUint();
                for(int idx = 0; idx < _numberOfArticulationParameters; idx++)
                {
                    ArticulationParameter anX = new ArticulationParameter();
                    anX.unmarshal(dis);
                    _articulationParameters.Add(anX);
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
            sb.Append("<FastEntityStatePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<site type=\"ushort\">" + _site.ToString() + "</site> " + System.Environment.NewLine);
                sb.Append("<application type=\"ushort\">" + _application.ToString() + "</application> " + System.Environment.NewLine);
                sb.Append("<entity type=\"ushort\">" + _entity.ToString() + "</entity> " + System.Environment.NewLine);
                sb.Append("<forceId type=\"byte\">" + _forceId.ToString() + "</forceId> " + System.Environment.NewLine);
                sb.Append("<articulationParameters type=\"byte\">" + _articulationParameters.Count.ToString() + "</articulationParameters> " + System.Environment.NewLine);
                sb.Append("<entityKind type=\"byte\">" + _entityKind.ToString() + "</entityKind> " + System.Environment.NewLine);
                sb.Append("<domain type=\"byte\">" + _domain.ToString() + "</domain> " + System.Environment.NewLine);
                sb.Append("<country type=\"ushort\">" + _country.ToString() + "</country> " + System.Environment.NewLine);
                sb.Append("<category type=\"byte\">" + _category.ToString() + "</category> " + System.Environment.NewLine);
                sb.Append("<subcategory type=\"byte\">" + _subcategory.ToString() + "</subcategory> " + System.Environment.NewLine);
                sb.Append("<specific type=\"byte\">" + _specific.ToString() + "</specific> " + System.Environment.NewLine);
                sb.Append("<extra type=\"byte\">" + _extra.ToString() + "</extra> " + System.Environment.NewLine);
                sb.Append("<altEntityKind type=\"byte\">" + _altEntityKind.ToString() + "</altEntityKind> " + System.Environment.NewLine);
                sb.Append("<altDomain type=\"byte\">" + _altDomain.ToString() + "</altDomain> " + System.Environment.NewLine);
                sb.Append("<altCountry type=\"ushort\">" + _altCountry.ToString() + "</altCountry> " + System.Environment.NewLine);
                sb.Append("<altCategory type=\"byte\">" + _altCategory.ToString() + "</altCategory> " + System.Environment.NewLine);
                sb.Append("<altSubcategory type=\"byte\">" + _altSubcategory.ToString() + "</altSubcategory> " + System.Environment.NewLine);
                sb.Append("<altSpecific type=\"byte\">" + _altSpecific.ToString() + "</altSpecific> " + System.Environment.NewLine);
                sb.Append("<altExtra type=\"byte\">" + _altExtra.ToString() + "</altExtra> " + System.Environment.NewLine);
                sb.Append("<xVelocity type=\"float\">" + _xVelocity.ToString() + "</xVelocity> " + System.Environment.NewLine);
                sb.Append("<yVelocity type=\"float\">" + _yVelocity.ToString() + "</yVelocity> " + System.Environment.NewLine);
                sb.Append("<zVelocity type=\"float\">" + _zVelocity.ToString() + "</zVelocity> " + System.Environment.NewLine);
                sb.Append("<xLocation type=\"double\">" + _xLocation.ToString() + "</xLocation> " + System.Environment.NewLine);
                sb.Append("<yLocation type=\"double\">" + _yLocation.ToString() + "</yLocation> " + System.Environment.NewLine);
                sb.Append("<zLocation type=\"double\">" + _zLocation.ToString() + "</zLocation> " + System.Environment.NewLine);
                sb.Append("<psi type=\"float\">" + _psi.ToString() + "</psi> " + System.Environment.NewLine);
                sb.Append("<theta type=\"float\">" + _theta.ToString() + "</theta> " + System.Environment.NewLine);
                sb.Append("<phi type=\"float\">" + _phi.ToString() + "</phi> " + System.Environment.NewLine);
                sb.Append("<entityAppearance type=\"uint\">" + _entityAppearance.ToString() + "</entityAppearance> " + System.Environment.NewLine);
                sb.Append("<deadReckoningAlgorithm type=\"byte\">" + _deadReckoningAlgorithm.ToString() + "</deadReckoningAlgorithm> " + System.Environment.NewLine);

                for(int idx = 0; idx < _otherParameters.Length; idx++)
                {
                sb.Append("<otherParameters"+ idx.ToString() + " type=\"byte\">" + _otherParameters[idx] + "</otherParameters"+ idx.ToString() + "> " + System.Environment.NewLine);
            } // end of array reflection

                sb.Append("<xAcceleration type=\"float\">" + _xAcceleration.ToString() + "</xAcceleration> " + System.Environment.NewLine);
                sb.Append("<yAcceleration type=\"float\">" + _yAcceleration.ToString() + "</yAcceleration> " + System.Environment.NewLine);
                sb.Append("<zAcceleration type=\"float\">" + _zAcceleration.ToString() + "</zAcceleration> " + System.Environment.NewLine);
                sb.Append("<xAngularVelocity type=\"float\">" + _xAngularVelocity.ToString() + "</xAngularVelocity> " + System.Environment.NewLine);
                sb.Append("<yAngularVelocity type=\"float\">" + _yAngularVelocity.ToString() + "</yAngularVelocity> " + System.Environment.NewLine);
                sb.Append("<zAngularVelocity type=\"float\">" + _zAngularVelocity.ToString() + "</zAngularVelocity> " + System.Environment.NewLine);

                for(int idx = 0; idx < _marking.Length; idx++)
                {
                sb.Append("<marking"+ idx.ToString() + " type=\"byte\">" + _marking[idx] + "</marking"+ idx.ToString() + "> " + System.Environment.NewLine);
            } // end of array reflection

                sb.Append("<capabilities type=\"uint\">" + _capabilities.ToString() + "</capabilities> " + System.Environment.NewLine);

            for(int idx = 0; idx < _articulationParameters.Count; idx++)
            {
                sb.Append("<articulationParameters"+ idx.ToString() + " type=\"ArticulationParameter\">" + System.Environment.NewLine);
                ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
                aArticulationParameter.reflection(sb);
                sb.Append("</articulationParameters"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</FastEntityStatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(FastEntityStatePdu a, FastEntityStatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(FastEntityStatePdu a, FastEntityStatePdu b)
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
            return this == obj as FastEntityStatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(FastEntityStatePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_site == rhs._site)) ivarsEqual = false;
            if( ! (_application == rhs._application)) ivarsEqual = false;
            if( ! (_entity == rhs._entity)) ivarsEqual = false;
            if( ! (_forceId == rhs._forceId)) ivarsEqual = false;
            if( ! (_numberOfArticulationParameters == rhs._numberOfArticulationParameters)) ivarsEqual = false;
            if( ! (_entityKind == rhs._entityKind)) ivarsEqual = false;
            if( ! (_domain == rhs._domain)) ivarsEqual = false;
            if( ! (_country == rhs._country)) ivarsEqual = false;
            if( ! (_category == rhs._category)) ivarsEqual = false;
            if( ! (_subcategory == rhs._subcategory)) ivarsEqual = false;
            if( ! (_specific == rhs._specific)) ivarsEqual = false;
            if( ! (_extra == rhs._extra)) ivarsEqual = false;
            if( ! (_altEntityKind == rhs._altEntityKind)) ivarsEqual = false;
            if( ! (_altDomain == rhs._altDomain)) ivarsEqual = false;
            if( ! (_altCountry == rhs._altCountry)) ivarsEqual = false;
            if( ! (_altCategory == rhs._altCategory)) ivarsEqual = false;
            if( ! (_altSubcategory == rhs._altSubcategory)) ivarsEqual = false;
            if( ! (_altSpecific == rhs._altSpecific)) ivarsEqual = false;
            if( ! (_altExtra == rhs._altExtra)) ivarsEqual = false;
            if( ! (_xVelocity == rhs._xVelocity)) ivarsEqual = false;
            if( ! (_yVelocity == rhs._yVelocity)) ivarsEqual = false;
            if( ! (_zVelocity == rhs._zVelocity)) ivarsEqual = false;
            if( ! (_xLocation == rhs._xLocation)) ivarsEqual = false;
            if( ! (_yLocation == rhs._yLocation)) ivarsEqual = false;
            if( ! (_zLocation == rhs._zLocation)) ivarsEqual = false;
            if( ! (_psi == rhs._psi)) ivarsEqual = false;
            if( ! (_theta == rhs._theta)) ivarsEqual = false;
            if( ! (_phi == rhs._phi)) ivarsEqual = false;
            if( ! (_entityAppearance == rhs._entityAppearance)) ivarsEqual = false;
            if( ! (_deadReckoningAlgorithm == rhs._deadReckoningAlgorithm)) ivarsEqual = false;

            if( ! (rhs._otherParameters.Length == 15)) ivarsEqual = false;
            if(ivarsEqual)
            {

                for(int idx = 0; idx < 15; idx++)
                {
                    if(!(_otherParameters[idx] == rhs._otherParameters[idx])) ivarsEqual = false;
                }
            }

            if( ! (_xAcceleration == rhs._xAcceleration)) ivarsEqual = false;
            if( ! (_yAcceleration == rhs._yAcceleration)) ivarsEqual = false;
            if( ! (_zAcceleration == rhs._zAcceleration)) ivarsEqual = false;
            if( ! (_xAngularVelocity == rhs._xAngularVelocity)) ivarsEqual = false;
            if( ! (_yAngularVelocity == rhs._yAngularVelocity)) ivarsEqual = false;
            if( ! (_zAngularVelocity == rhs._zAngularVelocity)) ivarsEqual = false;

            if( ! (rhs._marking.Length == 12)) ivarsEqual = false;
            if(ivarsEqual)
            {

                for(int idx = 0; idx < 12; idx++)
                {
                    if(!(_marking[idx] == rhs._marking[idx])) ivarsEqual = false;
                }
            }

            if( ! (_capabilities == rhs._capabilities)) ivarsEqual = false;

            if( ! (_articulationParameters.Count == rhs._articulationParameters.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _articulationParameters.Count; idx++)
                {
                    if( ! ( _articulationParameters[idx].Equals(rhs._articulationParameters[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _site.GetHashCode();
            result = GenerateHash(result) ^ _application.GetHashCode();
            result = GenerateHash(result) ^ _entity.GetHashCode();
            result = GenerateHash(result) ^ _forceId.GetHashCode();
            result = GenerateHash(result) ^ _numberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ _entityKind.GetHashCode();
            result = GenerateHash(result) ^ _domain.GetHashCode();
            result = GenerateHash(result) ^ _country.GetHashCode();
            result = GenerateHash(result) ^ _category.GetHashCode();
            result = GenerateHash(result) ^ _subcategory.GetHashCode();
            result = GenerateHash(result) ^ _specific.GetHashCode();
            result = GenerateHash(result) ^ _extra.GetHashCode();
            result = GenerateHash(result) ^ _altEntityKind.GetHashCode();
            result = GenerateHash(result) ^ _altDomain.GetHashCode();
            result = GenerateHash(result) ^ _altCountry.GetHashCode();
            result = GenerateHash(result) ^ _altCategory.GetHashCode();
            result = GenerateHash(result) ^ _altSubcategory.GetHashCode();
            result = GenerateHash(result) ^ _altSpecific.GetHashCode();
            result = GenerateHash(result) ^ _altExtra.GetHashCode();
            result = GenerateHash(result) ^ _xVelocity.GetHashCode();
            result = GenerateHash(result) ^ _yVelocity.GetHashCode();
            result = GenerateHash(result) ^ _zVelocity.GetHashCode();
            result = GenerateHash(result) ^ _xLocation.GetHashCode();
            result = GenerateHash(result) ^ _yLocation.GetHashCode();
            result = GenerateHash(result) ^ _zLocation.GetHashCode();
            result = GenerateHash(result) ^ _psi.GetHashCode();
            result = GenerateHash(result) ^ _theta.GetHashCode();
            result = GenerateHash(result) ^ _phi.GetHashCode();
            result = GenerateHash(result) ^ _entityAppearance.GetHashCode();
            result = GenerateHash(result) ^ _deadReckoningAlgorithm.GetHashCode();

            if(15 > 0)
            {

                for(int idx = 0; idx < 15; idx++)
                {
                    result = GenerateHash(result) ^ _otherParameters[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ _xAcceleration.GetHashCode();
            result = GenerateHash(result) ^ _yAcceleration.GetHashCode();
            result = GenerateHash(result) ^ _zAcceleration.GetHashCode();
            result = GenerateHash(result) ^ _xAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ _yAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ _zAngularVelocity.GetHashCode();

            if(12 > 0)
            {

                for(int idx = 0; idx < 12; idx++)
                {
                    result = GenerateHash(result) ^ _marking[idx].GetHashCode();
                }
            }

            result = GenerateHash(result) ^ _capabilities.GetHashCode();

            if(_articulationParameters.Count > 0)
            {
                for(int idx = 0; idx < _articulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ _articulationParameters[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
