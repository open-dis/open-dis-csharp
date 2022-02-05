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
    /// Section 5.3.11.1: Information about environmental effects and processes. This requires manual cleanup. the environmental
    ///       record is variable, as is the padding. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Environment))]
    public partial class EnvironmentalProcessPdu : SyntheticEnvironmentFamilyPdu, IEquatable<EnvironmentalProcessPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentalProcessPdu"/> class.
        /// </summary>
        public EnvironmentalProcessPdu()
        {
            PduType = 41;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += EnvironementalProcessID.GetMarshalledSize();  // this._environementalProcessID
            marshalSize += EnvironmentType.GetMarshalledSize();  // this._environmentType
            marshalSize += 1;  // this._modelType
            marshalSize += 1;  // this._environmentStatus
            marshalSize += 1;  // this._numberOfEnvironmentRecords
            marshalSize += 2;  // this._sequenceNumber
            for (int idx = 0; idx < EnvironmentRecords.Count; idx++)
            {
                var listElement = EnvironmentRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Environmental process ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "environementalProcessID")]
        public EntityID EnvironementalProcessID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Environment type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
        public EntityType EnvironmentType { get; set; } = new EntityType();

        /// <summary>
        /// Gets or sets the model type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modelType")]
        public byte ModelType { get; set; }

        /// <summary>
        /// Gets or sets the Environment status
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "environmentStatus")]
        public byte EnvironmentStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of environment records
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfEnvironmentRecords method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfEnvironmentRecords")]
        public byte NumberOfEnvironmentRecords { get; set; }

        /// <summary>
        /// Gets or sets the PDU sequence number for the environmentla process if pdu sequencing required
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "sequenceNumber")]
        public ushort SequenceNumber { get; set; }

        /// <summary>
        /// Gets the environemt records
        /// </summary>
        [XmlElement(ElementName = "environmentRecordsList", Type = typeof(List<Environment>))]
        public List<Environment> EnvironmentRecords { get; } = new();

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
                    EnvironementalProcessID.Marshal(dos);
                    EnvironmentType.Marshal(dos);
                    dos.WriteUnsignedByte(ModelType);
                    dos.WriteUnsignedByte(EnvironmentStatus);
                    dos.WriteUnsignedByte((byte)EnvironmentRecords.Count);
                    dos.WriteUnsignedShort(SequenceNumber);

                    for (int idx = 0; idx < EnvironmentRecords.Count; idx++)
                    {
                        var aEnvironment = EnvironmentRecords[idx];
                        aEnvironment.Marshal(dos);
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
                    EnvironementalProcessID.Unmarshal(dis);
                    EnvironmentType.Unmarshal(dis);
                    ModelType = dis.ReadUnsignedByte();
                    EnvironmentStatus = dis.ReadUnsignedByte();
                    NumberOfEnvironmentRecords = dis.ReadUnsignedByte();
                    SequenceNumber = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < NumberOfEnvironmentRecords; idx++)
                    {
                        var anX = new Environment();
                        anX.Unmarshal(dis);
                        EnvironmentRecords.Add(anX);
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
            sb.AppendLine("<EnvironmentalProcessPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<environementalProcessID>");
                EnvironementalProcessID.Reflection(sb);
                sb.AppendLine("</environementalProcessID>");
                sb.AppendLine("<environmentType>");
                EnvironmentType.Reflection(sb);
                sb.AppendLine("</environmentType>");
                sb.AppendLine("<modelType type=\"byte\">" + ModelType.ToString(CultureInfo.InvariantCulture) + "</modelType>");
                sb.AppendLine("<environmentStatus type=\"byte\">" + EnvironmentStatus.ToString(CultureInfo.InvariantCulture) + "</environmentStatus>");
                sb.AppendLine("<environmentRecords type=\"byte\">" + EnvironmentRecords.Count.ToString(CultureInfo.InvariantCulture) + "</environmentRecords>");
                sb.AppendLine("<sequenceNumber type=\"ushort\">" + SequenceNumber.ToString(CultureInfo.InvariantCulture) + "</sequenceNumber>");
                for (int idx = 0; idx < EnvironmentRecords.Count; idx++)
                {
                    sb.AppendLine("<environmentRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Environment\">");
                    var aEnvironment = EnvironmentRecords[idx];
                    aEnvironment.Reflection(sb);
                    sb.AppendLine("</environmentRecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</EnvironmentalProcessPdu>");
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
        public override bool Equals(object obj) => this == obj as EnvironmentalProcessPdu;

        ///<inheritdoc/>
        public bool Equals(EnvironmentalProcessPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!EnvironementalProcessID.Equals(obj.EnvironementalProcessID))
            {
                ivarsEqual = false;
            }

            if (!EnvironmentType.Equals(obj.EnvironmentType))
            {
                ivarsEqual = false;
            }

            if (ModelType != obj.ModelType)
            {
                ivarsEqual = false;
            }

            if (EnvironmentStatus != obj.EnvironmentStatus)
            {
                ivarsEqual = false;
            }

            if (NumberOfEnvironmentRecords != obj.NumberOfEnvironmentRecords)
            {
                ivarsEqual = false;
            }

            if (SequenceNumber != obj.SequenceNumber)
            {
                ivarsEqual = false;
            }

            if (EnvironmentRecords.Count != obj.EnvironmentRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < EnvironmentRecords.Count; idx++)
                {
                    if (!EnvironmentRecords[idx].Equals(obj.EnvironmentRecords[idx]))
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

            result = GenerateHash(result) ^ EnvironementalProcessID.GetHashCode();
            result = GenerateHash(result) ^ EnvironmentType.GetHashCode();
            result = GenerateHash(result) ^ ModelType.GetHashCode();
            result = GenerateHash(result) ^ EnvironmentStatus.GetHashCode();
            result = GenerateHash(result) ^ NumberOfEnvironmentRecords.GetHashCode();
            result = GenerateHash(result) ^ SequenceNumber.GetHashCode();

            if (EnvironmentRecords.Count > 0)
            {
                for (int idx = 0; idx < EnvironmentRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ EnvironmentRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
