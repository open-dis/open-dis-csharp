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

namespace OpenDis.Dis1998
{
    /// <summary>
    /// 5.2.42. Basic operational data ofr IFF ATC NAVAIDS
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class IffFundamentalData : IEquatable<IffFundamentalData>, IReflectable
    {
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
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IffFundamentalData left, IffFundamentalData right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IffFundamentalData left, IffFundamentalData right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

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
        public byte SystemStatus { get; set; }

        /// <summary>
        /// Gets or sets the Alternate parameter 4
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "alternateParameter4")]
        public byte AlternateParameter4 { get; set; }

        /// <summary>
        /// Gets or sets the eight boolean fields
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "informationLayers")]
        public byte InformationLayers { get; set; }

        /// <summary>
        /// Gets or sets the enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modifier")]
        public byte Modifier { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter1")]
        public ushort Parameter1 { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter2")]
        public ushort Parameter2 { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter3")]
        public ushort Parameter3 { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter4")]
        public ushort Parameter4 { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter5")]
        public ushort Parameter5 { get; set; }

        /// <summary>
        /// Gets or sets the parameter, enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "parameter6")]
        public ushort Parameter6 { get; set; }

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
                    dos.WriteUnsignedByte(SystemStatus);
                    dos.WriteUnsignedByte(AlternateParameter4);
                    dos.WriteUnsignedByte(InformationLayers);
                    dos.WriteUnsignedByte(Modifier);
                    dos.WriteUnsignedShort(Parameter1);
                    dos.WriteUnsignedShort(Parameter2);
                    dos.WriteUnsignedShort(Parameter3);
                    dos.WriteUnsignedShort(Parameter4);
                    dos.WriteUnsignedShort(Parameter5);
                    dos.WriteUnsignedShort(Parameter6);
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
                    SystemStatus = dis.ReadUnsignedByte();
                    AlternateParameter4 = dis.ReadUnsignedByte();
                    InformationLayers = dis.ReadUnsignedByte();
                    Modifier = dis.ReadUnsignedByte();
                    Parameter1 = dis.ReadUnsignedShort();
                    Parameter2 = dis.ReadUnsignedShort();
                    Parameter3 = dis.ReadUnsignedShort();
                    Parameter4 = dis.ReadUnsignedShort();
                    Parameter5 = dis.ReadUnsignedShort();
                    Parameter6 = dis.ReadUnsignedShort();
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
            sb.AppendLine("<IffFundamentalData>");
            try
            {
                sb.AppendLine("<systemStatus type=\"byte\">" + SystemStatus.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
                sb.AppendLine("<alternateParameter4 type=\"byte\">" + AlternateParameter4.ToString(CultureInfo.InvariantCulture) + "</alternateParameter4>");
                sb.AppendLine("<informationLayers type=\"byte\">" + InformationLayers.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
                sb.AppendLine("<modifier type=\"byte\">" + Modifier.ToString(CultureInfo.InvariantCulture) + "</modifier>");
                sb.AppendLine("<parameter1 type=\"ushort\">" + Parameter1.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
                sb.AppendLine("<parameter2 type=\"ushort\">" + Parameter2.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
                sb.AppendLine("<parameter3 type=\"ushort\">" + Parameter3.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
                sb.AppendLine("<parameter4 type=\"ushort\">" + Parameter4.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
                sb.AppendLine("<parameter5 type=\"ushort\">" + Parameter5.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
                sb.AppendLine("<parameter6 type=\"ushort\">" + Parameter6.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
                sb.AppendLine("</IffFundamentalData>");
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
        public override bool Equals(object obj) => this == obj as IffFundamentalData;

        ///<inheritdoc/>
        public bool Equals(IffFundamentalData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (SystemStatus != obj.SystemStatus)
            {
                ivarsEqual = false;
            }

            if (AlternateParameter4 != obj.AlternateParameter4)
            {
                ivarsEqual = false;
            }

            if (InformationLayers != obj.InformationLayers)
            {
                ivarsEqual = false;
            }

            if (Modifier != obj.Modifier)
            {
                ivarsEqual = false;
            }

            if (Parameter1 != obj.Parameter1)
            {
                ivarsEqual = false;
            }

            if (Parameter2 != obj.Parameter2)
            {
                ivarsEqual = false;
            }

            if (Parameter3 != obj.Parameter3)
            {
                ivarsEqual = false;
            }

            if (Parameter4 != obj.Parameter4)
            {
                ivarsEqual = false;
            }

            if (Parameter5 != obj.Parameter5)
            {
                ivarsEqual = false;
            }

            if (Parameter6 != obj.Parameter6)
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

            result = GenerateHash(result) ^ SystemStatus.GetHashCode();
            result = GenerateHash(result) ^ AlternateParameter4.GetHashCode();
            result = GenerateHash(result) ^ InformationLayers.GetHashCode();
            result = GenerateHash(result) ^ Modifier.GetHashCode();
            result = GenerateHash(result) ^ Parameter1.GetHashCode();
            result = GenerateHash(result) ^ Parameter2.GetHashCode();
            result = GenerateHash(result) ^ Parameter3.GetHashCode();
            result = GenerateHash(result) ^ Parameter4.GetHashCode();
            result = GenerateHash(result) ^ Parameter5.GetHashCode();
            result = GenerateHash(result) ^ Parameter6.GetHashCode();

            return result;
        }
    }
}
