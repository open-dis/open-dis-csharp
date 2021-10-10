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
    /// DE Precision Aimpoint Record. Section 6.2.21.3
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(EntityID))]
    public partial class DirectedEnergyPrecisionAimpoint
    {
        /// <summary>
        /// Type of Record
        /// </summary>
        private uint _recordType = 4000;

        /// <summary>
        /// Length of Record
        /// </summary>
        private ushort _recordLength = 88;

        /// <summary>
        /// Padding
        /// </summary>
        private ushort _padding;

        /// <summary>
        /// Position of Target Spot in World Coordinates.
        /// </summary>
        private Vector3Double _targetSpotLocation = new Vector3Double();

        /// <summary>
        /// Position (meters) of Target Spot relative to Entity Position.
        /// </summary>
        private Vector3Float _targetSpotEntityLocation = new Vector3Float();

        /// <summary>
        /// Velocity (meters/sec) of Target Spot.
        /// </summary>
        private Vector3Float _targetSpotVelocity = new Vector3Float();

        /// <summary>
        /// Acceleration (meters/sec/sec) of Target Spot.
        /// </summary>
        private Vector3Float _targetSpotAcceleration = new Vector3Float();

        /// <summary>
        /// Unique ID of the target entity.
        /// </summary>
        private EntityID _targetEntityID = new EntityID();

        /// <summary>
        /// Target Component ID ENUM, same as in DamageDescriptionRecord.
        /// </summary>
        private byte _targetComponentID;

        /// <summary>
        /// Spot Shape ENUM.
        /// </summary>
        private byte _SpotShape;

        /// <summary>
        /// Beam Spot Cross Section Semi-Major Axis.
        /// </summary>
        private float _BeamSpotXSecSemiMajorAxis;

        /// <summary>
        /// Beam Spot Cross Section Semi-Major Axis.
        /// </summary>
        private float _BeamSpotCrossSectionSemiMinorAxis;

        /// <summary>
        /// Beam Spot Cross Section Orientation Angle.
        /// </summary>
        private float _BeamSpotCrossSectionOrientAngle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEnergyPrecisionAimpoint"/> class.
        /// </summary>
        public DirectedEnergyPrecisionAimpoint()
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
        public static bool operator !=(DirectedEnergyPrecisionAimpoint left, DirectedEnergyPrecisionAimpoint right)
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
        public static bool operator ==(DirectedEnergyPrecisionAimpoint left, DirectedEnergyPrecisionAimpoint right)
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

            marshalSize += 4;  // this._recordType
            marshalSize += 2;  // this._recordLength
            marshalSize += 2;  // this._padding
            marshalSize += this._targetSpotLocation.GetMarshalledSize();  // this._targetSpotLocation
            marshalSize += this._targetSpotEntityLocation.GetMarshalledSize();  // this._targetSpotEntityLocation
            marshalSize += this._targetSpotVelocity.GetMarshalledSize();  // this._targetSpotVelocity
            marshalSize += this._targetSpotAcceleration.GetMarshalledSize();  // this._targetSpotAcceleration
            marshalSize += this._targetEntityID.GetMarshalledSize();  // this._targetEntityID
            marshalSize += 1;  // this._targetComponentID
            marshalSize += 1;  // this._SpotShape
            marshalSize += 4;  // this._BeamSpotXSecSemiMajorAxis
            marshalSize += 4;  // this._BeamSpotCrossSectionSemiMinorAxis
            marshalSize += 4;  // this._BeamSpotCrossSectionOrientAngle
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Type of Record
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordType")]
        public uint RecordType
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
        /// Gets or sets the Length of Record
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
        public ushort RecordLength
        {
            get
            {
                return this._recordLength;
            }

            set
            {
                this._recordLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding")]
        public ushort Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        /// <summary>
        /// Gets or sets the Position of Target Spot in World Coordinates.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "targetSpotLocation")]
        public Vector3Double TargetSpotLocation
        {
            get
            {
                return this._targetSpotLocation;
            }

            set
            {
                this._targetSpotLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Position (meters) of Target Spot relative to Entity Position.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotEntityLocation")]
        public Vector3Float TargetSpotEntityLocation
        {
            get
            {
                return this._targetSpotEntityLocation;
            }

            set
            {
                this._targetSpotEntityLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Velocity (meters/sec) of Target Spot.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotVelocity")]
        public Vector3Float TargetSpotVelocity
        {
            get
            {
                return this._targetSpotVelocity;
            }

            set
            {
                this._targetSpotVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the Acceleration (meters/sec/sec) of Target Spot.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotAcceleration")]
        public Vector3Float TargetSpotAcceleration
        {
            get
            {
                return this._targetSpotAcceleration;
            }

            set
            {
                this._targetSpotAcceleration = value;
            }
        }

        /// <summary>
        /// Gets or sets the Unique ID of the target entity.
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "targetEntityID")]
        public EntityID TargetEntityID
        {
            get
            {
                return this._targetEntityID;
            }

            set
            {
                this._targetEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Target Component ID ENUM, same as in DamageDescriptionRecord.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "targetComponentID")]
        public byte TargetComponentID
        {
            get
            {
                return this._targetComponentID;
            }

            set
            {
                this._targetComponentID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Spot Shape ENUM.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "SpotShape")]
        public byte SpotShape
        {
            get
            {
                return this._SpotShape;
            }

            set
            {
                this._SpotShape = value;
            }
        }

        /// <summary>
        /// Gets or sets the Beam Spot Cross Section Semi-Major Axis.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "BeamSpotXSecSemiMajorAxis")]
        public float BeamSpotXSecSemiMajorAxis
        {
            get
            {
                return this._BeamSpotXSecSemiMajorAxis;
            }

            set
            {
                this._BeamSpotXSecSemiMajorAxis = value;
            }
        }

        /// <summary>
        /// Gets or sets the Beam Spot Cross Section Semi-Major Axis.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionSemiMinorAxis")]
        public float BeamSpotCrossSectionSemiMinorAxis
        {
            get
            {
                return this._BeamSpotCrossSectionSemiMinorAxis;
            }

            set
            {
                this._BeamSpotCrossSectionSemiMinorAxis = value;
            }
        }

        /// <summary>
        /// Gets or sets the Beam Spot Cross Section Orientation Angle.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionOrientAngle")]
        public float BeamSpotCrossSectionOrientAngle
        {
            get
            {
                return this._BeamSpotCrossSectionOrientAngle;
            }

            set
            {
                this._BeamSpotCrossSectionOrientAngle = value;
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
                    dos.WriteUnsignedInt((uint)this._recordType);
                    dos.WriteUnsignedShort((ushort)this._recordLength);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    this._targetSpotLocation.Marshal(dos);
                    this._targetSpotEntityLocation.Marshal(dos);
                    this._targetSpotVelocity.Marshal(dos);
                    this._targetSpotAcceleration.Marshal(dos);
                    this._targetEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._targetComponentID);
                    dos.WriteUnsignedByte((byte)this._SpotShape);
                    dos.WriteFloat((float)this._BeamSpotXSecSemiMajorAxis);
                    dos.WriteFloat((float)this._BeamSpotCrossSectionSemiMinorAxis);
                    dos.WriteFloat((float)this._BeamSpotCrossSectionOrientAngle);
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
                    this._recordType = dis.ReadUnsignedInt();
                    this._recordLength = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
                    this._targetSpotLocation.Unmarshal(dis);
                    this._targetSpotEntityLocation.Unmarshal(dis);
                    this._targetSpotVelocity.Unmarshal(dis);
                    this._targetSpotAcceleration.Unmarshal(dis);
                    this._targetEntityID.Unmarshal(dis);
                    this._targetComponentID = dis.ReadUnsignedByte();
                    this._SpotShape = dis.ReadUnsignedByte();
                    this._BeamSpotXSecSemiMajorAxis = dis.ReadFloat();
                    this._BeamSpotCrossSectionSemiMinorAxis = dis.ReadFloat();
                    this._BeamSpotCrossSectionOrientAngle = dis.ReadFloat();
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
            sb.AppendLine("<DirectedEnergyPrecisionAimpoint>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<targetSpotLocation>");
                this._targetSpotLocation.Reflection(sb);
                sb.AppendLine("</targetSpotLocation>");
                sb.AppendLine("<targetSpotEntityLocation>");
                this._targetSpotEntityLocation.Reflection(sb);
                sb.AppendLine("</targetSpotEntityLocation>");
                sb.AppendLine("<targetSpotVelocity>");
                this._targetSpotVelocity.Reflection(sb);
                sb.AppendLine("</targetSpotVelocity>");
                sb.AppendLine("<targetSpotAcceleration>");
                this._targetSpotAcceleration.Reflection(sb);
                sb.AppendLine("</targetSpotAcceleration>");
                sb.AppendLine("<targetEntityID>");
                this._targetEntityID.Reflection(sb);
                sb.AppendLine("</targetEntityID>");
                sb.AppendLine("<targetComponentID type=\"byte\">" + this._targetComponentID.ToString(CultureInfo.InvariantCulture) + "</targetComponentID>");
                sb.AppendLine("<SpotShape type=\"byte\">" + this._SpotShape.ToString(CultureInfo.InvariantCulture) + "</SpotShape>");
                sb.AppendLine("<BeamSpotXSecSemiMajorAxis type=\"float\">" + this._BeamSpotXSecSemiMajorAxis.ToString(CultureInfo.InvariantCulture) + "</BeamSpotXSecSemiMajorAxis>");
                sb.AppendLine("<BeamSpotCrossSectionSemiMinorAxis type=\"float\">" + this._BeamSpotCrossSectionSemiMinorAxis.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionSemiMinorAxis>");
                sb.AppendLine("<BeamSpotCrossSectionOrientAngle type=\"float\">" + this._BeamSpotCrossSectionOrientAngle.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionOrientAngle>");
                sb.AppendLine("</DirectedEnergyPrecisionAimpoint>");
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
            return this == obj as DirectedEnergyPrecisionAimpoint;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DirectedEnergyPrecisionAimpoint obj)
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

            if (this._recordLength != obj._recordLength)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (!this._targetSpotLocation.Equals(obj._targetSpotLocation))
            {
                ivarsEqual = false;
            }

            if (!this._targetSpotEntityLocation.Equals(obj._targetSpotEntityLocation))
            {
                ivarsEqual = false;
            }

            if (!this._targetSpotVelocity.Equals(obj._targetSpotVelocity))
            {
                ivarsEqual = false;
            }

            if (!this._targetSpotAcceleration.Equals(obj._targetSpotAcceleration))
            {
                ivarsEqual = false;
            }

            if (!this._targetEntityID.Equals(obj._targetEntityID))
            {
                ivarsEqual = false;
            }

            if (this._targetComponentID != obj._targetComponentID)
            {
                ivarsEqual = false;
            }

            if (this._SpotShape != obj._SpotShape)
            {
                ivarsEqual = false;
            }

            if (this._BeamSpotXSecSemiMajorAxis != obj._BeamSpotXSecSemiMajorAxis)
            {
                ivarsEqual = false;
            }

            if (this._BeamSpotCrossSectionSemiMinorAxis != obj._BeamSpotCrossSectionSemiMinorAxis)
            {
                ivarsEqual = false;
            }

            if (this._BeamSpotCrossSectionOrientAngle != obj._BeamSpotCrossSectionOrientAngle)
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
            result = GenerateHash(result) ^ this._recordLength.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._targetSpotLocation.GetHashCode();
            result = GenerateHash(result) ^ this._targetSpotEntityLocation.GetHashCode();
            result = GenerateHash(result) ^ this._targetSpotVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._targetSpotAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._targetEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._targetComponentID.GetHashCode();
            result = GenerateHash(result) ^ this._SpotShape.GetHashCode();
            result = GenerateHash(result) ^ this._BeamSpotXSecSemiMajorAxis.GetHashCode();
            result = GenerateHash(result) ^ this._BeamSpotCrossSectionSemiMinorAxis.GetHashCode();
            result = GenerateHash(result) ^ this._BeamSpotCrossSectionOrientAngle.GetHashCode();

            return result;
        }
    }
}
