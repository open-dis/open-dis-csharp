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
 * Section 5.3.12.3: Start resume simulation, relaible. COMPLETE
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
[XmlInclude(typeof(ClockTime))]
public class StartResumeReliablePdu : SimulationManagementWithReliabilityFamilyPdu
{
   /** time in real world for this operation to happen */
   protected ClockTime  _realWorldTime = new ClockTime(); 

   /** time in simulation for the simulation to resume */
   protected ClockTime  _simulationTime = new ClockTime(); 

   /** level of reliability service used for this transaction */
   protected byte  _requiredReliabilityService;

   /** padding */
   protected ushort  _pad1;

   /** padding */
   protected byte  _pad2;

   /** Request ID */
   protected uint  _requestID;


/** Constructor */
   ///<summary>
   ///Section 5.3.12.3: Start resume simulation, relaible. COMPLETE
   ///</summary>
 public StartResumeReliablePdu()
 {
    PduType = (byte)53;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _realWorldTime.getMarshalledSize();  // _realWorldTime
   marshalSize = marshalSize + _simulationTime.getMarshalledSize();  // _simulationTime
   marshalSize = marshalSize + 1;  // _requiredReliabilityService
   marshalSize = marshalSize + 2;  // _pad1
   marshalSize = marshalSize + 1;  // _pad2
   marshalSize = marshalSize + 4;  // _requestID

   return marshalSize;
}


   ///<summary>
   ///time in real world for this operation to happen
   ///</summary>
public void setRealWorldTime(ClockTime pRealWorldTime)
{ _realWorldTime = pRealWorldTime;
}

   ///<summary>
   ///time in real world for this operation to happen
   ///</summary>
public ClockTime getRealWorldTime()
{ return _realWorldTime; 
}

   ///<summary>
   ///time in real world for this operation to happen
   ///</summary>
[XmlElement(Type= typeof(ClockTime), ElementName="realWorldTime")]
public ClockTime RealWorldTime
{
     get
{
          return _realWorldTime;
}
     set
{
          _realWorldTime = value;
}
}

   ///<summary>
   ///time in simulation for the simulation to resume
   ///</summary>
public void setSimulationTime(ClockTime pSimulationTime)
{ _simulationTime = pSimulationTime;
}

   ///<summary>
   ///time in simulation for the simulation to resume
   ///</summary>
public ClockTime getSimulationTime()
{ return _simulationTime; 
}

   ///<summary>
   ///time in simulation for the simulation to resume
   ///</summary>
[XmlElement(Type= typeof(ClockTime), ElementName="simulationTime")]
public ClockTime SimulationTime
{
     get
{
          return _simulationTime;
}
     set
{
          _simulationTime = value;
}
}

   ///<summary>
   ///level of reliability service used for this transaction
   ///</summary>
public void setRequiredReliabilityService(byte pRequiredReliabilityService)
{ _requiredReliabilityService = pRequiredReliabilityService;
}

[XmlElement(Type= typeof(byte), ElementName="requiredReliabilityService")]
public byte RequiredReliabilityService
{
     get
{
          return _requiredReliabilityService;
}
     set
{
          _requiredReliabilityService = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad1(ushort pPad1)
{ _pad1 = pPad1;
}

[XmlElement(Type= typeof(ushort), ElementName="pad1")]
public ushort Pad1
{
     get
{
          return _pad1;
}
     set
{
          _pad1 = value;
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
   ///Request ID
   ///</summary>
public void setRequestID(uint pRequestID)
{ _requestID = pRequestID;
}

[XmlElement(Type= typeof(uint), ElementName="requestID")]
public uint RequestID
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
       _realWorldTime.marshal(dos);
       _simulationTime.marshal(dos);
       dos.writeByte((byte)_requiredReliabilityService);
       dos.writeUshort((ushort)_pad1);
       dos.writeByte((byte)_pad2);
       dos.writeUint((uint)_requestID);
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
       _realWorldTime.unmarshal(dis);
       _simulationTime.unmarshal(dis);
       _requiredReliabilityService = dis.readByte();
       _pad1 = dis.readUshort();
       _pad2 = dis.readByte();
       _requestID = dis.readUint();
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
    sb.Append("<StartResumeReliablePdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<realWorldTime>"  + System.Environment.NewLine);
       _realWorldTime.reflection(sb);
    sb.Append("</realWorldTime>"  + System.Environment.NewLine);
    sb.Append("<simulationTime>"  + System.Environment.NewLine);
       _simulationTime.reflection(sb);
    sb.Append("</simulationTime>"  + System.Environment.NewLine);
           sb.Append("<requiredReliabilityService type=\"byte\">" + _requiredReliabilityService.ToString() + "</requiredReliabilityService> " + System.Environment.NewLine);
           sb.Append("<pad1 type=\"ushort\">" + _pad1.ToString() + "</pad1> " + System.Environment.NewLine);
           sb.Append("<pad2 type=\"byte\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
           sb.Append("<requestID type=\"uint\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
    sb.Append("</StartResumeReliablePdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(StartResumeReliablePdu a, StartResumeReliablePdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(StartResumeReliablePdu a, StartResumeReliablePdu b)
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
 public bool equals(StartResumeReliablePdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_realWorldTime.Equals( rhs._realWorldTime) )) ivarsEqual = false;
     if( ! (_simulationTime.Equals( rhs._simulationTime) )) ivarsEqual = false;
     if( ! (_requiredReliabilityService == rhs._requiredReliabilityService)) ivarsEqual = false;
     if( ! (_pad1 == rhs._pad1)) ivarsEqual = false;
     if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
     if( ! (_requestID == rhs._requestID)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
