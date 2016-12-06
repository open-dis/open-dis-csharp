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
     * Sectioin 5.3.4.1. Information about someone firing something. COMPLETE
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
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(BurstDescriptor))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class FirePdu : WarfareFamilyPdu
    {
        /** ID of the munition that is being shot */
        protected EntityID  _munitionID = new EntityID(); 

        /** ID of event */
        protected EventID  _eventID = new EventID(); 

        protected uint  _fireMissionIndex;

        /** location of the firing event */
        protected Vector3Double  _locationInWorldCoordinates = new Vector3Double(); 

        /** Describes munitions used in the firing event */
        protected BurstDescriptor  _burstDescriptor = new BurstDescriptor(); 

        /** Velocity of the ammunition */
        protected Vector3Float  _velocity = new Vector3Float(); 

        /** range to the target */
        protected float  _range;


        /** Constructor */
        ///<summary>
        ///Sectioin 5.3.4.1. Information about someone firing something. COMPLETE
        ///</summary>
        public FirePdu()
        {
            PduType = (byte)2;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _munitionID.getMarshalledSize();  // _munitionID
            marshalSize = marshalSize + _eventID.getMarshalledSize();  // _eventID
            marshalSize = marshalSize + 4;  // _fireMissionIndex
            marshalSize = marshalSize + _locationInWorldCoordinates.getMarshalledSize();  // _locationInWorldCoordinates
            marshalSize = marshalSize + _burstDescriptor.getMarshalledSize();  // _burstDescriptor
            marshalSize = marshalSize + _velocity.getMarshalledSize();  // _velocity
            marshalSize = marshalSize + 4;  // _range

            return marshalSize;
        }


        ///<summary>
        ///ID of the munition that is being shot
        ///</summary>
        public void setMunitionID(EntityID pMunitionID)
        { 
            _munitionID = pMunitionID;
        }

        ///<summary>
        ///ID of the munition that is being shot
        ///</summary>
        public EntityID getMunitionID()
        {
            return _munitionID;
        }

        ///<summary>
        ///ID of the munition that is being shot
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="munitionID")]
        public EntityID MunitionID
        {
            get
            {
                return _munitionID;
            }
            set
            {
                _munitionID = value;
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

        public void setFireMissionIndex(uint pFireMissionIndex)
        { 
            _fireMissionIndex = pFireMissionIndex;
        }

        [XmlElement(Type= typeof(uint), ElementName="fireMissionIndex")]
        public uint FireMissionIndex
        {
            get
            {
                return _fireMissionIndex;
            }
            set
            {
                _fireMissionIndex = value;
            }
        }

        ///<summary>
        ///location of the firing event
        ///</summary>
        public void setLocationInWorldCoordinates(Vector3Double pLocationInWorldCoordinates)
        { 
            _locationInWorldCoordinates = pLocationInWorldCoordinates;
        }

        ///<summary>
        ///location of the firing event
        ///</summary>
        public Vector3Double getLocationInWorldCoordinates()
        {
            return _locationInWorldCoordinates;
        }

        ///<summary>
        ///location of the firing event
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="locationInWorldCoordinates")]
        public Vector3Double LocationInWorldCoordinates
        {
            get
            {
                return _locationInWorldCoordinates;
            }
            set
            {
                _locationInWorldCoordinates = value;
            }
        }

        ///<summary>
        ///Describes munitions used in the firing event
        ///</summary>
        public void setBurstDescriptor(BurstDescriptor pBurstDescriptor)
        { 
            _burstDescriptor = pBurstDescriptor;
        }

        ///<summary>
        ///Describes munitions used in the firing event
        ///</summary>
        public BurstDescriptor getBurstDescriptor()
        {
            return _burstDescriptor;
        }

        ///<summary>
        ///Describes munitions used in the firing event
        ///</summary>
        [XmlElement(Type= typeof(BurstDescriptor), ElementName="burstDescriptor")]
        public BurstDescriptor BurstDescriptor
        {
            get
            {
                return _burstDescriptor;
            }
            set
            {
                _burstDescriptor = value;
            }
        }

        ///<summary>
        ///Velocity of the ammunition
        ///</summary>
        public void setVelocity(Vector3Float pVelocity)
        { 
            _velocity = pVelocity;
        }

        ///<summary>
        ///Velocity of the ammunition
        ///</summary>
        public Vector3Float getVelocity()
        {
            return _velocity;
        }

        ///<summary>
        ///Velocity of the ammunition
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
        ///range to the target
        ///</summary>
        public void setRange(float pRange)
        { 
            _range = pRange;
        }

        [XmlElement(Type= typeof(float), ElementName="range")]
        public float Range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
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
                _munitionID.marshal(dos);
                _eventID.marshal(dos);
                dos.writeUint((uint)_fireMissionIndex);
                _locationInWorldCoordinates.marshal(dos);
                _burstDescriptor.marshal(dos);
                _velocity.marshal(dos);
                dos.writeFloat((float)_range);
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
                _munitionID.unmarshal(dis);
                _eventID.unmarshal(dis);
                _fireMissionIndex = dis.readUint();
                _locationInWorldCoordinates.unmarshal(dis);
                _burstDescriptor.unmarshal(dis);
                _velocity.unmarshal(dis);
                _range = dis.readFloat();
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
            sb.Append("<FirePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<munitionID>"  + System.Environment.NewLine);
                _munitionID.reflection(sb);
                sb.Append("</munitionID>"  + System.Environment.NewLine);
                sb.Append("<eventID>"  + System.Environment.NewLine);
                _eventID.reflection(sb);
                sb.Append("</eventID>"  + System.Environment.NewLine);
                sb.Append("<fireMissionIndex type=\"uint\">" + _fireMissionIndex.ToString() + "</fireMissionIndex> " + System.Environment.NewLine);
                sb.Append("<locationInWorldCoordinates>"  + System.Environment.NewLine);
                _locationInWorldCoordinates.reflection(sb);
                sb.Append("</locationInWorldCoordinates>"  + System.Environment.NewLine);
                sb.Append("<burstDescriptor>"  + System.Environment.NewLine);
                _burstDescriptor.reflection(sb);
                sb.Append("</burstDescriptor>"  + System.Environment.NewLine);
                sb.Append("<velocity>"  + System.Environment.NewLine);
                _velocity.reflection(sb);
                sb.Append("</velocity>"  + System.Environment.NewLine);
                sb.Append("<range type=\"float\">" + _range.ToString() + "</range> " + System.Environment.NewLine);
                sb.Append("</FirePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(FirePdu a, FirePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(FirePdu a, FirePdu b)
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
            return this == obj as FirePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(FirePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_munitionID.Equals( rhs._munitionID) )) ivarsEqual = false;
            if( ! (_eventID.Equals( rhs._eventID) )) ivarsEqual = false;
            if( ! (_fireMissionIndex == rhs._fireMissionIndex)) ivarsEqual = false;
            if( ! (_locationInWorldCoordinates.Equals( rhs._locationInWorldCoordinates) )) ivarsEqual = false;
            if( ! (_burstDescriptor.Equals( rhs._burstDescriptor) )) ivarsEqual = false;
            if( ! (_velocity.Equals( rhs._velocity) )) ivarsEqual = false;
            if( ! (_range == rhs._range)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _munitionID.GetHashCode();
            result = GenerateHash(result) ^ _eventID.GetHashCode();
            result = GenerateHash(result) ^ _fireMissionIndex.GetHashCode();
            result = GenerateHash(result) ^ _locationInWorldCoordinates.GetHashCode();
            result = GenerateHash(result) ^ _burstDescriptor.GetHashCode();
            result = GenerateHash(result) ^ _velocity.GetHashCode();
            result = GenerateHash(result) ^ _range.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
