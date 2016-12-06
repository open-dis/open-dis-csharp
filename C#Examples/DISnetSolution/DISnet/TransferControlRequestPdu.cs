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
 * Section 5.3.9.3 Information initiating the dyanic allocation and control of simulation entities         between two simulation applications. Requires manual cleanup. The padding between record sets is variable. UNFINISHED
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
[XmlInclude(typeof(RecordSet))]
public class TransferControlRequestPdu : EntityManagementFamilyPdu
{
   /** ID of entity originating request */
   protected EntityID  _orginatingEntityID = new EntityID(); 

   /** ID of entity receiving request */
   protected EntityID  _recevingEntityID = new EntityID(); 

   /** ID ofrequest */
   protected uint  _requestID;

   /** required level of reliabliity service. */
   protected byte  _requiredReliabilityService;

   /** type of transfer desired */
   protected byte  _tranferType;

   /** The entity for which control is being requested to transfer */
   protected EntityID  _transferEntityID = new EntityID(); 

   /** number of record sets to transfer */
   protected byte  _numberOfRecordSets;

   /** ^^^This is wrong--the RecordSet class needs more work */
   protected List<RecordSet> _recordSets = new List<RecordSet>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.9.3 Information initiating the dyanic allocation and control of simulation entities         between two simulation applications. Requires manual cleanup. The padding between record sets is variable. UNFINISHED
   ///</summary>
 public TransferControlRequestPdu()
 {
    PduType = (byte)35;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _orginatingEntityID.getMarshalledSize();  // _orginatingEntityID
   marshalSize = marshalSize + _recevingEntityID.getMarshalledSize();  // _recevingEntityID
   marshalSize = marshalSize + 4;  // _requestID
   marshalSize = marshalSize + 1;  // _requiredReliabilityService
   marshalSize = marshalSize + 1;  // _tranferType
   marshalSize = marshalSize + _transferEntityID.getMarshalledSize();  // _transferEntityID
   marshalSize = marshalSize + 1;  // _numberOfRecordSets
   for(int idx=0; idx < _recordSets.Count; idx++)
   {
        RecordSet listElement = (RecordSet)_recordSets[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///ID of entity originating request
   ///</summary>
public void setOrginatingEntityID(EntityID pOrginatingEntityID)
{ _orginatingEntityID = pOrginatingEntityID;
}

   ///<summary>
   ///ID of entity originating request
   ///</summary>
public EntityID getOrginatingEntityID()
{ return _orginatingEntityID; 
}

   ///<summary>
   ///ID of entity originating request
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="orginatingEntityID")]
public EntityID OrginatingEntityID
{
     get
{
          return _orginatingEntityID;
}
     set
{
          _orginatingEntityID = value;
}
}

   ///<summary>
   ///ID of entity receiving request
   ///</summary>
public void setRecevingEntityID(EntityID pRecevingEntityID)
{ _recevingEntityID = pRecevingEntityID;
}

   ///<summary>
   ///ID of entity receiving request
   ///</summary>
public EntityID getRecevingEntityID()
{ return _recevingEntityID; 
}

   ///<summary>
   ///ID of entity receiving request
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="recevingEntityID")]
public EntityID RecevingEntityID
{
     get
{
          return _recevingEntityID;
}
     set
{
          _recevingEntityID = value;
}
}

   ///<summary>
   ///ID ofrequest
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
   ///required level of reliabliity service.
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
   ///type of transfer desired
   ///</summary>
public void setTranferType(byte pTranferType)
{ _tranferType = pTranferType;
}

[XmlElement(Type= typeof(byte), ElementName="tranferType")]
public byte TranferType
{
     get
{
          return _tranferType;
}
     set
{
          _tranferType = value;
}
}

   ///<summary>
   ///The entity for which control is being requested to transfer
   ///</summary>
public void setTransferEntityID(EntityID pTransferEntityID)
{ _transferEntityID = pTransferEntityID;
}

   ///<summary>
   ///The entity for which control is being requested to transfer
   ///</summary>
public EntityID getTransferEntityID()
{ return _transferEntityID; 
}

   ///<summary>
   ///The entity for which control is being requested to transfer
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="transferEntityID")]
public EntityID TransferEntityID
{
     get
{
          return _transferEntityID;
}
     set
{
          _transferEntityID = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfRecordSets(byte pNumberOfRecordSets)
{ _numberOfRecordSets = pNumberOfRecordSets;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfRecordSets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfRecordSets")]
public byte NumberOfRecordSets
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
   ///^^^This is wrong--the RecordSet class needs more work
   ///</summary>
public void setRecordSets(List<RecordSet> pRecordSets)
{ _recordSets = pRecordSets;
}

   ///<summary>
   ///^^^This is wrong--the RecordSet class needs more work
   ///</summary>
public List<RecordSet> getRecordSets()
{ return _recordSets; }

   ///<summary>
   ///^^^This is wrong--the RecordSet class needs more work
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
       _orginatingEntityID.marshal(dos);
       _recevingEntityID.marshal(dos);
       dos.writeUint((uint)_requestID);
       dos.writeByte((byte)_requiredReliabilityService);
       dos.writeByte((byte)_tranferType);
       _transferEntityID.marshal(dos);
       dos.writeByte((byte)_recordSets.Count);

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
       _orginatingEntityID.unmarshal(dis);
       _recevingEntityID.unmarshal(dis);
       _requestID = dis.readUint();
       _requiredReliabilityService = dis.readByte();
       _tranferType = dis.readByte();
       _transferEntityID.unmarshal(dis);
       _numberOfRecordSets = dis.readByte();
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
    sb.Append("<TransferControlRequestPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<orginatingEntityID>"  + System.Environment.NewLine);
       _orginatingEntityID.reflection(sb);
    sb.Append("</orginatingEntityID>"  + System.Environment.NewLine);
    sb.Append("<recevingEntityID>"  + System.Environment.NewLine);
       _recevingEntityID.reflection(sb);
    sb.Append("</recevingEntityID>"  + System.Environment.NewLine);
           sb.Append("<requestID type=\"uint\">" + _requestID.ToString() + "</requestID> " + System.Environment.NewLine);
           sb.Append("<requiredReliabilityService type=\"byte\">" + _requiredReliabilityService.ToString() + "</requiredReliabilityService> " + System.Environment.NewLine);
           sb.Append("<tranferType type=\"byte\">" + _tranferType.ToString() + "</tranferType> " + System.Environment.NewLine);
    sb.Append("<transferEntityID>"  + System.Environment.NewLine);
       _transferEntityID.reflection(sb);
    sb.Append("</transferEntityID>"  + System.Environment.NewLine);
           sb.Append("<recordSets type=\"byte\">" + _recordSets.Count.ToString() + "</recordSets> " + System.Environment.NewLine);

       for(int idx = 0; idx < _recordSets.Count; idx++)
       {
           sb.Append("<recordSets"+ idx.ToString() + " type=\"RecordSet\">" + System.Environment.NewLine);
            RecordSet aRecordSet = (RecordSet)_recordSets[idx];
            aRecordSet.reflection(sb);
           sb.Append("</recordSets"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</TransferControlRequestPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(TransferControlRequestPdu a, TransferControlRequestPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(TransferControlRequestPdu a, TransferControlRequestPdu b)
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
 public bool equals(TransferControlRequestPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_orginatingEntityID.Equals( rhs._orginatingEntityID) )) ivarsEqual = false;
     if( ! (_recevingEntityID.Equals( rhs._recevingEntityID) )) ivarsEqual = false;
     if( ! (_requestID == rhs._requestID)) ivarsEqual = false;
     if( ! (_requiredReliabilityService == rhs._requiredReliabilityService)) ivarsEqual = false;
     if( ! (_tranferType == rhs._tranferType)) ivarsEqual = false;
     if( ! (_transferEntityID.Equals( rhs._transferEntityID) )) ivarsEqual = false;
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
