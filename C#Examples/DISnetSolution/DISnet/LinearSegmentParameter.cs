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
 * 5.2.48: Linear segment parameters
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
[XmlInclude(typeof(SixByteChunk))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
public class LinearSegmentParameter : Object
{
   /** number of segments */
   protected byte  _segmentNumber;

   /** segment appearance */
   protected SixByteChunk  _segmentAppearance = new SixByteChunk(); 

   /** location */
   protected Vector3Double  _location = new Vector3Double(); 

   /** orientation */
   protected Orientation  _orientation = new Orientation(); 

   /** segmentLength */
   protected ushort  _segmentLength;

   /** segmentWidth */
   protected ushort  _segmentWidth;

   /** segmentHeight */
   protected ushort  _segmentHeight;

   /** segment Depth */
   protected ushort  _segmentDepth;

   /** segment Depth */
   protected uint  _pad1;


/** Constructor */
   ///<summary>
   ///5.2.48: Linear segment parameters
   ///</summary>
 public LinearSegmentParameter()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 1;  // _segmentNumber
   marshalSize = marshalSize + _segmentAppearance.getMarshalledSize();  // _segmentAppearance
   marshalSize = marshalSize + _location.getMarshalledSize();  // _location
   marshalSize = marshalSize + _orientation.getMarshalledSize();  // _orientation
   marshalSize = marshalSize + 2;  // _segmentLength
   marshalSize = marshalSize + 2;  // _segmentWidth
   marshalSize = marshalSize + 2;  // _segmentHeight
   marshalSize = marshalSize + 2;  // _segmentDepth
   marshalSize = marshalSize + 4;  // _pad1

   return marshalSize;
}


   ///<summary>
   ///number of segments
   ///</summary>
public void setSegmentNumber(byte pSegmentNumber)
{ _segmentNumber = pSegmentNumber;
}

[XmlElement(Type= typeof(byte), ElementName="segmentNumber")]
public byte SegmentNumber
{
     get
{
          return _segmentNumber;
}
     set
{
          _segmentNumber = value;
}
}

   ///<summary>
   ///segment appearance
   ///</summary>
public void setSegmentAppearance(SixByteChunk pSegmentAppearance)
{ _segmentAppearance = pSegmentAppearance;
}

   ///<summary>
   ///segment appearance
   ///</summary>
public SixByteChunk getSegmentAppearance()
{ return _segmentAppearance; 
}

   ///<summary>
   ///segment appearance
   ///</summary>
[XmlElement(Type= typeof(SixByteChunk), ElementName="segmentAppearance")]
public SixByteChunk SegmentAppearance
{
     get
{
          return _segmentAppearance;
}
     set
{
          _segmentAppearance = value;
}
}

   ///<summary>
   ///location
   ///</summary>
public void setLocation(Vector3Double pLocation)
{ _location = pLocation;
}

   ///<summary>
   ///location
   ///</summary>
public Vector3Double getLocation()
{ return _location; 
}

   ///<summary>
   ///location
   ///</summary>
[XmlElement(Type= typeof(Vector3Double), ElementName="location")]
public Vector3Double Location
{
     get
{
          return _location;
}
     set
{
          _location = value;
}
}

   ///<summary>
   ///orientation
   ///</summary>
public void setOrientation(Orientation pOrientation)
{ _orientation = pOrientation;
}

   ///<summary>
   ///orientation
   ///</summary>
public Orientation getOrientation()
{ return _orientation; 
}

   ///<summary>
   ///orientation
   ///</summary>
[XmlElement(Type= typeof(Orientation), ElementName="orientation")]
public Orientation Orientation
{
     get
{
          return _orientation;
}
     set
{
          _orientation = value;
}
}

   ///<summary>
   ///segmentLength
   ///</summary>
public void setSegmentLength(ushort pSegmentLength)
{ _segmentLength = pSegmentLength;
}

[XmlElement(Type= typeof(ushort), ElementName="segmentLength")]
public ushort SegmentLength
{
     get
{
          return _segmentLength;
}
     set
{
          _segmentLength = value;
}
}

   ///<summary>
   ///segmentWidth
   ///</summary>
public void setSegmentWidth(ushort pSegmentWidth)
{ _segmentWidth = pSegmentWidth;
}

[XmlElement(Type= typeof(ushort), ElementName="segmentWidth")]
public ushort SegmentWidth
{
     get
{
          return _segmentWidth;
}
     set
{
          _segmentWidth = value;
}
}

   ///<summary>
   ///segmentHeight
   ///</summary>
public void setSegmentHeight(ushort pSegmentHeight)
{ _segmentHeight = pSegmentHeight;
}

[XmlElement(Type= typeof(ushort), ElementName="segmentHeight")]
public ushort SegmentHeight
{
     get
{
          return _segmentHeight;
}
     set
{
          _segmentHeight = value;
}
}

   ///<summary>
   ///segment Depth
   ///</summary>
public void setSegmentDepth(ushort pSegmentDepth)
{ _segmentDepth = pSegmentDepth;
}

[XmlElement(Type= typeof(ushort), ElementName="segmentDepth")]
public ushort SegmentDepth
{
     get
{
          return _segmentDepth;
}
     set
{
          _segmentDepth = value;
}
}

   ///<summary>
   ///segment Depth
   ///</summary>
public void setPad1(uint pPad1)
{ _pad1 = pPad1;
}

[XmlElement(Type= typeof(uint), ElementName="pad1")]
public uint Pad1
{
     get
{
          return _pad1;
}
     set
{
          _pad1 = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeByte((byte)_segmentNumber);
       _segmentAppearance.marshal(dos);
       _location.marshal(dos);
       _orientation.marshal(dos);
       dos.writeUshort((ushort)_segmentLength);
       dos.writeUshort((ushort)_segmentWidth);
       dos.writeUshort((ushort)_segmentHeight);
       dos.writeUshort((ushort)_segmentDepth);
       dos.writeUint((uint)_pad1);
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
       _segmentNumber = dis.readByte();
       _segmentAppearance.unmarshal(dis);
       _location.unmarshal(dis);
       _orientation.unmarshal(dis);
       _segmentLength = dis.readUshort();
       _segmentWidth = dis.readUshort();
       _segmentHeight = dis.readUshort();
       _segmentDepth = dis.readUshort();
       _pad1 = dis.readUint();
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
    sb.Append("<LinearSegmentParameter>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<segmentNumber type=\"byte\">" + _segmentNumber.ToString() + "</segmentNumber> " + System.Environment.NewLine);
    sb.Append("<segmentAppearance>"  + System.Environment.NewLine);
       _segmentAppearance.reflection(sb);
    sb.Append("</segmentAppearance>"  + System.Environment.NewLine);
    sb.Append("<location>"  + System.Environment.NewLine);
       _location.reflection(sb);
    sb.Append("</location>"  + System.Environment.NewLine);
    sb.Append("<orientation>"  + System.Environment.NewLine);
       _orientation.reflection(sb);
    sb.Append("</orientation>"  + System.Environment.NewLine);
           sb.Append("<segmentLength type=\"ushort\">" + _segmentLength.ToString() + "</segmentLength> " + System.Environment.NewLine);
           sb.Append("<segmentWidth type=\"ushort\">" + _segmentWidth.ToString() + "</segmentWidth> " + System.Environment.NewLine);
           sb.Append("<segmentHeight type=\"ushort\">" + _segmentHeight.ToString() + "</segmentHeight> " + System.Environment.NewLine);
           sb.Append("<segmentDepth type=\"ushort\">" + _segmentDepth.ToString() + "</segmentDepth> " + System.Environment.NewLine);
           sb.Append("<pad1 type=\"uint\">" + _pad1.ToString() + "</pad1> " + System.Environment.NewLine);
    sb.Append("</LinearSegmentParameter>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(LinearSegmentParameter a, LinearSegmentParameter b)
        {
                return !(a == b);
        }

        public static bool operator ==(LinearSegmentParameter a, LinearSegmentParameter b)
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
 public bool equals(LinearSegmentParameter rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_segmentNumber == rhs._segmentNumber)) ivarsEqual = false;
     if( ! (_segmentAppearance.Equals( rhs._segmentAppearance) )) ivarsEqual = false;
     if( ! (_location.Equals( rhs._location) )) ivarsEqual = false;
     if( ! (_orientation.Equals( rhs._orientation) )) ivarsEqual = false;
     if( ! (_segmentLength == rhs._segmentLength)) ivarsEqual = false;
     if( ! (_segmentWidth == rhs._segmentWidth)) ivarsEqual = false;
     if( ! (_segmentHeight == rhs._segmentHeight)) ivarsEqual = false;
     if( ! (_segmentDepth == rhs._segmentDepth)) ivarsEqual = false;
     if( ! (_pad1 == rhs._pad1)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
