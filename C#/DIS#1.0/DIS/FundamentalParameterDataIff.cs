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
     * 5.2.45. Fundamental IFF atc data
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
    public partial class FundamentalParameterDataIff : Object
    {
        /** ERP */
        protected float  _erp;

        /** frequency */
        protected float  _frequency;

        /** pgrf */
        protected float  _pgrf;

        /** Pulse width */
        protected float  _pulseWidth;

        /** Burst length */
        protected uint  _burstLength;

        /** Applicable modes enumeration */
        protected byte  _applicableModes;

        /** padding */
        protected ushort  _pad2;

        /** padding */
        protected byte  _pad3;


        /** Constructor */
        ///<summary>
        ///5.2.45. Fundamental IFF atc data
        ///</summary>
        public FundamentalParameterDataIff()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 4;  // _erp
            marshalSize = marshalSize + 4;  // _frequency
            marshalSize = marshalSize + 4;  // _pgrf
            marshalSize = marshalSize + 4;  // _pulseWidth
            marshalSize = marshalSize + 4;  // _burstLength
            marshalSize = marshalSize + 1;  // _applicableModes
            marshalSize = marshalSize + 2;  // _pad2
            marshalSize = marshalSize + 1;  // _pad3

            return marshalSize;
        }


        ///<summary>
        ///ERP
        ///</summary>
        public void setErp(float pErp)
        { 
            _erp = pErp;
        }

        [XmlElement(Type= typeof(float), ElementName="erp")]
        public float Erp
        {
            get
            {
                return _erp;
            }
            set
            {
                _erp = value;
            }
        }

        ///<summary>
        ///frequency
        ///</summary>
        public void setFrequency(float pFrequency)
        { 
            _frequency = pFrequency;
        }

        [XmlElement(Type= typeof(float), ElementName="frequency")]
        public float Frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                _frequency = value;
            }
        }

        ///<summary>
        ///pgrf
        ///</summary>
        public void setPgrf(float pPgrf)
        { 
            _pgrf = pPgrf;
        }

        [XmlElement(Type= typeof(float), ElementName="pgrf")]
        public float Pgrf
        {
            get
            {
                return _pgrf;
            }
            set
            {
                _pgrf = value;
            }
        }

        ///<summary>
        ///Pulse width
        ///</summary>
        public void setPulseWidth(float pPulseWidth)
        { 
            _pulseWidth = pPulseWidth;
        }

        [XmlElement(Type= typeof(float), ElementName="pulseWidth")]
        public float PulseWidth
        {
            get
            {
                return _pulseWidth;
            }
            set
            {
                _pulseWidth = value;
            }
        }

        ///<summary>
        ///Burst length
        ///</summary>
        public void setBurstLength(uint pBurstLength)
        { 
            _burstLength = pBurstLength;
        }

        [XmlElement(Type= typeof(uint), ElementName="burstLength")]
        public uint BurstLength
        {
            get
            {
                return _burstLength;
            }
            set
            {
                _burstLength = value;
            }
        }

        ///<summary>
        ///Applicable modes enumeration
        ///</summary>
        public void setApplicableModes(byte pApplicableModes)
        { 
            _applicableModes = pApplicableModes;
        }

        [XmlElement(Type= typeof(byte), ElementName="applicableModes")]
        public byte ApplicableModes
        {
            get
            {
                return _applicableModes;
            }
            set
            {
                _applicableModes = value;
            }
        }

        ///<summary>
        ///padding
        ///</summary>
        public void setPad2(ushort pPad2)
        { 
            _pad2 = pPad2;
        }

        [XmlElement(Type= typeof(ushort), ElementName="pad2")]
        public ushort Pad2
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
        ///padding
        ///</summary>
        public void setPad3(byte pPad3)
        { 
            _pad3 = pPad3;
        }

        [XmlElement(Type= typeof(byte), ElementName="pad3")]
        public byte Pad3
        {
            get
            {
                return _pad3;
            }
            set
            {
                _pad3 = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeFloat((float)_erp);
                dos.writeFloat((float)_frequency);
                dos.writeFloat((float)_pgrf);
                dos.writeFloat((float)_pulseWidth);
                dos.writeUint((uint)_burstLength);
                dos.writeByte((byte)_applicableModes);
                dos.writeUshort((ushort)_pad2);
                dos.writeByte((byte)_pad3);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of marshal method

        public void unmarshal(DataInputStream dis)
        {
            try
            {
                _erp = dis.readFloat();
                _frequency = dis.readFloat();
                _pgrf = dis.readFloat();
                _pulseWidth = dis.readFloat();
                _burstLength = dis.readUint();
                _applicableModes = dis.readByte();
                _pad2 = dis.readUshort();
                _pad3 = dis.readByte();
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
        public void reflection(StringBuilder sb)
        {
            sb.Append("<FundamentalParameterDataIff>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<erp type=\"float\">" + _erp.ToString() + "</erp> " + System.Environment.NewLine);
                sb.Append("<frequency type=\"float\">" + _frequency.ToString() + "</frequency> " + System.Environment.NewLine);
                sb.Append("<pgrf type=\"float\">" + _pgrf.ToString() + "</pgrf> " + System.Environment.NewLine);
                sb.Append("<pulseWidth type=\"float\">" + _pulseWidth.ToString() + "</pulseWidth> " + System.Environment.NewLine);
                sb.Append("<burstLength type=\"uint\">" + _burstLength.ToString() + "</burstLength> " + System.Environment.NewLine);
                sb.Append("<applicableModes type=\"byte\">" + _applicableModes.ToString() + "</applicableModes> " + System.Environment.NewLine);
                sb.Append("<pad2 type=\"ushort\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
                sb.Append("<pad3 type=\"byte\">" + _pad3.ToString() + "</pad3> " + System.Environment.NewLine);
                sb.Append("</FundamentalParameterDataIff>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(FundamentalParameterDataIff a, FundamentalParameterDataIff b)
        {
            return !(a == b);
        }

        public static bool operator ==(FundamentalParameterDataIff a, FundamentalParameterDataIff b)
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
            return this == obj as FundamentalParameterDataIff;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(FundamentalParameterDataIff rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_erp == rhs._erp)) ivarsEqual = false;
            if( ! (_frequency == rhs._frequency)) ivarsEqual = false;
            if( ! (_pgrf == rhs._pgrf)) ivarsEqual = false;
            if( ! (_pulseWidth == rhs._pulseWidth)) ivarsEqual = false;
            if( ! (_burstLength == rhs._burstLength)) ivarsEqual = false;
            if( ! (_applicableModes == rhs._applicableModes)) ivarsEqual = false;
            if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
            if( ! (_pad3 == rhs._pad3)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _erp.GetHashCode();
            result = GenerateHash(result) ^ _frequency.GetHashCode();
            result = GenerateHash(result) ^ _pgrf.GetHashCode();
            result = GenerateHash(result) ^ _pulseWidth.GetHashCode();
            result = GenerateHash(result) ^ _burstLength.GetHashCode();
            result = GenerateHash(result) ^ _applicableModes.GetHashCode();
            result = GenerateHash(result) ^ _pad2.GetHashCode();
            result = GenerateHash(result) ^ _pad3.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
