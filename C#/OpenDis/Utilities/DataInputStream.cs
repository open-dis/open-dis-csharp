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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace OpenDis.Core
{
    /// <summary>
    /// Class used to read in PDU Bytes via the DataStream class
    /// </summary>
    public class DataInputStream
    {
		#region Fields (1) 

        private DataStream pduDataStream;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInputStream"/> class with
        /// Endian set to Little.
        /// </summary>
        public DataInputStream()
            : this(Endian.Little)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInputStream"/> class.
        /// </summary>
        /// <param name="endian">The endian.</param>
        public DataInputStream(Endian endian)
        {
            this.pduDataStream = new DataStream();
            this.pduDataStream.StreamCounter = 0;
            this.Endian = endian;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInputStream"/> class.
        /// </summary>
        /// <param name="ds">byte array</param>
        /// <param name="endian">type of endian</param>
        public DataInputStream(byte[] ds, Endian endian)
            : this(endian)
        {
            this.pduDataStream.StreamByteArray = ds;
            this.pduDataStream.Endian = endian;
        }
        
		#endregion Constructors 

		#region Properties (1) 

        ///// <summary>
        ///// Used to convert an array of bytes to a MemoryStream
        ///// </summary>
        ///// <param name="data">byte array</param>
        ///// <returns>MemoryStream</returns>
        ////private MemoryStream ConvertBytesMemoryStream(byte[] data)
        ////{
        ////    MemoryStream ms = new MemoryStream();

        ////    ms.Write(data, 0, data.Length);

        ////    return ms;
        ////}

        /// <summary>
        /// Gets or sets the endian value currently being used to process PDU data
        /// </summary>
        public Endian Endian
        {
            get
            {
                return this.pduDataStream.Endian;
            }

            set
            {
                this.pduDataStream.Endian = value;
            }
        }

		#endregion Properties 

		#region Methods (11) 

        /// <summary>
        /// Reads from DataStream's byte array a byte
        /// </summary>
        /// <returns>byte value</returns>
        public byte ReadByte()
        {
            byte returnedData = this.pduDataStream.StreamByteArray[this.pduDataStream.StreamCounter];
            this.pduDataStream.StreamCounter++;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a byte
        /// </summary>
        /// <returns>byte value</returns>
        public byte[] ReadByteArray(int length)
        {
            byte[] returnedData = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, length);

            this.pduDataStream.StreamCounter += length;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a double value
        /// </summary>
        /// <returns>double value</returns>
        public double ReadDouble()
        {
            int size = sizeof(double);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            double returnedData = System.BitConverter.ToDouble(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a float value
        /// </summary>
        /// <returns>float value</returns>
        public float ReadFloat()
        {
            int size = sizeof(float);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            float returnedData = System.BitConverter.ToSingle(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array an int value
        /// </summary>
        /// <returns>int value</returns>
        public int ReadInt()
        {
            int size = sizeof(int);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            int returnedData = System.BitConverter.ToInt32(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;

        }

        /// <summary>
        /// Reads from DataStream's byte array a long
        /// </summary>
        /// <returns>long value</returns>
        public long ReadLong()
        {
            int size = sizeof(long);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            long returnedData = System.BitConverter.ToInt64(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a short value
        /// </summary>
        /// <returns>short value</returns>
        public short ReadShort()
        {
            int size = sizeof(short);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            short returnedData = System.BitConverter.ToInt16(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a byte
        /// </summary>
        /// <returns>byte value</returns>
        public byte ReadUnsignedByte()
        {
            return this.ReadByte();
        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned int
        /// </summary>
        /// <returns>unsigned int value</returns>
        public uint ReadUnsignedInt()
        {
            int size = sizeof(uint);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            uint returnedData = System.BitConverter.ToUInt32(temp, 0);

            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned long
        /// </summary>
        /// <returns>ulong value</returns>
        public ulong ReadUnsignedLong()
        {
            int size = sizeof(ulong);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            ulong returnedData = System.BitConverter.ToUInt64(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

        /// <summary>
        /// Reads from DataStream's byte array a unsigned short
        /// </summary>
        /// <returns>unsigned short value</returns>
        public ushort ReadUnsignedShort()
        {
            int size = sizeof(ushort);
            byte[] temp = DataStream.ReturnByteArray(this.pduDataStream.StreamByteArray, this.pduDataStream.StreamCounter, size);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(temp);
            }

            ushort returnedData = System.BitConverter.ToUInt16(temp, 0);
            this.pduDataStream.StreamCounter += size;
            return returnedData;
        }

		#endregion Methods 
    }
}
