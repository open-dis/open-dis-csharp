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
     * Section 5.3.11.3: Inormation abut the addition or modification of a synthecic enviroment object that is anchored      to the terrain with a single point. COMPLETE
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
    [XmlInclude(typeof(ObjectType))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(SimulationAddress))]
    public partial class PointObjectStatePdu : SyntheticEnvironmentFamilyPdu
    {
        /** Object in synthetic environment */
        protected EntityID  _objectID = new EntityID(); 

        /** Object with which this point object is associated */
        protected EntityID  _referencedObjectID = new EntityID(); 

        /** unique update number of each state transition of an object */
        protected ushort  _updateNumber;

        /** force ID */
        protected byte  _forceID;

        /** modifications */
        protected byte  _modifications;

        /** Object type */
        protected ObjectType  _objectType = new ObjectType(); 

        /** Object location */
        protected Vector3Double  _objectLocation = new Vector3Double(); 

        /** Object orientation */
        protected Orientation  _objectOrientation = new Orientation(); 

        /** Object apperance */
        protected double  _objectAppearance;

        /** requesterID */
        protected SimulationAddress  _requesterID = new SimulationAddress(); 

        /** receiver ID */
        protected SimulationAddress  _receivingID = new SimulationAddress(); 

        /** padding */
        protected uint  _pad2;


        /** Constructor */
        ///<summary>
        ///Section 5.3.11.3: Inormation abut the addition or modification of a synthecic enviroment object that is anchored      to the terrain with a single point. COMPLETE
        ///</summary>
        public PointObjectStatePdu()
        {
            PduType = (byte)43;
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
            marshalSize = marshalSize + _objectLocation.getMarshalledSize();  // _objectLocation
            marshalSize = marshalSize + _objectOrientation.getMarshalledSize();  // _objectOrientation
            marshalSize = marshalSize + 8;  // _objectAppearance
            marshalSize = marshalSize + _requesterID.getMarshalledSize();  // _requesterID
            marshalSize = marshalSize + _receivingID.getMarshalledSize();  // _receivingID
            marshalSize = marshalSize + 4;  // _pad2

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
        ///modifications
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
        public void setObjectType(ObjectType pObjectType)
        { 
            _objectType = pObjectType;
        }

        ///<summary>
        ///Object type
        ///</summary>
        public ObjectType getObjectType()
        {
            return _objectType;
        }

        ///<summary>
        ///Object type
        ///</summary>
        [XmlElement(Type= typeof(ObjectType), ElementName="objectType")]
        public ObjectType ObjectType
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
        ///Object location
        ///</summary>
        public void setObjectLocation(Vector3Double pObjectLocation)
        { 
            _objectLocation = pObjectLocation;
        }

        ///<summary>
        ///Object location
        ///</summary>
        public Vector3Double getObjectLocation()
        {
            return _objectLocation;
        }

        ///<summary>
        ///Object location
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="objectLocation")]
        public Vector3Double ObjectLocation
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
        ///Object orientation
        ///</summary>
        public void setObjectOrientation(Orientation pObjectOrientation)
        { 
            _objectOrientation = pObjectOrientation;
        }

        ///<summary>
        ///Object orientation
        ///</summary>
        public Orientation getObjectOrientation()
        {
            return _objectOrientation;
        }

        ///<summary>
        ///Object orientation
        ///</summary>
        [XmlElement(Type= typeof(Orientation), ElementName="objectOrientation")]
        public Orientation ObjectOrientation
        {
            get
            {
                return _objectOrientation;
            }
            set
            {
                _objectOrientation = value;
            }
        }

        ///<summary>
        ///Object apperance
        ///</summary>
        public void setObjectAppearance(double pObjectAppearance)
        { 
            _objectAppearance = pObjectAppearance;
        }

        [XmlElement(Type= typeof(double), ElementName="objectAppearance")]
        public double ObjectAppearance
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
        ///padding
        ///</summary>
        public void setPad2(uint pPad2)
        { 
            _pad2 = pPad2;
        }

        [XmlElement(Type= typeof(uint), ElementName="pad2")]
        public uint Pad2
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
                _objectLocation.marshal(dos);
                _objectOrientation.marshal(dos);
                dos.writeDouble((double)_objectAppearance);
                _requesterID.marshal(dos);
                _receivingID.marshal(dos);
                dos.writeUint((uint)_pad2);
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
                _objectLocation.unmarshal(dis);
                _objectOrientation.unmarshal(dis);
                _objectAppearance = dis.readDouble();
                _requesterID.unmarshal(dis);
                _receivingID.unmarshal(dis);
                _pad2 = dis.readUint();
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
            sb.Append("<PointObjectStatePdu>"  + System.Environment.NewLine);
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
                sb.Append("<objectLocation>"  + System.Environment.NewLine);
                _objectLocation.reflection(sb);
                sb.Append("</objectLocation>"  + System.Environment.NewLine);
                sb.Append("<objectOrientation>"  + System.Environment.NewLine);
                _objectOrientation.reflection(sb);
                sb.Append("</objectOrientation>"  + System.Environment.NewLine);
                sb.Append("<objectAppearance type=\"double\">" + _objectAppearance.ToString() + "</objectAppearance> " + System.Environment.NewLine);
                sb.Append("<requesterID>"  + System.Environment.NewLine);
                _requesterID.reflection(sb);
                sb.Append("</requesterID>"  + System.Environment.NewLine);
                sb.Append("<receivingID>"  + System.Environment.NewLine);
                _receivingID.reflection(sb);
                sb.Append("</receivingID>"  + System.Environment.NewLine);
                sb.Append("<pad2 type=\"uint\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
                sb.Append("</PointObjectStatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(PointObjectStatePdu a, PointObjectStatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(PointObjectStatePdu a, PointObjectStatePdu b)
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
            return this == obj as PointObjectStatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(PointObjectStatePdu rhs)
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
            if( ! (_objectLocation.Equals( rhs._objectLocation) )) ivarsEqual = false;
            if( ! (_objectOrientation.Equals( rhs._objectOrientation) )) ivarsEqual = false;
            if( ! (_objectAppearance == rhs._objectAppearance)) ivarsEqual = false;
            if( ! (_requesterID.Equals( rhs._requesterID) )) ivarsEqual = false;
            if( ! (_receivingID.Equals( rhs._receivingID) )) ivarsEqual = false;
            if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;

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
            result = GenerateHash(result) ^ _objectLocation.GetHashCode();
            result = GenerateHash(result) ^ _objectOrientation.GetHashCode();
            result = GenerateHash(result) ^ _objectAppearance.GetHashCode();
            result = GenerateHash(result) ^ _requesterID.GetHashCode();
            result = GenerateHash(result) ^ _receivingID.GetHashCode();
            result = GenerateHash(result) ^ _pad2.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
