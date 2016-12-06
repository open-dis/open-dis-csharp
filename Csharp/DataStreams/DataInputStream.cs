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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;

namespace DISnet.DataStreamUtilities
{  
    /* Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
  * Modifications: none
  * Notes:
  */

    /// <summary>
    /// Class used to read in PDU Bytes via the DataStream class
    /// </summary>
    public class DataInputStream
    {
        //Instantiate new DataStream
        private DISnet.DataStreamUtilities.DataStream dsPDU = new DataStream();

        /// <summary>
        /// Constructor to create new DataInput Stream based upon a byte array.  Default endian based upon DataStream class.
        /// </summary>
        /// <param name="ds">byte array</param>
        public DataInputStream(DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            dsPDU = new DataStream();
            dsPDU.streamCounter = 0;
            Endian = endian;
        }

        /// <summary>
        /// Constructor to create new Input DataStream based upon a byte array and endian.
        /// </summary>
        /// <param name="ds">byte array</param>
        /// <param name="endian">type of endian</param>
        public DataInputStream(byte[] ds, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            dsPDU.byteStream = ds;
            dsPDU.streamCounter = 0;
            dsPDU.Endian = endian;
        }


        /// <summary>
        /// Used to convert an array of bytes to a MemoryStream
        /// </summary>
        /// <param name="data">byte array</param>
        /// <returns>MemoryStream</returns>
        private MemoryStream ConvertBytesMemoryStream(byte[] data)
        {
            MemoryStream ms = new MemoryStream();

            ms.Write(data, 0, data.Length);

            return ms;
        }

        /// <summary>
        /// Endian value currently being used to process PDU data
        /// </summary>
        public DISnet.DataStreamUtilities.EndianTypes.Endian Endian
        {
            get
            {
                return dsPDU.Endian;
            }

            set
            {
                dsPDU.Endian = value;
            }
        }

        /// <summary>
        /// Reads from DataStream's byte array a short value
        /// </summary>
        /// <returns>short</returns>
        public short readShort()
        {
            byte[] temp;
            int size = sizeof(short);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }
            
            short returnedData = System.BitConverter.ToInt16(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a float value
        /// </summary>
        /// <returns>float</returns>
        public float readFloat()
        {
            byte[] temp;
            int size = sizeof(float);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            float returnedData = System.BitConverter.ToSingle(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array an int value
        /// </summary>
        /// <returns>int</returns>
        public int readInt()
        {
            byte[] temp;
            int size = sizeof(int);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            int returnedData = System.BitConverter.ToInt32(temp,0);
            dsPDU.streamCounter += size;
            return returnedData;

        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned short
        /// </summary>
        /// <returns>unsigned short</returns>
        public ushort readUshort()
        {
            byte[] temp;
            int size = sizeof(ushort);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            ushort returnedData = System.BitConverter.ToUInt16(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned int
        /// </summary>
        /// <returns>unsigned int</returns>
        public uint readUint()
        {
            byte[] temp;
            int size = sizeof(uint);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            uint returnedData = System.BitConverter.ToUInt32(temp, 0);

            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a byte
        /// </summary>
        /// <returns>byte</returns>
        public byte readByte()
        {
            byte returnedData = dsPDU.byteStream[dsPDU.streamCounter];
            dsPDU.streamCounter++;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a byte
        /// </summary>
        /// <returns>byte</returns>
        public byte[] readByteArray(int length)
        {
            byte[] returnedData;

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, length, out returnedData);

            dsPDU.streamCounter+=length;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a double value
        /// </summary>
        /// <returns>double</returns>
        public double readDouble()
        {
            byte[] temp;
            int size = sizeof(double);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            double returnedData = System.BitConverter.ToDouble(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a long
        /// </summary>
        /// <returns>long</returns>
        public long readLong()
        {
            byte[] temp;
            int size = sizeof(long);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            long returnedData = System.BitConverter.ToInt64(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned long
        /// </summary>
        /// <returns>ulong</returns>
        public ulong readUlong()
        {
            byte[] temp;
            int size = sizeof(ulong);

            this.dsPDU.ReturnByteArray(dsPDU.byteStream, dsPDU.streamCounter, size, out temp);

            if (this.Endian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
            {
                Array.Reverse(temp);
            }

            ulong returnedData = System.BitConverter.ToUInt64(temp, 0);
            dsPDU.streamCounter += size;
            return returnedData;
        }
        
    }
}
