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
 * Section 5.3.3.1. Represents the postion and state of one entity in the world. COMPLETE
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
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(DeadReckoningParameter))]
[XmlInclude(typeof(Marking))]
[XmlInclude(typeof(ArticulationParameter))]
public class EntityStatePdu : EntityInformationFamilyPdu
{
   /** Unique ID for an entity that is tied to this state information */
   protected EntityID  _entityID = new EntityID(); 

   /** What force this entity is affiliated with, eg red, blue, neutral, etc */
   protected byte  _forceId;

   /** How many articulation parameters are in the variable length list */
   protected byte  _numberOfArticulationParameters;

   /** Describes the type of entity in the world */
   protected EntityType  _entityType = new EntityType(); 

   protected EntityType  _alternativeEntityType = new EntityType(); 

   /** Describes the speed of the entity in the world */
   protected Vector3Float  _entityLinearVelocity = new Vector3Float(); 

   /** describes the location of the entity in the world */
   protected Vector3Double  _entityLocation = new Vector3Double(); 

   /** describes the orientation of the entity, in euler angles */
   protected Orientation  _entityOrientation = new Orientation(); 

   /** a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc. */
   protected uint  _entityAppearance;

   /** parameters used for dead reckoning */
   protected DeadReckoningParameter  _deadReckoningParameters = new DeadReckoningParameter(); 

   /** characters that can be used for debugging, or to draw unique strings on the side of entities in the world */
   protected Marking  _marking = new Marking(); 

   /** a series of bit flags */
   protected uint  _capabilities;

   /** variable length list of articulation parameters */
   protected List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.3.1. Represents the postion and state of one entity in the world. COMPLETE
   ///</summary>
 public EntityStatePdu()
 {
    PduType = (byte)1;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _entityID.getMarshalledSize();  // _entityID
   marshalSize = marshalSize + 1;  // _forceId
   marshalSize = marshalSize + 1;  // _numberOfArticulationParameters
   marshalSize = marshalSize + _entityType.getMarshalledSize();  // _entityType
   marshalSize = marshalSize + _alternativeEntityType.getMarshalledSize();  // _alternativeEntityType
   marshalSize = marshalSize + _entityLinearVelocity.getMarshalledSize();  // _entityLinearVelocity
   marshalSize = marshalSize + _entityLocation.getMarshalledSize();  // _entityLocation
   marshalSize = marshalSize + _entityOrientation.getMarshalledSize();  // _entityOrientation
   marshalSize = marshalSize + 4;  // _entityAppearance
   marshalSize = marshalSize + _deadReckoningParameters.getMarshalledSize();  // _deadReckoningParameters
   marshalSize = marshalSize + _marking.getMarshalledSize();  // _marking
   marshalSize = marshalSize + 4;  // _capabilities
   for(int idx=0; idx < _articulationParameters.Count; idx++)
   {
        ArticulationParameter listElement = (ArticulationParameter)_articulationParameters[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///Unique ID for an entity that is tied to this state information
   ///</summary>
public void setEntityID(EntityID pEntityID)
{ _entityID = pEntityID;
}

   ///<summary>
   ///Unique ID for an entity that is tied to this state information
   ///</summary>
public EntityID getEntityID()
{ return _entityID; 
}

   ///<summary>
   ///Unique ID for an entity that is tied to this state information
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="entityID")]
public EntityID EntityID
{
     get
{
          return _entityID;
}
     set
{
          _entityID = value;
}
}

   ///<summary>
   ///What force this entity is affiliated with, eg red, blue, neutral, etc
   ///</summary>
public void setForceId(byte pForceId)
{ _forceId = pForceId;
}

[XmlElement(Type= typeof(byte), ElementName="forceId")]
public byte ForceId
{
     get
{
          return _forceId;
}
     set
{
          _forceId = value;
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
   ///Describes the type of entity in the world
   ///</summary>
public void setEntityType(EntityType pEntityType)
{ _entityType = pEntityType;
}

   ///<summary>
   ///Describes the type of entity in the world
   ///</summary>
public EntityType getEntityType()
{ return _entityType; 
}

   ///<summary>
   ///Describes the type of entity in the world
   ///</summary>
[XmlElement(Type= typeof(EntityType), ElementName="entityType")]
public EntityType EntityType
{
     get
{
          return _entityType;
}
     set
{
          _entityType = value;
}
}

public void setAlternativeEntityType(EntityType pAlternativeEntityType)
{ _alternativeEntityType = pAlternativeEntityType;
}

public EntityType getAlternativeEntityType()
{ return _alternativeEntityType; 
}

[XmlElement(Type= typeof(EntityType), ElementName="alternativeEntityType")]
public EntityType AlternativeEntityType
{
     get
{
          return _alternativeEntityType;
}
     set
{
          _alternativeEntityType = value;
}
}

   ///<summary>
   ///Describes the speed of the entity in the world
   ///</summary>
public void setEntityLinearVelocity(Vector3Float pEntityLinearVelocity)
{ _entityLinearVelocity = pEntityLinearVelocity;
}

   ///<summary>
   ///Describes the speed of the entity in the world
   ///</summary>
public Vector3Float getEntityLinearVelocity()
{ return _entityLinearVelocity; 
}

   ///<summary>
   ///Describes the speed of the entity in the world
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="entityLinearVelocity")]
public Vector3Float EntityLinearVelocity
{
     get
{
          return _entityLinearVelocity;
}
     set
{
          _entityLinearVelocity = value;
}
}

   ///<summary>
   ///describes the location of the entity in the world
   ///</summary>
public void setEntityLocation(Vector3Double pEntityLocation)
{ _entityLocation = pEntityLocation;
}

   ///<summary>
   ///describes the location of the entity in the world
   ///</summary>
public Vector3Double getEntityLocation()
{ return _entityLocation; 
}

   ///<summary>
   ///describes the location of the entity in the world
   ///</summary>
[XmlElement(Type= typeof(Vector3Double), ElementName="entityLocation")]
public Vector3Double EntityLocation
{
     get
{
          return _entityLocation;
}
     set
{
          _entityLocation = value;
}
}

   ///<summary>
   ///describes the orientation of the entity, in euler angles
   ///</summary>
public void setEntityOrientation(Orientation pEntityOrientation)
{ _entityOrientation = pEntityOrientation;
}

   ///<summary>
   ///describes the orientation of the entity, in euler angles
   ///</summary>
public Orientation getEntityOrientation()
{ return _entityOrientation; 
}

   ///<summary>
   ///describes the orientation of the entity, in euler angles
   ///</summary>
[XmlElement(Type= typeof(Orientation), ElementName="entityOrientation")]
public Orientation EntityOrientation
{
     get
{
          return _entityOrientation;
}
     set
{
          _entityOrientation = value;
}
}

   ///<summary>
   ///a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
   ///</summary>
public void setEntityAppearance(uint pEntityAppearance)
{ _entityAppearance = pEntityAppearance;
}

[XmlElement(Type= typeof(uint), ElementName="entityAppearance")]
public uint EntityAppearance
{
     get
{
          return _entityAppearance;
}
     set
{
          _entityAppearance = value;
}
}

   ///<summary>
   ///parameters used for dead reckoning
   ///</summary>
public void setDeadReckoningParameters(DeadReckoningParameter pDeadReckoningParameters)
{ _deadReckoningParameters = pDeadReckoningParameters;
}

   ///<summary>
   ///parameters used for dead reckoning
   ///</summary>
public DeadReckoningParameter getDeadReckoningParameters()
{ return _deadReckoningParameters; 
}

   ///<summary>
   ///parameters used for dead reckoning
   ///</summary>
[XmlElement(Type= typeof(DeadReckoningParameter), ElementName="deadReckoningParameters")]
public DeadReckoningParameter DeadReckoningParameters
{
     get
{
          return _deadReckoningParameters;
}
     set
{
          _deadReckoningParameters = value;
}
}

   ///<summary>
   ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
   ///</summary>
public void setMarking(Marking pMarking)
{ _marking = pMarking;
}

   ///<summary>
   ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
   ///</summary>
public Marking getMarking()
{ return _marking; 
}

   ///<summary>
   ///characters that can be used for debugging, or to draw unique strings on the side of entities in the world
   ///</summary>
[XmlElement(Type= typeof(Marking), ElementName="marking")]
public Marking Marking
{
     get
{
          return _marking;
}
     set
{
          _marking = value;
}
}

   ///<summary>
   ///a series of bit flags
   ///</summary>
public void setCapabilities(uint pCapabilities)
{ _capabilities = pCapabilities;
}

[XmlElement(Type= typeof(uint), ElementName="capabilities")]
public uint Capabilities
{
     get
{
          return _capabilities;
}
     set
{
          _capabilities = value;
}
}

   ///<summary>
   ///variable length list of articulation parameters
   ///</summary>
public void setArticulationParameters(List<ArticulationParameter> pArticulationParameters)
{ _articulationParameters = pArticulationParameters;
}

   ///<summary>
   ///variable length list of articulation parameters
   ///</summary>
public List<ArticulationParameter> getArticulationParameters()
{ return _articulationParameters; }

   ///<summary>
   ///variable length list of articulation parameters
   ///</summary>
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
       _entityID.marshal(dos);
       dos.writeByte((byte)_forceId);
       dos.writeByte((byte)_articulationParameters.Count);
       _entityType.marshal(dos);
       _alternativeEntityType.marshal(dos);
       _entityLinearVelocity.marshal(dos);
       _entityLocation.marshal(dos);
       _entityOrientation.marshal(dos);
       dos.writeUint((uint)_entityAppearance);
       _deadReckoningParameters.marshal(dos);
       _marking.marshal(dos);
       dos.writeUint((uint)_capabilities);

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
       _entityID.unmarshal(dis);
       _forceId = dis.readByte();
       _numberOfArticulationParameters = dis.readByte();
       _entityType.unmarshal(dis);
       _alternativeEntityType.unmarshal(dis);
       _entityLinearVelocity.unmarshal(dis);
       _entityLocation.unmarshal(dis);
       _entityOrientation.unmarshal(dis);
       _entityAppearance = dis.readUint();
       _deadReckoningParameters.unmarshal(dis);
       _marking.unmarshal(dis);
       _capabilities = dis.readUint();
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
    sb.Append("<EntityStatePdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<entityID>"  + System.Environment.NewLine);
       _entityID.reflection(sb);
    sb.Append("</entityID>"  + System.Environment.NewLine);
           sb.Append("<forceId type=\"byte\">" + _forceId.ToString() + "</forceId> " + System.Environment.NewLine);
           sb.Append("<articulationParameters type=\"byte\">" + _articulationParameters.Count.ToString() + "</articulationParameters> " + System.Environment.NewLine);
    sb.Append("<entityType>"  + System.Environment.NewLine);
       _entityType.reflection(sb);
    sb.Append("</entityType>"  + System.Environment.NewLine);
    sb.Append("<alternativeEntityType>"  + System.Environment.NewLine);
       _alternativeEntityType.reflection(sb);
    sb.Append("</alternativeEntityType>"  + System.Environment.NewLine);
    sb.Append("<entityLinearVelocity>"  + System.Environment.NewLine);
       _entityLinearVelocity.reflection(sb);
    sb.Append("</entityLinearVelocity>"  + System.Environment.NewLine);
    sb.Append("<entityLocation>"  + System.Environment.NewLine);
       _entityLocation.reflection(sb);
    sb.Append("</entityLocation>"  + System.Environment.NewLine);
    sb.Append("<entityOrientation>"  + System.Environment.NewLine);
       _entityOrientation.reflection(sb);
    sb.Append("</entityOrientation>"  + System.Environment.NewLine);
           sb.Append("<entityAppearance type=\"uint\">" + _entityAppearance.ToString() + "</entityAppearance> " + System.Environment.NewLine);
    sb.Append("<deadReckoningParameters>"  + System.Environment.NewLine);
       _deadReckoningParameters.reflection(sb);
    sb.Append("</deadReckoningParameters>"  + System.Environment.NewLine);
    sb.Append("<marking>"  + System.Environment.NewLine);
       _marking.reflection(sb);
    sb.Append("</marking>"  + System.Environment.NewLine);
           sb.Append("<capabilities type=\"uint\">" + _capabilities.ToString() + "</capabilities> " + System.Environment.NewLine);

       for(int idx = 0; idx < _articulationParameters.Count; idx++)
       {
           sb.Append("<articulationParameters"+ idx.ToString() + " type=\"ArticulationParameter\">" + System.Environment.NewLine);
            ArticulationParameter aArticulationParameter = (ArticulationParameter)_articulationParameters[idx];
            aArticulationParameter.reflection(sb);
           sb.Append("</articulationParameters"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</EntityStatePdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(EntityStatePdu a, EntityStatePdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(EntityStatePdu a, EntityStatePdu b)
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
 public bool equals(EntityStatePdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_entityID.Equals( rhs._entityID) )) ivarsEqual = false;
     if( ! (_forceId == rhs._forceId)) ivarsEqual = false;
     if( ! (_numberOfArticulationParameters == rhs._numberOfArticulationParameters)) ivarsEqual = false;
     if( ! (_entityType.Equals( rhs._entityType) )) ivarsEqual = false;
     if( ! (_alternativeEntityType.Equals( rhs._alternativeEntityType) )) ivarsEqual = false;
     if( ! (_entityLinearVelocity.Equals( rhs._entityLinearVelocity) )) ivarsEqual = false;
     if( ! (_entityLocation.Equals( rhs._entityLocation) )) ivarsEqual = false;
     if( ! (_entityOrientation.Equals( rhs._entityOrientation) )) ivarsEqual = false;
     if( ! (_entityAppearance == rhs._entityAppearance)) ivarsEqual = false;
     if( ! (_deadReckoningParameters.Equals( rhs._deadReckoningParameters) )) ivarsEqual = false;
     if( ! (_marking.Equals( rhs._marking) )) ivarsEqual = false;
     if( ! (_capabilities == rhs._capabilities)) ivarsEqual = false;

     for(int idx = 0; idx < _articulationParameters.Count; idx++)
     {
        ArticulationParameter x = (ArticulationParameter)_articulationParameters[idx];
        if( ! ( _articulationParameters[idx].Equals(rhs._articulationParameters[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
