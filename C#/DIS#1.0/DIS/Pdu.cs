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
     * The superclass for all PDUs. This incorporates the PduHeader record, section 5.2.29.
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
    public partial class Pdu : Object
    {
        /** The version of the protocol. 5=DIS-1995, 6=DIS-1998. */
        protected byte  _protocolVersion = 6;

        /** Exercise ID */
        protected byte  _exerciseID = 0;

        /** Type of pdu, unique for each PDU class */
        protected byte  _pduType;

        /** value that refers to the protocol family, eg SimulationManagement, et */
        protected byte  _protocolFamily;

        /** Timestamp value */
        protected uint  _timestamp;

        /** Length, in bytes, of the PDU */
        protected ushort  _length;

        /** zero-filled array of padding */
        protected short  _padding = 0;


        /** Constructor */
        ///<summary>
        ///The superclass for all PDUs. This incorporates the PduHeader record, section 5.2.29.
        ///</summary>
        public Pdu()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 1;  // _protocolVersion
            marshalSize = marshalSize + 1;  // _exerciseID
            marshalSize = marshalSize + 1;  // _pduType
            marshalSize = marshalSize + 1;  // _protocolFamily
            marshalSize = marshalSize + 4;  // _timestamp
            marshalSize = marshalSize + 2;  // _length
            marshalSize = marshalSize + 2;  // _padding

            return marshalSize;
        }


        ///<summary>
        ///The version of the protocol. 5=DIS-1995, 6=DIS-1998.
        ///</summary>
        public void setProtocolVersion(byte pProtocolVersion)
        { 
            _protocolVersion = pProtocolVersion;
        }

        [XmlElement(Type= typeof(byte), ElementName="protocolVersion")]
        public byte ProtocolVersion
        {
            get
            {
                return _protocolVersion;
            }
            set
            {
                _protocolVersion = value;
            }
        }

        ///<summary>
        ///Exercise ID
        ///</summary>
        public void setExerciseID(byte pExerciseID)
        { 
            _exerciseID = pExerciseID;
        }

        [XmlElement(Type= typeof(byte), ElementName="exerciseID")]
        public byte ExerciseID
        {
            get
            {
                return _exerciseID;
            }
            set
            {
                _exerciseID = value;
            }
        }

        ///<summary>
        ///Type of pdu, unique for each PDU class
        ///</summary>
        public void setPduType(byte pPduType)
        { 
            _pduType = pPduType;
        }

        [XmlElement(Type= typeof(byte), ElementName="pduType")]
        public byte PduType
        {
            get
            {
                return _pduType;
            }
            set
            {
                _pduType = value;
            }
        }

        ///<summary>
        ///value that refers to the protocol family, eg SimulationManagement, et
        ///</summary>
        public void setProtocolFamily(byte pProtocolFamily)
        { 
            _protocolFamily = pProtocolFamily;
        }

        [XmlElement(Type= typeof(byte), ElementName="protocolFamily")]
        public byte ProtocolFamily
        {
            get
            {
                return _protocolFamily;
            }
            set
            {
                _protocolFamily = value;
            }
        }

        ///<summary>
        ///Timestamp value
        ///</summary>
        public void setTimestamp(uint pTimestamp)
        { 
            _timestamp = pTimestamp;
        }

        [XmlElement(Type= typeof(uint), ElementName="timestamp")]
        public uint Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
            }
        }

        ///<summary>
        ///Length, in bytes, of the PDU
        ///</summary>
        public void setLength(ushort pLength)
        { 
            _length = pLength;
        }

        [XmlElement(Type= typeof(ushort), ElementName="length")]
        public ushort Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        ///<summary>
        ///zero-filled array of padding
        ///</summary>
        public void setPadding(short pPadding)
        { 
            _padding = pPadding;
        }

        [XmlElement(Type= typeof(short), ElementName="padding")]
        public short Padding
        {
            get
            {
                return _padding;
            }
            set
            {
                _padding = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeByte((byte)_protocolVersion);
                dos.writeByte((byte)_exerciseID);
                dos.writeByte((byte)_pduType);
                dos.writeByte((byte)_protocolFamily);
                dos.writeUint((uint)_timestamp);
                dos.writeUshort((ushort)_length);
                dos.writeShort((short)_padding);
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
                _protocolVersion = dis.readByte();
                _exerciseID = dis.readByte();
                _pduType = dis.readByte();
                _protocolFamily = dis.readByte();
                _timestamp = dis.readUint();
                _length = dis.readUshort();
                _padding = dis.readShort();
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
            sb.Append("<Pdu>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<protocolVersion type=\"byte\">" + _protocolVersion.ToString() + "</protocolVersion> " + System.Environment.NewLine);
                sb.Append("<exerciseID type=\"byte\">" + _exerciseID.ToString() + "</exerciseID> " + System.Environment.NewLine);
                sb.Append("<pduType type=\"byte\">" + _pduType.ToString() + "</pduType> " + System.Environment.NewLine);
                sb.Append("<protocolFamily type=\"byte\">" + _protocolFamily.ToString() + "</protocolFamily> " + System.Environment.NewLine);
                sb.Append("<timestamp type=\"uint\">" + _timestamp.ToString() + "</timestamp> " + System.Environment.NewLine);
                sb.Append("<length type=\"ushort\">" + _length.ToString() + "</length> " + System.Environment.NewLine);
                sb.Append("<padding type=\"short\">" + _padding.ToString() + "</padding> " + System.Environment.NewLine);
                sb.Append("</Pdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(Pdu a, Pdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(Pdu a, Pdu b)
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
            return this == obj as Pdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(Pdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_protocolVersion == rhs._protocolVersion)) ivarsEqual = false;
            if( ! (_exerciseID == rhs._exerciseID)) ivarsEqual = false;
            if( ! (_pduType == rhs._pduType)) ivarsEqual = false;
            if( ! (_protocolFamily == rhs._protocolFamily)) ivarsEqual = false;
            if( ! (_timestamp == rhs._timestamp)) ivarsEqual = false;
            if( ! (_length == rhs._length)) ivarsEqual = false;
            if( ! (_padding == rhs._padding)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _protocolVersion.GetHashCode();
            result = GenerateHash(result) ^ _exerciseID.GetHashCode();
            result = GenerateHash(result) ^ _pduType.GetHashCode();
            result = GenerateHash(result) ^ _protocolFamily.GetHashCode();
            result = GenerateHash(result) ^ _timestamp.GetHashCode();
            result = GenerateHash(result) ^ _length.GetHashCode();
            result = GenerateHash(result) ^ _padding.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
