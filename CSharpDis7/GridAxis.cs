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
    /// Grid axis record for fixed data. Section 6.2.41
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class GridAxis
    {
        /// <summary>
        /// coordinate of the grid origin or initial value
        /// </summary>
        private double _domainInitialXi;

        /// <summary>
        /// coordinate of the endpoint or final value
        /// </summary>
        private double _domainFinalXi;

        /// <summary>
        /// The number of grid points along the Xi domain axis for the enviornmental state data
        /// </summary>
        private ushort _domainPointsXi;

        /// <summary>
        /// interleaf factor along the domain axis.
        /// </summary>
        private byte _interleafFactor;

        /// <summary>
        /// type of grid axis
        /// </summary>
        private byte _axisType;

        /// <summary>
        /// Number of grid locations along Xi axis
        /// </summary>
        private ushort _numberOfPointsOnXiAxis;

        /// <summary>
        /// initial grid point for the current pdu
        /// </summary>
        private ushort _initialIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridAxis"/> class.
        /// </summary>
        public GridAxis()
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
        public static bool operator !=(GridAxis left, GridAxis right)
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
        public static bool operator ==(GridAxis left, GridAxis right)
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

            marshalSize += 8;  // this._domainInitialXi
            marshalSize += 8;  // this._domainFinalXi
            marshalSize += 2;  // this._domainPointsXi
            marshalSize += 1;  // this._interleafFactor
            marshalSize += 1;  // this._axisType
            marshalSize += 2;  // this._numberOfPointsOnXiAxis
            marshalSize += 2;  // this._initialIndex
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the coordinate of the grid origin or initial value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "domainInitialXi")]
        public double DomainInitialXi
        {
            get
            {
                return this._domainInitialXi;
            }

            set
            {
                this._domainInitialXi = value;
            }
        }

        /// <summary>
        /// Gets or sets the coordinate of the endpoint or final value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "domainFinalXi")]
        public double DomainFinalXi
        {
            get
            {
                return this._domainFinalXi;
            }

            set
            {
                this._domainFinalXi = value;
            }
        }

        /// <summary>
        /// Gets or sets the The number of grid points along the Xi domain axis for the enviornmental state data
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "domainPointsXi")]
        public ushort DomainPointsXi
        {
            get
            {
                return this._domainPointsXi;
            }

            set
            {
                this._domainPointsXi = value;
            }
        }

        /// <summary>
        /// Gets or sets the interleaf factor along the domain axis.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "interleafFactor")]
        public byte InterleafFactor
        {
            get
            {
                return this._interleafFactor;
            }

            set
            {
                this._interleafFactor = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of grid axis
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "axisType")]
        public byte AxisType
        {
            get
            {
                return this._axisType;
            }

            set
            {
                this._axisType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of grid locations along Xi axis
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfPointsOnXiAxis")]
        public ushort NumberOfPointsOnXiAxis
        {
            get
            {
                return this._numberOfPointsOnXiAxis;
            }

            set
            {
                this._numberOfPointsOnXiAxis = value;
            }
        }

        /// <summary>
        /// Gets or sets the initial grid point for the current pdu
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "initialIndex")]
        public ushort InitialIndex
        {
            get
            {
                return this._initialIndex;
            }

            set
            {
                this._initialIndex = value;
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
                    dos.WriteDouble((double)this._domainInitialXi);
                    dos.WriteDouble((double)this._domainFinalXi);
                    dos.WriteUnsignedShort((ushort)this._domainPointsXi);
                    dos.WriteUnsignedByte((byte)this._interleafFactor);
                    dos.WriteUnsignedByte((byte)this._axisType);
                    dos.WriteUnsignedShort((ushort)this._numberOfPointsOnXiAxis);
                    dos.WriteUnsignedShort((ushort)this._initialIndex);
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
                    this._domainInitialXi = dis.ReadDouble();
                    this._domainFinalXi = dis.ReadDouble();
                    this._domainPointsXi = dis.ReadUnsignedShort();
                    this._interleafFactor = dis.ReadUnsignedByte();
                    this._axisType = dis.ReadUnsignedByte();
                    this._numberOfPointsOnXiAxis = dis.ReadUnsignedShort();
                    this._initialIndex = dis.ReadUnsignedShort();
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
            sb.AppendLine("<GridAxis>");
            try
            {
                sb.AppendLine("<domainInitialXi type=\"double\">" + this._domainInitialXi.ToString(CultureInfo.InvariantCulture) + "</domainInitialXi>");
                sb.AppendLine("<domainFinalXi type=\"double\">" + this._domainFinalXi.ToString(CultureInfo.InvariantCulture) + "</domainFinalXi>");
                sb.AppendLine("<domainPointsXi type=\"ushort\">" + this._domainPointsXi.ToString(CultureInfo.InvariantCulture) + "</domainPointsXi>");
                sb.AppendLine("<interleafFactor type=\"byte\">" + this._interleafFactor.ToString(CultureInfo.InvariantCulture) + "</interleafFactor>");
                sb.AppendLine("<axisType type=\"byte\">" + this._axisType.ToString(CultureInfo.InvariantCulture) + "</axisType>");
                sb.AppendLine("<numberOfPointsOnXiAxis type=\"ushort\">" + this._numberOfPointsOnXiAxis.ToString(CultureInfo.InvariantCulture) + "</numberOfPointsOnXiAxis>");
                sb.AppendLine("<initialIndex type=\"ushort\">" + this._initialIndex.ToString(CultureInfo.InvariantCulture) + "</initialIndex>");
                sb.AppendLine("</GridAxis>");
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
            return this == obj as GridAxis;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(GridAxis obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._domainInitialXi != obj._domainInitialXi)
            {
                ivarsEqual = false;
            }

            if (this._domainFinalXi != obj._domainFinalXi)
            {
                ivarsEqual = false;
            }

            if (this._domainPointsXi != obj._domainPointsXi)
            {
                ivarsEqual = false;
            }

            if (this._interleafFactor != obj._interleafFactor)
            {
                ivarsEqual = false;
            }

            if (this._axisType != obj._axisType)
            {
                ivarsEqual = false;
            }

            if (this._numberOfPointsOnXiAxis != obj._numberOfPointsOnXiAxis)
            {
                ivarsEqual = false;
            }

            if (this._initialIndex != obj._initialIndex)
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

            result = GenerateHash(result) ^ this._domainInitialXi.GetHashCode();
            result = GenerateHash(result) ^ this._domainFinalXi.GetHashCode();
            result = GenerateHash(result) ^ this._domainPointsXi.GetHashCode();
            result = GenerateHash(result) ^ this._interleafFactor.GetHashCode();
            result = GenerateHash(result) ^ this._axisType.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfPointsOnXiAxis.GetHashCode();
            result = GenerateHash(result) ^ this._initialIndex.GetHashCode();

            return result;
        }
    }
}
