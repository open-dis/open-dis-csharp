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
     * Section 5.3.3.2. Information about a collision. COMPLETE
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
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class CollisionPdu : EntityInformationFamilyPdu
    {
        /** ID of the entity that issued the collision PDU */
        protected EntityID  _issuingEntityID = new EntityID(); 

        /** ID of entity that has collided with the issuing entity ID */
        protected EntityID  _collidingEntityID = new EntityID(); 

        /** ID of event */
        protected EventID  _eventID = new EventID(); 

        /** ID of event */
        protected byte  _collisionType;

        /** some padding */
        protected byte  _pad = 0;

        /** velocity at collision */
        protected Vector3Float  _velocity = new Vector3Float(); 

        /** mass of issuing entity */
        protected float  _mass;

        /** Location with respect to entity the issuing entity collided with */
        protected Vector3Float  _location = new Vector3Float(); 


        /** Constructor */
        ///<summary>
        ///Section 5.3.3.2. Information about a collision. COMPLETE
        ///</summary>
        public CollisionPdu()
        {
            PduType = (byte)4;
            ProtocolFamily = (byte)1;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _issuingEntityID.getMarshalledSize();  // _issuingEntityID
            marshalSize = marshalSize + _collidingEntityID.getMarshalledSize();  // _collidingEntityID
            marshalSize = marshalSize + _eventID.getMarshalledSize();  // _eventID
            marshalSize = marshalSize + 1;  // _collisionType
            marshalSize = marshalSize + 1;  // _pad
            marshalSize = marshalSize + _velocity.getMarshalledSize();  // _velocity
            marshalSize = marshalSize + 4;  // _mass
            marshalSize = marshalSize + _location.getMarshalledSize();  // _location

            return marshalSize;
        }


        ///<summary>
        ///ID of the entity that issued the collision PDU
        ///</summary>
        public void setIssuingEntityID(EntityID pIssuingEntityID)
        { 
            _issuingEntityID = pIssuingEntityID;
        }

        ///<summary>
        ///ID of the entity that issued the collision PDU
        ///</summary>
        public EntityID getIssuingEntityID()
        {
            return _issuingEntityID;
        }

        ///<summary>
        ///ID of the entity that issued the collision PDU
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="issuingEntityID")]
        public EntityID IssuingEntityID
        {
            get
            {
                return _issuingEntityID;
            }
            set
            {
                _issuingEntityID = value;
            }
        }

        ///<summary>
        ///ID of entity that has collided with the issuing entity ID
        ///</summary>
        public void setCollidingEntityID(EntityID pCollidingEntityID)
        { 
            _collidingEntityID = pCollidingEntityID;
        }

        ///<summary>
        ///ID of entity that has collided with the issuing entity ID
        ///</summary>
        public EntityID getCollidingEntityID()
        {
            return _collidingEntityID;
        }

        ///<summary>
        ///ID of entity that has collided with the issuing entity ID
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="collidingEntityID")]
        public EntityID CollidingEntityID
        {
            get
            {
                return _collidingEntityID;
            }
            set
            {
                _collidingEntityID = value;
            }
        }

        ///<summary>
        ///ID of event
        ///</summary>
        public void setEventID(EventID pEventID)
        { 
            _eventID = pEventID;
        }

        ///<summary>
        ///ID of event
        ///</summary>
        public EventID getEventID()
        {
            return _eventID;
        }

        ///<summary>
        ///ID of event
        ///</summary>
        [XmlElement(Type= typeof(EventID), ElementName="eventID")]
        public EventID EventID
        {
            get
            {
                return _eventID;
            }
            set
            {
                _eventID = value;
            }
        }

        ///<summary>
        ///ID of event
        ///</summary>
        public void setCollisionType(byte pCollisionType)
        { 
            _collisionType = pCollisionType;
        }

        [XmlElement(Type= typeof(byte), ElementName="collisionType")]
        public byte CollisionType
        {
            get
            {
                return _collisionType;
            }
            set
            {
                _collisionType = value;
            }
        }

        ///<summary>
        ///some padding
        ///</summary>
        public void setPad(byte pPad)
        { 
            _pad = pPad;
        }

        [XmlElement(Type= typeof(byte), ElementName="pad")]
        public byte Pad
        {
            get
            {
                return _pad;
            }
            set
            {
                _pad = value;
            }
        }

        ///<summary>
        ///velocity at collision
        ///</summary>
        public void setVelocity(Vector3Float pVelocity)
        { 
            _velocity = pVelocity;
        }

        ///<summary>
        ///velocity at collision
        ///</summary>
        public Vector3Float getVelocity()
        {
            return _velocity;
        }

        ///<summary>
        ///velocity at collision
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

        ///<summary>
        ///mass of issuing entity
        ///</summary>
        public void setMass(float pMass)
        { 
            _mass = pMass;
        }

        [XmlElement(Type= typeof(float), ElementName="mass")]
        public float Mass
        {
            get
            {
                return _mass;
            }
            set
            {
                _mass = value;
            }
        }

        ///<summary>
        ///Location with respect to entity the issuing entity collided with
        ///</summary>
        public void setLocation(Vector3Float pLocation)
        { 
            _location = pLocation;
        }

        ///<summary>
        ///Location with respect to entity the issuing entity collided with
        ///</summary>
        public Vector3Float getLocation()
        {
            return _location;
        }

        ///<summary>
        ///Location with respect to entity the issuing entity collided with
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="location")]
        public Vector3Float Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
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
                _issuingEntityID.marshal(dos);
                _collidingEntityID.marshal(dos);
                _eventID.marshal(dos);
                dos.writeByte((byte)_collisionType);
                dos.writeByte((byte)_pad);
                _velocity.marshal(dos);
                dos.writeFloat((float)_mass);
                _location.marshal(dos);
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
                _issuingEntityID.unmarshal(dis);
                _collidingEntityID.unmarshal(dis);
                _eventID.unmarshal(dis);
                _collisionType = dis.readByte();
                _pad = dis.readByte();
                _velocity.unmarshal(dis);
                _mass = dis.readFloat();
                _location.unmarshal(dis);
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
            sb.Append("<CollisionPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<issuingEntityID>"  + System.Environment.NewLine);
                _issuingEntityID.reflection(sb);
                sb.Append("</issuingEntityID>"  + System.Environment.NewLine);
                sb.Append("<collidingEntityID>"  + System.Environment.NewLine);
                _collidingEntityID.reflection(sb);
                sb.Append("</collidingEntityID>"  + System.Environment.NewLine);
                sb.Append("<eventID>"  + System.Environment.NewLine);
                _eventID.reflection(sb);
                sb.Append("</eventID>"  + System.Environment.NewLine);
                sb.Append("<collisionType type=\"byte\">" + _collisionType.ToString() + "</collisionType> " + System.Environment.NewLine);
                sb.Append("<pad type=\"byte\">" + _pad.ToString() + "</pad> " + System.Environment.NewLine);
                sb.Append("<velocity>"  + System.Environment.NewLine);
                _velocity.reflection(sb);
                sb.Append("</velocity>"  + System.Environment.NewLine);
                sb.Append("<mass type=\"float\">" + _mass.ToString() + "</mass> " + System.Environment.NewLine);
                sb.Append("<location>"  + System.Environment.NewLine);
                _location.reflection(sb);
                sb.Append("</location>"  + System.Environment.NewLine);
                sb.Append("</CollisionPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(CollisionPdu a, CollisionPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(CollisionPdu a, CollisionPdu b)
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
            return this == obj as CollisionPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(CollisionPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_issuingEntityID.Equals( rhs._issuingEntityID) )) ivarsEqual = false;
            if( ! (_collidingEntityID.Equals( rhs._collidingEntityID) )) ivarsEqual = false;
            if( ! (_eventID.Equals( rhs._eventID) )) ivarsEqual = false;
            if( ! (_collisionType == rhs._collisionType)) ivarsEqual = false;
            if( ! (_pad == rhs._pad)) ivarsEqual = false;
            if( ! (_velocity.Equals( rhs._velocity) )) ivarsEqual = false;
            if( ! (_mass == rhs._mass)) ivarsEqual = false;
            if( ! (_location.Equals( rhs._location) )) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _issuingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _collidingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _eventID.GetHashCode();
            result = GenerateHash(result) ^ _collisionType.GetHashCode();
            result = GenerateHash(result) ^ _pad.GetHashCode();
            result = GenerateHash(result) ^ _velocity.GetHashCode();
            result = GenerateHash(result) ^ _mass.GetHashCode();
            result = GenerateHash(result) ^ _location.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
