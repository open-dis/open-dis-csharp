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
using System.Text;
using OpenDis.Dis1998;

namespace OpenDis.Core
{
    /// <summary>
    /// Chunk Convertor for DIS 1998 (note: same methods could be reused with 1995).
    /// </summary>
    public static class DIS1998ChunkConverter
    {
		#region Methods (9)  

        /// <summary>
        /// Method to convert a byte Array into Eigh tByte Chunks
        /// </summary>
        /// <param name="data">Byte array that contains data to convert</param>
        /// <returns>List containing EightByteChunks</returns>
        public static List<EightByteChunk> ArrayToEightByteChunks(Array data)
        {
            //If no data exists return null
            if (data.Length == 0)
            {
                return null;
            }

            // Used to get the length of the data
            EightByteChunk byteChunkData = new EightByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            // Calculate the size if not on the byte boundary then all 1 to make it so
            int maxSize = System.Convert.ToInt32(Math.Ceiling((double)data.Length / (double)lengthByteChunkData)); //PES09182009 Modified so it would also work on Mobile

            // Create buffer to hold the data passed in from the array
            byte[] chunkBuffer = new byte[maxSize * lengthByteChunkData];

            // Copy data to the buffer created above
            Buffer.BlockCopy(data, 0, chunkBuffer, 0, data.Length);

            List<EightByteChunk> byteChunkList = new List<EightByteChunk>();

            // Iterate over the buffer and grab the appropriate number of bytes, store into the List
            for (int i = 0; i < maxSize; i++)
            {
                byteChunkData = new EightByteChunk();
                Buffer.BlockCopy(chunkBuffer, i * lengthByteChunkData, byteChunkData.OtherParameters, 0, lengthByteChunkData);

                byteChunkList.Add(byteChunkData);
            }

            return byteChunkList;
        }

        /// <summary>
        /// Method to convert a byte Array into Four tByte Chunks
        /// </summary>
        /// <param name="data">Byte array that contains data to convert</param>
        /// <returns>List containing FourByteChunks</returns>
        public static List<FourByteChunk> ArrayToFourByteChunks(Array data)
        {
            if (data.Length == 0)
            {
                return null;
            }

            FourByteChunk byteChunkData = new FourByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            // PES09182009 Modified so it would also work on Mobile
            int maxSize = System.Convert.ToInt32(Math.Ceiling((double)data.Length / (double)lengthByteChunkData));

            byte[] chunkBuffer = new byte[maxSize * lengthByteChunkData];
            Buffer.BlockCopy(data, 0, chunkBuffer, 0, data.Length);

            List<FourByteChunk> byteChunkList = new List<FourByteChunk>();

            for (int i = 0; i < maxSize; i++)
            {
                byteChunkData = new FourByteChunk();
                Buffer.BlockCopy(chunkBuffer, i * lengthByteChunkData, byteChunkData.OtherParameters, 0, lengthByteChunkData);

                byteChunkList.Add(byteChunkData);
            }

            return byteChunkList;
        }

        /// <summary>
        /// Method to convert a byte Array into Two tByte Chunks
        /// </summary>
        /// <param name="data">Byte array that contains data to convert</param>
        /// <returns>List containing TwoByteChunks</returns>
        public static List<TwoByteChunk> ArrayToTwoByteChunks(Array data)
        {
            if (data.Length == 0)
            {
                return null;
            }

            TwoByteChunk byteChunkData = new TwoByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            // PES09182009 Modified so it would also work on Mobile
            int maxSize = System.Convert.ToInt32(Math.Ceiling((double)data.Length / (double)lengthByteChunkData));

            byte[] chunkBuffer = new byte[maxSize * lengthByteChunkData];
            Buffer.BlockCopy(data, 0, chunkBuffer, 0, data.Length);

            List<TwoByteChunk> byteChunkList = new List<TwoByteChunk>();

            for (int i = 0; i < maxSize; i++)
            {
                byteChunkData = new TwoByteChunk();
                Buffer.BlockCopy(chunkBuffer, i * lengthByteChunkData, byteChunkData.OtherParameters, 0, lengthByteChunkData);

                byteChunkList.Add(byteChunkData);
            }

            return byteChunkList;
        }

        /// <summary>
        /// Method to convert Eight Byte Chunks into an Array
        /// </summary>
        /// <param name="chunkList">List that holds the EightByteChunks</param>
        /// <returns>Byte array</returns>
        public static Array EightByteChunksToArray(List<EightByteChunk> chunkList)
        {
            EightByteChunk byteChunkData = new EightByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            //Data passed in does not exist.
            if (chunkList.Count == 0)
            {
                return null;
            }

            // Create the appropriate sized buffer for this type
            byte[] chunkBuffer = new byte[chunkList.Count * lengthByteChunkData];

            // Go through each item and append to the buffer
            for (int i = 0; i < chunkList.Count; i++)
            {
                Buffer.BlockCopy(chunkList[i].OtherParameters, 0, chunkBuffer, i * lengthByteChunkData, lengthByteChunkData);
            }

            return (Array)chunkBuffer;
        }

        /// <summary>
        /// Method to convert Four Byte Chunks into an Array
        /// </summary>
        /// <param name="chunkList">List that holds the FourByteChunks</param>
        /// <returns>Byte array</returns>
        public static Array FourByteChunksToArray(List<FourByteChunk> chunkList)
        {
            FourByteChunk byteChunkData = new FourByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            // Data passed in does not exist.
            if (chunkList.Count == 0)
            {
                return null;
            }

            byte[] chunkBuffer = new byte[chunkList.Count * lengthByteChunkData];

            for (int i = 0; i < chunkList.Count; i++)
            {
                Buffer.BlockCopy(chunkList[i].OtherParameters, 0, chunkBuffer, i * lengthByteChunkData, lengthByteChunkData);
            }

            return (Array)chunkBuffer;
        }

        /// <summary>
        /// Method to convert a string into Eight Byte Chunks into an Array.  This method was provided as a means to transport 'other'
        /// types of data via a PDU that uses variable or fixed Datum.
        /// </summary>
        /// <param name="data">String data to convert</param>
        /// <returns>List of EightByteChunk data</returns>
        public static List<EightByteChunk> StringToEightByteChunks(string data)
        {
            // If data does not exist return null
            if (data.Length == 0)
            {
                return null;
            }

            // Using standard ascii encoding
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();

            // Convert string into bytes
            Array dataArray = encoding.GetBytes(data);

            return ArrayToEightByteChunks(dataArray);
        }

        /// <summary>
        /// Method to convert a string into Four Byte Chunks into an Array.  This method was provided as a means to transport 'other'
        /// types of data via a PDU that uses variable or fixed Datum.
        /// </summary>
        /// <param name="data">String data to convert</param>
        /// <returns>List of FourByteChunk data</returns>
        public static List<FourByteChunk> StringToFourByteChunks(string data)
        {
            if (data.Length == 0)
            {
                return null;
            }

            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            Array dataArray = encoding.GetBytes(data);

            return ArrayToFourByteChunks(dataArray);
        }

        /// <summary>
        /// Method to convert a string into Two Byte Chunks into an Array.  This method was provided as a means to transport 'other'
        /// types of data via a PDU that uses variable or fixed Datum.
        /// </summary>
        /// <param name="data">String data to convert</param>
        /// <returns>List of TwoByteChunk data</returns>
        public static List<TwoByteChunk> StringToTwoByteChunks(string data)
        {
            if (data.Length == 0)
            {
                return null;
            }

            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            Array dataArray = encoding.GetBytes(data);

            return ArrayToTwoByteChunks(dataArray);
        }

        /// <summary>
        /// Method to convert Two Byte Chunks into an Array
        /// </summary>
        /// <param name="chunkList">List that holds the TwoByteChunks</param>
        /// <returns>Byte array</returns>
        public static Array TwoByteChunksToArray(List<TwoByteChunk> chunkList)
        {
            TwoByteChunk byteChunkData = new TwoByteChunk();
            int lengthByteChunkData = byteChunkData.OtherParameters.Length;

            // Data passed in does not exist.
            if (chunkList.Count == 0)
            {
                return null;
            }

            byte[] chunkBuffer = new byte[chunkList.Count * lengthByteChunkData];

            for (int i = 0; i < chunkList.Count; i++)
            {
                Buffer.BlockCopy(chunkList[i].OtherParameters, 0, chunkBuffer, i * lengthByteChunkData, lengthByteChunkData);
            }

            return (Array)chunkBuffer;
        }

		#endregion Methods 
    }

    ///// <summary>
    ///// Class originally created to provide chunk data using reflection.  The method below does work, however I could not find a way to
    ///// use reflection going from an Array to the appropriate chunk type data (eg. EightByteChunk).
    ///// </summary>
    ///// <typeparam name="T">Type of Chunk data (eg. EightByteChunk)</typeparam>
    //public class ChunkConvertersUsingReflection<T> where T : class
    //{
    //    public Array ByteChunksToArrayUsingReflection(List<T> chunkList)
    //    {
    //        T[] bufferArray = new T[chunkList.Count];
    //        //Requires knowledge of the Property of the class.  In the Chunk classes each one contains the 'OtherParameters' property.  Note that
    //        //data has to exist within this otherwise an error will occur.  Try catch could be implemented.
    //        byte[] otherParameter = (byte[])chunkList[0].GetType().GetProperty("OtherParameters", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default).GetValue(chunkList[0], null);
    //        byte[] chunkBuffer = new byte[chunkList.Count * otherParameter.Length];
    //        for (int i = 0; i < bufferArray.Length; i++)
    //        {
    //            //Get the underlining data
    //            byte[] data = (byte[])chunkList[i].GetType().GetProperty("OtherParameters", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default).GetValue(chunkList[i], null);
    //            Buffer.BlockCopy(data, 0, chunkBuffer, i * otherParameter.Length, otherParameter.Length);
    //        }
    //        return chunkBuffer;
    //    }
    //}
}