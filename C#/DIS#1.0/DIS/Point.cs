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
     * x,y point
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
    public partial class Point : Object
    {
        /** x */
        protected float  _x;

        /** y */
        protected float  _y;


        /** Constructor */
        ///<summary>
        ///x,y point
        ///</summary>
        public Point()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 4;  // _x
            marshalSize = marshalSize + 4;  // _y

            return marshalSize;
        }


        ///<summary>
        ///x
        ///</summary>
        public void setX(float pX)
        { 
            _x = pX;
        }

        [XmlElement(Type= typeof(float), ElementName="x")]
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        ///<summary>
        ///y
        ///</summary>
        public void setY(float pY)
        { 
            _y = pY;
        }

        [XmlElement(Type= typeof(float), ElementName="y")]
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeFloat((float)_x);
                dos.writeFloat((float)_y);
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
                _x = dis.readFloat();
                _y = dis.readFloat();
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
            sb.Append("<Point>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<x type=\"float\">" + _x.ToString() + "</x> " + System.Environment.NewLine);
                sb.Append("<y type=\"float\">" + _y.ToString() + "</y> " + System.Environment.NewLine);
                sb.Append("</Point>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public static bool operator ==(Point a, Point b)
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
            return this == obj as Point;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(Point rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_x == rhs._x)) ivarsEqual = false;
            if( ! (_y == rhs._y)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _x.GetHashCode();
            result = GenerateHash(result) ^ _y.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
