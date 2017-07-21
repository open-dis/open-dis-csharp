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
    /// Section 5.2.22. Contains electromagnetic emmision regineratin parameters that are        variable throughout a scenario dependent on the actions of the participants in the simulation. Also provides basic parametric data that may be used to support low-fidelity simulations.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class FundamentalParameterData
    {
        /// <summary>
        /// center frequency of the emission in hertz.
        /// </summary>
        private float _frequency;

        /// <summary>
        /// Bandwidth of the frequencies corresponding to the fequency field.
        /// </summary>
        private float _frequencyRange;

        /// <summary>
        /// Effective radiated power for the emission in DdBm. For a     radar noise jammer, indicates the peak of the transmitted power.
        /// </summary>
        private float _effectiveRadiatedPower;

        /// <summary>
        /// Average repetition frequency of the emission in hertz.
        /// </summary>
        private float _pulseRepetitionFrequency;

        /// <summary>
        /// Average pulse width  of the emission in microseconds.
        /// </summary>
        private float _pulseWidth;

        /// <summary>
        /// Specifies the beam azimuth an elevation centers and corresponding half-angles     to describe the scan volume
        /// </summary>
        private float _beamAzimuthCenter;

        /// <summary>
        /// Specifies the beam azimuth sweep to determine scan volume
        /// </summary>
        private float _beamAzimuthSweep;

        /// <summary>
        /// Specifies the beam elevation center to determine scan volume
        /// </summary>
        private float _beamElevationCenter;

        /// <summary>
        /// Specifies the beam elevation sweep to determine scan volume
        /// </summary>
        private float _beamElevationSweep;

        /// <summary>
        /// allows receiver to synchronize its regenerated scan pattern to     that of the emmitter. Specifies the percentage of time a scan is through its pattern from its origion.
        /// </summary>
        private float _beamSweepSync;

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FundamentalParameterData left, FundamentalParameterData right)
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
        public static bool operator ==(FundamentalParameterData left, FundamentalParameterData right)
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

            marshalSize += 4;  // this._frequency
            marshalSize += 4;  // this._frequencyRange
            marshalSize += 4;  // this._effectiveRadiatedPower
            marshalSize += 4;  // this._pulseRepetitionFrequency
            marshalSize += 4;  // this._pulseWidth
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
        public float Frequency
        {
            get
            {
                return this._frequency;
            }

            set
            {
                this._frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the Bandwidth of the frequencies corresponding to the fequency field.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "frequencyRange")]
        public float FrequencyRange
        {
            get
            {
                return this._frequencyRange;
            }

            set
            {
                this._frequencyRange = value;
            }
        }

        /// <summary>
        /// Gets or sets the Effective radiated power for the emission in DdBm. For a     radar noise jammer, indicates the peak of the transmitted power.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "effectiveRadiatedPower")]
        public float EffectiveRadiatedPower
        {
            get
            {
                return this._effectiveRadiatedPower;
            }

            set
            {
                this._effectiveRadiatedPower = value;
            }
        }

        /// <summary>
        /// Gets or sets the Average repetition frequency of the emission in hertz.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
        public float PulseRepetitionFrequency
        {
            get
            {
                return this._pulseRepetitionFrequency;
            }

            set
            {
                this._pulseRepetitionFrequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the Average pulse width  of the emission in microseconds.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
        public float PulseWidth
        {
            get
            {
                return this._pulseWidth;
            }

            set
            {
                this._pulseWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the Specifies the beam azimuth an elevation centers and corresponding half-angles     to describe the scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamAzimuthCenter")]
        public float BeamAzimuthCenter
        {
            get
            {
                return this._beamAzimuthCenter;
            }

            set
            {
                this._beamAzimuthCenter = value;
            }
        }

        /// <summary>
        /// Gets or sets the Specifies the beam azimuth sweep to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamAzimuthSweep")]
        public float BeamAzimuthSweep
        {
            get
            {
                return this._beamAzimuthSweep;
            }

            set
            {
                this._beamAzimuthSweep = value;
            }
        }

        /// <summary>
        /// Gets or sets the Specifies the beam elevation center to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamElevationCenter")]
        public float BeamElevationCenter
        {
            get
            {
                return this._beamElevationCenter;
            }

            set
            {
                this._beamElevationCenter = value;
            }
        }

        /// <summary>
        /// Gets or sets the Specifies the beam elevation sweep to determine scan volume
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamElevationSweep")]
        public float BeamElevationSweep
        {
            get
            {
                return this._beamElevationSweep;
            }

            set
            {
                this._beamElevationSweep = value;
            }
        }

        /// <summary>
        /// Gets or sets the allows receiver to synchronize its regenerated scan pattern to     that of the emmitter. Specifies the percentage of time a scan is through its pattern from its origion.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamSweepSync")]
        public float BeamSweepSync
        {
            get
            {
                return this._beamSweepSync;
            }

            set
            {
                this._beamSweepSync = value;
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
                    dos.WriteFloat((float)this._frequency);
                    dos.WriteFloat((float)this._frequencyRange);
                    dos.WriteFloat((float)this._effectiveRadiatedPower);
                    dos.WriteFloat((float)this._pulseRepetitionFrequency);
                    dos.WriteFloat((float)this._pulseWidth);
                    dos.WriteFloat((float)this._beamAzimuthCenter);
                    dos.WriteFloat((float)this._beamAzimuthSweep);
                    dos.WriteFloat((float)this._beamElevationCenter);
                    dos.WriteFloat((float)this._beamElevationSweep);
                    dos.WriteFloat((float)this._beamSweepSync);
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
                    this._frequency = dis.ReadFloat();
                    this._frequencyRange = dis.ReadFloat();
                    this._effectiveRadiatedPower = dis.ReadFloat();
                    this._pulseRepetitionFrequency = dis.ReadFloat();
                    this._pulseWidth = dis.ReadFloat();
                    this._beamAzimuthCenter = dis.ReadFloat();
                    this._beamAzimuthSweep = dis.ReadFloat();
                    this._beamElevationCenter = dis.ReadFloat();
                    this._beamElevationSweep = dis.ReadFloat();
                    this._beamSweepSync = dis.ReadFloat();
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
            sb.AppendLine("<FundamentalParameterData>");
            try
            {
                sb.AppendLine("<frequency type=\"float\">" + this._frequency.ToString(CultureInfo.InvariantCulture) + "</frequency>");
                sb.AppendLine("<frequencyRange type=\"float\">" + this._frequencyRange.ToString(CultureInfo.InvariantCulture) + "</frequencyRange>");
                sb.AppendLine("<effectiveRadiatedPower type=\"float\">" + this._effectiveRadiatedPower.ToString(CultureInfo.InvariantCulture) + "</effectiveRadiatedPower>");
                sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + this._pulseRepetitionFrequency.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
                sb.AppendLine("<pulseWidth type=\"float\">" + this._pulseWidth.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
                sb.AppendLine("<beamAzimuthCenter type=\"float\">" + this._beamAzimuthCenter.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthCenter>");
                sb.AppendLine("<beamAzimuthSweep type=\"float\">" + this._beamAzimuthSweep.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthSweep>");
                sb.AppendLine("<beamElevationCenter type=\"float\">" + this._beamElevationCenter.ToString(CultureInfo.InvariantCulture) + "</beamElevationCenter>");
                sb.AppendLine("<beamElevationSweep type=\"float\">" + this._beamElevationSweep.ToString(CultureInfo.InvariantCulture) + "</beamElevationSweep>");
                sb.AppendLine("<beamSweepSync type=\"float\">" + this._beamSweepSync.ToString(CultureInfo.InvariantCulture) + "</beamSweepSync>");
                sb.AppendLine("</FundamentalParameterData>");
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
            return this == obj as FundamentalParameterData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(FundamentalParameterData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._frequency != obj._frequency)
            {
                ivarsEqual = false;
            }

            if (this._frequencyRange != obj._frequencyRange)
            {
                ivarsEqual = false;
            }

            if (this._effectiveRadiatedPower != obj._effectiveRadiatedPower)
            {
                ivarsEqual = false;
            }

            if (this._pulseRepetitionFrequency != obj._pulseRepetitionFrequency)
            {
                ivarsEqual = false;
            }

            if (this._pulseWidth != obj._pulseWidth)
            {
                ivarsEqual = false;
            }

            if (this._beamAzimuthCenter != obj._beamAzimuthCenter)
            {
                ivarsEqual = false;
            }

            if (this._beamAzimuthSweep != obj._beamAzimuthSweep)
            {
                ivarsEqual = false;
            }

            if (this._beamElevationCenter != obj._beamElevationCenter)
            {
                ivarsEqual = false;
            }

            if (this._beamElevationSweep != obj._beamElevationSweep)
            {
                ivarsEqual = false;
            }

            if (this._beamSweepSync != obj._beamSweepSync)
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

            result = GenerateHash(result) ^ this._frequency.GetHashCode();
            result = GenerateHash(result) ^ this._frequencyRange.GetHashCode();
            result = GenerateHash(result) ^ this._effectiveRadiatedPower.GetHashCode();
            result = GenerateHash(result) ^ this._pulseRepetitionFrequency.GetHashCode();
            result = GenerateHash(result) ^ this._pulseWidth.GetHashCode();
            result = GenerateHash(result) ^ this._beamAzimuthCenter.GetHashCode();
            result = GenerateHash(result) ^ this._beamAzimuthSweep.GetHashCode();
            result = GenerateHash(result) ^ this._beamElevationCenter.GetHashCode();
            result = GenerateHash(result) ^ this._beamElevationSweep.GetHashCode();
            result = GenerateHash(result) ^ this._beamSweepSync.GetHashCode();

            return result;
        }
    }
}
