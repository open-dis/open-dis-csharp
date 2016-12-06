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
 * Section 5.3.6.11. Reports occurance of a significant event to the simulation manager. COMPLETE
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
public class EventReportPdu : SimulationManagementFamilyPdu
{
   /** Type of event */
   protected uint  _eventType;

   /** padding */
   protected uint  _padding1 = 0;

   /** Number of fixed datum records */
   protected uint  _numberOfFixedDatumRecords;

   /** Number of variable datum records */
   protected uint  _numberOfVariableDatumRecords;

   /** variable length list of fixed datums */
   protected List<FixedDatum> _fixedDatums = new List<FixedDatum>(); 
   /** variable length list of variable length datums */
   protected List<VariableDatum> _variableDatums = new List<VariableDatum>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.6.11. Reports occurance of a significant event to the simulation manager. COMPLETE
   ///</summary>
 public EventReportPdu()
 {
    PduType = (byte)21;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + 4;  // _eventType
   marshalSize = marshalSize + 4;  // _padding1
   marshalSize = marshalSize + 4;  // _numberOfFixedDatumRecords
   marshalSize = marshalSize + 4;  // _numberOfVariableDatumRecords
   for(int idx=0; idx < _fixedDatums.Count; idx++)
   {
        FixedDatum listElement = (FixedDatum)_fixedDatums[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }
   for(int idx=0; idx < _variableDatums.Count; idx++)
   {
        VariableDatum listElement = (VariableDatum)_variableDatums[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///Type of event
   ///</summary>
public void setEventType(uint pEventType)
{ _eventType = pEventType;
}

[XmlElement(Type= typeof(uint), ElementName="eventType")]
public uint EventType
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
public void setPadding1(uint pPadding1)
{ _padding1 = pPadding1;
}

[XmlElement(Type= typeof(uint), ElementName="padding1")]
public uint Padding1
{
     get
{
          return _padding1;
}
     set
{
          _padding1 = value;
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
   ///variable length list of fixed datums
   ///</summary>
public void setFixedDatums(List<FixedDatum> pFixedDatums)
{ _fixedDatums = pFixedDatums;
}

   ///<summary>
   ///variable length list of fixed datums
   ///</summary>
public List<FixedDatum> getFixedDatums()
{ return _fixedDatums; }

   ///<summary>
   ///variable length list of fixed datums
   ///</summary>
[XmlElement(ElementName = "fixedDatumsList",Type = typeof(List<FixedDatum>))]
public List<FixedDatum> FixedDatums
{
     get
{
          return _fixedDatums;
}
     set
{
          _fixedDatums = value;
}
}

   ///<summary>
   ///variable length list of variable length datums
   ///</summary>
public void setVariableDatums(List<VariableDatum> pVariableDatums)
{ _variableDatums = pVariableDatums;
}

   ///<summary>
   ///variable length list of variable length datums
   ///</summary>
public List<VariableDatum> getVariableDatums()
{ return _variableDatums; }

   ///<summary>
   ///variable length list of variable length datums
   ///</summary>
[XmlElement(ElementName = "variableDatumsList",Type = typeof(List<VariableDatum>))]
public List<VariableDatum> VariableDatums
{
     get
{
          return _variableDatums;
}
     set
{
          _variableDatums = value;
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
       dos.writeUint((uint)_eventType);
       dos.writeUint((uint)_padding1);
       dos.writeUint((uint)_fixedDatums.Count);
       dos.writeUint((uint)_variableDatums.Count);

       for(int idx = 0; idx < _fixedDatums.Count; idx++)
       {
            FixedDatum aFixedDatum = (FixedDatum)_fixedDatums[idx];
            aFixedDatum.marshal(dos);
       } // end of list marshalling


       for(int idx = 0; idx < _variableDatums.Count; idx++)
       {
            VariableDatum aVariableDatum = (VariableDatum)_variableDatums[idx];
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
       _eventType = dis.readUint();
       _padding1 = dis.readUint();
       _numberOfFixedDatumRecords = dis.readUint();
       _numberOfVariableDatumRecords = dis.readUint();
        for(int idx = 0; idx < _numberOfFixedDatumRecords; idx++)
        {
           FixedDatum anX = new FixedDatum();
            anX.unmarshal(dis);
            _fixedDatums.Add(anX);
        };

        for(int idx = 0; idx < _numberOfVariableDatumRecords; idx++)
        {
           VariableDatum anX = new VariableDatum();
            anX.unmarshal(dis);
            _variableDatums.Add(anX);
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
    sb.Append("<EventReportPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
           sb.Append("<eventType type=\"uint\">" + _eventType.ToString() + "</eventType> " + System.Environment.NewLine);
           sb.Append("<padding1 type=\"uint\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
           sb.Append("<fixedDatums type=\"uint\">" + _fixedDatums.Count.ToString() + "</fixedDatums> " + System.Environment.NewLine);
           sb.Append("<variableDatums type=\"uint\">" + _variableDatums.Count.ToString() + "</variableDatums> " + System.Environment.NewLine);

       for(int idx = 0; idx < _fixedDatums.Count; idx++)
       {
           sb.Append("<fixedDatums"+ idx.ToString() + " type=\"FixedDatum\">" + System.Environment.NewLine);
            FixedDatum aFixedDatum = (FixedDatum)_fixedDatums[idx];
            aFixedDatum.reflection(sb);
           sb.Append("</fixedDatums"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling


       for(int idx = 0; idx < _variableDatums.Count; idx++)
       {
           sb.Append("<variableDatums"+ idx.ToString() + " type=\"VariableDatum\">" + System.Environment.NewLine);
            VariableDatum aVariableDatum = (VariableDatum)_variableDatums[idx];
            aVariableDatum.reflection(sb);
           sb.Append("</variableDatums"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</EventReportPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(EventReportPdu a, EventReportPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(EventReportPdu a, EventReportPdu b)
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
 public bool equals(EventReportPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_eventType == rhs._eventType)) ivarsEqual = false;
     if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
     if( ! (_numberOfFixedDatumRecords == rhs._numberOfFixedDatumRecords)) ivarsEqual = false;
     if( ! (_numberOfVariableDatumRecords == rhs._numberOfVariableDatumRecords)) ivarsEqual = false;

     for(int idx = 0; idx < _fixedDatums.Count; idx++)
     {
        FixedDatum x = (FixedDatum)_fixedDatums[idx];
        if( ! ( _fixedDatums[idx].Equals(rhs._fixedDatums[idx]))) ivarsEqual = false;
     }


     for(int idx = 0; idx < _variableDatums.Count; idx++)
     {
        VariableDatum x = (VariableDatum)_variableDatums[idx];
        if( ! ( _variableDatums[idx].Equals(rhs._variableDatums[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
