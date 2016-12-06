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
     * Section 5.3.10.1 Abstract superclass for PDUs relating to minefields. COMPLETE
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
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(EntityType))]
    public partial class MinefieldStatePdu : MinefieldFamilyPdu
    {
        /** Minefield ID */
        protected EntityID  _minefieldID = new EntityID(); 

        /** Minefield sequence */
        protected ushort  _minefieldSequence;

        /** force ID */
        protected byte  _forceID;

        /** Number of permieter points */
        protected byte  _numberOfPerimeterPoints;

        /** type of minefield */
        protected EntityType  _minefieldType = new EntityType(); 

        /** how many mine types */
        protected ushort  _numberOfMineTypes;

        /** location of minefield in world coords */
        protected Vector3Double  _minefieldLocation = new Vector3Double(); 

        /** orientation of minefield */
        protected Orientation  _minefieldOrientation = new Orientation(); 

        /** appearance bitflags */
        protected ushort  _appearance;

        /** protocolMode */
        protected ushort  _protocolMode;

        /** perimeter points for the minefield */
        protected List<Point> _perimeterPoints = new List<Point>(); 
        /** Type of mines */
        protected List<EntityType> _mineType = new List<EntityType>(); 

        /** Constructor */
        ///<summary>
        ///Section 5.3.10.1 Abstract superclass for PDUs relating to minefields. COMPLETE
        ///</summary>
        public MinefieldStatePdu()
        {
            PduType = (byte)37;
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + _minefieldID.getMarshalledSize();  // _minefieldID
            marshalSize = marshalSize + 2;  // _minefieldSequence
            marshalSize = marshalSize + 1;  // _forceID
            marshalSize = marshalSize + 1;  // _numberOfPerimeterPoints
            marshalSize = marshalSize + _minefieldType.getMarshalledSize();  // _minefieldType
            marshalSize = marshalSize + 2;  // _numberOfMineTypes
            marshalSize = marshalSize + _minefieldLocation.getMarshalledSize();  // _minefieldLocation
            marshalSize = marshalSize + _minefieldOrientation.getMarshalledSize();  // _minefieldOrientation
            marshalSize = marshalSize + 2;  // _appearance
            marshalSize = marshalSize + 2;  // _protocolMode
            for(int idx=0; idx < _perimeterPoints.Count; idx++)
            {
                Point listElement = (Point)_perimeterPoints[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }
            for(int idx=0; idx < _mineType.Count; idx++)
            {
                EntityType listElement = (EntityType)_mineType[idx];
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
        ///Minefield sequence
        ///</summary>
        public void setMinefieldSequence(ushort pMinefieldSequence)
        { 
            _minefieldSequence = pMinefieldSequence;
        }

        [XmlElement(Type= typeof(ushort), ElementName="minefieldSequence")]
        public ushort MinefieldSequence
        {
            get
            {
                return _minefieldSequence;
            }
            set
            {
                _minefieldSequence = value;
            }
        }

        ///<summary>
        ///force ID
        ///</summary>
        public void setForceID(byte pForceID)
        { 
            _forceID = pForceID;
        }

        [XmlElement(Type= typeof(byte), ElementName="forceID")]
        public byte ForceID
        {
            get
            {
                return _forceID;
            }
            set
            {
                _forceID = value;
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
        ///type of minefield
        ///</summary>
        public void setMinefieldType(EntityType pMinefieldType)
        { 
            _minefieldType = pMinefieldType;
        }

        ///<summary>
        ///type of minefield
        ///</summary>
        public EntityType getMinefieldType()
        {
            return _minefieldType;
        }

        ///<summary>
        ///type of minefield
        ///</summary>
        [XmlElement(Type= typeof(EntityType), ElementName="minefieldType")]
        public EntityType MinefieldType
        {
            get
            {
                return _minefieldType;
            }
            set
            {
                _minefieldType = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMineTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfMineTypes(ushort pNumberOfMineTypes)
        {
            _numberOfMineTypes = pNumberOfMineTypes;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfMineTypes method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfMineTypes")]
        public ushort NumberOfMineTypes
        {
            get
            {
                return _numberOfMineTypes;
            }
            set
            {
                _numberOfMineTypes = value;
            }
        }

        ///<summary>
        ///location of minefield in world coords
        ///</summary>
        public void setMinefieldLocation(Vector3Double pMinefieldLocation)
        { 
            _minefieldLocation = pMinefieldLocation;
        }

        ///<summary>
        ///location of minefield in world coords
        ///</summary>
        public Vector3Double getMinefieldLocation()
        {
            return _minefieldLocation;
        }

        ///<summary>
        ///location of minefield in world coords
        ///</summary>
        [XmlElement(Type= typeof(Vector3Double), ElementName="minefieldLocation")]
        public Vector3Double MinefieldLocation
        {
            get
            {
                return _minefieldLocation;
            }
            set
            {
                _minefieldLocation = value;
            }
        }

        ///<summary>
        ///orientation of minefield
        ///</summary>
        public void setMinefieldOrientation(Orientation pMinefieldOrientation)
        { 
            _minefieldOrientation = pMinefieldOrientation;
        }

        ///<summary>
        ///orientation of minefield
        ///</summary>
        public Orientation getMinefieldOrientation()
        {
            return _minefieldOrientation;
        }

        ///<summary>
        ///orientation of minefield
        ///</summary>
        [XmlElement(Type= typeof(Orientation), ElementName="minefieldOrientation")]
        public Orientation MinefieldOrientation
        {
            get
            {
                return _minefieldOrientation;
            }
            set
            {
                _minefieldOrientation = value;
            }
        }

        ///<summary>
        ///appearance bitflags
        ///</summary>
        public void setAppearance(ushort pAppearance)
        { 
            _appearance = pAppearance;
        }

        [XmlElement(Type= typeof(ushort), ElementName="appearance")]
        public ushort Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
            }
        }

        ///<summary>
        ///protocolMode
        ///</summary>
        public void setProtocolMode(ushort pProtocolMode)
        { 
            _protocolMode = pProtocolMode;
        }

        [XmlElement(Type= typeof(ushort), ElementName="protocolMode")]
        public ushort ProtocolMode
        {
            get
            {
                return _protocolMode;
            }
            set
            {
                _protocolMode = value;
            }
        }

        ///<summary>
        ///perimeter points for the minefield
        ///</summary>
        public void setPerimeterPoints(List<Point> pPerimeterPoints)
        {
            _perimeterPoints = pPerimeterPoints;
        }

        ///<summary>
        ///perimeter points for the minefield
        ///</summary>
        public List<Point> getPerimeterPoints()
        {
            return _perimeterPoints;
        }

        ///<summary>
        ///perimeter points for the minefield
        ///</summary>
        [XmlElement(ElementName = "perimeterPointsList",Type = typeof(List<Point>))]
        public List<Point> PerimeterPoints
        {
            get
            {
                return _perimeterPoints;
            }
            set
            {
                _perimeterPoints = value;
            }
        }

        ///<summary>
        ///Type of mines
        ///</summary>
        public void setMineType(List<EntityType> pMineType)
        {
            _mineType = pMineType;
        }

        ///<summary>
        ///Type of mines
        ///</summary>
        public List<EntityType> getMineType()
        {
            return _mineType;
        }

        ///<summary>
        ///Type of mines
        ///</summary>
        [XmlElement(ElementName = "mineTypeList",Type = typeof(List<EntityType>))]
        public List<EntityType> MineType
        {
            get
            {
                return _mineType;
            }
            set
            {
                _mineType = value;
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
                dos.writeUshort((ushort)_minefieldSequence);
                dos.writeByte((byte)_forceID);
                dos.writeByte((byte)_perimeterPoints.Count);
                _minefieldType.marshal(dos);
                dos.writeUshort((ushort)_mineType.Count);
                _minefieldLocation.marshal(dos);
                _minefieldOrientation.marshal(dos);
                dos.writeUshort((ushort)_appearance);
                dos.writeUshort((ushort)_protocolMode);

                for(int idx = 0; idx < _perimeterPoints.Count; idx++)
                {
                    Point aPoint = (Point)_perimeterPoints[idx];
                    aPoint.marshal(dos);
                } // end of list marshalling


                for(int idx = 0; idx < _mineType.Count; idx++)
                {
                    EntityType aEntityType = (EntityType)_mineType[idx];
                    aEntityType.marshal(dos);
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
                _minefieldSequence = dis.readUshort();
                _forceID = dis.readByte();
                _numberOfPerimeterPoints = dis.readByte();
                _minefieldType.unmarshal(dis);
                _numberOfMineTypes = dis.readUshort();
                _minefieldLocation.unmarshal(dis);
                _minefieldOrientation.unmarshal(dis);
                _appearance = dis.readUshort();
                _protocolMode = dis.readUshort();
                for(int idx = 0; idx < _numberOfPerimeterPoints; idx++)
                {
                    Point anX = new Point();
                    anX.unmarshal(dis);
                    _perimeterPoints.Add(anX);
                };

                for(int idx = 0; idx < _numberOfMineTypes; idx++)
                {
                    EntityType anX = new EntityType();
                    anX.unmarshal(dis);
                    _mineType.Add(anX);
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
            sb.Append("<MinefieldStatePdu>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<minefieldID>"  + System.Environment.NewLine);
                _minefieldID.reflection(sb);
                sb.Append("</minefieldID>"  + System.Environment.NewLine);
                sb.Append("<minefieldSequence type=\"ushort\">" + _minefieldSequence.ToString() + "</minefieldSequence> " + System.Environment.NewLine);
                sb.Append("<forceID type=\"byte\">" + _forceID.ToString() + "</forceID> " + System.Environment.NewLine);
                sb.Append("<perimeterPoints type=\"byte\">" + _perimeterPoints.Count.ToString() + "</perimeterPoints> " + System.Environment.NewLine);
                sb.Append("<minefieldType>"  + System.Environment.NewLine);
                _minefieldType.reflection(sb);
                sb.Append("</minefieldType>"  + System.Environment.NewLine);
                sb.Append("<mineType type=\"ushort\">" + _mineType.Count.ToString() + "</mineType> " + System.Environment.NewLine);
                sb.Append("<minefieldLocation>"  + System.Environment.NewLine);
                _minefieldLocation.reflection(sb);
                sb.Append("</minefieldLocation>"  + System.Environment.NewLine);
                sb.Append("<minefieldOrientation>"  + System.Environment.NewLine);
                _minefieldOrientation.reflection(sb);
                sb.Append("</minefieldOrientation>"  + System.Environment.NewLine);
                sb.Append("<appearance type=\"ushort\">" + _appearance.ToString() + "</appearance> " + System.Environment.NewLine);
                sb.Append("<protocolMode type=\"ushort\">" + _protocolMode.ToString() + "</protocolMode> " + System.Environment.NewLine);

            for(int idx = 0; idx < _perimeterPoints.Count; idx++)
            {
                sb.Append("<perimeterPoints"+ idx.ToString() + " type=\"Point\">" + System.Environment.NewLine);
                Point aPoint = (Point)_perimeterPoints[idx];
                aPoint.reflection(sb);
                sb.Append("</perimeterPoints"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling


            for(int idx = 0; idx < _mineType.Count; idx++)
            {
                sb.Append("<mineType"+ idx.ToString() + " type=\"EntityType\">" + System.Environment.NewLine);
                EntityType aEntityType = (EntityType)_mineType[idx];
                aEntityType.reflection(sb);
                sb.Append("</mineType"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</MinefieldStatePdu>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(MinefieldStatePdu a, MinefieldStatePdu b)
        {
            return !(a == b);
        }

        public static bool operator ==(MinefieldStatePdu a, MinefieldStatePdu b)
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
            return this == obj as MinefieldStatePdu;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(MinefieldStatePdu rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_minefieldID.Equals( rhs._minefieldID) )) ivarsEqual = false;
            if( ! (_minefieldSequence == rhs._minefieldSequence)) ivarsEqual = false;
            if( ! (_forceID == rhs._forceID)) ivarsEqual = false;
            if( ! (_numberOfPerimeterPoints == rhs._numberOfPerimeterPoints)) ivarsEqual = false;
            if( ! (_minefieldType.Equals( rhs._minefieldType) )) ivarsEqual = false;
            if( ! (_numberOfMineTypes == rhs._numberOfMineTypes)) ivarsEqual = false;
            if( ! (_minefieldLocation.Equals( rhs._minefieldLocation) )) ivarsEqual = false;
            if( ! (_minefieldOrientation.Equals( rhs._minefieldOrientation) )) ivarsEqual = false;
            if( ! (_appearance == rhs._appearance)) ivarsEqual = false;
            if( ! (_protocolMode == rhs._protocolMode)) ivarsEqual = false;

            if( ! (_perimeterPoints.Count == rhs._perimeterPoints.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _perimeterPoints.Count; idx++)
                {
                    if( ! ( _perimeterPoints[idx].Equals(rhs._perimeterPoints[idx]))) ivarsEqual = false;
                }
            }


            if( ! (_mineType.Count == rhs._mineType.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _mineType.Count; idx++)
                {
                    if( ! ( _mineType[idx].Equals(rhs._mineType[idx]))) ivarsEqual = false;
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
            result = GenerateHash(result) ^ _minefieldSequence.GetHashCode();
            result = GenerateHash(result) ^ _forceID.GetHashCode();
            result = GenerateHash(result) ^ _numberOfPerimeterPoints.GetHashCode();
            result = GenerateHash(result) ^ _minefieldType.GetHashCode();
            result = GenerateHash(result) ^ _numberOfMineTypes.GetHashCode();
            result = GenerateHash(result) ^ _minefieldLocation.GetHashCode();
            result = GenerateHash(result) ^ _minefieldOrientation.GetHashCode();
            result = GenerateHash(result) ^ _appearance.GetHashCode();
            result = GenerateHash(result) ^ _protocolMode.GetHashCode();

            if(_perimeterPoints.Count > 0)
            {
                for(int idx = 0; idx < _perimeterPoints.Count; idx++)
                {
                    result = GenerateHash(result) ^ _perimeterPoints[idx].GetHashCode();
                }
            }


            if(_mineType.Count > 0)
            {
                for(int idx = 0; idx < _mineType.Count; idx++)
                {
                    result = GenerateHash(result) ^ _mineType[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
