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
// Modified by Chad Dettmering (Unity Technologies - chad.dettmering@unity3d.com) 06/22/2021
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
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
        private XmlSerializer xmlSerializedData;

        #endregion Fields 

        #region Constructors (1) 

        public PduProcessor()
        {
            Endian = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        }

        #endregion Constructors 

        #region Properties (1) 

        /// <summary>
        /// Gets or sets the type of endian used to process the data
        /// </summary>
        public Endian Endian { get; set; }

        #endregion Properties 

        #region Methods (18) 

        /// <summary>
        /// Converts a byte array into a DIS1998 PDU
        /// </summary>
        /// <param name="pduType">Type of the PDU.</param>
        /// <param name="rawPdu">Byte array that hold raw 1998 PDU.</param>
        /// <param name="endian">The Endian type used for conversion.</param>
        /// <returns>PDU object</returns>
        public static Pdu ConvertByteArrayToPdu1998(byte pduType, byte[] rawPdu, Endian endian) => UnmarshalRawPdu(pduType, rawPdu, endian);

        /// <summary>
        /// Provided as a means to return a string representation of the underlining PDU data. Note format is not yet optimized.
        /// </summary>
        /// <param name="pdu">The PDU to parse</param>
        /// <returns>StringBuilder that represents the state of the PDU</returns>
        public static StringBuilder DecodePdu(object pdu)
        {
            var sb = new StringBuilder();
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
            Endian = endian;
            return ProcessPdu(buffer);
        }

        /// <summary>
        /// Processes the pdu.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="endian">format of value types</param>
        /// <returns>The PDU instance.</returns>
        public object ProcessPdu(Stream stream, Endian endian)
        {
            Endian = endian;
            return ProcessPdu(stream);
        }

        /// <summary>
        /// Processes the pdu.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="endian">format of value types</param>
        /// <param name="rawPdu">The raw pdu.</param>
        public void ProcessPdu(Stream stream, Endian endian, out byte[] rawPdu)
        {
            Endian = endian;
            ProcessPdu(stream, out rawPdu);
        }

        /// <summary>
        /// Provides a means of processing PDU data
        /// </summary>
        /// <param name="buffer">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <remarks>Added to support passing back just the byte array.</remarks>
        /// <returns>Collection of Raw byte[] PDUs</returns>
        public List<byte[]> ProcessRawPdu(byte[] buffer, Endian endian)
        {
            Endian = endian;
            return ProcessRawPdu(buffer);
        }

        /// <summary>
        /// Provides a means of processing PDU data
        /// </summary>
        /// <param name="buffer">byte array containing the pdu data to process</param>
        /// <param name="endian">format of value types</param>
        /// <param name="dataQueue">Returns raw packets to a referenced Queue</param>
        /// <remarks>Added to support passing back just the byte array into a Queue.</remarks>
        public void ProcessRawPdu(byte[] buffer, Endian endian, ref Queue<byte[]> dataQueue)
        {
            Endian = endian;

            // Calling the method to get PDUs, increment through each in case more than one pdu in packet
            foreach (byte[] pduRawByteArray in ProcessRawPdu(buffer))
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
        public static Pdu UnmarshalRawPdu(byte pduType, DataInputStream ds) => UnmarshalRawPdu((PduType)pduType, ds);

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="ds">Datastream which contains the raw packet and Endian Type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance.</returns>
        public static Pdu UnmarshalRawPdu(PduType pduType, DataInputStream ds)
        {
            var pdu = new Pdu();

            switch (pduType)
            {
                case PduType.EntityState:
                    pdu = new EntityStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Fire:
                    pdu = new FirePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Detonation:
                    pdu = new DetonationPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Collision:
                    pdu = new CollisionPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ServiceRequest:
                    pdu = new ServiceRequestPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyOffer:
                    pdu = new ResupplyOfferPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyReceived:
                    pdu = new ResupplyReceivedPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyCancel:
                    pdu = new ResupplyCancelPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RepairComplete:
                    pdu = new RepairCompletePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RepairResponse:
                    pdu = new RepairResponsePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.CreateEntity:
                    pdu = new CreateEntityPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RemoveEntity:
                    pdu = new RemoveEntityPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StartResume:
                    pdu = new StartResumePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Acknowledge:
                    pdu = new AcknowledgePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionRequest:
                    pdu = new ActionRequestPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionResponse:
                    pdu = new ActionResponsePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.DataQuery:
                    pdu = new DataQueryPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.SetData:
                    pdu = new SetDataPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.EventReport:
                    pdu = new EventReportPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Comment:
                    pdu = new CommentPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StopFreeze:
                    pdu = new StopFreezePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Signal:
                    pdu = new SignalPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Transmitter:
                    pdu = new TransmitterPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ElectromagneticEmission:
                    pdu = new ElectronicEmissionsPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Designator:
                    pdu = new DesignatorPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Receiver:
                    pdu = new ReceiverPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.IFF_ATC_NAVAIDS:
                    pdu = new IffAtcNavAidsLayer1Pdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.UnderwaterAcoustic:
                    pdu = new UaPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.SupplementalEmissionEntityState:
                    pdu = new SeesPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.IntercomSignal:
                    pdu = new IntercomSignalPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.IntercomControl:
                    pdu = new IntercomControlPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.AggregateState:
                    pdu = new AggregateStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.IsGroupOf:
                    pdu = new IsGroupOfPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.TransferControl:
                    pdu = new TransferControlRequestPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.IsPartOf:
                    pdu = new IsPartOfPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.MinefieldState:
                    pdu = new MinefieldStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.MinefieldQuery:
                    pdu = new MinefieldQueryPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.MinefieldData:
                    pdu = new MinefieldDataPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.MinefieldResponseNAK:
                    pdu = new MinefieldResponseNackPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.EnvironmentalProcess:
                    pdu = new EnvironmentalProcessPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.GriddedData:
                    pdu = new GriddedDataPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.PointObjectState:
                    pdu = new PointObjectStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.LinearObjectState:
                    pdu = new LinearObjectStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ArealObjectState:
                    pdu = new ArealObjectStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.TSPI:
                    throw new NotSupportedException();
                case PduType.Appearance:
                    throw new NotSupportedException();
                case PduType.ArticulatedParts:
                    throw new NotSupportedException();
                case PduType.LEFire:
                    throw new NotSupportedException();
                case PduType.LEDetonation:
                    throw new NotSupportedException();
                case PduType.CreateEntityR:
                    pdu = new CreateEntityReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RemoveEntityR:
                    pdu = new RemoveEntityReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StartResumeR:
                    pdu = new StartResumeReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StopFreezeR:
                    pdu = new StopFreezeReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.AcknowledgeR:
                    pdu = new AcknowledgeReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionRequestR:
                    pdu = new ActionRequestReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionResponseR:
                    pdu = new ActionResponseReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.DataQueryR:
                    pdu = new DataQueryReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.SetDataR:
                    pdu = new SetDataReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.DataR:
                    pdu = new DataReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.EventReportR:
                    pdu = new EventReportReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.CommentR:
                    pdu = new CommentReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RecordR:
                    pdu = new RecordQueryReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.SetRecordR:
                    pdu = new SetRecordReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RecordQueryR:
                    pdu = new RecordQueryReliablePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.CollisionElastic:
                    pdu = new CollisionElasticPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.EntityStateUpdate:
                    pdu = new EntityStateUpdatePdu();
                    pdu.Unmarshal(ds);
                    break;
            }

            return pdu;
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type for protocol 5.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="ds">Data stream that holds raw pdu data</param>
        /// <returns>Base PDU object that can be cast to specific PDU if needed</returns>
        /// <exception cref="NotSupportedException"></exception>
        public static Dis1995.Pdu UnmarshalRawPdu1995(PduType pduType, DataInputStream ds)
        {
            var pdu = new Dis1995.Pdu();
            switch (pduType)
            {
                case PduType.EntityState:
                    pdu = new Dis1995.EntityStatePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Fire:
                    pdu = new Dis1995.FirePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Detonation:
                    pdu = new Dis1995.DetonationPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Collision:
                    pdu = new Dis1995.CollisionPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ServiceRequest:
                    pdu = new Dis1995.ServiceRequestPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyOffer:
                    pdu = new Dis1995.ResupplyOfferPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyReceived:
                    pdu = new Dis1995.ResupplyReceivedPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ResupplyCancel:
                    pdu = new Dis1995.ResupplyCancelPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RepairComplete:
                    pdu = new Dis1995.RepairCompletePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RepairResponse:
                    pdu = new Dis1995.RepairResponsePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.CreateEntity:
                    pdu = new Dis1995.CreateEntityPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.RemoveEntity:
                    pdu = new Dis1995.RemoveEntityPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StartResume:
                    pdu = new Dis1995.StartResumePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Acknowledge:
                    pdu = new Dis1995.AcknowledgePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionRequest:
                    pdu = new Dis1995.ActionRequestPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.ActionResponse:
                    pdu = new Dis1995.ActionResponsePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.DataQuery:
                    pdu = new Dis1995.DataQueryPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.SetData:
                    pdu = new Dis1995.SetDataPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.EventReport:
                    pdu = new Dis1995.EventReportPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Comment:
                    pdu = new Dis1995.CommentPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.StopFreeze:
                    pdu = new Dis1995.StopFreezePdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Signal:
                    pdu = new Dis1995.SignalPdu();
                    pdu.Unmarshal(ds);
                    break;
                case PduType.Transmitter:
                    pdu = new Dis1995.TransmitterPdu();
                    pdu.Unmarshal(ds);
                    break;
            }

            return pdu;
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="rawPdu">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance</returns>
        public static Pdu UnmarshalRawPdu(byte pduType, byte[] rawPdu, Endian endian)
        {
            var ds = new DataInputStream(rawPdu, endian);
            return UnmarshalRawPdu((PduType)pduType, ds);
        }

        /// <summary>
        /// Used to unmarshal data back into the correct PDU type.
        /// </summary>
        /// <param name="pduType">PDU type</param>
        /// <param name="rawPdu">byte array containing the raw packets</param>
        /// <param name="endian">Endian type</param>
        /// <remarks>Added by PES to work with Mobile.</remarks>
        /// <returns>The PDU instance.</returns>
        public static Pdu UnmarshalRawPdu(PduType pduType, byte[] rawPdu, Endian endian)
        {
            var ds = new DataInputStream(rawPdu, endian);
            return UnmarshalRawPdu(pduType, ds);
        }

        /// <summary>
        /// Returns an XML version of the reflected PDU
        /// </summary>
        /// <param name="pdu">PDU to reflect into XML</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder XmlDecodePdu(object pdu)
        {
            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                try
                {
                    xmlSerializedData = new XmlSerializer(pdu.GetType());
                    xmlSerializedData.Serialize(stringWriter, pdu);
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
            const int upToPduLength = (int)PDU_LENGTH_POSITION + sizeof(ushort);
            byte pduType;
            byte pdu_version;
            long startingPosition = stream.Position;

            byte[] buffer = new byte[upToPduLength];

            // Read in part of the stream up to the pdu length
            stream.Read(buffer, 0, upToPduLength);

            object pdu;
            try
            {
                int pduLength = PduProcessor.pduLength(buffer, Endian);

                // Allocate space for the whole PDU
                byte[] pduBufferStorage = new byte[pduLength];

                // Reset back to beginning
                stream.Position = startingPosition;

                // Read in the whole PDU
                stream.Read(pduBufferStorage, 0, pduLength);

                pduType = pduBufferStorage[PDU_TYPE_POSITION];

                pdu_version = pduBufferStorage[PDU_VERSION_POSITION];

                pdu = SwitchOnType(pdu_version, pduType, pduBufferStorage);
            }
            catch
            {
                // Wow something bad just happened, could be bad/misalgined PDU
                pdu = null;
            }

            return pdu;
        }

        /// <summary>
        /// Process a received PDU. Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <param name="buffer">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) decoded</returns>
        protected virtual List<object> ProcessPdu(byte[] buffer)
        {
            var pduCollection = new List<object>();

            if (buffer.Length < 1)
            {
                return pduCollection;
            }

            int length = buffer.Length;
            byte pduType;
            byte pdu_version;
            int countBytes = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {
                    uint pduLength = PduProcessor.pduLength(buffer, Endian, (uint)(PDU_LENGTH_POSITION + countBytes));

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
            const int upToPduLength = (int)PDU_LENGTH_POSITION + sizeof(ushort);
            long startingPosition = stream.Position;

            byte[] buffer = new byte[upToPduLength];

            // Read in part of the stream up to the pdu length
            stream.Read(buffer, 0, upToPduLength);

            try
            {
                int pduLength = PduProcessor.pduLength(buffer, Endian);

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
        /// Process a received PDU. Note that a datastream can contain multiple PDUs.  Therefore a
        /// List is used to hold one or more after decoding.
        /// </summary>
        /// <remarks>Added by PES to support passing back just the byte array.</remarks>
        /// <param name="buffer">byte array of PDU(s)</param>
        /// <returns>Collection of all PDU(s) in raw byte format</returns>
        protected virtual List<byte[]> ProcessRawPdu(byte[] buffer)
        {
            var pduCollection = new List<byte[]>();

            if (buffer.Length < 1)
            {
                return pduCollection;
            }

            int length = buffer.Length;
            byte pduType;
            byte pduVersion;
            int countBytes = 0;

            //used to interate over all PDU(s) within the byte array
            while (countBytes < length)
            {
                try
                {
                    uint pduLength = PduProcessor.pduLength(buffer, Endian);

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
        /// Returns an instance of the PDU based upon the pdu type passed in. Note PDU will be represented as an Object for
        /// simplicity.
        /// </summary>
        /// <param name="pduVersion">Version of IEEE standard</param>
        /// <param name="pduType">Type of PDU</param>
        /// <param name="ds">PDU byte array containing the data</param>
        /// <returns>PDU instance.</returns>
        protected virtual object SwitchOnType(byte pduVersion, uint pduType, byte[] ds)
        {
            object pdu = null;

            var dStream = new DataInputStream(ds, Endian);

            switch (pduVersion)
            {
                case 5:
                    // DIS 1995
                    pdu = UnmarshalRawPdu1995((PduType)pduType, dStream);
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
        /// Extracts length of PDU without altering byte array/stream so that future access to this field is still valid
        /// </summary>
        /// <param name="buf">Byte array holding PDU data.</param>
        /// <param name="endian">The Endian type used for conversion.</param>
        /// <param name="pos">Position of 'length' field. generally at pos 8, but if this byte array holds more than one PDU</param>
        /// <returns>length</returns>
        private static ushort pduLength(byte[] buf, Endian endian, uint pos = PDU_LENGTH_POSITION)
        {
            byte[] temp = new byte[2];

            if (endian == Endian.Big)  //Reverse
            {
                temp[0] = buf[pos + 1];
                temp[1] = buf[pos];
            }
            else  //Leave as is
            {
                temp[0] = buf[pos];
                temp[1] = buf[pos + 1];
            }

            return BitConverter.ToUInt16(temp, 0);
        }

        /// <summary>
        /// Unmarshal all data into the pdu object. This method calls the all the base unmarshals.
        /// Deprecated: This method used Reflection, use <see cref="UnmarshalRawPdu(byte, DataInputStream)"/> method instead.
        /// </summary>
        /// <param name="pdu">object where the unmarshalled data will be stored</param>
        /// <param name="dStream">location of where the unmarshalled data is located</param>
        [Obsolete("This method used Reflection which is slow, new method 'UnmarshalRawPdu' should be used instead.")]
        private static void ReturnUnmarshalledPdu(object pdu, DataInputStream dStream) =>
            // Unmarshal is the method name found in each of the PDU classes
            pdu.GetType().InvokeMember("Unmarshal", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { dStream }, CultureInfo.InvariantCulture);

        #endregion Methods 
    }
}