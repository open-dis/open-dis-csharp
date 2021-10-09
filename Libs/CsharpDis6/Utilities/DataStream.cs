// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
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
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
// Modified by Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OpenDis.Core
{
    /// <summary>
    /// Base class for storing PDU information
    /// </summary>
    public class DataStream : IDisposable
    {
		#region Fields (1) 

        /// <summary>
        /// The endian type.
        /// </summary>
        private Endian endianType;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the DataStream class.  
        /// This will store all PDU information for either an InputStream or OutputStream.
        /// </summary>
        public DataStream()
        {
            // Test the machine to determine to see what it supports. 
            this.endianType = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);

            // create a new MemoryStream
            this.Stream = new MemoryStream();
        }

		#endregion Constructors 

		#region Properties (4) 

        /// <summary>
        /// Gets or sets the endian type
        /// </summary>
        public Endian Endian
        {
            get
            {
                return this.endianType;
            }

            set
            {
                this.endianType = value;
            }
        }

        /// <summary>
        /// Gets or sets the MemoryStream that will be used to hold the PDU data.
        /// </summary>
        public MemoryStream Stream
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location to store a byte representation of the PDU.
        /// </summary>
        public byte[] StreamByteArray
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the counter used to keep track of where pointer is for the stream.
        /// </summary>
        public int StreamCounter
        {
            get;
            set;
        }

		#endregion Properties 

		#region Methods (6) 

        /// <summary>
        /// Appends the byte array data to the MemoryStream
        /// </summary>
        /// <param name="data">byte array</param>
        public void Append(byte[] data)
        {
            this.Stream.Seek(this.Stream.Length, SeekOrigin.Begin);
            this.Stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Appends a single byte to the MemoryStream
        /// </summary>
        /// <param name="data"></param>
        public void Append(byte data)
        {
            this.Stream.Seek(this.Stream.Length, SeekOrigin.Begin);
            this.Stream.WriteByte(data);
        }

        /// <summary>
        /// Re-Initializes the MemoryStream and streamCounter back to zero
        /// </summary>
        public void Clear()
        {
            this.StreamCounter = 0;
            this.Stream = new MemoryStream();
        }

        /// <summary>
        /// Convert a MemoryStream to a byte array
        /// </summary>
        /// <returns>byte array</returns>
        public byte[] ConvertToBytes()
        {
            return ReturnByteArray(this.Stream.GetBuffer(), 0, (int)this.Stream.Length);
        }

        public void Dispose()
        {
            if (this.Stream != null)
            {
                try
                {
                    this.Stream.Close();
                    this.Stream.Dispose();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Returns a portion of a byte array for Endian conversion
        /// </summary>
        /// <param name="byteStream">source bytearray</param>
        /// <param name="startIndex">A 32-bit integer that represents the start index at which the conversion should begin</param>
        /// <param name="sizeOfData">A 32-bit integer that represents the size of the value type</param>
        /// <returns>A byte array that will hold the byte representation of the value</returns>
        public static byte[] ReturnByteArray(byte[] byteStream, int startIndex, int sizeOfData)
        {
            byte[] temp = new byte[sizeOfData];
            Array.Copy(byteStream, startIndex, temp, 0, sizeOfData);

            return temp;
        }

		#endregion Methods 
    }
}
