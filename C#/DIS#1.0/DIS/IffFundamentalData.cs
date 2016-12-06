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
     * 5.2.42. Basic operational data ofr IFF ATC NAVAIDS
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
    public partial class IffFundamentalData : Object
    {
        /** system status */
        protected byte  _systemStatus;

        /** Alternate parameter 4 */
        protected byte  _alternateParameter4;

        /** eight boolean fields */
        protected byte  _informationLayers;

        /** enumeration */
        protected byte  _modifier;

        /** parameter, enumeration */
        protected ushort  _parameter1;

        /** parameter, enumeration */
        protected ushort  _parameter2;

        /** parameter, enumeration */
        protected ushort  _parameter3;

        /** parameter, enumeration */
        protected ushort  _parameter4;

        /** parameter, enumeration */
        protected ushort  _parameter5;

        /** parameter, enumeration */
        protected ushort  _parameter6;


        /** Constructor */
        ///<summary>
        ///5.2.42. Basic operational data ofr IFF ATC NAVAIDS
        ///</summary>
        public IffFundamentalData()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 1;  // _systemStatus
            marshalSize = marshalSize + 1;  // _alternateParameter4
            marshalSize = marshalSize + 1;  // _informationLayers
            marshalSize = marshalSize + 1;  // _modifier
            marshalSize = marshalSize + 2;  // _parameter1
            marshalSize = marshalSize + 2;  // _parameter2
            marshalSize = marshalSize + 2;  // _parameter3
            marshalSize = marshalSize + 2;  // _parameter4
            marshalSize = marshalSize + 2;  // _parameter5
            marshalSize = marshalSize + 2;  // _parameter6

            return marshalSize;
        }


        ///<summary>
        ///system status
        ///</summary>
        public void setSystemStatus(byte pSystemStatus)
        { 
            _systemStatus = pSystemStatus;
        }

        [XmlElement(Type= typeof(byte), ElementName="systemStatus")]
        public byte SystemStatus
        {
            get
            {
                return _systemStatus;
            }
            set
            {
                _systemStatus = value;
            }
        }

        ///<summary>
        ///Alternate parameter 4
        ///</summary>
        public void setAlternateParameter4(byte pAlternateParameter4)
        { 
            _alternateParameter4 = pAlternateParameter4;
        }

        [XmlElement(Type= typeof(byte), ElementName="alternateParameter4")]
        public byte AlternateParameter4
        {
            get
            {
                return _alternateParameter4;
            }
            set
            {
                _alternateParameter4 = value;
            }
        }

        ///<summary>
        ///eight boolean fields
        ///</summary>
        public void setInformationLayers(byte pInformationLayers)
        { 
            _informationLayers = pInformationLayers;
        }

        [XmlElement(Type= typeof(byte), ElementName="informationLayers")]
        public byte InformationLayers
        {
            get
            {
                return _informationLayers;
            }
            set
            {
                _informationLayers = value;
            }
        }

        ///<summary>
        ///enumeration
        ///</summary>
        public void setModifier(byte pModifier)
        { 
            _modifier = pModifier;
        }

        [XmlElement(Type= typeof(byte), ElementName="modifier")]
        public byte Modifier
        {
            get
            {
                return _modifier;
            }
            set
            {
                _modifier = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter1(ushort pParameter1)
        { 
            _parameter1 = pParameter1;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter1")]
        public ushort Parameter1
        {
            get
            {
                return _parameter1;
            }
            set
            {
                _parameter1 = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter2(ushort pParameter2)
        { 
            _parameter2 = pParameter2;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter2")]
        public ushort Parameter2
        {
            get
            {
                return _parameter2;
            }
            set
            {
                _parameter2 = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter3(ushort pParameter3)
        { 
            _parameter3 = pParameter3;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter3")]
        public ushort Parameter3
        {
            get
            {
                return _parameter3;
            }
            set
            {
                _parameter3 = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter4(ushort pParameter4)
        { 
            _parameter4 = pParameter4;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter4")]
        public ushort Parameter4
        {
            get
            {
                return _parameter4;
            }
            set
            {
                _parameter4 = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter5(ushort pParameter5)
        { 
            _parameter5 = pParameter5;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter5")]
        public ushort Parameter5
        {
            get
            {
                return _parameter5;
            }
            set
            {
                _parameter5 = value;
            }
        }

        ///<summary>
        ///parameter, enumeration
        ///</summary>
        public void setParameter6(ushort pParameter6)
        { 
            _parameter6 = pParameter6;
        }

        [XmlElement(Type= typeof(ushort), ElementName="parameter6")]
        public ushort Parameter6
        {
            get
            {
                return _parameter6;
            }
            set
            {
                _parameter6 = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeByte((byte)_systemStatus);
                dos.writeByte((byte)_alternateParameter4);
                dos.writeByte((byte)_informationLayers);
                dos.writeByte((byte)_modifier);
                dos.writeUshort((ushort)_parameter1);
                dos.writeUshort((ushort)_parameter2);
                dos.writeUshort((ushort)_parameter3);
                dos.writeUshort((ushort)_parameter4);
                dos.writeUshort((ushort)_parameter5);
                dos.writeUshort((ushort)_parameter6);
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
                _systemStatus = dis.readByte();
                _alternateParameter4 = dis.readByte();
                _informationLayers = dis.readByte();
                _modifier = dis.readByte();
                _parameter1 = dis.readUshort();
                _parameter2 = dis.readUshort();
                _parameter3 = dis.readUshort();
                _parameter4 = dis.readUshort();
                _parameter5 = dis.readUshort();
                _parameter6 = dis.readUshort();
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
            sb.Append("<IffFundamentalData>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<systemStatus type=\"byte\">" + _systemStatus.ToString() + "</systemStatus> " + System.Environment.NewLine);
                sb.Append("<alternateParameter4 type=\"byte\">" + _alternateParameter4.ToString() + "</alternateParameter4> " + System.Environment.NewLine);
                sb.Append("<informationLayers type=\"byte\">" + _informationLayers.ToString() + "</informationLayers> " + System.Environment.NewLine);
                sb.Append("<modifier type=\"byte\">" + _modifier.ToString() + "</modifier> " + System.Environment.NewLine);
                sb.Append("<parameter1 type=\"ushort\">" + _parameter1.ToString() + "</parameter1> " + System.Environment.NewLine);
                sb.Append("<parameter2 type=\"ushort\">" + _parameter2.ToString() + "</parameter2> " + System.Environment.NewLine);
                sb.Append("<parameter3 type=\"ushort\">" + _parameter3.ToString() + "</parameter3> " + System.Environment.NewLine);
                sb.Append("<parameter4 type=\"ushort\">" + _parameter4.ToString() + "</parameter4> " + System.Environment.NewLine);
                sb.Append("<parameter5 type=\"ushort\">" + _parameter5.ToString() + "</parameter5> " + System.Environment.NewLine);
                sb.Append("<parameter6 type=\"ushort\">" + _parameter6.ToString() + "</parameter6> " + System.Environment.NewLine);
                sb.Append("</IffFundamentalData>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(IffFundamentalData a, IffFundamentalData b)
        {
            return !(a == b);
        }

        public static bool operator ==(IffFundamentalData a, IffFundamentalData b)
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
            return this == obj as IffFundamentalData;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(IffFundamentalData rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_systemStatus == rhs._systemStatus)) ivarsEqual = false;
            if( ! (_alternateParameter4 == rhs._alternateParameter4)) ivarsEqual = false;
            if( ! (_informationLayers == rhs._informationLayers)) ivarsEqual = false;
            if( ! (_modifier == rhs._modifier)) ivarsEqual = false;
            if( ! (_parameter1 == rhs._parameter1)) ivarsEqual = false;
            if( ! (_parameter2 == rhs._parameter2)) ivarsEqual = false;
            if( ! (_parameter3 == rhs._parameter3)) ivarsEqual = false;
            if( ! (_parameter4 == rhs._parameter4)) ivarsEqual = false;
            if( ! (_parameter5 == rhs._parameter5)) ivarsEqual = false;
            if( ! (_parameter6 == rhs._parameter6)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _systemStatus.GetHashCode();
            result = GenerateHash(result) ^ _alternateParameter4.GetHashCode();
            result = GenerateHash(result) ^ _informationLayers.GetHashCode();
            result = GenerateHash(result) ^ _modifier.GetHashCode();
            result = GenerateHash(result) ^ _parameter1.GetHashCode();
            result = GenerateHash(result) ^ _parameter2.GetHashCode();
            result = GenerateHash(result) ^ _parameter3.GetHashCode();
            result = GenerateHash(result) ^ _parameter4.GetHashCode();
            result = GenerateHash(result) ^ _parameter5.GetHashCode();
            result = GenerateHash(result) ^ _parameter6.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
