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
     * Section 5.3.7.5. SEES PDU, supplemental emissions entity state information. COMPLETE
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
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(PropulsionSystemData))]
    [XmlInclude(typeof(VectoringNozzleSystemData))]
    public partial class SeesPdu : DistributedEmissionsFamilyPdu
    {
        /** Originating entity ID */
        protected EntityID  _orginatingEntityID = new EntityID(); 

        /** IR Signature representation index */
        protected ushort  _infraredSignatureRepresentationIndex;

        /** acoustic Signature representation index */
        protected ushort  _acousticSignatureRepresentationIndex;

        /** radar cross section representation index */
        protected ushort  _radarCrossSectionSignatureRepresentationIndex;

        /** how many propulsion systems */
        protected ushort  _numberOfPropulsionSystems;

        /** how many vectoring nozzle systems */
        protected ushort  _numberOfVectoringNozzleSystems;

        /** variable length list of propulsion system data */
        protected List<PropulsionSystemData> _propulsionSystemData = new List<PropulsionSystemData>(); 
        /** variable length list of vectoring system data */
        protected List<VectoringNozzleSystemData> _vectoringSystemData = new List<VectoringNozzleSystemData>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.7.5. SEES PDU, supplemental emissions entity state information. COMPLETE
        ///</summary>
        public SeesPdu()
        {
            PduType = (byte)30;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _orginatingEntityID.getMarshalledSize();  // _orginatingEntityID
            marshalSize = marshalSize + 2;  // _infraredSignatureRepresentationIndex
            marshalSize = marshalSize + 2;  // _acousticSignatureRepresentationIndex
            marshalSize = marshalSize + 2;  // _radarCrossSectionSignatureRepresentationIndex
            marshalSize = marshalSize + 2;  // _numberOfPropulsionSystems
            marshalSize = marshalSize + 2;  // _numberOfVectoringNozzleSystems
            for(int idx=0; idx < _propulsionSystemData.Count; idx++)
            {
                PropulsionSystemData listElement = (PropulsionSystemData)_propulsionSystemData[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _vectoringSystemData.Count; idx++)
            {
                VectoringNozzleSystemData listElement = (VectoringNozzleSystemData)_vectoringSystemData[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Originating entity ID
        ///</summary>
        public void setOrginatingEntityID(EntityID pOrginatingEntityID)
        { 
            _orginatingEntityID = pOrginatingEntityID;
        }

        ///<summary>
        ///Originating entity ID
        ///</summary>
        public EntityID getOrginatingEntityID()
        {
            return _orginatingEntityID;
        }

        ///<summary>
        ///Originating entity ID
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="orginatingEntityID")]
        public EntityID OrginatingEntityID
        {
            get
            {
                return _orginatingEntityID;
            }
            set
            {
                _orginatingEntityID = value;
            }
        }

        ///<summary>
        ///IR Signature representation index
        ///</summary>
        public void setInfraredSignatureRepresentationIndex(ushort pInfraredSignatureRepresentationIndex)
        { 
            _infraredSignatureRepresentationIndex = pInfraredSignatureRepresentationIndex;
        }

        [XmlElement(Type= typeof(ushort), ElementName="infraredSignatureRepresentationIndex")]
        public ushort InfraredSignatureRepresentationIndex
        {
            get
            {
                return _infraredSignatureRepresentationIndex;
            }
            set
            {
                _infraredSignatureRepresentationIndex = value;
            }
        }

        ///<summary>
        ///acoustic Signature representation index
        ///</summary>
        public void setAcousticSignatureRepresentationIndex(ushort pAcousticSignatureRepresentationIndex)
        { 
            _acousticSignatureRepresentationIndex = pAcousticSignatureRepresentationIndex;
        }

        [XmlElement(Type= typeof(ushort), ElementName="acousticSignatureRepresentationIndex")]
        public ushort AcousticSignatureRepresentationIndex
        {
            get
            {
                return _acousticSignatureRepresentationIndex;
            }
            set
            {
                _acousticSignatureRepresentationIndex = value;
            }
        }

        ///<summary>
        ///radar cross section representation index
        ///</summary>
        public void setRadarCrossSectionSignatureRepresentationIndex(ushort pRadarCrossSectionSignatureRepresentationIndex)
        { 
            _radarCrossSectionSignatureRepresentationIndex = pRadarCrossSectionSignatureRepresentationIndex;
        }

        [XmlElement(Type= typeof(ushort), ElementName="radarCrossSectionSignatureRepresentationIndex")]
        public ushort RadarCrossSectionSignatureRepresentationIndex
        {
            get
            {
                return _radarCrossSectionSignatureRepresentationIndex;
            }
            set
            {
                _radarCrossSectionSignatureRepresentationIndex = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPropulsionSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfPropulsionSystems(ushort pNumberOfPropulsionSystems)
        {
            _numberOfPropulsionSystems = pNumberOfPropulsionSystems;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPropulsionSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfPropulsionSystems")]
        public ushort NumberOfPropulsionSystems
        {
            get
            {
                return _numberOfPropulsionSystems;
            }
            set
            {
                _numberOfPropulsionSystems = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVectoringNozzleSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfVectoringNozzleSystems(ushort pNumberOfVectoringNozzleSystems)
        {
            _numberOfVectoringNozzleSystems = pNumberOfVectoringNozzleSystems;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVectoringNozzleSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfVectoringNozzleSystems")]
        public ushort NumberOfVectoringNozzleSystems
        {
            get
            {
                return _numberOfVectoringNozzleSystems;
            }
            set
            {
                _numberOfVectoringNozzleSystems = value;
            }
        }

        ///<summary>
        ///variable length list of propulsion system data
        ///</summary>
        public void setPropulsionSystemData(List<PropulsionSystemData> pPropulsionSystemData)
        {
            _propulsionSystemData = pPropulsionSystemData;
        }

        ///<summary>
        ///variable length list of propulsion system data
        ///</summary>
        public List<PropulsionSystemData> getPropulsionSystemData()
        {
            return _propulsionSystemData;
        }

        ///<summary>
        ///variable length list of propulsion system data
        ///</summary>
        [XmlElement(ElementName = "propulsionSystemDataList",Type = typeof(List<PropulsionSystemData>))]
        public List<PropulsionSystemData> PropulsionSystemData
        {
            get
            {
                return _propulsionSystemData;
            }
            set
            {
                _propulsionSystemData = value;
            }
        }

        ///<summary>
        ///variable length list of vectoring system data
        ///</summary>
        public void setVectoringSystemData(List<VectoringNozzleSystemData> pVectoringSystemData)
        {
            _vectoringSystemData = pVectoringSystemData;
        }

        ///<summary>
        ///variable length list of vectoring system data
        ///</summary>
        public List<VectoringNozzleSystemData> getVectoringSystemData()
        {
            return _vectoringSystemData;
        }

        ///<summary>
        ///variable length list of vectoring system data
        ///</summary>
        [XmlElement(ElementName = "vectoringSystemDataList",Type = typeof(List<VectoringNozzleSystemData>))]
        public List<VectoringNozzleSystemData> VectoringSystemData
        {
            get
            {
                return _vectoringSystemData;
            }
            set
            {
                _vectoringSystemData = value;
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
                _orginatingEntityID.marshal(dos);
                dos.writeUshort((ushort)_infraredSignatureRepresentationIndex);
                dos.writeUshort((ushort)_acousticSignatureRepresentationIndex);
                dos.writeUshort((ushort)_radarCrossSectionSignatureRepresentationIndex);
                dos.writeUshort((ushort)_propulsionSystemData.Count);
                dos.writeUshort((ushort)_vectoringSystemData.Count);

                for(int idx = 0; idx < _propulsionSystemData.Count; idx++)
                {
                    PropulsionSystemData aPropulsionSystemData = (PropulsionSystemData)_propulsionSystemData[idx];
                    aPropulsionSystemData.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _vectoringSystemData.Count; idx++)
                {
                    VectoringNozzleSystemData aVectoringNozzleSystemData = (VectoringNozzleSystemData)_vectoringSystemData[idx];
                    aVectoringNozzleSystemData.marshal(dos);
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
                _orginatingEntityID.unmarshal(dis);
                _infraredSignatureRepresentationIndex = dis.readUshort();
                _acousticSignatureRepresentationIndex = dis.readUshort();
                _radarCrossSectionSignatureRepresentationIndex = dis.readUshort();
                _numberOfPropulsionSystems = dis.readUshort();
                _numberOfVectoringNozzleSystems = dis.readUshort();
                for(int idx = 0; idx < _numberOfPropulsionSystems; idx++)
                {
                    PropulsionSystemData anX = new PropulsionSystemData();
                    anX.unmarshal(dis);
                    _propulsionSystemData.Add(anX);
                };

                for(int idx = 0; idx < _numberOfVectoringNozzleSystems; idx++)
                {
                    VectoringNozzleSystemData anX = new VectoringNozzleSystemData();
                    anX.unmarshal(dis);
                    _vectoringSystemData.Add(anX);
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
            sb.Append("<SeesPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<orginatingEntityID>"  + System.Environment.NewLine);
                _orginatingEntityID.reflection(sb);
                sb.Append("</orginatingEntityID>"  + System.Environment.NewLine);
                sb.Append("<infraredSignatureRepresentationIndex type=\"ushort\">" + _infraredSignatureRepresentationIndex.ToString() + "</infraredSignatureRepresentationIndex> " + System.Environment.NewLine);
                sb.Append("<acousticSignatureRepresentationIndex type=\"ushort\">" + _acousticSignatureRepresentationIndex.ToString() + "</acousticSignatureRepresentationIndex> " + System.Environment.NewLine);
                sb.Append("<radarCrossSectionSignatureRepresentationIndex type=\"ushort\">" + _radarCrossSectionSignatureRepresentationIndex.ToString() + "</radarCrossSectionSignatureRepresentationIndex> " + System.Environment.NewLine);
                sb.Append("<propulsionSystemData type=\"ushort\">" + _propulsionSystemData.Count.ToString() + "</propulsionSystemData> " + System.Environment.NewLine);
                sb.Append("<vectoringSystemData type=\"ushort\">" + _vectoringSystemData.Count.ToString() + "</vectoringSystemData> " + System.Environment.NewLine);

            for(int idx = 0; idx < _propulsionSystemData.Count; idx++)
            {
                sb.Append("<propulsionSystemData"+ idx.ToString() + " type=\"PropulsionSystemData\">" + System.Environment.NewLine);
                PropulsionSystemData aPropulsionSystemData = (PropulsionSystemData)_propulsionSystemData[idx];
                aPropulsionSystemData.reflection(sb);
                sb.Append("</propulsionSystemData"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _vectoringSystemData.Count; idx++)
            {
                sb.Append("<vectoringSystemData"+ idx.ToString() + " type=\"VectoringNozzleSystemData\">" + System.Environment.NewLine);
                VectoringNozzleSystemData aVectoringNozzleSystemData = (VectoringNozzleSystemData)_vectoringSystemData[idx];
                aVectoringNozzleSystemData.reflection(sb);
                sb.Append("</vectoringSystemData"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</SeesPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(SeesPdu a, SeesPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(SeesPdu a, SeesPdu b)
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
            return this == obj as SeesPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(SeesPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_orginatingEntityID.Equals( rhs._orginatingEntityID) )) ivarsEqual = false;
            if( ! (_infraredSignatureRepresentationIndex == rhs._infraredSignatureRepresentationIndex)) ivarsEqual = false;
            if( ! (_acousticSignatureRepresentationIndex == rhs._acousticSignatureRepresentationIndex)) ivarsEqual = false;
            if( ! (_radarCrossSectionSignatureRepresentationIndex == rhs._radarCrossSectionSignatureRepresentationIndex)) ivarsEqual = false;
            if( ! (_numberOfPropulsionSystems == rhs._numberOfPropulsionSystems)) ivarsEqual = false;
            if( ! (_numberOfVectoringNozzleSystems == rhs._numberOfVectoringNozzleSystems)) ivarsEqual = false;

            if( ! (_propulsionSystemData.Count == rhs._propulsionSystemData.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _propulsionSystemData.Count; idx++)
                {
                    if( ! ( _propulsionSystemData[idx].Equals(rhs._propulsionSystemData[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_vectoringSystemData.Count == rhs._vectoringSystemData.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _vectoringSystemData.Count; idx++)
                {
                    if( ! ( _vectoringSystemData[idx].Equals(rhs._vectoringSystemData[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _orginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _infraredSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ _acousticSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ _radarCrossSectionSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ _numberOfPropulsionSystems.GetHashCode();
            result = GenerateHash(result) ^ _numberOfVectoringNozzleSystems.GetHashCode();

            if(_propulsionSystemData.Count > 0)
            {
                for(int idx = 0; idx < _propulsionSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ _propulsionSystemData[idx].GetHashCode();
                }
            }


            if(_vectoringSystemData.Count > 0)
            {
                for(int idx = 0; idx < _vectoringSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ _vectoringSystemData[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
