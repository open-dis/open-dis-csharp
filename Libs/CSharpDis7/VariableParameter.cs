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
    /// specification of additional information associated with an entity or detonation, not otherwise accounted for in a PDU 6.2.93.1
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class VariableParameter
    {
        /// <summary>
        /// the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        private byte _recordType;

        /// <summary>
        /// Variable parameter data fields. Two doubles minus one byte
        /// </summary>
        private double _variableParameterFields1;

        /// <summary>
        /// Variable parameter data fields. 
        /// </summary>
        private uint _variableParameterFields2;

        /// <summary>
        /// Variable parameter data fields. 
        /// </summary>
        private ushort _variableParameterFields3;

        /// <summary>
        /// Variable parameter data fields. 
        /// </summary>
        private byte _variableParameterFields4;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableParameter"/> class.
        /// </summary>
        public VariableParameter()
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
        public static bool operator !=(VariableParameter left, VariableParameter right)
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
        public static bool operator ==(VariableParameter left, VariableParameter right)
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

            marshalSize += 1;  // this._recordType
            marshalSize += 8;  // this._variableParameterFields1
            marshalSize += 4;  // this._variableParameterFields2
            marshalSize += 2;  // this._variableParameterFields3
            marshalSize += 1;  // this._variableParameterFields4
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the the identification of the Variable Parameter record. Enumeration from EBV
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "recordType")]
        public byte RecordType
        {
            get
            {
                return this._recordType;
            }

            set
            {
                this._recordType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Variable parameter data fields. Two doubles minus one byte
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "variableParameterFields1")]
        public double VariableParameterFields1
        {
            get
            {
                return this._variableParameterFields1;
            }

            set
            {
                this._variableParameterFields1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Variable parameter data fields. 
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "variableParameterFields2")]
        public uint VariableParameterFields2
        {
            get
            {
                return this._variableParameterFields2;
            }

            set
            {
                this._variableParameterFields2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Variable parameter data fields. 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "variableParameterFields3")]
        public ushort VariableParameterFields3
        {
            get
            {
                return this._variableParameterFields3;
            }

            set
            {
                this._variableParameterFields3 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Variable parameter data fields. 
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "variableParameterFields4")]
        public byte VariableParameterFields4
        {
            get
            {
                return this._variableParameterFields4;
            }

            set
            {
                this._variableParameterFields4 = value;
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
                    dos.WriteUnsignedByte((byte)this._recordType);
                    dos.WriteDouble((double)this._variableParameterFields1);
                    dos.WriteUnsignedInt((uint)this._variableParameterFields2);
                    dos.WriteUnsignedShort((ushort)this._variableParameterFields3);
                    dos.WriteUnsignedByte((byte)this._variableParameterFields4);
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
                    this._recordType = dis.ReadUnsignedByte();
                    this._variableParameterFields1 = dis.ReadDouble();
                    this._variableParameterFields2 = dis.ReadUnsignedInt();
                    this._variableParameterFields3 = dis.ReadUnsignedShort();
                    this._variableParameterFields4 = dis.ReadUnsignedByte();
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
            sb.AppendLine("<VariableParameter>");
            try
            {
                sb.AppendLine("<recordType type=\"byte\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<variableParameterFields1 type=\"double\">" + this._variableParameterFields1.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields1>");
                sb.AppendLine("<variableParameterFields2 type=\"uint\">" + this._variableParameterFields2.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields2>");
                sb.AppendLine("<variableParameterFields3 type=\"ushort\">" + this._variableParameterFields3.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields3>");
                sb.AppendLine("<variableParameterFields4 type=\"byte\">" + this._variableParameterFields4.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields4>");
                sb.AppendLine("</VariableParameter>");
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
            return this == obj as VariableParameter;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(VariableParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._recordType != obj._recordType)
            {
                ivarsEqual = false;
            }

            if (this._variableParameterFields1 != obj._variableParameterFields1)
            {
                ivarsEqual = false;
            }

            if (this._variableParameterFields2 != obj._variableParameterFields2)
            {
                ivarsEqual = false;
            }

            if (this._variableParameterFields3 != obj._variableParameterFields3)
            {
                ivarsEqual = false;
            }

            if (this._variableParameterFields4 != obj._variableParameterFields4)
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

            result = GenerateHash(result) ^ this._recordType.GetHashCode();
            result = GenerateHash(result) ^ this._variableParameterFields1.GetHashCode();
            result = GenerateHash(result) ^ this._variableParameterFields2.GetHashCode();
            result = GenerateHash(result) ^ this._variableParameterFields3.GetHashCode();
            result = GenerateHash(result) ^ this._variableParameterFields4.GetHashCode();

            return result;
        }
    }
}
