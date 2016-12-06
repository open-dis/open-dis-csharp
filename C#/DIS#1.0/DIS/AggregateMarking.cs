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
     * Section 5.2.37. Specifies the character set used inthe first byte, followed by up to 31 characters of text data.
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
    public partial class AggregateMarking : Object
    {
        /** The character set */
        protected byte  _characterSet;

        /** The characters */
        protected byte[]  _characters = new byte[31]; 


        /** Constructor */
        ///<summary>
        ///Section 5.2.37. Specifies the character set used inthe first byte, followed by up to 31 characters of text data.
        ///</summary>
        public AggregateMarking()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 1;  // _characterSet
            marshalSize = marshalSize + 31 * 1;  // _characters

            return marshalSize;
        }


        ///<summary>
        ///The character set
        ///</summary>
        public void setCharacterSet(byte pCharacterSet)
        { 
            _characterSet = pCharacterSet;
        }

        [XmlElement(Type= typeof(byte), ElementName="characterSet")]
        public byte CharacterSet
        {
            get
            {
                return _characterSet;
            }
            set
            {
                _characterSet = value;
            }
        }

        ///<summary>
        ///The characters
        ///</summary>
        public void setCharacters(byte[] pCharacters)
        {
            _characters = pCharacters;
        }

        ///<summary>
        ///The characters
        ///</summary>
        public byte[] getCharacters()
        {
            return _characters;
        }

        ///<summary>
        ///The characters
        ///</summary>
        [XmlArray(ElementName="characters")]
        public byte[] Characters
        {
            get
            {
                return _characters;
            }
            set
            {
                _characters = value;
            }
}


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeByte((byte)_characterSet);

                for(int idx = 0; idx < _characters.Length; idx++)
                {
                    dos.writeByte(_characters[idx]);
                } // end of array marshaling

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
                _characterSet = dis.readByte();
                for(int idx = 0; idx < _characters.Length; idx++)
                {
                    _characters[idx] = dis.readByte();
                } // end of array unmarshaling
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
            sb.Append("<AggregateMarking>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<characterSet type=\"byte\">" + _characterSet.ToString() + "</characterSet> " + System.Environment.NewLine);

                for(int idx = 0; idx < _characters.Length; idx++)
                {
                sb.Append("<characters"+ idx.ToString() + " type=\"byte\">" + _characters[idx] + "</characters"+ idx.ToString() + "> " + System.Environment.NewLine);
            } // end of array reflection

                sb.Append("</AggregateMarking>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(AggregateMarking a, AggregateMarking b)
        {
            return !(a == b);
        }

        public static bool operator ==(AggregateMarking a, AggregateMarking b)
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
            return this == obj as AggregateMarking;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(AggregateMarking rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_characterSet == rhs._characterSet)) ivarsEqual = false;

            if( ! (rhs._characters.Length == 31)) ivarsEqual = false;
            if(ivarsEqual)
            {

                for(int idx = 0; idx < 31; idx++)
                {
                    if(!(_characters[idx] == rhs._characters[idx])) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _characterSet.GetHashCode();

            if(31 > 0)
            {

                for(int idx = 0; idx < 31; idx++)
                {
                    result = GenerateHash(result) ^ _characters[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
