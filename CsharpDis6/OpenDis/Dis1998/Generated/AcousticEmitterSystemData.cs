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
    /// Used in the UA pdu; ties together an emmitter and a location. This requires manual cleanup; the beam data should
    /// not be attached to each emitter system.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(AcousticEmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(AcousticBeamData))]
    public partial class AcousticEmitterSystemData : IEquatable<AcousticEmitterSystemData>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcousticEmitterSystemData"/> class.
        /// </summary>
        public AcousticEmitterSystemData()
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
        public static bool operator !=(AcousticEmitterSystemData left, AcousticEmitterSystemData right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AcousticEmitterSystemData left, AcousticEmitterSystemData right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1;  // this._emitterSystemDataLength
            marshalSize += 1;  // this._numberOfBeams
            marshalSize += 2;  // this._pad2
            marshalSize += AcousticEmitterSystem.GetMarshalledSize();  // this._acousticEmitterSystem
            marshalSize += EmitterLocation.GetMarshalledSize();  // this._emitterLocation
            for (int idx = 0; idx < BeamRecords.Count; idx++)
            {
                var listElement = BeamRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Length of emitter system data
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "emitterSystemDataLength")]
        public byte EmitterSystemDataLength { get; set; }

        /// <summary>
        /// Gets or sets the Number of beams
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfBeams method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
        public byte NumberOfBeams { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad2")]
        public ushort Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the system for a particular UA emitter.
        /// </summary>
        [XmlElement(Type = typeof(AcousticEmitterSystem), ElementName = "acousticEmitterSystem")]
        public AcousticEmitterSystem AcousticEmitterSystem { get; set; } = new AcousticEmitterSystem();

        /// <summary>
        /// Gets or sets the Represents the location wrt the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "emitterLocation")]
        public Vector3Float EmitterLocation { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets the For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the
        /// end of the PDU, rather than attached to each system.
        /// </summary>
        [XmlElement(ElementName = "beamRecordsList", Type = typeof(List<AcousticBeamData>))]
        public List<AcousticBeamData> BeamRecords { get; } = new();

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
                    dos.WriteUnsignedByte(EmitterSystemDataLength);
                    dos.WriteUnsignedByte((byte)BeamRecords.Count);
                    dos.WriteUnsignedShort(Pad2);
                    AcousticEmitterSystem.Marshal(dos);
                    EmitterLocation.Marshal(dos);

                    for (int idx = 0; idx < BeamRecords.Count; idx++)
                    {
                        var aAcousticBeamData = BeamRecords[idx];
                        aAcousticBeamData.Marshal(dos);
                    }
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
                    EmitterSystemDataLength = dis.ReadUnsignedByte();
                    NumberOfBeams = dis.ReadUnsignedByte();
                    Pad2 = dis.ReadUnsignedShort();
                    AcousticEmitterSystem.Unmarshal(dis);
                    EmitterLocation.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfBeams; idx++)
                    {
                        var anX = new AcousticBeamData();
                        anX.Unmarshal(dis);
                        BeamRecords.Add(anX);
                    }
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
            sb.AppendLine("<AcousticEmitterSystemData>");
            try
            {
                sb.AppendLine("<emitterSystemDataLength type=\"byte\">" + EmitterSystemDataLength.ToString(CultureInfo.InvariantCulture) + "</emitterSystemDataLength>");
                sb.AppendLine("<beamRecords type=\"byte\">" + BeamRecords.Count.ToString(CultureInfo.InvariantCulture) + "</beamRecords>");
                sb.AppendLine("<pad2 type=\"ushort\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<acousticEmitterSystem>");
                AcousticEmitterSystem.Reflection(sb);
                sb.AppendLine("</acousticEmitterSystem>");
                sb.AppendLine("<emitterLocation>");
                EmitterLocation.Reflection(sb);
                sb.AppendLine("</emitterLocation>");
                for (int idx = 0; idx < BeamRecords.Count; idx++)
                {
                    sb.AppendLine("<beamRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticBeamData\">");
                    var aAcousticBeamData = BeamRecords[idx];
                    aAcousticBeamData.Reflection(sb);
                    sb.AppendLine("</beamRecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</AcousticEmitterSystemData>");
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
        public override bool Equals(object obj) => this == obj as AcousticEmitterSystemData;

        ///<inheritdoc/>
        public bool Equals(AcousticEmitterSystemData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (EmitterSystemDataLength != obj.EmitterSystemDataLength)
            {
                ivarsEqual = false;
            }

            if (NumberOfBeams != obj.NumberOfBeams)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (!AcousticEmitterSystem.Equals(obj.AcousticEmitterSystem))
            {
                ivarsEqual = false;
            }

            if (!EmitterLocation.Equals(obj.EmitterLocation))
            {
                ivarsEqual = false;
            }

            if (BeamRecords.Count != obj.BeamRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < BeamRecords.Count; idx++)
                {
                    if (!BeamRecords[idx].Equals(obj.BeamRecords[idx]))
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

            result = GenerateHash(result) ^ EmitterSystemDataLength.GetHashCode();
            result = GenerateHash(result) ^ NumberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ AcousticEmitterSystem.GetHashCode();
            result = GenerateHash(result) ^ EmitterLocation.GetHashCode();

            if (BeamRecords.Count > 0)
            {
                for (int idx = 0; idx < BeamRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ BeamRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
