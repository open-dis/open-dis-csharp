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
    /// Section 5.2.4.2. Used when the antenna pattern type field has a value of 1. Specifies           the direction, patter, and polarization of radiation from an antenna.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Orientation))]
    public partial class BeamAntennaPattern
    {
        /// <summary>
        /// The rotation that transformst he reference coordinate sytem    into the beam coordinate system. Either world coordinates or entity coordinates may be used as the     reference coordinate system, as specified by teh reference system field of the antenna pattern record.
        /// </summary>
        private Orientation _beamDirection = new Orientation();

        private float _azimuthBeamwidth;

        private float _referenceSystem;

        private short _padding1;

        private byte _padding2;

        /// <summary>
        /// Magnigute of the z-component in beam coordinates at some arbitrary     single point in the mainbeam      and in the far field of the antenna.
        /// </summary>
        private float _ez;

        /// <summary>
        /// Magnigute of the x-component in beam coordinates at some arbitrary     single point in the mainbeam      and in the far field of the antenna.
        /// </summary>
        private float _ex;

        /// <summary>
        /// THe phase angle between Ez and Ex in radians.
        /// </summary>
        private float _phase;

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(BeamAntennaPattern left, BeamAntennaPattern right)
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
        public static bool operator ==(BeamAntennaPattern left, BeamAntennaPattern right)
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

            marshalSize += this._beamDirection.GetMarshalledSize();  // this._beamDirection
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
        /// Gets or sets the The rotation that transformst he reference coordinate sytem    into the beam coordinate system. Either world coordinates or entity coordinates may be used as the     reference coordinate system, as specified by teh reference system field of the antenna pattern record.
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "beamDirection")]
        public Orientation BeamDirection
        {
            get
            {
                return this._beamDirection;
            }

            set
            {
                this._beamDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets the azimuthBeamwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
        public float AzimuthBeamwidth
        {
            get
            {
                return this._azimuthBeamwidth;
            }

            set
            {
                this._azimuthBeamwidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the referenceSystem
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
        public float ReferenceSystem
        {
            get
            {
                return this._referenceSystem;
            }

            set
            {
                this._referenceSystem = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding1
        /// </summary>
        [XmlElement(Type = typeof(short), ElementName = "padding1")]
        public short Padding1
        {
            get
            {
                return this._padding1;
            }

            set
            {
                this._padding1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding2
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding2")]
        public byte Padding2
        {
            get
            {
                return this._padding2;
            }

            set
            {
                this._padding2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the Magnigute of the z-component in beam coordinates at some arbitrary     single point in the mainbeam      and in the far field of the antenna.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "ez")]
        public float Ez
        {
            get
            {
                return this._ez;
            }

            set
            {
                this._ez = value;
            }
        }

        /// <summary>
        /// Gets or sets the Magnigute of the x-component in beam coordinates at some arbitrary     single point in the mainbeam      and in the far field of the antenna.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "ex")]
        public float Ex
        {
            get
            {
                return this._ex;
            }

            set
            {
                this._ex = value;
            }
        }

        /// <summary>
        /// Gets or sets the THe phase angle between Ez and Ex in radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "phase")]
        public float Phase
        {
            get
            {
                return this._phase;
            }

            set
            {
                this._phase = value;
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
                    this._beamDirection.Marshal(dos);
                    dos.WriteFloat((float)this._azimuthBeamwidth);
                    dos.WriteFloat((float)this._referenceSystem);
                    dos.WriteShort((short)this._padding1);
                    dos.WriteByte((byte)this._padding2);
                    dos.WriteFloat((float)this._ez);
                    dos.WriteFloat((float)this._ex);
                    dos.WriteFloat((float)this._phase);
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
                    this._beamDirection.Unmarshal(dis);
                    this._azimuthBeamwidth = dis.ReadFloat();
                    this._referenceSystem = dis.ReadFloat();
                    this._padding1 = dis.ReadShort();
                    this._padding2 = dis.ReadByte();
                    this._ez = dis.ReadFloat();
                    this._ex = dis.ReadFloat();
                    this._phase = dis.ReadFloat();
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
            sb.AppendLine("<BeamAntennaPattern>");
            try
            {
                sb.AppendLine("<beamDirection>");
                this._beamDirection.Reflection(sb);
                sb.AppendLine("</beamDirection>");
                sb.AppendLine("<azimuthBeamwidth type=\"float\">" + this._azimuthBeamwidth.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
                sb.AppendLine("<referenceSystem type=\"float\">" + this._referenceSystem.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
                sb.AppendLine("<padding1 type=\"short\">" + this._padding1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
                sb.AppendLine("<padding2 type=\"byte\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<ez type=\"float\">" + this._ez.ToString(CultureInfo.InvariantCulture) + "</ez>");
                sb.AppendLine("<ex type=\"float\">" + this._ex.ToString(CultureInfo.InvariantCulture) + "</ex>");
                sb.AppendLine("<phase type=\"float\">" + this._phase.ToString(CultureInfo.InvariantCulture) + "</phase>");
                sb.AppendLine("</BeamAntennaPattern>");
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
            return this == obj as BeamAntennaPattern;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(BeamAntennaPattern obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!this._beamDirection.Equals(obj._beamDirection))
            {
                ivarsEqual = false;
            }

            if (this._azimuthBeamwidth != obj._azimuthBeamwidth)
            {
                ivarsEqual = false;
            }

            if (this._referenceSystem != obj._referenceSystem)
            {
                ivarsEqual = false;
            }

            if (this._padding1 != obj._padding1)
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (this._ez != obj._ez)
            {
                ivarsEqual = false;
            }

            if (this._ex != obj._ex)
            {
                ivarsEqual = false;
            }

            if (this._phase != obj._phase)
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

            result = GenerateHash(result) ^ this._beamDirection.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthBeamwidth.GetHashCode();
            result = GenerateHash(result) ^ this._referenceSystem.GetHashCode();
            result = GenerateHash(result) ^ this._padding1.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._ez.GetHashCode();
            result = GenerateHash(result) ^ this._ex.GetHashCode();
            result = GenerateHash(result) ^ this._phase.GetHashCode();

            return result;
        }
    }
}
