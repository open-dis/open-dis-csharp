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
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using OpenDis.Dis1998;
using OpenDis.Enumerations;

namespace OpenDis.Core
{
    public class PduProcessor
    {
		#region Fields (5) 

        public const uint PDU_LENGTH_POSITION = 8;
        public const uint PDU_TYPE_POSITION = 2;
        public const uint PDU_VERSION_POSITION = 0;

        private Endian endian;
        private System.Xml.Serialization.XmlSerializer xmlSerializedData;

		#endregion Fields 

		#region Constructors (1) 

        public PduProcessor()
        {
            this.endian = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);
        }

		#endregion Constructors 

		#region Properties (1) 

        /// <summary>
        /// Gets or sets the type of endian used to process the data
        /// </summary>
        public Endian Endian
        {
            get
            {
                return this.endian;
            }

            set
            {
                this.endian = value;
            }
        }

		#endregion Properties 

		#region Methods (18) 

        /// <summary>
        /// Converts a byte array into a DIS1998 PDU
        /// </summary>
        /// <param name="pduType">Type of the PDU.</param>
        /// <param name="rawPdu">Byte array that hold raw 1998 PDU.</param>
        /// <param name="endian">The Endian type used for conversion.</param>
        /// <returns>PDU object</returns>
        public static Pdu ConvertByteArrayToPdu1998(byte pduType, byte[] rawPdu, Endian endian)
        {
            return UnmarshalRawPdu(pduType, rawPdu, endian);
        }

        /// <summary>
        /// Provided as a means to return a string representation of the underlining PDU data.  Note format is not yet optimized.
        /// </summary>
        /// <param name="pdu">The PDU to parse</param>
        /// <returns>StringBuilder that represents the state of the PDU</returns>
        public static StringBuilder DecodePdu(object pdu)
        {
            StringBuilder sb = new StringBuilder();
            pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb }, CultureInfo.InvariantCulture);

            return sb;
        }

        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buffer">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <returns>Collection of PDUs which are represented in base object class</returns>
        public List<object> ProcessPdu(byte[] buffer, Endian endian)
        {
            this.Endian = endian;
            return this.ProcessPdu(buffer);
        }

        /// <summary>
        /// Processes the pdu.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="endian">format of value types</param>
        /// <returns>The PDU instance.</returns>
        public object ProcessPdu(Stream stream, Endian endian)
        {
            this.Endian = endian;
            return this.ProcessPdu(stream);
        }

        /// <summary>
        /// Processes the pdu.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="endian">format of value types</param>
        /// <param name="rawPdu">The raw pdu.</param>
        public void ProcessPdu(Stream stream, Endian endian, out byte[] rawPdu)
        {
            this.Endian = endian;
            this.ProcessPdu(stream, out rawPdu);
        }

        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buf">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <remarks>Added to support passing back just the byte array.</remarks>
        /// <returns>Collection of Raw byte[] PDUs</returns>
        public List<byte[]> ProcessRawPdu(byte[] buffer, Endian endian)
        {
            this.Endian = endian;
            return this.ProcessRawPdu(buffer);
        }

        /// <summary>
        /// Provides a means of processing PDU data 
        /// </summary>
        /// <param name="buf">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <param name="dataQueue">Returns raw packets to a referenced Queue</param>
        /// <remarks>Added to support passing back just the byte array into a Queue.</remarks>
        public void ProcessRawPdu(byte[] buffer, Endian endian, ref Queue<byte[]> dataQueue)
        {
            this.Endian = endian;

            // Calling the method to get PDUs, increment through each in case more than one pdu in packet
            foreach (byte[] pduRawByteArray in this.ProcessRawPdu(buffer))
            {
                dataQueue.Enqueue(pduRawByteArray);
            }
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="ds">Datastream which contains the raw packet and Endian Type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance.</returns>
        public static Pdu UnmarshalRawPdu(byte pduType, DataInputStream ds)
        {
            return UnmarshalRawPdu((PduType)pduType, ds);
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="ds">Datastream which contains the raw packet and Endian Type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance.</returns>
        public static Pdu UnmarshalRawPdu(PduType pduType, DataInputStream ds)
        {
            Pdu pdu = new Pdu();

            switch (pduType)
            {
                case PduType.EntityState:
                    EntityStatePdu entityStatePdu = new EntityStatePdu();
                    entityStatePdu.Unmarshal(ds);
                    pdu = (Pdu)entityStatePdu;
                    break;
                case PduType.Fire:
                    FirePdu firePdu = new FirePdu();
                    firePdu.Unmarshal(ds);
                    pdu = (Pdu)firePdu;
                    break;
                case PduType.Detonation:
                    DetonationPdu detonationPdu = new DetonationPdu();
                    detonationPdu.Unmarshal(ds);
                    pdu = (Pdu)detonationPdu;
                    break;
                case PduType.Collision:
                    CollisionPdu collisionPdu = new CollisionPdu();
                    collisionPdu.Unmarshal(ds);
                    pdu = (Pdu)collisionPdu;
                    break;
                case PduType.ServiceRequest:
                    ServiceRequestPdu serviceRequestPdu = new ServiceRequestPdu();
                    serviceRequestPdu.Unmarshal(ds);
                    pdu = (Pdu)serviceRequestPdu;
                    break;
                case PduType.ResupplyOffer:
                    ResupplyOfferPdu resupplyOfferPdu = new ResupplyOfferPdu();
                    resupplyOfferPdu.Unmarshal(ds);
                    pdu = (Pdu)resupplyOfferPdu;
                    break;
                case PduType.ResupplyReceived:
                    ResupplyReceivedPdu resupplyReceivedPdu = new ResupplyReceivedPdu();
                    resupplyReceivedPdu.Unmarshal(ds);
                    pdu = (Pdu)resupplyReceivedPdu;
                    break;
                case PduType.ResupplyCancel:
                    ResupplyCancelPdu resupplyCancelPdu = new ResupplyCancelPdu();
                    resupplyCancelPdu.Unmarshal(ds);
                    pdu = (Pdu)resupplyCancelPdu;
                    break;
                case PduType.RepairComplete:
                    RepairCompletePdu repairCompletePdu = new RepairCompletePdu();
                    repairCompletePdu.Unmarshal(ds);
                    pdu = (Pdu)repairCompletePdu;
                    break;
                case PduType.RepairResponse:
                    RepairResponsePdu repairResponsePdu = new RepairResponsePdu();
                    repairResponsePdu.Unmarshal(ds);
                    pdu = (Pdu)repairResponsePdu;
                    break;
                case PduType.CreateEntity:
                    CreateEntityPdu createEntityPdu = new CreateEntityPdu();
                    createEntityPdu.Unmarshal(ds);
                    pdu = (Pdu)createEntityPdu;
                    break;
                case PduType.RemoveEntity:
                    RemoveEntityPdu removeEntityPdu = new RemoveEntityPdu();
                    removeEntityPdu.Unmarshal(ds);
                    pdu = (Pdu)removeEntityPdu;
                    break;
                case PduType.StartResume:
                    StartResumePdu startResumePdu = new StartResumePdu();
                    startResumePdu.Unmarshal(ds);
                    pdu = (Pdu)startResumePdu;
                    break;
                case PduType.Acknowledge:
                    AcknowledgePdu acknowledgePdu = new AcknowledgePdu();
                    acknowledgePdu.Unmarshal(ds);
                    pdu = (Pdu)acknowledgePdu;
                    break;
                case PduType.ActionRequest:
                    ActionRequestPdu actionRequestPdu = new ActionRequestPdu();
                    actionRequestPdu.Unmarshal(ds);
                    pdu = (Pdu)actionRequestPdu;
                    break;
                case PduType.ActionResponse:
                    ActionResponsePdu actionResponsePdu = new ActionResponsePdu();
                    actionResponsePdu.Unmarshal(ds);
                    pdu = (Pdu)actionResponsePdu;
                    break;
                case PduType.DataQuery:
                    DataQueryPdu dataQueryPdu = new DataQueryPdu();
                    dataQueryPdu.Unmarshal(ds);
                    pdu = (Pdu)dataQueryPdu;
                    break;
                case PduType.SetData:
                    SetDataPdu setDataPdu = new SetDataPdu();
                    setDataPdu.Unmarshal(ds);
                    pdu = (Pdu)setDataPdu;
                    break;
                case PduType.EventReport:
                    EventReportPdu eventReportPdu = new EventReportPdu();
                    eventReportPdu.Unmarshal(ds);
                    pdu = (Pdu)eventReportPdu;
                    break;
                case PduType.Comment:
                    CommentPdu commentPdu = new CommentPdu();
                    commentPdu.Unmarshal(ds);
                    pdu = (Pdu)commentPdu;
                    break;
                case PduType.StopFreeze:
                    StopFreezePdu stopFreezePdu = new StopFreezePdu();
                    stopFreezePdu.Unmarshal(ds);
                    pdu = (Pdu)stopFreezePdu;
                    break;
                case PduType.Signal:
                    SignalPdu signalPdu = new SignalPdu();
                    signalPdu.Unmarshal(ds);
                    pdu = (Pdu)signalPdu;
                    break;
                case PduType.Transmitter:
                    TransmitterPdu transmitterPdu = new TransmitterPdu();
                    transmitterPdu.Unmarshal(ds);
                    pdu = (Pdu)transmitterPdu;
                    break;
            }

            return pdu;
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="rawPDU">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance</returns>
        public static Pdu UnmarshalRawPdu(byte pduType, byte[] rawPdu, Endian endian)
        {
            DataInputStream ds = new DataInputStream(rawPdu, endian);
            return UnmarshalRawPdu((PduType)pduType, ds);
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="rawPDU">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance.</returns>
        public static Pdu UnmarshalRawPdu(PduType pduType, byte[] rawPdu, Endian endian)
        {
            DataInputStream ds = new DataInputStream(rawPdu, endian);
            return UnmarshalRawPdu(pduType, ds);
        }

        /// <summary>
        /// Returns an XML version of the reflected PDU
        /// </summary>
        /// <param name="pdu">PDU to reflect into XML</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder XmlDecodePdu(object pdu)
        {
            StringBuilder sb = new StringBuilder();

            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter(CultureInfo.InvariantCulture))
            {
                try
                {
                    this.xmlSerializedData = new XmlSerializer(pdu.GetType());
                    this.xmlSerializedData.Serialize(stringWriter, pdu);

                }
                catch
                {
                    throw;
                }
                finally
                {
                    sb.Append(stringWriter.ToString());
                    stringWriter.Close();
                }
            }

            return sb;
        }
		// Protected Methods (5) 

        protected virtual object ProcessPdu(Stream stream)
        {
            int upToPduLength = (int)PDU_LENGTH_POSITION + sizeof(ushort);
            int pduLength = 0;
            byte pduType;
            byte pdu_version;
            object pdu = null;

            long startingPosition = stream.Position;

            byte[] buffer = new byte[upToPduLength];

            // Read in part of the stream up to the pdu length
            stream.Read(buffer, 0, upToPduLength);

            try
            {
                if (this.endian == Endian.Big)
                {
                    Array.Reverse(buffer, (int)PDU_LENGTH_POSITION, 2);
                }

                pduLength = System.BitConverter.ToUInt16(buffer, (int)PDU_LENGTH_POSITION);

                // Allocate space for the whole PDU
                byte[] pduBufferStorage = new byte[pduLength];

                // Reset back to beginning
                stream.Position = startingPosition;

                // Read in the whole PDU
                stream.Read(pduBufferStorage, 0, pduLength);

                pduType = pduBufferStorage[PDU_TYPE_POSITION];

                pdu_version = pduBufferStorage[PDU_VERSION_POSITION];

                pdu = this.SwitchOnType(pdu_version, pduType, pduBufferStorage);

            }
            catch
            {
                // Wow something bad just happened, could be bad/misalgined PDU
                pdu = null;
            }

            return pdu;
        }

        /// <summary>
        /// Process a received PDU.  Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <param name="buf">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) decoded</returns>
        protected virtual List<object> ProcessPdu(byte[] buffer)
        {
            List<object> pduCollection = new List<object>();

            if (buffer.Length < 1)
            {
                return pduCollection;
            }

            int length = buffer.Length;
            byte pduType;
            byte pdu_version;
            int countBytes = 0;
            uint pduLength = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {
                    if (this.endian == Endian.Big)
                    {
                        Array.Reverse(buffer, (int)PDU_LENGTH_POSITION, 2);
                    }

                    pduLength = System.BitConverter.ToUInt16(buffer, (int)PDU_LENGTH_POSITION + countBytes);

                    // Must be at end of datastream
                    if (pduLength == 0)
                    {
                        break;
                    }

                    pduType = buffer[PDU_TYPE_POSITION + countBytes];

                    pdu_version = buffer[PDU_VERSION_POSITION + countBytes];

                    byte[] pduBufferStorage = new byte[pduLength];

                    // Could potentially be a problem since pduLength is an unsigned int,
                    // changed due to windows mobile does not accept a long for 4th parameter
                    Array.Copy(buffer, countBytes, pduBufferStorage, 0, (int)pduLength);

                    pduCollection.Add(SwitchOnType(pdu_version, pduType, pduBufferStorage));

                    countBytes += (int)pduLength;

                }
                catch
                {
                    // Wow something bad just happened, could be bad/misalgined PDU
                    break;
                }
            }

            return pduCollection;
        }

        protected virtual void ProcessPdu(Stream stream, out byte[] rawData)
        {
            int upToPduLength = (int)PDU_LENGTH_POSITION + sizeof(ushort);
            int pduLength = 0;

            long startingPosition = stream.Position;

            byte[] buffer = new byte[upToPduLength];

            // Read in part of the stream up to the pdu length
            stream.Read(buffer, 0, upToPduLength);

            try
            {
                if (this.endian == Endian.Big)
                {
                    Array.Reverse(buffer, (int)PDU_LENGTH_POSITION, 2);
                }

                pduLength = System.BitConverter.ToUInt16(buffer, (int)PDU_LENGTH_POSITION);


                // Allocate space for the whole PDU
                rawData = new byte[pduLength];

                // Reset back to beginning
                stream.Position = startingPosition;

                // Read in the whole PDU
                stream.Read(rawData, 0, pduLength);
            }
            catch
            {
                // Wow something bad just happened, could be bad/misalgined PDU
                rawData = null;
            }
        }

        /// <summary>
        /// Process a received PDU.  Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <remarks>Added by PES to support passing back just the byte array.</remarks>
        /// <param name="buf">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) in raw byte format</returns>
        protected virtual List<byte[]> ProcessRawPdu(byte[] buffer)
        {
            List<byte[]> pduCollection = new List<byte[]>();

            if (buffer.Length < 1)
            {
                return pduCollection;
            }

            int length = buffer.Length;
            byte pduType;
            byte pduVersion;
            int countBytes = 0;
            uint pduLength = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {
                    if (this.endian == Endian.Big)
                    {
                        Array.Reverse(buffer, (int)PDU_LENGTH_POSITION + countBytes, 2);
                    }

                    pduLength = System.BitConverter.ToUInt16(buffer, (int)PDU_LENGTH_POSITION + countBytes);

                    // Must be at end of datastream
                    if (pduLength == 0)
                    {
                        break;
                    }

                    pduType = buffer[PDU_TYPE_POSITION + countBytes];

                    pduVersion = buffer[PDU_VERSION_POSITION + countBytes];

                    byte[] pduBufferStorage = new byte[pduLength];

                    // Could potentially be a problem since pduLength is an unsigned int,
                    // changed due to windows mobile does not accept a long for 4th parameter
                    Array.Copy(buffer, countBytes, pduBufferStorage, 0, (int)pduLength);

                    pduCollection.Add(pduBufferStorage);

                    countBytes += (int)pduLength;
                }
                catch
                {
                    // Wow something bad just happened, could be bad/misalgined PDU
                    break;
                }
            }

            return pduCollection;
        }

        /// <summary>
        /// Returns an instance of the PDU based upon the pdu type passed in.  Note PDU will be represented as an Object for simplicity.
        /// </summary>
        /// <param name="pdu_version">Version of IEEE standard</param>
        /// <param name="pduType">Type of PDU</param>
        /// <param name="ds">PDU byte array containing the data</param>
        /// <returns>PDU instance.</returns>         
        protected virtual object SwitchOnType(byte pduVersion, uint pduType, byte[] ds)
        {
            object pdu = null;

            DataInputStream dStream = new DataInputStream(ds, this.Endian);

            switch (pduVersion)
            {
                case 5:
                    // DIS 1995
                    break;
                case 6:
                    // DIS 1998
                    // pdu = OpenDis.Utilities.PDUBank.GetPDU(pduType);
                    pdu = UnmarshalRawPdu((PduType)pduType, dStream);
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

        /// <summary>
        /// Unmarshal all data into the pdu object.  This method calls the all the base unmarshals.
        /// Deprecated:  This method used Reflection, use <see cref="UnmarshallRawPdu"/> method instead.
        /// </summary>
        /// <param name="pdu">object where the unmarshalled data will be stored</param>
        /// <param name="dStream">location of where the unmarshalled data is located</param>
        [Obsolete("This method used Reflection which is slow, new method 'UnmarshallRawPdu' should be used instead.")]
        private static void ReturnUnmarshalledPdu(object pdu, DataInputStream dStream)
        {
            // Unmarshal is the method name found in each of the PDU classes
            pdu.GetType().InvokeMember("Unmarshal", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { dStream }, CultureInfo.InvariantCulture);
        }

		#endregion Methods 
    }
}