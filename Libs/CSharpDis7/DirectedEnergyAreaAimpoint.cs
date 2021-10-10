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
    /// DE Precision Aimpoint Record. NOT COMPLETE. Section 6.2.21.2
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(BeamAntennaPattern))]
    [XmlInclude(typeof(DirectedEnergyTargetEnergyDeposition))]
    public partial class DirectedEnergyAreaAimpoint
    {
        /// <summary>
        /// Type of Record
        /// </summary>
        private uint _recordType = 4001;

        /// <summary>
        /// Length of Record
        /// </summary>
        private ushort _recordLength;

        /// <summary>
        /// Padding
        /// </summary>
        private ushort _padding;

        /// <summary>
        /// Number of beam antenna pattern records
        /// </summary>
        private ushort _beamAntennaPatternRecordCount;

        /// <summary>
        /// Number of DE target energy depositon records
        /// </summary>
        private ushort _directedEnergyTargetEnergyDepositionRecordCount;

        /// <summary>
        /// list of beam antenna records. See 6.2.9.2
        /// </summary>
        private List<BeamAntennaPattern> _beamAntennaParameterList = new List<BeamAntennaPattern>();

        /// <summary>
        /// list of DE target deposition records. See 6.2.21.4
        /// </summary>
        private List<DirectedEnergyTargetEnergyDeposition> _directedEnergyTargetEnergyDepositionRecordList = new List<DirectedEnergyTargetEnergyDeposition>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEnergyAreaAimpoint"/> class.
        /// </summary>
        public DirectedEnergyAreaAimpoint()
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
        public static bool operator !=(DirectedEnergyAreaAimpoint left, DirectedEnergyAreaAimpoint right)
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
        public static bool operator ==(DirectedEnergyAreaAimpoint left, DirectedEnergyAreaAimpoint right)
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

            marshalSize += 4;  // this._recordType
            marshalSize += 2;  // this._recordLength
            marshalSize += 2;  // this._padding
            marshalSize += 2;  // this._beamAntennaPatternRecordCount
            marshalSize += 2;  // this._directedEnergyTargetEnergyDepositionRecordCount
            for (int idx = 0; idx < this._beamAntennaParameterList.Count; idx++)
            {
                BeamAntennaPattern listElement = (BeamAntennaPattern)this._beamAntennaParameterList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            for (int idx = 0; idx < this._directedEnergyTargetEnergyDepositionRecordList.Count; idx++)
            {
                DirectedEnergyTargetEnergyDeposition listElement = (DirectedEnergyTargetEnergyDeposition)this._directedEnergyTargetEnergyDepositionRecordList[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Type of Record
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "recordType")]
        public uint RecordType
        {
            get
            {
                return this._recordType;
            }

            set
            {
                this._recordType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Length of Record
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
        public ushort RecordLength
        {
            get
            {
                return this._recordLength;
            }

            set
            {
                this._recordLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the Padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "padding")]
        public ushort Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getbeamAntennaPatternRecordCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "beamAntennaPatternRecordCount")]
        public ushort BeamAntennaPatternRecordCount
        {
            get
            {
                return this._beamAntennaPatternRecordCount;
            }

            set
            {
                this._beamAntennaPatternRecordCount = value;
            }
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getdirectedEnergyTargetEnergyDepositionRecordCount method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "directedEnergyTargetEnergyDepositionRecordCount")]
        public ushort DirectedEnergyTargetEnergyDepositionRecordCount
        {
            get
            {
                return this._directedEnergyTargetEnergyDepositionRecordCount;
            }

            set
            {
                this._directedEnergyTargetEnergyDepositionRecordCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of beam antenna records. See 6.2.9.2
        /// </summary>
        [XmlElement(ElementName = "beamAntennaParameterListList", Type = typeof(List<BeamAntennaPattern>))]
        public List<BeamAntennaPattern> BeamAntennaParameterList
        {
            get
            {
                return this._beamAntennaParameterList;
            }
        }

        /// <summary>
        /// Gets or sets the list of DE target deposition records. See 6.2.21.4
        /// </summary>
        [XmlElement(ElementName = "directedEnergyTargetEnergyDepositionRecordListList", Type = typeof(List<DirectedEnergyTargetEnergyDeposition>))]
        public List<DirectedEnergyTargetEnergyDeposition> DirectedEnergyTargetEnergyDepositionRecordList
        {
            get
            {
                return this._directedEnergyTargetEnergyDepositionRecordList;
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
                    dos.WriteUnsignedInt((uint)this._recordType);
                    dos.WriteUnsignedShort((ushort)this._recordLength);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    dos.WriteUnsignedShort((ushort)this._beamAntennaParameterList.Count);
                    dos.WriteUnsignedShort((ushort)this._directedEnergyTargetEnergyDepositionRecordList.Count);

                    for (int idx = 0; idx < this._beamAntennaParameterList.Count; idx++)
                    {
                        BeamAntennaPattern aBeamAntennaPattern = (BeamAntennaPattern)this._beamAntennaParameterList[idx];
                        aBeamAntennaPattern.Marshal(dos);
                    }

                    for (int idx = 0; idx < this._directedEnergyTargetEnergyDepositionRecordList.Count; idx++)
                    {
                        DirectedEnergyTargetEnergyDeposition aDirectedEnergyTargetEnergyDeposition = (DirectedEnergyTargetEnergyDeposition)this._directedEnergyTargetEnergyDepositionRecordList[idx];
                        aDirectedEnergyTargetEnergyDeposition.Marshal(dos);
                    }
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
                    this._recordType = dis.ReadUnsignedInt();
                    this._recordLength = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
                    this._beamAntennaPatternRecordCount = dis.ReadUnsignedShort();
                    this._directedEnergyTargetEnergyDepositionRecordCount = dis.ReadUnsignedShort();
                    for (int idx = 0; idx < this.BeamAntennaPatternRecordCount; idx++)
                    {
                        BeamAntennaPattern anX = new BeamAntennaPattern();
                        anX.Unmarshal(dis);
                        this._beamAntennaParameterList.Add(anX);
                    };

                    for (int idx = 0; idx < this.DirectedEnergyTargetEnergyDepositionRecordCount; idx++)
                    {
                        DirectedEnergyTargetEnergyDeposition anX = new DirectedEnergyTargetEnergyDeposition();
                        anX.Unmarshal(dis);
                        this._directedEnergyTargetEnergyDepositionRecordList.Add(anX);
                    };

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
            sb.AppendLine("<DirectedEnergyAreaAimpoint>");
            try
            {
                sb.AppendLine("<recordType type=\"uint\">" + this._recordType.ToString(CultureInfo.InvariantCulture) + "</recordType>");
                sb.AppendLine("<recordLength type=\"ushort\">" + this._recordLength.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<beamAntennaParameterList type=\"ushort\">" + this._beamAntennaParameterList.Count.ToString(CultureInfo.InvariantCulture) + "</beamAntennaParameterList>");
                sb.AppendLine("<directedEnergyTargetEnergyDepositionRecordList type=\"ushort\">" + this._directedEnergyTargetEnergyDepositionRecordList.Count.ToString(CultureInfo.InvariantCulture) + "</directedEnergyTargetEnergyDepositionRecordList>");
                for (int idx = 0; idx < this._beamAntennaParameterList.Count; idx++)
                {
                    sb.AppendLine("<beamAntennaParameterList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"BeamAntennaPattern\">");
                    BeamAntennaPattern aBeamAntennaPattern = (BeamAntennaPattern)this._beamAntennaParameterList[idx];
                    aBeamAntennaPattern.Reflection(sb);
                    sb.AppendLine("</beamAntennaParameterList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                for (int idx = 0; idx < this._directedEnergyTargetEnergyDepositionRecordList.Count; idx++)
                {
                    sb.AppendLine("<directedEnergyTargetEnergyDepositionRecordList" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"DirectedEnergyTargetEnergyDeposition\">");
                    DirectedEnergyTargetEnergyDeposition aDirectedEnergyTargetEnergyDeposition = (DirectedEnergyTargetEnergyDeposition)this._directedEnergyTargetEnergyDepositionRecordList[idx];
                    aDirectedEnergyTargetEnergyDeposition.Reflection(sb);
                    sb.AppendLine("</directedEnergyTargetEnergyDepositionRecordList" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</DirectedEnergyAreaAimpoint>");
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
            return this == obj as DirectedEnergyAreaAimpoint;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DirectedEnergyAreaAimpoint obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._recordType != obj._recordType)
            {
                ivarsEqual = false;
            }

            if (this._recordLength != obj._recordLength)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (this._beamAntennaPatternRecordCount != obj._beamAntennaPatternRecordCount)
            {
                ivarsEqual = false;
            }

            if (this._directedEnergyTargetEnergyDepositionRecordCount != obj._directedEnergyTargetEnergyDepositionRecordCount)
            {
                ivarsEqual = false;
            }

            if (this._beamAntennaParameterList.Count != obj._beamAntennaParameterList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._beamAntennaParameterList.Count; idx++)
                {
                    if (!this._beamAntennaParameterList[idx].Equals(obj._beamAntennaParameterList[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._directedEnergyTargetEnergyDepositionRecordList.Count != obj._directedEnergyTargetEnergyDepositionRecordList.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._directedEnergyTargetEnergyDepositionRecordList.Count; idx++)
                {
                    if (!this._directedEnergyTargetEnergyDepositionRecordList[idx].Equals(obj._directedEnergyTargetEnergyDepositionRecordList[idx]))
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

            result = GenerateHash(result) ^ this._recordType.GetHashCode();
            result = GenerateHash(result) ^ this._recordLength.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._beamAntennaPatternRecordCount.GetHashCode();
            result = GenerateHash(result) ^ this._directedEnergyTargetEnergyDepositionRecordCount.GetHashCode();

            if (this._beamAntennaParameterList.Count > 0)
            {
                for (int idx = 0; idx < this._beamAntennaParameterList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._beamAntennaParameterList[idx].GetHashCode();
                }
            }

            if (this._directedEnergyTargetEnergyDepositionRecordList.Count > 0)
            {
                for (int idx = 0; idx < this._directedEnergyTargetEnergyDepositionRecordList.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._directedEnergyTargetEnergyDepositionRecordList[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
