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
 * Section 5.3.10.3 Information about individual mines within a minefield. This is very, very wrong. UNFINISHED
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
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(TwoByteChunk))]
[XmlInclude(typeof(Vector3Float))]
public class MinefieldDataPdu : MinefieldFamilyPdu
{
   /** Minefield ID */
   protected EntityID  _minefieldID = new EntityID(); 

   /** ID of entity making request */
   protected EntityID  _requestingEntityID = new EntityID(); 

   /** Minefield sequence number */
   protected ushort  _minefieldSequenceNumbeer;

   /** request ID */
   protected byte  _requestID;

   /** pdu sequence number */
   protected byte  _pduSequenceNumber;

   /** number of pdus in response */
   protected byte  _numberOfPdus;

   /** how many mines are in this PDU */
   protected byte  _numberOfMinesInThisPdu;

   /** how many sensor type are in this PDU */
   protected byte  _numberOfSensorTypes;

   /** padding */
   protected byte  _pad2 = 0;

   /** 32 boolean fields */
   protected uint  _dataFilter;

   /** Mine type */
   protected EntityType  _mineType = new EntityType(); 

   /** Sensor types, each 16 bits long */
   protected List<TwoByteChunk> _sensorTypes = new List<TwoByteChunk>(); 
   /** Padding to get things 32-bit aligned. ^^^this is wrong--dyanmically sized padding needed */
   protected byte  _pad3;

   /** Mine locations */
   protected List<Vector3Float> _mineLocation = new List<Vector3Float>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.10.3 Information about individual mines within a minefield. This is very, very wrong. UNFINISHED
   ///</summary>
 public MinefieldDataPdu()
 {
    PduType = (byte)39;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _minefieldID.getMarshalledSize();  // _minefieldID
   marshalSize = marshalSize + _requestingEntityID.getMarshalledSize();  // _requestingEntityID
   marshalSize = marshalSize + 2;  // _minefieldSequenceNumbeer
   marshalSize = marshalSize + 1;  // _requestID
   marshalSize = marshalSize + 1;  // _pduSequenceNumber
   marshalSize = marshalSize + 1;  // _numberOfPdus
   marshalSize = marshalSize + 1;  // _numberOfMinesInThisPdu
   marshalSize = marshalSize + 1;  // _numberOfSensorTypes
   marshalSize = marshalSize + 1;  // _pad2
   marshalSize = marshalSize + 4;  // _dataFilter
   marshalSize = marshalSize + _mineType.getMarshalledSize();  // _mineType
   for(int idx=0; idx < _sensorTypes.Count; idx++)
   {
        TwoByteChunk listElement = (TwoByteChunk)_sensorTypes[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   marshalSize = marshalSize + 1;  // _pad3
   for(int idx=0; idx < _mineLocation.Count; idx++)
   {
        Vector3Float listElement = (Vector3Float)_mineLocation[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///Minefield ID
   ///</summary>
public void setMinefieldID(EntityID pMinefieldID)
{ _minefieldID = pMinefieldID;
}

   ///<summary>
   ///Minefield ID
   ///</summary>
public EntityID getMinefieldID()
{ return _minefieldID; 
}

   ///<summary>
   ///Minefield ID
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="minefieldID")]
public EntityID MinefieldID
{
     get
{
          return _minefieldID;
}
     set
{
          _minefieldID = value;
}
}

   ///<summary>
   ///ID of entity making request
   ///</summary>
public void setRequestingEntityID(EntityID pRequestingEntityID)
{ _requestingEntityID = pRequestingEntityID;
}

   ///<summary>
   ///ID of entity making request
   ///</summary>
public EntityID getRequestingEntityID()
{ return _requestingEntityID; 
}

   ///<summary>
   ///ID of entity making request
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="requestingEntityID")]
public EntityID RequestingEntityID
{
     get
{
          return _requestingEntityID;
}
     set
{
          _requestingEntityID = value;
}
}

   ///<summary>
   ///Minefield sequence number
   ///</summary>
public void setMinefieldSequenceNumbeer(ushort pMinefieldSequenceNumbeer)
{ _minefieldSequenceNumbeer = pMinefieldSequenceNumbeer;
}

[XmlElement(Type= typeof(ushort), ElementName="minefieldSequenceNumbeer")]
public ushort MinefieldSequenceNumbeer
{
     get
{
          return _minefieldSequenceNumbeer;
}
     set
{
          _minefieldSequenceNumbeer = value;
}
}

   ///<summary>
   ///request ID
   ///</summary>
public void setRequestID(byte pRequestID)
{ _requestID = pRequestID;
}

[XmlElement(Type= typeof(byte), ElementName="requestID")]
public byte RequestID
{
     get
{
          return _requestID;
}
     set
{
          _requestID = value;
}
}

   ///<summary>
   ///pdu sequence number
   ///</summary>
public void setPduSequenceNumber(byte pPduSequenceNumber)
{ _pduSequenceNumber = pPduSequenceNumber;
}

[XmlElement(Type= typeof(byte), ElementName="pduSequenceNumber")]
public byte PduSequenceNumber
{
     get
{
          return _pduSequenceNumber;
}
     set
{
          _pduSequenceNumber = value;
}
}

   ///<summary>
   ///number of pdus in response
   ///</summary>
public void setNumberOfPdus(byte pNumberOfPdus)
{ _numberOfPdus = pNumberOfPdus;
}

[XmlElement(Type= typeof(byte), ElementName="numberOfPdus")]
public byte NumberOfPdus
{
     get
{
          return _numberOfPdus;
}
     set
{
          _numberOfPdus = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfMinesInThisPdu method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfMinesInThisPdu(byte pNumberOfMinesInThisPdu)
{ _numberOfMinesInThisPdu = pNumberOfMinesInThisPdu;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfMinesInThisPdu method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfMinesInThisPdu")]
public byte NumberOfMinesInThisPdu
{
     get
     {
          return _numberOfMinesInThisPdu;
     }
     set
     {
          _numberOfMinesInThisPdu = value;
     }
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfSensorTypes(byte pNumberOfSensorTypes)
{ _numberOfSensorTypes = pNumberOfSensorTypes;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfSensorTypes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfSensorTypes")]
public byte NumberOfSensorTypes
{
     get
     {
          return _numberOfSensorTypes;
     }
     set
     {
          _numberOfSensorTypes = value;
     }
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad2(byte pPad2)
{ _pad2 = pPad2;
}

[XmlElement(Type= typeof(byte), ElementName="pad2")]
public byte Pad2
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
   ///32 boolean fields
   ///</summary>
public void setDataFilter(uint pDataFilter)
{ _dataFilter = pDataFilter;
}

[XmlElement(Type= typeof(uint), ElementName="dataFilter")]
public uint DataFilter
{
     get
{
          return _dataFilter;
}
     set
{
          _dataFilter = value;
}
}

   ///<summary>
   ///Mine type
   ///</summary>
public void setMineType(EntityType pMineType)
{ _mineType = pMineType;
}

   ///<summary>
   ///Mine type
   ///</summary>
public EntityType getMineType()
{ return _mineType; 
}

   ///<summary>
   ///Mine type
   ///</summary>
[XmlElement(Type= typeof(EntityType), ElementName="mineType")]
public EntityType MineType
{
     get
{
          return _mineType;
}
     set
{
          _mineType = value;
}
}

   ///<summary>
   ///Sensor types, each 16 bits long
   ///</summary>
public void setSensorTypes(List<TwoByteChunk> pSensorTypes)
{ _sensorTypes = pSensorTypes;
}

   ///<summary>
   ///Sensor types, each 16 bits long
   ///</summary>
public List<TwoByteChunk> getSensorTypes()
{ return _sensorTypes; }

   ///<summary>
   ///Sensor types, each 16 bits long
   ///</summary>
[XmlElement(ElementName = "sensorTypesList",Type = typeof(List<TwoByteChunk>))]
public List<TwoByteChunk> SensorTypes
{
     get
{
          return _sensorTypes;
}
     set
{
          _sensorTypes = value;
}
}

   ///<summary>
   ///Padding to get things 32-bit aligned. ^^^this is wrong--dyanmically sized padding needed
   ///</summary>
public void setPad3(byte pPad3)
{ _pad3 = pPad3;
}

[XmlElement(Type= typeof(byte), ElementName="pad3")]
public byte Pad3
{
     get
{
          return _pad3;
}
     set
{
          _pad3 = value;
}
}

   ///<summary>
   ///Mine locations
   ///</summary>
public void setMineLocation(List<Vector3Float> pMineLocation)
{ _mineLocation = pMineLocation;
}

   ///<summary>
   ///Mine locations
   ///</summary>
public List<Vector3Float> getMineLocation()
{ return _mineLocation; }

   ///<summary>
   ///Mine locations
   ///</summary>
[XmlElement(ElementName = "mineLocationList",Type = typeof(List<Vector3Float>))]
public List<Vector3Float> MineLocation
{
     get
{
          return _mineLocation;
}
     set
{
          _mineLocation = value;
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
       _minefieldID.marshal(dos);
       _requestingEntityID.marshal(dos);
       dos.writeUshort((ushort)_minefieldSequenceNumbeer);
       dos.writeByte((byte)_requestID);
       dos.writeByte((byte)_pduSequenceNumber);
       dos.writeByte((byte)_numberOfPdus);
       dos.writeByte((byte)_mineLocation.Count);
       dos.writeByte((byte)_sensorTypes.Count);
       dos.writeByte((byte)_pad2);
       dos.writeUint((uint)_dataFilter);
       _mineType.marshal(dos);

       for(int idx = 0; idx < _sensorTypes.Count; idx++)
       {
            TwoByteChunk aTwoByteChunk = (TwoByteChunk)_sensorTypes[idx];
            aTwoByteChunk.marshal(dos);
       } // end of list marshalling

       dos.writeByte((byte)_pad3);

       for(int idx = 0; idx < _mineLocation.Count; idx++)
       {
            Vector3Float aVector3Float = (Vector3Float)_mineLocation[idx];
            aVector3Float.marshal(dos);
       } // end of list marshalling

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
       _minefieldID.unmarshal(dis);
       _requestingEntityID.unmarshal(dis);
       _minefieldSequenceNumbeer = dis.readUshort();
       _requestID = dis.readByte();
       _pduSequenceNumber = dis.readByte();
       _numberOfPdus = dis.readByte();
       _numberOfMinesInThisPdu = dis.readByte();
       _numberOfSensorTypes = dis.readByte();
       _pad2 = dis.readByte();
       _dataFilter = dis.readUint();
       _mineType.unmarshal(dis);
        for(int idx = 0; idx < _numberOfSensorTypes; idx++)
        {
           TwoByteChunk anX = new TwoByteChunk();
            anX.unmarshal(dis);
            _sensorTypes.Add(anX);
        };

       _pad3 = dis.readByte();
        for(int idx = 0; idx < _numberOfMinesInThisPdu; idx++)
        {
           Vector3Float anX = new Vector3Float();
            anX.unmarshal(dis);
            _mineLocation.Add(anX);
        };

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
    sb.Append("<MinefieldDataPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<minefieldID>"  + System.Environment.NewLine);
       _minefieldID.reflection(sb);
    sb.Append("</minefieldID>"  + System.Environment.NewLine);
    sb.Append("<requestingEntityID>"  + System.Environment.NewLine);
       _requestingEntityID.reflection(sb);
    sb.Append("</requestingEntityID>"  + System.Environment.NewLine);
           sb.Append("<minefieldSequenceNumbeer type=\"ushort\">" + _minefieldSequenceNumbeer.ToString() + "</minefieldSequenceNumbeer> " + System.Environment.NewLine);
           sb.Append("<requestID type=\"byte\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
           sb.Append("<pduSequenceNumber type=\"byte\">" + _pduSequenceNumber.ToString() + "</pduSequenceNumber> " + System.Environment.NewLine);
           sb.Append("<numberOfPdus type=\"byte\">" + _numberOfPdus.ToString() + "</numberOfPdus> " + System.Environment.NewLine);
           sb.Append("<mineLocation type=\"byte\">" + _mineLocation.Count.ToString() + "</mineLocation> " + System.Environment.NewLine);
           sb.Append("<sensorTypes type=\"byte\">" + _sensorTypes.Count.ToString() + "</sensorTypes> " + System.Environment.NewLine);
           sb.Append("<pad2 type=\"byte\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
           sb.Append("<dataFilter type=\"uint\">" + _dataFilter.ToString() + "</dataFilter> " + System.Environment.NewLine);
    sb.Append("<mineType>"  + System.Environment.NewLine);
       _mineType.reflection(sb);
    sb.Append("</mineType>"  + System.Environment.NewLine);

       for(int idx = 0; idx < _sensorTypes.Count; idx++)
       {
           sb.Append("<sensorTypes"+ idx.ToString() + " type=\"TwoByteChunk\">" + System.Environment.NewLine);
            TwoByteChunk aTwoByteChunk = (TwoByteChunk)_sensorTypes[idx];
            aTwoByteChunk.reflection(sb);
           sb.Append("</sensorTypes"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

           sb.Append("<pad3 type=\"byte\">" + _pad3.ToString() + "</pad3> " + System.Environment.NewLine);

       for(int idx = 0; idx < _mineLocation.Count; idx++)
       {
           sb.Append("<mineLocation"+ idx.ToString() + " type=\"Vector3Float\">" + System.Environment.NewLine);
            Vector3Float aVector3Float = (Vector3Float)_mineLocation[idx];
            aVector3Float.reflection(sb);
           sb.Append("</mineLocation"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</MinefieldDataPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(MinefieldDataPdu a, MinefieldDataPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(MinefieldDataPdu a, MinefieldDataPdu b)
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
 public bool equals(MinefieldDataPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_minefieldID.Equals( rhs._minefieldID) )) ivarsEqual = false;
     if( ! (_requestingEntityID.Equals( rhs._requestingEntityID) )) ivarsEqual = false;
     if( ! (_minefieldSequenceNumbeer == rhs._minefieldSequenceNumbeer)) ivarsEqual = false;
     if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
     if( ! (_pduSequenceNumber == rhs._pduSequenceNumber)) ivarsEqual = false;
     if( ! (_numberOfPdus == rhs._numberOfPdus)) ivarsEqual = false;
     if( ! (_numberOfMinesInThisPdu == rhs._numberOfMinesInThisPdu)) ivarsEqual = false;
     if( ! (_numberOfSensorTypes == rhs._numberOfSensorTypes)) ivarsEqual = false;
     if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
     if( ! (_dataFilter == rhs._dataFilter)) ivarsEqual = false;
     if( ! (_mineType.Equals( rhs._mineType) )) ivarsEqual = false;

     for(int idx = 0; idx < _sensorTypes.Count; idx++)
     {
        TwoByteChunk x = (TwoByteChunk)_sensorTypes[idx];
        if( ! ( _sensorTypes[idx].Equals(rhs._sensorTypes[idx]))) ivarsEqual = false;
     }

     if( ! (_pad3 == rhs._pad3)) ivarsEqual = false;

     for(int idx = 0; idx < _mineLocation.Count; idx++)
     {
        Vector3Float x = (Vector3Float)_mineLocation[idx];
        if( ! ( _mineLocation[idx].Equals(rhs._mineLocation[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
