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
    /// The specification of an individual segment of a linear segment synthetic environment object in a Linear Object State PDU Section 6.2.53
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(EulerAngles))]
    public partial class LinearSegmentParameter
    {
        /// <summary>
        /// the individual segment of the linear segment 
        /// </summary>
        private byte _segmentNumber;

        /// <summary>
        ///  whether a modification has been made to the point object’s location or orientation
        /// </summary>
        private byte _segmentModification;

        /// <summary>
        /// general dynamic appearance attributes of the segment. This record shall be defined as a 16-bit record of enumerations. The values defined for this record are included in Section 12 of SISO-REF-010.
        /// </summary>
        private ushort _generalSegmentAppearance;

        /// <summary>
        /// This field shall specify specific dynamic appearance attributes of the segment. This record shall be defined as a 32-bit record of enumerations.
        /// </summary>
        private ushort _specificSegmentAppearance;

        /// <summary>
        /// This field shall specify the location of the linear segment in the simulated world and shall be represented by a World Coordinates record 
        /// </summary>
        private Vector3Double _segmentLocation = new Vector3Double();

        /// <summary>
        /// orientation of the linear segment about the segment location and shall be represented by a Euler Angles record 
        /// </summary>
        private EulerAngles _segmentOrientation = new EulerAngles();

        /// <summary>
        /// length of the linear segment, in meters, extending in the positive X direction
        /// </summary>
        private ushort _segmentLength;

        /// <summary>
        /// The total width of the linear segment, in meters, shall be specified by a 16-bit unsigned integer. One-half of the width shall extend in the positive Y direction, and one-half of the width shall extend in the negative Y direction.
        /// </summary>
        private ushort _segmentWidth;

        /// <summary>
        /// The height of the linear segment, in meters, above ground shall be specified by a 16-bit unsigned integer.
        /// </summary>
        private ushort _segmentHeight;

        /// <summary>
        /// The depth of the linear segment, in meters, below ground level 
        /// </summary>
        private ushort _segmentDepth;

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
            marshalSize += 1;  // this._segmentModification
            marshalSize += 2;  // this._generalSegmentAppearance
            marshalSize += 2;  // this._specificSegmentAppearance
            marshalSize += this._segmentLocation.GetMarshalledSize();  // this._segmentLocation
            marshalSize += this._segmentOrientation.GetMarshalledSize();  // this._segmentOrientation
            marshalSize += 2;  // this._segmentLength
            marshalSize += 2;  // this._segmentWidth
            marshalSize += 2;  // this._segmentHeight
            marshalSize += 2;  // this._segmentDepth
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the the individual segment of the linear segment 
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
        /// Gets or sets the  whether a modification has been made to the point object’s location or orientation
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "segmentModification")]
        public byte SegmentModification
        {
            get
            {
                return this._segmentModification;
            }

            set
            {
                this._segmentModification = value;
            }
        }

        /// <summary>
        /// Gets or sets the general dynamic appearance attributes of the segment. This record shall be defined as a 16-bit record of enumerations. The values defined for this record are included in Section 12 of SISO-REF-010.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "generalSegmentAppearance")]
        public ushort GeneralSegmentAppearance
        {
            get
            {
                return this._generalSegmentAppearance;
            }

            set
            {
                this._generalSegmentAppearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify specific dynamic appearance attributes of the segment. This record shall be defined as a 32-bit record of enumerations.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "specificSegmentAppearance")]
        public ushort SpecificSegmentAppearance
        {
            get
            {
                return this._specificSegmentAppearance;
            }

            set
            {
                this._specificSegmentAppearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the location of the linear segment in the simulated world and shall be represented by a World Coordinates record 
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "segmentLocation")]
        public Vector3Double SegmentLocation
        {
            get
            {
                return this._segmentLocation;
            }

            set
            {
                this._segmentLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the linear segment about the segment location and shall be represented by a Euler Angles record 
        /// </summary>
        [XmlElement(Type = typeof(EulerAngles), ElementName = "segmentOrientation")]
        public EulerAngles SegmentOrientation
        {
            get
            {
                return this._segmentOrientation;
            }

            set
            {
                this._segmentOrientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of the linear segment, in meters, extending in the positive X direction
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
        /// Gets or sets the The total width of the linear segment, in meters, shall be specified by a 16-bit unsigned integer. One-half of the width shall extend in the positive Y direction, and one-half of the width shall extend in the negative Y direction.
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
        /// Gets or sets the The height of the linear segment, in meters, above ground shall be specified by a 16-bit unsigned integer.
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
        /// Gets or sets the The depth of the linear segment, in meters, below ground level 
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
                    dos.WriteUnsignedByte((byte)this._segmentNumber);
                    dos.WriteUnsignedByte((byte)this._segmentModification);
                    dos.WriteUnsignedShort((ushort)this._generalSegmentAppearance);
                    dos.WriteUnsignedShort((ushort)this._specificSegmentAppearance);
                    this._segmentLocation.Marshal(dos);
                    this._segmentOrientation.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._segmentLength);
                    dos.WriteUnsignedShort((ushort)this._segmentWidth);
                    dos.WriteUnsignedShort((ushort)this._segmentHeight);
                    dos.WriteUnsignedShort((ushort)this._segmentDepth);
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
                    this._segmentNumber = dis.ReadUnsignedByte();
                    this._segmentModification = dis.ReadUnsignedByte();
                    this._generalSegmentAppearance = dis.ReadUnsignedShort();
                    this._specificSegmentAppearance = dis.ReadUnsignedShort();
                    this._segmentLocation.Unmarshal(dis);
                    this._segmentOrientation.Unmarshal(dis);
                    this._segmentLength = dis.ReadUnsignedShort();
                    this._segmentWidth = dis.ReadUnsignedShort();
                    this._segmentHeight = dis.ReadUnsignedShort();
                    this._segmentDepth = dis.ReadUnsignedShort();
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
            sb.AppendLine("<LinearSegmentParameter>");
            try
            {
                sb.AppendLine("<segmentNumber type=\"byte\">" + this._segmentNumber.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
                sb.AppendLine("<segmentModification type=\"byte\">" + this._segmentModification.ToString(CultureInfo.InvariantCulture) + "</segmentModification>");
                sb.AppendLine("<generalSegmentAppearance type=\"ushort\">" + this._generalSegmentAppearance.ToString(CultureInfo.InvariantCulture) + "</generalSegmentAppearance>");
                sb.AppendLine("<specificSegmentAppearance type=\"ushort\">" + this._specificSegmentAppearance.ToString(CultureInfo.InvariantCulture) + "</specificSegmentAppearance>");
                sb.AppendLine("<segmentLocation>");
                this._segmentLocation.Reflection(sb);
                sb.AppendLine("</segmentLocation>");
                sb.AppendLine("<segmentOrientation>");
                this._segmentOrientation.Reflection(sb);
                sb.AppendLine("</segmentOrientation>");
                sb.AppendLine("<segmentLength type=\"ushort\">" + this._segmentLength.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
                sb.AppendLine("<segmentWidth type=\"ushort\">" + this._segmentWidth.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
                sb.AppendLine("<segmentHeight type=\"ushort\">" + this._segmentHeight.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
                sb.AppendLine("<segmentDepth type=\"ushort\">" + this._segmentDepth.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
                sb.AppendLine("</LinearSegmentParameter>");
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

            if (this._segmentModification != obj._segmentModification)
            {
                ivarsEqual = false;
            }

            if (this._generalSegmentAppearance != obj._generalSegmentAppearance)
            {
                ivarsEqual = false;
            }

            if (this._specificSegmentAppearance != obj._specificSegmentAppearance)
            {
                ivarsEqual = false;
            }

            if (!this._segmentLocation.Equals(obj._segmentLocation))
            {
                ivarsEqual = false;
            }

            if (!this._segmentOrientation.Equals(obj._segmentOrientation))
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
            result = GenerateHash(result) ^ this._segmentModification.GetHashCode();
            result = GenerateHash(result) ^ this._generalSegmentAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._specificSegmentAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._segmentLocation.GetHashCode();
            result = GenerateHash(result) ^ this._segmentOrientation.GetHashCode();
            result = GenerateHash(result) ^ this._segmentLength.GetHashCode();
            result = GenerateHash(result) ^ this._segmentWidth.GetHashCode();
            result = GenerateHash(result) ^ this._segmentHeight.GetHashCode();
            result = GenerateHash(result) ^ this._segmentDepth.GetHashCode();

            return result;
        }
    }
}
