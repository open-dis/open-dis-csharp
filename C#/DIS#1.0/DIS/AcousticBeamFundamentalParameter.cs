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
     * Used in UaPdu
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
    public partial class AcousticBeamFundamentalParameter : Object
    {
        /** parameter index */
        protected ushort  _activeEmissionParameterIndex;

        /** scan pattern */
        protected ushort  _scanPattern;

        /** beam center azimuth */
        protected float  _beamCenterAzimuth;

        /** azimuthal beamwidth */
        protected float  _azimuthalBeamwidth;

        /** beam center */
        protected float  _beamCenterDE;

        /** DE beamwidth (vertical beamwidth) */
        protected float  _deBeamwidth;


        /** Constructor */
        ///<summary>
        ///Used in UaPdu
        ///</summary>
        public AcousticBeamFundamentalParameter()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 2;  // _activeEmissionParameterIndex
            marshalSize = marshalSize + 2;  // _scanPattern
            marshalSize = marshalSize + 4;  // _beamCenterAzimuth
            marshalSize = marshalSize + 4;  // _azimuthalBeamwidth
            marshalSize = marshalSize + 4;  // _beamCenterDE
            marshalSize = marshalSize + 4;  // _deBeamwidth

            return marshalSize;
        }


        ///<summary>
        ///parameter index
        ///</summary>
        public void setActiveEmissionParameterIndex(ushort pActiveEmissionParameterIndex)
        { 
            _activeEmissionParameterIndex = pActiveEmissionParameterIndex;
        }

        [XmlElement(Type= typeof(ushort), ElementName="activeEmissionParameterIndex")]
        public ushort ActiveEmissionParameterIndex
        {
            get
            {
                return _activeEmissionParameterIndex;
            }
            set
            {
                _activeEmissionParameterIndex = value;
            }
        }

        ///<summary>
        ///scan pattern
        ///</summary>
        public void setScanPattern(ushort pScanPattern)
        { 
            _scanPattern = pScanPattern;
        }

        [XmlElement(Type= typeof(ushort), ElementName="scanPattern")]
        public ushort ScanPattern
        {
            get
            {
                return _scanPattern;
            }
            set
            {
                _scanPattern = value;
            }
        }

        ///<summary>
        ///beam center azimuth
        ///</summary>
        public void setBeamCenterAzimuth(float pBeamCenterAzimuth)
        { 
            _beamCenterAzimuth = pBeamCenterAzimuth;
        }

        [XmlElement(Type= typeof(float), ElementName="beamCenterAzimuth")]
        public float BeamCenterAzimuth
        {
            get
            {
                return _beamCenterAzimuth;
            }
            set
            {
                _beamCenterAzimuth = value;
            }
        }

        ///<summary>
        ///azimuthal beamwidth
        ///</summary>
        public void setAzimuthalBeamwidth(float pAzimuthalBeamwidth)
        { 
            _azimuthalBeamwidth = pAzimuthalBeamwidth;
        }

        [XmlElement(Type= typeof(float), ElementName="azimuthalBeamwidth")]
        public float AzimuthalBeamwidth
        {
            get
            {
                return _azimuthalBeamwidth;
            }
            set
            {
                _azimuthalBeamwidth = value;
            }
        }

        ///<summary>
        ///beam center
        ///</summary>
        public void setBeamCenterDE(float pBeamCenterDE)
        { 
            _beamCenterDE = pBeamCenterDE;
        }

        [XmlElement(Type= typeof(float), ElementName="beamCenterDE")]
        public float BeamCenterDE
        {
            get
            {
                return _beamCenterDE;
            }
            set
            {
                _beamCenterDE = value;
            }
        }

        ///<summary>
        ///DE beamwidth (vertical beamwidth)
        ///</summary>
        public void setDeBeamwidth(float pDeBeamwidth)
        { 
            _deBeamwidth = pDeBeamwidth;
        }

        [XmlElement(Type= typeof(float), ElementName="deBeamwidth")]
        public float DeBeamwidth
        {
            get
            {
                return _deBeamwidth;
            }
            set
            {
                _deBeamwidth = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeUshort((ushort)_activeEmissionParameterIndex);
                dos.writeUshort((ushort)_scanPattern);
                dos.writeFloat((float)_beamCenterAzimuth);
                dos.writeFloat((float)_azimuthalBeamwidth);
                dos.writeFloat((float)_beamCenterDE);
                dos.writeFloat((float)_deBeamwidth);
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
                _activeEmissionParameterIndex = dis.readUshort();
                _scanPattern = dis.readUshort();
                _beamCenterAzimuth = dis.readFloat();
                _azimuthalBeamwidth = dis.readFloat();
                _beamCenterDE = dis.readFloat();
                _deBeamwidth = dis.readFloat();
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
            sb.Append("<AcousticBeamFundamentalParameter>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<activeEmissionParameterIndex type=\"ushort\">" + _activeEmissionParameterIndex.ToString() + "</activeEmissionParameterIndex> " + System.Environment.NewLine);
                sb.Append("<scanPattern type=\"ushort\">" + _scanPattern.ToString() + "</scanPattern> " + System.Environment.NewLine);
                sb.Append("<beamCenterAzimuth type=\"float\">" + _beamCenterAzimuth.ToString() + "</beamCenterAzimuth> " + System.Environment.NewLine);
                sb.Append("<azimuthalBeamwidth type=\"float\">" + _azimuthalBeamwidth.ToString() + "</azimuthalBeamwidth> " + System.Environment.NewLine);
                sb.Append("<beamCenterDE type=\"float\">" + _beamCenterDE.ToString() + "</beamCenterDE> " + System.Environment.NewLine);
                sb.Append("<deBeamwidth type=\"float\">" + _deBeamwidth.ToString() + "</deBeamwidth> " + System.Environment.NewLine);
                sb.Append("</AcousticBeamFundamentalParameter>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(AcousticBeamFundamentalParameter a, AcousticBeamFundamentalParameter b)
        {
            return !(a == b);
        }

        public static bool operator ==(AcousticBeamFundamentalParameter a, AcousticBeamFundamentalParameter b)
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
            return this == obj as AcousticBeamFundamentalParameter;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(AcousticBeamFundamentalParameter rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_activeEmissionParameterIndex == rhs._activeEmissionParameterIndex)) ivarsEqual = false;
            if( ! (_scanPattern == rhs._scanPattern)) ivarsEqual = false;
            if( ! (_beamCenterAzimuth == rhs._beamCenterAzimuth)) ivarsEqual = false;
            if( ! (_azimuthalBeamwidth == rhs._azimuthalBeamwidth)) ivarsEqual = false;
            if( ! (_beamCenterDE == rhs._beamCenterDE)) ivarsEqual = false;
            if( ! (_deBeamwidth == rhs._deBeamwidth)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _activeEmissionParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ _scanPattern.GetHashCode();
            result = GenerateHash(result) ^ _beamCenterAzimuth.GetHashCode();
            result = GenerateHash(result) ^ _azimuthalBeamwidth.GetHashCode();
            result = GenerateHash(result) ^ _beamCenterDE.GetHashCode();
            result = GenerateHash(result) ^ _deBeamwidth.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
