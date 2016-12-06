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
 * Section 5.2.38. Identifies the type of aggregate including kind of entity, domain (surface, subsurface, air, etc) country, category, etc.
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
public class AggregateType : Object
{
   /** Kind of entity */
   protected byte  _aggregateKind;

   /** Domain of entity (air, surface, subsurface, space, etc) */
   protected byte  _domain;

   /** country to which the design of the entity is attributed */
   protected ushort  _country;

   /** category of entity */
   protected byte  _category;

   /** subcategory of entity */
   protected byte  _subcategory;

   /** specific info based on subcategory field */
   protected byte  _specific;

   protected byte  _extra;


/** Constructor */
   ///<summary>
   ///Section 5.2.38. Identifies the type of aggregate including kind of entity, domain (surface, subsurface, air, etc) country, category, etc.
   ///</summary>
 public AggregateType()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 1;  // _aggregateKind
   marshalSize = marshalSize + 1;  // _domain
   marshalSize = marshalSize + 2;  // _country
   marshalSize = marshalSize + 1;  // _category
   marshalSize = marshalSize + 1;  // _subcategory
   marshalSize = marshalSize + 1;  // _specific
   marshalSize = marshalSize + 1;  // _extra

   return marshalSize;
}


   ///<summary>
   ///Kind of entity
   ///</summary>
public void setAggregateKind(byte pAggregateKind)
{ _aggregateKind = pAggregateKind;
}

[XmlElement(Type= typeof(byte), ElementName="aggregateKind")]
public byte AggregateKind
{
     get
{
          return _aggregateKind;
}
     set
{
          _aggregateKind = value;
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
   ///subcategory of entity
   ///</summary>
public void setSubcategory(byte pSubcategory)
{ _subcategory = pSubcategory;
}

[XmlElement(Type= typeof(byte), ElementName="subcategory")]
public byte Subcategory
{
     get
{
          return _subcategory;
}
     set
{
          _subcategory = value;
}
}

   ///<summary>
   ///specific info based on subcategory field
   ///</summary>
public void setSpecific(byte pSpecific)
{ _specific = pSpecific;
}

[XmlElement(Type= typeof(byte), ElementName="specific")]
public byte Specific
{
     get
{
          return _specific;
}
     set
{
          _specific = value;
}
}

public void setExtra(byte pExtra)
{ _extra = pExtra;
}

[XmlElement(Type= typeof(byte), ElementName="extra")]
public byte Extra
{
     get
{
          return _extra;
}
     set
{
          _extra = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeByte((byte)_aggregateKind);
       dos.writeByte((byte)_domain);
       dos.writeUshort((ushort)_country);
       dos.writeByte((byte)_category);
       dos.writeByte((byte)_subcategory);
       dos.writeByte((byte)_specific);
       dos.writeByte((byte)_extra);
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
       _aggregateKind = dis.readByte();
       _domain = dis.readByte();
       _country = dis.readUshort();
       _category = dis.readByte();
       _subcategory = dis.readByte();
       _specific = dis.readByte();
       _extra = dis.readByte();
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
    sb.Append("<AggregateType>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<aggregateKind type=\"byte\">" + _aggregateKind.ToString() + "</aggregateKind> " + System.Environment.NewLine);
           sb.Append("<domain type=\"byte\">" + _domain.ToString() + "</domain> " + System.Environment.NewLine);
           sb.Append("<country type=\"ushort\">" + _country.ToString() + "</country> " + System.Environment.NewLine);
           sb.Append("<category type=\"byte\">" + _category.ToString() + "</category> " + System.Environment.NewLine);
           sb.Append("<subcategory type=\"byte\">" + _subcategory.ToString() + "</subcategory> " + System.Environment.NewLine);
           sb.Append("<specific type=\"byte\">" + _specific.ToString() + "</specific> " + System.Environment.NewLine);
           sb.Append("<extra type=\"byte\">" + _extra.ToString() + "</extra> " + System.Environment.NewLine);
    sb.Append("</AggregateType>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(AggregateType a, AggregateType b)
        {
                return !(a == b);
        }

        public static bool operator ==(AggregateType a, AggregateType b)
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
 public bool equals(AggregateType rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_aggregateKind == rhs._aggregateKind)) ivarsEqual = false;
     if( ! (_domain == rhs._domain)) ivarsEqual = false;
     if( ! (_country == rhs._country)) ivarsEqual = false;
     if( ! (_category == rhs._category)) ivarsEqual = false;
     if( ! (_subcategory == rhs._subcategory)) ivarsEqual = false;
     if( ! (_specific == rhs._specific)) ivarsEqual = false;
     if( ! (_extra == rhs._extra)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
