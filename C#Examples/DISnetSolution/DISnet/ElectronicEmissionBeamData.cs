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
 * Description of one electronic emission beam
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
[XmlInclude(typeof(FundamentalParameterData))]
[XmlInclude(typeof(TrackJamTarget))]
public class ElectronicEmissionBeamData : Object
{
   /** This field shall specify the length of this beams data in 32 bit words */
   protected byte  _beamDataLength;

   /** This field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system. */
   protected byte  _beamIDNumber;

   /** This field shall specify a Beam Parameter Index number that shall be used by receiving entities in conjunction with the Emitter Name field to provide a pointer to the stored database parameters required to regenerate the beam.  */
   protected ushort  _beamParameterIndex;

   /** Fundamental parameter data such as frequency range, beam sweep, etc. */
   protected FundamentalParameterData  _fundamentalParameterData = new FundamentalParameterData(); 

   /** beam function of a particular beam */
   protected byte  _beamFunction;

   /** Number of track/jam targets */
   protected byte  _numberOfTrackJamTargets;

   /** wheher or not the receiving simulation apps can assume all the targets in the scan pattern are being tracked/jammed */
   protected byte  _highDensityTrackJam;

   /** padding */
   protected byte  _pad4 = 0;

   /** identify jamming techniques used */
   protected uint  _jammingModeSequence;

   /** variable length list of track/jam targets */
   protected List<TrackJamTarget> _trackJamTargets = new List<TrackJamTarget>(); 

/** Constructor */
   ///<summary>
   ///Description of one electronic emission beam
   ///</summary>
 public ElectronicEmissionBeamData()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 1;  // _beamDataLength
   marshalSize = marshalSize + 1;  // _beamIDNumber
   marshalSize = marshalSize + 2;  // _beamParameterIndex
   marshalSize = marshalSize + _fundamentalParameterData.getMarshalledSize();  // _fundamentalParameterData
   marshalSize = marshalSize + 1;  // _beamFunction
   marshalSize = marshalSize + 1;  // _numberOfTrackJamTargets
   marshalSize = marshalSize + 1;  // _highDensityTrackJam
   marshalSize = marshalSize + 1;  // _pad4
   marshalSize = marshalSize + 4;  // _jammingModeSequence
   for(int idx=0; idx < _trackJamTargets.Count; idx++)
   {
        TrackJamTarget listElement = (TrackJamTarget)_trackJamTargets[idx];
        marshalSize = marshalSize + listElement.getMarshalledSize();
   }

   return marshalSize;
}


   ///<summary>
   ///This field shall specify the length of this beams data in 32 bit words
   ///</summary>
public void setBeamDataLength(byte pBeamDataLength)
{ _beamDataLength = pBeamDataLength;
}

[XmlElement(Type= typeof(byte), ElementName="beamDataLength")]
public byte BeamDataLength
{
     get
{
          return _beamDataLength;
}
     set
{
          _beamDataLength = value;
}
}

   ///<summary>
   ///This field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system.
   ///</summary>
public void setBeamIDNumber(byte pBeamIDNumber)
{ _beamIDNumber = pBeamIDNumber;
}

[XmlElement(Type= typeof(byte), ElementName="beamIDNumber")]
public byte BeamIDNumber
{
     get
{
          return _beamIDNumber;
}
     set
{
          _beamIDNumber = value;
}
}

   ///<summary>
   ///This field shall specify a Beam Parameter Index number that shall be used by receiving entities in conjunction with the Emitter Name field to provide a pointer to the stored database parameters required to regenerate the beam. 
   ///</summary>
public void setBeamParameterIndex(ushort pBeamParameterIndex)
{ _beamParameterIndex = pBeamParameterIndex;
}

[XmlElement(Type= typeof(ushort), ElementName="beamParameterIndex")]
public ushort BeamParameterIndex
{
     get
{
          return _beamParameterIndex;
}
     set
{
          _beamParameterIndex = value;
}
}

   ///<summary>
   ///Fundamental parameter data such as frequency range, beam sweep, etc.
   ///</summary>
public void setFundamentalParameterData(FundamentalParameterData pFundamentalParameterData)
{ _fundamentalParameterData = pFundamentalParameterData;
}

   ///<summary>
   ///Fundamental parameter data such as frequency range, beam sweep, etc.
   ///</summary>
public FundamentalParameterData getFundamentalParameterData()
{ return _fundamentalParameterData; 
}

   ///<summary>
   ///Fundamental parameter data such as frequency range, beam sweep, etc.
   ///</summary>
[XmlElement(Type= typeof(FundamentalParameterData), ElementName="fundamentalParameterData")]
public FundamentalParameterData FundamentalParameterData
{
     get
{
          return _fundamentalParameterData;
}
     set
{
          _fundamentalParameterData = value;
}
}

   ///<summary>
   ///beam function of a particular beam
   ///</summary>
public void setBeamFunction(byte pBeamFunction)
{ _beamFunction = pBeamFunction;
}

[XmlElement(Type= typeof(byte), ElementName="beamFunction")]
public byte BeamFunction
{
     get
{
          return _beamFunction;
}
     set
{
          _beamFunction = value;
}
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfTrackJamTargets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
public void setNumberOfTrackJamTargets(byte pNumberOfTrackJamTargets)
{ _numberOfTrackJamTargets = pNumberOfTrackJamTargets;
}

/// <summary>
/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getnumberOfTrackJamTargets method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.
/// </summary>
[XmlElement(Type= typeof(byte), ElementName="numberOfTrackJamTargets")]
public byte NumberOfTrackJamTargets
{
     get
     {
          return _numberOfTrackJamTargets;
     }
     set
     {
          _numberOfTrackJamTargets = value;
     }
}

   ///<summary>
   ///wheher or not the receiving simulation apps can assume all the targets in the scan pattern are being tracked/jammed
   ///</summary>
public void setHighDensityTrackJam(byte pHighDensityTrackJam)
{ _highDensityTrackJam = pHighDensityTrackJam;
}

[XmlElement(Type= typeof(byte), ElementName="highDensityTrackJam")]
public byte HighDensityTrackJam
{
     get
{
          return _highDensityTrackJam;
}
     set
{
          _highDensityTrackJam = value;
}
}

   ///<summary>
   ///padding
   ///</summary>
public void setPad4(byte pPad4)
{ _pad4 = pPad4;
}

[XmlElement(Type= typeof(byte), ElementName="pad4")]
public byte Pad4
{
     get
{
          return _pad4;
}
     set
{
          _pad4 = value;
}
}

   ///<summary>
   ///identify jamming techniques used
   ///</summary>
public void setJammingModeSequence(uint pJammingModeSequence)
{ _jammingModeSequence = pJammingModeSequence;
}

[XmlElement(Type= typeof(uint), ElementName="jammingModeSequence")]
public uint JammingModeSequence
{
     get
{
          return _jammingModeSequence;
}
     set
{
          _jammingModeSequence = value;
}
}

   ///<summary>
   ///variable length list of track/jam targets
   ///</summary>
public void setTrackJamTargets(List<TrackJamTarget> pTrackJamTargets)
{ _trackJamTargets = pTrackJamTargets;
}

   ///<summary>
   ///variable length list of track/jam targets
   ///</summary>
public List<TrackJamTarget> getTrackJamTargets()
{ return _trackJamTargets; }

   ///<summary>
   ///variable length list of track/jam targets
   ///</summary>
[XmlElement(ElementName = "trackJamTargetsList",Type = typeof(List<TrackJamTarget>))]
public List<TrackJamTarget> TrackJamTargets
{
     get
{
          return _trackJamTargets;
}
     set
{
          _trackJamTargets = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeByte((byte)_beamDataLength);
       dos.writeByte((byte)_beamIDNumber);
       dos.writeUshort((ushort)_beamParameterIndex);
       _fundamentalParameterData.marshal(dos);
       dos.writeByte((byte)_beamFunction);
       dos.writeByte((byte)_trackJamTargets.Count);
       dos.writeByte((byte)_highDensityTrackJam);
       dos.writeByte((byte)_pad4);
       dos.writeUint((uint)_jammingModeSequence);

       for(int idx = 0; idx < _trackJamTargets.Count; idx++)
       {
            TrackJamTarget aTrackJamTarget = (TrackJamTarget)_trackJamTargets[idx];
            aTrackJamTarget.marshal(dos);
       } // end of list marshalling

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
       _beamDataLength = dis.readByte();
       _beamIDNumber = dis.readByte();
       _beamParameterIndex = dis.readUshort();
       _fundamentalParameterData.unmarshal(dis);
       _beamFunction = dis.readByte();
       _numberOfTrackJamTargets = dis.readByte();
       _highDensityTrackJam = dis.readByte();
       _pad4 = dis.readByte();
       _jammingModeSequence = dis.readUint();
        for(int idx = 0; idx < _numberOfTrackJamTargets; idx++)
        {
           TrackJamTarget anX = new TrackJamTarget();
            anX.unmarshal(dis);
            _trackJamTargets.Add(anX);
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
public void reflection(StringBuilder sb)
{
    sb.Append("<ElectronicEmissionBeamData>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<beamDataLength type=\"byte\">" + _beamDataLength.ToString() + "</beamDataLength> " + System.Environment.NewLine);
           sb.Append("<beamIDNumber type=\"byte\">" + _beamIDNumber.ToString() + "</beamIDNumber> " + System.Environment.NewLine);
           sb.Append("<beamParameterIndex type=\"ushort\">" + _beamParameterIndex.ToString() + "</beamParameterIndex> " + System.Environment.NewLine);
    sb.Append("<fundamentalParameterData>"  + System.Environment.NewLine);
       _fundamentalParameterData.reflection(sb);
    sb.Append("</fundamentalParameterData>"  + System.Environment.NewLine);
           sb.Append("<beamFunction type=\"byte\">" + _beamFunction.ToString() + "</beamFunction> " + System.Environment.NewLine);
           sb.Append("<trackJamTargets type=\"byte\">" + _trackJamTargets.Count.ToString() + "</trackJamTargets> " + System.Environment.NewLine);
           sb.Append("<highDensityTrackJam type=\"byte\">" + _highDensityTrackJam.ToString() + "</highDensityTrackJam> " + System.Environment.NewLine);
           sb.Append("<pad4 type=\"byte\">" + _pad4.ToString() + "</pad4> " + System.Environment.NewLine);
           sb.Append("<jammingModeSequence type=\"uint\">" + _jammingModeSequence.ToString() + "</jammingModeSequence> " + System.Environment.NewLine);

       for(int idx = 0; idx < _trackJamTargets.Count; idx++)
       {
           sb.Append("<trackJamTargets"+ idx.ToString() + " type=\"TrackJamTarget\">" + System.Environment.NewLine);
            TrackJamTarget aTrackJamTarget = (TrackJamTarget)_trackJamTargets[idx];
            aTrackJamTarget.reflection(sb);
           sb.Append("</trackJamTargets"+ idx.ToString() + ">" + System.Environment.NewLine);
       } // end of list marshalling

    sb.Append("</ElectronicEmissionBeamData>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(ElectronicEmissionBeamData a, ElectronicEmissionBeamData b)
        {
                return !(a == b);
        }

        public static bool operator ==(ElectronicEmissionBeamData a, ElectronicEmissionBeamData b)
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
 public bool equals(ElectronicEmissionBeamData rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_beamDataLength == rhs._beamDataLength)) ivarsEqual = false;
     if( ! (_beamIDNumber == rhs._beamIDNumber)) ivarsEqual = false;
     if( ! (_beamParameterIndex == rhs._beamParameterIndex)) ivarsEqual = false;
     if( ! (_fundamentalParameterData.Equals( rhs._fundamentalParameterData) )) ivarsEqual = false;
     if( ! (_beamFunction == rhs._beamFunction)) ivarsEqual = false;
     if( ! (_numberOfTrackJamTargets == rhs._numberOfTrackJamTargets)) ivarsEqual = false;
     if( ! (_highDensityTrackJam == rhs._highDensityTrackJam)) ivarsEqual = false;
     if( ! (_pad4 == rhs._pad4)) ivarsEqual = false;
     if( ! (_jammingModeSequence == rhs._jammingModeSequence)) ivarsEqual = false;

     for(int idx = 0; idx < _trackJamTargets.Count; idx++)
     {
        TrackJamTarget x = (TrackJamTarget)_trackJamTargets[idx];
        if( ! ( _trackJamTargets[idx].Equals(rhs._trackJamTargets[idx]))) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
