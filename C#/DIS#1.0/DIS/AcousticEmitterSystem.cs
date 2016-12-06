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
     * 5.3.35: Information about a particular UA emitter shall be represented using an Acoustic Emitter System record. This record shall consist of three fields: Acoustic Name, Function, and Acoustic ID Number
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
    public partial class AcousticEmitterSystem : Object
    {
        /** This field shall specify the system for a particular UA emitter. */
        protected ushort  _acousticName;

        /** This field shall describe the function of the acoustic system.  */
        protected byte  _acousticFunction;

        /** This field shall specify the UA emitter identification number relative to a specific system. This field shall be represented by an 8-bit unsigned integer. This field allows the differentiation of multiple systems on an entity, even if in some instances two or more of the systems may be identical UA emitter types. Numbering of systems shall begin with the value 1.  */
        protected byte  _acousticID;


        /** Constructor */
        ///<summary>
        ///5.3.35: Information about a particular UA emitter shall be represented using an Acoustic Emitter System record. This record shall consist of three fields: Acoustic Name, Function, and Acoustic ID Number
        ///</summary>
        public AcousticEmitterSystem()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 2;  // _acousticName
            marshalSize = marshalSize + 1;  // _acousticFunction
            marshalSize = marshalSize + 1;  // _acousticID

            return marshalSize;
        }


        ///<summary>
        ///This field shall specify the system for a particular UA emitter.
        ///</summary>
        public void setAcousticName(ushort pAcousticName)
        { 
            _acousticName = pAcousticName;
        }

        [XmlElement(Type= typeof(ushort), ElementName="acousticName")]
        public ushort AcousticName
        {
            get
            {
                return _acousticName;
            }
            set
            {
                _acousticName = value;
            }
        }

        ///<summary>
        ///This field shall describe the function of the acoustic system. 
        ///</summary>
        public void setAcousticFunction(byte pAcousticFunction)
        { 
            _acousticFunction = pAcousticFunction;
        }

        [XmlElement(Type= typeof(byte), ElementName="acousticFunction")]
        public byte AcousticFunction
        {
            get
            {
                return _acousticFunction;
            }
            set
            {
                _acousticFunction = value;
            }
        }

        ///<summary>
        ///This field shall specify the UA emitter identification number relative to a specific system. This field shall be represented by an 8-bit unsigned integer. This field allows the differentiation of multiple systems on an entity, even if in some instances two or more of the systems may be identical UA emitter types. Numbering of systems shall begin with the value 1. 
        ///</summary>
        public void setAcousticID(byte pAcousticID)
        { 
            _acousticID = pAcousticID;
        }

        [XmlElement(Type= typeof(byte), ElementName="acousticID")]
        public byte AcousticID
        {
            get
            {
                return _acousticID;
            }
            set
            {
                _acousticID = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeUshort((ushort)_acousticName);
                dos.writeByte((byte)_acousticFunction);
                dos.writeByte((byte)_acousticID);
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
                _acousticName = dis.readUshort();
                _acousticFunction = dis.readByte();
                _acousticID = dis.readByte();
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
            sb.Append("<AcousticEmitterSystem>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<acousticName type=\"ushort\">" + _acousticName.ToString() + "</acousticName> " + System.Environment.NewLine);
                sb.Append("<acousticFunction type=\"byte\">" + _acousticFunction.ToString() + "</acousticFunction> " + System.Environment.NewLine);
                sb.Append("<acousticID type=\"byte\">" + _acousticID.ToString() + "</acousticID> " + System.Environment.NewLine);
                sb.Append("</AcousticEmitterSystem>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(AcousticEmitterSystem a, AcousticEmitterSystem b)
        {
            return !(a == b);
        }

        public static bool operator ==(AcousticEmitterSystem a, AcousticEmitterSystem b)
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
            return this == obj as AcousticEmitterSystem;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(AcousticEmitterSystem rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_acousticName == rhs._acousticName)) ivarsEqual = false;
            if( ! (_acousticFunction == rhs._acousticFunction)) ivarsEqual = false;
            if( ! (_acousticID == rhs._acousticID)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _acousticName.GetHashCode();
            result = GenerateHash(result) ^ _acousticFunction.GetHashCode();
            result = GenerateHash(result) ^ _acousticID.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
