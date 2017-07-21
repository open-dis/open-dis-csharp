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
    /// 5.2.48: Linear segment parameters
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(SixByteChunk))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    public partial class LinearSegmentParameter
    {
        /// <summary>
        /// number of segments
        /// </summary>
        private byte _segmentNumber;

        /// <summary>
        /// segment appearance
        /// </summary>
        private SixByteChunk _segmentAppearance = new SixByteChunk();

        /// <summary>
        /// location
        /// </summary>
        private Vector3Double _location = new Vector3Double();

        /// <summary>
        /// orientation
        /// </summary>
        private Orientation _orientation = new Orientation();

        /// <summary>
        /// segmentLength
        /// </summary>
        private ushort _segmentLength;

        /// <summary>
        /// segmentWidth
        /// </summary>
        private ushort _segmentWidth;

        /// <summary>
        /// segmentHeight
        /// </summary>
        private ushort _segmentHeight;

        /// <summary>
        /// segment Depth
        /// </summary>
        private ushort _segmentDepth;

        /// <summary>
        /// segment Depth
        /// </summary>
        private uint _pad1;

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LinearSegmentParameter left, LinearSegmentParameter right)
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
        public static bool operator ==(LinearSegmentParameter left, LinearSegmentParameter right)
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

            marshalSize += 1;  // this._segmentNumber
            marshalSize += this._segmentAppearance.GetMarshalledSize();  // this._segmentAppearance
            marshalSize += this._location.GetMarshalledSize();  // this._location
            marshalSize += this._orientation.GetMarshalledSize();  // this._orientation
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
        public byte SegmentNumber
        {
            get
            {
                return this._segmentNumber;
            }

            set
            {
                this._segmentNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the segment appearance
        /// </summary>
        [XmlElement(Type = typeof(SixByteChunk), ElementName = "segmentAppearance")]
        public SixByteChunk SegmentAppearance
        {
            get
            {
                return this._segmentAppearance;
            }

            set
            {
                this._segmentAppearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "location")]
        public Vector3Double Location
        {
            get
            {
                return this._location;
            }

            set
            {
                this._location = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
        public Orientation Orientation
        {
            get
            {
                return this._orientation;
            }

            set
            {
                this._orientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the segmentLength
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
        public ushort SegmentLength
        {
            get
            {
                return this._segmentLength;
            }

            set
            {
                this._segmentLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the segmentWidth
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
        public ushort SegmentWidth
        {
            get
            {
                return this._segmentWidth;
            }

            set
            {
                this._segmentWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the segmentHeight
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
        public ushort SegmentHeight
        {
            get
            {
                return this._segmentHeight;
            }

            set
            {
                this._segmentHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the segment Depth
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
        public ushort SegmentDepth
        {
            get
            {
                return this._segmentDepth;
            }

            set
            {
                this._segmentDepth = value;
            }
        }

        /// <summary>
        /// Gets or sets the segment Depth
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "pad1")]
        public uint Pad1
        {
            get
            {
                return this._pad1;
            }

            set
            {
                this._pad1 = value;
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
                    dos.WriteUnsignedByte((byte)this._segmentNumber);
                    this._segmentAppearance.Marshal(dos);
                    this._location.Marshal(dos);
                    this._orientation.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._segmentLength);
                    dos.WriteUnsignedShort((ushort)this._segmentWidth);
                    dos.WriteUnsignedShort((ushort)this._segmentHeight);
                    dos.WriteUnsignedShort((ushort)this._segmentDepth);
                    dos.WriteUnsignedInt((uint)this._pad1);
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
                    this._segmentNumber = dis.ReadUnsignedByte();
                    this._segmentAppearance.Unmarshal(dis);
                    this._location.Unmarshal(dis);
                    this._orientation.Unmarshal(dis);
                    this._segmentLength = dis.ReadUnsignedShort();
                    this._segmentWidth = dis.ReadUnsignedShort();
                    this._segmentHeight = dis.ReadUnsignedShort();
                    this._segmentDepth = dis.ReadUnsignedShort();
                    this._pad1 = dis.ReadUnsignedInt();
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
            sb.AppendLine("<LinearSegmentParameter>");
            try
            {
                sb.AppendLine("<segmentNumber type=\"byte\">" + this._segmentNumber.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
                sb.AppendLine("<segmentAppearance>");
                this._segmentAppearance.Reflection(sb);
                sb.AppendLine("</segmentAppearance>");
                sb.AppendLine("<location>");
                this._location.Reflection(sb);
                sb.AppendLine("</location>");
                sb.AppendLine("<orientation>");
                this._orientation.Reflection(sb);
                sb.AppendLine("</orientation>");
                sb.AppendLine("<segmentLength type=\"ushort\">" + this._segmentLength.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
                sb.AppendLine("<segmentWidth type=\"ushort\">" + this._segmentWidth.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
                sb.AppendLine("<segmentHeight type=\"ushort\">" + this._segmentHeight.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
                sb.AppendLine("<segmentDepth type=\"ushort\">" + this._segmentDepth.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
                sb.AppendLine("<pad1 type=\"uint\">" + this._pad1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
                sb.AppendLine("</LinearSegmentParameter>");
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
            return this == obj as LinearSegmentParameter;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LinearSegmentParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._segmentNumber != obj._segmentNumber)
            {
                ivarsEqual = false;
            }

            if (!this._segmentAppearance.Equals(obj._segmentAppearance))
            {
                ivarsEqual = false;
            }

            if (!this._location.Equals(obj._location))
            {
                ivarsEqual = false;
            }

            if (!this._orientation.Equals(obj._orientation))
            {
                ivarsEqual = false;
            }

            if (this._segmentLength != obj._segmentLength)
            {
                ivarsEqual = false;
            }

            if (this._segmentWidth != obj._segmentWidth)
            {
                ivarsEqual = false;
            }

            if (this._segmentHeight != obj._segmentHeight)
            {
                ivarsEqual = false;
            }

            if (this._segmentDepth != obj._segmentDepth)
            {
                ivarsEqual = false;
            }

            if (this._pad1 != obj._pad1)
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

            result = GenerateHash(result) ^ this._segmentNumber.GetHashCode();
            result = GenerateHash(result) ^ this._segmentAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._location.GetHashCode();
            result = GenerateHash(result) ^ this._orientation.GetHashCode();
            result = GenerateHash(result) ^ this._segmentLength.GetHashCode();
            result = GenerateHash(result) ^ this._segmentWidth.GetHashCode();
            result = GenerateHash(result) ^ this._segmentHeight.GetHashCode();
            result = GenerateHash(result) ^ this._segmentDepth.GetHashCode();
            result = GenerateHash(result) ^ this._pad1.GetHashCode();

            return result;
        }
    }
}
