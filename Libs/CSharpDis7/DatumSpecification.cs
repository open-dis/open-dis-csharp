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
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// List of fixed and variable datum records. Section 6.2.19 
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FixedDatum))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class DatumSpecification
    {
        /// <summary>
        /// Number of fixed datums
        /// </summary>
        private uint _numberOfFixedDatums;

        /// <summary>
        /// Number of variable datums
        /// </summary>
        private uint _numberOfVariableDatums;

        /// <summary>
        /// variable length list fixed datums
        /// </summary>
        private List<FixedDatum> _fixedDatumIDList = new List<FixedDatum>();

        /// <summary>
        /// variable length list variable datums
        /// </summary>
        private List<VariableDatum> _variableDatumIDList = new List<VariableDatum>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DatumSpecification"/> class.
        /// </summary>
        public DatumSpecification()
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
        public static bool operator !=(DatumSpecification left, DatumSpecification right)
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
        public static bool operator ==(DatumSpecification left, DatumSpecification right)
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

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize += 4;  // this._numberOfFixedDatums
            marshalSize += 4;  // this._numberOfVariableDatums
            for (int idx = 0; idx < this._fixedDatumIDList.Count; idx++)
            {
                FixedDatum listElement = (FixedDatum)this._fixedDatumIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._variableDatumIDList.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)this._variableDatumIDList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfFixedDatums method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatums")]
        public uint NumberOfFixedDatums
        {
            get
            {
                return this._numberOfFixedDatums;
            }

            set
            {
                this._numberOfFixedDatums = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVariableDatums method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatums")]
        public uint NumberOfVariableDatums
        {
            get
            {
                return this._numberOfVariableDatums;
            }

            set
            {
                this._numberOfVariableDatums = value;
            }
        }

        /// <summary>
        /// Gets or sets the variable length list fixed datums
        /// </summary>
        [XmlElement(ElementName = "fixedDatumIDListList", Type = typeof(List<FixedDatum>))]
        public List<FixedDatum> FixedDatumIDList
        {
            get
            {
                return this._fixedDatumIDList;
            }
        }

        /// <summary>
        /// Gets or sets the variable length list variable datums
        /// </summary>
        [XmlElement(ElementName = "variableDatumIDListList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> VariableDatumIDList
        {
            get
            {
                return this._variableDatumIDList;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt((uint)this._fixedDatumIDList.Count);
                    dos.WriteUnsignedInt((uint)this._variableDatumIDList.Count);

                    for (int idx = 0; idx < this._fixedDatumIDList.Count; idx++)
                    {
                        FixedDatum aFixedDatum = (FixedDatum)this._fixedDatumIDList[idx];
                        aFixedDatum.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._variableDatumIDList.Count; idx++)
                    {
                        VariableDatum aVariableDatum = (VariableDatum)this._variableDatumIDList[idx];
                        aVariableDatum.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                    this._numberOfFixedDatums = dis.ReadUnsignedInt();
                    this._numberOfVariableDatums = dis.ReadUnsignedInt();
                    for (int idx = 0; idx < this.NumberOfFixedDatums; idx++)
                    {
                        FixedDatum anX = new FixedDatum();
                        anX.Unmarshal(dis);
                        this._fixedDatumIDList.Add(anX);
                    };

                    for (int idx = 0; idx < this.NumberOfVariableDatums; idx++)
                    {
                        VariableDatum anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        this._variableDatumIDList.Add(anX);
                    };

                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<DatumSpecification>");
            try
            {
                sb.AppendLine("<fixedDatumIDList type=\"uint\">" + this._fixedDatumIDList.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumIDList>");
                sb.AppendLine("<variableDatumIDList type=\"uint\">" + this._variableDatumIDList.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumIDList>");
                for (int idx = 0; idx < this._fixedDatumIDList.Count; idx++)
                {
                    sb.AppendLine("<fixedDatumIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
                    FixedDatum aFixedDatum = (FixedDatum)this._fixedDatumIDList[idx];
                    aFixedDatum.Reflection(sb);
                    sb.AppendLine("</fixedDatumIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._variableDatumIDList.Count; idx++)
                {
                    sb.AppendLine("<variableDatumIDList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    VariableDatum aVariableDatum = (VariableDatum)this._variableDatumIDList[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</variableDatumIDList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DatumSpecification>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
            return this == obj as DatumSpecification;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DatumSpecification obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._numberOfFixedDatums != obj._numberOfFixedDatums)
            {
                ivarsEqual = false;
            }

            if (this._numberOfVariableDatums != obj._numberOfVariableDatums)
            {
                ivarsEqual = false;
            }

            if (this._fixedDatumIDList.Count != obj._fixedDatumIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._fixedDatumIDList.Count; idx++)
                {
                    if (!this._fixedDatumIDList[idx].Equals(obj._fixedDatumIDList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._variableDatumIDList.Count != obj._variableDatumIDList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._variableDatumIDList.Count; idx++)
                {
                    if (!this._variableDatumIDList[idx].Equals(obj._variableDatumIDList[idx]))
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

            result = GenerateHash(result) ^ this._numberOfFixedDatums.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfVariableDatums.GetHashCode();

            if (this._fixedDatumIDList.Count > 0)
            {
                for (int idx = 0; idx < this._fixedDatumIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._fixedDatumIDList[idx].GetHashCode();
                }
            }

            if (this._variableDatumIDList.Count > 0)
            {
                for (int idx = 0; idx < this._variableDatumIDList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._variableDatumIDList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
