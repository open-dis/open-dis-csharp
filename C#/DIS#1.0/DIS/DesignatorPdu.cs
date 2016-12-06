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
     * Section 5.3.7.2. Handles designating operations. COMPLETE
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
    public partial class DesignatorPdu : DistributedEmissionsFamilyPdu
    {
        /** ID of the entity designating */
        protected EntityID  _designatingEntityID = new EntityID(); 

        /** This field shall specify a unique emitter database number assigned to  differentiate between otherwise similar or identical emitter beams within an emitter system. */
        protected ushort  _codeName;

        /** ID of the entity being designated */
        protected EntityID  _designatedEntityID = new EntityID(); 

        /** This field shall identify the designator code being used by the designating entity  */
        protected ushort  _designatorCode;

        /** This field shall identify the designator output power in watts */
        protected float  _designatorPower;

        /** This field shall identify the designator wavelength in units of microns */
        protected float  _designatorWavelength;

        /** designtor spot wrt the designated entity */
        protected Vector3Float  _designatorSpotWrtDesignated = new Vector3Float(); 

        /** designtor spot wrt the designated entity */
        protected Vector3Double  _designatorSpotLocation = new Vector3Double(); 

        /** Dead reckoning algorithm */
        protected byte  _deadReckoningAlgorithm;

        /** padding */
        protected ushort  _padding1;

        /** padding */
        protected byte  _padding2;

        /** linear accelleration of entity */
        protected Vector3Float  _entityLinearAcceleration = new Vector3Float(); 


        /** Constructor */
        ///<summary>
        ///Section 5.3.7.2. Handles designating operations. COMPLETE
        ///</summary>
        public DesignatorPdu()
        {
            PduType = (byte)24;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _designatingEntityID.getMarshalledSize();  // _designatingEntityID
            marshalSize = marshalSize + 2;  // _codeName
            marshalSize = marshalSize + _designatedEntityID.getMarshalledSize();  // _designatedEntityID
            marshalSize = marshalSize + 2;  // _designatorCode
            marshalSize = marshalSize + 4;  // _designatorPower
            marshalSize = marshalSize + 4;  // _designatorWavelength
            marshalSize = marshalSize + _designatorSpotWrtDesignated.getMarshalledSize();  // _designatorSpotWrtDesignated
            marshalSize = marshalSize + _designatorSpotLocation.getMarshalledSize();  // _designatorSpotLocation
            marshalSize = marshalSize + 1;  // _deadReckoningAlgorithm
            marshalSize = marshalSize + 2;  // _padding1
            marshalSize = marshalSize + 1;  // _padding2
            marshalSize = marshalSize + _entityLinearAcceleration.getMarshalledSize();  // _entityLinearAcceleration

            return marshalSize;
        }


        ///<summary>
        ///ID of the entity designating
        ///</summary>
        public void setDesignatingEntityID(EntityID pDesignatingEntityID)
        { 
            _designatingEntityID = pDesignatingEntityID;
        }

        ///<summary>
        ///ID of the entity designating
        ///</summary>
        public EntityID getDesignatingEntityID()
        {
            return _designatingEntityID;
        }

        ///<summary>
        ///ID of the entity designating
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="designatingEntityID")]
        public EntityID DesignatingEntityID
        {
            get
            {
                return _designatingEntityID;
            }
            set
            {
                _designatingEntityID = value;
            }
        }

        ///<summary>
        ///This field shall specify a unique emitter database number assigned to  differentiate between otherwise similar or identical emitter beams within an emitter system.
        ///</summary>
        public void setCodeName(ushort pCodeName)
        { 
            _codeName = pCodeName;
        }

        [XmlElement(Type= typeof(ushort), ElementName="codeName")]
        public ushort CodeName
        {
            get
            {
                return _codeName;
            }
            set
            {
                _codeName = value;
            }
        }

        ///<summary>
        ///ID of the entity being designated
        ///</summary>
        public void setDesignatedEntityID(EntityID pDesignatedEntityID)
        { 
            _designatedEntityID = pDesignatedEntityID;
        }

        ///<summary>
        ///ID of the entity being designated
        ///</summary>
        public EntityID getDesignatedEntityID()
        {
            return _designatedEntityID;
        }

        ///<summary>
        ///ID of the entity being designated
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="designatedEntityID")]
        public EntityID DesignatedEntityID
        {
            get
            {
                return _designatedEntityID;
            }
            set
            {
                _designatedEntityID = value;
            }
        }

        ///<summary>
        ///This field shall identify the designator code being used by the designating entity 
        ///</summary>
        public void setDesignatorCode(ushort pDesignatorCode)
        { 
            _designatorCode = pDesignatorCode;
        }

        [XmlElement(Type= typeof(ushort), ElementName="designatorCode")]
        public ushort DesignatorCode
        {
            get
            {
                return _designatorCode;
            }
            set
            {
                _designatorCode = value;
            }
        }

        ///<summary>
        ///This field shall identify the designator output power in watts
        ///</summary>
        public void setDesignatorPower(float pDesignatorPower)
        { 
            _designatorPower = pDesignatorPower;
        }

        [XmlElement(Type= typeof(float), ElementName="designatorPower")]
        public float DesignatorPower
        {
            get
            {
                return _designatorPower;
            }
            set
            {
                _designatorPower = value;
            }
        }

        ///<summary>
        ///This field shall identify the designator wavelength in units of microns
        ///</summary>
        public void setDesignatorWavelength(float pDesignatorWavelength)
        { 
            _designatorWavelength = pDesignatorWavelength;
        }

        [XmlElement(Type= typeof(float), ElementName="designatorWavelength")]
        public float DesignatorWavelength
        {
            get
            {
                return _designatorWavelength;
            }
            set
            {
                _designatorWavelength = value;
            }
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        public void setDesignatorSpotWrtDesignated(Vector3Float pDesignatorSpotWrtDesignated)
        { 
            _designatorSpotWrtDesignated = pDesignatorSpotWrtDesignated;
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        public Vector3Float getDesignatorSpotWrtDesignated()
        {
            return _designatorSpotWrtDesignated;
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="designatorSpotWrtDesignated")]
        public Vector3Float DesignatorSpotWrtDesignated
        {
            get
            {
                return _designatorSpotWrtDesignated;
            }
            set
            {
                _designatorSpotWrtDesignated = value;
            }
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        public void setDesignatorSpotLocation(Vector3Double pDesignatorSpotLocation)
        { 
            _designatorSpotLocation = pDesignatorSpotLocation;
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        public Vector3Double getDesignatorSpotLocation()
        {
            return _designatorSpotLocation;
        }

        ///<summary>
        ///designtor spot wrt the designated entity
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="designatorSpotLocation")]
        public Vector3Double DesignatorSpotLocation
        {
            get
            {
                return _designatorSpotLocation;
            }
            set
            {
                _designatorSpotLocation = value;
            }
        }

        ///<summary>
        ///Dead reckoning algorithm
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
        ///padding
        ///</summary>
        public void setPadding1(ushort pPadding1)
        { 
            _padding1 = pPadding1;
        }

        [XmlElement(Type= typeof(ushort), ElementName="padding1")]
        public ushort Padding1
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

        ///<summary>
        ///padding
        ///</summary>
        public void setPadding2(byte pPadding2)
        { 
            _padding2 = pPadding2;
        }

        [XmlElement(Type= typeof(byte), ElementName="padding2")]
        public byte Padding2
        {
            get
            {
                return _padding2;
            }
            set
            {
                _padding2 = value;
            }
        }

        ///<summary>
        ///linear accelleration of entity
        ///</summary>
        public void setEntityLinearAcceleration(Vector3Float pEntityLinearAcceleration)
        { 
            _entityLinearAcceleration = pEntityLinearAcceleration;
        }

        ///<summary>
        ///linear accelleration of entity
        ///</summary>
        public Vector3Float getEntityLinearAcceleration()
        {
            return _entityLinearAcceleration;
        }

        ///<summary>
        ///linear accelleration of entity
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="entityLinearAcceleration")]
        public Vector3Float EntityLinearAcceleration
        {
            get
            {
                return _entityLinearAcceleration;
            }
            set
            {
                _entityLinearAcceleration = value;
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
                _designatingEntityID.marshal(dos);
                dos.writeUshort((ushort)_codeName);
                _designatedEntityID.marshal(dos);
                dos.writeUshort((ushort)_designatorCode);
                dos.writeFloat((float)_designatorPower);
                dos.writeFloat((float)_designatorWavelength);
                _designatorSpotWrtDesignated.marshal(dos);
                _designatorSpotLocation.marshal(dos);
                dos.writeByte((byte)_deadReckoningAlgorithm);
                dos.writeUshort((ushort)_padding1);
                dos.writeByte((byte)_padding2);
                _entityLinearAcceleration.marshal(dos);
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
                _designatingEntityID.unmarshal(dis);
                _codeName = dis.readUshort();
                _designatedEntityID.unmarshal(dis);
                _designatorCode = dis.readUshort();
                _designatorPower = dis.readFloat();
                _designatorWavelength = dis.readFloat();
                _designatorSpotWrtDesignated.unmarshal(dis);
                _designatorSpotLocation.unmarshal(dis);
                _deadReckoningAlgorithm = dis.readByte();
                _padding1 = dis.readUshort();
                _padding2 = dis.readByte();
                _entityLinearAcceleration.unmarshal(dis);
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
            sb.Append("<DesignatorPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<designatingEntityID>"  + System.Environment.NewLine);
                _designatingEntityID.reflection(sb);
                sb.Append("</designatingEntityID>"  + System.Environment.NewLine);
                sb.Append("<codeName type=\"ushort\">" + _codeName.ToString() + "</codeName> " + System.Environment.NewLine);
                sb.Append("<designatedEntityID>"  + System.Environment.NewLine);
                _designatedEntityID.reflection(sb);
                sb.Append("</designatedEntityID>"  + System.Environment.NewLine);
                sb.Append("<designatorCode type=\"ushort\">" + _designatorCode.ToString() + "</designatorCode> " + System.Environment.NewLine);
                sb.Append("<designatorPower type=\"float\">" + _designatorPower.ToString() + "</designatorPower> " + System.Environment.NewLine);
                sb.Append("<designatorWavelength type=\"float\">" + _designatorWavelength.ToString() + "</designatorWavelength> " + System.Environment.NewLine);
                sb.Append("<designatorSpotWrtDesignated>"  + System.Environment.NewLine);
                _designatorSpotWrtDesignated.reflection(sb);
                sb.Append("</designatorSpotWrtDesignated>"  + System.Environment.NewLine);
                sb.Append("<designatorSpotLocation>"  + System.Environment.NewLine);
                _designatorSpotLocation.reflection(sb);
                sb.Append("</designatorSpotLocation>"  + System.Environment.NewLine);
                sb.Append("<deadReckoningAlgorithm type=\"byte\">" + _deadReckoningAlgorithm.ToString() + "</deadReckoningAlgorithm> " + System.Environment.NewLine);
                sb.Append("<padding1 type=\"ushort\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
                sb.Append("<padding2 type=\"byte\">" + _padding2.ToString() + "</padding2> " + System.Environment.NewLine);
                sb.Append("<entityLinearAcceleration>"  + System.Environment.NewLine);
                _entityLinearAcceleration.reflection(sb);
                sb.Append("</entityLinearAcceleration>"  + System.Environment.NewLine);
                sb.Append("</DesignatorPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(DesignatorPdu a, DesignatorPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(DesignatorPdu a, DesignatorPdu b)
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
            return this == obj as DesignatorPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(DesignatorPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_designatingEntityID.Equals( rhs._designatingEntityID) )) ivarsEqual = false;
            if( ! (_codeName == rhs._codeName)) ivarsEqual = false;
            if( ! (_designatedEntityID.Equals( rhs._designatedEntityID) )) ivarsEqual = false;
            if( ! (_designatorCode == rhs._designatorCode)) ivarsEqual = false;
            if( ! (_designatorPower == rhs._designatorPower)) ivarsEqual = false;
            if( ! (_designatorWavelength == rhs._designatorWavelength)) ivarsEqual = false;
            if( ! (_designatorSpotWrtDesignated.Equals( rhs._designatorSpotWrtDesignated) )) ivarsEqual = false;
            if( ! (_designatorSpotLocation.Equals( rhs._designatorSpotLocation) )) ivarsEqual = false;
            if( ! (_deadReckoningAlgorithm == rhs._deadReckoningAlgorithm)) ivarsEqual = false;
            if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
            if( ! (_padding2 == rhs._padding2)) ivarsEqual = false;
            if( ! (_entityLinearAcceleration.Equals( rhs._entityLinearAcceleration) )) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _designatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _codeName.GetHashCode();
            result = GenerateHash(result) ^ _designatedEntityID.GetHashCode();
            result = GenerateHash(result) ^ _designatorCode.GetHashCode();
            result = GenerateHash(result) ^ _designatorPower.GetHashCode();
            result = GenerateHash(result) ^ _designatorWavelength.GetHashCode();
            result = GenerateHash(result) ^ _designatorSpotWrtDesignated.GetHashCode();
            result = GenerateHash(result) ^ _designatorSpotLocation.GetHashCode();
            result = GenerateHash(result) ^ _deadReckoningAlgorithm.GetHashCode();
            result = GenerateHash(result) ^ _padding1.GetHashCode();
            result = GenerateHash(result) ^ _padding2.GetHashCode();
            result = GenerateHash(result) ^ _entityLinearAcceleration.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
