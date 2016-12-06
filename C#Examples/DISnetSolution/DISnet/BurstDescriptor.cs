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
 * Section 5.2.7. Specifies the type of muntion fired, the type of warhead, the         type of fuse, the number of rounds fired, and the rate at which the roudns are fired in         rounds per minute.
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
public class BurstDescriptor : Object
{
   /** What munition was used in the burst */
   protected EntityType  _munition = new EntityType(); 

   /** type of warhead */
   protected ushort  _warhead;

   /** type of fuse used */
   protected ushort  _fuse;

   /** how many of the munition were fired */
   protected ushort  _quantity;

   /** rate at which the munition was fired */
   protected ushort  _rate;


/** Constructor */
   ///<summary>
   ///Section 5.2.7. Specifies the type of muntion fired, the type of warhead, the         type of fuse, the number of rounds fired, and the rate at which the roudns are fired in         rounds per minute.
   ///</summary>
 public BurstDescriptor()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + _munition.getMarshalledSize();  // _munition
   marshalSize = marshalSize + 2;  // _warhead
   marshalSize = marshalSize + 2;  // _fuse
   marshalSize = marshalSize + 2;  // _quantity
   marshalSize = marshalSize + 2;  // _rate

   return marshalSize;
}


   ///<summary>
   ///What munition was used in the burst
   ///</summary>
public void setMunition(EntityType pMunition)
{ _munition = pMunition;
}

   ///<summary>
   ///What munition was used in the burst
   ///</summary>
public EntityType getMunition()
{ return _munition; 
}

   ///<summary>
   ///What munition was used in the burst
   ///</summary>
[XmlElement(Type= typeof(EntityType), ElementName="munition")]
public EntityType Munition
{
     get
{
          return _munition;
}
     set
{
          _munition = value;
}
}

   ///<summary>
   ///type of warhead
   ///</summary>
public void setWarhead(ushort pWarhead)
{ _warhead = pWarhead;
}

[XmlElement(Type= typeof(ushort), ElementName="warhead")]
public ushort Warhead
{
     get
{
          return _warhead;
}
     set
{
          _warhead = value;
}
}

   ///<summary>
   ///type of fuse used
   ///</summary>
public void setFuse(ushort pFuse)
{ _fuse = pFuse;
}

[XmlElement(Type= typeof(ushort), ElementName="fuse")]
public ushort Fuse
{
     get
{
          return _fuse;
}
     set
{
          _fuse = value;
}
}

   ///<summary>
   ///how many of the munition were fired
   ///</summary>
public void setQuantity(ushort pQuantity)
{ _quantity = pQuantity;
}

[XmlElement(Type= typeof(ushort), ElementName="quantity")]
public ushort Quantity
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
   ///rate at which the munition was fired
   ///</summary>
public void setRate(ushort pRate)
{ _rate = pRate;
}

[XmlElement(Type= typeof(ushort), ElementName="rate")]
public ushort Rate
{
     get
{
          return _rate;
}
     set
{
          _rate = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       _munition.marshal(dos);
       dos.writeUshort((ushort)_warhead);
       dos.writeUshort((ushort)_fuse);
       dos.writeUshort((ushort)_quantity);
       dos.writeUshort((ushort)_rate);
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
       _munition.unmarshal(dis);
       _warhead = dis.readUshort();
       _fuse = dis.readUshort();
       _quantity = dis.readUshort();
       _rate = dis.readUshort();
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
    sb.Append("<BurstDescriptor>"  + System.Environment.NewLine);
    try 
    {
    sb.Append("<munition>"  + System.Environment.NewLine);
       _munition.reflection(sb);
    sb.Append("</munition>"  + System.Environment.NewLine);
           sb.Append("<warhead type=\"ushort\">" + _warhead.ToString() + "</warhead> " + System.Environment.NewLine);
           sb.Append("<fuse type=\"ushort\">" + _fuse.ToString() + "</fuse> " + System.Environment.NewLine);
           sb.Append("<quantity type=\"ushort\">" + _quantity.ToString() + "</quantity> " + System.Environment.NewLine);
           sb.Append("<rate type=\"ushort\">" + _rate.ToString() + "</rate> " + System.Environment.NewLine);
    sb.Append("</BurstDescriptor>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(BurstDescriptor a, BurstDescriptor b)
        {
                return !(a == b);
        }

        public static bool operator ==(BurstDescriptor a, BurstDescriptor b)
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
 public bool equals(BurstDescriptor rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_munition.Equals( rhs._munition) )) ivarsEqual = false;
     if( ! (_warhead == rhs._warhead)) ivarsEqual = false;
     if( ! (_fuse == rhs._fuse)) ivarsEqual = false;
     if( ! (_quantity == rhs._quantity)) ivarsEqual = false;
     if( ! (_rate == rhs._rate)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
