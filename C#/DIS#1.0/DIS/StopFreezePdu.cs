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
     * Section 5.2.3.4. Stop or freeze an exercise. COMPLETE
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
    [XmlInclude(typeof(ClockTime))]
    public partial class StopFreezePdu : SimulationManagementFamilyPdu
    {
        /** UTC time at which the simulation shall stop or freeze */
        protected ClockTime  _realWorldTime = new ClockTime(); 

        /** Reason the simulation was stopped or frozen */
        protected byte  _reason;

        /** Internal behavior of the simulation and its appearance while frozento the other participants */
        protected byte  _frozenBehavior;

        /** padding */
        protected short  _padding1 = 0;

        /** Request ID that is unique */
        protected uint  _requestID;


        /** Constructor */
        ///<summary>
        ///Section 5.2.3.4. Stop or freeze an exercise. COMPLETE
        ///</summary>
        public StopFreezePdu()
        {
            PduType = (byte)14;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _realWorldTime.getMarshalledSize();  // _realWorldTime
            marshalSize = marshalSize + 1;  // _reason
            marshalSize = marshalSize + 1;  // _frozenBehavior
            marshalSize = marshalSize + 2;  // _padding1
            marshalSize = marshalSize + 4;  // _requestID

            return marshalSize;
        }


        ///<summary>
        ///UTC time at which the simulation shall stop or freeze
        ///</summary>
        public void setRealWorldTime(ClockTime pRealWorldTime)
        { 
            _realWorldTime = pRealWorldTime;
        }

        ///<summary>
        ///UTC time at which the simulation shall stop or freeze
        ///</summary>
        public ClockTime getRealWorldTime()
        {
            return _realWorldTime;
        }

        ///<summary>
        ///UTC time at which the simulation shall stop or freeze
        ///</summary>
        [XmlElement(Type= typeof(ClockTime), ElementName="realWorldTime")]
        public ClockTime RealWorldTime
        {
            get
            {
                return _realWorldTime;
            }
            set
            {
                _realWorldTime = value;
            }
        }

        ///<summary>
        ///Reason the simulation was stopped or frozen
        ///</summary>
        public void setReason(byte pReason)
        { 
            _reason = pReason;
        }

        [XmlElement(Type= typeof(byte), ElementName="reason")]
        public byte Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
            }
        }

        ///<summary>
        ///Internal behavior of the simulation and its appearance while frozento the other participants
        ///</summary>
        public void setFrozenBehavior(byte pFrozenBehavior)
        { 
            _frozenBehavior = pFrozenBehavior;
        }

        [XmlElement(Type= typeof(byte), ElementName="frozenBehavior")]
        public byte FrozenBehavior
        {
            get
            {
                return _frozenBehavior;
            }
            set
            {
                _frozenBehavior = value;
            }
        }

        ///<summary>
        ///padding
        ///</summary>
        public void setPadding1(short pPadding1)
        { 
            _padding1 = pPadding1;
        }

        [XmlElement(Type= typeof(short), ElementName="padding1")]
        public short Padding1
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
        ///Request ID that is unique
        ///</summary>
        public void setRequestID(uint pRequestID)
        { 
            _requestID = pRequestID;
        }

        [XmlElement(Type= typeof(uint), ElementName="requestID")]
        public uint RequestID
        {
            get
            {
                return _requestID;
            }
            set
            {
                _requestID = value;
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
                _realWorldTime.marshal(dos);
                dos.writeByte((byte)_reason);
                dos.writeByte((byte)_frozenBehavior);
                dos.writeShort((short)_padding1);
                dos.writeUint((uint)_requestID);
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
                _realWorldTime.unmarshal(dis);
                _reason = dis.readByte();
                _frozenBehavior = dis.readByte();
                _padding1 = dis.readShort();
                _requestID = dis.readUint();
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
            sb.Append("<StopFreezePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<realWorldTime>"  + System.Environment.NewLine);
                _realWorldTime.reflection(sb);
                sb.Append("</realWorldTime>"  + System.Environment.NewLine);
                sb.Append("<reason type=\"byte\">" + _reason.ToString() + "</reason> " + System.Environment.NewLine);
                sb.Append("<frozenBehavior type=\"byte\">" + _frozenBehavior.ToString() + "</frozenBehavior> " + System.Environment.NewLine);
                sb.Append("<padding1 type=\"short\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
                sb.Append("<requestID type=\"uint\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
                sb.Append("</StopFreezePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(StopFreezePdu a, StopFreezePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(StopFreezePdu a, StopFreezePdu b)
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
            return this == obj as StopFreezePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(StopFreezePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_realWorldTime.Equals( rhs._realWorldTime) )) ivarsEqual = false;
            if( ! (_reason == rhs._reason)) ivarsEqual = false;
            if( ! (_frozenBehavior == rhs._frozenBehavior)) ivarsEqual = false;
            if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
            if( ! (_requestID == rhs._requestID)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _realWorldTime.GetHashCode();
            result = GenerateHash(result) ^ _reason.GetHashCode();
            result = GenerateHash(result) ^ _frozenBehavior.GetHashCode();
            result = GenerateHash(result) ^ _padding1.GetHashCode();
            result = GenerateHash(result) ^ _requestID.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
