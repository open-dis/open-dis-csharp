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
using System.Text;

namespace OpenDis.Core
{
    /// <summary>
    /// Class used to export PDU information from a DataStream
    /// </summary>
    public class DataOutputStream
    {
		#region Fields (1) 

        DataStream pduDataStream;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the DataOutputStream class from an 
        /// existing DataStream and sets Endian type to use.
        /// </summary>
        /// <param name="ds">The data stream.</param>
        /// <param name="endian">The endian to be used.</param>
        public DataOutputStream(DataStream ds, Endian endian)
        {
            this.pduDataStream = ds;
            this.Endian = endian;
        }

        /// <summary>
        /// Initializes a new instance of the DataOutputStream class and
        /// with Endian set to Little.
        /// </summary>
        /// <param name="endian">The endian to be used.</param>
        public DataOutputStream()
            : this(Endian.Little)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the DataOutputStream class and
        /// sets the Endian to use.
        /// </summary>
        /// <param name="endian">The endian to be used.</param>
        public DataOutputStream(Endian endian)
        {
            this.pduDataStream = new DataStream();
            this.Endian = endian;
        }

		#endregion Constructors 

		#region Properties (2) 

        /// <summary>
        /// Gets the underlining DataStream
        /// </summary>
        public DataStream DS
        {
            get
            {
                return this.pduDataStream;
            }
        }

        /// <summary>
        /// Gets or sets the Endian type
        /// </summary>
        public Endian Endian
        {
            get
            {
                return this.DS.Endian;
            }

            set
            {
                this.DS.Endian = value;
            }
        }

		#endregion Properties 

		#region Methods (15) 

        /// <summary>
        /// Converts the DataStream to a byte array
        /// </summary>
        /// <returns>byte array</returns>
        public byte[] ConvertToBytes()
        {
            return this.DS.ConvertToBytes();
        }

        /// <summary>
        /// Write a byte value to the DataStream
        /// </summary>
        /// <param name="data">byte</param>
        public void WriteByte(byte data)
        {
            this.WriteData(data);
        }

        /// <summary>
        /// Write a byte array value to the DataStream
        /// </summary>
        /// <param name="data">byte</param>
        public void WriteByte(byte[] data)
        {
            this.WriteData(data);
        }

        /// <summary>
        /// Write a double value to the DataStream
        /// </summary>
        /// <param name="data">double</param>
        public void WriteDouble(double data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a float value to the DataStream
        /// </summary>
        /// <param name="data">float</param>
        public void WriteFloat(float data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a int value to the DataStream
        /// </summary>
        /// <param name="data">int32</param>
        public void WriteInt(int data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a long value to the DataStream
        /// </summary>
        /// <param name="data">long</param>
        public void WriteLong(long data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a short value to the DataStream
        /// </summary>
        /// <param name="data">short value</param>
        public void WriteShort(short data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a byte value to the DataStream
        /// </summary>
        /// <param name="data">byte</param>
        public void WriteUnsignedByte(byte data)
        {
            this.WriteData(data);
        }

        /// <summary>
        /// Write a byte array value to the DataStream
        /// </summary>
        /// <param name="data">byte</param>
        public void WriteUnsignedByte(byte[] data)
        {
            this.WriteData(data);
        }

        /// <summary>
        /// Write a unsigned int value to the DataStream
        /// </summary>
        /// <param name="data">unsigned int</param>
        public void WriteUnsignedInt(uint data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a unsigned long value to the DataStream
        /// </summary>
        /// <param name="data">long</param>
        public void WriteUnsignedLong(ulong data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Write a unsigned short value to the DataStream
        /// </summary>
        /// <param name="data">unsigned short</param>
        public void WriteUnsignedShort(ushort data)
        {
            byte[] serializedData = System.BitConverter.GetBytes(data);

            if (this.Endian == Endian.Big)
            {
                Array.Reverse(serializedData);
            }

            this.WriteData(serializedData);
        }

        /// <summary>
        /// Base method to write a byte value to the DataStream
        /// </summary>
        /// <param name="data">byte</param>
        private void WriteData(byte data)
        {
            this.pduDataStream.Append(data);
            this.pduDataStream.StreamCounter += 1;
        }

        /// <summary>
        /// Base method to write an array of bytes to the DataStream
        /// </summary>
        /// <param name="data">byte array</param>
        private void WriteData(byte[] data)
        {
            this.pduDataStream.Append(data);
            this.pduDataStream.StreamCounter += data.Length;
        }

		#endregion Methods 
    }
}
