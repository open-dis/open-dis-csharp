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
            IPdu pdu = type switch
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
                PduType.ElectromagneticEmission => throw new NotSupportedException(),
                PduType.Designator => new DesignatorPdu(),
                PduType.Transmitter => new TransmitterPdu(),
                PduType.Signal => new SignalPdu(),
                PduType.Receiver => new ReceiverPdu(),
                _ => throw new NotSupportedException(),
            };
            return pdu;
        }
    }
}
