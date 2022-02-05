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
    /// Section 5.2.22. Contains electromagnetic emmision regineratin parameters that are       variable throughout a scenario
    /// dependent on the actions of the participants in the simulation. Also provides basic parametric data that may be used to support low-fidelity simulations.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class FundamentalParameterData : IEquatable<FundamentalParameterData>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundamentalParameterData"/> class.
        /// </summary>
        public FundamentalParameterData()
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
        public static bool operator !=(FundamentalParameterData left, FundamentalParameterData right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(FundamentalParameterData left, FundamentalParameterData right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 4;  // this._frequency
            marshalSize += 4;  // this._frequencyRange
            marshalSize += 4;  // this._effectiveRadiatedPower
            marshalSize += 4;  // this._pulseRepetitionFrequency
            marshalSize += 4;  // this._pusleWidth
            marshalSize += 4;  // this._beamAzimuthCenter
            marshalSize += 4;  // this._beamAzimuthSweep
            marshalSize += 4;  // this._beamElevationCenter
            marshalSize += 4;  // this._beamElevationSweep
            marshalSize += 4;  // this._beamSweepSync
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the center frequency of the emission in hertz.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "frequency")]
        public float Frequency { get; set; }

        /// <summary>
        /// Gets or sets the Bandwidth of the frequencies corresponding to the fequency field.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "frequencyRange")]
        public float FrequencyRange { get; set; }

        /// <summary>
        /// Gets or sets the Effective radiated power for the emission in DdBm. For a     radar noise jammer, indicates the
        /// peak of the transmitted power.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "effectiveRadiatedPower")]
        public float EffectiveRadiatedPower { get; set; }

        /// <summary>
        /// Gets or sets the Average repetition frequency of the emission in hertz.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
        public float PulseRepetitionFrequency { get; set; }

        /// <summary>
        /// Gets or sets the Average pulse width of the emission in microseconds.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pusleWidth")]
        public float PusleWidth { get; set; }

        /// <summary>
        /// Gets or sets the Specifies the beam azimuth an elevation centers and corresponding half-angles    to describe the
        /// scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamAzimuthCenter")]
        public float BeamAzimuthCenter { get; set; }

        /// <summary>
        /// Gets or sets the Specifies the beam azimuth sweep to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamAzimuthSweep")]
        public float BeamAzimuthSweep { get; set; }

        /// <summary>
        /// Gets or sets the Specifies the beam elevation center to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamElevationCenter")]
        public float BeamElevationCenter { get; set; }

        /// <summary>
        /// Gets or sets the Specifies the beam elevation sweep to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamElevationSweep")]
        public float BeamElevationSweep { get; set; }

        /// <summary>
        /// Gets or sets the allows receiver to synchronize its regenerated scan pattern to    that of the emmitter. Specifies
        /// the percentage of time a scan is through its pattern from its origion.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamSweepSync")]
        public float BeamSweepSync { get; set; }

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
                    dos.WriteFloat((float)Frequency);
                    dos.WriteFloat((float)FrequencyRange);
                    dos.WriteFloat((float)EffectiveRadiatedPower);
                    dos.WriteFloat((float)PulseRepetitionFrequency);
                    dos.WriteFloat(PusleWidth);
                    dos.WriteFloat((float)BeamAzimuthCenter);
                    dos.WriteFloat(BeamAzimuthSweep);
                    dos.WriteFloat((float)BeamElevationCenter);
                    dos.WriteFloat(BeamElevationSweep);
                    dos.WriteFloat((float)BeamSweepSync);
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
                    Frequency = dis.ReadFloat();
                    FrequencyRange = dis.ReadFloat();
                    EffectiveRadiatedPower = dis.ReadFloat();
                    PulseRepetitionFrequency = dis.ReadFloat();
                    PusleWidth = dis.ReadFloat();
                    BeamAzimuthCenter = dis.ReadFloat();
                    BeamAzimuthSweep = dis.ReadFloat();
                    BeamElevationCenter = dis.ReadFloat();
                    BeamElevationSweep = dis.ReadFloat();
                    BeamSweepSync = dis.ReadFloat();
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
            sb.AppendLine("<FundamentalParameterData>");
            try
            {
                sb.AppendLine("<frequency type=\"float\">" + Frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<frequencyRange type=\"float\">" + FrequencyRange.ToString(CultureInfo.InvariantCulture) + "</frequencyRange>");
                sb.AppendLine("<effectiveRadiatedPower type=\"float\">" + EffectiveRadiatedPower.ToString(CultureInfo.InvariantCulture) + "</effectiveRadiatedPower>");
                sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + PulseRepetitionFrequency.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
                sb.AppendLine("<pusleWidth type=\"float\">" + PusleWidth.ToString(CultureInfo.InvariantCulture) + "</pusleWidth>");
                sb.AppendLine("<beamAzimuthCenter type=\"float\">" + BeamAzimuthCenter.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthCenter>");
                sb.AppendLine("<beamAzimuthSweep type=\"float\">" + BeamAzimuthSweep.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthSweep>");
                sb.AppendLine("<beamElevationCenter type=\"float\">" + BeamElevationCenter.ToString(CultureInfo.InvariantCulture) + "</beamElevationCenter>");
                sb.AppendLine("<beamElevationSweep type=\"float\">" + BeamElevationSweep.ToString(CultureInfo.InvariantCulture) + "</beamElevationSweep>");
                sb.AppendLine("<beamSweepSync type=\"float\">" + BeamSweepSync.ToString(CultureInfo.InvariantCulture) + "</beamSweepSync>");
                sb.AppendLine("</FundamentalParameterData>");
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
        public override bool Equals(object obj) => this == obj as FundamentalParameterData;

        ///<inheritdoc/>
        public bool Equals(FundamentalParameterData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (Frequency != obj.Frequency)
            {
                ivarsEqual = false;
            }

            if (FrequencyRange != obj.FrequencyRange)
            {
                ivarsEqual = false;
            }

            if (EffectiveRadiatedPower != obj.EffectiveRadiatedPower)
            {
                ivarsEqual = false;
            }

            if (PulseRepetitionFrequency != obj.PulseRepetitionFrequency)
            {
                ivarsEqual = false;
            }

            if (PusleWidth != obj.PusleWidth)
            {
                ivarsEqual = false;
            }

            if (BeamAzimuthCenter != obj.BeamAzimuthCenter)
            {
                ivarsEqual = false;
            }

            if (BeamAzimuthSweep != obj.BeamAzimuthSweep)
            {
                ivarsEqual = false;
            }

            if (BeamElevationCenter != obj.BeamElevationCenter)
            {
                ivarsEqual = false;
            }

            if (BeamElevationSweep != obj.BeamElevationSweep)
            {
                ivarsEqual = false;
            }

            if (BeamSweepSync != obj.BeamSweepSync)
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

            result = GenerateHash(result) ^ Frequency.GetHashCode();
            result = GenerateHash(result) ^ FrequencyRange.GetHashCode();
            result = GenerateHash(result) ^ EffectiveRadiatedPower.GetHashCode();
            result = GenerateHash(result) ^ PulseRepetitionFrequency.GetHashCode();
            result = GenerateHash(result) ^ PusleWidth.GetHashCode();
            result = GenerateHash(result) ^ BeamAzimuthCenter.GetHashCode();
            result = GenerateHash(result) ^ BeamAzimuthSweep.GetHashCode();
            result = GenerateHash(result) ^ BeamElevationCenter.GetHashCode();
            result = GenerateHash(result) ^ BeamElevationSweep.GetHashCode();
            result = GenerateHash(result) ^ BeamSweepSync.GetHashCode();

            return result;
        }
    }
}
