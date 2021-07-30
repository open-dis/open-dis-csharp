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
    /// Section 5.2.4.2. Used when the antenna pattern type field has a value of 1. Specifies          the direction, patter,
    /// and polarization of radiation from an antenna.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Orientation))]
    public partial class BeamAntennaPattern : IEquatable<BeamAntennaPattern>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeamAntennaPattern"/> class.
        /// </summary>
        public BeamAntennaPattern()
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
        public static bool operator !=(BeamAntennaPattern left, BeamAntennaPattern right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(BeamAntennaPattern left, BeamAntennaPattern right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += BeamDirection.GetMarshalledSize();  // this._beamDirection
            marshalSize += 4;  // this._azimuthBeamwidth
            marshalSize += 4;  // this._referenceSystem
            marshalSize += 2;  // this._padding1
            marshalSize += 1;  // this._padding2
            marshalSize += 4;  // this._ez
            marshalSize += 4;  // this._ex
            marshalSize += 4;  // this._phase
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the rotation that transforms the reference coordinate system into the beam coordinate
        /// system. Either world coordinates or entity coordinates may be used as the reference coordinate
        /// system, as specified by the reference system field of the antenna pattern record.
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "beamDirection")]
        public Orientation BeamDirection { get; set; } = new Orientation();

        /// <summary>
        /// Gets or sets the azimuthBeamwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
        public float AzimuthBeamwidth { get; set; }

        /// <summary>
        /// Gets or sets the referenceSystem
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
        public float ReferenceSystem { get; set; }

        /// <summary>
        /// Gets or sets the padding1
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding1")]
        public short Padding1 { get; set; }

        /// <summary>
        /// Gets or sets the padding2
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2 { get; set; }

        /// <summary>
        /// Gets or sets the Magnigute of the z-component in beam coordinates at some arbitrary     single point in the mainbeam
        ///      and in the far field of the antenna.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "ez")]
        public float Ez { get; set; }

        /// <summary>
        /// Gets or sets the Magnigute of the x-component in beam coordinates at some arbitrary     single point in the mainbeam
        ///      and in the far field of the antenna.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "ex")]
        public float Ex { get; set; }

        /// <summary>
        /// Gets or sets the phase angle between Ez and Ex in radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "phase")]
        public float Phase { get; set; }

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
                    BeamDirection.Marshal(dos);
                    dos.WriteFloat((float)AzimuthBeamwidth);
                    dos.WriteFloat(ReferenceSystem);
                    dos.WriteShort(Padding1);
                    dos.WriteByte(Padding2);
                    dos.WriteFloat((float)Ez);
                    dos.WriteFloat(Ex);
                    dos.WriteFloat((float)Phase);
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
                    BeamDirection.Unmarshal(dis);
                    AzimuthBeamwidth = dis.ReadFloat();
                    ReferenceSystem = dis.ReadFloat();
                    Padding1 = dis.ReadShort();
                    Padding2 = dis.ReadByte();
                    Ez = dis.ReadFloat();
                    Ex = dis.ReadFloat();
                    Phase = dis.ReadFloat();
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
            sb.AppendLine("<BeamAntennaPattern>");
            try
            {
                sb.AppendLine("<beamDirection>");
                BeamDirection.Reflection(sb);
                sb.AppendLine("</beamDirection>");
                sb.AppendLine("<azimuthBeamwidth type=\"float\">" + AzimuthBeamwidth.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
                sb.AppendLine("<referenceSystem type=\"float\">" + ReferenceSystem.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
                sb.AppendLine("<padding1 type=\"short\">" + Padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + Padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<ez type=\"float\">" + Ez.ToString(CultureInfo.InvariantCulture) + "</ez>");
                sb.AppendLine("<ex type=\"float\">" + Ex.ToString(CultureInfo.InvariantCulture) + "</ex>");
                sb.AppendLine("<phase type=\"float\">" + Phase.ToString(CultureInfo.InvariantCulture) + "</phase>");
                sb.AppendLine("</BeamAntennaPattern>");
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
        public override bool Equals(object obj) => this == obj as BeamAntennaPattern;

        ///<inheritdoc/>
        public bool Equals(BeamAntennaPattern obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (!BeamDirection.Equals(obj.BeamDirection))
            {
                ivarsEqual = false;
            }

            if (AzimuthBeamwidth != obj.AzimuthBeamwidth)
            {
                ivarsEqual = false;
            }

            if (ReferenceSystem != obj.ReferenceSystem)
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

            if (Ez != obj.Ez)
            {
                ivarsEqual = false;
            }

            if (Ex != obj.Ex)
            {
                ivarsEqual = false;
            }

            if (Phase != obj.Phase)
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

            result = GenerateHash(result) ^ BeamDirection.GetHashCode();
            result = GenerateHash(result) ^ AzimuthBeamwidth.GetHashCode();
            result = GenerateHash(result) ^ ReferenceSystem.GetHashCode();
            result = GenerateHash(result) ^ Padding1.GetHashCode();
            result = GenerateHash(result) ^ Padding2.GetHashCode();
            result = GenerateHash(result) ^ Ez.GetHashCode();
            result = GenerateHash(result) ^ Ex.GetHashCode();
            result = GenerateHash(result) ^ Phase.GetHashCode();

            return result;
        }
    }
}
