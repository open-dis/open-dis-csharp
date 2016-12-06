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
 * represents values used in dead reckoning algorithms
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
[XmlInclude(typeof(Vector3Float))]
public class DeadReckoningParameter : Object
{
   /** enumeration of what dead reckoning algorighm to use */
   protected byte  _deadReckoningAlgorithm;

   /** other parameters to use in the dead reckoning algorithm */
   protected byte[]  _otherParameters = new byte[15]; 

   /** Linear acceleration of the entity */
   protected Vector3Float  _entityLinearAcceleration = new Vector3Float(); 

   /** angular velocity of the entity */
   protected Vector3Float  _entityAngularVelocity = new Vector3Float(); 


/** Constructor */
   ///<summary>
   ///represents values used in dead reckoning algorithms
   ///</summary>
 public DeadReckoningParameter()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 1;  // _deadReckoningAlgorithm
   marshalSize = marshalSize + 15 * 1;  // _otherParameters
   marshalSize = marshalSize + _entityLinearAcceleration.getMarshalledSize();  // _entityLinearAcceleration
   marshalSize = marshalSize + _entityAngularVelocity.getMarshalledSize();  // _entityAngularVelocity

   return marshalSize;
}


   ///<summary>
   ///enumeration of what dead reckoning algorighm to use
   ///</summary>
public void setDeadReckoningAlgorithm(byte pDeadReckoningAlgorithm)
{ _deadReckoningAlgorithm = pDeadReckoningAlgorithm;
}

[XmlElement(Type= typeof(byte), ElementName="deadReckoningAlgorithm")]
public byte DeadReckoningAlgorithm
{
     get
{
          return _deadReckoningAlgorithm;
}
     set
{
          _deadReckoningAlgorithm = value;
}
}

   ///<summary>
   ///other parameters to use in the dead reckoning algorithm
   ///</summary>
public void setOtherParameters(byte[] pOtherParameters)
{ _otherParameters = pOtherParameters;
}

   ///<summary>
   ///other parameters to use in the dead reckoning algorithm
   ///</summary>
public byte[] getOtherParameters()
{ return _otherParameters; }

   ///<summary>
   ///other parameters to use in the dead reckoning algorithm
   ///</summary>
[XmlArray(ElementName="otherParameters")]
public byte[] OtherParameters
{
     get
{
          return _otherParameters;
}
     set
{
          _otherParameters = value;
}
}

   ///<summary>
   ///Linear acceleration of the entity
   ///</summary>
public void setEntityLinearAcceleration(Vector3Float pEntityLinearAcceleration)
{ _entityLinearAcceleration = pEntityLinearAcceleration;
}

   ///<summary>
   ///Linear acceleration of the entity
   ///</summary>
public Vector3Float getEntityLinearAcceleration()
{ return _entityLinearAcceleration; 
}

   ///<summary>
   ///Linear acceleration of the entity
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="entityLinearAcceleration")]
public Vector3Float EntityLinearAcceleration
{
     get
{
          return _entityLinearAcceleration;
}
     set
{
          _entityLinearAcceleration = value;
}
}

   ///<summary>
   ///angular velocity of the entity
   ///</summary>
public void setEntityAngularVelocity(Vector3Float pEntityAngularVelocity)
{ _entityAngularVelocity = pEntityAngularVelocity;
}

   ///<summary>
   ///angular velocity of the entity
   ///</summary>
public Vector3Float getEntityAngularVelocity()
{ return _entityAngularVelocity; 
}

   ///<summary>
   ///angular velocity of the entity
   ///</summary>
[XmlElement(Type= typeof(Vector3Float), ElementName="entityAngularVelocity")]
public Vector3Float EntityAngularVelocity
{
     get
{
          return _entityAngularVelocity;
}
     set
{
          _entityAngularVelocity = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeByte((byte)_deadReckoningAlgorithm);

       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
           dos.writeByte(_otherParameters[idx]);
       } // end of array marshaling

       _entityLinearAcceleration.marshal(dos);
       _entityAngularVelocity.marshal(dos);
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
       _deadReckoningAlgorithm = dis.readByte();
       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
                _otherParameters[idx] = dis.readByte();
       } // end of array unmarshaling
       _entityLinearAcceleration.unmarshal(dis);
       _entityAngularVelocity.unmarshal(dis);
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
    sb.Append("<DeadReckoningParameter>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<deadReckoningAlgorithm type=\"byte\">" + _deadReckoningAlgorithm.ToString() + "</deadReckoningAlgorithm> " + System.Environment.NewLine);

       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
           sb.Append("<otherParameters"+ idx.ToString() + " type=\"byte\">" + _otherParameters[idx] + "</otherParameters"+ idx.ToString() + "> " + System.Environment.NewLine);
       } // end of array reflection

    sb.Append("<entityLinearAcceleration>"  + System.Environment.NewLine);
       _entityLinearAcceleration.reflection(sb);
    sb.Append("</entityLinearAcceleration>"  + System.Environment.NewLine);
    sb.Append("<entityAngularVelocity>"  + System.Environment.NewLine);
       _entityAngularVelocity.reflection(sb);
    sb.Append("</entityAngularVelocity>"  + System.Environment.NewLine);
    sb.Append("</DeadReckoningParameter>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(DeadReckoningParameter a, DeadReckoningParameter b)
        {
                return !(a == b);
        }

        public static bool operator ==(DeadReckoningParameter a, DeadReckoningParameter b)
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
 public bool equals(DeadReckoningParameter rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_deadReckoningAlgorithm == rhs._deadReckoningAlgorithm)) ivarsEqual = false;

     for(int idx = 0; idx < 15; idx++)
     {
          if(!(_otherParameters[idx] == rhs._otherParameters[idx])) ivarsEqual = false;
     }

     if( ! (_entityLinearAcceleration.Equals( rhs._entityLinearAcceleration) )) ivarsEqual = false;
     if( ! (_entityAngularVelocity.Equals( rhs._entityAngularVelocity) )) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
