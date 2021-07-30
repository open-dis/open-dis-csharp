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

namespace OpenDis.Dis1998
{
    /// <summary>
    /// 5.2.44: Grid data record, representation 1
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(TwoByteChunk))]
    public partial class GridAxisRecordRepresentation1 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation1>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridAxisRecordRepresentation1"/> class.
        /// </summary>
        public GridAxisRecordRepresentation1()
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
        public static bool operator !=(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 4;  // this._fieldScale
            marshalSize += 4;  // this._fieldOffset
            marshalSize += 2;  // this._numberOfValues
            for (int idx = 0; idx < DataValues.Count; idx++)
            {
                var listElement = DataValues[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the constant scale factor
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "fieldScale")]
        public float FieldScale { get; set; }

        /// <summary>
        /// Gets or sets the constant offset used to scale grid data
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "fieldOffset")]
        public float FieldOffset { get; set; }

        /// <summary>
        /// Gets or sets the Number of data values
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfValues method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfValues")]
        public ushort NumberOfValues { get; set; }

        /// <summary>
        /// Gets the variable length list of data parameters ^^^this is wrong--need padding as well
        /// </summary>
        [XmlElement(ElementName = "dataValuesList", Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> DataValues { get; } = new();

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    dos.WriteFloat((float)FieldScale);
                    dos.WriteFloat((float)FieldOffset);
                    dos.WriteUnsignedShort((ushort)DataValues.Count);

                    for (int idx = 0; idx < DataValues.Count; idx++)
                    {
                        var aTwoByteChunk = DataValues[idx];
                        aTwoByteChunk.Marshal(dos);
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
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    FieldScale = dis.ReadFloat();
                    FieldOffset = dis.ReadFloat();
                    NumberOfValues = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < NumberOfValues; idx++)
                    {
                        var anX = new TwoByteChunk();
                        anX.Unmarshal(dis);
                        DataValues.Add(anX);
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

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<GridAxisRecordRepresentation1>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<fieldScale type=\"float\">" + FieldScale.ToString(CultureInfo.InvariantCulture) + "</fieldScale>");
                sb.AppendLine("<fieldOffset type=\"float\">" + FieldOffset.ToString(CultureInfo.InvariantCulture) + "</fieldOffset>");
                sb.AppendLine("<dataValues type=\"ushort\">" + DataValues.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
                for (int idx = 0; idx < DataValues.Count; idx++)
                {
                    sb.AppendLine("<dataValues" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
                    var aTwoByteChunk = DataValues[idx];
                    aTwoByteChunk.Reflection(sb);
                    sb.AppendLine("</dataValues" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</GridAxisRecordRepresentation1>");
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
        public override bool Equals(object obj) => this == obj as GridAxisRecordRepresentation1;

        ///<inheritdoc/>
        public bool Equals(GridAxisRecordRepresentation1 obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (FieldScale != obj.FieldScale)
            {
                ivarsEqual = false;
            }

            if (FieldOffset != obj.FieldOffset)
            {
                ivarsEqual = false;
            }

            if (NumberOfValues != obj.NumberOfValues)
            {
                ivarsEqual = false;
            }

            if (DataValues.Count != obj.DataValues.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < DataValues.Count; idx++)
                {
                    if (!DataValues[idx].Equals(obj.DataValues[idx]))
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

            result = GenerateHash(result) ^ FieldScale.GetHashCode();
            result = GenerateHash(result) ^ FieldOffset.GetHashCode();
            result = GenerateHash(result) ^ NumberOfValues.GetHashCode();

            if (DataValues.Count > 0)
            {
                for (int idx = 0; idx < DataValues.Count; idx++)
                {
                    result = GenerateHash(result) ^ DataValues[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
