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
 * Record sets, used in transfer control request PDU
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
public class RecordSet : Object
{
   /** record ID */
   protected uint  _recordID;

   /** record set serial number */
   protected uint  _recordSetSerialNumber;

   /** record length */
   protected ushort  _recordLength;

   /** record count */
   protected ushort  _recordCount;

   /** ^^^This is wrong--variable sized data records */
   protected ushort  _recordValues;

   /** ^^^This is wrong--variable sized padding */
   protected byte  _pad4;


/** Constructor */
   ///<summary>
   ///Record sets, used in transfer control request PDU
   ///</summary>
 public RecordSet()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 4;  // _recordID
   marshalSize = marshalSize + 4;  // _recordSetSerialNumber
   marshalSize = marshalSize + 2;  // _recordLength
   marshalSize = marshalSize + 2;  // _recordCount
   marshalSize = marshalSize + 2;  // _recordValues
   marshalSize = marshalSize + 1;  // _pad4

   return marshalSize;
}


   ///<summary>
   ///record ID
   ///</summary>
public void setRecordID(uint pRecordID)
{ _recordID = pRecordID;
}

[XmlElement(Type= typeof(uint), ElementName="recordID")]
public uint RecordID
{
     get
{
          return _recordID;
}
     set
{
          _recordID = value;
}
}

   ///<summary>
   ///record set serial number
   ///</summary>
public void setRecordSetSerialNumber(uint pRecordSetSerialNumber)
{ _recordSetSerialNumber = pRecordSetSerialNumber;
}

[XmlElement(Type= typeof(uint), ElementName="recordSetSerialNumber")]
public uint RecordSetSerialNumber
{
     get
{
          return _recordSetSerialNumber;
}
     set
{
          _recordSetSerialNumber = value;
}
}

   ///<summary>
   ///record length
   ///</summary>
public void setRecordLength(ushort pRecordLength)
{ _recordLength = pRecordLength;
}

[XmlElement(Type= typeof(ushort), ElementName="recordLength")]
public ushort RecordLength
{
     get
{
          return _recordLength;
}
     set
{
          _recordLength = value;
}
}

   ///<summary>
   ///record count
   ///</summary>
public void setRecordCount(ushort pRecordCount)
{ _recordCount = pRecordCount;
}

[XmlElement(Type= typeof(ushort), ElementName="recordCount")]
public ushort RecordCount
{
     get
{
          return _recordCount;
}
     set
{
          _recordCount = value;
}
}

   ///<summary>
   ///^^^This is wrong--variable sized data records
   ///</summary>
public void setRecordValues(ushort pRecordValues)
{ _recordValues = pRecordValues;
}

[XmlElement(Type= typeof(ushort), ElementName="recordValues")]
public ushort RecordValues
{
     get
{
          return _recordValues;
}
     set
{
          _recordValues = value;
}
}

   ///<summary>
   ///^^^This is wrong--variable sized padding
   ///</summary>
public void setPad4(byte pPad4)
{ _pad4 = pPad4;
}

[XmlElement(Type= typeof(byte), ElementName="pad4")]
public byte Pad4
{
     get
{
          return _pad4;
}
     set
{
          _pad4 = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeUint((uint)_recordID);
       dos.writeUint((uint)_recordSetSerialNumber);
       dos.writeUshort((ushort)_recordLength);
       dos.writeUshort((ushort)_recordCount);
       dos.writeUshort((ushort)_recordValues);
       dos.writeByte((byte)_pad4);
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
       _recordID = dis.readUint();
       _recordSetSerialNumber = dis.readUint();
       _recordLength = dis.readUshort();
       _recordCount = dis.readUshort();
       _recordValues = dis.readUshort();
       _pad4 = dis.readByte();
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
    sb.Append("<RecordSet>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<recordID type=\"uint\">" + _recordID.ToString() + "</recordID> " + System.Environment.NewLine);
           sb.Append("<recordSetSerialNumber type=\"uint\">" + _recordSetSerialNumber.ToString() + "</recordSetSerialNumber> " + System.Environment.NewLine);
           sb.Append("<recordLength type=\"ushort\">" + _recordLength.ToString() + "</recordLength> " + System.Environment.NewLine);
           sb.Append("<recordCount type=\"ushort\">" + _recordCount.ToString() + "</recordCount> " + System.Environment.NewLine);
           sb.Append("<recordValues type=\"ushort\">" + _recordValues.ToString() + "</recordValues> " + System.Environment.NewLine);
           sb.Append("<pad4 type=\"byte\">" + _pad4.ToString() + "</pad4> " + System.Environment.NewLine);
    sb.Append("</RecordSet>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(RecordSet a, RecordSet b)
        {
                return !(a == b);
        }

        public static bool operator ==(RecordSet a, RecordSet b)
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
 public bool equals(RecordSet rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_recordID == rhs._recordID)) ivarsEqual = false;
     if( ! (_recordSetSerialNumber == rhs._recordSetSerialNumber)) ivarsEqual = false;
     if( ! (_recordLength == rhs._recordLength)) ivarsEqual = false;
     if( ! (_recordCount == rhs._recordCount)) ivarsEqual = false;
     if( ! (_recordValues == rhs._recordValues)) ivarsEqual = false;
     if( ! (_pad4 == rhs._pad4)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
