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
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Section 5.3.6.9. Change state information with the data contained in this
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FixedDatum))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class SetDataPdu : SimulationManagementPdu, IEquatable<SetDataPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDataPdu"/> class.
        /// </summary>
        public SetDataPdu()
        {
            PduType = 19;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SetDataPdu left, SetDataPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(SetDataPdu left, SetDataPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 4;  // this._requestID
            marshalSize += 4;  // this._padding1
            marshalSize += 4;  // this._fixedDatumRecordCount
            marshalSize += 4;  // this._variableDatumRecordCount
            for (int idx = 0; idx < FixedDatums.Count; idx++)
            {
                var listElement = FixedDatums[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < VariableDatums.Count; idx++)
            {
                var listElement = VariableDatums[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of request
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "padding1")]
        public uint Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the Number of fixed datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getfixedDatumRecordCount method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "fixedDatumRecordCount")]
        public uint FixedDatumRecordCount { get; set; }

        /// <summary>
        /// Gets or sets the Number of variable datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getvariableDatumRecordCount method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "variableDatumRecordCount")]
        public uint VariableDatumRecordCount { get; set; }

        /// <summary>
        /// Gets the variable length list of fixed datums
        /// </summary>
        [XmlElement(ElementName = "fixedDatumsList", Type = typeof(List<FixedDatum>))]
        public List<FixedDatum> FixedDatums { get; } = new();

        /// <summary>
        /// Gets the variable length list of variable length datums
        /// </summary>
        [XmlElement(ElementName = "variableDatumsList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatums { get; } = new();

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
                    dos.WriteUnsignedInt(RequestID);
                    dos.WriteUnsignedInt(Padding1);
                    dos.WriteUnsignedInt((uint)FixedDatums.Count);
                    dos.WriteUnsignedInt((uint)VariableDatums.Count);

                    for (int idx = 0; idx < FixedDatums.Count; idx++)
                    {
                        var aFixedDatum = FixedDatums[idx];
                        aFixedDatum.Marshal(dos);
                    }

                    for (int idx = 0; idx < VariableDatums.Count; idx++)
                    {
                        var aVariableDatum = VariableDatums[idx];
                        aVariableDatum.Marshal(dos);
                    }
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
                    RequestID = dis.ReadUnsignedInt();
                    Padding1 = dis.ReadUnsignedInt();
                    FixedDatumRecordCount = dis.ReadUnsignedInt();
                    VariableDatumRecordCount = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < FixedDatumRecordCount; idx++)
                    {
                        var anX = new FixedDatum();
                        anX.Unmarshal(dis);
                        FixedDatums.Add(anX);
                    }

                    for (int idx = 0; idx < VariableDatumRecordCount; idx++)
                    {
                        var anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        VariableDatums.Add(anX);
                    }
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
            sb.AppendLine("<SetDataPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestID type=\"uint\">" + RequestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<padding1 type=\"uint\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<fixedDatums type=\"uint\">" + FixedDatums.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatums>");
                sb.AppendLine("<variableDatums type=\"uint\">" + VariableDatums.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
                for (int idx = 0; idx < FixedDatums.Count; idx++)
                {
                    sb.AppendLine("<fixedDatums" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
                    var aFixedDatum = FixedDatums[idx];
                    aFixedDatum.Reflection(sb);
                    sb.AppendLine("</fixedDatums" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < VariableDatums.Count; idx++)
                {
                    sb.AppendLine("<variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    var aVariableDatum = VariableDatums[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</SetDataPdu>");
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
        public override bool Equals(object obj) => this == obj as SetDataPdu;

        ///<inheritdoc/>
        public bool Equals(SetDataPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (RequestID != obj.RequestID)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (FixedDatumRecordCount != obj.FixedDatumRecordCount)
            {
                ivarsEqual = false;
            }

            if (VariableDatumRecordCount != obj.VariableDatumRecordCount)
            {
                ivarsEqual = false;
            }

            if (FixedDatums.Count != obj.FixedDatums.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < FixedDatums.Count; idx++)
                {
                    if (!FixedDatums[idx].Equals(obj.FixedDatums[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (VariableDatums.Count != obj.VariableDatums.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < VariableDatums.Count; idx++)
                {
                    if (!VariableDatums[idx].Equals(obj.VariableDatums[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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

            result = GenerateHash(result) ^ RequestID.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ FixedDatumRecordCount.GetHashCode();
            result = GenerateHash(result) ^ VariableDatumRecordCount.GetHashCode();

            if (FixedDatums.Count > 0)
            {
                for (int idx = 0; idx < FixedDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ FixedDatums[idx].GetHashCode();
                }
            }

            if (VariableDatums.Count > 0)
            {
                for (int idx = 0; idx < VariableDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ VariableDatums[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
