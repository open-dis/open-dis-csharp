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

        protected const uint PDU_LENGTH_POSITION = 8;
        protected const uint PDU_TYPE_POSITION = 2;
        protected const uint PDU_VERSION_POSITION = 0;

        protected DISnet.DataStreamUtilities.EndianTypes.Endian edian = (BitConverter.IsLittleEndian ? DISnet.DataStreamUtilities.EndianTypes.Endian.LITTLE : DISnet.DataStreamUtilities.EndianTypes.Endian.BIG);
        protected System.Xml.Serialization.XmlSerializer xmlSerializedData;

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
        public DIS1998net.Pdu ConvertByteArrayToPDU1998(byte pdu_type, byte[] rawPDU, EndianTypes.Endian endian)
        {
            DIS1998net.Pdu pdu = DISnet.Utilities.PDUBank.GetPDU(pdu_type);
            DataInputStream ds = new DataInputStream(rawPDU, endian);
            
            //ReturnUnmarshalledPDU(pdu, ds);  //Removed this method to get rid of using Reflection
            return UnMarshalRawPDU(pdu_type, rawPDU, endian);
            //return pdu;
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

        //PES 09115009 Added to support passing back just the byte array into a Queue
        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buf">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <param name="dataQueue">Returns raw packets to a referenced Queue</param>
        public void ProcessRawPDU(byte[] buf, DISnet.DataStreamUtilities.EndianTypes.Endian endian, ref Queue<byte[]> dataQueue)
        {
            Endian = endian;

            foreach (byte[] pduRawByteArray in ProcessRawPDU(buf)) //Calling the method to get PDUs, increment through each in case more than one pdu in packet
            {
                dataQueue.Enqueue(pduRawByteArray);
            }
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

        //PES 09192009 This method used Reflection which is slow, new method 'UnMarshalRawPDU' should be used instead
        /// <summary>
        /// Unmarshal all data into the pdu object.  This method calls the all the base unmarshals.
        /// Deprecated:  This method used Reflection, use UnMarshalRawPDU method instead
        /// </summary>
        /// <param name="pdu">object where the unmarshalled data will be stored</param>
        /// <param name="dStream">location of where the unmarshalled data is located</param>
        private static void ReturnUnmarshalledPDU(object pdu, DataInputStream dStream)
        {
            //unmarshal is the method name found in each of the PDU classes
            pdu.GetType().InvokeMember("unmarshal", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { dStream });
        }

        virtual protected void ProcessPDU(Stream stream, out byte[] rawData)
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
                    Array.Reverse(buf, (int)PDU_LENGTH_POSITION, 2);
                }

                pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION);


                //Allocate space for the whole PDU
                rawData = new byte[pduLength];

                //Reset back to beginning
                stream.Position = startingPosition;

                //read in the whole PDU
                stream.Read(rawData, 0, pduLength);
            }
            catch (Exception ex)//Wow something bad just happened, could be bad/misalgined PDU
            {
                rawData = null;
            }
        }

        virtual protected object ProcessPDU(Stream stream)
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
                    Array.Reverse(buf, (int)PDU_LENGTH_POSITION, 2);
                }

                pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION);

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
        virtual protected List<object> ProcessPDU(byte[] buf)
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
                        Array.Reverse(buf, (int)PDU_LENGTH_POSITION, 2);
                    }

                    pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION + countBytes);

                    //Must be at end of datastream
                    if (pduLength == 0)
                        break;

                    pdu_type = buf[PDU_TYPE_POSITION + countBytes];

                    pdu_version = buf[PDU_VERSION_POSITION + countBytes];

                    byte[] PDUBufferStorage = new byte[pduLength];

                    //Could potentially be a problem since pduLength is an unsigned int,
                    //changed due to windows mobile does not accept a long for 4th parameter
                    Array.Copy(buf, countBytes, PDUBufferStorage, 0, (int)pduLength);

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
        virtual protected List<byte[]> ProcessRawPDU(byte[] buf)
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
                        Array.Reverse(buf, (int)PDU_LENGTH_POSITION + countBytes, 2);
                    }

                    pduLength = System.BitConverter.ToUInt16(buf, (int)PDU_LENGTH_POSITION + countBytes);

                    //Must be at end of datastream
                    if (pduLength == 0)
                        break;

                    pdu_type = buf[PDU_TYPE_POSITION + countBytes];

                    pdu_version = buf[PDU_VERSION_POSITION + countBytes];

                    byte[] PDUBufferStorage = new byte[pduLength];

                    //Could potentially be a problem since pduLength is an unsigned int,
                    //changed due to windows mobile does not accept a long for 4th parameter
                    Array.Copy(buf, countBytes, PDUBufferStorage, 0, (int)pduLength); 

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
        virtual protected object SwitchOnType(byte pdu_version, uint pdu_type, byte[] ds)
        {
            object pdu = null;

            DataInputStream dStream = new DataInputStream(ds, this.Endian);

            switch (pdu_version)
            {
                case 5: //1995
                    break;
                case 6: //1998
                    //pdu = DISnet.Utilities.PDUBank.GetPDU(pdu_type);
                    pdu = UnMarshalRawPDU((PDUTypes.PDUType1998)pdu_type, dStream);
                    break;
                default:
                    break;
            }

            //if (pdu != null)
            //{
            //    //Call the method of the underlining Type vice the Upper class method.
            //    ReturnUnmarshalledPDU(pdu, dStream);
            //}

            return pdu;
        }

        //PES 09182009  Added to work with Mobile 
        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pdu_type">PDU type</param>
        /// <param name="rawPDU">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <returns></returns>
        public static DIS1998net.Pdu UnMarshalRawPDU(byte pdu_type, byte[] rawPDU, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            DataInputStream ds = new DataInputStream(rawPDU, endian);
            return UnMarshalRawPDU((PDUTypes.PDUType1998)pdu_type, ds);
        }
        //PES 09182009  Added to work with Mobile
        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pdu_type">PDU type</param>
        /// <param name="ds">Datastream which contains the raw packet and Endian Type</param>
        /// <returns></returns>
        public static DIS1998net.Pdu UnMarshalRawPDU(byte pdu_type, DataInputStream ds)
        {
            return UnMarshalRawPDU((PDUTypes.PDUType1998)pdu_type, ds);
        }

        //PES 09182009  Added to work with Mobile 
        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pdu_type">PDU type</param>
        /// <param name="rawPDU">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <returns></returns>
        public static DIS1998net.Pdu UnMarshalRawPDU(DISnet.Utilities.PDUTypes.PDUType1998 pdu_type, byte[] rawPDU, DISnet.DataStreamUtilities.EndianTypes.Endian endian)
        {
            DataInputStream ds = new DataInputStream(rawPDU, endian);
            return UnMarshalRawPDU(pdu_type, ds);
        }

        //PES 09182009  Added to work with Mobile
        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pdu_type">PDU type</param>
        /// <param name="ds">Datastream which contains the raw packet and Endian Type</param>
        /// <returns></returns>
        public static DIS1998net.Pdu UnMarshalRawPDU(DISnet.Utilities.PDUTypes.PDUType1998 pdu_type, DataInputStream ds)
        {
            DIS1998net.Pdu pdu = new DIS1998net.Pdu();

            switch (pdu_type)
            {
                case PDUTypes.PDUType1998.PDU_ENTITY_STATE:
                    DIS1998net.EntityStatePdu EntityStatePdu = new DIS1998net.EntityStatePdu();
                    EntityStatePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)EntityStatePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_FIRE:
                    DIS1998net.FirePdu FirePdu = new DIS1998net.FirePdu();
                    FirePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)FirePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_DETONATION:
                    DIS1998net.DetonationPdu DetonationPdu = new DIS1998net.DetonationPdu();
                    DetonationPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)DetonationPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_COLLISION:
                    DIS1998net.CollisionPdu CollisionPdu = new DIS1998net.CollisionPdu();
                    CollisionPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)CollisionPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_SERVICE_REQUEST:
                    DIS1998net.ServiceRequestPdu ServiceRequestPdu = new DIS1998net.ServiceRequestPdu();
                    ServiceRequestPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ServiceRequestPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_OFFER:
                    DIS1998net.ResupplyOfferPdu ResupplyOfferPdu = new DIS1998net.ResupplyOfferPdu();
                    ResupplyOfferPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ResupplyOfferPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_RECEIVED:
                    DIS1998net.ResupplyReceivedPdu ResupplyReceivedPdu = new DIS1998net.ResupplyReceivedPdu();
                    ResupplyReceivedPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ResupplyReceivedPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_CANCEL:
                    DIS1998net.ResupplyCancelPdu ResupplyCancelPdu = new DIS1998net.ResupplyCancelPdu();
                    ResupplyCancelPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ResupplyCancelPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_REPAIR_COMPLETE:
                    DIS1998net.RepairCompletePdu RepairCompletePdu = new DIS1998net.RepairCompletePdu();
                    RepairCompletePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)RepairCompletePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_REPAIR_RESPONSE:
                    DIS1998net.RepairResponsePdu RepairResponsePdu = new DIS1998net.RepairResponsePdu();
                    RepairResponsePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)RepairResponsePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_CREATE_ENTITY:
                    DIS1998net.CreateEntityPdu CreateEntityPdu = new DIS1998net.CreateEntityPdu();
                    CreateEntityPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)CreateEntityPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_REMOVE_ENTITY:
                    DIS1998net.RemoveEntityPdu RemoveEntityPdu = new DIS1998net.RemoveEntityPdu();
                    RemoveEntityPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)RemoveEntityPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_START_RESUME:
                    DIS1998net.StartResumePdu StartResumePdu = new DIS1998net.StartResumePdu();
                    StartResumePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)StartResumePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_ACKNOWLEDGE:
                    DIS1998net.AcknowledgePdu AcknowledgePdu = new DIS1998net.AcknowledgePdu();
                    AcknowledgePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)AcknowledgePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_ACTION_REQUEST:
                    DIS1998net.ActionRequestPdu ActionRequestPdu = new DIS1998net.ActionRequestPdu();
                    ActionRequestPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ActionRequestPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_ACTION_RESPONSE:
                    DIS1998net.ActionResponsePdu ActionResponsePdu = new DIS1998net.ActionResponsePdu();
                    ActionResponsePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)ActionResponsePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_DATA_QUERY:
                    DIS1998net.DataQueryPdu DataQueryPdu = new DIS1998net.DataQueryPdu();
                    DataQueryPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)DataQueryPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_SET_DATA:
                    DIS1998net.SetDataPdu SetDataPdu = new DIS1998net.SetDataPdu();
                    SetDataPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)SetDataPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_EVENT_REPORT:
                    DIS1998net.EventReportPdu EventReportPdu = new DIS1998net.EventReportPdu();
                    EventReportPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)EventReportPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_COMMENT:
                    DIS1998net.CommentPdu CommentPdu = new DIS1998net.CommentPdu();
                    CommentPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)CommentPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_STOP_FREEZE:
                    DIS1998net.StopFreezePdu StopFreezePdu = new DIS1998net.StopFreezePdu();
                    StopFreezePdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)StopFreezePdu;
                    break;
                case PDUTypes.PDUType1998.PDU_SIGNAL:
                    DIS1998net.SignalPdu SignalPdu = new DIS1998net.SignalPdu();
                    SignalPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)SignalPdu;
                    break;
                case PDUTypes.PDUType1998.PDU_TRANSMITTER:
                    DIS1998net.TransmitterPdu transmitterPdu = new DIS1998net.TransmitterPdu();
                    transmitterPdu.unmarshal(ds);
                    pdu = (DIS1998net.Pdu)transmitterPdu;
                    break;
            }

            return pdu;
        }

        #endregion Methods
    }
}
