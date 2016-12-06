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
 * Section 5.3.8.1. Detailed information about a radio transmitter. This PDU requires manually         written code to complete, since the modulation parameters are of variable length. UNFINISHED
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
[XmlInclude(typeof(RadioEntityType))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(ModulationType))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Float))]
public class TransmitterPdu : RadioCommunicationsFamilyPdu
{
   /** linear accelleration of entity */
   protected RadioEntityType  _radioEntityType = new RadioEntityType(); 

   /** transmit state */
   protected byte  _transmitState;

   /** input source */
   protected byte  _inputSource;

   /** padding */
   protected ushort  _padding1;

   /** Location of antenna */
   protected Vector3Double  _antennaLocation = new Vector3Double(); 

   /** relative location of antenna */
   protected Vector3Float  _relativeAntennaLocation = new Vector3Float(); 

   /** antenna pattern type */
   protected ushort  _antennaPatternType;

   /** atenna pattern length */
   protected ushort  _antennaPatternCount;

   /** frequency */
   protected ulong  _frequency;

   /** transmit frequency Bandwidth */
   protected float  _transmitFrequencyBandwidth;

   /** transmission power */
   protected float  _power;

   /** modulation */
   protected ModulationType  _modulationType = new ModulationType(); 

   /** crypto system enumeration */
   protected ushort  _cryptoSystem;

   /** crypto system key identifer */
   protected ushort  _cryptoKeyId;

   /** how many modulation parameters we have */
   protected byte  _modulationParameterCount;

   /** padding2 */
   protected ushort  _padding2 = 0;

   /** padding3 */
   protected byte  _padding3 = 0;

   /** variable length list of modulation parameters */
   protected List<Vector3Float> _modulationParametersList = new List<Vector3Float>(); 
   /** variable length list of antenna pattern records */
   protected List<Vector3Float> _antennaPatternList = new List<Vector3Float>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.8.1. Detailed information about a radio transmitter. This PDU requires manually         written code to complete, since the modulation parameters are of variable length. UNFINISHED
   ///</summary>
 public TransmitterPdu()
 {
    PduType = (byte)25;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _radioEntityType.getMarshalledSize();  // _radioEntityType
   marshalSize = marshalSize + 1;  // _transmitState
   marshalSize = marshalSize + 1;  // _inputSource
   marshalSize = marshalSize + 2;  // _padding1
   marshalSize = marshalSize + _antennaLocation.getMarshalledSize();  // _antennaLocation
   marshalSize = marshalSize + _relativeAntennaLocation.getMarshalledSize();  // _relativeAntennaLocation
   marshalSize = marshalSize + 2;  // _antennaPatternType
   marshalSize = marshalSize + 2;  // _antennaPatternCount
   marshalSize = marshalSize + 8;  // _frequency
   marshalSize = marshalSize + 4;  // _transmitFrequencyBandwidth
   marshalSize = marshalSize + 4;  // _power
   marshalSize = marshalSize + _modulationType.getMarshalledSize();  // _modulationType
   marshalSize = marshalSize + 2;  // _cryptoSystem
   marshalSize = marshalSize + 2;  // _cryptoKeyId
   marshalSize = marshalSize + 1;  // _modulationParameterCount
   marshalSize = marshalSize + 2;  // _padding2
   marshalSize = marshalSize + 1;  // _padding3
   for(int idx=0; idx < _modulationParametersList.Count; idx++)
   {
        Vector3Float listElement = (Vector3Float)_modulationParametersList[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   for(int idx=0; idx < _antennaPatternList.Count; idx++)
   {
        Vector3Float listElement = (Vector3Float)_antennaPatternList[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///linear accelleration of entity
   ///</summary>
public void setRadioEntityType(RadioEntityType pRadioEntityType)
{ _radioEntityType = pRadioEntityType;
}

   ///<summary>
   ///linear accelleration of entity
   ///</summary>
public RadioEntityType getRadioEntityType()
{ return _radioEntityType; 
}

   ///<summary>
   ///linear accelleration of entity
   ///</summary>
[XmlElement(Type= typeof(RadioEntityType), ElementName="radioEntityType")]
public RadioEntityType RadioEntityType
{
     get
{
          return _radioEntityType;
}
     set
{
          _radioEntityType = value;
}
}

   ///<summary>
   ///transmit state
   ///</summary>
public void setTransmitState(byte pTransmitState)
{ _transmitState = pTransmitState;
}

[XmlElement(Type= typeof(byte), ElementName="transmitState")]
public byte TransmitState
{
     get
{
          return _transmitState;
}
     set
{
          _transmitState = value;
}
}

   ///<summary>
   ///input source
   ///</summary>
public void setInputSource(byte pInputSource)
{ _inputSource = pInputSource;
}

[XmlElement(Type= typeof(byte), ElementName="inputSource")]
public byte InputSource
{
     get
{
          return _inputSource;
}
     set
{
          _inputSource = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPadding1(ushort pPadding1)
{ _padding1 = pPadding1;
}

[XmlElement(Type= typeof(ushort), ElementName="padding1")]
public ushort Padding1
{
     get
{
          return _padding1;
}
     set
{
          _padding1 = value;
}
}

   ///<summary>
   ///Location of antenna
   ///</summary>
public void setAntennaLocation(Vector3Double pAntennaLocation)
{ _antennaLocation = pAntennaLocation;
}

   ///<summary>
   ///Location of antenna
   ///</summary>
public Vector3Double getAntennaLocation()
{ return _antennaLocation; 
}

   ///<summary>
   ///Location of antenna
   ///</summary>
[XmlElement(Type= typeof(Vector3Double), ElementName="antennaLocation")]
public Vector3Double AntennaLocation
{
     get
{
          return _antennaLocation;
}
     set
{
          _antennaLocation = value;
}
}

   ///<summary>
   ///relative location of antenna
   ///</summary>
public void setRelativeAntennaLocation(Vector3Float pRelativeAntennaLocation)
{ _relativeAntennaLocation = pRelativeAntennaLocation;
}

   ///<summary>
   ///relative location of antenna
   ///</summary>
public Vector3Float getRelativeAntennaLocation()
{ return _relativeAntennaLocation; 
}

   ///<summary>
   ///relative location of antenna
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="relativeAntennaLocation")]
public Vector3Float RelativeAntennaLocation
{
     get
{
          return _relativeAntennaLocation;
}
     set
{
          _relativeAntennaLocation = value;
}
}

   ///<summary>
   ///antenna pattern type
   ///</summary>
public void setAntennaPatternType(ushort pAntennaPatternType)
{ _antennaPatternType = pAntennaPatternType;
}

[XmlElement(Type= typeof(ushort), ElementName="antennaPatternType")]
public ushort AntennaPatternType
{
     get
{
          return _antennaPatternType;
}
     set
{
          _antennaPatternType = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getantennaPatternCount method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setAntennaPatternCount(ushort pAntennaPatternCount)
{ _antennaPatternCount = pAntennaPatternCount;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getantennaPatternCount method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(ushort), ElementName="antennaPatternCount")]
public ushort AntennaPatternCount
{
     get
     {
          return _antennaPatternCount;
     }
     set
     {
          _antennaPatternCount = value;
     }
}

   ///<summary>
   ///frequency
   ///</summary>
public void setFrequency(ulong pFrequency)
{ _frequency = pFrequency;
}

[XmlElement(Type= typeof(ulong), ElementName="frequency")]
public ulong Frequency
{
     get
{
          return _frequency;
}
     set
{
          _frequency = value;
}
}

   ///<summary>
   ///transmit frequency Bandwidth
   ///</summary>
public void setTransmitFrequencyBandwidth(float pTransmitFrequencyBandwidth)
{ _transmitFrequencyBandwidth = pTransmitFrequencyBandwidth;
}

[XmlElement(Type= typeof(float), ElementName="transmitFrequencyBandwidth")]
public float TransmitFrequencyBandwidth
{
     get
{
          return _transmitFrequencyBandwidth;
}
     set
{
          _transmitFrequencyBandwidth = value;
}
}

   ///<summary>
   ///transmission power
   ///</summary>
public void setPower(float pPower)
{ _power = pPower;
}

[XmlElement(Type= typeof(float), ElementName="power")]
public float Power
{
     get
{
          return _power;
}
     set
{
          _power = value;
}
}

   ///<summary>
   ///modulation
   ///</summary>
public void setModulationType(ModulationType pModulationType)
{ _modulationType = pModulationType;
}

   ///<summary>
   ///modulation
   ///</summary>
public ModulationType getModulationType()
{ return _modulationType; 
}

   ///<summary>
   ///modulation
   ///</summary>
[XmlElement(Type= typeof(ModulationType), ElementName="modulationType")]
public ModulationType ModulationType
{
     get
{
          return _modulationType;
}
     set
{
          _modulationType = value;
}
}

   ///<summary>
   ///crypto system enumeration
   ///</summary>
public void setCryptoSystem(ushort pCryptoSystem)
{ _cryptoSystem = pCryptoSystem;
}

[XmlElement(Type= typeof(ushort), ElementName="cryptoSystem")]
public ushort CryptoSystem
{
     get
{
          return _cryptoSystem;
}
     set
{
          _cryptoSystem = value;
}
}

   ///<summary>
   ///crypto system key identifer
   ///</summary>
public void setCryptoKeyId(ushort pCryptoKeyId)
{ _cryptoKeyId = pCryptoKeyId;
}

[XmlElement(Type= typeof(ushort), ElementName="cryptoKeyId")]
public ushort CryptoKeyId
{
     get
{
          return _cryptoKeyId;
}
     set
{
          _cryptoKeyId = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getmodulationParameterCount method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setModulationParameterCount(byte pModulationParameterCount)
{ _modulationParameterCount = pModulationParameterCount;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getmodulationParameterCount method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="modulationParameterCount")]
public byte ModulationParameterCount
{
     get
     {
          return _modulationParameterCount;
     }
     set
     {
          _modulationParameterCount = value;
     }
}

   ///<summary>
   ///padding2
   ///</summary>
public void setPadding2(ushort pPadding2)
{ _padding2 = pPadding2;
}

[XmlElement(Type= typeof(ushort), ElementName="padding2")]
public ushort Padding2
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
   ///padding3
   ///</summary>
public void setPadding3(byte pPadding3)
{ _padding3 = pPadding3;
}

[XmlElement(Type= typeof(byte), ElementName="padding3")]
public byte Padding3
{
     get
{
          return _padding3;
}
     set
{
          _padding3 = value;
}
}

   ///<summary>
   ///variable length list of modulation parameters
   ///</summary>
public void setModulationParametersList(List<Vector3Float> pModulationParametersList)
{ _modulationParametersList = pModulationParametersList;
}

   ///<summary>
   ///variable length list of modulation parameters
   ///</summary>
public List<Vector3Float> getModulationParametersList()
{ return _modulationParametersList; }

   ///<summary>
   ///variable length list of modulation parameters
   ///</summary>
[XmlElement(ElementName = "modulationParametersListList",Type = typeof(List<Vector3Float>))]
public List<Vector3Float> ModulationParametersList
{
     get
{
          return _modulationParametersList;
}
     set
{
          _modulationParametersList = value;
}
}

   ///<summary>
   ///variable length list of antenna pattern records
   ///</summary>
public void setAntennaPatternList(List<Vector3Float> pAntennaPatternList)
{ _antennaPatternList = pAntennaPatternList;
}

   ///<summary>
   ///variable length list of antenna pattern records
   ///</summary>
public List<Vector3Float> getAntennaPatternList()
{ return _antennaPatternList; }

   ///<summary>
   ///variable length list of antenna pattern records
   ///</summary>
[XmlElement(ElementName = "antennaPatternListList",Type = typeof(List<Vector3Float>))]
public List<Vector3Float> AntennaPatternList
{
     get
{
          return _antennaPatternList;
}
     set
{
          _antennaPatternList = value;
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
       _radioEntityType.marshal(dos);
       dos.writeByte((byte)_transmitState);
       dos.writeByte((byte)_inputSource);
       dos.writeUshort((ushort)_padding1);
       _antennaLocation.marshal(dos);
       _relativeAntennaLocation.marshal(dos);
       dos.writeUshort((ushort)_antennaPatternType);
       dos.writeUshort((ushort)_antennaPatternList.Count);
       dos.writeUlong((ulong)_frequency);
       dos.writeFloat((float)_transmitFrequencyBandwidth);
       dos.writeFloat((float)_power);
       _modulationType.marshal(dos);
       dos.writeUshort((ushort)_cryptoSystem);
       dos.writeUshort((ushort)_cryptoKeyId);
       dos.writeByte((byte)_modulationParametersList.Count);
       dos.writeUshort((ushort)_padding2);
       dos.writeByte((byte)_padding3);

       for(int idx = 0; idx < _modulationParametersList.Count; idx++)
       {
            Vector3Float aVector3Float = (Vector3Float)_modulationParametersList[idx];
            aVector3Float.marshal(dos);
       } // end of list marshalling


       for(int idx = 0; idx < _antennaPatternList.Count; idx++)
       {
            Vector3Float aVector3Float = (Vector3Float)_antennaPatternList[idx];
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
       _radioEntityType.unmarshal(dis);
       _transmitState = dis.readByte();
       _inputSource = dis.readByte();
       _padding1 = dis.readUshort();
       _antennaLocation.unmarshal(dis);
       _relativeAntennaLocation.unmarshal(dis);
       _antennaPatternType = dis.readUshort();
       _antennaPatternCount = dis.readUshort();
       _frequency = dis.readUlong();
       _transmitFrequencyBandwidth = dis.readFloat();
       _power = dis.readFloat();
       _modulationType.unmarshal(dis);
       _cryptoSystem = dis.readUshort();
       _cryptoKeyId = dis.readUshort();
       _modulationParameterCount = dis.readByte();
       _padding2 = dis.readUshort();
       _padding3 = dis.readByte();
        for(int idx = 0; idx < _modulationParameterCount; idx++)
        {
           Vector3Float anX = new Vector3Float();
            anX.unmarshal(dis);
            _modulationParametersList.Add(anX);
        };

        for(int idx = 0; idx < _antennaPatternCount; idx++)
        {
           Vector3Float anX = new Vector3Float();
            anX.unmarshal(dis);
            _antennaPatternList.Add(anX);
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
    sb.Append("<TransmitterPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<radioEntityType>"  + System.Environment.NewLine);
       _radioEntityType.reflection(sb);
    sb.Append("</radioEntityType>"  + System.Environment.NewLine);
           sb.Append("<transmitState type=\"byte\">" + _transmitState.ToString() + "</transmitState> " + System.Environment.NewLine);
           sb.Append("<inputSource type=\"byte\">" + _inputSource.ToString() + "</inputSource> " + System.Environment.NewLine);
           sb.Append("<padding1 type=\"ushort\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
    sb.Append("<antennaLocation>"  + System.Environment.NewLine);
       _antennaLocation.reflection(sb);
    sb.Append("</antennaLocation>"  + System.Environment.NewLine);
    sb.Append("<relativeAntennaLocation>"  + System.Environment.NewLine);
       _relativeAntennaLocation.reflection(sb);
    sb.Append("</relativeAntennaLocation>"  + System.Environment.NewLine);
           sb.Append("<antennaPatternType type=\"ushort\">" + _antennaPatternType.ToString() + "</antennaPatternType> " + System.Environment.NewLine);
           sb.Append("<antennaPatternList type=\"ushort\">" + _antennaPatternList.Count.ToString() + "</antennaPatternList> " + System.Environment.NewLine);
           sb.Append("<frequency type=\"ulong\">" + _frequency.ToString() + "</frequency> " + System.Environment.NewLine);
           sb.Append("<transmitFrequencyBandwidth type=\"float\">" + _transmitFrequencyBandwidth.ToString() + "</transmitFrequencyBandwidth> " + System.Environment.NewLine);
           sb.Append("<power type=\"float\">" + _power.ToString() + "</power> " + System.Environment.NewLine);
    sb.Append("<modulationType>"  + System.Environment.NewLine);
       _modulationType.reflection(sb);
    sb.Append("</modulationType>"  + System.Environment.NewLine);
           sb.Append("<cryptoSystem type=\"ushort\">" + _cryptoSystem.ToString() + "</cryptoSystem> " + System.Environment.NewLine);
           sb.Append("<cryptoKeyId type=\"ushort\">" + _cryptoKeyId.ToString() + "</cryptoKeyId> " + System.Environment.NewLine);
           sb.Append("<modulationParametersList type=\"byte\">" + _modulationParametersList.Count.ToString() + "</modulationParametersList> " + System.Environment.NewLine);
           sb.Append("<padding2 type=\"ushort\">" + _padding2.ToString() + "</padding2> " + System.Environment.NewLine);
           sb.Append("<padding3 type=\"byte\">" + _padding3.ToString() + "</padding3> " + System.Environment.NewLine);

       for(int idx = 0; idx < _modulationParametersList.Count; idx++)
       {
           sb.Append("<modulationParametersList"+ idx.ToString() + " type=\"Vector3Float\">" + System.Environment.NewLine);
            Vector3Float aVector3Float = (Vector3Float)_modulationParametersList[idx];
            aVector3Float.reflection(sb);
           sb.Append("</modulationParametersList"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling


       for(int idx = 0; idx < _antennaPatternList.Count; idx++)
       {
           sb.Append("<antennaPatternList"+ idx.ToString() + " type=\"Vector3Float\">" + System.Environment.NewLine);
            Vector3Float aVector3Float = (Vector3Float)_antennaPatternList[idx];
            aVector3Float.reflection(sb);
           sb.Append("</antennaPatternList"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</TransmitterPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(TransmitterPdu a, TransmitterPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(TransmitterPdu a, TransmitterPdu b)
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
 public bool equals(TransmitterPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_radioEntityType.Equals( rhs._radioEntityType) )) ivarsEqual = false;
     if( ! (_transmitState == rhs._transmitState)) ivarsEqual = false;
     if( ! (_inputSource == rhs._inputSource)) ivarsEqual = false;
     if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
     if( ! (_antennaLocation.Equals( rhs._antennaLocation) )) ivarsEqual = false;
     if( ! (_relativeAntennaLocation.Equals( rhs._relativeAntennaLocation) )) ivarsEqual = false;
     if( ! (_antennaPatternType == rhs._antennaPatternType)) ivarsEqual = false;
     if( ! (_antennaPatternCount == rhs._antennaPatternCount)) ivarsEqual = false;
     if( ! (_frequency == rhs._frequency)) ivarsEqual = false;
     if( ! (_transmitFrequencyBandwidth == rhs._transmitFrequencyBandwidth)) ivarsEqual = false;
     if( ! (_power == rhs._power)) ivarsEqual = false;
     if( ! (_modulationType.Equals( rhs._modulationType) )) ivarsEqual = false;
     if( ! (_cryptoSystem == rhs._cryptoSystem)) ivarsEqual = false;
     if( ! (_cryptoKeyId == rhs._cryptoKeyId)) ivarsEqual = false;
     if( ! (_modulationParameterCount == rhs._modulationParameterCount)) ivarsEqual = false;
     if( ! (_padding2 == rhs._padding2)) ivarsEqual = false;
     if( ! (_padding3 == rhs._padding3)) ivarsEqual = false;

     for(int idx = 0; idx < _modulationParametersList.Count; idx++)
     {
        Vector3Float x = (Vector3Float)_modulationParametersList[idx];
        if( ! ( _modulationParametersList[idx].Equals(rhs._modulationParametersList[idx]))) ivarsEqual = false;
     }


     for(int idx = 0; idx < _antennaPatternList.Count; idx++)
     {
        Vector3Float x = (Vector3Float)_antennaPatternList[idx];
        if( ! ( _antennaPatternList[idx].Equals(rhs._antennaPatternList[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
