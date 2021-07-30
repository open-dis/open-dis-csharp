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
    /// 5.2.48: Linear segment parameters
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(SixByteChunk))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    public partial class LinearSegmentParameter : IEquatable<LinearSegmentParameter>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearSegmentParameter"/> class.
        /// </summary>
        public LinearSegmentParameter()
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
        public static bool operator !=(LinearSegmentParameter left, LinearSegmentParameter right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(LinearSegmentParameter left, LinearSegmentParameter right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1;  // this._segmentNumber
            marshalSize += SegmentAppearance.GetMarshalledSize();  // this._segmentAppearance
            marshalSize += Location.GetMarshalledSize();  // this._location
            marshalSize += Orientation.GetMarshalledSize();  // this._orientation
            marshalSize += 2;  // this._segmentLength
            marshalSize += 2;  // this._segmentWidth
            marshalSize += 2;  // this._segmentHeight
            marshalSize += 2;  // this._segmentDepth
            marshalSize += 4;  // this._pad1
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the number of segments
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "segmentNumber")]
        public byte SegmentNumber { get; set; }

        /// <summary>
        /// Gets or sets the segment appearance
        /// </summary>
        [XmlElement(Type = typeof(SixByteChunk), ElementName = "segmentAppearance")]
        public SixByteChunk SegmentAppearance { get; set; } = new SixByteChunk();

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "location")]
        public Vector3Double Location { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the orientation
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
        public Orientation Orientation { get; set; } = new Orientation();

        /// <summary>
        /// Gets or sets the segmentLength
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
        public ushort SegmentLength { get; set; }

        /// <summary>
        /// Gets or sets the segmentWidth
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
        public ushort SegmentWidth { get; set; }

        /// <summary>
        /// Gets or sets the segmentHeight
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
        public ushort SegmentHeight { get; set; }

        /// <summary>
        /// Gets or sets the segment Depth
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
        public ushort SegmentDepth { get; set; }

        /// <summary>
        /// Gets or sets the segment Depth
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "pad1")]
        public uint Pad1 { get; set; }

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
                    dos.WriteUnsignedByte(SegmentNumber);
                    SegmentAppearance.Marshal(dos);
                    Location.Marshal(dos);
                    Orientation.Marshal(dos);
                    dos.WriteUnsignedShort(SegmentLength);
                    dos.WriteUnsignedShort(SegmentWidth);
                    dos.WriteUnsignedShort(SegmentHeight);
                    dos.WriteUnsignedShort(SegmentDepth);
                    dos.WriteUnsignedInt(Pad1);
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
                    SegmentNumber = dis.ReadUnsignedByte();
                    SegmentAppearance.Unmarshal(dis);
                    Location.Unmarshal(dis);
                    Orientation.Unmarshal(dis);
                    SegmentLength = dis.ReadUnsignedShort();
                    SegmentWidth = dis.ReadUnsignedShort();
                    SegmentHeight = dis.ReadUnsignedShort();
                    SegmentDepth = dis.ReadUnsignedShort();
                    Pad1 = dis.ReadUnsignedInt();
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
            sb.AppendLine("<LinearSegmentParameter>");
            try
            {
                sb.AppendLine("<segmentNumber type=\"byte\">" + SegmentNumber.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
                sb.AppendLine("<segmentAppearance>");
                SegmentAppearance.Reflection(sb);
                sb.AppendLine("</segmentAppearance>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<orientation>");
                Orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<segmentLength type=\"ushort\">" + SegmentLength.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
                sb.AppendLine("<segmentWidth type=\"ushort\">" + SegmentWidth.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
                sb.AppendLine("<segmentHeight type=\"ushort\">" + SegmentHeight.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
                sb.AppendLine("<segmentDepth type=\"ushort\">" + SegmentDepth.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
                sb.AppendLine("<pad1 type=\"uint\">" + Pad1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
                sb.AppendLine("</LinearSegmentParameter>");
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
        public override bool Equals(object obj) => this == obj as LinearSegmentParameter;

        ///<inheritdoc/>
        public bool Equals(LinearSegmentParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (SegmentNumber != obj.SegmentNumber)
            {
                ivarsEqual = false;
            }

            if (!SegmentAppearance.Equals(obj.SegmentAppearance))
            {
                ivarsEqual = false;
            }

            if (!Location.Equals(obj.Location))
            {
                ivarsEqual = false;
            }

            if (!Orientation.Equals(obj.Orientation))
            {
                ivarsEqual = false;
            }

            if (SegmentLength != obj.SegmentLength)
            {
                ivarsEqual = false;
            }

            if (SegmentWidth != obj.SegmentWidth)
            {
                ivarsEqual = false;
            }

            if (SegmentHeight != obj.SegmentHeight)
            {
                ivarsEqual = false;
            }

            if (SegmentDepth != obj.SegmentDepth)
            {
                ivarsEqual = false;
            }

            if (Pad1 != obj.Pad1)
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

            result = GenerateHash(result) ^ SegmentNumber.GetHashCode();
            result = GenerateHash(result) ^ SegmentAppearance.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();
            result = GenerateHash(result) ^ Orientation.GetHashCode();
            result = GenerateHash(result) ^ SegmentLength.GetHashCode();
            result = GenerateHash(result) ^ SegmentWidth.GetHashCode();
            result = GenerateHash(result) ^ SegmentHeight.GetHashCode();
            result = GenerateHash(result) ^ SegmentDepth.GetHashCode();
            result = GenerateHash(result) ^ Pad1.GetHashCode();

            return result;
        }
    }
}
