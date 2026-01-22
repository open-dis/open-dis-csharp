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
// Author: Jan Birkmann (ELT Group Germany)
// Modified for use with C#:

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using OpenDis.Core;

namespace DISnet
{
    /// <summary>
    /// Describes the scan volue of an emitter beam. Section 6.2.13.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class Beam
    {
        /// <summary>
        /// this field shall specify the length of this beam's data (including track/jam information) in 32-bit words. The length shall include the Beam Data Length field.
        /// </summary>
        private byte _beamDataLength;

        /// <summary>
        /// this field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system. Once established for an exercise, the Beam ID numbers shall not be changed during that exercise.
        /// </summary>
        private byte _beamIdNumber;

        /// <summary>
        /// this field shall specify a beam parameter index number that shall be used by receiving entities in conjunction with the emitter name field to provide a pointer to the stored database parameters required to regenerate the beam.
        /// </summary>
        private ushort _beamParameterIndex;

        /// <summary>
        /// The Fundamental Parameter Data Record contains Electromagnetic Emission regeneration parameters that are variable throughout a scenario dependent on the actions of the participants in the simulation. This record also provides basic parametric data that may be used to support low-fidelity simulations which may not have the processing capability to model a high-fidelity regeneration of emission beams.
        /// </summary>
        private EEFundamentalParameterData _fundamentalParameters = new EEFundamentalParameterData();

        /// <summary>
        /// Beam scan volume data (azimuth/elevation centers and sweeps, sweep sync)
        /// </summary>
        private BeamData _beamData = new BeamData();

        /// <summary>
        /// this field shall specify the function of a particular beam.
        /// </summary>
        private byte _beamFunction;

        /// <summary>
        /// this field, in conjunction with the following field, provides a mechanism for an emitter to identify targets that are being illuminated by a track beam or target emitters it is attempting to jam.
        /// </summary>
        private byte _numberOfTargetsInTrackJam;

        /// <summary>
        /// this field shall specify the function of a particular beam.
        /// </summary>
        private byte _highDensityTrackJam;

        /// <summary>
        /// padding
        /// </summary>
        private byte _paddingForEmissionSystem2;

        /// <summary>
        /// this field shall specify the function of a particular beam.
        /// </summary>
        private JammingTechnique _jammingTechnique = new JammingTechnique();

        /// <summary>
        /// This field shall identify the targets in an emitter track or emitters a system is attempting to jam.
        /// </summary>
        private List<TrackJamData> _trackJamData = new List<TrackJamData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Beam"/> class.
        /// </summary>
        public Beam()
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
        public static bool operator !=(Beam left, Beam right)
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
        public static bool operator ==(Beam left, Beam right)
        {
            if (object.ReferenceEquals(left, right))
                return true;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Equals(right);
        }

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1; // _beamDataLength
            marshalSize += 1; // _beamIdNumber
            marshalSize += 2; // _beamParameterIndex
            marshalSize += this._fundamentalParameters.GetMarshalledSize();
            marshalSize += this._beamData.GetMarshalledSize();
            marshalSize += 1; // _beamFunction
            marshalSize += 1; // _numberOfTargetsInTrackJam
            marshalSize += 1; // _highDensityTrackJam
            marshalSize += 1; // _paddingForEmissionSystem2
            marshalSize += this._jammingTechnique.GetMarshalledSize();

            for (int idx = 0; idx < this._trackJamData.Count; idx++)
            {
                marshalSize += this._trackJamData[idx].GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// this field shall specify the length of this beam's data (including track/jam information) in 32-bit words. The length shall include the Beam Data Length field.
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
        /// this field shall specify a unique emitter database number assigned to differentiate between otherwise similar or identical emitter beams within an emitter system. Once established for an exercise, the Beam ID numbers shall not be changed during that exercise.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "beamIdNumber")]
        public byte BeamIdNumber
        {
            get 
            {
                return this._beamIdNumber;
            }

            set
            {
                this._beamIdNumber = value; 
            }
        }

        /// <summary>
        /// this field shall specify a beam parameter index number that shall be used by receiving entities in conjunction with the emitter name field to provide a pointer to the stored database parameters required to regenerate the beam.
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
        /// this field shall specify dynamic parameters of the emitter.
        /// </summary>
        [XmlElement(Type = typeof(EEFundamentalParameterData), ElementName = "fundamentalParameters")]
        public EEFundamentalParameterData FundamentalParameters
        {
            get 
            {
                return this._fundamentalParameters; 
            }

            set 
            {
                this._fundamentalParameters = value; 
            }
        }

        /// <summary>
        /// Beam scan volume data (azimuth/elevation centers and sweeps, sweep sync)
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
        /// this field shall specify the function of a particular beam.
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
        /// This field, in conjunction with the following field, provides a mechanism for an emitter to identify targets that are being illuminated by a track beam or target emitters it is attempting to jam.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfTargetsInTrackJam")]
        public byte NumberOfTargetsInTrackJam
        {
            get
            {
                return this._numberOfTargetsInTrackJam;
            }

            set 
            { 
                this._numberOfTargetsInTrackJam = value;
            }
        }

        /// <summary>
        /// This field shall be used to indicate whether or not the receiving simulation applications can assume that all targets, in the scan pattern which the sending emitter can track (for a phased array system) or jam (for a jamming system), are being tracked or jammed respectively.
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
        /// padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "paddingForEmissionSystem2")]
        public byte PaddingForEmissionSystem2
        {
            get 
            { 
                return this._paddingForEmissionSystem2;
            }

            set 
            {
                this._paddingForEmissionSystem2 = value;
            }
        }

        /// <summary>
        /// this field shall be used to identify one or multiple jamming techniques being applied.
        /// </summary>
        [XmlElement(Type = typeof(JammingTechnique), ElementName = "jammingTechnique")]
        public JammingTechnique JammingTechnique
        {
            get
            {
                return this._jammingTechnique; 
            }

            set 
            {
                this._jammingTechnique = value;
            }
        }

        /// <summary>
        /// this field shall identify the targets in an emitter track or emitters a system is attempting to jam.
        /// </summary>
        [XmlElement(ElementName = "trackJamDataList")]
        public List<TrackJamData> TrackJamData
        {
            get 
            { 
                return this._trackJamData; 
            }

            set 
            { 
                this._trackJamData = value;
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
                this.Exception(e);
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos == null) return;

            try
            {
                dos.WriteUnsignedByte(this._beamDataLength);
                dos.WriteUnsignedByte(this._beamIdNumber);
                dos.WriteUnsignedShort(this._beamParameterIndex);

                this._fundamentalParameters.Marshal(dos);
                this._beamData.Marshal(dos);

                dos.WriteUnsignedByte(this._beamFunction);
                dos.WriteUnsignedByte(this._numberOfTargetsInTrackJam);
                dos.WriteUnsignedByte(this._highDensityTrackJam);
                dos.WriteUnsignedByte(this._paddingForEmissionSystem2);

                this._jammingTechnique.Marshal(dos);

                for (int i = 0; i < this._numberOfTargetsInTrackJam; i++)
                {
                    this._trackJamData[i].Marshal(dos);
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

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis == null) return;

            try
            {
                this._beamDataLength = dis.ReadUnsignedByte();
                this._beamIdNumber = dis.ReadUnsignedByte();
                this._beamParameterIndex = dis.ReadUnsignedShort();

                this._fundamentalParameters.Unmarshal(dis);
                this._beamData.Unmarshal(dis);

                this._beamFunction = dis.ReadUnsignedByte();
                this._numberOfTargetsInTrackJam = dis.ReadUnsignedByte();
                this._highDensityTrackJam = dis.ReadUnsignedByte();
                this._paddingForEmissionSystem2 = dis.ReadUnsignedByte();

                this._jammingTechnique.Unmarshal(dis);

                this._trackJamData.Clear();
                for (int i = 0; i < this._numberOfTargetsInTrackJam; i++)
                {
                    TrackJamData tjd = new TrackJamData();
                    tjd.Unmarshal(dis);
                    this._trackJamData.Add(tjd);
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

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<Beam>");
            try
            {
                sb.AppendLine("<beamDataLength type=\"byte\">" + this._beamDataLength + "</beamDataLength>");
                sb.AppendLine("<beamIdNumber type=\"byte\">" + this._beamIdNumber + "</beamIdNumber>");
                sb.AppendLine("<beamParameterIndex type=\"ushort\">" + this._beamParameterIndex + "</beamParameterIndex>");

                sb.AppendLine("<fundamentalParameters>");
                this._fundamentalParameters.Reflection(sb);
                sb.AppendLine("</fundamentalParameters>");

                sb.AppendLine("<beamData>");
                this._beamData.Reflection(sb);
                sb.AppendLine("</beamData>");

                sb.AppendLine("<beamFunction type=\"byte\">" + this._beamFunction + "</beamFunction>");
                sb.AppendLine("<numberOfTargetsInTrackJam type=\"byte\">" + this._numberOfTargetsInTrackJam + "</numberOfTargetsInTrackJam>");
                sb.AppendLine("<highDensityTrackJam type=\"byte\">" + this._highDensityTrackJam + "</highDensityTrackJam>");
                sb.AppendLine("<paddingForEmissionSystem2 type=\"byte\">" + this._paddingForEmissionSystem2 + "</paddingForEmissionSystem2>");

                sb.AppendLine("<jammingTechnique>");
                this._jammingTechnique.Reflection(sb);
                sb.AppendLine("</jammingTechnique>");

                sb.AppendLine("<trackJamDataList count=\"" + this._trackJamData.Count + "\">");
                for (int idx = 0; idx < this._trackJamData.Count; idx++)
                {
                    sb.AppendLine("<trackJamData index=\"" + idx + "\">");
                    this._trackJamData[idx].Reflection(sb);
                    sb.AppendLine("</trackJamData>");
                }
                sb.AppendLine("</trackJamDataList>");
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.WriteLine(e);
                Trace.Flush();
#endif
                this.OnException(e);
            }

            sb.AppendLine("</Beam>");
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
            return this == obj as Beam;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Beam obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            bool ivarsEqual = true;

            if (this._beamDataLength != obj._beamDataLength) ivarsEqual = false;
            if (this._beamIdNumber != obj._beamIdNumber) ivarsEqual = false;
            if (this._beamParameterIndex != obj._beamParameterIndex) ivarsEqual = false;

            if (!this._fundamentalParameters.Equals(obj._fundamentalParameters)) ivarsEqual = false;
            if (!this._beamData.Equals(obj._beamData)) ivarsEqual = false;

            if (this._beamFunction != obj._beamFunction) ivarsEqual = false;
            if (this._numberOfTargetsInTrackJam != obj._numberOfTargetsInTrackJam) ivarsEqual = false;
            if (this._highDensityTrackJam != obj._highDensityTrackJam) ivarsEqual = false;
            if (this._paddingForEmissionSystem2 != obj._paddingForEmissionSystem2) ivarsEqual = false;

            if (!this._jammingTechnique.Equals(obj._jammingTechnique)) ivarsEqual = false;

            if (this._trackJamData.Count != obj._trackJamData.Count) ivarsEqual = false;
            else
            {
                for (int idx = 0; idx < this._trackJamData.Count; idx++)
                {
                    if (!this._trackJamData[idx].Equals(obj._trackJamData[idx])) ivarsEqual = false;
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
            result = GenerateHash(result) ^ this._beamIdNumber.GetHashCode();
            result = GenerateHash(result) ^ this._beamParameterIndex.GetHashCode();

            if (this._fundamentalParameters != null) result = GenerateHash(result) ^ this._fundamentalParameters.GetHashCode();
            if (this._beamData != null) result = GenerateHash(result) ^ this._beamData.GetHashCode();

            result = GenerateHash(result) ^ this._beamFunction.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfTargetsInTrackJam.GetHashCode();
            result = GenerateHash(result) ^ this._highDensityTrackJam.GetHashCode();
            result = GenerateHash(result) ^ this._paddingForEmissionSystem2.GetHashCode();

            if (this._jammingTechnique != null) result = GenerateHash(result) ^ this._jammingTechnique.GetHashCode();

            for (int idx = 0; idx < this._trackJamData.Count; idx++)
            {
                if (this._trackJamData[idx] != null) result = GenerateHash(result) ^ this._trackJamData[idx].GetHashCode();
            }

            return result;
        }
    }
}
