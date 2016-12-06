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
     * Section 5.3.8.3. Communication of a receiver state. COMPLETE
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
    public partial class ReceiverPdu : RadioCommunicationsFamilyPdu
    {
        /** encoding scheme used, and enumeration */
        protected ushort  _receiverState;

        /** padding */
        protected ushort  _padding1;

        /** received power */
        protected float  _receivedPoser;

        /** ID of transmitter */
        protected EntityID  _transmitterEntityId = new EntityID(); 

        /** ID of transmitting radio */
        protected ushort  _transmitterRadioId;


        /** Constructor */
        ///<summary>
        ///Section 5.3.8.3. Communication of a receiver state. COMPLETE
        ///</summary>
        public ReceiverPdu()
        {
            PduType = (byte)27;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + 2;  // _receiverState
            marshalSize = marshalSize + 2;  // _padding1
            marshalSize = marshalSize + 4;  // _receivedPoser
            marshalSize = marshalSize + _transmitterEntityId.getMarshalledSize();  // _transmitterEntityId
            marshalSize = marshalSize + 2;  // _transmitterRadioId

            return marshalSize;
        }


        ///<summary>
        ///encoding scheme used, and enumeration
        ///</summary>
        public void setReceiverState(ushort pReceiverState)
        { 
            _receiverState = pReceiverState;
        }

        [XmlElement(Type= typeof(ushort), ElementName="receiverState")]
        public ushort ReceiverState
        {
            get
            {
                return _receiverState;
            }
            set
            {
                _receiverState = value;
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
        ///received power
        ///</summary>
        public void setReceivedPoser(float pReceivedPoser)
        { 
            _receivedPoser = pReceivedPoser;
        }

        [XmlElement(Type= typeof(float), ElementName="receivedPoser")]
        public float ReceivedPoser
        {
            get
            {
                return _receivedPoser;
            }
            set
            {
                _receivedPoser = value;
            }
        }

        ///<summary>
        ///ID of transmitter
        ///</summary>
        public void setTransmitterEntityId(EntityID pTransmitterEntityId)
        { 
            _transmitterEntityId = pTransmitterEntityId;
        }

        ///<summary>
        ///ID of transmitter
        ///</summary>
        public EntityID getTransmitterEntityId()
        {
            return _transmitterEntityId;
        }

        ///<summary>
        ///ID of transmitter
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="transmitterEntityId")]
        public EntityID TransmitterEntityId
        {
            get
            {
                return _transmitterEntityId;
            }
            set
            {
                _transmitterEntityId = value;
            }
        }

        ///<summary>
        ///ID of transmitting radio
        ///</summary>
        public void setTransmitterRadioId(ushort pTransmitterRadioId)
        { 
            _transmitterRadioId = pTransmitterRadioId;
        }

        [XmlElement(Type= typeof(ushort), ElementName="transmitterRadioId")]
        public ushort TransmitterRadioId
        {
            get
            {
                return _transmitterRadioId;
            }
            set
            {
                _transmitterRadioId = value;
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
                dos.writeUshort((ushort)_receiverState);
                dos.writeUshort((ushort)_padding1);
                dos.writeFloat((float)_receivedPoser);
                _transmitterEntityId.marshal(dos);
                dos.writeUshort((ushort)_transmitterRadioId);
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
                _receiverState = dis.readUshort();
                _padding1 = dis.readUshort();
                _receivedPoser = dis.readFloat();
                _transmitterEntityId.unmarshal(dis);
                _transmitterRadioId = dis.readUshort();
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
            sb.Append("<ReceiverPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<receiverState type=\"ushort\">" + _receiverState.ToString() + "</receiverState> " + System.Environment.NewLine);
                sb.Append("<padding1 type=\"ushort\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
                sb.Append("<receivedPoser type=\"float\">" + _receivedPoser.ToString() + "</receivedPoser> " + System.Environment.NewLine);
                sb.Append("<transmitterEntityId>"  + System.Environment.NewLine);
                _transmitterEntityId.reflection(sb);
                sb.Append("</transmitterEntityId>"  + System.Environment.NewLine);
                sb.Append("<transmitterRadioId type=\"ushort\">" + _transmitterRadioId.ToString() + "</transmitterRadioId> " + System.Environment.NewLine);
                sb.Append("</ReceiverPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(ReceiverPdu a, ReceiverPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(ReceiverPdu a, ReceiverPdu b)
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
            return this == obj as ReceiverPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(ReceiverPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_receiverState == rhs._receiverState)) ivarsEqual = false;
            if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
            if( ! (_receivedPoser == rhs._receivedPoser)) ivarsEqual = false;
            if( ! (_transmitterEntityId.Equals( rhs._transmitterEntityId) )) ivarsEqual = false;
            if( ! (_transmitterRadioId == rhs._transmitterRadioId)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _receiverState.GetHashCode();
            result = GenerateHash(result) ^ _padding1.GetHashCode();
            result = GenerateHash(result) ^ _receivedPoser.GetHashCode();
            result = GenerateHash(result) ^ _transmitterEntityId.GetHashCode();
            result = GenerateHash(result) ^ _transmitterRadioId.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
