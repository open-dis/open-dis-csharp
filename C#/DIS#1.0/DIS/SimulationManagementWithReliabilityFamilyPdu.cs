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
     * Section 5.3.12: Abstract superclass for reliable simulation management PDUs
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
    public partial class SimulationManagementWithReliabilityFamilyPdu : Pdu
    {
        /** Object originatig the request */
        protected EntityID  _originatingEntityID = new EntityID(); 

        /** Object with which this point object is associated */
        protected EntityID  _receivingEntityID = new EntityID(); 


        /** Constructor */
        ///<summary>
        ///Section 5.3.12: Abstract superclass for reliable simulation management PDUs
        ///</summary>
        public SimulationManagementWithReliabilityFamilyPdu()
        {
            ProtocolFamily = (byte)10;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _originatingEntityID.getMarshalledSize();  // _originatingEntityID
            marshalSize = marshalSize + _receivingEntityID.getMarshalledSize();  // _receivingEntityID

            return marshalSize;
        }


        ///<summary>
        ///Object originatig the request
        ///</summary>
        public void setOriginatingEntityID(EntityID pOriginatingEntityID)
        { 
            _originatingEntityID = pOriginatingEntityID;
        }

        ///<summary>
        ///Object originatig the request
        ///</summary>
        public EntityID getOriginatingEntityID()
        {
            return _originatingEntityID;
        }

        ///<summary>
        ///Object originatig the request
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="originatingEntityID")]
        public EntityID OriginatingEntityID
        {
            get
            {
                return _originatingEntityID;
            }
            set
            {
                _originatingEntityID = value;
            }
        }

        ///<summary>
        ///Object with which this point object is associated
        ///</summary>
        public void setReceivingEntityID(EntityID pReceivingEntityID)
        { 
            _receivingEntityID = pReceivingEntityID;
        }

        ///<summary>
        ///Object with which this point object is associated
        ///</summary>
        public EntityID getReceivingEntityID()
        {
            return _receivingEntityID;
        }

        ///<summary>
        ///Object with which this point object is associated
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
        ///Automatically sets the length of the marshalled data, then calls the marshal method.
        ///</summary>
        public void marshalAutoLengthSet(DataOutputStream dos)
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
                _originatingEntityID.marshal(dos);
                _receivingEntityID.marshal(dos);
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
                _originatingEntityID.unmarshal(dis);
                _receivingEntityID.unmarshal(dis);
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
            sb.Append("<SimulationManagementWithReliabilityFamilyPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<originatingEntityID>"  + System.Environment.NewLine);
                _originatingEntityID.reflection(sb);
                sb.Append("</originatingEntityID>"  + System.Environment.NewLine);
                sb.Append("<receivingEntityID>"  + System.Environment.NewLine);
                _receivingEntityID.reflection(sb);
                sb.Append("</receivingEntityID>"  + System.Environment.NewLine);
                sb.Append("</SimulationManagementWithReliabilityFamilyPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(SimulationManagementWithReliabilityFamilyPdu a, SimulationManagementWithReliabilityFamilyPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(SimulationManagementWithReliabilityFamilyPdu a, SimulationManagementWithReliabilityFamilyPdu b)
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
            return this == obj as SimulationManagementWithReliabilityFamilyPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(SimulationManagementWithReliabilityFamilyPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_originatingEntityID.Equals( rhs._originatingEntityID) )) ivarsEqual = false;
            if( ! (_receivingEntityID.Equals( rhs._receivingEntityID) )) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _originatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _receivingEntityID.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
