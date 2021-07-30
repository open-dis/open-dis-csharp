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
    /// Used in UaPdu
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AcousticBeamFundamentalParameter : IEquatable<AcousticBeamFundamentalParameter>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcousticBeamFundamentalParameter"/> class.
        /// </summary>
        public AcousticBeamFundamentalParameter()
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
        public static bool operator !=(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 2;  // this._activeEmissionParameterIndex
            marshalSize += 2;  // this._scanPattern
            marshalSize += 4;  // this._beamCenterAzimuth
            marshalSize += 4;  // this._azimuthalBeamwidth
            marshalSize += 4;  // this._beamCenterDE
            marshalSize += 4;  // this._deBeamwidth
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the parameter index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "activeEmissionParameterIndex")]
        public ushort ActiveEmissionParameterIndex { get; set; }

        /// <summary>
        /// Gets or sets the scan pattern
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
        public ushort ScanPattern { get; set; }

        /// <summary>
        /// Gets or sets the beam center azimuth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuth")]
        public float BeamCenterAzimuth { get; set; }

        /// <summary>
        /// Gets or sets the azimuthal beamwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidth")]
        public float AzimuthalBeamwidth { get; set; }

        /// <summary>
        /// Gets or sets the beam center
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterDE")]
        public float BeamCenterDE { get; set; }

        /// <summary>
        /// Gets or sets the DE beamwidth (vertical beamwidth)
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "deBeamwidth")]
        public float DeBeamwidth { get; set; }

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
                    dos.WriteUnsignedShort(ActiveEmissionParameterIndex);
                    dos.WriteUnsignedShort(ScanPattern);
                    dos.WriteFloat((float)BeamCenterAzimuth);
                    dos.WriteFloat((float)AzimuthalBeamwidth);
                    dos.WriteFloat((float)BeamCenterDE);
                    dos.WriteFloat((float)DeBeamwidth);
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
                    ActiveEmissionParameterIndex = dis.ReadUnsignedShort();
                    ScanPattern = dis.ReadUnsignedShort();
                    BeamCenterAzimuth = dis.ReadFloat();
                    AzimuthalBeamwidth = dis.ReadFloat();
                    BeamCenterDE = dis.ReadFloat();
                    DeBeamwidth = dis.ReadFloat();
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
            sb.AppendLine("<AcousticBeamFundamentalParameter>");
            try
            {
                sb.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + ActiveEmissionParameterIndex.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
                sb.AppendLine("<scanPattern type=\"ushort\">" + ScanPattern.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
                sb.AppendLine("<beamCenterAzimuth type=\"float\">" + BeamCenterAzimuth.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuth>");
                sb.AppendLine("<azimuthalBeamwidth type=\"float\">" + AzimuthalBeamwidth.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidth>");
                sb.AppendLine("<beamCenterDE type=\"float\">" + BeamCenterDE.ToString(CultureInfo.InvariantCulture) + "</beamCenterDE>");
                sb.AppendLine("<deBeamwidth type=\"float\">" + DeBeamwidth.ToString(CultureInfo.InvariantCulture) + "</deBeamwidth>");
                sb.AppendLine("</AcousticBeamFundamentalParameter>");
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
        public override bool Equals(object obj) => this == obj as AcousticBeamFundamentalParameter;

        ///<inheritdoc/>
        public bool Equals(AcousticBeamFundamentalParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (ActiveEmissionParameterIndex != obj.ActiveEmissionParameterIndex)
            {
                ivarsEqual = false;
            }

            if (ScanPattern != obj.ScanPattern)
            {
                ivarsEqual = false;
            }

            if (BeamCenterAzimuth != obj.BeamCenterAzimuth)
            {
                ivarsEqual = false;
            }

            if (AzimuthalBeamwidth != obj.AzimuthalBeamwidth)
            {
                ivarsEqual = false;
            }

            if (BeamCenterDE != obj.BeamCenterDE)
            {
                ivarsEqual = false;
            }

            if (DeBeamwidth != obj.DeBeamwidth)
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

            result = GenerateHash(result) ^ ActiveEmissionParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ ScanPattern.GetHashCode();
            result = GenerateHash(result) ^ BeamCenterAzimuth.GetHashCode();
            result = GenerateHash(result) ^ AzimuthalBeamwidth.GetHashCode();
            result = GenerateHash(result) ^ BeamCenterDE.GetHashCode();
            result = GenerateHash(result) ^ DeBeamwidth.GetHashCode();

            return result;
        }
    }
}
