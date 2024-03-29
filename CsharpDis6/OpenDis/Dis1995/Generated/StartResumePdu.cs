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
// Author: DMcG
// Modified for use with C#:
//  - Peter Smith (Naval Air Warfare Center - Training Systems Division)
//  - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Section 5.2.6.3. Start or resume an exercise
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(ClockTime))]
    public partial class StartResumePdu : SimulationManagementPdu, IEquatable<StartResumePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartResumePdu"/> class.
        /// </summary>
        public StartResumePdu()
        {
            PduType = 13;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(StartResumePdu left, StartResumePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(StartResumePdu left, StartResumePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += RealWorldTime.GetMarshalledSize();  // this._realWorldTime
            marshalSize += SimulationTime.GetMarshalledSize();  // this._simulationTime
            marshalSize += 4;  // this._requestID
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the UTC time at which the simulation shall start or resume
        /// </summary>
        [XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
        public ClockTime RealWorldTime { get; set; } = new ClockTime();

        /// <summary>
        /// Gets or sets the Simulation clock time at which the simulation shall start or resume
        /// </summary>
        [XmlElement(Type = typeof(ClockTime), ElementName = "simulationTime")]
        public ClockTime SimulationTime { get; set; } = new ClockTime();

        /// <summary>
        /// Gets or sets the Identifier for the request
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID { get; set; }

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    RealWorldTime.Marshal(dos);
                    SimulationTime.Marshal(dos);
                    dos.WriteUnsignedInt(RequestID);
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    RealWorldTime.Unmarshal(dis);
                    SimulationTime.Unmarshal(dis);
                    RequestID = dis.ReadUnsignedInt();
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<StartResumePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<realWorldTime>");
                RealWorldTime.Reflection(sb);
                sb.AppendLine("</realWorldTime>");
                sb.AppendLine("<simulationTime>");
                SimulationTime.Reflection(sb);
                sb.AppendLine("</simulationTime>");
                sb.AppendLine("<requestID type=\"uint\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("</StartResumePdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as StartResumePdu;

        ///<inheritdoc/>
        public bool Equals(StartResumePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!RealWorldTime.Equals(obj.RealWorldTime))
            {
                ivarsEqual = false;
            }

            if (!SimulationTime.Equals(obj.SimulationTime))
            {
                ivarsEqual = false;
            }

            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            return ivarsEqual;
        }

        /// <summary>
        /// HashCode Helper
        /// </summary>
        /// <param name="hash">The hash value.</param>
        /// <returns>The new hash value.</returns>
        private static int GenerateHash(int hash) => hash << (5 + hash);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ RealWorldTime.GetHashCode();
            result = GenerateHash(result) ^ SimulationTime.GetHashCode();
            result = GenerateHash(result) ^ RequestID.GetHashCode();

            return result;
        }
    }
}
