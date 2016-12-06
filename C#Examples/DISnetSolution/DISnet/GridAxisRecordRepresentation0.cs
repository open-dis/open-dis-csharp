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
 * 5.2.44: Grid data record, representation 0
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
[XmlInclude(typeof(OneByteChunk))]
public class GridAxisRecordRepresentation0 : GridAxisRecord
{
   /** number of bytes of environmental state data */
   protected ushort  _numberOfBytes;

   /** variable length list of data parameters ^^^this is wrong--need padding as well */
   protected byte[] _dataValues; 

/** Constructor */
   ///<summary>
   ///5.2.44: Grid data record, representation 0
   ///</summary>
 public GridAxisRecordRepresentation0()
 {
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + 2;  // _numberOfBytes
   marshalSize = marshalSize + _dataValues.Length;

   return marshalSize;
}


/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfBytes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfBytes(ushort pNumberOfBytes)
{ _numberOfBytes = pNumberOfBytes;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfBytes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(ushort), ElementName="numberOfBytes")]
public ushort NumberOfBytes
{
     get
     {
          return _numberOfBytes;
     }
     set
     {
          _numberOfBytes = value;
     }
}

   ///<summary>
   ///variable length list of data parameters ^^^this is wrong--need padding as well
   ///</summary>
public void setDataValues(byte[] pDataValues)
{ _dataValues = pDataValues;
}

   ///<summary>
   ///variable length list of data parameters ^^^this is wrong--need padding as well
   ///</summary>
public byte[] getDataValues()
{ return _dataValues; }

   ///<summary>
   ///variable length list of data parameters ^^^this is wrong--need padding as well
   ///</summary>
[XmlElement(ElementName = "dataValuesList", DataType = "hexBinary")]
public byte[] DataValues
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
       dos.writeUshort((ushort)_dataValues.Length);
       dos.writeByte (_dataValues);
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
       _numberOfBytes = dis.readUshort();
       _dataValues = dis.readByteArray(_numberOfBytes);
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
    sb.Append("<GridAxisRecordRepresentation0>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
           sb.Append("<dataValues type=\"ushort\">" + _dataValues.Length.ToString() + "</dataValues> " + System.Environment.NewLine);

           sb.Append("<dataValues type=\"byte[]\">" + System.Environment.NewLine);
           foreach (byte b in _dataValues) sb.Append(b.ToString("X2"));
                sb.Append("</dataValues>" + System.Environment.NewLine);
    sb.Append("</GridAxisRecordRepresentation0>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(GridAxisRecordRepresentation0 a, GridAxisRecordRepresentation0 b)
        {
                return !(a == b);
        }

        public static bool operator ==(GridAxisRecordRepresentation0 a, GridAxisRecordRepresentation0 b)
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
 public bool equals(GridAxisRecordRepresentation0 rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_numberOfBytes == rhs._numberOfBytes)) ivarsEqual = false;
        if( ! ( _dataValues.Equals(rhs._dataValues))) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
