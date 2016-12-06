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
     * Section 5.3.11.5: Information about the addition/modification of an oobject that is geometrically      achored to the terrain with a set of three or more points that come to a closure. COMPLETE
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
    [XmlInclude(typeof(SixByteChunk))]
    [XmlInclude(typeof(SimulationAddress))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class ArealObjectStatePdu : SyntheticEnvironmentFamilyPdu
    {
        /** Object in synthetic environment */
        protected EntityID  _objectID = new EntityID(); 

        /** Object with which this point object is associated */
        protected EntityID  _referencedObjectID = new EntityID(); 

        /** unique update number of each state transition of an object */
        protected ushort  _updateNumber;

        /** force ID */
        protected byte  _forceID;

        /** modifications enumeration */
        protected byte  _modifications;

        /** Object type */
        protected EntityType  _objectType = new EntityType(); 

        /** Object appearance */
        protected SixByteChunk  _objectAppearance = new SixByteChunk(); 

        /** Number of points */
        protected ushort  _numberOfPoints;

        /** requesterID */
        protected SimulationAddress  _requesterID = new SimulationAddress(); 

        /** receiver ID */
        protected SimulationAddress  _receivingID = new SimulationAddress(); 

        /** location of object */
        protected List<Vector3Double> _objectLocation = new List<Vector3Double>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.11.5: Information about the addition/modification of an oobject that is geometrically      achored to the terrain with a set of three or more points that come to a closure. COMPLETE
        ///</summary>
        public ArealObjectStatePdu()
        {
            PduType = (byte)45;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _objectID.getMarshalledSize();  // _objectID
            marshalSize = marshalSize + _referencedObjectID.getMarshalledSize();  // _referencedObjectID
            marshalSize = marshalSize + 2;  // _updateNumber
            marshalSize = marshalSize + 1;  // _forceID
            marshalSize = marshalSize + 1;  // _modifications
            marshalSize = marshalSize + _objectType.getMarshalledSize();  // _objectType
            marshalSize = marshalSize + _objectAppearance.getMarshalledSize();  // _objectAppearance
            marshalSize = marshalSize + 2;  // _numberOfPoints
            marshalSize = marshalSize + _requesterID.getMarshalledSize();  // _requesterID
            marshalSize = marshalSize + _receivingID.getMarshalledSize();  // _receivingID
            for(int idx=0; idx < _objectLocation.Count; idx++)
            {
                Vector3Double listElement = (Vector3Double)_objectLocation[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Object in synthetic environment
        ///</summary>
        public void setObjectID(EntityID pObjectID)
        { 
            _objectID = pObjectID;
        }

        ///<summary>
        ///Object in synthetic environment
        ///</summary>
        public EntityID getObjectID()
        {
            return _objectID;
        }

        ///<summary>
        ///Object in synthetic environment
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="objectID")]
        public EntityID ObjectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                _objectID = value;
            }
        }

        ///<summary>
        ///Object with which this point object is associated
        ///</summary>
        public void setReferencedObjectID(EntityID pReferencedObjectID)
        { 
            _referencedObjectID = pReferencedObjectID;
        }

        ///<summary>
        ///Object with which this point object is associated
        ///</summary>
        public EntityID getReferencedObjectID()
        {
            return _referencedObjectID;
        }

        ///<summary>
        ///Object with which this point object is associated
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="referencedObjectID")]
        public EntityID ReferencedObjectID
        {
            get
            {
                return _referencedObjectID;
            }
            set
            {
                _referencedObjectID = value;
            }
        }

        ///<summary>
        ///unique update number of each state transition of an object
        ///</summary>
        public void setUpdateNumber(ushort pUpdateNumber)
        { 
            _updateNumber = pUpdateNumber;
        }

        [XmlElement(Type= typeof(ushort), ElementName="updateNumber")]
        public ushort UpdateNumber
        {
            get
            {
                return _updateNumber;
            }
            set
            {
                _updateNumber = value;
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
        ///modifications enumeration
        ///</summary>
        public void setModifications(byte pModifications)
        { 
            _modifications = pModifications;
        }

        [XmlElement(Type= typeof(byte), ElementName="modifications")]
        public byte Modifications
        {
            get
            {
                return _modifications;
            }
            set
            {
                _modifications = value;
            }
        }

        ///<summary>
        ///Object type
        ///</summary>
        public void setObjectType(EntityType pObjectType)
        { 
            _objectType = pObjectType;
        }

        ///<summary>
        ///Object type
        ///</summary>
        public EntityType getObjectType()
        {
            return _objectType;
        }

        ///<summary>
        ///Object type
        ///</summary>
        [XmlElement(Type= typeof(EntityType), ElementName="objectType")]
        public EntityType ObjectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                _objectType = value;
            }
        }

        ///<summary>
        ///Object appearance
        ///</summary>
        public void setObjectAppearance(SixByteChunk pObjectAppearance)
        { 
            _objectAppearance = pObjectAppearance;
        }

        ///<summary>
        ///Object appearance
        ///</summary>
        public SixByteChunk getObjectAppearance()
        {
            return _objectAppearance;
        }

        ///<summary>
        ///Object appearance
        ///</summary>
        [XmlElement(Type= typeof(SixByteChunk), ElementName="objectAppearance")]
        public SixByteChunk ObjectAppearance
        {
            get
            {
                return _objectAppearance;
            }
            set
            {
                _objectAppearance = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfPoints(ushort pNumberOfPoints)
        {
            _numberOfPoints = pNumberOfPoints;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfPoints")]
        public ushort NumberOfPoints
        {
            get
            {
                return _numberOfPoints;
            }
            set
            {
                _numberOfPoints = value;
            }
        }

        ///<summary>
        ///requesterID
        ///</summary>
        public void setRequesterID(SimulationAddress pRequesterID)
        { 
            _requesterID = pRequesterID;
        }

        ///<summary>
        ///requesterID
        ///</summary>
        public SimulationAddress getRequesterID()
        {
            return _requesterID;
        }

        ///<summary>
        ///requesterID
        ///</summary>
        [XmlElement(Type= typeof(SimulationAddress), ElementName="requesterID")]
        public SimulationAddress RequesterID
        {
            get
            {
                return _requesterID;
            }
            set
            {
                _requesterID = value;
            }
        }

        ///<summary>
        ///receiver ID
        ///</summary>
        public void setReceivingID(SimulationAddress pReceivingID)
        { 
            _receivingID = pReceivingID;
        }

        ///<summary>
        ///receiver ID
        ///</summary>
        public SimulationAddress getReceivingID()
        {
            return _receivingID;
        }

        ///<summary>
        ///receiver ID
        ///</summary>
        [XmlElement(Type= typeof(SimulationAddress), ElementName="receivingID")]
        public SimulationAddress ReceivingID
        {
            get
            {
                return _receivingID;
            }
            set
            {
                _receivingID = value;
            }
        }

        ///<summary>
        ///location of object
        ///</summary>
        public void setObjectLocation(List<Vector3Double> pObjectLocation)
        {
            _objectLocation = pObjectLocation;
        }

        ///<summary>
        ///location of object
        ///</summary>
        public List<Vector3Double> getObjectLocation()
        {
            return _objectLocation;
        }

        ///<summary>
        ///location of object
        ///</summary>
        [XmlElement(ElementName = "objectLocationList",Type = typeof(List<Vector3Double>))]
        public List<Vector3Double> ObjectLocation
        {
            get
            {
                return _objectLocation;
            }
            set
            {
                _objectLocation = value;
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
                _objectID.marshal(dos);
                _referencedObjectID.marshal(dos);
                dos.writeUshort((ushort)_updateNumber);
                dos.writeByte((byte)_forceID);
                dos.writeByte((byte)_modifications);
                _objectType.marshal(dos);
                _objectAppearance.marshal(dos);
                dos.writeUshort((ushort)_objectLocation.Count);
                _requesterID.marshal(dos);
                _receivingID.marshal(dos);

                for(int idx = 0; idx < _objectLocation.Count; idx++)
                {
                    Vector3Double aVector3Double = (Vector3Double)_objectLocation[idx];
                    aVector3Double.marshal(dos);
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
                _objectID.unmarshal(dis);
                _referencedObjectID.unmarshal(dis);
                _updateNumber = dis.readUshort();
                _forceID = dis.readByte();
                _modifications = dis.readByte();
                _objectType.unmarshal(dis);
                _objectAppearance.unmarshal(dis);
                _numberOfPoints = dis.readUshort();
                _requesterID.unmarshal(dis);
                _receivingID.unmarshal(dis);
                for(int idx = 0; idx < _numberOfPoints; idx++)
                {
                    Vector3Double anX = new Vector3Double();
                    anX.unmarshal(dis);
                    _objectLocation.Add(anX);
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
            sb.Append("<ArealObjectStatePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<objectID>"  + System.Environment.NewLine);
                _objectID.reflection(sb);
                sb.Append("</objectID>"  + System.Environment.NewLine);
                sb.Append("<referencedObjectID>"  + System.Environment.NewLine);
                _referencedObjectID.reflection(sb);
                sb.Append("</referencedObjectID>"  + System.Environment.NewLine);
                sb.Append("<updateNumber type=\"ushort\">" + _updateNumber.ToString() + "</updateNumber> " + System.Environment.NewLine);
                sb.Append("<forceID type=\"byte\">" + _forceID.ToString() + "</forceID> " + System.Environment.NewLine);
                sb.Append("<modifications type=\"byte\">" + _modifications.ToString() + "</modifications> " + System.Environment.NewLine);
                sb.Append("<objectType>"  + System.Environment.NewLine);
                _objectType.reflection(sb);
                sb.Append("</objectType>"  + System.Environment.NewLine);
                sb.Append("<objectAppearance>"  + System.Environment.NewLine);
                _objectAppearance.reflection(sb);
                sb.Append("</objectAppearance>"  + System.Environment.NewLine);
                sb.Append("<objectLocation type=\"ushort\">" + _objectLocation.Count.ToString() + "</objectLocation> " + System.Environment.NewLine);
                sb.Append("<requesterID>"  + System.Environment.NewLine);
                _requesterID.reflection(sb);
                sb.Append("</requesterID>"  + System.Environment.NewLine);
                sb.Append("<receivingID>"  + System.Environment.NewLine);
                _receivingID.reflection(sb);
                sb.Append("</receivingID>"  + System.Environment.NewLine);

            for(int idx = 0; idx < _objectLocation.Count; idx++)
            {
                sb.Append("<objectLocation"+ idx.ToString() + " type=\"Vector3Double\">" + System.Environment.NewLine);
                Vector3Double aVector3Double = (Vector3Double)_objectLocation[idx];
                aVector3Double.reflection(sb);
                sb.Append("</objectLocation"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</ArealObjectStatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(ArealObjectStatePdu a, ArealObjectStatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(ArealObjectStatePdu a, ArealObjectStatePdu b)
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
            return this == obj as ArealObjectStatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(ArealObjectStatePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_objectID.Equals( rhs._objectID) )) ivarsEqual = false;
            if( ! (_referencedObjectID.Equals( rhs._referencedObjectID) )) ivarsEqual = false;
            if( ! (_updateNumber == rhs._updateNumber)) ivarsEqual = false;
            if( ! (_forceID == rhs._forceID)) ivarsEqual = false;
            if( ! (_modifications == rhs._modifications)) ivarsEqual = false;
            if( ! (_objectType.Equals( rhs._objectType) )) ivarsEqual = false;
            if( ! (_objectAppearance.Equals( rhs._objectAppearance) )) ivarsEqual = false;
            if( ! (_numberOfPoints == rhs._numberOfPoints)) ivarsEqual = false;
            if( ! (_requesterID.Equals( rhs._requesterID) )) ivarsEqual = false;
            if( ! (_receivingID.Equals( rhs._receivingID) )) ivarsEqual = false;

            if( ! (_objectLocation.Count == rhs._objectLocation.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _objectLocation.Count; idx++)
                {
                    if( ! ( _objectLocation[idx].Equals(rhs._objectLocation[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _objectID.GetHashCode();
            result = GenerateHash(result) ^ _referencedObjectID.GetHashCode();
            result = GenerateHash(result) ^ _updateNumber.GetHashCode();
            result = GenerateHash(result) ^ _forceID.GetHashCode();
            result = GenerateHash(result) ^ _modifications.GetHashCode();
            result = GenerateHash(result) ^ _objectType.GetHashCode();
            result = GenerateHash(result) ^ _objectAppearance.GetHashCode();
            result = GenerateHash(result) ^ _numberOfPoints.GetHashCode();
            result = GenerateHash(result) ^ _requesterID.GetHashCode();
            result = GenerateHash(result) ^ _receivingID.GetHashCode();

            if(_objectLocation.Count > 0)
            {
                for(int idx = 0; idx < _objectLocation.Count; idx++)
                {
                    result = GenerateHash(result) ^ _objectLocation[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
