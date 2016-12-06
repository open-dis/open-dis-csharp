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
 * Section 5.2.5.5. Repair is complete. COMPLETE
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
public class RepairCompletePdu : LogisticsFamilyPdu
{
   /** Entity that is receiving service */
   protected EntityID  _receivingEntityID = new EntityID(); 

   /** Entity that is supplying */
   protected EntityID  _repairingEntityID = new EntityID(); 

   /** Enumeration for type of repair */
   protected ushort  _repair;

   /** padding, number prevents conflict with superclass ivar name */
   protected short  _padding2 = 0;


/** Constructor */
   ///<summary>
   ///Section 5.2.5.5. Repair is complete. COMPLETE
   ///</summary>
 public RepairCompletePdu()
 {
    PduType = (byte)9;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _receivingEntityID.getMarshalledSize();  // _receivingEntityID
   marshalSize = marshalSize + _repairingEntityID.getMarshalledSize();  // _repairingEntityID
   marshalSize = marshalSize + 2;  // _repair
   marshalSize = marshalSize + 2;  // _padding2

   return marshalSize;
}


   ///<summary>
   ///Entity that is receiving service
   ///</summary>
public void setReceivingEntityID(EntityID pReceivingEntityID)
{ _receivingEntityID = pReceivingEntityID;
}

   ///<summary>
   ///Entity that is receiving service
   ///</summary>
public EntityID getReceivingEntityID()
{ return _receivingEntityID; 
}

   ///<summary>
   ///Entity that is receiving service
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="receivingEntityID")]
public EntityID ReceivingEntityID
{
     get
{
          return _receivingEntityID;
}
     set
{
          _receivingEntityID = value;
}
}

   ///<summary>
   ///Entity that is supplying
   ///</summary>
public void setRepairingEntityID(EntityID pRepairingEntityID)
{ _repairingEntityID = pRepairingEntityID;
}

   ///<summary>
   ///Entity that is supplying
   ///</summary>
public EntityID getRepairingEntityID()
{ return _repairingEntityID; 
}

   ///<summary>
   ///Entity that is supplying
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="repairingEntityID")]
public EntityID RepairingEntityID
{
     get
{
          return _repairingEntityID;
}
     set
{
          _repairingEntityID = value;
}
}

   ///<summary>
   ///Enumeration for type of repair
   ///</summary>
public void setRepair(ushort pRepair)
{ _repair = pRepair;
}

[XmlElement(Type= typeof(ushort), ElementName="repair")]
public ushort Repair
{
     get
{
          return _repair;
}
     set
{
          _repair = value;
}
}

   ///<summary>
   ///padding, number prevents conflict with superclass ivar name
   ///</summary>
public void setPadding2(short pPadding2)
{ _padding2 = pPadding2;
}

[XmlElement(Type= typeof(short), ElementName="padding2")]
public short Padding2
{
     get
{
          return _padding2;
}
     set
{
          _padding2 = value;
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
       _receivingEntityID.marshal(dos);
       _repairingEntityID.marshal(dos);
       dos.writeUshort((ushort)_repair);
       dos.writeShort((short)_padding2);
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
       _receivingEntityID.unmarshal(dis);
       _repairingEntityID.unmarshal(dis);
       _repair = dis.readUshort();
       _padding2 = dis.readShort();
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
    sb.Append("<RepairCompletePdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<receivingEntityID>"  + System.Environment.NewLine);
       _receivingEntityID.reflection(sb);
    sb.Append("</receivingEntityID>"  + System.Environment.NewLine);
    sb.Append("<repairingEntityID>"  + System.Environment.NewLine);
       _repairingEntityID.reflection(sb);
    sb.Append("</repairingEntityID>"  + System.Environment.NewLine);
           sb.Append("<repair type=\"ushort\">" + _repair.ToString() + "</repair> " + System.Environment.NewLine);
           sb.Append("<padding2 type=\"short\">" + _padding2.ToString() + "</padding2> " + System.Environment.NewLine);
    sb.Append("</RepairCompletePdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(RepairCompletePdu a, RepairCompletePdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(RepairCompletePdu a, RepairCompletePdu b)
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
 public bool equals(RepairCompletePdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_receivingEntityID.Equals( rhs._receivingEntityID) )) ivarsEqual = false;
     if( ! (_repairingEntityID.Equals( rhs._repairingEntityID) )) ivarsEqual = false;
     if( ! (_repair == rhs._repair)) ivarsEqual = false;
     if( ! (_padding2 == rhs._padding2)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
