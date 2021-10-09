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
        /// Originating entity ID
        /// </summary>
        private EntityID _orginatingEntityID = new EntityID();

        /// <summary>
        /// IR Signature representation index
        /// </summary>
        private ushort _infraredSignatureRepresentationIndex;

        /// <summary>
        /// acoustic Signature representation index
        /// </summary>
        private ushort _acousticSignatureRepresentationIndex;

        /// <summary>
        /// radar cross section representation index
        /// </summary>
        private ushort _radarCrossSectionSignatureRepresentationIndex;

        /// <summary>
        /// how many propulsion systems
        /// </summary>
        private ushort _numberOfPropulsionSystems;

        /// <summary>
        /// how many vectoring nozzle systems
        /// </summary>
        private ushort _numberOfVectoringNozzleSystems;

        /// <summary>
        /// variable length list of propulsion system data
        /// </summary>
        private List<PropulsionSystemData> _propulsionSystemData = new List<PropulsionSystemData>();

        /// <summary>
        /// variable length list of vectoring system data
        /// </summary>
        private List<VectoringNozzleSystemData> _vectoringSystemData = new List<VectoringNozzleSystemData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SeesPdu"/> class.
        /// </summary>
        public SeesPdu()
        {
            PduType = (byte)30;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SeesPdu left, SeesPdu right)
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
        public static bool operator ==(SeesPdu left, SeesPdu right)
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
            marshalSize += this._orginatingEntityID.GetMarshalledSize();  // this._orginatingEntityID
            marshalSize += 2;  // this._infraredSignatureRepresentationIndex
            marshalSize += 2;  // this._acousticSignatureRepresentationIndex
            marshalSize += 2;  // this._radarCrossSectionSignatureRepresentationIndex
            marshalSize += 2;  // this._numberOfPropulsionSystems
            marshalSize += 2;  // this._numberOfVectoringNozzleSystems
            for (int idx = 0; idx < this._propulsionSystemData.Count; idx++)
            {
                PropulsionSystemData listElement = (PropulsionSystemData)this._propulsionSystemData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._vectoringSystemData.Count; idx++)
            {
                VectoringNozzleSystemData listElement = (VectoringNozzleSystemData)this._vectoringSystemData[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Originating entity ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
        public EntityID OrginatingEntityID
        {
            get
            {
                return this._orginatingEntityID;
            }

            set
            {
                this._orginatingEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the IR Signature representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "infraredSignatureRepresentationIndex")]
        public ushort InfraredSignatureRepresentationIndex
        {
            get
            {
                return this._infraredSignatureRepresentationIndex;
            }

            set
            {
                this._infraredSignatureRepresentationIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the acoustic Signature representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "acousticSignatureRepresentationIndex")]
        public ushort AcousticSignatureRepresentationIndex
        {
            get
            {
                return this._acousticSignatureRepresentationIndex;
            }

            set
            {
                this._acousticSignatureRepresentationIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the radar cross section representation index
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "radarCrossSectionSignatureRepresentationIndex")]
        public ushort RadarCrossSectionSignatureRepresentationIndex
        {
            get
            {
                return this._radarCrossSectionSignatureRepresentationIndex;
            }

            set
            {
                this._radarCrossSectionSignatureRepresentationIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many propulsion systems
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPropulsionSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfPropulsionSystems")]
        public ushort NumberOfPropulsionSystems
        {
            get
            {
                return this._numberOfPropulsionSystems;
            }

            set
            {
                this._numberOfPropulsionSystems = value;
            }
        }

        /// <summary>
        /// Gets or sets the how many vectoring nozzle systems
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfVectoringNozzleSystems method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfVectoringNozzleSystems")]
        public ushort NumberOfVectoringNozzleSystems
        {
            get
            {
                return this._numberOfVectoringNozzleSystems;
            }

            set
            {
                this._numberOfVectoringNozzleSystems = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of propulsion system data
        /// </summary>
        [XmlElement(ElementName = "propulsionSystemDataList", Type = typeof(List<PropulsionSystemData>))]
        public List<PropulsionSystemData> PropulsionSystemData
        {
            get
            {
                return this._propulsionSystemData;
            }
        }

        /// <summary>
        /// Gets the variable length list of vectoring system data
        /// </summary>
        [XmlElement(ElementName = "vectoringSystemDataList", Type = typeof(List<VectoringNozzleSystemData>))]
        public List<VectoringNozzleSystemData> VectoringSystemData
        {
            get
            {
                return this._vectoringSystemData;
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
                    this._orginatingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._infraredSignatureRepresentationIndex);
                    dos.WriteUnsignedShort((ushort)this._acousticSignatureRepresentationIndex);
                    dos.WriteUnsignedShort((ushort)this._radarCrossSectionSignatureRepresentationIndex);
                    dos.WriteUnsignedShort((ushort)this._propulsionSystemData.Count);
                    dos.WriteUnsignedShort((ushort)this._vectoringSystemData.Count);

                    for (int idx = 0; idx < this._propulsionSystemData.Count; idx++)
                    {
                        PropulsionSystemData aPropulsionSystemData = (PropulsionSystemData)this._propulsionSystemData[idx];
                        aPropulsionSystemData.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._vectoringSystemData.Count; idx++)
                    {
                        VectoringNozzleSystemData aVectoringNozzleSystemData = (VectoringNozzleSystemData)this._vectoringSystemData[idx];
                        aVectoringNozzleSystemData.Marshal(dos);
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
                    this._orginatingEntityID.Unmarshal(dis);
                    this._infraredSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    this._acousticSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    this._radarCrossSectionSignatureRepresentationIndex = dis.ReadUnsignedShort();
                    this._numberOfPropulsionSystems = dis.ReadUnsignedShort();
                    this._numberOfVectoringNozzleSystems = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfPropulsionSystems; idx++)
                    {
                        PropulsionSystemData anX = new PropulsionSystemData();
                        anX.Unmarshal(dis);
                        this._propulsionSystemData.Add(anX);
                    }

                    for (int idx = 0; idx < this.NumberOfVectoringNozzleSystems; idx++)
                    {
                        VectoringNozzleSystemData anX = new VectoringNozzleSystemData();
                        anX.Unmarshal(dis);
                        this._vectoringSystemData.Add(anX);
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
            sb.AppendLine("<SeesPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<orginatingEntityID>");
                this._orginatingEntityID.Reflection(sb);
                sb.AppendLine("</orginatingEntityID>");
                sb.AppendLine("<infraredSignatureRepresentationIndex type=\"ushort\">" + this._infraredSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</infraredSignatureRepresentationIndex>");
                sb.AppendLine("<acousticSignatureRepresentationIndex type=\"ushort\">" + this._acousticSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</acousticSignatureRepresentationIndex>");
                sb.AppendLine("<radarCrossSectionSignatureRepresentationIndex type=\"ushort\">" + this._radarCrossSectionSignatureRepresentationIndex.ToString(CultureInfo.InvariantCulture) + "</radarCrossSectionSignatureRepresentationIndex>");
                sb.AppendLine("<propulsionSystemData type=\"ushort\">" + this._propulsionSystemData.Count.ToString(CultureInfo.InvariantCulture) + "</propulsionSystemData>");
                sb.AppendLine("<vectoringSystemData type=\"ushort\">" + this._vectoringSystemData.Count.ToString(CultureInfo.InvariantCulture) + "</vectoringSystemData>");
                for (int idx = 0; idx < this._propulsionSystemData.Count; idx++)
                {
                    sb.AppendLine("<propulsionSystemData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"PropulsionSystemData\">");
                    PropulsionSystemData aPropulsionSystemData = (PropulsionSystemData)this._propulsionSystemData[idx];
                    aPropulsionSystemData.Reflection(sb);
                    sb.AppendLine("</propulsionSystemData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._vectoringSystemData.Count; idx++)
                {
                    sb.AppendLine("<vectoringSystemData" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VectoringNozzleSystemData\">");
                    VectoringNozzleSystemData aVectoringNozzleSystemData = (VectoringNozzleSystemData)this._vectoringSystemData[idx];
                    aVectoringNozzleSystemData.Reflection(sb);
                    sb.AppendLine("</vectoringSystemData" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</SeesPdu>");
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
            return this == obj as SeesPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SeesPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._orginatingEntityID.Equals(obj._orginatingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._infraredSignatureRepresentationIndex != obj._infraredSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (this._acousticSignatureRepresentationIndex != obj._acousticSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (this._radarCrossSectionSignatureRepresentationIndex != obj._radarCrossSectionSignatureRepresentationIndex)
            {
                ivarsEqual = false;
            }

            if (this._numberOfPropulsionSystems != obj._numberOfPropulsionSystems)
            {
                ivarsEqual = false;
            }

            if (this._numberOfVectoringNozzleSystems != obj._numberOfVectoringNozzleSystems)
            {
                ivarsEqual = false;
            }

            if (this._propulsionSystemData.Count != obj._propulsionSystemData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._propulsionSystemData.Count; idx++)
                {
                    if (!this._propulsionSystemData[idx].Equals(obj._propulsionSystemData[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._vectoringSystemData.Count != obj._vectoringSystemData.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._vectoringSystemData.Count; idx++)
                {
                    if (!this._vectoringSystemData[idx].Equals(obj._vectoringSystemData[idx]))
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

            result = GenerateHash(result) ^ this._orginatingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._infraredSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ this._acousticSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ this._radarCrossSectionSignatureRepresentationIndex.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfPropulsionSystems.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfVectoringNozzleSystems.GetHashCode();

            if (this._propulsionSystemData.Count > 0)
            {
                for (int idx = 0; idx < this._propulsionSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._propulsionSystemData[idx].GetHashCode();
                }
            }

            if (this._vectoringSystemData.Count > 0)
            {
                for (int idx = 0; idx < this._vectoringSystemData.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._vectoringSystemData[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
