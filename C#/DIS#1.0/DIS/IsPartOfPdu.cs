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
     * Section 5.3.9.4 The joining of two or more simulation entities is communicated by this PDU. COMPLETE
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
    [XmlInclude(typeof(Relationship))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(NamedLocation))]
    [XmlInclude(typeof(EntityType))]
    public partial class IsPartOfPdu : EntityManagementFamilyPdu
    {
        /** ID of entity originating PDU */
        protected EntityID  _orginatingEntityID = new EntityID(); 

        /** ID of entity receiving PDU */
        protected EntityID  _receivingEntityID = new EntityID(); 

        /** relationship of joined parts */
        protected Relationship  _relationship = new Relationship(); 

        /** location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0 */
        protected Vector3Float  _partLocation = new Vector3Float(); 

        /** named location */
        protected NamedLocation  _namedLocationID = new NamedLocation(); 

        /** entity type */
        protected EntityType  _partEntityType = new EntityType(); 


        /** Constructor */
        ///<summary>
        ///Section 5.3.9.4 The joining of two or more simulation entities is communicated by this PDU. COMPLETE
        ///</summary>
        public IsPartOfPdu()
        {
            PduType = (byte)36;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _orginatingEntityID.getMarshalledSize();  // _orginatingEntityID
            marshalSize = marshalSize + _receivingEntityID.getMarshalledSize();  // _receivingEntityID
            marshalSize = marshalSize + _relationship.getMarshalledSize();  // _relationship
            marshalSize = marshalSize + _partLocation.getMarshalledSize();  // _partLocation
            marshalSize = marshalSize + _namedLocationID.getMarshalledSize();  // _namedLocationID
            marshalSize = marshalSize + _partEntityType.getMarshalledSize();  // _partEntityType

            return marshalSize;
        }


        ///<summary>
        ///ID of entity originating PDU
        ///</summary>
        public void setOrginatingEntityID(EntityID pOrginatingEntityID)
        { 
            _orginatingEntityID = pOrginatingEntityID;
        }

        ///<summary>
        ///ID of entity originating PDU
        ///</summary>
        public EntityID getOrginatingEntityID()
        {
            return _orginatingEntityID;
        }

        ///<summary>
        ///ID of entity originating PDU
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="orginatingEntityID")]
        public EntityID OrginatingEntityID
        {
            get
            {
                return _orginatingEntityID;
            }
            set
            {
                _orginatingEntityID = value;
            }
        }

        ///<summary>
        ///ID of entity receiving PDU
        ///</summary>
        public void setReceivingEntityID(EntityID pReceivingEntityID)
        { 
            _receivingEntityID = pReceivingEntityID;
        }

        ///<summary>
        ///ID of entity receiving PDU
        ///</summary>
        public EntityID getReceivingEntityID()
        {
            return _receivingEntityID;
        }

        ///<summary>
        ///ID of entity receiving PDU
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="receivingEntityID")]
        public EntityID ReceivingEntityID
        {
            get
            {
                return _receivingEntityID;
            }
            set
            {
                _receivingEntityID = value;
            }
        }

        ///<summary>
        ///relationship of joined parts
        ///</summary>
        public void setRelationship(Relationship pRelationship)
        { 
            _relationship = pRelationship;
        }

        ///<summary>
        ///relationship of joined parts
        ///</summary>
        public Relationship getRelationship()
        {
            return _relationship;
        }

        ///<summary>
        ///relationship of joined parts
        ///</summary>
        [XmlElement(Type= typeof(Relationship), ElementName="relationship")]
        public Relationship Relationship
        {
            get
            {
                return _relationship;
            }
            set
            {
                _relationship = value;
            }
        }

        ///<summary>
        ///location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        ///</summary>
        public void setPartLocation(Vector3Float pPartLocation)
        { 
            _partLocation = pPartLocation;
        }

        ///<summary>
        ///location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        ///</summary>
        public Vector3Float getPartLocation()
        {
            return _partLocation;
        }

        ///<summary>
        ///location of part; centroid of part in host's coordinate system. x=range, y=bearing, z=0
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="partLocation")]
        public Vector3Float PartLocation
        {
            get
            {
                return _partLocation;
            }
            set
            {
                _partLocation = value;
            }
        }

        ///<summary>
        ///named location
        ///</summary>
        public void setNamedLocationID(NamedLocation pNamedLocationID)
        { 
            _namedLocationID = pNamedLocationID;
        }

        ///<summary>
        ///named location
        ///</summary>
        public NamedLocation getNamedLocationID()
        {
            return _namedLocationID;
        }

        ///<summary>
        ///named location
        ///</summary>
        [XmlElement(Type= typeof(NamedLocation), ElementName="namedLocationID")]
        public NamedLocation NamedLocationID
        {
            get
            {
                return _namedLocationID;
            }
            set
            {
                _namedLocationID = value;
            }
        }

        ///<summary>
        ///entity type
        ///</summary>
        public void setPartEntityType(EntityType pPartEntityType)
        { 
            _partEntityType = pPartEntityType;
        }

        ///<summary>
        ///entity type
        ///</summary>
        public EntityType getPartEntityType()
        {
            return _partEntityType;
        }

        ///<summary>
        ///entity type
        ///</summary>
        [XmlElement(Type= typeof(EntityType), ElementName="partEntityType")]
        public EntityType PartEntityType
        {
            get
            {
                return _partEntityType;
            }
            set
            {
                _partEntityType = value;
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
                _orginatingEntityID.marshal(dos);
                _receivingEntityID.marshal(dos);
                _relationship.marshal(dos);
                _partLocation.marshal(dos);
                _namedLocationID.marshal(dos);
                _partEntityType.marshal(dos);
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
                _orginatingEntityID.unmarshal(dis);
                _receivingEntityID.unmarshal(dis);
                _relationship.unmarshal(dis);
                _partLocation.unmarshal(dis);
                _namedLocationID.unmarshal(dis);
                _partEntityType.unmarshal(dis);
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
            sb.Append("<IsPartOfPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<orginatingEntityID>"  + System.Environment.NewLine);
                _orginatingEntityID.reflection(sb);
                sb.Append("</orginatingEntityID>"  + System.Environment.NewLine);
                sb.Append("<receivingEntityID>"  + System.Environment.NewLine);
                _receivingEntityID.reflection(sb);
                sb.Append("</receivingEntityID>"  + System.Environment.NewLine);
                sb.Append("<relationship>"  + System.Environment.NewLine);
                _relationship.reflection(sb);
                sb.Append("</relationship>"  + System.Environment.NewLine);
                sb.Append("<partLocation>"  + System.Environment.NewLine);
                _partLocation.reflection(sb);
                sb.Append("</partLocation>"  + System.Environment.NewLine);
                sb.Append("<namedLocationID>"  + System.Environment.NewLine);
                _namedLocationID.reflection(sb);
                sb.Append("</namedLocationID>"  + System.Environment.NewLine);
                sb.Append("<partEntityType>"  + System.Environment.NewLine);
                _partEntityType.reflection(sb);
                sb.Append("</partEntityType>"  + System.Environment.NewLine);
                sb.Append("</IsPartOfPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(IsPartOfPdu a, IsPartOfPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(IsPartOfPdu a, IsPartOfPdu b)
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
            return this == obj as IsPartOfPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(IsPartOfPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_orginatingEntityID.Equals( rhs._orginatingEntityID) )) ivarsEqual = false;
            if( ! (_receivingEntityID.Equals( rhs._receivingEntityID) )) ivarsEqual = false;
            if( ! (_relationship.Equals( rhs._relationship) )) ivarsEqual = false;
            if( ! (_partLocation.Equals( rhs._partLocation) )) ivarsEqual = false;
            if( ! (_namedLocationID.Equals( rhs._namedLocationID) )) ivarsEqual = false;
            if( ! (_partEntityType.Equals( rhs._partEntityType) )) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _orginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _receivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _relationship.GetHashCode();
            result = GenerateHash(result) ^ _partLocation.GetHashCode();
            result = GenerateHash(result) ^ _namedLocationID.GetHashCode();
            result = GenerateHash(result) ^ _partEntityType.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
