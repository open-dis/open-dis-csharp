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
    /// Section 5.2.40. Information about a geometry, a state associated with a geometry, a bounding volume, or an associated
    /// entity ID. NOTE: this class requires hand coding.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class Environment : IEquatable<Environment>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Environment"/> class.
        /// </summary>
        public Environment()
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
        public static bool operator !=(Environment left, Environment right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Environment left, Environment right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 4;  // this._environmentType
            marshalSize += 1;  // this._length
            marshalSize += 1;  // this._index
            marshalSize += 1;  // this._padding1
            marshalSize += 1;  // this._geometry
            marshalSize += 1;  // this._padding2
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Record type
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "environmentType")]
        public uint EnvironmentType { get; set; }

        /// <summary>
        /// Gets or sets the length, in bits
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "length")]
        public byte Length { get; set; }

        /// <summary>
        /// Gets or sets the Identify the sequentially numbered record index
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "index")]
        public byte Index { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding1")]
        public byte Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the Geometry or state record
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "geometry")]
        public byte Geometry { get; set; }

        /// <summary>
        /// Gets or sets the padding to bring the total size up to a 64 bit boundry
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2 { get; set; }

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
                    dos.WriteUnsignedInt(EnvironmentType);
                    dos.WriteUnsignedByte(Length);
                    dos.WriteUnsignedByte(Index);
                    dos.WriteUnsignedByte(Padding1);
                    dos.WriteUnsignedByte(Geometry);
                    dos.WriteUnsignedByte(Padding2);
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
                    EnvironmentType = dis.ReadUnsignedInt();
                    Length = dis.ReadUnsignedByte();
                    Index = dis.ReadUnsignedByte();
                    Padding1 = dis.ReadUnsignedByte();
                    Geometry = dis.ReadUnsignedByte();
                    Padding2 = dis.ReadUnsignedByte();
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
            sb.AppendLine("<Environment>");
            try
            {
                sb.AppendLine("<environmentType type=\"uint\">" + EnvironmentType.ToString(CultureInfo.InvariantCulture) + "</environmentType>");
                sb.AppendLine("<length type=\"byte\">" + Length.ToString(CultureInfo.InvariantCulture) + "</length>");
                sb.AppendLine("<index type=\"byte\">" + Index.ToString(CultureInfo.InvariantCulture) + "</index>");
                sb.AppendLine("<padding1 type=\"byte\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<geometry type=\"byte\">" + Geometry.ToString(CultureInfo.InvariantCulture) + "</geometry>");
                sb.AppendLine("<padding2 type=\"byte\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("</Environment>");
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
        public override bool Equals(object obj) => this == obj as Environment;

        ///<inheritdoc/>
        public bool Equals(Environment obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (EnvironmentType != obj.EnvironmentType)
            {
                ivarsEqual = false;
            }

            if (Length != obj.Length)
            {
                ivarsEqual = false;
            }

            if (Index != obj.Index)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (Geometry != obj.Geometry)
            {
                ivarsEqual = false;
            }

            if (Padding2 != obj.Padding2)
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

            result = GenerateHash(result) ^ EnvironmentType.GetHashCode();
            result = GenerateHash(result) ^ Length.GetHashCode();
            result = GenerateHash(result) ^ Index.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ Geometry.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();

            return result;
        }
    }
}
