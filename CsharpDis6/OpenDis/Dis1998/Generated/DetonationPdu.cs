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
    /// Section 5.3.4.2. Information about stuff exploding. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(BurstDescriptor))]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class DetonationPdu : WarfareFamilyPdu, IEquatable<DetonationPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetonationPdu"/> class.
        /// </summary>
        public DetonationPdu()
        {
            PduType = 3;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DetonationPdu left, DetonationPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(DetonationPdu left, DetonationPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MunitionID.GetMarshalledSize();  // this._munitionID
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += Velocity.GetMarshalledSize();  // this._velocity
            marshalSize += LocationInWorldCoordinates.GetMarshalledSize();  // this._locationInWorldCoordinates
            marshalSize += BurstDescriptor.GetMarshalledSize();  // this._burstDescriptor
            marshalSize += LocationInEntityCoordinates.GetMarshalledSize();  // this._locationInEntityCoordinates
            marshalSize += 1;  // this._detonationResult
            marshalSize += 1;  // this._numberOfArticulationParameters
            marshalSize += 2;  // this._pad
            for (int idx = 0; idx < ArticulationParameters.Count; idx++)
            {
                var listElement = ArticulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of muntion that was fired
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "munitionID")]
        public EntityID MunitionID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID firing event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the ID firing event
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity { get; set; } = new();

        /// <summary>
        /// Gets or sets the where the detonation is, in world coordinates
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
        public Vector3Double LocationInWorldCoordinates { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the Describes munition used
        /// </summary>
        [XmlElement(Type = typeof(BurstDescriptor), ElementName = "burstDescriptor")]
        public BurstDescriptor BurstDescriptor { get; set; } = new BurstDescriptor();

        /// <summary>
        /// Gets or sets the location of the detonation or impact in the target entity's coordinate system. This information
        /// should be used for damage assessment.
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "locationInEntityCoordinates")]
        public Vector3Float LocationInEntityCoordinates { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the result of the explosion
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "detonationResult")]
        public byte DetonationResult { get; set; }

        /// <summary>
        /// Gets or sets the How many articulation parameters we have
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "pad")]
        public short Pad { get; set; }

        /// <summary>
        /// Gets the articulationParameters
        /// </summary>
        [XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters { get; } = new();

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
                    MunitionID.Marshal(dos);
                    EventID.Marshal(dos);
                    Velocity.Marshal(dos);
                    LocationInWorldCoordinates.Marshal(dos);
                    BurstDescriptor.Marshal(dos);
                    LocationInEntityCoordinates.Marshal(dos);
                    dos.WriteUnsignedByte(DetonationResult);
                    dos.WriteUnsignedByte((byte)ArticulationParameters.Count);
                    dos.WriteShort(Pad);

                    for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                    {
                        var aArticulationParameter = ArticulationParameters[idx];
                        aArticulationParameter.Marshal(dos);
                    }
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
                    MunitionID.Unmarshal(dis);
                    EventID.Unmarshal(dis);
                    Velocity.Unmarshal(dis);
                    LocationInWorldCoordinates.Unmarshal(dis);
                    BurstDescriptor.Unmarshal(dis);
                    LocationInEntityCoordinates.Unmarshal(dis);
                    DetonationResult = dis.ReadUnsignedByte();
                    NumberOfArticulationParameters = dis.ReadUnsignedByte();
                    Pad = dis.ReadShort();

                    for (int idx = 0; idx < NumberOfArticulationParameters; idx++)
                    {
                        var anX = new ArticulationParameter();
                        anX.Unmarshal(dis);
                        ArticulationParameters.Add(anX);
                    }
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
            sb.AppendLine("<DetonationPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<munitionID>");
                MunitionID.Reflection(sb);
                sb.AppendLine("</munitionID>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<velocity>");
                Velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<locationInWorldCoordinates>");
                LocationInWorldCoordinates.Reflection(sb);
                sb.AppendLine("</locationInWorldCoordinates>");
                sb.AppendLine("<burstDescriptor>");
                BurstDescriptor.Reflection(sb);
                sb.AppendLine("</burstDescriptor>");
                sb.AppendLine("<locationInEntityCoordinates>");
                LocationInEntityCoordinates.Reflection(sb);
                sb.AppendLine("</locationInEntityCoordinates>");
                sb.AppendLine("<detonationResult type=\"byte\">" + DetonationResult.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + ArticulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<pad type=\"short\">" + Pad.ToString(CultureInfo.InvariantCulture) + "</pad>");
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    var aArticulationParameter = ArticulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DetonationPdu>");
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
        public override bool Equals(object obj) => this == obj as DetonationPdu;

        ///<inheritdoc/>
        public bool Equals(DetonationPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!MunitionID.Equals(obj.MunitionID))
            {
                ivarsEqual = false;
            }

            if (!EventID.Equals(obj.EventID))
            {
                ivarsEqual = false;
            }

            if (!Velocity.Equals(obj.Velocity))
            {
                ivarsEqual = false;
            }

            if (!LocationInWorldCoordinates.Equals(obj.LocationInWorldCoordinates))
            {
                ivarsEqual = false;
            }

            if (!BurstDescriptor.Equals(obj.BurstDescriptor))
            {
                ivarsEqual = false;
            }

            if (!LocationInEntityCoordinates.Equals(obj.LocationInEntityCoordinates))
            {
                ivarsEqual = false;
            }

            if (DetonationResult != obj.DetonationResult)
            {
                ivarsEqual = false;
            }

            if (NumberOfArticulationParameters != obj.NumberOfArticulationParameters)
            {
                ivarsEqual = false;
            }

            if (Pad != obj.Pad)
            {
                ivarsEqual = false;
            }

            if (ArticulationParameters.Count != obj.ArticulationParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    if (!ArticulationParameters[idx].Equals(obj.ArticulationParameters[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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

            result = GenerateHash(result) ^ MunitionID.GetHashCode();
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ Velocity.GetHashCode();
            result = GenerateHash(result) ^ LocationInWorldCoordinates.GetHashCode();
            result = GenerateHash(result) ^ BurstDescriptor.GetHashCode();
            result = GenerateHash(result) ^ LocationInEntityCoordinates.GetHashCode();
            result = GenerateHash(result) ^ DetonationResult.GetHashCode();
            result = GenerateHash(result) ^ NumberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ Pad.GetHashCode();

            if (ArticulationParameters.Count > 0)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ ArticulationParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
