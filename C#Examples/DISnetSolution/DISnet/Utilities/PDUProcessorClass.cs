#region Header

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

#endregion Header

namespace DISnet.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using DISnet.DataStreamUtilities;

    /* Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
    * Modifications: none
    * Notes:
    */
    public class PDUProcessor
    {
        #region Fields

        private const uint PDU_LENGTH_POSITION = 8;
        private const uint PDU_TYPE_POSITION = 2;
        private const uint PDU_VERSION_POSITION = 0;

        private DISnet.DataStreamUtilities.EndianTypes.Endian edian = (BitConverter.IsLittleEndian ? DISnet.DataStreamUtilities.EndianTypes.Endian.LITTLE : DISnet.DataStreamUtilities.EndianTypes.Endian.BIG);
        private System.Xml.Serialization.XmlSerializer xmlSerializedData;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Type of endian used to process the data
        /// </summary>
        public DISnet.DataStreamUtilities.EndianTypes.Endian Endian
        {
            get
            {
                return this.edian;
            }

            set
            {
                this.edian = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Converts a byte array into a DIS1998 PDU
        /// </summary>
        /// <param name="rawPDU">Byte array that hold raw 1998 PDU</param>
        /// <param name="pdu_type">Type of pdu</param>
        /// <returns>PDU object</returns>
        public DIS1998net.Pdu ConvertByteArrayToPDU1998(uint pdu_type, byte[] rawPDU, EndianTypes.Endian endian)
        {
            DIS1998net.Pdu pdu = DISnet.Utilities.PDUBank.GetPDU(pdu_type);
            DataInputStream ds = new DataInputStream(rawPDU, endian);
            ReturnUnmarshalledPDU(pdu, ds);
            return pdu;
        }

        /// <summary>
        /// Provided as a means to return a string representation of the underlining PDU data.  Note format is not yet optimized.
        /// </summary>
        /// <param name="pdu">PDU to parse</param>
        /// <returns>StringBuilder that represents the state of the PDU</returns>
        public StringBuilder DecodePDU(object pdu)
        {
            StringBuilder sb = new StringBuilder();
            pdu.GetType().InvokeMember("reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });

            return sb;
        }

        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buf">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <returns>Collection of PDUs which are represented in base object class</returns>
        public List<object> ProcessPDU(byte[] buf, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            Endian = endian;
            return ProcessPDU(buf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="endian"></param>
        /// <param name="length">The standard size of a PDU header.  The size of the pdu will be read from the header. 
        /// Note: This value could have been a const but wanted to be more flexible</param>
        /// <returns></returns>
        public object ProcessPDU(Stream stream, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            Endian = endian;
            return ProcessPDU(stream);
        }

        public void ProcessPDU(Stream stream, DISnet.DataStreamUtilities.EndianTypes.Endian endian, out byte[] rawPDU)
        {
            Endian = endian;
            ProcessPDU(stream, out rawPDU);
        }

        //PES 09112009 Added to support passing back just the byte array
        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buf">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <returns>Collection of Raw byte[] PDUs</returns>
        public List<byte[]> ProcessRawPDU(byte[] buf, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            Endian = endian;
            return ProcessRawPDU(buf);
        }

        /// <summary>
        /// Returns an XML version of the reflected PDU
        /// </summary>
        /// <param name="pdu">PDU to reflect into XML</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder XmlDecodePDU(object pdu)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();

            try
            {
                xmlSerializedData = new XmlSerializer(pdu.GetType());
                xmlSerializedData.Serialize(stringWriter, pdu);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sb.Append(stringWriter.ToString());
                stringWriter.Close();
            }

            return sb;
        }

        /// <summary>
        /// Unmarshal all data into the pdu object.  This method calls the all the base unmarshals.
        /// </summary>
        /// <param name="pdu">object where the unmarshalled data will be stored</param>
        /// <param name="dStream">location of where the unmarshalled data is located</param>
        private static void ReturnUnmarshalledPDU(object pdu, DataInputStream dStream)
        {
            //unmarshal is the method name found in each of the PDU classes
            pdu.GetType().InvokeMember("unmarshal", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { dStream });
        }

        private void ProcessPDU(Stream stream, out byte[] rawData)
        {
            int upToPDULength = (int)PDU_LENGTH_POSITION + sizeof(UInt16);
            int pduLength = 0;

            long startingPosition = stream.Position;

            byte[] buf = new byte[upToPDULength];

            //Read in part of the stream up to the pdu length
            stream.Read(buf, 0, upToPDULength);

            try
            {
                if (this.edian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
                {
                    byte[] temp = new byte[sizeof(UInt16)];

                    Array.Copy(buf, (int)PDU_LENGTH_POSITION, temp, 0, temp.Length);
                    Array.Reverse(temp);
                    pduLength = System.BitConverter.ToUInt16(temp, 0);
                }
                else
                {
                    pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION);
                }

                //Allocate space for the whole PDU
                rawData = new byte[pduLength];

                //Reset back to beginning
                stream.Position = startingPosition;

                //read in the whole PDU
                stream.Read(rawData, 0, pduLength);

                //pdu_type = PDUBufferStorage[PDU_TYPE_POSITION];

                //pdu_version = PDUBufferStorage[PDU_VERSION_POSITION];

                //PDU = SwitchOnType(pdu_version, pdu_type, PDUBufferStorage);

            }
            catch (Exception ex)//Wow something bad just happened, could be bad/misalgined PDU
            {
                rawData = null;
            }
        }

        private object ProcessPDU(Stream stream)
        {
            int upToPDULength = (int)PDU_LENGTH_POSITION + sizeof(UInt16);
            int pduLength = 0;
            byte pdu_type;
            byte pdu_version;
            object PDU = null;

            long startingPosition = stream.Position;

            byte[] buf = new byte[upToPDULength];

            //Read in part of the stream up to the pdu length
            stream.Read(buf, 0, upToPDULength);

            try
            {
                if (this.edian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
                {
                    byte[] temp = new byte[sizeof(UInt16)];

                    Array.Copy(buf, (int)PDU_LENGTH_POSITION, temp, 0, temp.Length);
                    Array.Reverse(temp);
                    pduLength = System.BitConverter.ToUInt16(temp, 0);
                }
                else
                {
                    pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION);
                }

                //Allocate space for the whole PDU
                byte[] PDUBufferStorage = new byte[pduLength];

                //Reset back to beginning
                stream.Position = startingPosition;

                //read in the whole PDU
                stream.Read(PDUBufferStorage, 0, pduLength);

                pdu_type = PDUBufferStorage[PDU_TYPE_POSITION];

                pdu_version = PDUBufferStorage[PDU_VERSION_POSITION];

                PDU = SwitchOnType(pdu_version, pdu_type, PDUBufferStorage);

            }
            catch (Exception ex)//Wow something bad just happened, could be bad/misalgined PDU
            {
                PDU = null;
            }

            return PDU;
        }

        /// <summary>
        /// Process a received PDU.  Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <param name="buf">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) decoded</returns>
        private List<object> ProcessPDU(byte[] buf)
        {
            List<object> pduCollection = new List<object>();

            if (buf.Length < 1)
            {
                return pduCollection;
            }

            int length = buf.Length;
            byte pdu_type;
            byte pdu_version;
            int countBytes = 0;
            uint pduLength = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {

                    if (this.edian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
                    {
                        byte[] temp = new byte[sizeof(UInt16)];

                        Array.Copy(buf, (int)PDU_LENGTH_POSITION + countBytes, temp, 0, temp.Length);
                        Array.Reverse(temp);
                        pduLength = System.BitConverter.ToUInt16(temp, 0);
                    }
                    else
                    {
                        pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION + countBytes);
                    }

                    //Must be at end of datastream
                    if (pduLength == 0)
                        break;

                    pdu_type = buf[PDU_TYPE_POSITION + countBytes];

                    pdu_version = buf[PDU_VERSION_POSITION + countBytes];

                    byte[] PDUBufferStorage = new byte[pduLength];

                    Array.Copy(buf, countBytes, PDUBufferStorage, 0, (long)pduLength);

                    pduCollection.Add(SwitchOnType(pdu_version, pdu_type, PDUBufferStorage));

                    countBytes += (int)pduLength;

                }
                catch (Exception ex)//Wow something bad just happened, could be bad/misalgined PDU
                {
                    break;
                }
            }

            return pduCollection;
        }

        //PES 09112009 Added to support passing back just the byte array
        /// <summary>
        /// Process a received PDU.  Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <param name="buf">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) in raw byte format</returns>
        private List<byte[]> ProcessRawPDU(byte[] buf)
        {
            List<byte[]> pduCollection = new List<byte[]>();

            if (buf.Length < 1)
            {
                return pduCollection;
            }

            int length = buf.Length;
            byte pdu_type;
            byte pdu_version;
            int countBytes = 0;
            uint pduLength = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {

                    if (this.edian == DISnet.DataStreamUtilities.EndianTypes.Endian.BIG)
                    {
                        byte[] temp = new byte[sizeof(UInt16)];

                        Array.Copy(buf, (int)PDU_LENGTH_POSITION + countBytes, temp, 0, temp.Length);
                        Array.Reverse(temp);
                        pduLength = System.BitConverter.ToUInt16(temp, 0);
                    }
                    else
                    {
                        pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION + countBytes);
                    }

                    //Must be at end of datastream
                    if (pduLength == 0)
                        break;

                    pdu_type = buf[PDU_TYPE_POSITION + countBytes];

                    pdu_version = buf[PDU_VERSION_POSITION + countBytes];

                    byte[] PDUBufferStorage = new byte[pduLength];

                    Array.Copy(buf, countBytes, PDUBufferStorage, 0, (long)pduLength);

                    pduCollection.Add(PDUBufferStorage);

                    countBytes += (int)pduLength;

                }
                catch (Exception ex)//Wow something bad just happened, could be bad/misalgined PDU
                {
                    break;
                }
            }

            return pduCollection;
        }

        ///<summary>
        ///Returns an instance of the PDU based upon the pdu type passed in.  Note PDU will be represented as an Object for simplicity.
        ///</summary>
        ///<param name="pdu_version">Version of IEEE standard</param>
        ///<param name="pdu_type">Type of PDU</param>
        ///<param name="ds">PDU byte array containing the data</param>
        ///<returns></returns>         
        private object SwitchOnType(byte pdu_version, uint pdu_type, byte[] ds)
        {
            object pdu = null;

            DataInputStream dStream = new DataInputStream(ds, this.Endian);

            switch (pdu_version)
            {
                case 5: //1995
                    break;
                case 6: //1998
                    pdu = DISnet.Utilities.PDUBank.GetPDU(pdu_type);
                    break;
                default:
                    break;
            }

            if (pdu != null)
            {
                //Call the method of the underlining Type vice the Upper class method.
                ReturnUnmarshalledPDU(pdu, dStream);
            }

            return pdu;
        }

        #endregion Methods
    }
}