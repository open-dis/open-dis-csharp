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
        /// constant scale factor
        /// </summary>
        private float _fieldScale;

        /// <summary>
        /// constant offset used to scale grid data
        /// </summary>
        private float _fieldOffset;

        /// <summary>
        /// Number of data values
        /// </summary>
        private ushort _numberOfValues;

        /// <summary>
        /// variable length list of data parameters ^^^this is wrong--need padding as well
        /// </summary>
        private List<TwoByteChunk> _dataValues = new List<TwoByteChunk>();

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public override int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.GetMarshalledSize();
            marshalSize += 4;  // this._fieldScale
            marshalSize += 4;  // this._fieldOffset
            marshalSize += 2;  // this._numberOfValues
            for (int idx = 0; idx < this._dataValues.Count; idx++)
            {
                TwoByteChunk listElement = (TwoByteChunk)this._dataValues[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the constant scale factor
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "fieldScale")]
        public float FieldScale
        {
            get
            {
                return this._fieldScale;
            }

            set
            {
                this._fieldScale = value;
            }
        }

        /// <summary>
        /// Gets or sets the constant offset used to scale grid data
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "fieldOffset")]
        public float FieldOffset
        {
            get
            {
                return this._fieldOffset;
            }

            set
            {
                this._fieldOffset = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of data values
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfValues method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfValues")]
        public ushort NumberOfValues
        {
            get
            {
                return this._numberOfValues;
            }

            set
            {
                this._numberOfValues = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of data parameters ^^^this is wrong--need padding as well
        /// </summary>
        [XmlElement(ElementName = "dataValuesList", Type = typeof(List<TwoByteChunk>))]
        public List<TwoByteChunk> DataValues
        {
            get
            {
                return this._dataValues;
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    dos.WriteFloat((float)this._fieldScale);
                    dos.WriteFloat((float)this._fieldOffset);
                    dos.WriteUnsignedShort((ushort)this._dataValues.Count);

                    for (int idx = 0; idx < this._dataValues.Count; idx++)
                    {
                        TwoByteChunk aTwoByteChunk = (TwoByteChunk)this._dataValues[idx];
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

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
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
                    this._fieldScale = dis.ReadFloat();
                    this._fieldOffset = dis.ReadFloat();
                    this._numberOfValues = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfValues; idx++)
                    {
                        TwoByteChunk anX = new TwoByteChunk();
                        anX.Unmarshal(dis);
                        this._dataValues.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<GridAxisRecordRepresentation1>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<fieldScale type=\"float\">" + this._fieldScale.ToString(CultureInfo.InvariantCulture) + "</fieldScale>");
                sb.AppendLine("<fieldOffset type=\"float\">" + this._fieldOffset.ToString(CultureInfo.InvariantCulture) + "</fieldOffset>");
                sb.AppendLine("<dataValues type=\"ushort\">" + this._dataValues.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
                for (int idx = 0; idx < this._dataValues.Count; idx++)
                {
                    sb.AppendLine("<dataValues" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
                    TwoByteChunk aTwoByteChunk = (TwoByteChunk)this._dataValues[idx];
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

                    this.RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw e;
                    }
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as GridAxisRecordRepresentation1;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(GridAxisRecordRepresentation1 obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._fieldScale != obj._fieldScale)
            {
                ivarsEqual = false;
            }

            if (this._fieldOffset != obj._fieldOffset)
            {
                ivarsEqual = false;
            }

            if (this._numberOfValues != obj._numberOfValues)
            {
                ivarsEqual = false;
            }

            if (this._dataValues.Count != obj._dataValues.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._dataValues.Count; idx++)
                {
                    if (!this._dataValues[idx].Equals(obj._dataValues[idx]))
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
        private static int GenerateHash(int hash)
        {
            hash = hash << (5 + hash);
            return hash;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ this._fieldScale.GetHashCode();
            result = GenerateHash(result) ^ this._fieldOffset.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfValues.GetHashCode();

            if (this._dataValues.Count > 0)
            {
                for (int idx = 0; idx < this._dataValues.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._dataValues[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
