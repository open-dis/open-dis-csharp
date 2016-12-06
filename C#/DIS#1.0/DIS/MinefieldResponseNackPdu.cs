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
     * Section 5.3.10.4 proivde the means to request a retransmit of a minefield data pdu. COMPLETE
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
    [XmlInclude(typeof(EightByteChunk))]
    public partial class MinefieldResponseNackPdu : MinefieldFamilyPdu
    {
        /** Minefield ID */
        protected EntityID  _minefieldID = new EntityID(); 

        /** entity ID making the request */
        protected EntityID  _requestingEntityID = new EntityID(); 

        /** request ID */
        protected byte  _requestID;

        /** how many pdus were missing */
        protected byte  _numberOfMissingPdus;

        /** PDU sequence numbers that were missing */
        protected List<EightByteChunk> _missingPduSequenceNumbers = new List<EightByteChunk>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.10.4 proivde the means to request a retransmit of a minefield data pdu. COMPLETE
        ///</summary>
        public MinefieldResponseNackPdu()
        {
            PduType = (byte)40;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _minefieldID.getMarshalledSize();  // _minefieldID
            marshalSize = marshalSize + _requestingEntityID.getMarshalledSize();  // _requestingEntityID
            marshalSize = marshalSize + 1;  // _requestID
            marshalSize = marshalSize + 1;  // _numberOfMissingPdus
            for(int idx=0; idx < _missingPduSequenceNumbers.Count; idx++)
            {
                EightByteChunk listElement = (EightByteChunk)_missingPduSequenceNumbers[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Minefield ID
        ///</summary>
        public void setMinefieldID(EntityID pMinefieldID)
        { 
            _minefieldID = pMinefieldID;
        }

        ///<summary>
        ///Minefield ID
        ///</summary>
        public EntityID getMinefieldID()
        {
            return _minefieldID;
        }

        ///<summary>
        ///Minefield ID
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="minefieldID")]
        public EntityID MinefieldID
        {
            get
            {
                return _minefieldID;
            }
            set
            {
                _minefieldID = value;
            }
        }

        ///<summary>
        ///entity ID making the request
        ///</summary>
        public void setRequestingEntityID(EntityID pRequestingEntityID)
        { 
            _requestingEntityID = pRequestingEntityID;
        }

        ///<summary>
        ///entity ID making the request
        ///</summary>
        public EntityID getRequestingEntityID()
        {
            return _requestingEntityID;
        }

        ///<summary>
        ///entity ID making the request
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="requestingEntityID")]
        public EntityID RequestingEntityID
        {
            get
            {
                return _requestingEntityID;
            }
            set
            {
                _requestingEntityID = value;
            }
        }

        ///<summary>
        ///request ID
        ///</summary>
        public void setRequestID(byte pRequestID)
        { 
            _requestID = pRequestID;
        }

        [XmlElement(Type= typeof(byte), ElementName="requestID")]
        public byte RequestID
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

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMissingPdus method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfMissingPdus(byte pNumberOfMissingPdus)
        {
            _numberOfMissingPdus = pNumberOfMissingPdus;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMissingPdus method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfMissingPdus")]
        public byte NumberOfMissingPdus
        {
            get
            {
                return _numberOfMissingPdus;
            }
            set
            {
                _numberOfMissingPdus = value;
            }
        }

        ///<summary>
        ///PDU sequence numbers that were missing
        ///</summary>
        public void setMissingPduSequenceNumbers(List<EightByteChunk> pMissingPduSequenceNumbers)
        {
            _missingPduSequenceNumbers = pMissingPduSequenceNumbers;
        }

        ///<summary>
        ///PDU sequence numbers that were missing
        ///</summary>
        public List<EightByteChunk> getMissingPduSequenceNumbers()
        {
            return _missingPduSequenceNumbers;
        }

        ///<summary>
        ///PDU sequence numbers that were missing
        ///</summary>
        [XmlElement(ElementName = "missingPduSequenceNumbersList",Type = typeof(List<EightByteChunk>))]
        public List<EightByteChunk> MissingPduSequenceNumbers
        {
            get
            {
                return _missingPduSequenceNumbers;
            }
            set
            {
                _missingPduSequenceNumbers = value;
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
                _minefieldID.marshal(dos);
                _requestingEntityID.marshal(dos);
                dos.writeByte((byte)_requestID);
                dos.writeByte((byte)_missingPduSequenceNumbers.Count);

                for(int idx = 0; idx < _missingPduSequenceNumbers.Count; idx++)
                {
                    EightByteChunk aEightByteChunk = (EightByteChunk)_missingPduSequenceNumbers[idx];
                    aEightByteChunk.marshal(dos);
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
                _minefieldID.unmarshal(dis);
                _requestingEntityID.unmarshal(dis);
                _requestID = dis.readByte();
                _numberOfMissingPdus = dis.readByte();
                for(int idx = 0; idx < _numberOfMissingPdus; idx++)
                {
                    EightByteChunk anX = new EightByteChunk();
                    anX.unmarshal(dis);
                    _missingPduSequenceNumbers.Add(anX);
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
            sb.Append("<MinefieldResponseNackPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<minefieldID>"  + System.Environment.NewLine);
                _minefieldID.reflection(sb);
                sb.Append("</minefieldID>"  + System.Environment.NewLine);
                sb.Append("<requestingEntityID>"  + System.Environment.NewLine);
                _requestingEntityID.reflection(sb);
                sb.Append("</requestingEntityID>"  + System.Environment.NewLine);
                sb.Append("<requestID type=\"byte\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
                sb.Append("<missingPduSequenceNumbers type=\"byte\">" + _missingPduSequenceNumbers.Count.ToString() + "</missingPduSequenceNumbers> " + System.Environment.NewLine);

            for(int idx = 0; idx < _missingPduSequenceNumbers.Count; idx++)
            {
                sb.Append("<missingPduSequenceNumbers"+ idx.ToString() + " type=\"EightByteChunk\">" + System.Environment.NewLine);
                EightByteChunk aEightByteChunk = (EightByteChunk)_missingPduSequenceNumbers[idx];
                aEightByteChunk.reflection(sb);
                sb.Append("</missingPduSequenceNumbers"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</MinefieldResponseNackPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(MinefieldResponseNackPdu a, MinefieldResponseNackPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(MinefieldResponseNackPdu a, MinefieldResponseNackPdu b)
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
            return this == obj as MinefieldResponseNackPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(MinefieldResponseNackPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_minefieldID.Equals( rhs._minefieldID) )) ivarsEqual = false;
            if( ! (_requestingEntityID.Equals( rhs._requestingEntityID) )) ivarsEqual = false;
            if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
            if( ! (_numberOfMissingPdus == rhs._numberOfMissingPdus)) ivarsEqual = false;

            if( ! (_missingPduSequenceNumbers.Count == rhs._missingPduSequenceNumbers.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _missingPduSequenceNumbers.Count; idx++)
                {
                    if( ! ( _missingPduSequenceNumbers[idx].Equals(rhs._missingPduSequenceNumbers[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _minefieldID.GetHashCode();
            result = GenerateHash(result) ^ _requestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _requestID.GetHashCode();
            result = GenerateHash(result) ^ _numberOfMissingPdus.GetHashCode();

            if(_missingPduSequenceNumbers.Count > 0)
            {
                for(int idx = 0; idx < _missingPduSequenceNumbers.Count; idx++)
                {
                    result = GenerateHash(result) ^ _missingPduSequenceNumbers[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
