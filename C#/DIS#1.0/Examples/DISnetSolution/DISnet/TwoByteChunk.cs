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
 * 16 bit piece of data
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
public class TwoByteChunk : Object
{
   /** two bytes of arbitrary data */
   protected byte[]  _otherParameters = new byte[2]; 


/** Constructor */
   ///<summary>
   ///16 bit piece of data
   ///</summary>
 public TwoByteChunk()
 {
 }

public int getMarshalledSize()
{
   int marshalSize = 0; 

   marshalSize = marshalSize + 2 * 1;  // _otherParameters

   return marshalSize;
}


   ///<summary>
   ///two bytes of arbitrary data
   ///</summary>
public void setOtherParameters(byte[] pOtherParameters)
{ _otherParameters = pOtherParameters;
}

   ///<summary>
   ///two bytes of arbitrary data
   ///</summary>
public byte[] getOtherParameters()
{ return _otherParameters; }

   ///<summary>
   ///two bytes of arbitrary data
   ///</summary>
[XmlArray(ElementName="otherParameters")]
public byte[] OtherParameters
{
     get
{
          return _otherParameters;
}
     set
{
          _otherParameters = value;
}
}


///<summary>
///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
///</summary>
public void marshal(DataOutputStream dos)
{
    try 
    {

       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
           dos.writeByte(_otherParameters[idx]);
       } // end of array marshaling

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
       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
                _otherParameters[idx] = dis.readByte();
       } // end of array unmarshaling
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
    sb.Append("<TwoByteChunk>"  + System.Environment.NewLine);
    try 
    {

       for(int idx = 0; idx < _otherParameters.Length; idx++)
       {
           sb.Append("<otherParameters"+ idx.ToString() + " type=\"byte\">" + _otherParameters[idx] + "</otherParameters"+ idx.ToString() + "> " + System.Environment.NewLine);
       } // end of array reflection

    sb.Append("</TwoByteChunk>"  + System.Environment.NewLine);
    } // end try 
    catch(Exception e)
    { 
      Trace.WriteLine(e);
      Trace.Flush();
}
    } // end of marshal method

        public static bool operator !=(TwoByteChunk a, TwoByteChunk b)
        {
                return !(a == b);
        }

        public static bool operator ==(TwoByteChunk a, TwoByteChunk b)
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
 public bool equals(TwoByteChunk rhs)
 {
     bool ivarsEqual = true;

    if(rhs.GetType() != this.GetType())
        return false;


     for(int idx = 0; idx < 2; idx++)
     {
          if(!(_otherParameters[idx] == rhs._otherParameters[idx])) ivarsEqual = false;
     }


    return ivarsEqual;
 }
} // end of class
} // end of namespace
