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
 * Section 5.3.12.14: Initializing or changing internal parameter info. Needs manual intervention     to fix padding in recrod set PDUs. UNFINISHED
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
[XmlInclude(typeof(RecordSet))]
public class SetRecordReliablePdu : SimulationManagementWithReliabilityFamilyPdu
{
   /** request ID */
   protected uint  _requestID;

   /** level of reliability service used for this transaction */
   protected byte  _requiredReliabilityService;

   /** padding. The spec is unclear and contradictory here. */
   protected ushort  _pad1;

   /** padding */
   protected byte  _pad2;

   /** Number of record sets in list */
   protected uint  _numberOfRecordSets;

   /** record sets */
   protected List<RecordSet> _recordSets = new List<RecordSet>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.12.14: Initializing or changing internal parameter info. Needs manual intervention     to fix padding in recrod set PDUs. UNFINISHED
   ///</summary>
 public SetRecordReliablePdu()
 {
    PduType = (byte)64;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + 4;  // _requestID
   marshalSize = marshalSize + 1;  // _requiredReliabilityService
   marshalSize = marshalSize + 2;  // _pad1
   marshalSize = marshalSize + 1;  // _pad2
   marshalSize = marshalSize + 4;  // _numberOfRecordSets
   for(int idx=0; idx < _recordSets.Count; idx++)
   {
        RecordSet listElement = (RecordSet)_recordSets[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///request ID
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
   ///padding. The spec is unclear and contradictory here.
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

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfRecordSets(uint pNumberOfRecordSets)
{ _numberOfRecordSets = pNumberOfRecordSets;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(uint), ElementName="numberOfRecordSets")]
public uint NumberOfRecordSets
{
     get
     {
          return _numberOfRecordSets;
     }
     set
     {
          _numberOfRecordSets = value;
     }
}

   ///<summary>
   ///record sets
   ///</summary>
public void setRecordSets(List<RecordSet> pRecordSets)
{ _recordSets = pRecordSets;
}

   ///<summary>
   ///record sets
   ///</summary>
public List<RecordSet> getRecordSets()
{ return _recordSets; }

   ///<summary>
   ///record sets
   ///</summary>
[XmlElement(ElementName = "recordSetsList",Type = typeof(List<RecordSet>))]
public List<RecordSet> RecordSets
{
     get
{
          return _recordSets;
}
     set
{
          _recordSets = value;
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
       dos.writeUint((uint)_requestID);
       dos.writeByte((byte)_requiredReliabilityService);
       dos.writeUshort((ushort)_pad1);
       dos.writeByte((byte)_pad2);
       dos.writeUint((uint)_recordSets.Count);

       for(int idx = 0; idx < _recordSets.Count; idx++)
       {
            RecordSet aRecordSet = (RecordSet)_recordSets[idx];
            aRecordSet.marshal(dos);
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
       _requestID = dis.readUint();
       _requiredReliabilityService = dis.readByte();
       _pad1 = dis.readUshort();
       _pad2 = dis.readByte();
       _numberOfRecordSets = dis.readUint();
        for(int idx = 0; idx < _numberOfRecordSets; idx++)
        {
           RecordSet anX = new RecordSet();
            anX.unmarshal(dis);
            _recordSets.Add(anX);
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
    sb.Append("<SetRecordReliablePdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
           sb.Append("<requestID type=\"uint\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
           sb.Append("<requiredReliabilityService type=\"byte\">" + _requiredReliabilityService.ToString() + "</requiredReliabilityService> " + System.Environment.NewLine);
           sb.Append("<pad1 type=\"ushort\">" + _pad1.ToString() + "</pad1> " + System.Environment.NewLine);
           sb.Append("<pad2 type=\"byte\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
           sb.Append("<recordSets type=\"uint\">" + _recordSets.Count.ToString() + "</recordSets> " + System.Environment.NewLine);

       for(int idx = 0; idx < _recordSets.Count; idx++)
       {
           sb.Append("<recordSets"+ idx.ToString() + " type=\"RecordSet\">" + System.Environment.NewLine);
            RecordSet aRecordSet = (RecordSet)_recordSets[idx];
            aRecordSet.reflection(sb);
           sb.Append("</recordSets"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</SetRecordReliablePdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(SetRecordReliablePdu a, SetRecordReliablePdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(SetRecordReliablePdu a, SetRecordReliablePdu b)
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
 public bool equals(SetRecordReliablePdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
     if( ! (_requiredReliabilityService == rhs._requiredReliabilityService)) ivarsEqual = false;
     if( ! (_pad1 == rhs._pad1)) ivarsEqual = false;
     if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
     if( ! (_numberOfRecordSets == rhs._numberOfRecordSets)) ivarsEqual = false;

     for(int idx = 0; idx < _recordSets.Count; idx++)
     {
        RecordSet x = (RecordSet)_recordSets[idx];
        if( ! ( _recordSets[idx].Equals(rhs._recordSets[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
