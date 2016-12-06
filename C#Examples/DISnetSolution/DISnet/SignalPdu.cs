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
 * Section 5.3.8.2. Detailed information about a radio transmitter. This PDU requires        manually written code to complete. The encodingScheme field can be used in multiple        ways, which requires hand-written code to finish. UNFINISHED
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
public class SignalPdu : RadioCommunicationsFamilyPdu
{
   /** encoding scheme used, and enumeration */
   protected ushort  _encodingScheme;

   /** tdl type */
   protected ushort  _tdlType;

   /** sample rate */
   protected uint  _sampleRate;

   /** length od data */
   protected short  _dataLength;

   /** number of samples */
   protected short  _samples;

   /** list of eight bit values */
   protected byte[] _data; 

/** Constructor */
   ///<summary>
   ///Section 5.3.8.2. Detailed information about a radio transmitter. This PDU requires        manually written code to complete. The encodingScheme field can be used in multiple        ways, which requires hand-written code to finish. UNFINISHED
   ///</summary>
 public SignalPdu()
 {
    PduType = (byte)26;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + 2;  // _encodingScheme
   marshalSize = marshalSize + 2;  // _tdlType
   marshalSize = marshalSize + 4;  // _sampleRate
   marshalSize = marshalSize + 2;  // _dataLength
   marshalSize = marshalSize + 2;  // _samples
   marshalSize = marshalSize + _data.Length;

   return marshalSize;
}


   ///<summary>
   ///encoding scheme used, and enumeration
   ///</summary>
public void setEncodingScheme(ushort pEncodingScheme)
{ _encodingScheme = pEncodingScheme;
}

[XmlElement(Type= typeof(ushort), ElementName="encodingScheme")]
public ushort EncodingScheme
{
     get
{
          return _encodingScheme;
}
     set
{
          _encodingScheme = value;
}
}

   ///<summary>
   ///tdl type
   ///</summary>
public void setTdlType(ushort pTdlType)
{ _tdlType = pTdlType;
}

[XmlElement(Type= typeof(ushort), ElementName="tdlType")]
public ushort TdlType
{
     get
{
          return _tdlType;
}
     set
{
          _tdlType = value;
}
}

   ///<summary>
   ///sample rate
   ///</summary>
public void setSampleRate(uint pSampleRate)
{ _sampleRate = pSampleRate;
}

[XmlElement(Type= typeof(uint), ElementName="sampleRate")]
public uint SampleRate
{
     get
{
          return _sampleRate;
}
     set
{
          _sampleRate = value;
}
}

/// <summary>
/// This value must be set to the number of bits that will be used from the Data field.  Normally this value would be in increments of 8.  If this is the case then multiply the number of bytes used in the Data field by 8 and store that number here.
/// </summary>
public void setDataLength(short pDataLength)
{ _dataLength = pDataLength;
}

/// <summary>
/// This value must be set to the number of bits that will be used from the Data field.  Normally this value would be in increments of 8.  If this is the case then multiply the number of bytes used in the Data field by 8 and store that number here.
/// </summary>
[XmlElement(Type= typeof(short), ElementName="dataLength")]
public short DataLength
{
     get
     {
          return _dataLength;
     }
     set
     {
          _dataLength = value;
     }
}

   ///<summary>
   ///number of samples
   ///</summary>
public void setSamples(short pSamples)
{ _samples = pSamples;
}

[XmlElement(Type= typeof(short), ElementName="samples")]
public short Samples
{
     get
{
          return _samples;
}
     set
{
          _samples = value;
}
}

   ///<summary>
   ///list of eight bit values
   ///</summary>
public void setData(byte[] pData)
{ _data = pData;
}

   ///<summary>
   ///list of eight bit values
   ///</summary>
public byte[] getData()
{ return _data; }

   ///<summary>
   ///list of eight bit values
   ///</summary>
[XmlElement(ElementName = "dataList", DataType = "hexBinary")]
public byte[] Data
{
     get
{
          return _data;
}
     set
{
          _data = value;
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
       dos.writeUshort((ushort)_encodingScheme);
       dos.writeUshort((ushort)_tdlType);
       dos.writeUint((uint)_sampleRate);
       dos.writeShort((short)((_dataLength == 0 && _data.Length > 0) ? _data.Length * 8 : _dataLength)); //09062009 Post processed.  If value is zero then default to every byte will use all 8 bits
       dos.writeShort((short)_samples);
       dos.writeByte (_data);
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
       _encodingScheme = dis.readUshort();
       _tdlType = dis.readUshort();
       _sampleRate = dis.readUint();
       _dataLength = dis.readShort();
       _samples = dis.readShort();
       _data = dis.readByteArray((_dataLength / 8) + (_dataLength % 8 > 0 ? 1 : 0));  //09062009 Post processed. Needed to convert from bits to bytes
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
    sb.Append("<SignalPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
           sb.Append("<encodingScheme type=\"ushort\">" + _encodingScheme.ToString() + "</encodingScheme> " + System.Environment.NewLine);
           sb.Append("<tdlType type=\"ushort\">" + _tdlType.ToString() + "</tdlType> " + System.Environment.NewLine);
           sb.Append("<sampleRate type=\"uint\">" + _sampleRate.ToString() + "</sampleRate> " + System.Environment.NewLine);
           sb.Append("<data type=\"short\">" + _data.Length.ToString() + "</data> " + System.Environment.NewLine);
           sb.Append("<samples type=\"short\">" + _samples.ToString() + "</samples> " + System.Environment.NewLine);

           sb.Append("<data type=\"byte[]\">" + System.Environment.NewLine);
           foreach (byte b in _data) sb.Append(b.ToString("X2"));
                sb.Append("</data>" + System.Environment.NewLine);
    sb.Append("</SignalPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(SignalPdu a, SignalPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(SignalPdu a, SignalPdu b)
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
 public bool equals(SignalPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_encodingScheme == rhs._encodingScheme)) ivarsEqual = false;
     if( ! (_tdlType == rhs._tdlType)) ivarsEqual = false;
     if( ! (_sampleRate == rhs._sampleRate)) ivarsEqual = false;
     if( ! (_dataLength == rhs._dataLength)) ivarsEqual = false;
     if( ! (_samples == rhs._samples)) ivarsEqual = false;
        if( ! ( _data.Equals(rhs._data))) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
