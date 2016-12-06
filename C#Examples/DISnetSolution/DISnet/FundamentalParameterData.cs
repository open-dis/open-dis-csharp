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
 * Section 5.2.22. Contains electromagnetic emmision regineratin parameters that are        variable throughout a scenario dependent on the actions of the participants in the simulation. Also provides basic parametric data that may be used to support low-fidelity simulations.
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
public class FundamentalParameterData : Object
{
   /** center frequency of the emission in hertz. */
   protected float  _frequency;

   /** Bandwidth of the frequencies corresponding to the fequency field. */
   protected float  _frequencyRange;

   /** Effective radiated power for the emission in DdBm. For a      radar noise jammer, indicates the peak of the transmitted power. */
   protected float  _effectiveRadiatedPower;

   /** Average repetition frequency of the emission in hertz. */
   protected float  _pulseRepetitionFrequency;

   /** Average pulse width  of the emission in microseconds. */
   protected float  _pulseWidth;

   /** Specifies the beam azimuth an elevation centers and corresponding half-angles     to describe the scan volume */
   protected float  _beamAzimuthCenter;

   /** Specifies the beam azimuth sweep to determine scan volume */
   protected float  _beamAzimuthSweep;

   /** Specifies the beam elevation center to determine scan volume */
   protected float  _beamElevationCenter;

   /** Specifies the beam elevation sweep to determine scan volume */
   protected float  _beamElevationSweep;

   /** allows receiver to synchronize its regenerated scan pattern to     that of the emmitter. Specifies the percentage of time a scan is through its pattern from its origion. */
   protected float  _beamSweepSync;


/** Constructor */
   ///<summary>
   ///Section 5.2.22. Contains electromagnetic emmision regineratin parameters that are        variable throughout a scenario dependent on the actions of the participants in the simulation. Also provides basic parametric data that may be used to support low-fidelity simulations.
   ///</summary>
 public FundamentalParameterData()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 4;  // _frequency
   marshalSize = marshalSize + 4;  // _frequencyRange
   marshalSize = marshalSize + 4;  // _effectiveRadiatedPower
   marshalSize = marshalSize + 4;  // _pulseRepetitionFrequency
   marshalSize = marshalSize + 4;  // _pulseWidth
   marshalSize = marshalSize + 4;  // _beamAzimuthCenter
   marshalSize = marshalSize + 4;  // _beamAzimuthSweep
   marshalSize = marshalSize + 4;  // _beamElevationCenter
   marshalSize = marshalSize + 4;  // _beamElevationSweep
   marshalSize = marshalSize + 4;  // _beamSweepSync

   return marshalSize;
}


   ///<summary>
   ///center frequency of the emission in hertz.
   ///</summary>
public void setFrequency(float pFrequency)
{ _frequency = pFrequency;
}

[XmlElement(Type= typeof(float), ElementName="frequency")]
public float Frequency
{
     get
{
          return _frequency;
}
     set
{
          _frequency = value;
}
}

   ///<summary>
   ///Bandwidth of the frequencies corresponding to the fequency field.
   ///</summary>
public void setFrequencyRange(float pFrequencyRange)
{ _frequencyRange = pFrequencyRange;
}

[XmlElement(Type= typeof(float), ElementName="frequencyRange")]
public float FrequencyRange
{
     get
{
          return _frequencyRange;
}
     set
{
          _frequencyRange = value;
}
}

   ///<summary>
   ///Effective radiated power for the emission in DdBm. For a      radar noise jammer, indicates the peak of the transmitted power.
   ///</summary>
public void setEffectiveRadiatedPower(float pEffectiveRadiatedPower)
{ _effectiveRadiatedPower = pEffectiveRadiatedPower;
}

[XmlElement(Type= typeof(float), ElementName="effectiveRadiatedPower")]
public float EffectiveRadiatedPower
{
     get
{
          return _effectiveRadiatedPower;
}
     set
{
          _effectiveRadiatedPower = value;
}
}

   ///<summary>
   ///Average repetition frequency of the emission in hertz.
   ///</summary>
public void setPulseRepetitionFrequency(float pPulseRepetitionFrequency)
{ _pulseRepetitionFrequency = pPulseRepetitionFrequency;
}

[XmlElement(Type= typeof(float), ElementName="pulseRepetitionFrequency")]
public float PulseRepetitionFrequency
{
     get
{
          return _pulseRepetitionFrequency;
}
     set
{
          _pulseRepetitionFrequency = value;
}
}

   ///<summary>
   ///Average pulse width  of the emission in microseconds.
   ///</summary>
public void setPulseWidth(float pPulseWidth)
{ _pulseWidth = pPulseWidth;
}

[XmlElement(Type= typeof(float), ElementName="pulseWidth")]
public float PulseWidth
{
     get
{
          return _pulseWidth;
}
     set
{
          _pulseWidth = value;
}
}

   ///<summary>
   ///Specifies the beam azimuth an elevation centers and corresponding half-angles     to describe the scan volume
   ///</summary>
public void setBeamAzimuthCenter(float pBeamAzimuthCenter)
{ _beamAzimuthCenter = pBeamAzimuthCenter;
}

[XmlElement(Type= typeof(float), ElementName="beamAzimuthCenter")]
public float BeamAzimuthCenter
{
     get
{
          return _beamAzimuthCenter;
}
     set
{
          _beamAzimuthCenter = value;
}
}

   ///<summary>
   ///Specifies the beam azimuth sweep to determine scan volume
   ///</summary>
public void setBeamAzimuthSweep(float pBeamAzimuthSweep)
{ _beamAzimuthSweep = pBeamAzimuthSweep;
}

[XmlElement(Type= typeof(float), ElementName="beamAzimuthSweep")]
public float BeamAzimuthSweep
{
     get
{
          return _beamAzimuthSweep;
}
     set
{
          _beamAzimuthSweep = value;
}
}

   ///<summary>
   ///Specifies the beam elevation center to determine scan volume
   ///</summary>
public void setBeamElevationCenter(float pBeamElevationCenter)
{ _beamElevationCenter = pBeamElevationCenter;
}

[XmlElement(Type= typeof(float), ElementName="beamElevationCenter")]
public float BeamElevationCenter
{
     get
{
          return _beamElevationCenter;
}
     set
{
          _beamElevationCenter = value;
}
}

   ///<summary>
   ///Specifies the beam elevation sweep to determine scan volume
   ///</summary>
public void setBeamElevationSweep(float pBeamElevationSweep)
{ _beamElevationSweep = pBeamElevationSweep;
}

[XmlElement(Type= typeof(float), ElementName="beamElevationSweep")]
public float BeamElevationSweep
{
     get
{
          return _beamElevationSweep;
}
     set
{
          _beamElevationSweep = value;
}
}

   ///<summary>
   ///allows receiver to synchronize its regenerated scan pattern to     that of the emmitter. Specifies the percentage of time a scan is through its pattern from its origion.
   ///</summary>
public void setBeamSweepSync(float pBeamSweepSync)
{ _beamSweepSync = pBeamSweepSync;
}

[XmlElement(Type= typeof(float), ElementName="beamSweepSync")]
public float BeamSweepSync
{
     get
{
          return _beamSweepSync;
}
     set
{
          _beamSweepSync = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {
       dos.writeFloat((float)_frequency);
       dos.writeFloat((float)_frequencyRange);
       dos.writeFloat((float)_effectiveRadiatedPower);
       dos.writeFloat((float)_pulseRepetitionFrequency);
       dos.writeFloat((float)_pulseWidth);
       dos.writeFloat((float)_beamAzimuthCenter);
       dos.writeFloat((float)_beamAzimuthSweep);
       dos.writeFloat((float)_beamElevationCenter);
       dos.writeFloat((float)_beamElevationSweep);
       dos.writeFloat((float)_beamSweepSync);
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
       _frequency = dis.readFloat();
       _frequencyRange = dis.readFloat();
       _effectiveRadiatedPower = dis.readFloat();
       _pulseRepetitionFrequency = dis.readFloat();
       _pulseWidth = dis.readFloat();
       _beamAzimuthCenter = dis.readFloat();
       _beamAzimuthSweep = dis.readFloat();
       _beamElevationCenter = dis.readFloat();
       _beamElevationSweep = dis.readFloat();
       _beamSweepSync = dis.readFloat();
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
    sb.Append("<FundamentalParameterData>"  + System.Environment.NewLine);
    try 
    {
           sb.Append("<frequency type=\"float\">" + _frequency.ToString() + "</frequency> " + System.Environment.NewLine);
           sb.Append("<frequencyRange type=\"float\">" + _frequencyRange.ToString() + "</frequencyRange> " + System.Environment.NewLine);
           sb.Append("<effectiveRadiatedPower type=\"float\">" + _effectiveRadiatedPower.ToString() + "</effectiveRadiatedPower> " + System.Environment.NewLine);
           sb.Append("<pulseRepetitionFrequency type=\"float\">" + _pulseRepetitionFrequency.ToString() + "</pulseRepetitionFrequency> " + System.Environment.NewLine);
           sb.Append("<pulseWidth type=\"float\">" + _pulseWidth.ToString() + "</pulseWidth> " + System.Environment.NewLine);
           sb.Append("<beamAzimuthCenter type=\"float\">" + _beamAzimuthCenter.ToString() + "</beamAzimuthCenter> " + System.Environment.NewLine);
           sb.Append("<beamAzimuthSweep type=\"float\">" + _beamAzimuthSweep.ToString() + "</beamAzimuthSweep> " + System.Environment.NewLine);
           sb.Append("<beamElevationCenter type=\"float\">" + _beamElevationCenter.ToString() + "</beamElevationCenter> " + System.Environment.NewLine);
           sb.Append("<beamElevationSweep type=\"float\">" + _beamElevationSweep.ToString() + "</beamElevationSweep> " + System.Environment.NewLine);
           sb.Append("<beamSweepSync type=\"float\">" + _beamSweepSync.ToString() + "</beamSweepSync> " + System.Environment.NewLine);
    sb.Append("</FundamentalParameterData>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(FundamentalParameterData a, FundamentalParameterData b)
        {
                return !(a == b);
        }

        public static bool operator ==(FundamentalParameterData a, FundamentalParameterData b)
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
 public bool equals(FundamentalParameterData rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;

     if( ! (_frequency == rhs._frequency)) ivarsEqual = false;
     if( ! (_frequencyRange == rhs._frequencyRange)) ivarsEqual = false;
     if( ! (_effectiveRadiatedPower == rhs._effectiveRadiatedPower)) ivarsEqual = false;
     if( ! (_pulseRepetitionFrequency == rhs._pulseRepetitionFrequency)) ivarsEqual = false;
     if( ! (_pulseWidth == rhs._pulseWidth)) ivarsEqual = false;
     if( ! (_beamAzimuthCenter == rhs._beamAzimuthCenter)) ivarsEqual = false;
     if( ! (_beamAzimuthSweep == rhs._beamAzimuthSweep)) ivarsEqual = false;
     if( ! (_beamElevationCenter == rhs._beamElevationCenter)) ivarsEqual = false;
     if( ! (_beamElevationSweep == rhs._beamElevationSweep)) ivarsEqual = false;
     if( ! (_beamSweepSync == rhs._beamSweepSync)) ivarsEqual = false;

    return ivarsEqual;
 }
} // end of class
} // end of namespace
