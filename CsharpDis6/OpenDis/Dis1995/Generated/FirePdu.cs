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

namespace OpenDis.Dis1995
{
    /// <summary>
    /// Sectioin 5.3.4.1. Information about someone firing something
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EventID))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(BurstDescriptor))]
    [XmlInclude(typeof(Vector3Float))]
    public partial class FirePdu : Warfare, IEquatable<FirePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirePdu"/> class.
        /// </summary>
        public FirePdu()
        {
            PduType = 2;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FirePdu left, FirePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(FirePdu left, FirePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += MunitionID.GetMarshalledSize();  // this._munitionID
            marshalSize += EventID.GetMarshalledSize();  // this._eventID
            marshalSize += 4;  // this._fireMissionIndex
            marshalSize += LocationInWorldCoordinates.GetMarshalledSize();  // this._locationInWorldCoordinates
            marshalSize += BurstDescriptor.GetMarshalledSize();  // this._burstDescriptor
            marshalSize += Velocity.GetMarshalledSize();  // this._velocity
            marshalSize += 4;  // this._range
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of the munition that is being shot
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "munitionID")]
        public EntityID MunitionID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the ID of event
        /// </summary>
        [XmlElement(Type = typeof(EventID), ElementName = "eventID")]
        public EventID EventID { get; set; } = new EventID();

        /// <summary>
        /// Gets or sets the fireMissionIndex
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "fireMissionIndex")]
        public int FireMissionIndex { get; set; }

        /// <summary>
        /// Gets or sets the location of the firing event
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
        public Vector3Double LocationInWorldCoordinates { get; set; } = new Vector3Double();

        /// <summary>
        /// Gets or sets the Describes munitions used in the firing event
        /// </summary>
        [XmlElement(Type = typeof(BurstDescriptor), ElementName = "burstDescriptor")]
        public BurstDescriptor BurstDescriptor { get; set; } = new BurstDescriptor();

        /// <summary>
        /// Gets or sets the Velocity of the ammunition
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
        public Vector3Float Velocity { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the range to the target
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "range")]
        public float Range { get; set; }

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
                    dos.WriteInt(FireMissionIndex);
                    LocationInWorldCoordinates.Marshal(dos);
                    BurstDescriptor.Marshal(dos);
                    Velocity.Marshal(dos);
                    dos.WriteFloat((float)Range);
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
                    FireMissionIndex = dis.ReadInt();
                    LocationInWorldCoordinates.Unmarshal(dis);
                    BurstDescriptor.Unmarshal(dis);
                    Velocity.Unmarshal(dis);
                    Range = dis.ReadFloat();
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
            sb.AppendLine("<FirePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<munitionID>");
                MunitionID.Reflection(sb);
                sb.AppendLine("</munitionID>");
                sb.AppendLine("<eventID>");
                EventID.Reflection(sb);
                sb.AppendLine("</eventID>");
                sb.AppendLine("<fireMissionIndex type=\"int\">" + FireMissionIndex.ToString(CultureInfo.InvariantCulture) + "</fireMissionIndex>");
                sb.AppendLine("<locationInWorldCoordinates>");
                LocationInWorldCoordinates.Reflection(sb);
                sb.AppendLine("</locationInWorldCoordinates>");
                sb.AppendLine("<burstDescriptor>");
                BurstDescriptor.Reflection(sb);
                sb.AppendLine("</burstDescriptor>");
                sb.AppendLine("<velocity>");
                Velocity.Reflection(sb);
                sb.AppendLine("</velocity>");
                sb.AppendLine("<range type=\"float\">" + Range.ToString(CultureInfo.InvariantCulture) + "</range>");
                sb.AppendLine("</FirePdu>");
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
        public override bool Equals(object obj) => this == obj as FirePdu;

        ///<inheritdoc/>
        public bool Equals(FirePdu obj)
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

            if (FireMissionIndex != obj.FireMissionIndex)
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

            if (!Velocity.Equals(obj.Velocity))
            {
                ivarsEqual = false;
            }

            if (Range != obj.Range)
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

            result = GenerateHash(result) ^ MunitionID.GetHashCode();
            result = GenerateHash(result) ^ EventID.GetHashCode();
            result = GenerateHash(result) ^ FireMissionIndex.GetHashCode();
            result = GenerateHash(result) ^ LocationInWorldCoordinates.GetHashCode();
            result = GenerateHash(result) ^ BurstDescriptor.GetHashCode();
            result = GenerateHash(result) ^ Velocity.GetHashCode();
            result = GenerateHash(result) ^ Range.GetHashCode();

            return result;
        }
    }
}
