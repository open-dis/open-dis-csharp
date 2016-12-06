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
     * Section 5.3.10.2 Query a minefield for information about individual mines. Requires manual clean up to get the padding right. UNFINISHED
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
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(TwoByteChunk))]
    public partial class MinefieldQueryPdu : MinefieldFamilyPdu
    {
        /** Minefield ID */
        protected EntityID  _minefieldID = new EntityID(); 

        /** EID of entity making the request */
        protected EntityID  _requestingEntityID = new EntityID(); 

        /** request ID */
        protected byte  _requestID;

        /** Number of perimeter points for the minefield */
        protected byte  _numberOfPerimeterPoints;

        /** Padding */
        protected byte  _pad2;

        /** Number of sensor types */
        protected byte  _numberOfSensorTypes;

        /** data filter, 32 boolean fields */
        protected uint  _dataFilter;

        /** Entity type of mine being requested */
        protected EntityType  _requestedMineType = new EntityType(); 

        /** perimeter points of request */
        protected List<Point> _requestedPerimeterPoints = new List<Point>(); 
        /** Sensor types, each 16 bits long */
        protected List<TwoByteChunk> _sensorTypes = new List<TwoByteChunk>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.10.2 Query a minefield for information about individual mines. Requires manual clean up to get the padding right. UNFINISHED
        ///</summary>
        public MinefieldQueryPdu()
        {
            PduType = (byte)38;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _minefieldID.getMarshalledSize();  // _minefieldID
            marshalSize = marshalSize + _requestingEntityID.getMarshalledSize();  // _requestingEntityID
            marshalSize = marshalSize + 1;  // _requestID
            marshalSize = marshalSize + 1;  // _numberOfPerimeterPoints
            marshalSize = marshalSize + 1;  // _pad2
            marshalSize = marshalSize + 1;  // _numberOfSensorTypes
            marshalSize = marshalSize + 4;  // _dataFilter
            marshalSize = marshalSize + _requestedMineType.getMarshalledSize();  // _requestedMineType
            for(int idx=0; idx < _requestedPerimeterPoints.Count; idx++)
            {
                Point listElement = (Point)_requestedPerimeterPoints[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _sensorTypes.Count; idx++)
            {
                TwoByteChunk listElement = (TwoByteChunk)_sensorTypes[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///Minefield ID
        ///</summary>
        public void setMinefieldID(EntityID pMinefieldID)
        { 
            _minefieldID = pMinefieldID;
        }

        ///<summary>
        ///Minefield ID
        ///</summary>
        public EntityID getMinefieldID()
        {
            return _minefieldID;
        }

        ///<summary>
        ///Minefield ID
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="minefieldID")]
        public EntityID MinefieldID
        {
            get
            {
                return _minefieldID;
            }
            set
            {
                _minefieldID = value;
            }
        }

        ///<summary>
        ///EID of entity making the request
        ///</summary>
        public void setRequestingEntityID(EntityID pRequestingEntityID)
        { 
            _requestingEntityID = pRequestingEntityID;
        }

        ///<summary>
        ///EID of entity making the request
        ///</summary>
        public EntityID getRequestingEntityID()
        {
            return _requestingEntityID;
        }

        ///<summary>
        ///EID of entity making the request
        ///</summary>
        [XmlElement(Type= typeof(EntityID), ElementName="requestingEntityID")]
        public EntityID RequestingEntityID
        {
            get
            {
                return _requestingEntityID;
            }
            set
            {
                _requestingEntityID = value;
            }
        }

        ///<summary>
        ///request ID
        ///</summary>
        public void setRequestID(byte pRequestID)
        { 
            _requestID = pRequestID;
        }

        [XmlElement(Type= typeof(byte), ElementName="requestID")]
        public byte RequestID
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

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPerimeterPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfPerimeterPoints(byte pNumberOfPerimeterPoints)
        {
            _numberOfPerimeterPoints = pNumberOfPerimeterPoints;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPerimeterPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfPerimeterPoints")]
        public byte NumberOfPerimeterPoints
        {
            get
            {
                return _numberOfPerimeterPoints;
            }
            set
            {
                _numberOfPerimeterPoints = value;
            }
        }

        ///<summary>
        ///Padding
        ///</summary>
        public void setPad2(byte pPad2)
        { 
            _pad2 = pPad2;
        }

        [XmlElement(Type= typeof(byte), ElementName="pad2")]
        public byte Pad2
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

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfSensorTypes(byte pNumberOfSensorTypes)
        {
            _numberOfSensorTypes = pNumberOfSensorTypes;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(byte), ElementName="numberOfSensorTypes")]
        public byte NumberOfSensorTypes
        {
            get
            {
                return _numberOfSensorTypes;
            }
            set
            {
                _numberOfSensorTypes = value;
            }
        }

        ///<summary>
        ///data filter, 32 boolean fields
        ///</summary>
        public void setDataFilter(uint pDataFilter)
        { 
            _dataFilter = pDataFilter;
        }

        [XmlElement(Type= typeof(uint), ElementName="dataFilter")]
        public uint DataFilter
        {
            get
            {
                return _dataFilter;
            }
            set
            {
                _dataFilter = value;
            }
        }

        ///<summary>
        ///Entity type of mine being requested
        ///</summary>
        public void setRequestedMineType(EntityType pRequestedMineType)
        { 
            _requestedMineType = pRequestedMineType;
        }

        ///<summary>
        ///Entity type of mine being requested
        ///</summary>
        public EntityType getRequestedMineType()
        {
            return _requestedMineType;
        }

        ///<summary>
        ///Entity type of mine being requested
        ///</summary>
        [XmlElement(Type= typeof(EntityType), ElementName="requestedMineType")]
        public EntityType RequestedMineType
        {
            get
            {
                return _requestedMineType;
            }
            set
            {
                _requestedMineType = value;
            }
        }

        ///<summary>
        ///perimeter points of request
        ///</summary>
        public void setRequestedPerimeterPoints(List<Point> pRequestedPerimeterPoints)
        {
            _requestedPerimeterPoints = pRequestedPerimeterPoints;
        }

        ///<summary>
        ///perimeter points of request
        ///</summary>
        public List<Point> getRequestedPerimeterPoints()
        {
            return _requestedPerimeterPoints;
        }

        ///<summary>
        ///perimeter points of request
        ///</summary>
        [XmlElement(ElementName = "requestedPerimeterPointsList",Type = typeof(List<Point>))]
        public List<Point> RequestedPerimeterPoints
        {
            get
            {
                return _requestedPerimeterPoints;
            }
            set
            {
                _requestedPerimeterPoints = value;
            }
        }

        ///<summary>
        ///Sensor types, each 16 bits long
        ///</summary>
        public void setSensorTypes(List<TwoByteChunk> pSensorTypes)
        {
            _sensorTypes = pSensorTypes;
        }

        ///<summary>
        ///Sensor types, each 16 bits long
        ///</summary>
        public List<TwoByteChunk> getSensorTypes()
        {
            return _sensorTypes;
        }

        ///<summary>
        ///Sensor types, each 16 bits long
        ///</summary>
        [XmlElement(ElementName = "sensorTypesList",Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> SensorTypes
        {
            get
            {
                return _sensorTypes;
            }
            set
            {
                _sensorTypes = value;
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
                _minefieldID.marshal(dos);
                _requestingEntityID.marshal(dos);
                dos.writeByte((byte)_requestID);
                dos.writeByte((byte)_requestedPerimeterPoints.Count);
                dos.writeByte((byte)_pad2);
                dos.writeByte((byte)_sensorTypes.Count);
                dos.writeUint((uint)_dataFilter);
                _requestedMineType.marshal(dos);

                for(int idx = 0; idx < _requestedPerimeterPoints.Count; idx++)
                {
                    Point aPoint = (Point)_requestedPerimeterPoints[idx];
                    aPoint.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _sensorTypes.Count; idx++)
                {
                    TwoByteChunk aTwoByteChunk = (TwoByteChunk)_sensorTypes[idx];
                    aTwoByteChunk.marshal(dos);
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
                _minefieldID.unmarshal(dis);
                _requestingEntityID.unmarshal(dis);
                _requestID = dis.readByte();
                _numberOfPerimeterPoints = dis.readByte();
                _pad2 = dis.readByte();
                _numberOfSensorTypes = dis.readByte();
                _dataFilter = dis.readUint();
                _requestedMineType.unmarshal(dis);
                for(int idx = 0; idx < _numberOfPerimeterPoints; idx++)
                {
                    Point anX = new Point();
                    anX.unmarshal(dis);
                    _requestedPerimeterPoints.Add(anX);
                };

                for(int idx = 0; idx < _numberOfSensorTypes; idx++)
                {
                    TwoByteChunk anX = new TwoByteChunk();
                    anX.unmarshal(dis);
                    _sensorTypes.Add(anX);
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
            sb.Append("<MinefieldQueryPdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<minefieldID>"  + System.Environment.NewLine);
                _minefieldID.reflection(sb);
                sb.Append("</minefieldID>"  + System.Environment.NewLine);
                sb.Append("<requestingEntityID>"  + System.Environment.NewLine);
                _requestingEntityID.reflection(sb);
                sb.Append("</requestingEntityID>"  + System.Environment.NewLine);
                sb.Append("<requestID type=\"byte\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
                sb.Append("<requestedPerimeterPoints type=\"byte\">" + _requestedPerimeterPoints.Count.ToString() + "</requestedPerimeterPoints> " + System.Environment.NewLine);
                sb.Append("<pad2 type=\"byte\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
                sb.Append("<sensorTypes type=\"byte\">" + _sensorTypes.Count.ToString() + "</sensorTypes> " + System.Environment.NewLine);
                sb.Append("<dataFilter type=\"uint\">" + _dataFilter.ToString() + "</dataFilter> " + System.Environment.NewLine);
                sb.Append("<requestedMineType>"  + System.Environment.NewLine);
                _requestedMineType.reflection(sb);
                sb.Append("</requestedMineType>"  + System.Environment.NewLine);

            for(int idx = 0; idx < _requestedPerimeterPoints.Count; idx++)
            {
                sb.Append("<requestedPerimeterPoints"+ idx.ToString() + " type=\"Point\">" + System.Environment.NewLine);
                Point aPoint = (Point)_requestedPerimeterPoints[idx];
                aPoint.reflection(sb);
                sb.Append("</requestedPerimeterPoints"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _sensorTypes.Count; idx++)
            {
                sb.Append("<sensorTypes"+ idx.ToString() + " type=\"TwoByteChunk\">" + System.Environment.NewLine);
                TwoByteChunk aTwoByteChunk = (TwoByteChunk)_sensorTypes[idx];
                aTwoByteChunk.reflection(sb);
                sb.Append("</sensorTypes"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</MinefieldQueryPdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(MinefieldQueryPdu a, MinefieldQueryPdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(MinefieldQueryPdu a, MinefieldQueryPdu b)
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
            return this == obj as MinefieldQueryPdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(MinefieldQueryPdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_minefieldID.Equals( rhs._minefieldID) )) ivarsEqual = false;
            if( ! (_requestingEntityID.Equals( rhs._requestingEntityID) )) ivarsEqual = false;
            if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
            if( ! (_numberOfPerimeterPoints == rhs._numberOfPerimeterPoints)) ivarsEqual = false;
            if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
            if( ! (_numberOfSensorTypes == rhs._numberOfSensorTypes)) ivarsEqual = false;
            if( ! (_dataFilter == rhs._dataFilter)) ivarsEqual = false;
            if( ! (_requestedMineType.Equals( rhs._requestedMineType) )) ivarsEqual = false;

            if( ! (_requestedPerimeterPoints.Count == rhs._requestedPerimeterPoints.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _requestedPerimeterPoints.Count; idx++)
                {
                    if( ! ( _requestedPerimeterPoints[idx].Equals(rhs._requestedPerimeterPoints[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_sensorTypes.Count == rhs._sensorTypes.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _sensorTypes.Count; idx++)
                {
                    if( ! ( _sensorTypes[idx].Equals(rhs._sensorTypes[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _minefieldID.GetHashCode();
            result = GenerateHash(result) ^ _requestingEntityID.GetHashCode();
            result = GenerateHash(result) ^ _requestID.GetHashCode();
            result = GenerateHash(result) ^ _numberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ _pad2.GetHashCode();
            result = GenerateHash(result) ^ _numberOfSensorTypes.GetHashCode();
            result = GenerateHash(result) ^ _dataFilter.GetHashCode();
            result = GenerateHash(result) ^ _requestedMineType.GetHashCode();

            if(_requestedPerimeterPoints.Count > 0)
            {
                for(int idx = 0; idx < _requestedPerimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ _requestedPerimeterPoints[idx].GetHashCode();
                }
            }


            if(_sensorTypes.Count > 0)
            {
                for(int idx = 0; idx < _sensorTypes.Count; idx++)
                {
                    result = GenerateHash(result) ^ _sensorTypes[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
