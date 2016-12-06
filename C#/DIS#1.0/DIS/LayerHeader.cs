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
     * 5.2.47.  Layer header.
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
    public partial class LayerHeader : Object
    {
        /** Layer number */
        protected byte  _layerNumber;

        /** Layer speccific information enumeration */
        protected byte  _layerSpecificInformaiton;

        /** information length */
        protected ushort  _length;


        /** Constructor */
        ///<summary>
        ///5.2.47.  Layer header.
        ///</summary>
        public LayerHeader()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 1;  // _layerNumber
            marshalSize = marshalSize + 1;  // _layerSpecificInformaiton
            marshalSize = marshalSize + 2;  // _length

            return marshalSize;
        }


        ///<summary>
        ///Layer number
        ///</summary>
        public void setLayerNumber(byte pLayerNumber)
        { 
            _layerNumber = pLayerNumber;
        }

        [XmlElement(Type= typeof(byte), ElementName="layerNumber")]
        public byte LayerNumber
        {
            get
            {
                return _layerNumber;
            }
            set
            {
                _layerNumber = value;
            }
        }

        ///<summary>
        ///Layer speccific information enumeration
        ///</summary>
        public void setLayerSpecificInformaiton(byte pLayerSpecificInformaiton)
        { 
            _layerSpecificInformaiton = pLayerSpecificInformaiton;
        }

        [XmlElement(Type= typeof(byte), ElementName="layerSpecificInformaiton")]
        public byte LayerSpecificInformaiton
        {
            get
            {
                return _layerSpecificInformaiton;
            }
            set
            {
                _layerSpecificInformaiton = value;
            }
        }

        ///<summary>
        ///information length
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
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeByte((byte)_layerNumber);
                dos.writeByte((byte)_layerSpecificInformaiton);
                dos.writeUshort((ushort)_length);
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
                _layerNumber = dis.readByte();
                _layerSpecificInformaiton = dis.readByte();
                _length = dis.readUshort();
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
            sb.Append("<LayerHeader>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<layerNumber type=\"byte\">" + _layerNumber.ToString() + "</layerNumber> " + System.Environment.NewLine);
                sb.Append("<layerSpecificInformaiton type=\"byte\">" + _layerSpecificInformaiton.ToString() + "</layerSpecificInformaiton> " + System.Environment.NewLine);
                sb.Append("<length type=\"ushort\">" + _length.ToString() + "</length> " + System.Environment.NewLine);
                sb.Append("</LayerHeader>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(LayerHeader a, LayerHeader b)
        {
            return !(a == b);
        }

        public static bool operator ==(LayerHeader a, LayerHeader b)
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
            return this == obj as LayerHeader;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(LayerHeader rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_layerNumber == rhs._layerNumber)) ivarsEqual = false;
            if( ! (_layerSpecificInformaiton == rhs._layerSpecificInformaiton)) ivarsEqual = false;
            if( ! (_length == rhs._length)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _layerNumber.GetHashCode();
            result = GenerateHash(result) ^ _layerSpecificInformaiton.GetHashCode();
            result = GenerateHash(result) ^ _length.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
