﻿using System;

namespace OpenDis.Core
{
    public interface IReflectable
    {
        /// <summary>#original#
        /// This allows for a quick display of PDU data. The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display. Usage:
        /// <code>
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// </code>
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides
        /// this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        void Reflection(System.Text.StringBuilder sb);
    }

    public interface IPdu : IReflectable
    {
        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        void Marshal(DataOutputStream dos);

        /// <summary>
        /// Unmarshal the data from the DataInputStream.
        /// </summary>
        /// <param name="dis">The dis input stream.</param>
        void Unmarshal(DataInputStream dis);

        /// <summary>
        /// Raised when exception occurs while processing PDU.
        /// </summary>
        event EventHandler<PduExceptionEventArgs> ExceptionOccured;
    }
}
