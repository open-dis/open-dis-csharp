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
    /// Data about one electronic system
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(ElectronicEmissionBeamData))]
    public partial class ElectronicEmissionSystemData : IEquatable<ElectronicEmissionSystemData>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicEmissionSystemData"/> class.
        /// </summary>
        public ElectronicEmissionSystemData()
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
        public static bool operator !=(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1;  // this._systemDataLength
            marshalSize += 1;  // this._numberOfBeams
            marshalSize += 2;  // this._emissionsPadding2
            marshalSize += EmitterSystem.GetMarshalledSize();  // this._emitterSystem
            marshalSize += Location.GetMarshalledSize();  // this._location
            for (int idx = 0; idx < BeamDataRecords.Count; idx++)
            {
                var listElement = BeamDataRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall specify the length of this emitter system?s data (including beam data and its
        /// track/jam information) in 32-bit words. The length shall include the System Data Length field.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
        public byte SystemDataLength { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify the number of beams being described in the current PDU for the system
        /// being described.
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfBeams method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
        public byte NumberOfBeams { get; set; }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
        public ushort EmissionsPadding2 { get; set; }

        /// <summary>
        /// Gets or sets the This field shall specify information about a particular emitter system
        /// </summary>
        [XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
        public EmitterSystem EmitterSystem { get; set; } = new EmitterSystem();

        /// <summary>
        /// Gets or sets the Location with respect to the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets the variable length list of beam data records
        /// </summary>
        [XmlElement(ElementName = "beamDataRecordsList", Type = typeof(List<ElectronicEmissionBeamData>))]
        public List<ElectronicEmissionBeamData> BeamDataRecords { get; } = new();

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
            if (PduBase.FireExceptionEvents && ExceptionOccured != null)
            {
                ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedByte(SystemDataLength);
                    dos.WriteUnsignedByte((byte)BeamDataRecords.Count);
                    dos.WriteUnsignedShort(EmissionsPadding2);
                    EmitterSystem.Marshal(dos);
                    Location.Marshal(dos);

                    for (int idx = 0; idx < BeamDataRecords.Count; idx++)
                    {
                        var aElectronicEmissionBeamData = BeamDataRecords[idx];
                        aElectronicEmissionBeamData.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
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
                    SystemDataLength = dis.ReadUnsignedByte();
                    NumberOfBeams = dis.ReadUnsignedByte();
                    EmissionsPadding2 = dis.ReadUnsignedShort();
                    EmitterSystem.Unmarshal(dis);
                    Location.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfBeams; idx++)
                    {
                        var anX = new ElectronicEmissionBeamData();
                        anX.Unmarshal(dis);
                        BeamDataRecords.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        ///<inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<ElectronicEmissionSystemData>");
            try
            {
                sb.AppendLine("<systemDataLength type=\"byte\">" + SystemDataLength.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
                sb.AppendLine("<beamDataRecords type=\"byte\">" + BeamDataRecords.Count.ToString(CultureInfo.InvariantCulture) + "</beamDataRecords>");
                sb.AppendLine("<emissionsPadding2 type=\"ushort\">" + EmissionsPadding2.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
                sb.AppendLine("<emitterSystem>");
                EmitterSystem.Reflection(sb);
                sb.AppendLine("</emitterSystem>");
                sb.AppendLine("<location>");
                Location.Reflection(sb);
                sb.AppendLine("</location>");
                for (int idx = 0; idx < BeamDataRecords.Count; idx++)
                {
                    sb.AppendLine("<beamDataRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionBeamData\">");
                    var aElectronicEmissionBeamData = BeamDataRecords[idx];
                    aElectronicEmissionBeamData.Reflection(sb);
                    sb.AppendLine("</beamDataRecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ElectronicEmissionSystemData>");
            }
            catch (Exception e)
            {
                if (PduBase.TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (PduBase.ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as ElectronicEmissionSystemData;

        ///<inheritdoc/>
        public bool Equals(ElectronicEmissionSystemData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (SystemDataLength != obj.SystemDataLength)
            {
                ivarsEqual = false;
            }

            if (NumberOfBeams != obj.NumberOfBeams)
            {
                ivarsEqual = false;
            }

            if (EmissionsPadding2 != obj.EmissionsPadding2)
            {
                ivarsEqual = false;
            }

            if (!EmitterSystem.Equals(obj.EmitterSystem))
            {
                ivarsEqual = false;
            }

            if (!Location.Equals(obj.Location))
            {
                ivarsEqual = false;
            }

            if (BeamDataRecords.Count != obj.BeamDataRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < BeamDataRecords.Count; idx++)
                {
                    if (!BeamDataRecords[idx].Equals(obj.BeamDataRecords[idx]))
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

            result = GenerateHash(result) ^ SystemDataLength.GetHashCode();
            result = GenerateHash(result) ^ NumberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ EmissionsPadding2.GetHashCode();
            result = GenerateHash(result) ^ EmitterSystem.GetHashCode();
            result = GenerateHash(result) ^ Location.GetHashCode();

            if (BeamDataRecords.Count > 0)
            {
                for (int idx = 0; idx < BeamDataRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ BeamDataRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
