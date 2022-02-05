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
    /// Section 5.3.7.5. SEES PDU, supplemental emissions entity state information. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(PropulsionSystemData))]
    [XmlInclude(typeof(VectoringNozzleSystemData))]
    public partial class SeesPdu : DistributedEmissionsFamilyPdu, IEquatable<SeesPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeesPdu"/> class.
        /// </summary>
        public SeesPdu()
        {
            PduType = 30;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SeesPdu left, SeesPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(SeesPdu left, SeesPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += OrginatingEntityID.GetMarshalledSize();  // this._orginatingEntityID
            marshalSize += 2;  // this._infraredSignatureRepresentationIndex
            marshalSize += 2;  // this._acousticSignatureRepresentationIndex
            marshalSize += 2;  // this._radarCrossSectionSignatureRepresentationIndex
            marshalSize += 2;  // this._numberOfPropulsionSystems
            marshalSize += 2;  // this._numberOfVectoringNozzleSystems
            for (int idx = 0; idx < PropulsionSystemData.Count; idx++)
            {
                var listElement = PropulsionSystemData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < VectoringSystemData.Count; idx++)
            {
                var listElement = VectoringSystemData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Originating entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
        public EntityID OrginatingEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the IR Signature representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "infraredSignatureRepresentationIndex")]
        public ushort InfraredSignatureRepresentationIndex { get; set; }

        /// <summary>
        /// Gets or sets the acoustic Signature representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "acousticSignatureRepresentationIndex")]
        public ushort AcousticSignatureRepresentationIndex { get; set; }

        /// <summary>
        /// Gets or sets the radar cross section representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "radarCrossSectionSignatureRepresentationIndex")]
        public ushort RadarCrossSectionSignatureRepresentationIndex { get; set; }

        /// <summary>
        /// Gets or sets the how many propulsion systems
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfPropulsionSystems method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfPropulsionSystems")]
        public ushort NumberOfPropulsionSystems { get; set; }

        /// <summary>
        /// Gets or sets the how many vectoring nozzle systems
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfVectoringNozzleSystems method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfVectoringNozzleSystems")]
        public ushort NumberOfVectoringNozzleSystems { get; set; }

        /// <summary>
        /// Gets the variable length list of propulsion system data
        /// </summary>
        [XmlElement(ElementName = "propulsionSystemDataList", Type = typeof(List<PropulsionSystemData>))]
        public List<PropulsionSystemData> PropulsionSystemData { get; } = new();

        /// <summary>
        /// Gets the variable length list of vectoring system data
        /// </summary>
        [XmlElement(ElementName = "vectoringSystemDataList", Type = typeof(List<VectoringNozzleSystemData>))]
        public List<VectoringNozzleSystemData> VectoringSystemData { get; } = new();

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
                    OrginatingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort(InfraredSignatureRepresentationIndex);
                    dos.WriteUnsignedShort(AcousticSignatureRepresentationIndex);
                    dos.WriteUnsignedShort(RadarCrossSectionSignatureRepresentationIndex);
                    dos.WriteUnsignedShort((ushort)PropulsionSystemData.Count);
                    dos.WriteUnsignedShort((ushort)VectoringSystemData.Count);

                    for (int idx = 0; idx < PropulsionSystemData.Count; idx++)
                    {
                        var aPropulsionSystemData = PropulsionSystemData[idx];
                        aPropulsionSystemData.Marshal(dos);
                    }

                    for (int idx = 0; idx < VectoringSystemData.Count; idx++)
                    {
                        var aVectoringNozzleSystemData = VectoringSystemData[idx];
                        aVectoringNozzleSystemData.Marshal(dos);
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
                    OrginatingEntityID.Unmarshal(dis);
                    InfraredSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    AcousticSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    RadarCrossSectionSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    NumberOfPropulsionSystems = dis.ReadUnsignedShort();
                    NumberOfVectoringNozzleSystems = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < NumberOfPropulsionSystems; idx++)
                    {
                        var anX = new PropulsionSystemData();
                        anX.Unmarshal(dis);
                        PropulsionSystemData.Add(anX);
                    }

                    for (int idx = 0; idx < NumberOfVectoringNozzleSystems; idx++)
                    {
                        var anX = new VectoringNozzleSystemData();
                        anX.Unmarshal(dis);
                        VectoringSystemData.Add(anX);
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
            sb.AppendLine("<SeesPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                OrginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<infraredSignatureRepresentationIndex type=\"ushort\">" + InfraredSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</infraredSignatureRepresentationIndex>");
                sb.AppendLine("<acousticSignatureRepresentationIndex type=\"ushort\">" + AcousticSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</acousticSignatureRepresentationIndex>");
                sb.AppendLine("<radarCrossSectionSignatureRepresentationIndex type=\"ushort\">" + RadarCrossSectionSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</radarCrossSectionSignatureRepresentationIndex>");
                sb.AppendLine("<propulsionSystemData type=\"ushort\">" + PropulsionSystemData.Count.ToString(CultureInfo.InvariantCulture) + "</propulsionSystemData>");
                sb.AppendLine("<vectoringSystemData type=\"ushort\">" + VectoringSystemData.Count.ToString(CultureInfo.InvariantCulture) + "</vectoringSystemData>");
                for (int idx = 0; idx < PropulsionSystemData.Count; idx++)
                {
                    sb.AppendLine("<propulsionSystemData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"PropulsionSystemData\">");
                    var aPropulsionSystemData = PropulsionSystemData[idx];
                    aPropulsionSystemData.Reflection(sb);
                    sb.AppendLine("</propulsionSystemData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < VectoringSystemData.Count; idx++)
                {
                    sb.AppendLine("<vectoringSystemData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VectoringNozzleSystemData\">");
                    var aVectoringNozzleSystemData = VectoringSystemData[idx];
                    aVectoringNozzleSystemData.Reflection(sb);
                    sb.AppendLine("</vectoringSystemData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</SeesPdu>");
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
        public override bool Equals(object obj) => this == obj as SeesPdu;

        ///<inheritdoc/>
        public bool Equals(SeesPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!OrginatingEntityID.Equals(obj.OrginatingEntityID))
            {
                ivarsEqual = false;
            }

            if (InfraredSignatureRepresentationIndex != obj.InfraredSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (AcousticSignatureRepresentationIndex != obj.AcousticSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (RadarCrossSectionSignatureRepresentationIndex != obj.RadarCrossSectionSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (NumberOfPropulsionSystems != obj.NumberOfPropulsionSystems)
            {
                ivarsEqual = false;
            }

            if (NumberOfVectoringNozzleSystems != obj.NumberOfVectoringNozzleSystems)
            {
                ivarsEqual = false;
            }

            if (PropulsionSystemData.Count != obj.PropulsionSystemData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < PropulsionSystemData.Count; idx++)
                {
                    if (!PropulsionSystemData[idx].Equals(obj.PropulsionSystemData[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (VectoringSystemData.Count != obj.VectoringSystemData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < VectoringSystemData.Count; idx++)
                {
                    if (!VectoringSystemData[idx].Equals(obj.VectoringSystemData[idx]))
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

            result = GenerateHash(result) ^ OrginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ InfraredSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ AcousticSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ RadarCrossSectionSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ NumberOfPropulsionSystems.GetHashCode();
            result = GenerateHash(result) ^ NumberOfVectoringNozzleSystems.GetHashCode();

            if (PropulsionSystemData.Count > 0)
            {
                for (int idx = 0; idx < PropulsionSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ PropulsionSystemData[idx].GetHashCode();
                }
            }

            if (VectoringSystemData.Count > 0)
            {
                for (int idx = 0; idx < VectoringSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ VectoringSystemData[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
