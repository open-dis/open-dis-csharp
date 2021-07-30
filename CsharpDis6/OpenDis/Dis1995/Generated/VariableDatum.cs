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
    /// Section 5.2.32. Variable Datum Record
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EightByteChunk))]
    public partial class VariableDatum : IEquatable<VariableDatum>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableDatum"/> class.
        /// </summary>
        public VariableDatum()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(VariableDatum left, VariableDatum right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(VariableDatum left, VariableDatum right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 4;  // this._variableDatumID
            marshalSize += 4;  // this._variableDatumLength
            for (int idx = 0; idx < VariableDatums.Count; idx++)
            {
                var listElement = VariableDatums[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the variable datum
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "variableDatumID")]
        public uint VariableDatumID { get; set; }

        /// <summary>
        /// Gets or sets the length of the variable datums
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getvariableDatumLength method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "variableDatumLength")]
        public uint VariableDatumLength { get; set; }

        /// <summary>
        /// Gets the variable length list of 64-bit datums
        /// </summary>
        [XmlElement(ElementName = "variableDatumsList", Type = typeof(List<EightByteChunk>))]
        public List<EightByteChunk> VariableDatums { get; } = new();

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event EventHandler<PduExceptionEventArgs> ExceptionOccured;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void RaiseExceptionOccured(Exception e)
        {
            if (PduBase.FireExceptionEvents && ExceptionOccured != null)
            {
                ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt(VariableDatumID);
                    dos.WriteUnsignedInt((uint)VariableDatums.Count);

                    for (int idx = 0; idx < VariableDatums.Count; idx++)
                    {
                        var aEightByteChunk = VariableDatums[idx];
                        aEightByteChunk.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    VariableDatumID = dis.ReadUnsignedInt();
                    VariableDatumLength = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < VariableDatumLength; idx++)
                    {
                        var anX = new EightByteChunk();
                        anX.Unmarshal(dis);
                        VariableDatums.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        ///<inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<VariableDatum>");
            try
            {
                sb.AppendLine("<variableDatumID type=\"uint\">" + VariableDatumID.ToString(CultureInfo.InvariantCulture) + "</variableDatumID>");
                sb.AppendLine("<variableDatums type=\"uint\">" + VariableDatums.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
                for (int idx = 0; idx < VariableDatums.Count; idx++)
                {
                    sb.AppendLine("<variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
                    var aEightByteChunk = VariableDatums[idx];
                    aEightByteChunk.Reflection(sb);
                    sb.AppendLine("</variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</VariableDatum>");
            }
            catch (Exception e)
            {
                if (PduBase.TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (PduBase.ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as VariableDatum;

        ///<inheritdoc/>
        public bool Equals(VariableDatum obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (VariableDatumID != obj.VariableDatumID)
            {
                ivarsEqual = false;
            }

            if (VariableDatumLength != obj.VariableDatumLength)
            {
                ivarsEqual = false;
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

            result = GenerateHash(result) ^ VariableDatumID.GetHashCode();
            result = GenerateHash(result) ^ VariableDatumLength.GetHashCode();

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
