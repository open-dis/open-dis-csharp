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
     * 5.2.46.  Intercom communcations parameters
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
    public partial class IntercomCommunicationsParameters : Object
    {
        /** Type of intercom parameters record */
        protected ushort  _recordType;

        /** length of record */
        protected ushort  _recordLength;

        /** Jerks. Looks like the committee is forcing a lookup of the record type parameter to find out how long the field is. This is a placeholder. */
        protected uint  _recordSpecificField;


        /** Constructor */
        ///<summary>
        ///5.2.46.  Intercom communcations parameters
        ///</summary>
        public IntercomCommunicationsParameters()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 2;  // _recordType
            marshalSize = marshalSize + 2;  // _recordLength
            marshalSize = marshalSize + 4;  // _recordSpecificField

            return marshalSize;
        }


        ///<summary>
        ///Type of intercom parameters record
        ///</summary>
        public void setRecordType(ushort pRecordType)
        { 
            _recordType = pRecordType;
        }

        [XmlElement(Type= typeof(ushort), ElementName="recordType")]
        public ushort RecordType
        {
            get
            {
                return _recordType;
            }
            set
            {
                _recordType = value;
            }
        }

        ///<summary>
        ///length of record
        ///</summary>
        public void setRecordLength(ushort pRecordLength)
        { 
            _recordLength = pRecordLength;
        }

        [XmlElement(Type= typeof(ushort), ElementName="recordLength")]
        public ushort RecordLength
        {
            get
            {
                return _recordLength;
            }
            set
            {
                _recordLength = value;
            }
        }

        ///<summary>
        ///Jerks. Looks like the committee is forcing a lookup of the record type parameter to find out how long the field is. This is a placeholder.
        ///</summary>
        public void setRecordSpecificField(uint pRecordSpecificField)
        { 
            _recordSpecificField = pRecordSpecificField;
        }

        [XmlElement(Type= typeof(uint), ElementName="recordSpecificField")]
        public uint RecordSpecificField
        {
            get
            {
                return _recordSpecificField;
            }
            set
            {
                _recordSpecificField = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeUshort((ushort)_recordType);
                dos.writeUshort((ushort)_recordLength);
                dos.writeUint((uint)_recordSpecificField);
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
                _recordType = dis.readUshort();
                _recordLength = dis.readUshort();
                _recordSpecificField = dis.readUint();
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
            sb.Append("<IntercomCommunicationsParameters>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<recordType type=\"ushort\">" + _recordType.ToString() + "</recordType> " + System.Environment.NewLine);
                sb.Append("<recordLength type=\"ushort\">" + _recordLength.ToString() + "</recordLength> " + System.Environment.NewLine);
                sb.Append("<recordSpecificField type=\"uint\">" + _recordSpecificField.ToString() + "</recordSpecificField> " + System.Environment.NewLine);
                sb.Append("</IntercomCommunicationsParameters>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(IntercomCommunicationsParameters a, IntercomCommunicationsParameters b)
        {
            return !(a == b);
        }

        public static bool operator ==(IntercomCommunicationsParameters a, IntercomCommunicationsParameters b)
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
            return this == obj as IntercomCommunicationsParameters;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(IntercomCommunicationsParameters rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_recordType == rhs._recordType)) ivarsEqual = false;
            if( ! (_recordLength == rhs._recordLength)) ivarsEqual = false;
            if( ! (_recordSpecificField == rhs._recordSpecificField)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _recordType.GetHashCode();
            result = GenerateHash(result) ^ _recordLength.GetHashCode();
            result = GenerateHash(result) ^ _recordSpecificField.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
