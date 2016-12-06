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
     * Section 5.3.5.2. Information about a request for supplies. COMPLETE
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
    [XmlInclude(typeof(SupplyQuantity))]
    public partial class ResupplyOfferPdu : LogisticsFamilyPdu
    {
        /** Entity that is receiving service */
        protected EntityID  _receivingEntityID = new EntityID(); 

        /** Entity that is supplying */
        protected EntityID  _supplyingEntityID = new EntityID(); 

        /** how many supplies are being offered */
        protected byte  _numberOfSupplyTypes;

        /** padding */
        protected short  _padding1 = 0;

        /** padding */
        protected byte  _padding2 = 0;

        protected List<SupplyQuantity> _supplies = new List<SupplyQuantity>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.5.2. Information about a request for supplies. COMPLETE
        ///</summary>
        public ResupplyOfferPdu()
        {
            PduType = (byte)6;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _receivingEntityID.getMarshalledSize();  // _receivingEntityID
            marshalSize = marshalSize + _supplyingEntityID.getMarshalledSize();  // _supplyingEntityID
            marshalSize = marshalSize + 1;  // _numberOfSupplyTypes
            marshalSize = marshalSize + 2;  // _padding1
            marshalSize = marshalSize + 1;  // _padding2
            for(int idx=0; idx < _supplies.Count; idx++)
            {
                SupplyQuantity listElement = (SupplyQuantity)_supplies[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Entity that is receiving service
        ///</summary>
        public void setReceivingEntityID(EntityID pReceivingEntityID)
        { 
            _receivingEntityID = pReceivingEntityID;
        }

        ///<summary>
        ///Entity that is receiving service
        ///</summary>
        public EntityID getReceivingEntityID()
        {
            return _receivingEntityID;
        }

        ///<summary>
        ///Entity that is receiving service
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
        ///Entity that is supplying
        ///</summary>
        public void setSupplyingEntityID(EntityID pSupplyingEntityID)
        { 
            _supplyingEntityID = pSupplyingEntityID;
        }

        ///<summary>
        ///Entity that is supplying
        ///</summary>
        public EntityID getSupplyingEntityID()
        {
            return _supplyingEntityID;
        }

        ///<summary>
        ///Entity that is supplying
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="supplyingEntityID")]
        public EntityID SupplyingEntityID
        {
            get
            {
                return _supplyingEntityID;
            }
            set
            {
                _supplyingEntityID = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSupplyTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfSupplyTypes(byte pNumberOfSupplyTypes)
        {
            _numberOfSupplyTypes = pNumberOfSupplyTypes;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSupplyTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfSupplyTypes")]
        public byte NumberOfSupplyTypes
        {
            get
            {
                return _numberOfSupplyTypes;
            }
            set
            {
                _numberOfSupplyTypes = value;
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

        public void setSupplies(List<SupplyQuantity> pSupplies)
        {
            _supplies = pSupplies;
        }

        public List<SupplyQuantity> getSupplies()
        {
            return _supplies;
        }

        [XmlElement(ElementName = "suppliesList",Type = typeof(List<SupplyQuantity>))]
        public List<SupplyQuantity> Supplies
        {
            get
            {
                return _supplies;
            }
            set
            {
                _supplies = value;
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
                _receivingEntityID.marshal(dos);
                _supplyingEntityID.marshal(dos);
                dos.writeByte((byte)_supplies.Count);
                dos.writeShort((short)_padding1);
                dos.writeByte((byte)_padding2);

                for(int idx = 0; idx < _supplies.Count; idx++)
                {
                    SupplyQuantity aSupplyQuantity = (SupplyQuantity)_supplies[idx];
                    aSupplyQuantity.marshal(dos);
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
                _receivingEntityID.unmarshal(dis);
                _supplyingEntityID.unmarshal(dis);
                _numberOfSupplyTypes = dis.readByte();
                _padding1 = dis.readShort();
                _padding2 = dis.readByte();
                for(int idx = 0; idx < _numberOfSupplyTypes; idx++)
                {
                    SupplyQuantity anX = new SupplyQuantity();
                    anX.unmarshal(dis);
                    _supplies.Add(anX);
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
            sb.Append("<ResupplyOfferPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<receivingEntityID>"  + System.Environment.NewLine);
                _receivingEntityID.reflection(sb);
                sb.Append("</receivingEntityID>"  + System.Environment.NewLine);
                sb.Append("<supplyingEntityID>"  + System.Environment.NewLine);
                _supplyingEntityID.reflection(sb);
                sb.Append("</supplyingEntityID>"  + System.Environment.NewLine);
                sb.Append("<supplies type=\"byte\">" + _supplies.Count.ToString() + "</supplies> " + System.Environment.NewLine);
                sb.Append("<padding1 type=\"short\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
                sb.Append("<padding2 type=\"byte\">" + _padding2.ToString() + "</padding2> " + System.Environment.NewLine);

            for(int idx = 0; idx < _supplies.Count; idx++)
            {
                sb.Append("<supplies"+ idx.ToString() + " type=\"SupplyQuantity\">" + System.Environment.NewLine);
                SupplyQuantity aSupplyQuantity = (SupplyQuantity)_supplies[idx];
                aSupplyQuantity.reflection(sb);
                sb.Append("</supplies"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</ResupplyOfferPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(ResupplyOfferPdu a, ResupplyOfferPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(ResupplyOfferPdu a, ResupplyOfferPdu b)
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
            return this == obj as ResupplyOfferPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(ResupplyOfferPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_receivingEntityID.Equals( rhs._receivingEntityID) )) ivarsEqual = false;
            if( ! (_supplyingEntityID.Equals( rhs._supplyingEntityID) )) ivarsEqual = false;
            if( ! (_numberOfSupplyTypes == rhs._numberOfSupplyTypes)) ivarsEqual = false;
            if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
            if( ! (_padding2 == rhs._padding2)) ivarsEqual = false;

            if( ! (_supplies.Count == rhs._supplies.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _supplies.Count; idx++)
                {
                    if( ! ( _supplies[idx].Equals(rhs._supplies[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _receivingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _supplyingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _numberOfSupplyTypes.GetHashCode();
            result = GenerateHash(result) ^ _padding1.GetHashCode();
            result = GenerateHash(result) ^ _padding2.GetHashCode();

            if(_supplies.Count > 0)
            {
                for(int idx = 0; idx < _supplies.Count; idx++)
                {
                    result = GenerateHash(result) ^ _supplies[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
