using System;
using OpenDis.Enumerations;
using Dis1995 = OpenDis.Dis1995;
using Dis1998 = OpenDis.Dis1998;

namespace OpenDis.Core
{
    public static class PduFactory
    {
        /// <summary>
        /// Creates the PDU. Supported protocol versions are IEEE 1278.1-1995 and IEEE 1278.1A-1998.
        /// </summary>
        /// <param name="type">The type of PDU to be created.</param>
        /// <param name="version">The protocol version.</param>
        /// <returns>
        /// Returns the corresponding PDU instance or null if type equals 0.
        /// </returns>
        /// <exception cref="NotImplementedException">if the PDU type specified in parameter is not supported.</exception>
        /// <exception cref="ArgumentException">if the protocol version is not supported</exception>
        public static IPdu CreatePdu(byte type, ProtocolVersion version)
        {
            return CreatePdu((PduType)type, version);
        }

        /// <summary>
        /// Creates the PDU. Supported protocol versions are IEEE 1278.1-1995 and IEEE 1278.1A-1998.
        /// </summary>
        /// <param name="type">The type of PDU to be created.</param>
        /// <returns>
        /// Returns the corresponding PDU instance or null if PduType.Other is specified.
        /// </returns>
        /// <exception cref="NotImplementedException">if the PDU type specified in parameter is not supported.</exception>
        /// <exception cref="ArgumentException">if the protocol version is not supported</exception>
        public static IPdu CreatePdu(PduType type, ProtocolVersion version)
        {
            if (version == ProtocolVersion.Ieee1278_1_1995)
            {
                return Dis1995.PduFactory.CreatePdu(type);
            }
            else if (version == ProtocolVersion.Ieee1278_1A_1998)
            {
                return Dis1998.PduFactory.CreatePdu(type);
            }

            throw new ArgumentException("Unsupported protocol version.");
        }
    }
}
