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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DISnet.DataStreamUtilities
{
    /* Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
* Modifications: none
* Notes:
*/

    /// <summary>
    /// Base class for storing PDU information
    /// </summary>
    public class DataStream
    {
        //Counter used to keep track of where pointer is for the stream
        public int streamCounter;
        //Create the MemoryStream that will be used to hold the PDU data
        public MemoryStream msPDU;
        //Location to store a byte representation of the PDU
        public byte[] byteStream;

        //Test the machine to determine to see what it supports, this will be the default but can be overridden via constructor
        private DISnet.DataStreamUtilities.EndianTypes.Endian endianType = (BitConverter.IsLittleEndian ? DISnet.DataStreamUtilities.EndianTypes.Endian.LITTLE : DISnet.DataStreamUtilities.EndianTypes.Endian.BIG);

        /// <summary>
        /// Create new DataStream.  This will store all PDU information for either an InputStream or OutputStream
        /// </summary>
        public DataStream()
        {
            //Set default counter value to 0
            streamCounter = 0;
            //Create a new MemoryStream
            msPDU = new MemoryStream();
        }

        /// <summary>
        /// Re-Initializes the MemoryStream and streamCounter back to zero
        /// </summary>
        public void clear()
        {
            streamCounter = 0;
            msPDU = new MemoryStream();
        }

        /// <summary>
        /// Convert a MemoryStream to a byte array
        /// </summary>
        /// <returns>byte array</returns>
        public byte[] ConvertToBytes()
        {
            byte[] returnBytes;

            ReturnByteArray(msPDU.GetBuffer(), 0, (int)msPDU.Length, out returnBytes);  //PES 09092009

            return returnBytes;
        }

        /// <summary>
        /// Used primarily to return a portion of a byte array for Endian conversion
        /// </summary>
        /// <param name="byteStream">source bytearray</param>
        /// <param name="startIndex">A 32-bit integer that represents the start index at which the conversion should begin</param>
        /// <param name="sizeOfData">A 32-bit integer that represents the size of the value type</param>
        /// <param name="temp">A byte array that will hold the byte representation of the value</param>
        public void ReturnByteArray(byte[] byteStream, int startIndex, int sizeOfData, out byte[] temp)
        {
            temp = new byte[sizeOfData];
            Array.Copy(byteStream, startIndex, temp, 0, sizeOfData);
        }

        /// <summary>
        /// Appends the byte array data to the MemoryStream
        /// </summary>
        /// <param name="data">byte array</param>
        public void Append(byte[] data)
        {
            msPDU.Seek(msPDU.Length, SeekOrigin.Begin);
            msPDU.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Appends a single byte to the MemoryStream
        /// </summary>
        /// <param name="data"></param>
        public void Append(byte data)
        {
            msPDU.Seek(msPDU.Length, SeekOrigin.Begin);
            msPDU.WriteByte(data);
        }

        /// <summary>
        /// Gets or Sets the Endian type
        /// </summary>
        public DISnet.DataStreamUtilities.EndianTypes.Endian Endian
        {
            get
            {
                return endianType;
            }

            set
            {
                endianType = value;
            }                
        }
    }

  
}
