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
     * Each entity in a given DIS simulation application shall be given an entity identifier number unique to all  other entities in that application. This identifier number is valid for the duration of the exercise; however,  entity identifier numbers may be reused when all possible numbers have been exhausted. No entity shall  have an entity identifier number of NO_ENTITY, ALL_ENTITIES, or RQST_ASSIGN_ID. The entity iden-  tifier number need not be registered or retained for future exercises. The entity identifier number shall be  specified by a 16-bit unsigned integer.  An entity identifier number equal to zero with valid site and application identification shall address a  simulation application. An entity identifier number equal to ALL_ENTITIES shall mean all entities within  the specified site and application. An entity identifier number equal to RQST_ASSIGN_ID allows the  receiver of the create entity to define the entity identifier number of the new entity.
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
    public partial class EntityID : Object
    {
        /** The site ID */
        protected ushort  _site;

        /** The application ID */
        protected ushort  _application;

        /** the entity ID */
        protected ushort  _entity;


        /** Constructor */
        ///<summary>
        ///Each entity in a given DIS simulation application shall be given an entity identifier number unique to all  other entities in that application. This identifier number is valid for the duration of the exercise; however,  entity identifier numbers may be reused when all possible numbers have been exhausted. No entity shall  have an entity identifier number of NO_ENTITY, ALL_ENTITIES, or RQST_ASSIGN_ID. The entity iden-  tifier number need not be registered or retained for future exercises. The entity identifier number shall be  specified by a 16-bit unsigned integer.  An entity identifier number equal to zero with valid site and application identification shall address a  simulation application. An entity identifier number equal to ALL_ENTITIES shall mean all entities within  the specified site and application. An entity identifier number equal to RQST_ASSIGN_ID allows the  receiver of the create entity to define the entity identifier number of the new entity.
        ///</summary>
        public EntityID()
        {
        }

        public int getMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = marshalSize + 2;  // _site
            marshalSize = marshalSize + 2;  // _application
            marshalSize = marshalSize + 2;  // _entity

            return marshalSize;
        }


        ///<summary>
        ///The site ID
        ///</summary>
        public void setSite(ushort pSite)
        { 
            _site = pSite;
        }

        [XmlElement(Type= typeof(ushort), ElementName="site")]
        public ushort Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }

        ///<summary>
        ///The application ID
        ///</summary>
        public void setApplication(ushort pApplication)
        { 
            _application = pApplication;
        }

        [XmlElement(Type= typeof(ushort), ElementName="application")]
        public ushort Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }

        ///<summary>
        ///the entity ID
        ///</summary>
        public void setEntity(ushort pEntity)
        { 
            _entity = pEntity;
        }

        [XmlElement(Type= typeof(ushort), ElementName="entity")]
        public ushort Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }


        ///<summary>
        ///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        ///</summary>
        public void marshal(DataOutputStream dos)
        {
            try
            {
                dos.writeUshort((ushort)_site);
                dos.writeUshort((ushort)_application);
                dos.writeUshort((ushort)_entity);
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
                _site = dis.readUshort();
                _application = dis.readUshort();
                _entity = dis.readUshort();
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
            sb.Append("<EntityID>"  + System.Environment.NewLine);
            try
            {
                sb.Append("<site type=\"ushort\">" + _site.ToString() + "</site> " + System.Environment.NewLine);
                sb.Append("<application type=\"ushort\">" + _application.ToString() + "</application> " + System.Environment.NewLine);
                sb.Append("<entity type=\"ushort\">" + _entity.ToString() + "</entity> " + System.Environment.NewLine);
                sb.Append("</EntityID>"  + System.Environment.NewLine);
            } // end try
            catch(Exception e)
            {
                Trace.WriteLine(e);
                Trace.Flush();
            }
        } // end of reflection method

        public static bool operator !=(EntityID a, EntityID b)
        {
            return !(a == b);
        }

        public static bool operator ==(EntityID a, EntityID b)
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
            return this == obj as EntityID;
        }


        /**
         * Compares for reference equality and value equality.
         */
        public bool equals(EntityID rhs)
        {
            bool ivarsEqual = true;

            if(rhs.GetType() != this.GetType())
                return false;


            if( ! (_site == rhs._site)) ivarsEqual = false;
            if( ! (_application == rhs._application)) ivarsEqual = false;
            if( ! (_entity == rhs._entity)) ivarsEqual = false;

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

            result = GenerateHash(result) ^ _site.GetHashCode();
            result = GenerateHash(result) ^ _application.GetHashCode();
            result = GenerateHash(result) ^ _entity.GetHashCode();

            return result;
        }
    } // end of class
} // end of namespace
