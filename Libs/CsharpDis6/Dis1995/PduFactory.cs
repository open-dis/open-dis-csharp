using System;
using OpenDis.Core;
using OpenDis.Enumerations;

namespace OpenDis.Dis1995
{
    internal static class PduFactory
    {
        /// <summary>
        /// Creates the PDU.
        /// </summary>
        /// <param name="type">The type of PDU to be created.</param>
        /// <returns>Returns the corresponding PDU instance or null if type equals 0.</returns>
        /// <exception cref="NotImplementedException">if the PDU type specified in parameter is not supported.</exception>
        public static IPdu CreatePdu(byte type)
        {
            return CreatePdu((PduType)type);
        }
        
        /// <summary>
        /// Creates the PDU.
        /// </summary>
        /// <param name="type">The type of PDU to be created.</param>
        /// <returns>Returns the corresponding PDU instance or null if PduType.Other is specified.</returns>
        /// <exception cref="NotImplementedException">if the PDU type specified in parameter is not supported.</exception>
        public static IPdu CreatePdu(PduType type)
        {
            IPdu pdu = null;

            switch (type)
            {
                case PduType.Other:
                    pdu = new Pdu();
                    break;
                case PduType.EntityState:
                    pdu = new EntityStatePdu();
                    break;
                case PduType.Fire:
                    pdu = new FirePdu();
                    break;
                case PduType.Detonation:
                    pdu = new DetonationPdu();
                    break;
                case PduType.Collision:
                    pdu = new CollisionPdu();
                    break;
                case PduType.ServiceRequest:
                    pdu = new ServiceRequestPdu();
                    break;
                case PduType.ResupplyOffer:
                    pdu = new ResupplyOfferPdu();
                    break;
                case PduType.ResupplyReceived:
                    pdu = new ResupplyReceivedPdu();
                    break;
                case PduType.ResupplyCancel:
                    pdu = new ResupplyCancelPdu();
                    break;
                case PduType.RepairComplete:
                    pdu = new RepairCompletePdu();
                    break;
                case PduType.RepairResponse:
                    pdu = new RepairResponsePdu();
                    break;
                case PduType.CreateEntity:
                    pdu = new CreateEntityPdu();
                    break;
                case PduType.RemoveEntity:
                    pdu = new RemoveEntityPdu();
                    break;
                case PduType.StartResume:
                    pdu = new StartResumePdu();
                    break;
                case PduType.StopFreeze:
                    pdu = new StopFreezePdu();
                    break;
                case PduType.Acknowledge:
                    pdu = new AcknowledgePdu();
                    break;
                case PduType.ActionRequest:
                    pdu = new ActionRequestPdu();
                    break;
                case PduType.ActionResponse:
                    pdu = new ActionResponsePdu();
                    break;
                case PduType.DataQuery:
                    pdu = new DataQueryPdu();
                    break;
                case PduType.SetData:
                    pdu = new SetDataPdu();
                    break;
                case PduType.Data:
                    pdu = new DataPdu();
                    break;
                case PduType.EventReport:
                    pdu = new EventReportPdu();
                    break;
                case PduType.Comment:
                    pdu = new CommentPdu();
                    break;
                case PduType.ElectromagneticEmission:
                    throw new NotImplementedException();
                case PduType.Designator:
                    pdu = new DesignatorPdu();
                    break;
                case PduType.Transmitter:
                    pdu = new TransmitterPdu();
                    break;
                case PduType.Signal:
                    pdu = new SignalPdu();
                    break;
                case PduType.Receiver:
                    pdu = new ReceiverPdu();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return pdu;
        }
    }
}
