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
 * Section 5.3.4.2. Information about stuff exploding. COMPLETE
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
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(BurstDescriptor))]
[XmlInclude(typeof(ArticulationParameter))]
public class DetonationPdu : WarfareFamilyPdu
{
   /** ID of muntion that was fired */
   protected EntityID  _munitionID = new EntityID(); 

   /** ID firing event */
   protected EventID  _eventID = new EventID(); 

   /** ID firing event */
   protected Vector3Float  _velocity = new Vector3Float(); 

   /** where the detonation is, in world coordinates */
   protected Vector3Double  _locationInWorldCoordinates = new Vector3Double(); 

   /** Describes munition used */
   protected BurstDescriptor  _burstDescriptor = new BurstDescriptor(); 

   /** location of the detonation or impact in the target entity's coordinate system. This information should be used for damage assessment. */
   protected Vector3Float  _locationInEntityCoordinates = new Vector3Float(); 

   /** result of the explosion */
   protected byte  _detonationResult;

   /** How many articulation parameters we have */
   protected byte  _numberOfArticulationParameters;

   /** padding */
   protected short  _pad = 0;

   protected List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.4.2. Information about stuff exploding. COMPLETE
   ///</summary>
 public DetonationPdu()
 {
    PduType = (byte)3;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _munitionID.getMarshalledSize();  // _munitionID
   marshalSize = marshalSize + _eventID.getMarshalledSize();  // _eventID
   marshalSize = marshalSize + _velocity.getMarshalledSize();  // _velocity
   marshalSize = marshalSize + _locationInWorldCoordinates.getMarshalledSize();  // _locationInWorldCoordinates
   marshalSize = marshalSize + _burstDescriptor.getMarshalledSize();  // _burstDescriptor
   marshalSize = marshalSize + _locationInEntityCoordinates.getMarshalledSize();  // _locationInEntityCoordinates
   marshalSize = marshalSize + 1;  // _detonationResult
   marshalSize = marshalSize + 1;  // _numberOfArticulationParameters
   marshalSize = marshalSize + 2;  // _pad
   for(int idx=0; idx < _articulationParameters.Count; idx++)
   {
        ArticulationParameter listElement = (ArticulationParameter)_articulationParameters[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///ID of muntion that was fired
   ///</summary>
public void setMunitionID(EntityID pMunitionID)
{ _munitionID = pMunitionID;
}

   ///<summary>
   ///ID of muntion that was fired
   ///</summary>
public EntityID getMunitionID()
{ return _munitionID; 
}

   ///<summary>
   ///ID of muntion that was fired
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="munitionID")]
public EntityID MunitionID
{
     get
{
          return _munitionID;
}
     set
{
          _munitionID = value;
}
}

   ///<summary>
   ///ID firing event
   ///</summary>
public void setEventID(EventID pEventID)
{ _eventID = pEventID;
}

   ///<summary>
   ///ID firing event
   ///</summary>
public EventID getEventID()
{ return _eventID; 
}

   ///<summary>
   ///ID firing event
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
   ///ID firing event
   ///</summary>
public void setVelocity(Vector3Float pVelocity)
{ _velocity = pVelocity;
}

   ///<summary>
   ///ID firing event
   ///</summary>
public Vector3Float getVelocity()
{ return _velocity; 
}

   ///<summary>
   ///ID firing event
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="velocity")]
public Vector3Float Velocity
{
     get
{
          return _velocity;
}
     set
{
          _velocity = value;
}
}

   ///<summary>
   ///where the detonation is, in world coordinates
   ///</summary>
public void setLocationInWorldCoordinates(Vector3Double pLocationInWorldCoordinates)
{ _locationInWorldCoordinates = pLocationInWorldCoordinates;
}

   ///<summary>
   ///where the detonation is, in world coordinates
   ///</summary>
public Vector3Double getLocationInWorldCoordinates()
{ return _locationInWorldCoordinates; 
}

   ///<summary>
   ///where the detonation is, in world coordinates
   ///</summary>
[XmlElement(Type= typeof(Vector3Double), ElementName="locationInWorldCoordinates")]
public Vector3Double LocationInWorldCoordinates
{
     get
{
          return _locationInWorldCoordinates;
}
     set
{
          _locationInWorldCoordinates = value;
}
}

   ///<summary>
   ///Describes munition used
   ///</summary>
public void setBurstDescriptor(BurstDescriptor pBurstDescriptor)
{ _burstDescriptor = pBurstDescriptor;
}

   ///<summary>
   ///Describes munition used
   ///</summary>
public BurstDescriptor getBurstDescriptor()
{ return _burstDescriptor; 
}

   ///<summary>
   ///Describes munition used
   ///</summary>
[XmlElement(Type= typeof(BurstDescriptor), ElementName="burstDescriptor")]
public BurstDescriptor BurstDescriptor
{
     get
{
          return _burstDescriptor;
}
     set
{
          _burstDescriptor = value;
}
}

   ///<summary>
   ///location of the detonation or impact in the target entity's coordinate system. This information should be used for damage assessment.
   ///</summary>
public void setLocationInEntityCoordinates(Vector3Float pLocationInEntityCoordinates)
{ _locationInEntityCoordinates = pLocationInEntityCoordinates;
}

   ///<summary>
   ///location of the detonation or impact in the target entity's coordinate system. This information should be used for damage assessment.
   ///</summary>
public Vector3Float getLocationInEntityCoordinates()
{ return _locationInEntityCoordinates; 
}

   ///<summary>
   ///location of the detonation or impact in the target entity's coordinate system. This information should be used for damage assessment.
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="locationInEntityCoordinates")]
public Vector3Float LocationInEntityCoordinates
{
     get
{
          return _locationInEntityCoordinates;
}
     set
{
          _locationInEntityCoordinates = value;
}
}

   ///<summary>
   ///result of the explosion
   ///</summary>
public void setDetonationResult(byte pDetonationResult)
{ _detonationResult = pDetonationResult;
}

[XmlElement(Type= typeof(byte), ElementName="detonationResult")]
public byte DetonationResult
{
     get
{
          return _detonationResult;
}
     set
{
          _detonationResult = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfArticulationParameters(byte pNumberOfArticulationParameters)
{ _numberOfArticulationParameters = pNumberOfArticulationParameters;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfArticulationParameters")]
public byte NumberOfArticulationParameters
{
     get
     {
          return _numberOfArticulationParameters;
     }
     set
     {
          _numberOfArticulationParameters = value;
     }
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad(short pPad)
{ _pad = pPad;
}

[XmlElement(Type= typeof(short), ElementName="pad")]
public short Pad
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

public void setArticulationParameters(List<ArticulationParameter> pArticulationParameters)
{ _articulationParameters = pArticulationParameters;
}

public List<ArticulationParameter> getArticulationParameters()
{ return _articulationParameters; }

[XmlElement(ElementName = "articulationParametersList",Type = typeof(List<ArticulationParameter>))]
public List<ArticulationParameter> ArticulationParameters
{
     get
{
          return _articulationParameters;
}
     set
{
          _articulationParameters = value;
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
       _munitionID.marshal(dos);
       _eventID.marshal(dos);
       _velocity.marshal(dos);
       _locationInWorldCoordinates.marshal(dos);
       _burstDescriptor.marshal(dos);
       _locationInEntityCoordinates.marshal(dos);
       dos.writeByte((byte)_detonationResult);
       dos.writeByte((byte)_articulationParameters.Count);
       dos.writeShort((short)_pad);

       for(int idx = 0; idx < _articulationParameters.Count; idx++)
       {
            ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
            aArticulationParameter.marshal(dos);
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
       _munitionID.unmarshal(dis);
       _eventID.unmarshal(dis);
       _velocity.unmarshal(dis);
       _locationInWorldCoordinates.unmarshal(dis);
       _burstDescriptor.unmarshal(dis);
       _locationInEntityCoordinates.unmarshal(dis);
       _detonationResult = dis.readByte();
       _numberOfArticulationParameters = dis.readByte();
       _pad = dis.readShort();
        for(int idx = 0; idx < _numberOfArticulationParameters; idx++)
        {
           ArticulationParameter anX = new ArticulationParameter();
            anX.unmarshal(dis);
            _articulationParameters.Add(anX);
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
    sb.Append("<DetonationPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<munitionID>"  + System.Environment.NewLine);
       _munitionID.reflection(sb);
    sb.Append("</munitionID>"  + System.Environment.NewLine);
    sb.Append("<eventID>"  + System.Environment.NewLine);
       _eventID.reflection(sb);
    sb.Append("</eventID>"  + System.Environment.NewLine);
    sb.Append("<velocity>"  + System.Environment.NewLine);
       _velocity.reflection(sb);
    sb.Append("</velocity>"  + System.Environment.NewLine);
    sb.Append("<locationInWorldCoordinates>"  + System.Environment.NewLine);
       _locationInWorldCoordinates.reflection(sb);
    sb.Append("</locationInWorldCoordinates>"  + System.Environment.NewLine);
    sb.Append("<burstDescriptor>"  + System.Environment.NewLine);
       _burstDescriptor.reflection(sb);
    sb.Append("</burstDescriptor>"  + System.Environment.NewLine);
    sb.Append("<locationInEntityCoordinates>"  + System.Environment.NewLine);
       _locationInEntityCoordinates.reflection(sb);
    sb.Append("</locationInEntityCoordinates>"  + System.Environment.NewLine);
           sb.Append("<detonationResult type=\"byte\">" + _detonationResult.ToString() + "</detonationResult> " + System.Environment.NewLine);
           sb.Append("<articulationParameters type=\"byte\">" + _articulationParameters.Count.ToString() + "</articulationParameters> " + System.Environment.NewLine);
           sb.Append("<pad type=\"short\">" + _pad.ToString() + "</pad> " + System.Environment.NewLine);

       for(int idx = 0; idx < _articulationParameters.Count; idx++)
       {
           sb.Append("<articulationParameters"+ idx.ToString() + " type=\"ArticulationParameter\">" + System.Environment.NewLine);
            ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
            aArticulationParameter.reflection(sb);
           sb.Append("</articulationParameters"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</DetonationPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(DetonationPdu a, DetonationPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(DetonationPdu a, DetonationPdu b)
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
 public bool equals(DetonationPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_munitionID.Equals( rhs._munitionID) )) ivarsEqual = false;
     if( ! (_eventID.Equals( rhs._eventID) )) ivarsEqual = false;
     if( ! (_velocity.Equals( rhs._velocity) )) ivarsEqual = false;
     if( ! (_locationInWorldCoordinates.Equals( rhs._locationInWorldCoordinates) )) ivarsEqual = false;
     if( ! (_burstDescriptor.Equals( rhs._burstDescriptor) )) ivarsEqual = false;
     if( ! (_locationInEntityCoordinates.Equals( rhs._locationInEntityCoordinates) )) ivarsEqual = false;
     if( ! (_detonationResult == rhs._detonationResult)) ivarsEqual = false;
     if( ! (_numberOfArticulationParameters == rhs._numberOfArticulationParameters)) ivarsEqual = false;
     if( ! (_pad == rhs._pad)) ivarsEqual = false;

     for(int idx = 0; idx < _articulationParameters.Count; idx++)
     {
        ArticulationParameter x = (ArticulationParameter)_articulationParameters[idx];
        if( ! ( _articulationParameters[idx].Equals(rhs._articulationParameters[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
