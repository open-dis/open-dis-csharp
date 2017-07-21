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
    /// Section 5.3.6.8. Request for data from an entity
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FixedDatum))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class DataQueryPdu : SimulationManagementPdu, IEquatable<DataQueryPdu>
    {
        /// <summary>
        /// ID of request
        /// </summary>
        private uint _requestID;

        /// <summary>
        /// time issues between issues of Data PDUs. Zero means send once only.
        /// </summary>
        private uint _timeInterval;

        /// <summary>
        /// Number of fixed datum records
        /// </summary>
        private uint _fixedDatumRecordCount;

        /// <summary>
        /// Number of variable datum records
        /// </summary>
        private uint _variableDatumRecordCount;

        /// <summary>
        /// variable length list of fixed datums
        /// </summary>
        private List<FixedDatum> _fixedDatums = new List<FixedDatum>();

        /// <summary>
        /// variable length list of variable length datums
        /// </summary>
        private List<VariableDatum> _variableDatums = new List<VariableDatum>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataQueryPdu"/> class.
        /// </summary>
        public DataQueryPdu()
        {
            PduType = (byte)18;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DataQueryPdu left, DataQueryPdu right)
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
        public static bool operator ==(DataQueryPdu left, DataQueryPdu right)
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
            marshalSize += 4;  // this._requestID
            marshalSize += 4;  // this._timeInterval
            marshalSize += 4;  // this._fixedDatumRecordCount
            marshalSize += 4;  // this._variableDatumRecordCount
            for (int idx = 0; idx < this._fixedDatums.Count; idx++)
            {
                FixedDatum listElement = (FixedDatum)this._fixedDatums[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._variableDatums.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)this._variableDatums[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of request
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "requestID")]
        public uint RequestID
        {
            get
            {
                return this._requestID;
            }

            set
            {
                this._requestID = value;
            }
        }

        /// <summary>
        /// Gets or sets the time issues between issues of Data PDUs. Zero means send once only.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "timeInterval")]
        public uint TimeInterval
        {
            get
            {
                return this._timeInterval;
            }

            set
            {
                this._timeInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of fixed datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getfixedDatumRecordCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "fixedDatumRecordCount")]
        public uint FixedDatumRecordCount
        {
            get
            {
                return this._fixedDatumRecordCount;
            }

            set
            {
                this._fixedDatumRecordCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of variable datum records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getvariableDatumRecordCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(uint), ElementName = "variableDatumRecordCount")]
        public uint VariableDatumRecordCount
        {
            get
            {
                return this._variableDatumRecordCount;
            }

            set
            {
                this._variableDatumRecordCount = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of fixed datums
        /// </summary>
        [XmlElement(ElementName = "fixedDatumsList", Type = typeof(List<FixedDatum>))]
        public List<FixedDatum> FixedDatums
        {
            get
            {
                return this._fixedDatums;
            }
        }

        /// <summary>
        /// Gets the variable length list of variable length datums
        /// </summary>
        [XmlElement(ElementName = "variableDatumsList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatums
        {
            get
            {
                return this._variableDatums;
            }
        }

        /// <summary>
        /// Automatically sets the length of the marshalled data, then calls the marshal method.
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            this.Length = (ushort)this.GetMarshalledSize();
            this.Marshal(dos);
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
                    dos.WriteUnsignedInt((uint)this._requestID);
                    dos.WriteUnsignedInt((uint)this._timeInterval);
                    dos.WriteUnsignedInt((uint)this._fixedDatums.Count);
                    dos.WriteUnsignedInt((uint)this._variableDatums.Count);

                    for (int idx = 0; idx < this._fixedDatums.Count; idx++)
                    {
                        FixedDatum aFixedDatum = (FixedDatum)this._fixedDatums[idx];
                        aFixedDatum.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._variableDatums.Count; idx++)
                    {
                        VariableDatum aVariableDatum = (VariableDatum)this._variableDatums[idx];
                        aVariableDatum.Marshal(dos);
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
                    this._requestID = dis.ReadUnsignedInt();
                    this._timeInterval = dis.ReadUnsignedInt();
                    this._fixedDatumRecordCount = dis.ReadUnsignedInt();
                    this._variableDatumRecordCount = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < this.FixedDatumRecordCount; idx++)
                    {
                        FixedDatum anX = new FixedDatum();
                        anX.Unmarshal(dis);
                        this._fixedDatums.Add(anX);
                    }

                    for (int idx = 0; idx < this.VariableDatumRecordCount; idx++)
                    {
                        VariableDatum anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        this._variableDatums.Add(anX);
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
            sb.AppendLine("<DataQueryPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<requestID type=\"uint\">" + this._requestID.ToString(CultureInfo.InvariantCulture) + "</requestID>");
                sb.AppendLine("<timeInterval type=\"uint\">" + this._timeInterval.ToString(CultureInfo.InvariantCulture) + "</timeInterval>");
                sb.AppendLine("<fixedDatums type=\"uint\">" + this._fixedDatums.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatums>");
                sb.AppendLine("<variableDatums type=\"uint\">" + this._variableDatums.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
                for (int idx = 0; idx < this._fixedDatums.Count; idx++)
                {
                    sb.AppendLine("<fixedDatums" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
                    FixedDatum aFixedDatum = (FixedDatum)this._fixedDatums[idx];
                    aFixedDatum.Reflection(sb);
                    sb.AppendLine("</fixedDatums" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._variableDatums.Count; idx++)
                {
                    sb.AppendLine("<variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    VariableDatum aVariableDatum = (VariableDatum)this._variableDatums[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</variableDatums" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DataQueryPdu>");
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
            return this == obj as DataQueryPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DataQueryPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._requestID != obj._requestID)
            {
                ivarsEqual = false;
            }

            if (this._timeInterval != obj._timeInterval)
            {
                ivarsEqual = false;
            }

            if (this._fixedDatumRecordCount != obj._fixedDatumRecordCount)
            {
                ivarsEqual = false;
            }

            if (this._variableDatumRecordCount != obj._variableDatumRecordCount)
            {
                ivarsEqual = false;
            }

            if (this._fixedDatums.Count != obj._fixedDatums.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._fixedDatums.Count; idx++)
                {
                    if (!this._fixedDatums[idx].Equals(obj._fixedDatums[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._variableDatums.Count != obj._variableDatums.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._variableDatums.Count; idx++)
                {
                    if (!this._variableDatums[idx].Equals(obj._variableDatums[idx]))
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

            result = GenerateHash(result) ^ this._requestID.GetHashCode();
            result = GenerateHash(result) ^ this._timeInterval.GetHashCode();
            result = GenerateHash(result) ^ this._fixedDatumRecordCount.GetHashCode();
            result = GenerateHash(result) ^ this._variableDatumRecordCount.GetHashCode();

            if (this._fixedDatums.Count > 0)
            {
                for (int idx = 0; idx < this._fixedDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._fixedDatums[idx].GetHashCode();
                }
            }

            if (this._variableDatums.Count > 0)
            {
                for (int idx = 0; idx < this._variableDatums.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._variableDatums[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
