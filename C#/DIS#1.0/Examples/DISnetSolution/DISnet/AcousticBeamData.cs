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
 * Used in UA PDU
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
[XmlInclude(typeof(AcousticBeamFundamentalParameter))]
public class AcousticBeamData : Object
{
   /** beam data length */
   protected ushort  _beamDataLength;

   /** beamIDNumber */
   protected byte  _beamIDNumber;

   /** padding */
   protected ushort  _pad2;

   /** fundamental data parameters */
   protected AcousticBeamFundamentalParameter  _fundamentalDataParameters = new AcousticBeamFundamentalParameter(); 


/** Constructor */
   ///<summary>
   ///Used in UA PDU
   ///</summary>
 public AcousticBeamData()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 2;  // _beamDataLength
   marshalSize = marshalSize + 1;  // _beamIDNumber
   marshalSize = marshalSize + 2;  // _pad2
   marshalSize = marshalSize + _fundamentalDataParameters.getMarshalledSize();  // _fundamentalDataParameters

   return marshalSize;
}


   ///<summary>
   ///beam data length
   ///</summary>
public void setBeamDataLength(ushort pBeamDataLength)
{ _beamDataLength = pBeamDataLength;
}

[XmlElement(Type= typeof(ushort), ElementName="beamDataLength")]
public ushort BeamDataLength
{
     get
{
          return _beamDataLength;
}
     set
{
          _beamDataLength = value;
}
}

   ///<summary>
   ///beamIDNumber
   ///</summary>
public void setBeamIDNumber(byte pBeamIDNumber)
{ _beamIDNumber = pBeamIDNumber;
}

[XmlElement(Type= typeof(byte), ElementName="beamIDNumber")]
public byte BeamIDNumber
{
     get
{
          return _beamIDNumber;
}
     set
{
          _beamIDNumber = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad2(ushort pPad2)
{ _pad2 = pPad2;
}

[XmlElement(Type= typeof(ushort), ElementName="pad2")]
public ushort Pad2
{
     get
{
          return _pad2;
}
     set
{
          _pad2 = value;
}
}

   ///<summary>
   ///fundamental data parameters
   ///</summary>
public void setFundamentalDataParameters(AcousticBeamFundamentalParameter pFundamentalDataParameters)
{ _fundamentalDataParameters = pFundamentalDataParameters;
}

   ///<summary>
   ///fundamental data parameters
   ///</summary>
public AcousticBeamFundamentalParameter getFundamentalDataParameters()
{ return _fundamentalDataParameters; 
}

   ///<summary>
   ///fundamental data parameters
   ///</summary>
[XmlElement(Type= typeof(AcousticBeamFundamentalParameter), ElementName="fundamentalDataParameters")]
public AcousticBeamFundamentalParameter FundamentalDataParameters
{
     get
{
          return _fundamentalDataParameters;
}
     set
{
          _fundamentalDataParameters = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeUshort((ushort)_beamDataLength);
       dos.writeByte((byte)_beamIDNumber);
       dos.writeUshort((ushort)_pad2);
       _fundamentalDataParameters.marshal(dos);
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
       _beamDataLength = dis.readUshort();
       _beamIDNumber = dis.readByte();
       _pad2 = dis.readUshort();
       _fundamentalDataParameters.unmarshal(dis);
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
    sb.Append("<AcousticBeamData>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<beamDataLength type=\"ushort\">" + _beamDataLength.ToString() + "</beamDataLength> " + System.Environment.NewLine);
           sb.Append("<beamIDNumber type=\"byte\">" + _beamIDNumber.ToString() + "</beamIDNumber> " + System.Environment.NewLine);
           sb.Append("<pad2 type=\"ushort\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
    sb.Append("<fundamentalDataParameters>"  + System.Environment.NewLine);
       _fundamentalDataParameters.reflection(sb);
    sb.Append("</fundamentalDataParameters>"  + System.Environment.NewLine);
    sb.Append("</AcousticBeamData>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(AcousticBeamData a, AcousticBeamData b)
        {
                return !(a == b);
        }

        public static bool operator ==(AcousticBeamData a, AcousticBeamData b)
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
 public bool equals(AcousticBeamData rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_beamDataLength == rhs._beamDataLength)) ivarsEqual = false;
     if( ! (_beamIDNumber == rhs._beamIDNumber)) ivarsEqual = false;
     if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
     if( ! (_fundamentalDataParameters.Equals( rhs._fundamentalDataParameters) )) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
