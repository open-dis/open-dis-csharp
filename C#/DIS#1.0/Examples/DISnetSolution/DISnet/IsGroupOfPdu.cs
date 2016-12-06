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
 * Section 5.3.9.2 Information about a particular group of entities grouped together for the purposes of netowrk bandwidth         reduction or aggregation. Needs manual cleanup. The GED size requires a database lookup. UNFINISHED
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
[XmlInclude(typeof(VariableDatum))]
public class IsGroupOfPdu : EntityManagementFamilyPdu
{
   /** ID of aggregated entities */
   protected EntityID  _groupEntityID = new EntityID(); 

   /** type of entities constituting the group */
   protected byte  _groupedEntityCategory;

   /** Number of individual entities constituting the group */
   protected byte  _numberOfGroupedEntities;

   /** padding */
   protected uint  _pad2;

   /** latitude */
   protected double  _latitude;

   /** longitude */
   protected double  _longitude;

   /** GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements */
   protected List<VariableDatum> _groupedEntityDescriptions = new List<VariableDatum>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.9.2 Information about a particular group of entities grouped together for the purposes of netowrk bandwidth         reduction or aggregation. Needs manual cleanup. The GED size requires a database lookup. UNFINISHED
   ///</summary>
 public IsGroupOfPdu()
 {
    PduType = (byte)34;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _groupEntityID.getMarshalledSize();  // _groupEntityID
   marshalSize = marshalSize + 1;  // _groupedEntityCategory
   marshalSize = marshalSize + 1;  // _numberOfGroupedEntities
   marshalSize = marshalSize + 4;  // _pad2
   marshalSize = marshalSize + 8;  // _latitude
   marshalSize = marshalSize + 8;  // _longitude
   for(int idx=0; idx < _groupedEntityDescriptions.Count; idx++)
   {
        VariableDatum listElement = (VariableDatum)_groupedEntityDescriptions[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///ID of aggregated entities
   ///</summary>
public void setGroupEntityID(EntityID pGroupEntityID)
{ _groupEntityID = pGroupEntityID;
}

   ///<summary>
   ///ID of aggregated entities
   ///</summary>
public EntityID getGroupEntityID()
{ return _groupEntityID; 
}

   ///<summary>
   ///ID of aggregated entities
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="groupEntityID")]
public EntityID GroupEntityID
{
     get
{
          return _groupEntityID;
}
     set
{
          _groupEntityID = value;
}
}

   ///<summary>
   ///type of entities constituting the group
   ///</summary>
public void setGroupedEntityCategory(byte pGroupedEntityCategory)
{ _groupedEntityCategory = pGroupedEntityCategory;
}

[XmlElement(Type= typeof(byte), ElementName="groupedEntityCategory")]
public byte GroupedEntityCategory
{
     get
{
          return _groupedEntityCategory;
}
     set
{
          _groupedEntityCategory = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfGroupedEntities method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfGroupedEntities(byte pNumberOfGroupedEntities)
{ _numberOfGroupedEntities = pNumberOfGroupedEntities;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfGroupedEntities method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfGroupedEntities")]
public byte NumberOfGroupedEntities
{
     get
     {
          return _numberOfGroupedEntities;
     }
     set
     {
          _numberOfGroupedEntities = value;
     }
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad2(uint pPad2)
{ _pad2 = pPad2;
}

[XmlElement(Type= typeof(uint), ElementName="pad2")]
public uint Pad2
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
   ///latitude
   ///</summary>
public void setLatitude(double pLatitude)
{ _latitude = pLatitude;
}

[XmlElement(Type= typeof(double), ElementName="latitude")]
public double Latitude
{
     get
{
          return _latitude;
}
     set
{
          _latitude = value;
}
}

   ///<summary>
   ///longitude
   ///</summary>
public void setLongitude(double pLongitude)
{ _longitude = pLongitude;
}

[XmlElement(Type= typeof(double), ElementName="longitude")]
public double Longitude
{
     get
{
          return _longitude;
}
     set
{
          _longitude = value;
}
}

   ///<summary>
   ///GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements
   ///</summary>
public void setGroupedEntityDescriptions(List<VariableDatum> pGroupedEntityDescriptions)
{ _groupedEntityDescriptions = pGroupedEntityDescriptions;
}

   ///<summary>
   ///GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements
   ///</summary>
public List<VariableDatum> getGroupedEntityDescriptions()
{ return _groupedEntityDescriptions; }

   ///<summary>
   ///GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements
   ///</summary>
[XmlElement(ElementName = "groupedEntityDescriptionsList",Type = typeof(List<VariableDatum>))]
public List<VariableDatum> GroupedEntityDescriptions
{
     get
{
          return _groupedEntityDescriptions;
}
     set
{
          _groupedEntityDescriptions = value;
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
       _groupEntityID.marshal(dos);
       dos.writeByte((byte)_groupedEntityCategory);
       dos.writeByte((byte)_groupedEntityDescriptions.Count);
       dos.writeUint((uint)_pad2);
       dos.writeDouble((double)_latitude);
       dos.writeDouble((double)_longitude);

       for(int idx = 0; idx < _groupedEntityDescriptions.Count; idx++)
       {
            VariableDatum aVariableDatum = (VariableDatum)_groupedEntityDescriptions[idx];
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
       _groupEntityID.unmarshal(dis);
       _groupedEntityCategory = dis.readByte();
       _numberOfGroupedEntities = dis.readByte();
       _pad2 = dis.readUint();
       _latitude = dis.readDouble();
       _longitude = dis.readDouble();
        for(int idx = 0; idx < _numberOfGroupedEntities; idx++)
        {
           VariableDatum anX = new VariableDatum();
            anX.unmarshal(dis);
            _groupedEntityDescriptions.Add(anX);
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
    sb.Append("<IsGroupOfPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<groupEntityID>"  + System.Environment.NewLine);
       _groupEntityID.reflection(sb);
    sb.Append("</groupEntityID>"  + System.Environment.NewLine);
           sb.Append("<groupedEntityCategory type=\"byte\">" + _groupedEntityCategory.ToString() + "</groupedEntityCategory> " + System.Environment.NewLine);
           sb.Append("<groupedEntityDescriptions type=\"byte\">" + _groupedEntityDescriptions.Count.ToString() + "</groupedEntityDescriptions> " + System.Environment.NewLine);
           sb.Append("<pad2 type=\"uint\">" + _pad2.ToString() + "</pad2> " + System.Environment.NewLine);
           sb.Append("<latitude type=\"double\">" + _latitude.ToString() + "</latitude> " + System.Environment.NewLine);
           sb.Append("<longitude type=\"double\">" + _longitude.ToString() + "</longitude> " + System.Environment.NewLine);

       for(int idx = 0; idx < _groupedEntityDescriptions.Count; idx++)
       {
           sb.Append("<groupedEntityDescriptions"+ idx.ToString() + " type=\"VariableDatum\">" + System.Environment.NewLine);
            VariableDatum aVariableDatum = (VariableDatum)_groupedEntityDescriptions[idx];
            aVariableDatum.reflection(sb);
           sb.Append("</groupedEntityDescriptions"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</IsGroupOfPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(IsGroupOfPdu a, IsGroupOfPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(IsGroupOfPdu a, IsGroupOfPdu b)
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
 public bool equals(IsGroupOfPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_groupEntityID.Equals( rhs._groupEntityID) )) ivarsEqual = false;
     if( ! (_groupedEntityCategory == rhs._groupedEntityCategory)) ivarsEqual = false;
     if( ! (_numberOfGroupedEntities == rhs._numberOfGroupedEntities)) ivarsEqual = false;
     if( ! (_pad2 == rhs._pad2)) ivarsEqual = false;
     if( ! (_latitude == rhs._latitude)) ivarsEqual = false;
     if( ! (_longitude == rhs._longitude)) ivarsEqual = false;

     for(int idx = 0; idx < _groupedEntityDescriptions.Count; idx++)
     {
        VariableDatum x = (VariableDatum)_groupedEntityDescriptions[idx];
        if( ! ( _groupedEntityDescriptions[idx].Equals(rhs._groupedEntityDescriptions[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
