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
    /// Section 5.3.7.4.2 When present, layer 2 should follow layer 1 and have the following fields. This requires manual cleanup.        the beamData attribute semantics are used in multiple ways. UNFINSISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(LayerHeader))]
    [XmlInclude(typeof(BeamData))]
    [XmlInclude(typeof(FundamentalParameterDataIff))]
    public partial class IffAtcNavAidsLayer2Pdu : IffAtcNavAidsLayer1Pdu, IEquatable<IffAtcNavAidsLayer2Pdu>
    {
        /// <summary>
        /// layer header
        /// </summary>
        private LayerHeader _layerHeader = new LayerHeader();

        /// <summary>
        /// beam data
        /// </summary>
        private BeamData _beamData = new BeamData();

        /// <summary>
        /// Secondary operational data, 5.2.57
        /// </summary>
        private BeamData _secondaryOperationalData = new BeamData();

        /// <summary>
        /// variable length list of fundamental parameters. ^^^This is wrong
        /// </summary>
        private List<FundamentalParameterDataIff> _fundamentalIffParameters = new List<FundamentalParameterDataIff>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IffAtcNavAidsLayer2Pdu"/> class.
        /// </summary>
        public IffAtcNavAidsLayer2Pdu()
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
        public static bool operator !=(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right)
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
        public static bool operator ==(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right)
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

        public override int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize = base.GetMarshalledSize();
            marshalSize += this._layerHeader.GetMarshalledSize();  // this._layerHeader
            marshalSize += this._beamData.GetMarshalledSize();  // this._beamData
            marshalSize += this._secondaryOperationalData.GetMarshalledSize();  // this._secondaryOperationalData
            for (int idx = 0; idx < this._fundamentalIffParameters.Count; idx++)
            {
                FundamentalParameterDataIff listElement = (FundamentalParameterDataIff)this._fundamentalIffParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the layer header
        /// </summary>
        [XmlElement(Type = typeof(LayerHeader), ElementName = "layerHeader")]
        public LayerHeader LayerHeader
        {
            get
            {
                return this._layerHeader;
            }

            set
            {
                this._layerHeader = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam data
        /// </summary>
        [XmlElement(Type = typeof(BeamData), ElementName = "beamData")]
        public BeamData BeamData
        {
            get
            {
                return this._beamData;
            }

            set
            {
                this._beamData = value;
            }
        }

        /// <summary>
        /// Gets or sets the Secondary operational data, 5.2.57
        /// </summary>
        [XmlElement(Type = typeof(BeamData), ElementName = "secondaryOperationalData")]
        public BeamData SecondaryOperationalData
        {
            get
            {
                return this._secondaryOperationalData;
            }

            set
            {
                this._secondaryOperationalData = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of fundamental parameters. ^^^This is wrong
        /// </summary>
        [XmlElement(ElementName = "fundamentalIffParametersList", Type = typeof(List<FundamentalParameterDataIff>))]
        public List<FundamentalParameterDataIff> FundamentalIffParameters
        {
            get
            {
                return this._fundamentalIffParameters;
            }
        }

        /// <summary>
        /// Automatically sets the length of the marshalled data, then calls the marshal method.
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            this.Length = (ushort)this.GetMarshalledSize();
            this.Marshal(dos);
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    this._layerHeader.Marshal(dos);
                    this._beamData.Marshal(dos);
                    this._secondaryOperationalData.Marshal(dos);

                    for (int idx = 0; idx < this._fundamentalIffParameters.Count; idx++)
                    {
                        FundamentalParameterDataIff aFundamentalParameterDataIff = (FundamentalParameterDataIff)this._fundamentalIffParameters[idx];
                        aFundamentalParameterDataIff.Marshal(dos);
                    }
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
        public override void Unmarshal(DataInputStream dis)
        {
            base.Unmarshal(dis);

            if (dis != null)
            {
                try
                {
                    this._layerHeader.Unmarshal(dis);
                    this._beamData.Unmarshal(dis);
                    this._secondaryOperationalData.Unmarshal(dis);

                    for (int idx = 0; idx < this.Pad2; idx++)
                    {
                        FundamentalParameterDataIff anX = new FundamentalParameterDataIff();
                        anX.Unmarshal(dis);
                        this._fundamentalIffParameters.Add(anX);
                    }
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
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<IffAtcNavAidsLayer2Pdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<layerHeader>");
                this._layerHeader.Reflection(sb);
                sb.AppendLine("</layerHeader>");
                sb.AppendLine("<beamData>");
                this._beamData.Reflection(sb);
                sb.AppendLine("</beamData>");
                sb.AppendLine("<secondaryOperationalData>");
                this._secondaryOperationalData.Reflection(sb);
                sb.AppendLine("</secondaryOperationalData>");
                for (int idx = 0; idx < this._fundamentalIffParameters.Count; idx++)
                {
                    sb.AppendLine("<fundamentalIffParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FundamentalParameterDataIff\">");
                    FundamentalParameterDataIff aFundamentalParameterDataIff = (FundamentalParameterDataIff)this._fundamentalIffParameters[idx];
                    aFundamentalParameterDataIff.Reflection(sb);
                    sb.AppendLine("</fundamentalIffParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IffAtcNavAidsLayer2Pdu>");
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
            return this == obj as IffAtcNavAidsLayer2Pdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IffAtcNavAidsLayer2Pdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._layerHeader.Equals(obj._layerHeader))
            {
                ivarsEqual = false;
            }

            if (!this._beamData.Equals(obj._beamData))
            {
                ivarsEqual = false;
            }

            if (!this._secondaryOperationalData.Equals(obj._secondaryOperationalData))
            {
                ivarsEqual = false;
            }

            if (this._fundamentalIffParameters.Count != obj._fundamentalIffParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._fundamentalIffParameters.Count; idx++)
                {
                    if (!this._fundamentalIffParameters[idx].Equals(obj._fundamentalIffParameters[idx]))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ this._layerHeader.GetHashCode();
            result = GenerateHash(result) ^ this._beamData.GetHashCode();
            result = GenerateHash(result) ^ this._secondaryOperationalData.GetHashCode();

            if (this._fundamentalIffParameters.Count > 0)
            {
                for (int idx = 0; idx < this._fundamentalIffParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._fundamentalIffParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
