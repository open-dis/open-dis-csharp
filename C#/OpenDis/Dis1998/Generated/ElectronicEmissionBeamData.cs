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
    /// Description of one electronic emission beam
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(FundamentalParameterData))]
    [XmlInclude(typeof(TrackJamTarget))]
    public partial class ElectronicEmissionBeamData
    {
        /// <summary>
        /// This field shall specify the length of this beams data in 32 bit words
        /// </summary>
        private byte _beamDataLength;

        /// <summary>
        /// This field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system.
        /// </summary>
        private byte _beamIDNumber;

        /// <summary>
        /// This field shall specify a Beam Parameter Index number that shall be used by receiving entities in conjunction with the Emitter Name field to provide a pointer to the stored database parameters required to regenerate the beam. 
        /// </summary>
        private ushort _beamParameterIndex;

        /// <summary>
        /// Fundamental parameter data such as frequency range, beam sweep, etc.
        /// </summary>
        private FundamentalParameterData _fundamentalParameterData = new FundamentalParameterData();

        /// <summary>
        /// beam function of a particular beam
        /// </summary>
        private byte _beamFunction;

        /// <summary>
        /// Number of track/jam targets
        /// </summary>
        private byte _numberOfTrackJamTargets;

        /// <summary>
        /// wheher or not the receiving simulation apps can assume all the targets in the scan pattern are being tracked/jammed
        /// </summary>
        private byte _highDensityTrackJam;

        /// <summary>
        /// padding
        /// </summary>
        private byte _pad4;

        /// <summary>
        /// identify jamming techniques used
        /// </summary>
        private uint _jammingModeSequence;

        /// <summary>
        /// variable length list of track/jam targets
        /// </summary>
        private List<TrackJamTarget> _trackJamTargets = new List<TrackJamTarget>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicEmissionBeamData"/> class.
        /// </summary>
        public ElectronicEmissionBeamData()
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
        public static bool operator !=(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right)
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
        public static bool operator ==(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right)
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

            marshalSize += 1;  // this._beamDataLength
            marshalSize += 1;  // this._beamIDNumber
            marshalSize += 2;  // this._beamParameterIndex
            marshalSize += this._fundamentalParameterData.GetMarshalledSize();  // this._fundamentalParameterData
            marshalSize += 1;  // this._beamFunction
            marshalSize += 1;  // this._numberOfTrackJamTargets
            marshalSize += 1;  // this._highDensityTrackJam
            marshalSize += 1;  // this._pad4
            marshalSize += 4;  // this._jammingModeSequence
            for (int idx = 0; idx < this._trackJamTargets.Count; idx++)
            {
                TrackJamTarget listElement = (TrackJamTarget)this._trackJamTargets[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall specify the length of this beams data in 32 bit words
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
        public byte BeamDataLength
        {
            get
            {
                return this._beamDataLength;
            }

            set
            {
                this._beamDataLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
        public byte BeamIDNumber
        {
            get
            {
                return this._beamIDNumber;
            }

            set
            {
                this._beamIDNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify a Beam Parameter Index number that shall be used by receiving entities in conjunction with the Emitter Name field to provide a pointer to the stored database parameters required to regenerate the beam. 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
        public ushort BeamParameterIndex
        {
            get
            {
                return this._beamParameterIndex;
            }

            set
            {
                this._beamParameterIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the Fundamental parameter data such as frequency range, beam sweep, etc.
        /// </summary>
        [XmlElement(Type = typeof(FundamentalParameterData), ElementName = "fundamentalParameterData")]
        public FundamentalParameterData FundamentalParameterData
        {
            get
            {
                return this._fundamentalParameterData;
            }

            set
            {
                this._fundamentalParameterData = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam function of a particular beam
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamFunction")]
        public byte BeamFunction
        {
            get
            {
                return this._beamFunction;
            }

            set
            {
                this._beamFunction = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of track/jam targets
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfTrackJamTargets method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfTrackJamTargets")]
        public byte NumberOfTrackJamTargets
        {
            get
            {
                return this._numberOfTrackJamTargets;
            }

            set
            {
                this._numberOfTrackJamTargets = value;
            }
        }

        /// <summary>
        /// Gets or sets the wheher or not the receiving simulation apps can assume all the targets in the scan pattern are being tracked/jammed
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "highDensityTrackJam")]
        public byte HighDensityTrackJam
        {
            get
            {
                return this._highDensityTrackJam;
            }

            set
            {
                this._highDensityTrackJam = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "pad4")]
        public byte Pad4
        {
            get
            {
                return this._pad4;
            }

            set
            {
                this._pad4 = value;
            }
        }

        /// <summary>
        /// Gets or sets the identify jamming techniques used
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "jammingModeSequence")]
        public uint JammingModeSequence
        {
            get
            {
                return this._jammingModeSequence;
            }

            set
            {
                this._jammingModeSequence = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of track/jam targets
        /// </summary>
        [XmlElement(ElementName = "trackJamTargetsList", Type = typeof(List<TrackJamTarget>))]
        public List<TrackJamTarget> TrackJamTargets
        {
            get
            {
                return this._trackJamTargets;
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
                    dos.WriteUnsignedByte((byte)this._beamDataLength);
                    dos.WriteUnsignedByte((byte)this._beamIDNumber);
                    dos.WriteUnsignedShort((ushort)this._beamParameterIndex);
                    this._fundamentalParameterData.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._beamFunction);
                    dos.WriteUnsignedByte((byte)this._trackJamTargets.Count);
                    dos.WriteUnsignedByte((byte)this._highDensityTrackJam);
                    dos.WriteUnsignedByte((byte)this._pad4);
                    dos.WriteUnsignedInt((uint)this._jammingModeSequence);

                    for (int idx = 0; idx < this._trackJamTargets.Count; idx++)
                    {
                        TrackJamTarget aTrackJamTarget = (TrackJamTarget)this._trackJamTargets[idx];
                        aTrackJamTarget.Marshal(dos);
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
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    this._beamDataLength = dis.ReadUnsignedByte();
                    this._beamIDNumber = dis.ReadUnsignedByte();
                    this._beamParameterIndex = dis.ReadUnsignedShort();
                    this._fundamentalParameterData.Unmarshal(dis);
                    this._beamFunction = dis.ReadUnsignedByte();
                    this._numberOfTrackJamTargets = dis.ReadUnsignedByte();
                    this._highDensityTrackJam = dis.ReadUnsignedByte();
                    this._pad4 = dis.ReadUnsignedByte();
                    this._jammingModeSequence = dis.ReadUnsignedInt();

                    for (int idx = 0; idx < this.NumberOfTrackJamTargets; idx++)
                    {
                        TrackJamTarget anX = new TrackJamTarget();
                        anX.Unmarshal(dis);
                        this._trackJamTargets.Add(anX);
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
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<ElectronicEmissionBeamData>");
            try
            {
                sb.AppendLine("<beamDataLength type=\"byte\">" + this._beamDataLength.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
                sb.AppendLine("<beamIDNumber type=\"byte\">" + this._beamIDNumber.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
                sb.AppendLine("<beamParameterIndex type=\"ushort\">" + this._beamParameterIndex.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
                sb.AppendLine("<fundamentalParameterData>");
                this._fundamentalParameterData.Reflection(sb);
                sb.AppendLine("</fundamentalParameterData>");
                sb.AppendLine("<beamFunction type=\"byte\">" + this._beamFunction.ToString(CultureInfo.InvariantCulture) + "</beamFunction>");
                sb.AppendLine("<trackJamTargets type=\"byte\">" + this._trackJamTargets.Count.ToString(CultureInfo.InvariantCulture) + "</trackJamTargets>");
                sb.AppendLine("<highDensityTrackJam type=\"byte\">" + this._highDensityTrackJam.ToString(CultureInfo.InvariantCulture) + "</highDensityTrackJam>");
                sb.AppendLine("<pad4 type=\"byte\">" + this._pad4.ToString(CultureInfo.InvariantCulture) + "</pad4>");
                sb.AppendLine("<jammingModeSequence type=\"uint\">" + this._jammingModeSequence.ToString(CultureInfo.InvariantCulture) + "</jammingModeSequence>");
                for (int idx = 0; idx < this._trackJamTargets.Count; idx++)
                {
                    sb.AppendLine("<trackJamTargets" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"TrackJamTarget\">");
                    TrackJamTarget aTrackJamTarget = (TrackJamTarget)this._trackJamTargets[idx];
                    aTrackJamTarget.Reflection(sb);
                    sb.AppendLine("</trackJamTargets" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ElectronicEmissionBeamData>");
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
            return this == obj as ElectronicEmissionBeamData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ElectronicEmissionBeamData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._beamDataLength != obj._beamDataLength)
            {
                ivarsEqual = false;
            }

            if (this._beamIDNumber != obj._beamIDNumber)
            {
                ivarsEqual = false;
            }

            if (this._beamParameterIndex != obj._beamParameterIndex)
            {
                ivarsEqual = false;
            }

            if (!this._fundamentalParameterData.Equals(obj._fundamentalParameterData))
            {
                ivarsEqual = false;
            }

            if (this._beamFunction != obj._beamFunction)
            {
                ivarsEqual = false;
            }

            if (this._numberOfTrackJamTargets != obj._numberOfTrackJamTargets)
            {
                ivarsEqual = false;
            }

            if (this._highDensityTrackJam != obj._highDensityTrackJam)
            {
                ivarsEqual = false;
            }

            if (this._pad4 != obj._pad4)
            {
                ivarsEqual = false;
            }

            if (this._jammingModeSequence != obj._jammingModeSequence)
            {
                ivarsEqual = false;
            }

            if (this._trackJamTargets.Count != obj._trackJamTargets.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._trackJamTargets.Count; idx++)
                {
                    if (!this._trackJamTargets[idx].Equals(obj._trackJamTargets[idx]))
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

            result = GenerateHash(result) ^ this._beamDataLength.GetHashCode();
            result = GenerateHash(result) ^ this._beamIDNumber.GetHashCode();
            result = GenerateHash(result) ^ this._beamParameterIndex.GetHashCode();
            result = GenerateHash(result) ^ this._fundamentalParameterData.GetHashCode();
            result = GenerateHash(result) ^ this._beamFunction.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfTrackJamTargets.GetHashCode();
            result = GenerateHash(result) ^ this._highDensityTrackJam.GetHashCode();
            result = GenerateHash(result) ^ this._pad4.GetHashCode();
            result = GenerateHash(result) ^ this._jammingModeSequence.GetHashCode();

            if (this._trackJamTargets.Count > 0)
            {
                for (int idx = 0; idx < this._trackJamTargets.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._trackJamTargets[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
