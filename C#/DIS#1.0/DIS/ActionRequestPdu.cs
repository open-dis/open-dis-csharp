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
     * Section 5.3.6.6. Request from simulation manager to an entity. COMPLETE
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
    [XmlInclude(typeof(FixedDatum))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class ActionRequestPdu : SimulationManagementFamilyPdu
    {
        /** Request ID that is unique */
        protected uint  _requestID;

        /** identifies the action being requested */
        protected uint  _actionID;

        /** Number of fixed datum records */
        protected uint  _numberOfFixedDatumRecords;

        /** Number of variable datum records */
        protected uint  _numberOfVariableDatumRecords;

        /** variable length list of fixed datums */
        protected List<FixedDatum> _fixedDatums = new List<FixedDatum>(); 
        /** variable length list of variable length datums */
        protected List<VariableDatum> _variableDatums = new List<VariableDatum>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.6.6. Request from simulation manager to an entity. COMPLETE
        ///</summary>
        public ActionRequestPdu()
        {
            PduType = (byte)16;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + 4;  // _requestID
            marshalSize = marshalSize + 4;  // _actionID
            marshalSize = marshalSize + 4;  // _numberOfFixedDatumRecords
            marshalSize = marshalSize + 4;  // _numberOfVariableDatumRecords
            for(int idx=0; idx < _fixedDatums.Count; idx++)
            {
                FixedDatum listElement = (FixedDatum)_fixedDatums[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _variableDatums.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)_variableDatums[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Request ID that is unique
        ///</summary>
        public void setRequestID(uint pRequestID)
        { 
            _requestID = pRequestID;
        }

        [XmlElement(Type= typeof(uint), ElementName="requestID")]
        public uint RequestID
        {
            get
            {
                return _requestID;
            }
            set
            {
                _requestID = value;
            }
        }

        ///<summary>
        ///identifies the action being requested
        ///</summary>
        public void setActionID(uint pActionID)
        { 
            _actionID = pActionID;
        }

        [XmlElement(Type= typeof(uint), ElementName="actionID")]
        public uint ActionID
        {
            get
            {
                return _actionID;
            }
            set
            {
                _actionID = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfFixedDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfFixedDatumRecords(uint pNumberOfFixedDatumRecords)
        {
            _numberOfFixedDatumRecords = pNumberOfFixedDatumRecords;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfFixedDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(uint), ElementName="numberOfFixedDatumRecords")]
        public uint NumberOfFixedDatumRecords
        {
            get
            {
                return _numberOfFixedDatumRecords;
            }
            set
            {
                _numberOfFixedDatumRecords = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfVariableDatumRecords(uint pNumberOfVariableDatumRecords)
        {
            _numberOfVariableDatumRecords = pNumberOfVariableDatumRecords;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(uint), ElementName="numberOfVariableDatumRecords")]
        public uint NumberOfVariableDatumRecords
        {
            get
            {
                return _numberOfVariableDatumRecords;
            }
            set
            {
                _numberOfVariableDatumRecords = value;
            }
        }

        ///<summary>
        ///variable length list of fixed datums
        ///</summary>
        public void setFixedDatums(List<FixedDatum> pFixedDatums)
        {
            _fixedDatums = pFixedDatums;
        }

        ///<summary>
        ///variable length list of fixed datums
        ///</summary>
        public List<FixedDatum> getFixedDatums()
        {
            return _fixedDatums;
        }

        ///<summary>
        ///variable length list of fixed datums
        ///</summary>
        [XmlElement(ElementName = "fixedDatumsList",Type = typeof(List<FixedDatum>))]
        public List<FixedDatum> FixedDatums
        {
            get
            {
                return _fixedDatums;
            }
            set
            {
                _fixedDatums = value;
            }
        }

        ///<summary>
        ///variable length list of variable length datums
        ///</summary>
        public void setVariableDatums(List<VariableDatum> pVariableDatums)
        {
            _variableDatums = pVariableDatums;
        }

        ///<summary>
        ///variable length list of variable length datums
        ///</summary>
        public List<VariableDatum> getVariableDatums()
        {
            return _variableDatums;
        }

        ///<summary>
        ///variable length list of variable length datums
        ///</summary>
        [XmlElement(ElementName = "variableDatumsList",Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatums
        {
            get
            {
                return _variableDatums;
            }
            set
            {
                _variableDatums = value;
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
                dos.writeUint((uint)_requestID);
                dos.writeUint((uint)_actionID);
                dos.writeUint((uint)_fixedDatums.Count);
                dos.writeUint((uint)_variableDatums.Count);

                for(int idx = 0; idx < _fixedDatums.Count; idx++)
                {
                    FixedDatum aFixedDatum = (FixedDatum)_fixedDatums[idx];
                    aFixedDatum.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _variableDatums.Count; idx++)
                {
                    VariableDatum aVariableDatum = (VariableDatum)_variableDatums[idx];
                    aVariableDatum.marshal(dos);
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
                _requestID = dis.readUint();
                _actionID = dis.readUint();
                _numberOfFixedDatumRecords = dis.readUint();
                _numberOfVariableDatumRecords = dis.readUint();
                for(int idx = 0; idx < _numberOfFixedDatumRecords; idx++)
                {
                    FixedDatum anX = new FixedDatum();
                    anX.unmarshal(dis);
                    _fixedDatums.Add(anX);
                };

                for(int idx = 0; idx < _numberOfVariableDatumRecords; idx++)
                {
                    VariableDatum anX = new VariableDatum();
                    anX.unmarshal(dis);
                    _variableDatums.Add(anX);
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
            sb.Append("<ActionRequestPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<requestID type=\"uint\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
                sb.Append("<actionID type=\"uint\">" + _actionID.ToString() + "</actionID> " + System.Environment.NewLine);
                sb.Append("<fixedDatums type=\"uint\">" + _fixedDatums.Count.ToString() + "</fixedDatums> " + System.Environment.NewLine);
                sb.Append("<variableDatums type=\"uint\">" + _variableDatums.Count.ToString() + "</variableDatums> " + System.Environment.NewLine);

            for(int idx = 0; idx < _fixedDatums.Count; idx++)
            {
                sb.Append("<fixedDatums"+ idx.ToString() + " type=\"FixedDatum\">" + System.Environment.NewLine);
                FixedDatum aFixedDatum = (FixedDatum)_fixedDatums[idx];
                aFixedDatum.reflection(sb);
                sb.Append("</fixedDatums"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _variableDatums.Count; idx++)
            {
                sb.Append("<variableDatums"+ idx.ToString() + " type=\"VariableDatum\">" + System.Environment.NewLine);
                VariableDatum aVariableDatum = (VariableDatum)_variableDatums[idx];
                aVariableDatum.reflection(sb);
                sb.Append("</variableDatums"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</ActionRequestPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(ActionRequestPdu a, ActionRequestPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(ActionRequestPdu a, ActionRequestPdu b)
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
            return this == obj as ActionRequestPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(ActionRequestPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
            if( ! (_actionID == rhs._actionID)) ivarsEqual = false;
            if( ! (_numberOfFixedDatumRecords == rhs._numberOfFixedDatumRecords)) ivarsEqual = false;
            if( ! (_numberOfVariableDatumRecords == rhs._numberOfVariableDatumRecords)) ivarsEqual = false;

            if( ! (_fixedDatums.Count == rhs._fixedDatums.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _fixedDatums.Count; idx++)
                {
                    if( ! ( _fixedDatums[idx].Equals(rhs._fixedDatums[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_variableDatums.Count == rhs._variableDatums.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _variableDatums.Count; idx++)
                {
                    if( ! ( _variableDatums[idx].Equals(rhs._variableDatums[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _requestID.GetHashCode();
            result = GenerateHash(result) ^ _actionID.GetHashCode();
            result = GenerateHash(result) ^ _numberOfFixedDatumRecords.GetHashCode();
            result = GenerateHash(result) ^ _numberOfVariableDatumRecords.GetHashCode();

            if(_fixedDatums.Count > 0)
            {
                for(int idx = 0; idx < _fixedDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ _fixedDatums[idx].GetHashCode();
                }
            }


            if(_variableDatums.Count > 0)
            {
                for(int idx = 0; idx < _variableDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ _variableDatums[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
