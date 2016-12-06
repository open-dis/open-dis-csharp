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
 * Section 5.2.25. Identifies the type of radio
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
public class RadioEntityType : Object
{
   /** Kind of entity */
   protected byte  _entityKind;

   /** Domain of entity (air, surface, subsurface, space, etc) */
   protected byte  _domain;

   /** country to which the design of the entity is attributed */
   protected ushort  _country;

   /** category of entity */
   protected byte  _category;

   /** specific info based on subcategory field */
   protected byte  _nomenclatureVersion;

   protected ushort  _nomenclature;


/** Constructor */
   ///<summary>
   ///Section 5.2.25. Identifies the type of radio
   ///</summary>
 public RadioEntityType()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 1;  // _entityKind
   marshalSize = marshalSize + 1;  // _domain
   marshalSize = marshalSize + 2;  // _country
   marshalSize = marshalSize + 1;  // _category
   marshalSize = marshalSize + 1;  // _nomenclatureVersion
   marshalSize = marshalSize + 2;  // _nomenclature

   return marshalSize;
}


   ///<summary>
   ///Kind of entity
   ///</summary>
public void setEntityKind(byte pEntityKind)
{ _entityKind = pEntityKind;
}

[XmlElement(Type= typeof(byte), ElementName="entityKind")]
public byte EntityKind
{
     get
{
          return _entityKind;
}
     set
{
          _entityKind = value;
}
}

   ///<summary>
   ///Domain of entity (air, surface, subsurface, space, etc)
   ///</summary>
public void setDomain(byte pDomain)
{ _domain = pDomain;
}

[XmlElement(Type= typeof(byte), ElementName="domain")]
public byte Domain
{
     get
{
          return _domain;
}
     set
{
          _domain = value;
}
}

   ///<summary>
   ///country to which the design of the entity is attributed
   ///</summary>
public void setCountry(ushort pCountry)
{ _country = pCountry;
}

[XmlElement(Type= typeof(ushort), ElementName="country")]
public ushort Country
{
     get
{
          return _country;
}
     set
{
          _country = value;
}
}

   ///<summary>
   ///category of entity
   ///</summary>
public void setCategory(byte pCategory)
{ _category = pCategory;
}

[XmlElement(Type= typeof(byte), ElementName="category")]
public byte Category
{
     get
{
          return _category;
}
     set
{
          _category = value;
}
}

   ///<summary>
   ///specific info based on subcategory field
   ///</summary>
public void setNomenclatureVersion(byte pNomenclatureVersion)
{ _nomenclatureVersion = pNomenclatureVersion;
}

[XmlElement(Type= typeof(byte), ElementName="nomenclatureVersion")]
public byte NomenclatureVersion
{
     get
{
          return _nomenclatureVersion;
}
     set
{
          _nomenclatureVersion = value;
}
}

public void setNomenclature(ushort pNomenclature)
{ _nomenclature = pNomenclature;
}

[XmlElement(Type= typeof(ushort), ElementName="nomenclature")]
public ushort Nomenclature
{
     get
{
          return _nomenclature;
}
     set
{
          _nomenclature = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeByte((byte)_entityKind);
       dos.writeByte((byte)_domain);
       dos.writeUshort((ushort)_country);
       dos.writeByte((byte)_category);
       dos.writeByte((byte)_nomenclatureVersion);
       dos.writeUshort((ushort)_nomenclature);
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
       _entityKind = dis.readByte();
       _domain = dis.readByte();
       _country = dis.readUshort();
       _category = dis.readByte();
       _nomenclatureVersion = dis.readByte();
       _nomenclature = dis.readUshort();
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
    sb.Append("<RadioEntityType>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<entityKind type=\"byte\">" + _entityKind.ToString() + "</entityKind> " + System.Environment.NewLine);
           sb.Append("<domain type=\"byte\">" + _domain.ToString() + "</domain> " + System.Environment.NewLine);
           sb.Append("<country type=\"ushort\">" + _country.ToString() + "</country> " + System.Environment.NewLine);
           sb.Append("<category type=\"byte\">" + _category.ToString() + "</category> " + System.Environment.NewLine);
           sb.Append("<nomenclatureVersion type=\"byte\">" + _nomenclatureVersion.ToString() + "</nomenclatureVersion> " + System.Environment.NewLine);
           sb.Append("<nomenclature type=\"ushort\">" + _nomenclature.ToString() + "</nomenclature> " + System.Environment.NewLine);
    sb.Append("</RadioEntityType>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(RadioEntityType a, RadioEntityType b)
        {
                return !(a == b);
        }

        public static bool operator ==(RadioEntityType a, RadioEntityType b)
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


 /**
  * The equals method doesn't always work--mostly on on classes that consist only of primitives. Be careful.
  */
 public bool equals(RadioEntityType rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_entityKind == rhs._entityKind)) ivarsEqual = false;
     if( ! (_domain == rhs._domain)) ivarsEqual = false;
     if( ! (_country == rhs._country)) ivarsEqual = false;
     if( ! (_category == rhs._category)) ivarsEqual = false;
     if( ! (_nomenclatureVersion == rhs._nomenclatureVersion)) ivarsEqual = false;
     if( ! (_nomenclature == rhs._nomenclature)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
