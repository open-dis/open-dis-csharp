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
     * Radio modulation
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
    public partial class ModulationType : Object
    {
        /** spread spectrum, 16 bit boolean array */
        protected ushort  _spreadSpectrum;

        /** major */
        protected ushort  _major;

        /** detail */
        protected ushort  _detail;

        /** system */
        protected ushort  _system;


        /** Constructor */
        ///<summary>
        ///Radio modulation
        ///</summary>
        public ModulationType()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 2;  // _spreadSpectrum
            marshalSize = marshalSize + 2;  // _major
            marshalSize = marshalSize + 2;  // _detail
            marshalSize = marshalSize + 2;  // _system

            return marshalSize;
        }


        ///<summary>
        ///spread spectrum, 16 bit boolean array
        ///</summary>
        public void setSpreadSpectrum(ushort pSpreadSpectrum)
        { 
            _spreadSpectrum = pSpreadSpectrum;
        }

        [XmlElement(Type= typeof(ushort), ElementName="spreadSpectrum")]
        public ushort SpreadSpectrum
        {
            get
            {
                return _spreadSpectrum;
            }
            set
            {
                _spreadSpectrum = value;
            }
        }

        ///<summary>
        ///major
        ///</summary>
        public void setMajor(ushort pMajor)
        { 
            _major = pMajor;
        }

        [XmlElement(Type= typeof(ushort), ElementName="major")]
        public ushort Major
        {
            get
            {
                return _major;
            }
            set
            {
                _major = value;
            }
        }

        ///<summary>
        ///detail
        ///</summary>
        public void setDetail(ushort pDetail)
        { 
            _detail = pDetail;
        }

        [XmlElement(Type= typeof(ushort), ElementName="detail")]
        public ushort Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }

        ///<summary>
        ///system
        ///</summary>
        public void setSystem(ushort pSystem)
        { 
            _system = pSystem;
        }

        [XmlElement(Type= typeof(ushort), ElementName="system")]
        public ushort System_
        {
            get
            {
                return _system;
            }
            set
            {
                _system = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeUshort((ushort)_spreadSpectrum);
                dos.writeUshort((ushort)_major);
                dos.writeUshort((ushort)_detail);
                dos.writeUshort((ushort)_system);
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
                _spreadSpectrum = dis.readUshort();
                _major = dis.readUshort();
                _detail = dis.readUshort();
                _system = dis.readUshort();
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
            sb.Append("<ModulationType>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<spreadSpectrum type=\"ushort\">" + _spreadSpectrum.ToString() + "</spreadSpectrum> " + System.Environment.NewLine);
                sb.Append("<major type=\"ushort\">" + _major.ToString() + "</major> " + System.Environment.NewLine);
                sb.Append("<detail type=\"ushort\">" + _detail.ToString() + "</detail> " + System.Environment.NewLine);
                sb.Append("<system type=\"ushort\">" + _system.ToString() + "</system> " + System.Environment.NewLine);
                sb.Append("</ModulationType>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(ModulationType a, ModulationType b)
        {
            return !(a == b);
        }

        public static bool operator ==(ModulationType a, ModulationType b)
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
            return this == obj as ModulationType;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(ModulationType rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_spreadSpectrum == rhs._spreadSpectrum)) ivarsEqual = false;
            if( ! (_major == rhs._major)) ivarsEqual = false;
            if( ! (_detail == rhs._detail)) ivarsEqual = false;
            if( ! (_system == rhs._system)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _spreadSpectrum.GetHashCode();
            result = GenerateHash(result) ^ _major.GetHashCode();
            result = GenerateHash(result) ^ _detail.GetHashCode();
            result = GenerateHash(result) ^ _system.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
