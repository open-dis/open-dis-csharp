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
 * Section 5.3.11.2: Information about globat, spatially varying enviornmental effects. This requires manual cleanup; the grid axis        records are variable sized. UNFINISHED
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
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(GridAxisRecord))]
public class GriddedDataPdu : SyntheticEnvironmentFamilyPdu
{
   /** environmental simulation application ID */
   protected EntityID  _environmentalSimulationApplicationID = new EntityID(); 

   /** unique identifier for each piece of enviornmental data */
   protected ushort  _fieldNumber;

   /** sequence number for the total set of PDUS used to transmit the data */
   protected ushort  _pduNumber;

   /** Total number of PDUS used to transmit the data */
   protected ushort  _pduTotal;

   /** coordinate system of the grid */
   protected ushort  _coordinateSystem;

   /** number of grid axes for the environmental data */
   protected byte  _numberOfGridAxes;

   /** are domain grid axes identidal to those of the priveious domain update? */
   protected byte  _constantGrid;

   /** type of environment */
   protected EntityType  _environmentType = new EntityType(); 

   /** orientation of the data grid */
   protected Orientation  _orientation = new Orientation(); 

   /** valid time of the enviormental data sample, 64 bit unsigned int */
   protected long  _sampleTime;

   /** total number of all data values for all pdus for an environmental sample */
   protected uint  _totalValues;

   /** total number of data values at each grid point. */
   protected byte  _vectorDimension;

   /** padding */
   protected ushort  _padding1;

   /** padding */
   protected byte  _padding2;

   /** Grid data ^^^This is wrong */
   protected List<GridAxisRecord> _gridDataList = new List<GridAxisRecord>(); 

/** Constructor */
   ///<summary>
   ///Section 5.3.11.2: Information about globat, spatially varying enviornmental effects. This requires manual cleanup; the grid axis        records are variable sized. UNFINISHED
   ///</summary>
 public GriddedDataPdu()
 {
    PduType = (byte)42;
 }

new public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = base.getMarshalledSize();
   marshalSize = marshalSize + _environmentalSimulationApplicationID.getMarshalledSize();  // _environmentalSimulationApplicationID
   marshalSize = marshalSize + 2;  // _fieldNumber
   marshalSize = marshalSize + 2;  // _pduNumber
   marshalSize = marshalSize + 2;  // _pduTotal
   marshalSize = marshalSize + 2;  // _coordinateSystem
   marshalSize = marshalSize + 1;  // _numberOfGridAxes
   marshalSize = marshalSize + 1;  // _constantGrid
   marshalSize = marshalSize + _environmentType.getMarshalledSize();  // _environmentType
   marshalSize = marshalSize + _orientation.getMarshalledSize();  // _orientation
   marshalSize = marshalSize + 8;  // _sampleTime
   marshalSize = marshalSize + 4;  // _totalValues
   marshalSize = marshalSize + 1;  // _vectorDimension
   marshalSize = marshalSize + 2;  // _padding1
   marshalSize = marshalSize + 1;  // _padding2
   for(int idx=0; idx < _gridDataList.Count; idx++)
   {
        GridAxisRecord listElement = (GridAxisRecord)_gridDataList[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///environmental simulation application ID
   ///</summary>
public void setEnvironmentalSimulationApplicationID(EntityID pEnvironmentalSimulationApplicationID)
{ _environmentalSimulationApplicationID = pEnvironmentalSimulationApplicationID;
}

   ///<summary>
   ///environmental simulation application ID
   ///</summary>
public EntityID getEnvironmentalSimulationApplicationID()
{ return _environmentalSimulationApplicationID; 
}

   ///<summary>
   ///environmental simulation application ID
   ///</summary>
[XmlElement(Type= typeof(EntityID), ElementName="environmentalSimulationApplicationID")]
public EntityID EnvironmentalSimulationApplicationID
{
     get
{
          return _environmentalSimulationApplicationID;
}
     set
{
          _environmentalSimulationApplicationID = value;
}
}

   ///<summary>
   ///unique identifier for each piece of enviornmental data
   ///</summary>
public void setFieldNumber(ushort pFieldNumber)
{ _fieldNumber = pFieldNumber;
}

[XmlElement(Type= typeof(ushort), ElementName="fieldNumber")]
public ushort FieldNumber
{
     get
{
          return _fieldNumber;
}
     set
{
          _fieldNumber = value;
}
}

   ///<summary>
   ///sequence number for the total set of PDUS used to transmit the data
   ///</summary>
public void setPduNumber(ushort pPduNumber)
{ _pduNumber = pPduNumber;
}

[XmlElement(Type= typeof(ushort), ElementName="pduNumber")]
public ushort PduNumber
{
     get
{
          return _pduNumber;
}
     set
{
          _pduNumber = value;
}
}

   ///<summary>
   ///Total number of PDUS used to transmit the data
   ///</summary>
public void setPduTotal(ushort pPduTotal)
{ _pduTotal = pPduTotal;
}

[XmlElement(Type= typeof(ushort), ElementName="pduTotal")]
public ushort PduTotal
{
     get
{
          return _pduTotal;
}
     set
{
          _pduTotal = value;
}
}

   ///<summary>
   ///coordinate system of the grid
   ///</summary>
public void setCoordinateSystem(ushort pCoordinateSystem)
{ _coordinateSystem = pCoordinateSystem;
}

[XmlElement(Type= typeof(ushort), ElementName="coordinateSystem")]
public ushort CoordinateSystem
{
     get
{
          return _coordinateSystem;
}
     set
{
          _coordinateSystem = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfGridAxes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfGridAxes(byte pNumberOfGridAxes)
{ _numberOfGridAxes = pNumberOfGridAxes;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfGridAxes method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfGridAxes")]
public byte NumberOfGridAxes
{
     get
     {
          return _numberOfGridAxes;
     }
     set
     {
          _numberOfGridAxes = value;
     }
}

   ///<summary>
   ///are domain grid axes identidal to those of the priveious domain update?
   ///</summary>
public void setConstantGrid(byte pConstantGrid)
{ _constantGrid = pConstantGrid;
}

[XmlElement(Type= typeof(byte), ElementName="constantGrid")]
public byte ConstantGrid
{
     get
{
          return _constantGrid;
}
     set
{
          _constantGrid = value;
}
}

   ///<summary>
   ///type of environment
   ///</summary>
public void setEnvironmentType(EntityType pEnvironmentType)
{ _environmentType = pEnvironmentType;
}

   ///<summary>
   ///type of environment
   ///</summary>
public EntityType getEnvironmentType()
{ return _environmentType; 
}

   ///<summary>
   ///type of environment
   ///</summary>
[XmlElement(Type= typeof(EntityType), ElementName="environmentType")]
public EntityType EnvironmentType
{
     get
{
          return _environmentType;
}
     set
{
          _environmentType = value;
}
}

   ///<summary>
   ///orientation of the data grid
   ///</summary>
public void setOrientation(Orientation pOrientation)
{ _orientation = pOrientation;
}

   ///<summary>
   ///orientation of the data grid
   ///</summary>
public Orientation getOrientation()
{ return _orientation; 
}

   ///<summary>
   ///orientation of the data grid
   ///</summary>
[XmlElement(Type= typeof(Orientation), ElementName="orientation")]
public Orientation Orientation
{
     get
{
          return _orientation;
}
     set
{
          _orientation = value;
}
}

   ///<summary>
   ///valid time of the enviormental data sample, 64 bit unsigned int
   ///</summary>
public void setSampleTime(long pSampleTime)
{ _sampleTime = pSampleTime;
}

[XmlElement(Type= typeof(long), ElementName="sampleTime")]
public long SampleTime
{
     get
{
          return _sampleTime;
}
     set
{
          _sampleTime = value;
}
}

   ///<summary>
   ///total number of all data values for all pdus for an environmental sample
   ///</summary>
public void setTotalValues(uint pTotalValues)
{ _totalValues = pTotalValues;
}

[XmlElement(Type= typeof(uint), ElementName="totalValues")]
public uint TotalValues
{
     get
{
          return _totalValues;
}
     set
{
          _totalValues = value;
}
}

   ///<summary>
   ///total number of data values at each grid point.
   ///</summary>
public void setVectorDimension(byte pVectorDimension)
{ _vectorDimension = pVectorDimension;
}

[XmlElement(Type= typeof(byte), ElementName="vectorDimension")]
public byte VectorDimension
{
     get
{
          return _vectorDimension;
}
     set
{
          _vectorDimension = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPadding1(ushort pPadding1)
{ _padding1 = pPadding1;
}

[XmlElement(Type= typeof(ushort), ElementName="padding1")]
public ushort Padding1
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

   ///<summary>
   ///padding
   ///</summary>
public void setPadding2(byte pPadding2)
{ _padding2 = pPadding2;
}

[XmlElement(Type= typeof(byte), ElementName="padding2")]
public byte Padding2
{
     get
{
          return _padding2;
}
     set
{
          _padding2 = value;
}
}

   ///<summary>
   ///Grid data ^^^This is wrong
   ///</summary>
public void setGridDataList(List<GridAxisRecord> pGridDataList)
{ _gridDataList = pGridDataList;
}

   ///<summary>
   ///Grid data ^^^This is wrong
   ///</summary>
public List<GridAxisRecord> getGridDataList()
{ return _gridDataList; }

   ///<summary>
   ///Grid data ^^^This is wrong
   ///</summary>
[XmlElement(ElementName = "gridDataListList",Type = typeof(List<GridAxisRecord>))]
public List<GridAxisRecord> GridDataList
{
     get
{
          return _gridDataList;
}
     set
{
          _gridDataList = value;
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
       _environmentalSimulationApplicationID.marshal(dos);
       dos.writeUshort((ushort)_fieldNumber);
       dos.writeUshort((ushort)_pduNumber);
       dos.writeUshort((ushort)_pduTotal);
       dos.writeUshort((ushort)_coordinateSystem);
       dos.writeByte((byte)_gridDataList.Count);
       dos.writeByte((byte)_constantGrid);
       _environmentType.marshal(dos);
       _orientation.marshal(dos);
       dos.writeLong((long)_sampleTime);
       dos.writeUint((uint)_totalValues);
       dos.writeByte((byte)_vectorDimension);
       dos.writeUshort((ushort)_padding1);
       dos.writeByte((byte)_padding2);

       for(int idx = 0; idx < _gridDataList.Count; idx++)
       {
            GridAxisRecord aGridAxisRecord = (GridAxisRecord)_gridDataList[idx];
            aGridAxisRecord.marshal(dos);
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
       _environmentalSimulationApplicationID.unmarshal(dis);
       _fieldNumber = dis.readUshort();
       _pduNumber = dis.readUshort();
       _pduTotal = dis.readUshort();
       _coordinateSystem = dis.readUshort();
       _numberOfGridAxes = dis.readByte();
       _constantGrid = dis.readByte();
       _environmentType.unmarshal(dis);
       _orientation.unmarshal(dis);
       _sampleTime = dis.readLong();
       _totalValues = dis.readUint();
       _vectorDimension = dis.readByte();
       _padding1 = dis.readUshort();
       _padding2 = dis.readByte();
        for(int idx = 0; idx < _numberOfGridAxes; idx++)
        {
           GridAxisRecord anX = new GridAxisRecord();
            anX.unmarshal(dis);
            _gridDataList.Add(anX);
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
    sb.Append("<GriddedDataPdu>"  + System.Environment.NewLine);
    base.reflection(sb);
    try 
    {
    sb.Append("<environmentalSimulationApplicationID>"  + System.Environment.NewLine);
       _environmentalSimulationApplicationID.reflection(sb);
    sb.Append("</environmentalSimulationApplicationID>"  + System.Environment.NewLine);
           sb.Append("<fieldNumber type=\"ushort\">" + _fieldNumber.ToString() + "</fieldNumber> " + System.Environment.NewLine);
           sb.Append("<pduNumber type=\"ushort\">" + _pduNumber.ToString() + "</pduNumber> " + System.Environment.NewLine);
           sb.Append("<pduTotal type=\"ushort\">" + _pduTotal.ToString() + "</pduTotal> " + System.Environment.NewLine);
           sb.Append("<coordinateSystem type=\"ushort\">" + _coordinateSystem.ToString() + "</coordinateSystem> " + System.Environment.NewLine);
           sb.Append("<gridDataList type=\"byte\">" + _gridDataList.Count.ToString() + "</gridDataList> " + System.Environment.NewLine);
           sb.Append("<constantGrid type=\"byte\">" + _constantGrid.ToString() + "</constantGrid> " + System.Environment.NewLine);
    sb.Append("<environmentType>"  + System.Environment.NewLine);
       _environmentType.reflection(sb);
    sb.Append("</environmentType>"  + System.Environment.NewLine);
    sb.Append("<orientation>"  + System.Environment.NewLine);
       _orientation.reflection(sb);
    sb.Append("</orientation>"  + System.Environment.NewLine);
           sb.Append("<sampleTime type=\"long\">" + _sampleTime.ToString() + "</sampleTime> " + System.Environment.NewLine);
           sb.Append("<totalValues type=\"uint\">" + _totalValues.ToString() + "</totalValues> " + System.Environment.NewLine);
           sb.Append("<vectorDimension type=\"byte\">" + _vectorDimension.ToString() + "</vectorDimension> " + System.Environment.NewLine);
           sb.Append("<padding1 type=\"ushort\">" + _padding1.ToString() + "</padding1> " + System.Environment.NewLine);
           sb.Append("<padding2 type=\"byte\">" + _padding2.ToString() + "</padding2> " + System.Environment.NewLine);

       for(int idx = 0; idx < _gridDataList.Count; idx++)
       {
           sb.Append("<gridDataList"+ idx.ToString() + " type=\"GridAxisRecord\">" + System.Environment.NewLine);
            GridAxisRecord aGridAxisRecord = (GridAxisRecord)_gridDataList[idx];
            aGridAxisRecord.reflection(sb);
           sb.Append("</gridDataList"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</GriddedDataPdu>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(GriddedDataPdu a, GriddedDataPdu b)
        {
                return !(a == b);
        }

        public static bool operator ==(GriddedDataPdu a, GriddedDataPdu b)
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
 public bool equals(GriddedDataPdu rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_environmentalSimulationApplicationID.Equals( rhs._environmentalSimulationApplicationID) )) ivarsEqual = false;
     if( ! (_fieldNumber == rhs._fieldNumber)) ivarsEqual = false;
     if( ! (_pduNumber == rhs._pduNumber)) ivarsEqual = false;
     if( ! (_pduTotal == rhs._pduTotal)) ivarsEqual = false;
     if( ! (_coordinateSystem == rhs._coordinateSystem)) ivarsEqual = false;
     if( ! (_numberOfGridAxes == rhs._numberOfGridAxes)) ivarsEqual = false;
     if( ! (_constantGrid == rhs._constantGrid)) ivarsEqual = false;
     if( ! (_environmentType.Equals( rhs._environmentType) )) ivarsEqual = false;
     if( ! (_orientation.Equals( rhs._orientation) )) ivarsEqual = false;
     if( ! (_sampleTime == rhs._sampleTime)) ivarsEqual = false;
     if( ! (_totalValues == rhs._totalValues)) ivarsEqual = false;
     if( ! (_vectorDimension == rhs._vectorDimension)) ivarsEqual = false;
     if( ! (_padding1 == rhs._padding1)) ivarsEqual = false;
     if( ! (_padding2 == rhs._padding2)) ivarsEqual = false;

     for(int idx = 0; idx < _gridDataList.Count; idx++)
     {
        GridAxisRecord x = (GridAxisRecord)_gridDataList[idx];
        if( ! ( _gridDataList[idx].Equals(rhs._gridDataList[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
