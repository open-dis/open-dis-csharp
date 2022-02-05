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
    /// Section 5.3.7.4.2 When present, layer 2 should follow layer 1 and have the following fields. This requires manual
    /// cleanup.       the beamData attribute semantics are used in multiple ways. UNFINSISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(LayerHeader))]
    [XmlInclude(typeof(BeamData))]
    [XmlInclude(typeof(FundamentalParameterDataIff))]
    public partial class IffAtcNavAidsLayer2Pdu : IffAtcNavAidsLayer1Pdu, IEquatable<IffAtcNavAidsLayer2Pdu>
    {
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
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += LayerHeader.GetMarshalledSize();  // this._layerHeader
            marshalSize += BeamData.GetMarshalledSize();  // this._beamData
            marshalSize += SecondaryOperationalData.GetMarshalledSize();  // this._secondaryOperationalData
            for (int idx = 0; idx < FundamentalIffParameters.Count; idx++)
            {
                var listElement = FundamentalIffParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the layer header
        /// </summary>
        [XmlElement(Type = typeof(LayerHeader), ElementName = "layerHeader")]
        public LayerHeader LayerHeader { get; set; } = new LayerHeader();

        /// <summary>
        /// Gets or sets the beam data
        /// </summary>
        [XmlElement(Type = typeof(BeamData), ElementName = "beamData")]
        public BeamData BeamData { get; set; } = new BeamData();

        /// <summary>
        /// Gets or sets the Secondary operational data, 5.2.57
        /// </summary>
        [XmlElement(Type = typeof(BeamData), ElementName = "secondaryOperationalData")]
        public BeamData SecondaryOperationalData { get; set; } = new BeamData();

        /// <summary>
        /// Gets the variable length list of fundamental parameters. ^^^This is wrong
        /// </summary>
        [XmlElement(ElementName = "fundamentalIffParametersList", Type = typeof(List<FundamentalParameterDataIff>))]
        public List<FundamentalParameterDataIff> FundamentalIffParameters { get; } = new();

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    LayerHeader.Marshal(dos);
                    BeamData.Marshal(dos);
                    SecondaryOperationalData.Marshal(dos);

                    for (int idx = 0; idx < FundamentalIffParameters.Count; idx++)
                    {
                        var aFundamentalParameterDataIff = FundamentalIffParameters[idx];
                        aFundamentalParameterDataIff.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
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
                    LayerHeader.Unmarshal(dis);
                    BeamData.Unmarshal(dis);
                    SecondaryOperationalData.Unmarshal(dis);

                    for (int idx = 0; idx < Pad2; idx++)
                    {
                        var anX = new FundamentalParameterDataIff();
                        anX.Unmarshal(dis);
                        FundamentalIffParameters.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<IffAtcNavAidsLayer2Pdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<layerHeader>");
                LayerHeader.Reflection(sb);
                sb.AppendLine("</layerHeader>");
                sb.AppendLine("<beamData>");
                BeamData.Reflection(sb);
                sb.AppendLine("</beamData>");
                sb.AppendLine("<secondaryOperationalData>");
                SecondaryOperationalData.Reflection(sb);
                sb.AppendLine("</secondaryOperationalData>");
                for (int idx = 0; idx < FundamentalIffParameters.Count; idx++)
                {
                    sb.AppendLine("<fundamentalIffParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"FundamentalParameterDataIff\">");
                    var aFundamentalParameterDataIff = FundamentalIffParameters[idx];
                    aFundamentalParameterDataIff.Reflection(sb);
                    sb.AppendLine("</fundamentalIffParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IffAtcNavAidsLayer2Pdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as IffAtcNavAidsLayer2Pdu;

        ///<inheritdoc/>
        public bool Equals(IffAtcNavAidsLayer2Pdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!LayerHeader.Equals(obj.LayerHeader))
            {
                ivarsEqual = false;
            }

            if (!BeamData.Equals(obj.BeamData))
            {
                ivarsEqual = false;
            }

            if (!SecondaryOperationalData.Equals(obj.SecondaryOperationalData))
            {
                ivarsEqual = false;
            }

            if (FundamentalIffParameters.Count != obj.FundamentalIffParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < FundamentalIffParameters.Count; idx++)
                {
                    if (!FundamentalIffParameters[idx].Equals(obj.FundamentalIffParameters[idx]))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ LayerHeader.GetHashCode();
            result = GenerateHash(result) ^ BeamData.GetHashCode();
            result = GenerateHash(result) ^ SecondaryOperationalData.GetHashCode();

            if (FundamentalIffParameters.Count > 0)
            {
                for (int idx = 0; idx < FundamentalIffParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ FundamentalIffParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
