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
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// Regeneration parameters for active emission systems that are variable throughout a scenario. Section 6.2.90
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class UAFundamentalParameter
    {
        /// <summary>
        /// Which database record shall be used. An enumeration from EBV document
        /// </summary>
        private ushort _activeEmissionParameterIndex;

        /// <summary>
        /// The type of scan pattern, If not used, zero. An enumeration from EBV document
        /// </summary>
        private ushort _scanPattern;

        /// <summary>
        /// center azimuth bearing of th emain beam. In radians.
        /// </summary>
        private float _beamCenterAzimuthHorizontal;

        /// <summary>
        /// Horizontal beamwidth of th emain beam Meastued at the 3dB down point of peak radiated power. In radians.
        /// </summary>
        private float _azimuthalBeamwidthHorizontal;

        /// <summary>
        /// center of the d/e angle of th emain beam relative to the stablised de angle of the target. In radians.
        /// </summary>
        private float _beamCenterDepressionElevation;

        /// <summary>
        /// vertical beamwidth of the main beam. Meastured at the 3dB down point of peak radiated power. In radians.
        /// </summary>
        private float _beamwidthDownElevation;

        /// <summary>
        /// Initializes a new instance of the <see cref="UAFundamentalParameter"/> class.
        /// </summary>
        public UAFundamentalParameter()
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
        public static bool operator !=(UAFundamentalParameter left, UAFundamentalParameter right)
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
        public static bool operator ==(UAFundamentalParameter left, UAFundamentalParameter right)
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
            marshalSize += 4;  // this._beamCenterAzimuthHorizontal
            marshalSize += 4;  // this._azimuthalBeamwidthHorizontal
            marshalSize += 4;  // this._beamCenterDepressionElevation
            marshalSize += 4;  // this._beamwidthDownElevation
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Which database record shall be used. An enumeration from EBV document
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
        /// Gets or sets the The type of scan pattern, If not used, zero. An enumeration from EBV document
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
        /// Gets or sets the center azimuth bearing of th emain beam. In radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuthHorizontal")]
        public float BeamCenterAzimuthHorizontal
        {
            get
            {
                return this._beamCenterAzimuthHorizontal;
            }

            set
            {
                this._beamCenterAzimuthHorizontal = value;
            }
        }

        /// <summary>
        /// Gets or sets the Horizontal beamwidth of th emain beam Meastued at the 3dB down point of peak radiated power. In radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidthHorizontal")]
        public float AzimuthalBeamwidthHorizontal
        {
            get
            {
                return this._azimuthalBeamwidthHorizontal;
            }

            set
            {
                this._azimuthalBeamwidthHorizontal = value;
            }
        }

        /// <summary>
        /// Gets or sets the center of the d/e angle of th emain beam relative to the stablised de angle of the target. In radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamCenterDepressionElevation")]
        public float BeamCenterDepressionElevation
        {
            get
            {
                return this._beamCenterDepressionElevation;
            }

            set
            {
                this._beamCenterDepressionElevation = value;
            }
        }

        /// <summary>
        /// Gets or sets the vertical beamwidth of the main beam. Meastured at the 3dB down point of peak radiated power. In radians.
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "beamwidthDownElevation")]
        public float BeamwidthDownElevation
        {
            get
            {
                return this._beamwidthDownElevation;
            }

            set
            {
                this._beamwidthDownElevation = value;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
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
                    dos.WriteFloat((float)this._beamCenterAzimuthHorizontal);
                    dos.WriteFloat((float)this._azimuthalBeamwidthHorizontal);
                    dos.WriteFloat((float)this._beamCenterDepressionElevation);
                    dos.WriteFloat((float)this._beamwidthDownElevation);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                    this._beamCenterAzimuthHorizontal = dis.ReadFloat();
                    this._azimuthalBeamwidthHorizontal = dis.ReadFloat();
                    this._beamCenterDepressionElevation = dis.ReadFloat();
                    this._beamwidthDownElevation = dis.ReadFloat();
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
            sb.AppendLine("<UAFundamentalParameter>");
            try
            {
                sb.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + this._activeEmissionParameterIndex.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
                sb.AppendLine("<scanPattern type=\"ushort\">" + this._scanPattern.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
                sb.AppendLine("<beamCenterAzimuthHorizontal type=\"float\">" + this._beamCenterAzimuthHorizontal.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuthHorizontal>");
                sb.AppendLine("<azimuthalBeamwidthHorizontal type=\"float\">" + this._azimuthalBeamwidthHorizontal.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidthHorizontal>");
                sb.AppendLine("<beamCenterDepressionElevation type=\"float\">" + this._beamCenterDepressionElevation.ToString(CultureInfo.InvariantCulture) + "</beamCenterDepressionElevation>");
                sb.AppendLine("<beamwidthDownElevation type=\"float\">" + this._beamwidthDownElevation.ToString(CultureInfo.InvariantCulture) + "</beamwidthDownElevation>");
                sb.AppendLine("</UAFundamentalParameter>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
            return this == obj as UAFundamentalParameter;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(UAFundamentalParameter obj)
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

            if (this._beamCenterAzimuthHorizontal != obj._beamCenterAzimuthHorizontal)
            {
                ivarsEqual = false;
            }

            if (this._azimuthalBeamwidthHorizontal != obj._azimuthalBeamwidthHorizontal)
            {
                ivarsEqual = false;
            }

            if (this._beamCenterDepressionElevation != obj._beamCenterDepressionElevation)
            {
                ivarsEqual = false;
            }

            if (this._beamwidthDownElevation != obj._beamwidthDownElevation)
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
            result = GenerateHash(result) ^ this._beamCenterAzimuthHorizontal.GetHashCode();
            result = GenerateHash(result) ^ this._azimuthalBeamwidthHorizontal.GetHashCode();
            result = GenerateHash(result) ^ this._beamCenterDepressionElevation.GetHashCode();
            result = GenerateHash(result) ^ this._beamwidthDownElevation.GetHashCode();

            return result;
        }
    }
}
