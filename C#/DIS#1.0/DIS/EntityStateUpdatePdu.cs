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
     * 5.3.3.4. Nonstatic information about a particular entity may be communicated by issuing an Entity State Update PDU. COMPLETE
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
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class EntityStateUpdatePdu : EntityInformationFamilyPdu
    {
        /** This field shall identify the entity issuing the PDU */
        protected EntityID  _entityID = new EntityID(); 

        /** Padding */
        protected byte  _padding1;

        /** How many articulation parameters are in the variable length list */
        protected byte  _numberOfArticulationParameters;

        /** Describes the speed of the entity in the world */
        protected Vector3Float  _entityLinearVelocity = new Vector3Float(); 

        /** describes the location of the entity in the world */
        protected Vector3Double  _entityLocation = new Vector3Double(); 

        /** describes the orientation of the entity, in euler angles */
        protected Orientation  _entityOrientation = new Orientation(); 

        /** a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc. */
        protected uint  _entityAppearance;

        protected List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>(); 

        /** Constructor */
        ///<summary>
        ///5.3.3.4. Nonstatic information about a particular entity may be communicated by issuing an Entity State Update PDU. COMPLETE
        ///</summary>
        public EntityStateUpdatePdu()
        {
            PduType = (byte)67;
            ProtocolFamily = (byte)1;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _entityID.getMarshalledSize();  // _entityID
            marshalSize = marshalSize + 1;  // _padding1
            marshalSize = marshalSize + 1;  // _numberOfArticulationParameters
            marshalSize = marshalSize + _entityLinearVelocity.getMarshalledSize();  // _entityLinearVelocity
            marshalSize = marshalSize + _entityLocation.getMarshalledSize();  // _entityLocation
            marshalSize = marshalSize + _entityOrientation.getMarshalledSize();  // _entityOrientation
            marshalSize = marshalSize + 4;  // _entityAppearance
            for(int idx=0; idx < _articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)_articulationParameters[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///This field shall identify the entity issuing the PDU
        ///</summary>
        public void setEntityID(EntityID pEntityID)
        { 
            _entityID = pEntityID;
        }

        ///<summary>
        ///This field shall identify the entity issuing the PDU
        ///</summary>
        public EntityID getEntityID()
        {
            return _entityID;
        }

        ///<summary>
        ///This field shall identify the entity issuing the PDU
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="entityID")]
        public EntityID EntityID
        {
            get
            {
                return _entityID;
            }
            set
            {
                _entityID = value;
            }
        }

        ///<summary>
        ///Padding
        ///</summary>
        public void setPadding1(byte pPadding1)
        { 
            _padding1 = pPadding1;
        }

        [XmlElement(Type= typeof(byte), ElementName="padding1")]
        public byte Padding1
        {
            get
            {
                return _padding1;
            }
            set
            {
                _padding1 = value;
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
        ///Describes the speed of the entity in the world
        ///</summary>
        public void setEntityLinearVelocity(Vector3Float pEntityLinearVelocity)
        { 
            _entityLinearVelocity = pEntityLinearVelocity;
        }

        ///<summary>
        ///Describes the speed of the entity in the world
        ///</summary>
        public Vector3Float getEntityLinearVelocity()
        {
            return _entityLinearVelocity;
        }

        ///<summary>
        ///Describes the speed of the entity in the world
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="entityLinearVelocity")]
        public Vector3Float EntityLinearVelocity
        {
            get
            {
                return _entityLinearVelocity;
            }
            set
            {
                _entityLinearVelocity = value;
            }
        }

        ///<summary>
        ///describes the location of the entity in the world
        ///</summary>
        public void setEntityLocation(Vector3Double pEntityLocation)
        { 
            _entityLocation = pEntityLocation;
        }

        ///<summary>
        ///describes the location of the entity in the world
        ///</summary>
        public Vector3Double getEntityLocation()
        {
            return _entityLocation;
        }

        ///<summary>
        ///describes the location of the entity in the world
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="entityLocation")]
        public Vector3Double EntityLocation
        {
            get
            {
                return _entityLocation;
            }
            set
            {
                _entityLocation = value;
            }
        }

        ///<summary>
        ///describes the orientation of the entity, in euler angles
        ///</summary>
        public void setEntityOrientation(Orientation pEntityOrientation)
        { 
            _entityOrientation = pEntityOrientation;
        }

        ///<summary>
        ///describes the orientation of the entity, in euler angles
        ///</summary>
        public Orientation getEntityOrientation()
        {
            return _entityOrientation;
        }

        ///<summary>
        ///describes the orientation of the entity, in euler angles
        ///</summary>
        [XmlElement(Type= typeof(Orientation), ElementName="entityOrientation")]
        public Orientation EntityOrientation
        {
            get
            {
                return _entityOrientation;
            }
            set
            {
                _entityOrientation = value;
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

        public void setArticulationParameters(List<ArticulationParameter> pArticulationParameters)
        {
            _articulationParameters = pArticulationParameters;
        }

        public List<ArticulationParameter> getArticulationParameters()
        {
            return _articulationParameters;
        }

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
                _entityID.marshal(dos);
                dos.writeByte((byte)_padding1);
                dos.writeByte((byte)_articulationParameters.Count);
                _entityLinearVelocity.marshal(dos);
                _entityLocation.marshal(dos);
                _entityOrientation.marshal(dos);
                dos.writeUint((uint)_entityAppearance);

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
                _entityID.unmarshal(dis);
                _padding1 = dis.readByte();
                _numberOfArticulationParameters = dis.readByte();
                _entityLinearVelocity.unmarshal(dis);
                _entityLocation.unmarshal(dis);
                _entityOrientation.unmarshal(dis);
                _entityAppearance = dis.readUint();
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
            sb.Append("<EntityStateUpdatePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<entityID>"  + System.Environment.NewLine);
                _entityID.reflection(sb);
                sb.Append("</entityID>"  + System.Environment.NewLine);
                sb.Append("<padding1 type=\"byte\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
                sb.Append("<articulationParameters type=\"byte\">" + _articulationParameters.Count.ToString() + "</articulationParameters> " + System.Environment.NewLine);
                sb.Append("<entityLinearVelocity>"  + System.Environment.NewLine);
                _entityLinearVelocity.reflection(sb);
                sb.Append("</entityLinearVelocity>"  + System.Environment.NewLine);
                sb.Append("<entityLocation>"  + System.Environment.NewLine);
                _entityLocation.reflection(sb);
                sb.Append("</entityLocation>"  + System.Environment.NewLine);
                sb.Append("<entityOrientation>"  + System.Environment.NewLine);
                _entityOrientation.reflection(sb);
                sb.Append("</entityOrientation>"  + System.Environment.NewLine);
                sb.Append("<entityAppearance type=\"uint\">" + _entityAppearance.ToString() + "</entityAppearance> " + System.Environment.NewLine);

            for(int idx = 0; idx < _articulationParameters.Count; idx++)
            {
                sb.Append("<articulationParameters"+ idx.ToString() + " type=\"ArticulationParameter\">" + System.Environment.NewLine);
                ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
                aArticulationParameter.reflection(sb);
                sb.Append("</articulationParameters"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</EntityStateUpdatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(EntityStateUpdatePdu a, EntityStateUpdatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(EntityStateUpdatePdu a, EntityStateUpdatePdu b)
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
            return this == obj as EntityStateUpdatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(EntityStateUpdatePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_entityID.Equals( rhs._entityID) )) ivarsEqual = false;
            if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
            if( ! (_numberOfArticulationParameters == rhs._numberOfArticulationParameters)) ivarsEqual = false;
            if( ! (_entityLinearVelocity.Equals( rhs._entityLinearVelocity) )) ivarsEqual = false;
            if( ! (_entityLocation.Equals( rhs._entityLocation) )) ivarsEqual = false;
            if( ! (_entityOrientation.Equals( rhs._entityOrientation) )) ivarsEqual = false;
            if( ! (_entityAppearance == rhs._entityAppearance)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _entityID.GetHashCode();
            result = GenerateHash(result) ^ _padding1.GetHashCode();
            result = GenerateHash(result) ^ _numberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ _entityLinearVelocity.GetHashCode();
            result = GenerateHash(result) ^ _entityLocation.GetHashCode();
            result = GenerateHash(result) ^ _entityOrientation.GetHashCode();
            result = GenerateHash(result) ^ _entityAppearance.GetHashCode();

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
