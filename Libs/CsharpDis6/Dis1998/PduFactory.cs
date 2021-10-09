using System;
using OpenDis.Core;
using OpenDis.Enumerations;

namespace OpenDis.Dis1998
{
    public static class PduFactory
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
                    pdu = new ElectronicEmissionsPdu();
                    break;
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
                case PduType.IFF_ATC_NAVAIDS:
                    pdu = new IffAtcNavAidsLayer1Pdu();
                    break;
                case PduType.UnderwaterAcoustic:
                    pdu = new UaPdu();
                    break;
                case PduType.SupplementalEmissionEntityState:
                    pdu = new SeesPdu();
                    break;
                case PduType.IntercomSignal:
                    pdu = new IntercomSignalPdu();
                    break;
                case PduType.IntercomControl:
                    pdu = new IntercomControlPdu();
                    break;
                case PduType.AggregateState:
                    pdu = new AggregateStatePdu();
                    break;
                case PduType.IsGroupOf:
                    pdu = new IsGroupOfPdu();
                    break;
                case PduType.TransferControl:
                    pdu = new TransferControlRequestPdu();
                    break;
                case PduType.IsPartOf:
                    pdu = new IsPartOfPdu();
                    break;
                case PduType.MinefieldState:
                    pdu = new MinefieldStatePdu();
                    break;
                case PduType.MinefieldQuery:
                    pdu = new MinefieldQueryPdu();
                    break;
                case PduType.MinefieldData:
                    pdu = new MinefieldDataPdu();
                    break;
                case PduType.MinefieldResponseNAK:
                    pdu = new MinefieldResponseNackPdu();
                    break;
                case PduType.EnvironmentalProcess:
                    pdu = new EnvironmentalProcessPdu();
                    break;
                case PduType.GriddedData:
                    pdu = new GriddedDataPdu();
                    break;
                case PduType.PointObjectState:
                    pdu = new PointObjectStatePdu();
                    break;
                case PduType.LinearObjectState:
                    pdu = new LinearObjectStatePdu();
                    break;
                case PduType.ArealObjectState:
                    pdu = new ArealObjectStatePdu();
                    break;
                case PduType.TSPI:
                    throw new NotImplementedException();
                case PduType.Appearance:
                    throw new NotImplementedException();
                case PduType.ArticulatedParts:
                    throw new NotImplementedException();
                case PduType.LEFire:
                    throw new NotImplementedException();
                case PduType.LEDetonation:
                    throw new NotImplementedException();
                case PduType.CreateEntityR:
                    pdu = new CreateEntityReliablePdu();
                    break;
                case PduType.RemoveEntityR:
                    pdu = new RemoveEntityReliablePdu();
                    break;
                case PduType.StartResumeR:
                    pdu = new StartResumeReliablePdu();
                    break;
                case PduType.StopFreezeR:
                    pdu = new StopFreezeReliablePdu();
                    break;
                case PduType.AcknowledgeR:
                    pdu = new AcknowledgeReliablePdu();
                    break;
                case PduType.ActionRequestR:
                    pdu = new ActionRequestReliablePdu();
                    break;
                case PduType.ActionResponseR:
                    pdu = new ActionResponseReliablePdu();
                    break;
                case PduType.DataQueryR:
                    pdu = new DataQueryReliablePdu();
                    break;
                case PduType.SetDataR:
                    pdu = new SetDataReliablePdu();
                    break;
                case PduType.DataR:
                    pdu = new DataReliablePdu();
                    break;
                case PduType.EventReportR:
                    pdu = new EventReportReliablePdu();
                    break;
                case PduType.CommentR:
                    pdu = new CommentReliablePdu();
                    break;
                case PduType.RecordR:
                    pdu = new RecordQueryReliablePdu();
                    break;
                case PduType.SetRecordR:
                    pdu = new SetRecordReliablePdu();
                    break;
                case PduType.RecordQueryR:
                    pdu = new RecordQueryReliablePdu();
                    break;
                case PduType.CollisionElastic:
                    pdu = new CollisionElasticPdu();
                    break;
                case PduType.EntityStateUpdate:
                    pdu = new EntityStateUpdatePdu();
                    break;
                default:
                    pdu = null;
                    break;
            }

            return pdu;
        }
    }
}
