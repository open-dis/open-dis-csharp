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
     * Used in the UA pdu; ties together an emmitter and a location. This requires manual cleanup; the beam data should not be attached to each emitter system.
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
    [XmlInclude(typeof(AcousticEmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(AcousticBeamData))]
    public partial class AcousticEmitterSystemData : Object
    {
        /** Length of emitter system data */
        protected byte  _emitterSystemDataLength;

        /** Number of beams */
        protected byte  _numberOfBeams;

        /** padding */
        protected ushort  _pad2;

        /** This field shall specify the system for a particular UA emitter. */
        protected AcousticEmitterSystem  _acousticEmitterSystem = new AcousticEmitterSystem(); 

        /** Represents the location wrt the entity */
        protected Vector3Float  _emitterLocation = new Vector3Float(); 

        /** For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system. */
        protected List<AcousticBeamData> _beamRecords = new List<AcousticBeamData>(); 

        /** Constructor */
        ///<summary>
        ///Used in the UA pdu; ties together an emmitter and a location. This requires manual cleanup; the beam data should not be attached to each emitter system.
        ///</summary>
        public AcousticEmitterSystemData()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 1;  // _emitterSystemDataLength
            marshalSize = marshalSize + 1;  // _numberOfBeams
            marshalSize = marshalSize + 2;  // _pad2
            marshalSize = marshalSize + _acousticEmitterSystem.getMarshalledSize();  // _acousticEmitterSystem
            marshalSize = marshalSize + _emitterLocation.getMarshalledSize();  // _emitterLocation
            for(int idx=0; idx < _beamRecords.Count; idx++)
            {
                AcousticBeamData listElement = (AcousticBeamData)_beamRecords[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Length of emitter system data
        ///</summary>
        public void setEmitterSystemDataLength(byte pEmitterSystemDataLength)
        { 
            _emitterSystemDataLength = pEmitterSystemDataLength;
        }

        [XmlElement(Type= typeof(byte), ElementName="emitterSystemDataLength")]
        public byte EmitterSystemDataLength
        {
            get
            {
                return _emitterSystemDataLength;
            }
            set
            {
                _emitterSystemDataLength = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfBeams method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfBeams(byte pNumberOfBeams)
        {
            _numberOfBeams = pNumberOfBeams;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfBeams method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfBeams")]
        public byte NumberOfBeams
        {
            get
            {
                return _numberOfBeams;
            }
            set
            {
                _numberOfBeams = value;
            }
        }

        ///<summary>
        ///padding
        ///</summary>
        public void setPad2(ushort pPad2)
        { 
            _pad2 = pPad2;
        }

        [XmlElement(Type= typeof(ushort), ElementName="pad2")]
        public ushort Pad2
        {
            get
            {
                return _pad2;
            }
            set
            {
                _pad2 = value;
            }
        }

        ///<summary>
        ///This field shall specify the system for a particular UA emitter.
        ///</summary>
        public void setAcousticEmitterSystem(AcousticEmitterSystem pAcousticEmitterSystem)
        { 
            _acousticEmitterSystem = pAcousticEmitterSystem;
        }

        ///<summary>
        ///This field shall specify the system for a particular UA emitter.
        ///</summary>
        public AcousticEmitterSystem getAcousticEmitterSystem()
        {
            return _acousticEmitterSystem;
        }

        ///<summary>
        ///This field shall specify the system for a particular UA emitter.
        ///</summary>
        [XmlElement(Type= typeof(AcousticEmitterSystem), ElementName="acousticEmitterSystem")]
        public AcousticEmitterSystem AcousticEmitterSystem
        {
            get
            {
                return _acousticEmitterSystem;
            }
            set
            {
                _acousticEmitterSystem = value;
            }
        }

        ///<summary>
        ///Represents the location wrt the entity
        ///</summary>
        public void setEmitterLocation(Vector3Float pEmitterLocation)
        { 
            _emitterLocation = pEmitterLocation;
        }

        ///<summary>
        ///Represents the location wrt the entity
        ///</summary>
        public Vector3Float getEmitterLocation()
        {
            return _emitterLocation;
        }

        ///<summary>
        ///Represents the location wrt the entity
        ///</summary>
        [XmlElement(Type= typeof(Vector3Float), ElementName="emitterLocation")]
        public Vector3Float EmitterLocation
        {
            get
            {
                return _emitterLocation;
            }
            set
            {
                _emitterLocation = value;
            }
        }

        ///<summary>
        ///For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system.
        ///</summary>
        public void setBeamRecords(List<AcousticBeamData> pBeamRecords)
        {
            _beamRecords = pBeamRecords;
        }

        ///<summary>
        ///For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system.
        ///</summary>
        public List<AcousticBeamData> getBeamRecords()
        {
            return _beamRecords;
        }

        ///<summary>
        ///For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system.
        ///</summary>
        [XmlElement(ElementName = "beamRecordsList",Type = typeof(List<AcousticBeamData>))]
        public List<AcousticBeamData> BeamRecords
        {
            get
            {
                return _beamRecords;
            }
            set
            {
                _beamRecords = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeByte((byte)_emitterSystemDataLength);
                dos.writeByte((byte)_beamRecords.Count);
                dos.writeUshort((ushort)_pad2);
                _acousticEmitterSystem.marshal(dos);
                _emitterLocation.marshal(dos);

                for(int idx = 0; idx < _beamRecords.Count; idx++)
                {
                    AcousticBeamData aAcousticBeamData = (AcousticBeamData)_beamRecords[idx];
                    aAcousticBeamData.marshal(dos);
                } // end of list marshalling

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
                _emitterSystemDataLength = dis.readByte();
                _numberOfBeams = dis.readByte();
                _pad2 = dis.readUshort();
                _acousticEmitterSystem.unmarshal(dis);
                _emitterLocation.unmarshal(dis);
                for(int idx = 0; idx < _numberOfBeams; idx++)
                {
                    AcousticBeamData anX = new AcousticBeamData();
                    anX.unmarshal(dis);
                    _beamRecords.Add(anX);
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
        public void reflection(StringBuilder sb)
        {
            sb.Append("<AcousticEmitterSystemData>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<emitterSystemDataLength type=\"byte\">" + _emitterSystemDataLength.ToString() + "</emitterSystemDataLength> " + System.Environment.NewLine);
                sb.Append("<beamRecords type=\"byte\">" + _beamRecords.Count.ToString() + "</beamRecords> " + System.Environment.NewLine);
                sb.Append("<pad2 type=\"ushort\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
                sb.Append("<acousticEmitterSystem>"  + System.Environment.NewLine);
                _acousticEmitterSystem.reflection(sb);
                sb.Append("</acousticEmitterSystem>"  + System.Environment.NewLine);
                sb.Append("<emitterLocation>"  + System.Environment.NewLine);
                _emitterLocation.reflection(sb);
                sb.Append("</emitterLocation>"  + System.Environment.NewLine);

            for(int idx = 0; idx < _beamRecords.Count; idx++)
            {
                sb.Append("<beamRecords"+ idx.ToString() + " type=\"AcousticBeamData\">" + System.Environment.NewLine);
                AcousticBeamData aAcousticBeamData = (AcousticBeamData)_beamRecords[idx];
                aAcousticBeamData.reflection(sb);
                sb.Append("</beamRecords"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</AcousticEmitterSystemData>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(AcousticEmitterSystemData a, AcousticEmitterSystemData b)
        {
            return !(a == b);
        }

        public static bool operator ==(AcousticEmitterSystemData a, AcousticEmitterSystemData b)
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
            return this == obj as AcousticEmitterSystemData;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(AcousticEmitterSystemData rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_emitterSystemDataLength == rhs._emitterSystemDataLength)) ivarsEqual = false;
            if( ! (_numberOfBeams == rhs._numberOfBeams)) ivarsEqual = false;
            if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
            if( ! (_acousticEmitterSystem.Equals( rhs._acousticEmitterSystem) )) ivarsEqual = false;
            if( ! (_emitterLocation.Equals( rhs._emitterLocation) )) ivarsEqual = false;

            if( ! (_beamRecords.Count == rhs._beamRecords.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _beamRecords.Count; idx++)
                {
                    if( ! ( _beamRecords[idx].Equals(rhs._beamRecords[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _emitterSystemDataLength.GetHashCode();
            result = GenerateHash(result) ^ _numberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ _pad2.GetHashCode();
            result = GenerateHash(result) ^ _acousticEmitterSystem.GetHashCode();
            result = GenerateHash(result) ^ _emitterLocation.GetHashCode();

            if(_beamRecords.Count > 0)
            {
                for(int idx = 0; idx < _beamRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ _beamRecords[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
