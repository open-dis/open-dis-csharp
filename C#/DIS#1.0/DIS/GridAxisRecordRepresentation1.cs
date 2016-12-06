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
     * 5.2.44: Grid data record, representation 1
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
    [XmlInclude(typeof(TwoByteChunk))]
    public partial class GridAxisRecordRepresentation1 : GridAxisRecord
    {
        /** constant scale factor */
        protected float  _fieldScale;

        /** constant offset used to scale grid data */
        protected float  _fieldOffset;

        /** Number of data values */
        protected ushort  _numberOfValues;

        /** variable length list of data parameters ^^^this is wrong--need padding as well */
        protected List<TwoByteChunk> _dataValues = new List<TwoByteChunk>(); 

        /** Constructor */
        ///<summary>
        ///5.2.44: Grid data record, representation 1
        ///</summary>
        public GridAxisRecordRepresentation1()
        {
        }

        new public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.getMarshalledSize();
            marshalSize = marshalSize + 4;  // _fieldScale
            marshalSize = marshalSize + 4;  // _fieldOffset
            marshalSize = marshalSize + 2;  // _numberOfValues
            for(int idx=0; idx < _dataValues.Count; idx++)
            {
                TwoByteChunk listElement = (TwoByteChunk)_dataValues[idx];
                marshalSize = marshalSize + listElement.getMarshalledSize();
            }

            return marshalSize;
        }


        ///<summary>
        ///constant scale factor
        ///</summary>
        public void setFieldScale(float pFieldScale)
        { 
            _fieldScale = pFieldScale;
        }

        [XmlElement(Type= typeof(float), ElementName="fieldScale")]
        public float FieldScale
        {
            get
            {
                return _fieldScale;
            }
            set
            {
                _fieldScale = value;
            }
        }

        ///<summary>
        ///constant offset used to scale grid data
        ///</summary>
        public void setFieldOffset(float pFieldOffset)
        { 
            _fieldOffset = pFieldOffset;
        }

        [XmlElement(Type= typeof(float), ElementName="fieldOffset")]
        public float FieldOffset
        {
            get
            {
                return _fieldOffset;
            }
            set
            {
                _fieldOffset = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfValues method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        public void setNumberOfValues(ushort pNumberOfValues)
        {
            _numberOfValues = pNumberOfValues;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfValues method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type= typeof(ushort), ElementName="numberOfValues")]
        public ushort NumberOfValues
        {
            get
            {
                return _numberOfValues;
            }
            set
            {
                _numberOfValues = value;
            }
        }

        ///<summary>
        ///variable length list of data parameters ^^^this is wrong--need padding as well
        ///</summary>
        public void setDataValues(List<TwoByteChunk> pDataValues)
        {
            _dataValues = pDataValues;
        }

        ///<summary>
        ///variable length list of data parameters ^^^this is wrong--need padding as well
        ///</summary>
        public List<TwoByteChunk> getDataValues()
        {
            return _dataValues;
        }

        ///<summary>
        ///variable length list of data parameters ^^^this is wrong--need padding as well
        ///</summary>
        [XmlElement(ElementName = "dataValuesList",Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> DataValues
        {
            get
            {
                return _dataValues;
            }
            set
            {
                _dataValues = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        new public void marshal(DataOutputStream dos)
        {
            base.marshal(dos);
            try
            {
                dos.writeFloat((float)_fieldScale);
                dos.writeFloat((float)_fieldOffset);
                dos.writeUshort((ushort)_dataValues.Count);

                for(int idx = 0; idx < _dataValues.Count; idx++)
                {
                    TwoByteChunk aTwoByteChunk = (TwoByteChunk)_dataValues[idx];
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
                _fieldScale = dis.readFloat();
                _fieldOffset = dis.readFloat();
                _numberOfValues = dis.readUshort();
                for(int idx = 0; idx < _numberOfValues; idx++)
                {
                    TwoByteChunk anX = new TwoByteChunk();
                    anX.unmarshal(dis);
                    _dataValues.Add(anX);
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
            sb.Append("<GridAxisRecordRepresentation1>"  + System.Environment.NewLine);
            base.reflection(sb);
            try
            {
                sb.Append("<fieldScale type=\"float\">" + _fieldScale.ToString() + "</fieldScale> " + System.Environment.NewLine);
                sb.Append("<fieldOffset type=\"float\">" + _fieldOffset.ToString() + "</fieldOffset> " + System.Environment.NewLine);
                sb.Append("<dataValues type=\"ushort\">" + _dataValues.Count.ToString() + "</dataValues> " + System.Environment.NewLine);

            for(int idx = 0; idx < _dataValues.Count; idx++)
            {
                sb.Append("<dataValues"+ idx.ToString() + " type=\"TwoByteChunk\">" + System.Environment.NewLine);
                TwoByteChunk aTwoByteChunk = (TwoByteChunk)_dataValues[idx];
                aTwoByteChunk.reflection(sb);
                sb.Append("</dataValues"+ idx.ToString() + ">" + System.Environment.NewLine);
            } // end of list marshalling

                sb.Append("</GridAxisRecordRepresentation1>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(GridAxisRecordRepresentation1 a, GridAxisRecordRepresentation1 b)
        {
            return !(a == b);
        }

        public static bool operator ==(GridAxisRecordRepresentation1 a, GridAxisRecordRepresentation1 b)
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
            return this == obj as GridAxisRecordRepresentation1;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(GridAxisRecordRepresentation1 rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;

            ivarsEqual = base.Equals(rhs);

            if( ! (_fieldScale == rhs._fieldScale)) ivarsEqual = false;
            if( ! (_fieldOffset == rhs._fieldOffset)) ivarsEqual = false;
            if( ! (_numberOfValues == rhs._numberOfValues)) ivarsEqual = false;

            if( ! (_dataValues.Count == rhs._dataValues.Count)) ivarsEqual = false;
            if(ivarsEqual)
            {
                for(int idx = 0; idx < _dataValues.Count; idx++)
                {
                    if( ! ( _dataValues[idx].Equals(rhs._dataValues[idx]))) ivarsEqual = false;
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

            result = GenerateHash(result) ^ _fieldScale.GetHashCode();
            result = GenerateHash(result) ^ _fieldOffset.GetHashCode();
            result = GenerateHash(result) ^ _numberOfValues.GetHashCode();

            if(_dataValues.Count > 0)
            {
                for(int idx = 0; idx < _dataValues.Count; idx++)
                {
                    result = GenerateHash(result) ^ _dataValues[idx].GetHashCode();
                }
            }


            return result;
        }
    } // end of class
} // end of namespace
