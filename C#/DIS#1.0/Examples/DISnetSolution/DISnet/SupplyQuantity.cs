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
 * Section 5.2.30. A supply, and the amount of that supply. Similar to an entity kind but with the addition of a quantity.
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
[XmlInclude(typeof(EntityType))]
public class SupplyQuantity : Object
{
   /** Type of supply */
   protected EntityType  _supplyType = new EntityType(); 

   /** quantity to be supplied */
   protected byte  _quantity;


/** Constructor */
   ///<summary>
   ///Section 5.2.30. A supply, and the amount of that supply. Similar to an entity kind but with the addition of a quantity.
   ///</summary>
 public SupplyQuantity()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + _supplyType.getMarshalledSize();  // _supplyType
   marshalSize = marshalSize + 1;  // _quantity

   return marshalSize;
}


   ///<summary>
   ///Type of supply
   ///</summary>
public void setSupplyType(EntityType pSupplyType)
{ _supplyType = pSupplyType;
}

   ///<summary>
   ///Type of supply
   ///</summary>
public EntityType getSupplyType()
{ return _supplyType; 
}

   ///<summary>
   ///Type of supply
   ///</summary>
[XmlElement(Type= typeof(EntityType), ElementName="supplyType")]
public EntityType SupplyType
{
     get
{
          return _supplyType;
}
     set
{
          _supplyType = value;
}
}

   ///<summary>
   ///quantity to be supplied
   ///</summary>
public void setQuantity(byte pQuantity)
{ _quantity = pQuantity;
}

[XmlElement(Type= typeof(byte), ElementName="quantity")]
public byte Quantity
{
     get
{
          return _quantity;
}
     set
{
          _quantity = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       _supplyType.marshal(dos);
       dos.writeByte((byte)_quantity);
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
       _supplyType.unmarshal(dis);
       _quantity = dis.readByte();
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
    sb.Append("<SupplyQuantity>"  + System.Environment.NewLine);
    try 
    {
    sb.Append("<supplyType>"  + System.Environment.NewLine);
       _supplyType.reflection(sb);
    sb.Append("</supplyType>"  + System.Environment.NewLine);
           sb.Append("<quantity type=\"byte\">" + _quantity.ToString() + "</quantity> " + System.Environment.NewLine);
    sb.Append("</SupplyQuantity>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(SupplyQuantity a, SupplyQuantity b)
        {
                return !(a == b);
        }

        public static bool operator ==(SupplyQuantity a, SupplyQuantity b)
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
 public bool equals(SupplyQuantity rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_supplyType.Equals( rhs._supplyType) )) ivarsEqual = false;
     if( ! (_quantity == rhs._quantity)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
