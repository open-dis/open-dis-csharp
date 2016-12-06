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
 * One track/jam target
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
public class TrackJamTarget : Object
{
   /** track/jam target */
   protected EntityID  _trackJam = new EntityID(); 

   /** Emitter ID */
   protected byte  _emitterID;

   /** beam ID */
   protected byte  _beamID;


/** Constructor */
   ///<summary>
   ///One track/jam target
   ///</summary>
 public TrackJamTarget()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + _trackJam.getMarshalledSize();  // _trackJam
   marshalSize = marshalSize + 1;  // _emitterID
   marshalSize = marshalSize + 1;  // _beamID

   return marshalSize;
}


   ///<summary>
   ///track/jam target
   ///</summary>
public void setTrackJam(EntityID pTrackJam)
{ _trackJam = pTrackJam;
}

   ///<summary>
   ///track/jam target
   ///</summary>
public EntityID getTrackJam()
{ return _trackJam; 
}

   ///<summary>
   ///track/jam target
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="trackJam")]
public EntityID TrackJam
{
     get
{
          return _trackJam;
}
     set
{
          _trackJam = value;
}
}

   ///<summary>
   ///Emitter ID
   ///</summary>
public void setEmitterID(byte pEmitterID)
{ _emitterID = pEmitterID;
}

[XmlElement(Type= typeof(byte), ElementName="emitterID")]
public byte EmitterID
{
     get
{
          return _emitterID;
}
     set
{
          _emitterID = value;
}
}

   ///<summary>
   ///beam ID
   ///</summary>
public void setBeamID(byte pBeamID)
{ _beamID = pBeamID;
}

[XmlElement(Type= typeof(byte), ElementName="beamID")]
public byte BeamID
{
     get
{
          return _beamID;
}
     set
{
          _beamID = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       _trackJam.marshal(dos);
       dos.writeByte((byte)_emitterID);
       dos.writeByte((byte)_beamID);
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
       _trackJam.unmarshal(dis);
       _emitterID = dis.readByte();
       _beamID = dis.readByte();
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
    sb.Append("<TrackJamTarget>"  + System.Environment.NewLine);
    try 
    {
    sb.Append("<trackJam>"  + System.Environment.NewLine);
       _trackJam.reflection(sb);
    sb.Append("</trackJam>"  + System.Environment.NewLine);
           sb.Append("<emitterID type=\"byte\">" + _emitterID.ToString() + "</emitterID> " + System.Environment.NewLine);
           sb.Append("<beamID type=\"byte\">" + _beamID.ToString() + "</beamID> " + System.Environment.NewLine);
    sb.Append("</TrackJamTarget>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(TrackJamTarget a, TrackJamTarget b)
        {
                return !(a == b);
        }

        public static bool operator ==(TrackJamTarget a, TrackJamTarget b)
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
 public bool equals(TrackJamTarget rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_trackJam.Equals( rhs._trackJam) )) ivarsEqual = false;
     if( ! (_emitterID == rhs._emitterID)) ivarsEqual = false;
     if( ! (_beamID == rhs._beamID)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
