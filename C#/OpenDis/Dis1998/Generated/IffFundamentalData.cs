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
    /// 5.2.42. Basic operational data ofr IFF ATC NAVAIDS
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class IffFundamentalData
    {
        /// <summary>
        /// system status
        /// </summary>
        private byte _systemStatus;

        /// <summary>
        /// Alternate parameter 4
        /// </summary>
        private byte _alternateParameter4;

        /// <summary>
        /// eight boolean fields
        /// </summary>
        private byte _informationLayers;

        /// <summary>
        /// enumeration
        /// </summary>
        private byte _modifier;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter1;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter2;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter3;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter4;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter5;

        /// <summary>
        /// parameter, enumeration
        /// </summary>
        private ushort _parameter6;

        /// <summary>
        /// Initializes a new instance of the <see cref="IffFundamentalData"/> class.
        /// </summary>
        public IffFundamentalData()
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
        public static bool operator !=(IffFundamentalData left, IffFundamentalData right)
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
        public static bool operator ==(IffFundamentalData left, IffFundamentalData right)
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

            marshalSize += 1;  // this._systemStatus
            marshalSize += 1;  // this._alternateParameter4
            marshalSize += 1;  // this._informationLayers
            marshalSize += 1;  // this._modifier
            marshalSize += 2;  // this._parameter1
            marshalSize += 2;  // this._parameter2
            marshalSize += 2;  // this._parameter3
            marshalSize += 2;  // this._parameter4
            marshalSize += 2;  // this._parameter5
            marshalSize += 2;  // this._parameter6
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the system status
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "systemStatus")]
        public byte SystemStatus
        {
            get
            {
                return this._systemStatus;
            }

            set
            {
                this._systemStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the Alternate parameter 4
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "alternateParameter4")]
        public byte AlternateParameter4
        {
            get
            {
                return this._alternateParameter4;
            }

            set
            {
                this._alternateParameter4 = value;
            }
        }

        /// <summary>
        /// Gets or sets the eight boolean fields
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "informationLayers")]
        public byte InformationLayers
        {
            get
            {
                return this._informationLayers;
            }

            set
            {
                this._informationLayers = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modifier")]
        public byte Modifier
        {
            get
            {
                return this._modifier;
            }

            set
            {
                this._modifier = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter1")]
        public ushort Parameter1
        {
            get
            {
                return this._parameter1;
            }

            set
            {
                this._parameter1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter2")]
        public ushort Parameter2
        {
            get
            {
                return this._parameter2;
            }

            set
            {
                this._parameter2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter3")]
        public ushort Parameter3
        {
            get
            {
                return this._parameter3;
            }

            set
            {
                this._parameter3 = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter4")]
        public ushort Parameter4
        {
            get
            {
                return this._parameter4;
            }

            set
            {
                this._parameter4 = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter5")]
        public ushort Parameter5
        {
            get
            {
                return this._parameter5;
            }

            set
            {
                this._parameter5 = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter6")]
        public ushort Parameter6
        {
            get
            {
                return this._parameter6;
            }

            set
            {
                this._parameter6 = value;
            }
        }

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
            if (Pdu.FireExceptionEvents && this.ExceptionOccured != null)
            {
                this.ExceptionOccured(this, new PduExceptionEventArgs(e));
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
                    dos.WriteUnsignedByte((byte)this._systemStatus);
                    dos.WriteUnsignedByte((byte)this._alternateParameter4);
                    dos.WriteUnsignedByte((byte)this._informationLayers);
                    dos.WriteUnsignedByte((byte)this._modifier);
                    dos.WriteUnsignedShort((ushort)this._parameter1);
                    dos.WriteUnsignedShort((ushort)this._parameter2);
                    dos.WriteUnsignedShort((ushort)this._parameter3);
                    dos.WriteUnsignedShort((ushort)this._parameter4);
                    dos.WriteUnsignedShort((ushort)this._parameter5);
                    dos.WriteUnsignedShort((ushort)this._parameter6);
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
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    this._systemStatus = dis.ReadUnsignedByte();
                    this._alternateParameter4 = dis.ReadUnsignedByte();
                    this._informationLayers = dis.ReadUnsignedByte();
                    this._modifier = dis.ReadUnsignedByte();
                    this._parameter1 = dis.ReadUnsignedShort();
                    this._parameter2 = dis.ReadUnsignedShort();
                    this._parameter3 = dis.ReadUnsignedShort();
                    this._parameter4 = dis.ReadUnsignedShort();
                    this._parameter5 = dis.ReadUnsignedShort();
                    this._parameter6 = dis.ReadUnsignedShort();
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
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<IffFundamentalData>");
            try
            {
                sb.AppendLine("<systemStatus type=\"byte\">" + this._systemStatus.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
                sb.AppendLine("<alternateParameter4 type=\"byte\">" + this._alternateParameter4.ToString(CultureInfo.InvariantCulture) + "</alternateParameter4>");
                sb.AppendLine("<informationLayers type=\"byte\">" + this._informationLayers.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
                sb.AppendLine("<modifier type=\"byte\">" + this._modifier.ToString(CultureInfo.InvariantCulture) + "</modifier>");
                sb.AppendLine("<parameter1 type=\"ushort\">" + this._parameter1.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
                sb.AppendLine("<parameter2 type=\"ushort\">" + this._parameter2.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
                sb.AppendLine("<parameter3 type=\"ushort\">" + this._parameter3.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
                sb.AppendLine("<parameter4 type=\"ushort\">" + this._parameter4.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
                sb.AppendLine("<parameter5 type=\"ushort\">" + this._parameter5.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
                sb.AppendLine("<parameter6 type=\"ushort\">" + this._parameter6.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
                sb.AppendLine("</IffFundamentalData>");
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
            return this == obj as IffFundamentalData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IffFundamentalData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._systemStatus != obj._systemStatus)
            {
                ivarsEqual = false;
            }

            if (this._alternateParameter4 != obj._alternateParameter4)
            {
                ivarsEqual = false;
            }

            if (this._informationLayers != obj._informationLayers)
            {
                ivarsEqual = false;
            }

            if (this._modifier != obj._modifier)
            {
                ivarsEqual = false;
            }

            if (this._parameter1 != obj._parameter1)
            {
                ivarsEqual = false;
            }

            if (this._parameter2 != obj._parameter2)
            {
                ivarsEqual = false;
            }

            if (this._parameter3 != obj._parameter3)
            {
                ivarsEqual = false;
            }

            if (this._parameter4 != obj._parameter4)
            {
                ivarsEqual = false;
            }

            if (this._parameter5 != obj._parameter5)
            {
                ivarsEqual = false;
            }

            if (this._parameter6 != obj._parameter6)
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

            result = GenerateHash(result) ^ this._systemStatus.GetHashCode();
            result = GenerateHash(result) ^ this._alternateParameter4.GetHashCode();
            result = GenerateHash(result) ^ this._informationLayers.GetHashCode();
            result = GenerateHash(result) ^ this._modifier.GetHashCode();
            result = GenerateHash(result) ^ this._parameter1.GetHashCode();
            result = GenerateHash(result) ^ this._parameter2.GetHashCode();
            result = GenerateHash(result) ^ this._parameter3.GetHashCode();
            result = GenerateHash(result) ^ this._parameter4.GetHashCode();
            result = GenerateHash(result) ^ this._parameter5.GetHashCode();
            result = GenerateHash(result) ^ this._parameter6.GetHashCode();

            return result;
        }
    }
}
