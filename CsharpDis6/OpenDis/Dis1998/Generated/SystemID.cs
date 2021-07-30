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
    /// 5.2.58. Used in IFF ATC PDU
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class SystemID : IEquatable<SystemID>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemID"/> class.
        /// </summary>
        public SystemID()
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
        public static bool operator !=(SystemID left, SystemID right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(SystemID left, SystemID right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 2;  // this._systemType
            marshalSize += 2;  // this._systemName
            marshalSize += 1;  // this._systemMode
            marshalSize += 1;  // this._changeOptions
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the System Type
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "systemType")]
        public ushort SystemType { get; set; }

        /// <summary>
        /// Gets or sets the System name, an enumeration
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "systemName")]
        public ushort SystemName { get; set; }

        /// <summary>
        /// Gets or sets the System mode
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "systemMode")]
        public byte SystemMode { get; set; }

        /// <summary>
        /// Gets or sets the Change Options
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "changeOptions")]
        public byte ChangeOptions { get; set; }

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
                    dos.WriteUnsignedShort(SystemType);
                    dos.WriteUnsignedShort(SystemName);
                    dos.WriteUnsignedByte(SystemMode);
                    dos.WriteUnsignedByte(ChangeOptions);
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
                    SystemType = dis.ReadUnsignedShort();
                    SystemName = dis.ReadUnsignedShort();
                    SystemMode = dis.ReadUnsignedByte();
                    ChangeOptions = dis.ReadUnsignedByte();
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
            sb.AppendLine("<SystemID>");
            try
            {
                sb.AppendLine("<systemType type=\"ushort\">" + SystemType.ToString(CultureInfo.InvariantCulture) + "</systemType>");
                sb.AppendLine("<systemName type=\"ushort\">" + SystemName.ToString(CultureInfo.InvariantCulture) + "</systemName>");
                sb.AppendLine("<systemMode type=\"byte\">" + SystemMode.ToString(CultureInfo.InvariantCulture) + "</systemMode>");
                sb.AppendLine("<changeOptions type=\"byte\">" + ChangeOptions.ToString(CultureInfo.InvariantCulture) + "</changeOptions>");
                sb.AppendLine("</SystemID>");
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
        public override bool Equals(object obj) => this == obj as SystemID;

        ///<inheritdoc/>
        public bool Equals(SystemID obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (SystemType != obj.SystemType)
            {
                ivarsEqual = false;
            }

            if (SystemName != obj.SystemName)
            {
                ivarsEqual = false;
            }

            if (SystemMode != obj.SystemMode)
            {
                ivarsEqual = false;
            }

            if (ChangeOptions != obj.ChangeOptions)
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

            result = GenerateHash(result) ^ SystemType.GetHashCode();
            result = GenerateHash(result) ^ SystemName.GetHashCode();
            result = GenerateHash(result) ^ SystemMode.GetHashCode();
            result = GenerateHash(result) ^ ChangeOptions.GetHashCode();

            return result;
        }
    }
}
