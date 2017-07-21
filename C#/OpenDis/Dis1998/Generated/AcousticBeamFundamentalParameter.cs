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
    /// Used in UaPdu
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class AcousticBeamFundamentalParameter
    {
        /// <summary>
        /// parameter index
        /// </summary>
        private ushort _activeEmissionParameterIndex;

        /// <summary>
        /// scan pattern
        /// </summary>
        private ushort _scanPattern;

        /// <summary>
        /// beam center azimuth
        /// </summary>
        private float _beamCenterAzimuth;

        /// <summary>
        /// azimuthal beamwidth
        /// </summary>
        private float _azimuthalBeamwidth;

        /// <summary>
        /// beam center
        /// </summary>
        private float _beamCenterDE;

        /// <summary>
        /// DE beamwidth (vertical beamwidth)
        /// </summary>
        private float _deBeamwidth;

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right)
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
        public static bool operator ==(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right)
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
        public ushort ActiveEmissionParameterIndex
        {
            get
            {
                return this._activeEmissionParameterIndex;
            }

            set
            {
                this._activeEmissionParameterIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the scan pattern
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
        public ushort ScanPattern
        {
            get
            {
                return this._scanPattern;
            }

            set
            {
                this._scanPattern = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam center azimuth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuth")]
        public float BeamCenterAzimuth
        {
            get
            {
                return this._beamCenterAzimuth;
            }

            set
            {
                this._beamCenterAzimuth = value;
            }
        }

        /// <summary>
        /// Gets or sets the azimuthal beamwidth
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidth")]
        public float AzimuthalBeamwidth
        {
            get
            {
                return this._azimuthalBeamwidth;
            }

            set
            {
                this._azimuthalBeamwidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam center
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterDE")]
        public float BeamCenterDE
        {
            get
            {
                return this._beamCenterDE;
            }

            set
            {
                this._beamCenterDE = value;
            }
        }

        /// <summary>
        /// Gets or sets the DE beamwidth (vertical beamwidth)
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "deBeamwidth")]
        public float DeBeamwidth
        {
            get
            {
                return this._deBeamwidth;
            }

            set
            {
                this._deBeamwidth = value;
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
                    dos.WriteUnsignedShort((ushort)this._activeEmissionParameterIndex);
                    dos.WriteUnsignedShort((ushort)this._scanPattern);
                    dos.WriteFloat((float)this._beamCenterAzimuth);
                    dos.WriteFloat((float)this._azimuthalBeamwidth);
                    dos.WriteFloat((float)this._beamCenterDE);
                    dos.WriteFloat((float)this._deBeamwidth);
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
                    this._activeEmissionParameterIndex = dis.ReadUnsignedShort();
                    this._scanPattern = dis.ReadUnsignedShort();
                    this._beamCenterAzimuth = dis.ReadFloat();
                    this._azimuthalBeamwidth = dis.ReadFloat();
                    this._beamCenterDE = dis.ReadFloat();
                    this._deBeamwidth = dis.ReadFloat();
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
            sb.AppendLine("<AcousticBeamFundamentalParameter>");
            try
            {
                sb.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + this._activeEmissionParameterIndex.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
                sb.AppendLine("<scanPattern type=\"ushort\">" + this._scanPattern.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
                sb.AppendLine("<beamCenterAzimuth type=\"float\">" + this._beamCenterAzimuth.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuth>");
                sb.AppendLine("<azimuthalBeamwidth type=\"float\">" + this._azimuthalBeamwidth.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidth>");
                sb.AppendLine("<beamCenterDE type=\"float\">" + this._beamCenterDE.ToString(CultureInfo.InvariantCulture) + "</beamCenterDE>");
                sb.AppendLine("<deBeamwidth type=\"float\">" + this._deBeamwidth.ToString(CultureInfo.InvariantCulture) + "</deBeamwidth>");
                sb.AppendLine("</AcousticBeamFundamentalParameter>");
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
            return this == obj as AcousticBeamFundamentalParameter;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AcousticBeamFundamentalParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._activeEmissionParameterIndex != obj._activeEmissionParameterIndex)
            {
                ivarsEqual = false;
            }

            if (this._scanPattern != obj._scanPattern)
            {
                ivarsEqual = false;
            }

            if (this._beamCenterAzimuth != obj._beamCenterAzimuth)
            {
                ivarsEqual = false;
            }

            if (this._azimuthalBeamwidth != obj._azimuthalBeamwidth)
            {
                ivarsEqual = false;
            }

            if (this._beamCenterDE != obj._beamCenterDE)
            {
                ivarsEqual = false;
            }

            if (this._deBeamwidth != obj._deBeamwidth)
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

            result = GenerateHash(result) ^ this._activeEmissionParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ this._scanPattern.GetHashCode();
            result = GenerateHash(result) ^ this._beamCenterAzimuth.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthalBeamwidth.GetHashCode();
            result = GenerateHash(result) ^ this._beamCenterDE.GetHashCode();
            result = GenerateHash(result) ^ this._deBeamwidth.GetHashCode();

            return result;
        }
    }
}
