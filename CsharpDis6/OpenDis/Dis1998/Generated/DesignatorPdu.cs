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
    /// Section 5.3.7.2. Handles designating operations. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class DesignatorPdu : DistributedEmissionsFamilyPdu, IEquatable<DesignatorPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignatorPdu"/> class.
        /// </summary>
        public DesignatorPdu()
        {
            PduType = 24;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DesignatorPdu left, DesignatorPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(DesignatorPdu left, DesignatorPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += DesignatingEntityID.GetMarshalledSize();  // this._designatingEntityID
            marshalSize += 2;  // this._codeName
            marshalSize += DesignatedEntityID.GetMarshalledSize();  // this._designatedEntityID
            marshalSize += 2;  // this._designatorCode
            marshalSize += 4;  // this._designatorPower
            marshalSize += 4;  // this._designatorWavelength
            marshalSize += DesignatorSpotWrtDesignated.GetMarshalledSize();  // this._designatorSpotWrtDesignated
            marshalSize += DesignatorSpotLocation.GetMarshalledSize();  // this._designatorSpotLocation
            marshalSize += 1;  // this._deadReckoningAlgorithm
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            marshalSize += EntityLinearAcceleration.GetMarshalledSize();  // this._entityLinearAcceleration
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the entity designating
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "designatingEntityID")]
        public EntityID DesignatingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the This field shall specify a unique emitter database number assigned to differentiate between otherwise
        /// similar or identical emitter beams within an emitter system.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "codeName")]
        public ushort CodeName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the entity being designated
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "designatedEntityID")]
        public EntityID DesignatedEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the This field shall identify the designator code being used by the designating entity
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "designatorCode")]
        public ushort DesignatorCode { get; set; }

        /// <summary>
        /// Gets or sets the This field shall identify the designator output power in watts
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "designatorPower")]
        public float DesignatorPower { get; set; }

        /// <summary>
        /// Gets or sets the This field shall identify the designator wavelength in units of microns
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "designatorWavelength")]
        public float DesignatorWavelength { get; set; }

        /// <summary>
        /// Gets or sets the designtor spot wrt the designated entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "designatorSpotWrtDesignated")]
        public Vector3Float DesignatorSpotWrtDesignated { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the designtor spot wrt the designated entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "designatorSpotLocation")]
        public Vector3Double DesignatorSpotLocation { get; set; } = new();

        /// <summary>
        /// Gets or sets the Dead reckoning algorithm
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding1")]
        public ushort Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2 { get; set; }

        /// <summary>
        /// Gets or sets the linear accelleration of entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
        public Vector3Float EntityLinearAcceleration { get; set; } = new Vector3Float();

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    DesignatingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(CodeName);
                    DesignatedEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(DesignatorCode);
                    dos.WriteFloat((float)DesignatorPower);
                    dos.WriteFloat(DesignatorWavelength);
                    DesignatorSpotWrtDesignated.Marshal(dos);
                    DesignatorSpotLocation.Marshal(dos);
                    dos.WriteByte(DeadReckoningAlgorithm);
                    dos.WriteUnsignedShort(Padding1);
                    dos.WriteByte(Padding2);
                    EntityLinearAcceleration.Marshal(dos);
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    DesignatingEntityID.Unmarshal(dis);
                    CodeName = dis.ReadUnsignedShort();
                    DesignatedEntityID.Unmarshal(dis);
                    DesignatorCode = dis.ReadUnsignedShort();
                    DesignatorPower = dis.ReadFloat();
                    DesignatorWavelength = dis.ReadFloat();
                    DesignatorSpotWrtDesignated.Unmarshal(dis);
                    DesignatorSpotLocation.Unmarshal(dis);
                    DeadReckoningAlgorithm = dis.ReadByte();
                    Padding1 = dis.ReadUnsignedShort();
                    Padding2 = dis.ReadByte();
                    EntityLinearAcceleration.Unmarshal(dis);
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<DesignatorPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<designatingEntityID>");
                DesignatingEntityID.Reflection(sb);
                sb.AppendLine("</designatingEntityID>");
                sb.AppendLine("<codeName type=\"ushort\">" + CodeName.ToString(CultureInfo.InvariantCulture) + "</codeName>");
                sb.AppendLine("<designatedEntityID>");
                DesignatedEntityID.Reflection(sb);
                sb.AppendLine("</designatedEntityID>");
                sb.AppendLine("<designatorCode type=\"ushort\">" + DesignatorCode.ToString(CultureInfo.InvariantCulture) + "</designatorCode>");
                sb.AppendLine("<designatorPower type=\"float\">" + DesignatorPower.ToString(CultureInfo.InvariantCulture) + "</designatorPower>");
                sb.AppendLine("<designatorWavelength type=\"float\">" + DesignatorWavelength.ToString(CultureInfo.InvariantCulture) + "</designatorWavelength>");
                sb.AppendLine("<designatorSpotWrtDesignated>");
                DesignatorSpotWrtDesignated.Reflection(sb);
                sb.AppendLine("</designatorSpotWrtDesignated>");
                sb.AppendLine("<designatorSpotLocation>");
                DesignatorSpotLocation.Reflection(sb);
                sb.AppendLine("</designatorSpotLocation>");
                sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + DeadReckoningAlgorithm.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
                sb.AppendLine("<padding1 type=\"ushort\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<entityLinearAcceleration>");
                EntityLinearAcceleration.Reflection(sb);
                sb.AppendLine("</entityLinearAcceleration>");
                sb.AppendLine("</DesignatorPdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as DesignatorPdu;

        ///<inheritdoc/>
        public bool Equals(DesignatorPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!DesignatingEntityID.Equals(obj.DesignatingEntityID))
            {
                ivarsEqual = false;
            }

            if (CodeName != obj.CodeName)
            {
                ivarsEqual = false;
            }

            if (!DesignatedEntityID.Equals(obj.DesignatedEntityID))
            {
                ivarsEqual = false;
            }

            if (DesignatorCode != obj.DesignatorCode)
            {
                ivarsEqual = false;
            }

            if (DesignatorPower != obj.DesignatorPower)
            {
                ivarsEqual = false;
            }

            if (DesignatorWavelength != obj.DesignatorWavelength)
            {
                ivarsEqual = false;
            }

            if (!DesignatorSpotWrtDesignated.Equals(obj.DesignatorSpotWrtDesignated))
            {
                ivarsEqual = false;
            }

            if (!DesignatorSpotLocation.Equals(obj.DesignatorSpotLocation))
            {
                ivarsEqual = false;
            }

            if (DeadReckoningAlgorithm != obj.DeadReckoningAlgorithm)
            {
                ivarsEqual = false;
            }

            if (Padding1 != obj.Padding1)
            {
                ivarsEqual = false;
            }

            if (Padding2 != obj.Padding2)
            {
                ivarsEqual = false;
            }

            if (!EntityLinearAcceleration.Equals(obj.EntityLinearAcceleration))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ DesignatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ CodeName.GetHashCode();
            result = GenerateHash(result) ^ DesignatedEntityID.GetHashCode();
            result = GenerateHash(result) ^ DesignatorCode.GetHashCode();
            result = GenerateHash(result) ^ DesignatorPower.GetHashCode();
            result = GenerateHash(result) ^ DesignatorWavelength.GetHashCode();
            result = GenerateHash(result) ^ DesignatorSpotWrtDesignated.GetHashCode();
            result = GenerateHash(result) ^ DesignatorSpotLocation.GetHashCode();
            result = GenerateHash(result) ^ DeadReckoningAlgorithm.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();
            result = GenerateHash(result) ^ EntityLinearAcceleration.GetHashCode();

            return result;
        }
    }
}
