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
        /// <exception cref="NotSupportedException">if the PDU type specified in parameter is not supported.</exception>
        public static IPdu CreatePdu(byte type) => CreatePdu((PduType)type);

        /// <summary>
        /// Creates the PDU.
        /// </summary>
        /// <param name="type">The type of PDU to be created.</param>
        /// <returns>Returns the corresponding PDU instance or null if PduType.Other is specified.</returns>
        /// <exception cref="NotSupportedException">if the PDU type specified in parameter is not supported.</exception>
        public static IPdu CreatePdu(PduType type)
        {
            return type switch
            {
                PduType.Other => new Pdu(),
                PduType.EntityState => new EntityStatePdu(),
                PduType.Fire => new FirePdu(),
                PduType.Detonation => new DetonationPdu(),
                PduType.Collision => new CollisionPdu(),
                PduType.ServiceRequest => new ServiceRequestPdu(),
                PduType.ResupplyOffer => new ResupplyOfferPdu(),
                PduType.ResupplyReceived => new ResupplyReceivedPdu(),
                PduType.ResupplyCancel => new ResupplyCancelPdu(),
                PduType.RepairComplete => new RepairCompletePdu(),
                PduType.RepairResponse => new RepairResponsePdu(),
                PduType.CreateEntity => new CreateEntityPdu(),
                PduType.RemoveEntity => new RemoveEntityPdu(),
                PduType.StartResume => new StartResumePdu(),
                PduType.StopFreeze => new StopFreezePdu(),
                PduType.Acknowledge => new AcknowledgePdu(),
                PduType.ActionRequest => new ActionRequestPdu(),
                PduType.ActionResponse => new ActionResponsePdu(),
                PduType.DataQuery => new DataQueryPdu(),
                PduType.SetData => new SetDataPdu(),
                PduType.Data => new DataPdu(),
                PduType.EventReport => new EventReportPdu(),
                PduType.Comment => new CommentPdu(),
                PduType.ElectromagneticEmission => new ElectronicEmissionsPdu(),
                PduType.Designator => new DesignatorPdu(),
                PduType.Transmitter => new TransmitterPdu(),
                PduType.Signal => new SignalPdu(),
                PduType.Receiver => new ReceiverPdu(),
                PduType.IFF_ATC_NAVAIDS => new IffAtcNavAidsLayer1Pdu(),
                PduType.UnderwaterAcoustic => new UaPdu(),
                PduType.SupplementalEmissionEntityState => new SeesPdu(),
                PduType.IntercomSignal => new IntercomSignalPdu(),
                PduType.IntercomControl => new IntercomControlPdu(),
                PduType.AggregateState => new AggregateStatePdu(),
                PduType.IsGroupOf => new IsGroupOfPdu(),
                PduType.TransferControl => new TransferControlRequestPdu(),
                PduType.IsPartOf => new IsPartOfPdu(),
                PduType.MinefieldState => new MinefieldStatePdu(),
                PduType.MinefieldQuery => new MinefieldQueryPdu(),
                PduType.MinefieldData => new MinefieldDataPdu(),
                PduType.MinefieldResponseNAK => new MinefieldResponseNackPdu(),
                PduType.EnvironmentalProcess => new EnvironmentalProcessPdu(),
                PduType.GriddedData => new GriddedDataPdu(),
                PduType.PointObjectState => new PointObjectStatePdu(),
                PduType.LinearObjectState => new LinearObjectStatePdu(),
                PduType.ArealObjectState => new ArealObjectStatePdu(),
                PduType.TSPI => throw new NotSupportedException(),
                PduType.Appearance => throw new NotSupportedException(),
                PduType.ArticulatedParts => throw new NotSupportedException(),
                PduType.LEFire => throw new NotSupportedException(),
                PduType.LEDetonation => throw new NotSupportedException(),
                PduType.CreateEntityR => new CreateEntityReliablePdu(),
                PduType.RemoveEntityR => new RemoveEntityReliablePdu(),
                PduType.StartResumeR => new StartResumeReliablePdu(),
                PduType.StopFreezeR => new StopFreezeReliablePdu(),
                PduType.AcknowledgeR => new AcknowledgeReliablePdu(),
                PduType.ActionRequestR => new ActionRequestReliablePdu(),
                PduType.ActionResponseR => new ActionResponseReliablePdu(),
                PduType.DataQueryR => new DataQueryReliablePdu(),
                PduType.SetDataR => new SetDataReliablePdu(),
                PduType.DataR => new DataReliablePdu(),
                PduType.EventReportR => new EventReportReliablePdu(),
                PduType.CommentR => new CommentReliablePdu(),
                PduType.RecordR => new RecordQueryReliablePdu(),
                PduType.SetRecordR => new SetRecordReliablePdu(),
                PduType.RecordQueryR => new RecordQueryReliablePdu(),
                PduType.CollisionElastic => new CollisionElasticPdu(),
                PduType.EntityStateUpdate => new EntityStateUpdatePdu(),
                _ => null,
            };
        }
    }
}
