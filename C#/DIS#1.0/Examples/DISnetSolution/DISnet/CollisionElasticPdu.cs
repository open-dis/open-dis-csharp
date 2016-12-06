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
 * 5.3.3.3. Information about elastic collisions in a DIS exercise shall be communicated using a Collision-Elastic PDU. COMPLETE
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
public class CollisionElasticPdu : EntityInformationFamilyPdu
{
   /** ID of the entity that issued the collision PDU */
   protected EntityID  _issuingEntityID = new EntityID(); 

   /** ID of entity that has collided with the issuing entity ID */
   protected EntityID  _collidingEntityID = new EntityID(); 

   /** ID of event */
   protected EventID  _collisionEventID = new EventID(); 

   /** some padding */
   protected short  _pad = 0;

   /** velocity at collision */
   protected Vector3Float  _contactVelocity = new Vector3Float(); 

   /** mass of issuing entity */
   protected float  _mass;

   /** Location with respect to entity the issuing entity collided with */
   protected Vector3Float  _location = new Vector3Float(); 

   /** tensor values */
   protected float  _collisionResultXX;

   /** tensor values */
   protected float  _collisionResultXY;

   /** tensor values */
   protected float  _collisionResultXZ;

   /** tensor values */
   protected float  _collisionResultYY;

   /** tensor values */
   protected float  _collisionResultYZ;

   /** tensor values */
   protected float  _collisionResultZZ;

   /** This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates. */
   protected Vector3Float  _unitSurfaceNormal = new Vector3Float(); 

   /** This field shall represent the degree to which energy is conserved in a collision */
   protected float  _coefficientOfRestitution;


/** Constructor */
   ///<summary>
   ///5.3.3.3. Information about elastic collisions in a DIS exercise shall be communicated using a Collision-Elastic PDU. COMPLETE
   ///</summary>
 public CollisionElasticPdu()
 {
    PduType = (byte)66;
    ProtocolFamily = (byte)1;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _issuingEntityID.getMarshalledSize();  // _issuingEntityID
   marshalSize = marshalSize + _collidingEntityID.getMarshalledSize();  // _collidingEntityID
   marshalSize = marshalSize + _collisionEventID.getMarshalledSize();  // _collisionEventID
   marshalSize = marshalSize + 2;  // _pad
   marshalSize = marshalSize + _contactVelocity.getMarshalledSize();  // _contactVelocity
   marshalSize = marshalSize + 4;  // _mass
   marshalSize = marshalSize + _location.getMarshalledSize();  // _location
   marshalSize = marshalSize + 4;  // _collisionResultXX
   marshalSize = marshalSize + 4;  // _collisionResultXY
   marshalSize = marshalSize + 4;  // _collisionResultXZ
   marshalSize = marshalSize + 4;  // _collisionResultYY
   marshalSize = marshalSize + 4;  // _collisionResultYZ
   marshalSize = marshalSize + 4;  // _collisionResultZZ
   marshalSize = marshalSize + _unitSurfaceNormal.getMarshalledSize();  // _unitSurfaceNormal
   marshalSize = marshalSize + 4;  // _coefficientOfRestitution

   return marshalSize;
}


   ///<summary>
   ///ID of the entity that issued the collision PDU
   ///</summary>
public void setIssuingEntityID(EntityID pIssuingEntityID)
{ _issuingEntityID = pIssuingEntityID;
}

   ///<summary>
   ///ID of the entity that issued the collision PDU
   ///</summary>
public EntityID getIssuingEntityID()
{ return _issuingEntityID; 
}

   ///<summary>
   ///ID of the entity that issued the collision PDU
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="issuingEntityID")]
public EntityID IssuingEntityID
{
     get
{
          return _issuingEntityID;
}
     set
{
          _issuingEntityID = value;
}
}

   ///<summary>
   ///ID of entity that has collided with the issuing entity ID
   ///</summary>
public void setCollidingEntityID(EntityID pCollidingEntityID)
{ _collidingEntityID = pCollidingEntityID;
}

   ///<summary>
   ///ID of entity that has collided with the issuing entity ID
   ///</summary>
public EntityID getCollidingEntityID()
{ return _collidingEntityID; 
}

   ///<summary>
   ///ID of entity that has collided with the issuing entity ID
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="collidingEntityID")]
public EntityID CollidingEntityID
{
     get
{
          return _collidingEntityID;
}
     set
{
          _collidingEntityID = value;
}
}

   ///<summary>
   ///ID of event
   ///</summary>
public void setCollisionEventID(EventID pCollisionEventID)
{ _collisionEventID = pCollisionEventID;
}

   ///<summary>
   ///ID of event
   ///</summary>
public EventID getCollisionEventID()
{ return _collisionEventID; 
}

   ///<summary>
   ///ID of event
   ///</summary>
[XmlElement(Type= typeof(EventID), ElementName="collisionEventID")]
public EventID CollisionEventID
{
     get
{
          return _collisionEventID;
}
     set
{
          _collisionEventID = value;
}
}

   ///<summary>
   ///some padding
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

   ///<summary>
   ///velocity at collision
   ///</summary>
public void setContactVelocity(Vector3Float pContactVelocity)
{ _contactVelocity = pContactVelocity;
}

   ///<summary>
   ///velocity at collision
   ///</summary>
public Vector3Float getContactVelocity()
{ return _contactVelocity; 
}

   ///<summary>
   ///velocity at collision
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="contactVelocity")]
public Vector3Float ContactVelocity
{
     get
{
          return _contactVelocity;
}
     set
{
          _contactVelocity = value;
}
}

   ///<summary>
   ///mass of issuing entity
   ///</summary>
public void setMass(float pMass)
{ _mass = pMass;
}

[XmlElement(Type= typeof(float), ElementName="mass")]
public float Mass
{
     get
{
          return _mass;
}
     set
{
          _mass = value;
}
}

   ///<summary>
   ///Location with respect to entity the issuing entity collided with
   ///</summary>
public void setLocation(Vector3Float pLocation)
{ _location = pLocation;
}

   ///<summary>
   ///Location with respect to entity the issuing entity collided with
   ///</summary>
public Vector3Float getLocation()
{ return _location; 
}

   ///<summary>
   ///Location with respect to entity the issuing entity collided with
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="location")]
public Vector3Float Location
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
   ///tensor values
   ///</summary>
public void setCollisionResultXX(float pCollisionResultXX)
{ _collisionResultXX = pCollisionResultXX;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultXX")]
public float CollisionResultXX
{
     get
{
          return _collisionResultXX;
}
     set
{
          _collisionResultXX = value;
}
}

   ///<summary>
   ///tensor values
   ///</summary>
public void setCollisionResultXY(float pCollisionResultXY)
{ _collisionResultXY = pCollisionResultXY;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultXY")]
public float CollisionResultXY
{
     get
{
          return _collisionResultXY;
}
     set
{
          _collisionResultXY = value;
}
}

   ///<summary>
   ///tensor values
   ///</summary>
public void setCollisionResultXZ(float pCollisionResultXZ)
{ _collisionResultXZ = pCollisionResultXZ;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultXZ")]
public float CollisionResultXZ
{
     get
{
          return _collisionResultXZ;
}
     set
{
          _collisionResultXZ = value;
}
}

   ///<summary>
   ///tensor values
   ///</summary>
public void setCollisionResultYY(float pCollisionResultYY)
{ _collisionResultYY = pCollisionResultYY;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultYY")]
public float CollisionResultYY
{
     get
{
          return _collisionResultYY;
}
     set
{
          _collisionResultYY = value;
}
}

   ///<summary>
   ///tensor values
   ///</summary>
public void setCollisionResultYZ(float pCollisionResultYZ)
{ _collisionResultYZ = pCollisionResultYZ;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultYZ")]
public float CollisionResultYZ
{
     get
{
          return _collisionResultYZ;
}
     set
{
          _collisionResultYZ = value;
}
}

   ///<summary>
   ///tensor values
   ///</summary>
public void setCollisionResultZZ(float pCollisionResultZZ)
{ _collisionResultZZ = pCollisionResultZZ;
}

[XmlElement(Type= typeof(float), ElementName="collisionResultZZ")]
public float CollisionResultZZ
{
     get
{
          return _collisionResultZZ;
}
     set
{
          _collisionResultZZ = value;
}
}

   ///<summary>
   ///This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates.
   ///</summary>
public void setUnitSurfaceNormal(Vector3Float pUnitSurfaceNormal)
{ _unitSurfaceNormal = pUnitSurfaceNormal;
}

   ///<summary>
   ///This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates.
   ///</summary>
public Vector3Float getUnitSurfaceNormal()
{ return _unitSurfaceNormal; 
}

   ///<summary>
   ///This record shall represent the normal vector to the surface at the point of collision detection. The surface normal shall be represented in world coordinates.
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="unitSurfaceNormal")]
public Vector3Float UnitSurfaceNormal
{
     get
{
          return _unitSurfaceNormal;
}
     set
{
          _unitSurfaceNormal = value;
}
}

   ///<summary>
   ///This field shall represent the degree to which energy is conserved in a collision
   ///</summary>
public void setCoefficientOfRestitution(float pCoefficientOfRestitution)
{ _coefficientOfRestitution = pCoefficientOfRestitution;
}

[XmlElement(Type= typeof(float), ElementName="coefficientOfRestitution")]
public float CoefficientOfRestitution
{
     get
{
          return _coefficientOfRestitution;
}
     set
{
          _coefficientOfRestitution = value;
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
       _issuingEntityID.marshal(dos);
       _collidingEntityID.marshal(dos);
       _collisionEventID.marshal(dos);
       dos.writeShort((short)_pad);
       _contactVelocity.marshal(dos);
       dos.writeFloat((float)_mass);
       _location.marshal(dos);
       dos.writeFloat((float)_collisionResultXX);
       dos.writeFloat((float)_collisionResultXY);
       dos.writeFloat((float)_collisionResultXZ);
       dos.writeFloat((float)_collisionResultYY);
       dos.writeFloat((float)_collisionResultYZ);
       dos.writeFloat((float)_collisionResultZZ);
       _unitSurfaceNormal.marshal(dos);
       dos.writeFloat((float)_coefficientOfRestitution);
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
       _issuingEntityID.unmarshal(dis);
       _collidingEntityID.unmarshal(dis);
       _collisionEventID.unmarshal(dis);
       _pad = dis.readShort();
       _contactVelocity.unmarshal(dis);
       _mass = dis.readFloat();
       _location.unmarshal(dis);
       _collisionResultXX = dis.readFloat();
       _collisionResultXY = dis.readFloat();
       _collisionResultXZ = dis.readFloat();
       _collisionResultYY = dis.readFloat();
       _collisionResultYZ = dis.readFloat();
       _collisionResultZZ = dis.readFloat();
       _unitSurfaceNormal.unmarshal(dis);
       _coefficientOfRestitution = dis.readFloat();
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
    sb.Append("<CollisionElasticPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<issuingEntityID>"  + System.Environment.NewLine);
       _issuingEntityID.reflection(sb);
    sb.Append("</issuingEntityID>"  + System.Environment.NewLine);
    sb.Append("<collidingEntityID>"  + System.Environment.NewLine);
       _collidingEntityID.reflection(sb);
    sb.Append("</collidingEntityID>"  + System.Environment.NewLine);
    sb.Append("<collisionEventID>"  + System.Environment.NewLine);
       _collisionEventID.reflection(sb);
    sb.Append("</collisionEventID>"  + System.Environment.NewLine);
           sb.Append("<pad type=\"short\">" + _pad.ToString() + "</pad> " + System.Environment.NewLine);
    sb.Append("<contactVelocity>"  + System.Environment.NewLine);
       _contactVelocity.reflection(sb);
    sb.Append("</contactVelocity>"  + System.Environment.NewLine);
           sb.Append("<mass type=\"float\">" + _mass.ToString() + "</mass> " + System.Environment.NewLine);
    sb.Append("<location>"  + System.Environment.NewLine);
       _location.reflection(sb);
    sb.Append("</location>"  + System.Environment.NewLine);
           sb.Append("<collisionResultXX type=\"float\">" + _collisionResultXX.ToString() + "</collisionResultXX> " + System.Environment.NewLine);
           sb.Append("<collisionResultXY type=\"float\">" + _collisionResultXY.ToString() + "</collisionResultXY> " + System.Environment.NewLine);
           sb.Append("<collisionResultXZ type=\"float\">" + _collisionResultXZ.ToString() + "</collisionResultXZ> " + System.Environment.NewLine);
           sb.Append("<collisionResultYY type=\"float\">" + _collisionResultYY.ToString() + "</collisionResultYY> " + System.Environment.NewLine);
           sb.Append("<collisionResultYZ type=\"float\">" + _collisionResultYZ.ToString() + "</collisionResultYZ> " + System.Environment.NewLine);
           sb.Append("<collisionResultZZ type=\"float\">" + _collisionResultZZ.ToString() + "</collisionResultZZ> " + System.Environment.NewLine);
    sb.Append("<unitSurfaceNormal>"  + System.Environment.NewLine);
       _unitSurfaceNormal.reflection(sb);
    sb.Append("</unitSurfaceNormal>"  + System.Environment.NewLine);
           sb.Append("<coefficientOfRestitution type=\"float\">" + _coefficientOfRestitution.ToString() + "</coefficientOfRestitution> " + System.Environment.NewLine);
    sb.Append("</CollisionElasticPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(CollisionElasticPdu a, CollisionElasticPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(CollisionElasticPdu a, CollisionElasticPdu b)
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
 public bool equals(CollisionElasticPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_issuingEntityID.Equals( rhs._issuingEntityID) )) ivarsEqual = false;
     if( ! (_collidingEntityID.Equals( rhs._collidingEntityID) )) ivarsEqual = false;
     if( ! (_collisionEventID.Equals( rhs._collisionEventID) )) ivarsEqual = false;
     if( ! (_pad == rhs._pad)) ivarsEqual = false;
     if( ! (_contactVelocity.Equals( rhs._contactVelocity) )) ivarsEqual = false;
     if( ! (_mass == rhs._mass)) ivarsEqual = false;
     if( ! (_location.Equals( rhs._location) )) ivarsEqual = false;
     if( ! (_collisionResultXX == rhs._collisionResultXX)) ivarsEqual = false;
     if( ! (_collisionResultXY == rhs._collisionResultXY)) ivarsEqual = false;
     if( ! (_collisionResultXZ == rhs._collisionResultXZ)) ivarsEqual = false;
     if( ! (_collisionResultYY == rhs._collisionResultYY)) ivarsEqual = false;
     if( ! (_collisionResultYZ == rhs._collisionResultYZ)) ivarsEqual = false;
     if( ! (_collisionResultZZ == rhs._collisionResultZZ)) ivarsEqual = false;
     if( ! (_unitSurfaceNormal.Equals( rhs._unitSurfaceNormal) )) ivarsEqual = false;
     if( ! (_coefficientOfRestitution == rhs._coefficientOfRestitution)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
