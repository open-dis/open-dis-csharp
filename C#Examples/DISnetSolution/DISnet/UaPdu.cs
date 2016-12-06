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
 * Section 5.3.7.3. Information about underwater acoustic emmissions. This requires manual cleanup.  The beam data records should ALL be a the finish, rather than attached to each emitter system. UNFINISHED
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
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(ShaftRPMs))]
[XmlInclude(typeof(ApaData))]
[XmlInclude(typeof(AcousticEmitterSystemData))]
public class UaPdu : DistributedEmissionsFamilyPdu
{
   /** ID of the entity that is the source of the emission */
   protected EntityID  _emittingEntityID = new EntityID(); 

   /** ID of event */
   protected EventID  _eventID = new EventID(); 

   /** This field shall be used to indicate whether the data in the UA PDU represent a state update or data that have changed since issuance of the last UA PDU */
   protected byte  _stateChangeIndicator;

   /** padding */
   protected byte  _pad;

   /** This field indicates which database record (or file) shall be used in the definition of passive signature (unintentional) emissions of the entity. The indicated database record (or  file) shall define all noise generated as a function of propulsion plant configurations and associated  auxiliaries. */
   protected ushort  _passiveParameterIndex;

   /** This field shall specify the entity propulsion plant configuration. This field is used to determine the passive signature characteristics of an entity. */
   protected byte  _propulsionPlantConfiguration;

   /**  This field shall represent the number of shafts on a platform */
   protected byte  _numberOfShafts;

   /** This field shall indicate the number of APAs described in the current UA PDU */
   protected byte  _numberOfAPAs;

   /** This field shall specify the number of UA emitter systems being described in the current UA PDU */
   protected byte  _numberOfUAEmitterSystems;

   /** shaft RPM values */
   protected List<ShaftRPMs> _shaftRPMs = new List<ShaftRPMs>(); 
   /** apaData */
   protected List<ApaData> _apaData = new List<ApaData>(); 
   protected List<AcousticEmitterSystemData> _emitterSystems = new List<AcousticEmitterSystemData>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.7.3. Information about underwater acoustic emmissions. This requires manual cleanup.  The beam data records should ALL be a the finish, rather than attached to each emitter system. UNFINISHED
   ///</summary>
 public UaPdu()
 {
    PduType = (byte)29;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _emittingEntityID.getMarshalledSize();  // _emittingEntityID
   marshalSize = marshalSize + _eventID.getMarshalledSize();  // _eventID
   marshalSize = marshalSize + 1;  // _stateChangeIndicator
   marshalSize = marshalSize + 1;  // _pad
   marshalSize = marshalSize + 2;  // _passiveParameterIndex
   marshalSize = marshalSize + 1;  // _propulsionPlantConfiguration
   marshalSize = marshalSize + 1;  // _numberOfShafts
   marshalSize = marshalSize + 1;  // _numberOfAPAs
   marshalSize = marshalSize + 1;  // _numberOfUAEmitterSystems
   for(int idx=0; idx < _shaftRPMs.Count; idx++)
   {
        ShaftRPMs listElement = (ShaftRPMs)_shaftRPMs[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   for(int idx=0; idx < _apaData.Count; idx++)
   {
        ApaData listElement = (ApaData)_apaData[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   for(int idx=0; idx < _emitterSystems.Count; idx++)
   {
        AcousticEmitterSystemData listElement = (AcousticEmitterSystemData)_emitterSystems[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///ID of the entity that is the source of the emission
   ///</summary>
public void setEmittingEntityID(EntityID pEmittingEntityID)
{ _emittingEntityID = pEmittingEntityID;
}

   ///<summary>
   ///ID of the entity that is the source of the emission
   ///</summary>
public EntityID getEmittingEntityID()
{ return _emittingEntityID; 
}

   ///<summary>
   ///ID of the entity that is the source of the emission
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="emittingEntityID")]
public EntityID EmittingEntityID
{
     get
{
          return _emittingEntityID;
}
     set
{
          _emittingEntityID = value;
}
}

   ///<summary>
   ///ID of event
   ///</summary>
public void setEventID(EventID pEventID)
{ _eventID = pEventID;
}

   ///<summary>
   ///ID of event
   ///</summary>
public EventID getEventID()
{ return _eventID; 
}

   ///<summary>
   ///ID of event
   ///</summary>
[XmlElement(Type= typeof(EventID), ElementName="eventID")]
public EventID EventID
{
     get
{
          return _eventID;
}
     set
{
          _eventID = value;
}
}

   ///<summary>
   ///This field shall be used to indicate whether the data in the UA PDU represent a state update or data that have changed since issuance of the last UA PDU
   ///</summary>
public void setStateChangeIndicator(byte pStateChangeIndicator)
{ _stateChangeIndicator = pStateChangeIndicator;
}

[XmlElement(Type= typeof(byte), ElementName="stateChangeIndicator")]
public byte StateChangeIndicator
{
     get
{
          return _stateChangeIndicator;
}
     set
{
          _stateChangeIndicator = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad(byte pPad)
{ _pad = pPad;
}

[XmlElement(Type= typeof(byte), ElementName="pad")]
public byte Pad
{
     get
{
          return _pad;
}
     set
{
          _pad = value;
}
}

   ///<summary>
   ///This field indicates which database record (or file) shall be used in the definition of passive signature (unintentional) emissions of the entity. The indicated database record (or  file) shall define all noise generated as a function of propulsion plant configurations and associated  auxiliaries.
   ///</summary>
public void setPassiveParameterIndex(ushort pPassiveParameterIndex)
{ _passiveParameterIndex = pPassiveParameterIndex;
}

[XmlElement(Type= typeof(ushort), ElementName="passiveParameterIndex")]
public ushort PassiveParameterIndex
{
     get
{
          return _passiveParameterIndex;
}
     set
{
          _passiveParameterIndex = value;
}
}

   ///<summary>
   ///This field shall specify the entity propulsion plant configuration. This field is used to determine the passive signature characteristics of an entity.
   ///</summary>
public void setPropulsionPlantConfiguration(byte pPropulsionPlantConfiguration)
{ _propulsionPlantConfiguration = pPropulsionPlantConfiguration;
}

[XmlElement(Type= typeof(byte), ElementName="propulsionPlantConfiguration")]
public byte PropulsionPlantConfiguration
{
     get
{
          return _propulsionPlantConfiguration;
}
     set
{
          _propulsionPlantConfiguration = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfShafts method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfShafts(byte pNumberOfShafts)
{ _numberOfShafts = pNumberOfShafts;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfShafts method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfShafts")]
public byte NumberOfShafts
{
     get
     {
          return _numberOfShafts;
     }
     set
     {
          _numberOfShafts = value;
     }
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfAPAs method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfAPAs(byte pNumberOfAPAs)
{ _numberOfAPAs = pNumberOfAPAs;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfAPAs method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfAPAs")]
public byte NumberOfAPAs
{
     get
     {
          return _numberOfAPAs;
     }
     set
     {
          _numberOfAPAs = value;
     }
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfUAEmitterSystems method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfUAEmitterSystems(byte pNumberOfUAEmitterSystems)
{ _numberOfUAEmitterSystems = pNumberOfUAEmitterSystems;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfUAEmitterSystems method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfUAEmitterSystems")]
public byte NumberOfUAEmitterSystems
{
     get
     {
          return _numberOfUAEmitterSystems;
     }
     set
     {
          _numberOfUAEmitterSystems = value;
     }
}

   ///<summary>
   ///shaft RPM values
   ///</summary>
public void setShaftRPMs(List<ShaftRPMs> pShaftRPMs)
{ _shaftRPMs = pShaftRPMs;
}

   ///<summary>
   ///shaft RPM values
   ///</summary>
public List<ShaftRPMs> getShaftRPMs()
{ return _shaftRPMs; }

   ///<summary>
   ///shaft RPM values
   ///</summary>
[XmlElement(ElementName = "shaftRPMsList",Type = typeof(List<ShaftRPMs>))]
public List<ShaftRPMs> ShaftRPMs
{
     get
{
          return _shaftRPMs;
}
     set
{
          _shaftRPMs = value;
}
}

   ///<summary>
   ///apaData
   ///</summary>
public void setApaData(List<ApaData> pApaData)
{ _apaData = pApaData;
}

   ///<summary>
   ///apaData
   ///</summary>
public List<ApaData> getApaData()
{ return _apaData; }

   ///<summary>
   ///apaData
   ///</summary>
[XmlElement(ElementName = "apaDataList",Type = typeof(List<ApaData>))]
public List<ApaData> ApaData
{
     get
{
          return _apaData;
}
     set
{
          _apaData = value;
}
}

public void setEmitterSystems(List<AcousticEmitterSystemData> pEmitterSystems)
{ _emitterSystems = pEmitterSystems;
}

public List<AcousticEmitterSystemData> getEmitterSystems()
{ return _emitterSystems; }

[XmlElement(ElementName = "emitterSystemsList",Type = typeof(List<AcousticEmitterSystemData>))]
public List<AcousticEmitterSystemData> EmitterSystems
{
     get
{
          return _emitterSystems;
}
     set
{
          _emitterSystems = value;
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
       _emittingEntityID.marshal(dos);
       _eventID.marshal(dos);
       dos.writeByte((byte)_stateChangeIndicator);
       dos.writeByte((byte)_pad);
       dos.writeUshort((ushort)_passiveParameterIndex);
       dos.writeByte((byte)_propulsionPlantConfiguration);
       dos.writeByte((byte)_shaftRPMs.Count);
       dos.writeByte((byte)_apaData.Count);
       dos.writeByte((byte)_emitterSystems.Count);

       for(int idx = 0; idx < _shaftRPMs.Count; idx++)
       {
            ShaftRPMs aShaftRPMs = (ShaftRPMs)_shaftRPMs[idx];
            aShaftRPMs.marshal(dos);
       } // end of list marshalling


       for(int idx = 0; idx < _apaData.Count; idx++)
       {
            ApaData aApaData = (ApaData)_apaData[idx];
            aApaData.marshal(dos);
       } // end of list marshalling


       for(int idx = 0; idx < _emitterSystems.Count; idx++)
       {
            AcousticEmitterSystemData aAcousticEmitterSystemData = (AcousticEmitterSystemData)_emitterSystems[idx];
            aAcousticEmitterSystemData.marshal(dos);
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
       _emittingEntityID.unmarshal(dis);
       _eventID.unmarshal(dis);
       _stateChangeIndicator = dis.readByte();
       _pad = dis.readByte();
       _passiveParameterIndex = dis.readUshort();
       _propulsionPlantConfiguration = dis.readByte();
       _numberOfShafts = dis.readByte();
       _numberOfAPAs = dis.readByte();
       _numberOfUAEmitterSystems = dis.readByte();
        for(int idx = 0; idx < _numberOfShafts; idx++)
        {
           ShaftRPMs anX = new ShaftRPMs();
            anX.unmarshal(dis);
            _shaftRPMs.Add(anX);
        };

        for(int idx = 0; idx < _numberOfAPAs; idx++)
        {
           ApaData anX = new ApaData();
            anX.unmarshal(dis);
            _apaData.Add(anX);
        };

        for(int idx = 0; idx < _numberOfUAEmitterSystems; idx++)
        {
           AcousticEmitterSystemData anX = new AcousticEmitterSystemData();
            anX.unmarshal(dis);
            _emitterSystems.Add(anX);
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
    sb.Append("<UaPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<emittingEntityID>"  + System.Environment.NewLine);
       _emittingEntityID.reflection(sb);
    sb.Append("</emittingEntityID>"  + System.Environment.NewLine);
    sb.Append("<eventID>"  + System.Environment.NewLine);
       _eventID.reflection(sb);
    sb.Append("</eventID>"  + System.Environment.NewLine);
           sb.Append("<stateChangeIndicator type=\"byte\">" + _stateChangeIndicator.ToString() + "</stateChangeIndicator> " + System.Environment.NewLine);
           sb.Append("<pad type=\"byte\">" + _pad.ToString() + "</pad> " + System.Environment.NewLine);
           sb.Append("<passiveParameterIndex type=\"ushort\">" + _passiveParameterIndex.ToString() + "</passiveParameterIndex> " + System.Environment.NewLine);
           sb.Append("<propulsionPlantConfiguration type=\"byte\">" + _propulsionPlantConfiguration.ToString() + "</propulsionPlantConfiguration> " + System.Environment.NewLine);
           sb.Append("<shaftRPMs type=\"byte\">" + _shaftRPMs.Count.ToString() + "</shaftRPMs> " + System.Environment.NewLine);
           sb.Append("<apaData type=\"byte\">" + _apaData.Count.ToString() + "</apaData> " + System.Environment.NewLine);
           sb.Append("<emitterSystems type=\"byte\">" + _emitterSystems.Count.ToString() + "</emitterSystems> " + System.Environment.NewLine);

       for(int idx = 0; idx < _shaftRPMs.Count; idx++)
       {
           sb.Append("<shaftRPMs"+ idx.ToString() + " type=\"ShaftRPMs\">" + System.Environment.NewLine);
            ShaftRPMs aShaftRPMs = (ShaftRPMs)_shaftRPMs[idx];
            aShaftRPMs.reflection(sb);
           sb.Append("</shaftRPMs"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling


       for(int idx = 0; idx < _apaData.Count; idx++)
       {
           sb.Append("<apaData"+ idx.ToString() + " type=\"ApaData\">" + System.Environment.NewLine);
            ApaData aApaData = (ApaData)_apaData[idx];
            aApaData.reflection(sb);
           sb.Append("</apaData"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling


       for(int idx = 0; idx < _emitterSystems.Count; idx++)
       {
           sb.Append("<emitterSystems"+ idx.ToString() + " type=\"AcousticEmitterSystemData\">" + System.Environment.NewLine);
            AcousticEmitterSystemData aAcousticEmitterSystemData = (AcousticEmitterSystemData)_emitterSystems[idx];
            aAcousticEmitterSystemData.reflection(sb);
           sb.Append("</emitterSystems"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</UaPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(UaPdu a, UaPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(UaPdu a, UaPdu b)
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
 public bool equals(UaPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_emittingEntityID.Equals( rhs._emittingEntityID) )) ivarsEqual = false;
     if( ! (_eventID.Equals( rhs._eventID) )) ivarsEqual = false;
     if( ! (_stateChangeIndicator == rhs._stateChangeIndicator)) ivarsEqual = false;
     if( ! (_pad == rhs._pad)) ivarsEqual = false;
     if( ! (_passiveParameterIndex == rhs._passiveParameterIndex)) ivarsEqual = false;
     if( ! (_propulsionPlantConfiguration == rhs._propulsionPlantConfiguration)) ivarsEqual = false;
     if( ! (_numberOfShafts == rhs._numberOfShafts)) ivarsEqual = false;
     if( ! (_numberOfAPAs == rhs._numberOfAPAs)) ivarsEqual = false;
     if( ! (_numberOfUAEmitterSystems == rhs._numberOfUAEmitterSystems)) ivarsEqual = false;

     for(int idx = 0; idx < _shaftRPMs.Count; idx++)
     {
        ShaftRPMs x = (ShaftRPMs)_shaftRPMs[idx];
        if( ! ( _shaftRPMs[idx].Equals(rhs._shaftRPMs[idx]))) ivarsEqual = false;
     }


     for(int idx = 0; idx < _apaData.Count; idx++)
     {
        ApaData x = (ApaData)_apaData[idx];
        if( ! ( _apaData[idx].Equals(rhs._apaData[idx]))) ivarsEqual = false;
     }


     for(int idx = 0; idx < _emitterSystems.Count; idx++)
     {
        AcousticEmitterSystemData x = (AcousticEmitterSystemData)_emitterSystems[idx];
        if( ! ( _emitterSystems[idx].Equals(rhs._emitterSystems[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
