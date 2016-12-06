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
 * Section 5.3.12.11: reports the occurance of a significatnt event to the simulation manager. Needs manual     intervention to fix padding in variable datums. UNFINISHED.
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
[XmlInclude(typeof(FixedDatum))]
[XmlInclude(typeof(VariableDatum))]
public class EventReportReliablePdu : SimulationManagementWithReliabilityFamilyPdu
{
   /** Event type */
   protected ushort  _eventType;

   /** padding */
   protected uint  _pad1;

   /** Fixed datum record count */
   protected uint  _numberOfFixedDatumRecords;

   /** variable datum record count */
   protected uint  _numberOfVariableDatumRecords;

   /** Fixed datum records */
   protected List<FixedDatum> _fixedDatumRecords = new List<FixedDatum>(); 
   /** Variable datum records */
   protected List<VariableDatum> _variableDatumRecords = new List<VariableDatum>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.12.11: reports the occurance of a significatnt event to the simulation manager. Needs manual     intervention to fix padding in variable datums. UNFINISHED.
   ///</summary>
 public EventReportReliablePdu()
 {
    PduType = (byte)61;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + 2;  // _eventType
   marshalSize = marshalSize + 4;  // _pad1
   marshalSize = marshalSize + 4;  // _numberOfFixedDatumRecords
   marshalSize = marshalSize + 4;  // _numberOfVariableDatumRecords
   for(int idx=0; idx < _fixedDatumRecords.Count; idx++)
   {
        FixedDatum listElement = (FixedDatum)_fixedDatumRecords[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   for(int idx=0; idx < _variableDatumRecords.Count; idx++)
   {
        VariableDatum listElement = (VariableDatum)_variableDatumRecords[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///Event type
   ///</summary>
public void setEventType(ushort pEventType)
{ _eventType = pEventType;
}

[XmlElement(Type= typeof(ushort), ElementName="eventType")]
public ushort EventType
{
     get
{
          return _eventType;
}
     set
{
          _eventType = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad1(uint pPad1)
{ _pad1 = pPad1;
}

[XmlElement(Type= typeof(uint), ElementName="pad1")]
public uint Pad1
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

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfFixedDatumRecords method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfFixedDatumRecords(uint pNumberOfFixedDatumRecords)
{ _numberOfFixedDatumRecords = pNumberOfFixedDatumRecords;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfFixedDatumRecords method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(uint), ElementName="numberOfFixedDatumRecords")]
public uint NumberOfFixedDatumRecords
{
     get
     {
          return _numberOfFixedDatumRecords;
     }
     set
     {
          _numberOfFixedDatumRecords = value;
     }
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfVariableDatumRecords(uint pNumberOfVariableDatumRecords)
{ _numberOfVariableDatumRecords = pNumberOfVariableDatumRecords;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfVariableDatumRecords method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(uint), ElementName="numberOfVariableDatumRecords")]
public uint NumberOfVariableDatumRecords
{
     get
     {
          return _numberOfVariableDatumRecords;
     }
     set
     {
          _numberOfVariableDatumRecords = value;
     }
}

   ///<summary>
   ///Fixed datum records
   ///</summary>
public void setFixedDatumRecords(List<FixedDatum> pFixedDatumRecords)
{ _fixedDatumRecords = pFixedDatumRecords;
}

   ///<summary>
   ///Fixed datum records
   ///</summary>
public List<FixedDatum> getFixedDatumRecords()
{ return _fixedDatumRecords; }

   ///<summary>
   ///Fixed datum records
   ///</summary>
[XmlElement(ElementName = "fixedDatumRecordsList",Type = typeof(List<FixedDatum>))]
public List<FixedDatum> FixedDatumRecords
{
     get
{
          return _fixedDatumRecords;
}
     set
{
          _fixedDatumRecords = value;
}
}

   ///<summary>
   ///Variable datum records
   ///</summary>
public void setVariableDatumRecords(List<VariableDatum> pVariableDatumRecords)
{ _variableDatumRecords = pVariableDatumRecords;
}

   ///<summary>
   ///Variable datum records
   ///</summary>
public List<VariableDatum> getVariableDatumRecords()
{ return _variableDatumRecords; }

   ///<summary>
   ///Variable datum records
   ///</summary>
[XmlElement(ElementName = "variableDatumRecordsList",Type = typeof(List<VariableDatum>))]
public List<VariableDatum> VariableDatumRecords
{
     get
{
          return _variableDatumRecords;
}
     set
{
          _variableDatumRecords = value;
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
       dos.writeUshort((ushort)_eventType);
       dos.writeUint((uint)_pad1);
       dos.writeUint((uint)_fixedDatumRecords.Count);
       dos.writeUint((uint)_variableDatumRecords.Count);

       for(int idx = 0; idx < _fixedDatumRecords.Count; idx++)
       {
            FixedDatum aFixedDatum = (FixedDatum)_fixedDatumRecords[idx];
            aFixedDatum.marshal(dos);
       } // end of list marshalling


       for(int idx = 0; idx < _variableDatumRecords.Count; idx++)
       {
            VariableDatum aVariableDatum = (VariableDatum)_variableDatumRecords[idx];
            aVariableDatum.marshal(dos);
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
       _eventType = dis.readUshort();
       _pad1 = dis.readUint();
       _numberOfFixedDatumRecords = dis.readUint();
       _numberOfVariableDatumRecords = dis.readUint();
        for(int idx = 0; idx < _numberOfFixedDatumRecords; idx++)
        {
           FixedDatum anX = new FixedDatum();
            anX.unmarshal(dis);
            _fixedDatumRecords.Add(anX);
        };

        for(int idx = 0; idx < _numberOfVariableDatumRecords; idx++)
        {
           VariableDatum anX = new VariableDatum();
            anX.unmarshal(dis);
            _variableDatumRecords.Add(anX);
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
    sb.Append("<EventReportReliablePdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
           sb.Append("<eventType type=\"ushort\">" + _eventType.ToString() + "</eventType> " + System.Environment.NewLine);
           sb.Append("<pad1 type=\"uint\">" + _pad1.ToString() + "</pad1> " + System.Environment.NewLine);
           sb.Append("<fixedDatumRecords type=\"uint\">" + _fixedDatumRecords.Count.ToString() + "</fixedDatumRecords> " + System.Environment.NewLine);
           sb.Append("<variableDatumRecords type=\"uint\">" + _variableDatumRecords.Count.ToString() + "</variableDatumRecords> " + System.Environment.NewLine);

       for(int idx = 0; idx < _fixedDatumRecords.Count; idx++)
       {
           sb.Append("<fixedDatumRecords"+ idx.ToString() + " type=\"FixedDatum\">" + System.Environment.NewLine);
            FixedDatum aFixedDatum = (FixedDatum)_fixedDatumRecords[idx];
            aFixedDatum.reflection(sb);
           sb.Append("</fixedDatumRecords"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling


       for(int idx = 0; idx < _variableDatumRecords.Count; idx++)
       {
           sb.Append("<variableDatumRecords"+ idx.ToString() + " type=\"VariableDatum\">" + System.Environment.NewLine);
            VariableDatum aVariableDatum = (VariableDatum)_variableDatumRecords[idx];
            aVariableDatum.reflection(sb);
           sb.Append("</variableDatumRecords"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</EventReportReliablePdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(EventReportReliablePdu a, EventReportReliablePdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(EventReportReliablePdu a, EventReportReliablePdu b)
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
 public bool equals(EventReportReliablePdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_eventType == rhs._eventType)) ivarsEqual = false;
     if( ! (_pad1 == rhs._pad1)) ivarsEqual = false;
     if( ! (_numberOfFixedDatumRecords == rhs._numberOfFixedDatumRecords)) ivarsEqual = false;
     if( ! (_numberOfVariableDatumRecords == rhs._numberOfVariableDatumRecords)) ivarsEqual = false;

     for(int idx = 0; idx < _fixedDatumRecords.Count; idx++)
     {
        FixedDatum x = (FixedDatum)_fixedDatumRecords[idx];
        if( ! ( _fixedDatumRecords[idx].Equals(rhs._fixedDatumRecords[idx]))) ivarsEqual = false;
     }


     for(int idx = 0; idx < _variableDatumRecords.Count; idx++)
     {
        VariableDatum x = (VariableDatum)_variableDatumRecords[idx];
        if( ! ( _variableDatumRecords[idx].Equals(rhs._variableDatumRecords[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
