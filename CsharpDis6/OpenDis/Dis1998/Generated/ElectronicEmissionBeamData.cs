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
    /// Description of one electronic emission beam
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FundamentalParameterData))]
    [XmlInclude(typeof(TrackJamTarget))]
    public partial class ElectronicEmissionBeamData : IEquatable<ElectronicEmissionBeamData>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicEmissionBeamData"/> class.
        /// </summary>
        public ElectronicEmissionBeamData()
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
        public static bool operator !=(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1;  // this._beamDataLength
            marshalSize += 1;  // this._beamIDNumber
            marshalSize += 2;  // this._beamParameterIndex
            marshalSize += FundamentalParameterData.GetMarshalledSize();  // this._fundamentalParameterData
            marshalSize += 1;  // this._beamFunction
            marshalSize += 1;  // this._numberOfTrackJamTargets
            marshalSize += 1;  // this._highDensityTrackJam
            marshalSize += 1;  // this._pad4
            marshalSize += 4;  // this._jammingModeSequence
            for (int idx = 0; idx < TrackJamTargets.Count; idx++)
            {
                var listElement = TrackJamTargets[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall specify the length of this beams data in 32 bit words
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
        public byte BeamDataLength { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify a unique emitter database number assigned to differentiate between otherwise
        /// similar or identical emitter beams within an emitter system.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
        public byte BeamIDNumber { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify a Beam Parameter Index number that shall be used by receiving entities
        /// in conjunction with the Emitter Name field to provide a pointer to the stored database parameters required to regenerate the beam.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
        public ushort BeamParameterIndex { get; set; }

        /// <summary>
        /// Gets or sets the Fundamental parameter data such as frequency range, beam sweep, etc.
        /// </summary>
        [XmlElement(Type = typeof(FundamentalParameterData), ElementName = "fundamentalParameterData")]
        public FundamentalParameterData FundamentalParameterData { get; set; } = new FundamentalParameterData();

        /// <summary>
        /// Gets or sets the beam function of a particular beam
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamFunction")]
        public byte BeamFunction { get; set; }

        /// <summary>
        /// Gets or sets the Number of track/jam targets
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfTrackJamTargets method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfTrackJamTargets")]
        public byte NumberOfTrackJamTargets { get; set; }

        /// <summary>
        /// Gets or sets the wheher or not the receiving simulation apps can assume all the targets in the scan pattern are
        /// being tracked/jammed
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "highDensityTrackJam")]
        public byte HighDensityTrackJam { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad4")]
        public byte Pad4 { get; set; }

        /// <summary>
        /// Gets or sets the identify jamming techniques used
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "jammingModeSequence")]
        public uint JammingModeSequence { get; set; }

        /// <summary>
        /// Gets the variable length list of track/jam targets
        /// </summary>
        [XmlElement(ElementName = "trackJamTargetsList", Type = typeof(List<TrackJamTarget>))]
        public List<TrackJamTarget> TrackJamTargets { get; } = new();

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
                    dos.WriteUnsignedByte(BeamDataLength);
                    dos.WriteUnsignedByte(BeamIDNumber);
                    dos.WriteUnsignedShort(BeamParameterIndex);
                    FundamentalParameterData.Marshal(dos);
                    dos.WriteUnsignedByte(BeamFunction);
                    dos.WriteUnsignedByte((byte)TrackJamTargets.Count);
                    dos.WriteUnsignedByte(HighDensityTrackJam);
                    dos.WriteUnsignedByte(Pad4);
                    dos.WriteUnsignedInt(JammingModeSequence);

                    for (int idx = 0; idx < TrackJamTargets.Count; idx++)
                    {
                        var aTrackJamTarget = TrackJamTargets[idx];
                        aTrackJamTarget.Marshal(dos);
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
                    BeamDataLength = dis.ReadUnsignedByte();
                    BeamIDNumber = dis.ReadUnsignedByte();
                    BeamParameterIndex = dis.ReadUnsignedShort();
                    FundamentalParameterData.Unmarshal(dis);
                    BeamFunction = dis.ReadUnsignedByte();
                    NumberOfTrackJamTargets = dis.ReadUnsignedByte();
                    HighDensityTrackJam = dis.ReadUnsignedByte();
                    Pad4 = dis.ReadUnsignedByte();
                    JammingModeSequence = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < NumberOfTrackJamTargets; idx++)
                    {
                        var anX = new TrackJamTarget();
                        anX.Unmarshal(dis);
                        TrackJamTargets.Add(anX);
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
            sb.AppendLine("<ElectronicEmissionBeamData>");
            try
            {
                sb.AppendLine("<beamDataLength type=\"byte\">" + BeamDataLength.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
                sb.AppendLine("<beamIDNumber type=\"byte\">" + BeamIDNumber.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
                sb.AppendLine("<beamParameterIndex type=\"ushort\">" + BeamParameterIndex.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
                sb.AppendLine("<fundamentalParameterData>");
                FundamentalParameterData.Reflection(sb);
                sb.AppendLine("</fundamentalParameterData>");
                sb.AppendLine("<beamFunction type=\"byte\">" + BeamFunction.ToString(CultureInfo.InvariantCulture) + "</beamFunction>");
                sb.AppendLine("<trackJamTargets type=\"byte\">" + TrackJamTargets.Count.ToString(CultureInfo.InvariantCulture) + "</trackJamTargets>");
                sb.AppendLine("<highDensityTrackJam type=\"byte\">" + HighDensityTrackJam.ToString(CultureInfo.InvariantCulture) + "</highDensityTrackJam>");
                sb.AppendLine("<pad4 type=\"byte\">" + Pad4.ToString(CultureInfo.InvariantCulture) + "</pad4>");
                sb.AppendLine("<jammingModeSequence type=\"uint\">" + JammingModeSequence.ToString(CultureInfo.InvariantCulture) + "</jammingModeSequence>");
                for (int idx = 0; idx < TrackJamTargets.Count; idx++)
                {
                    sb.AppendLine("<trackJamTargets" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TrackJamTarget\">");
                    var aTrackJamTarget = TrackJamTargets[idx];
                    aTrackJamTarget.Reflection(sb);
                    sb.AppendLine("</trackJamTargets" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ElectronicEmissionBeamData>");
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
        public override bool Equals(object obj) => this == obj as ElectronicEmissionBeamData;

        ///<inheritdoc/>
        public bool Equals(ElectronicEmissionBeamData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (BeamDataLength != obj.BeamDataLength)
            {
                ivarsEqual = false;
            }

            if (BeamIDNumber != obj.BeamIDNumber)
            {
                ivarsEqual = false;
            }

            if (BeamParameterIndex != obj.BeamParameterIndex)
            {
                ivarsEqual = false;
            }

            if (!FundamentalParameterData.Equals(obj.FundamentalParameterData))
            {
                ivarsEqual = false;
            }

            if (BeamFunction != obj.BeamFunction)
            {
                ivarsEqual = false;
            }

            if (NumberOfTrackJamTargets != obj.NumberOfTrackJamTargets)
            {
                ivarsEqual = false;
            }

            if (HighDensityTrackJam != obj.HighDensityTrackJam)
            {
                ivarsEqual = false;
            }

            if (Pad4 != obj.Pad4)
            {
                ivarsEqual = false;
            }

            if (JammingModeSequence != obj.JammingModeSequence)
            {
                ivarsEqual = false;
            }

            if (TrackJamTargets.Count != obj.TrackJamTargets.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < TrackJamTargets.Count; idx++)
                {
                    if (!TrackJamTargets[idx].Equals(obj.TrackJamTargets[idx]))
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

            result = GenerateHash(result) ^ BeamDataLength.GetHashCode();
            result = GenerateHash(result) ^ BeamIDNumber.GetHashCode();
            result = GenerateHash(result) ^ BeamParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ FundamentalParameterData.GetHashCode();
            result = GenerateHash(result) ^ BeamFunction.GetHashCode();
            result = GenerateHash(result) ^ NumberOfTrackJamTargets.GetHashCode();
            result = GenerateHash(result) ^ HighDensityTrackJam.GetHashCode();
            result = GenerateHash(result) ^ Pad4.GetHashCode();
            result = GenerateHash(result) ^ JammingModeSequence.GetHashCode();

            if (TrackJamTargets.Count > 0)
            {
                for (int idx = 0; idx < TrackJamTargets.Count; idx++)
                {
                    result = GenerateHash(result) ^ TrackJamTargets[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
