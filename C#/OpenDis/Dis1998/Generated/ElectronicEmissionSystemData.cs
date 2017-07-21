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
    public partial class ElectronicEmissionSystemData
    {
        /// <summary>
        /// This field shall specify the length of this emitter system?s data (including beam data and its track/jam information) in 32-bit words. The length shall include the System Data Length field. 
        /// </summary>
        private byte _systemDataLength;

        /// <summary>
        /// This field shall specify the number of beams being described in the current PDU for the system being described. 
        /// </summary>
        private byte _numberOfBeams;

        /// <summary>
        /// padding.
        /// </summary>
        private ushort _emissionsPadding2;

        /// <summary>
        /// This field shall specify information about a particular emitter system
        /// </summary>
        private EmitterSystem _emitterSystem = new EmitterSystem();

        /// <summary>
        /// Location with respect to the entity
        /// </summary>
        private Vector3Float _location = new Vector3Float();

        /// <summary>
        /// variable length list of beam data records
        /// </summary>
        private List<ElectronicEmissionBeamData> _beamDataRecords = new List<ElectronicEmissionBeamData>();

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
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right)
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
        public static bool operator ==(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right)
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

            marshalSize += 1;  // this._systemDataLength
            marshalSize += 1;  // this._numberOfBeams
            marshalSize += 2;  // this._emissionsPadding2
            marshalSize += this._emitterSystem.GetMarshalledSize();  // this._emitterSystem
            marshalSize += this._location.GetMarshalledSize();  // this._location
            for (int idx = 0; idx < this._beamDataRecords.Count; idx++)
            {
                ElectronicEmissionBeamData listElement = (ElectronicEmissionBeamData)this._beamDataRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the This field shall specify the length of this emitter system?s data (including beam data and its track/jam information) in 32-bit words. The length shall include the System Data Length field. 
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
        public byte SystemDataLength
        {
            get
            {
                return this._systemDataLength;
            }

            set
            {
                this._systemDataLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the number of beams being described in the current PDU for the system being described. 
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfBeams method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
        public byte NumberOfBeams
        {
            get
            {
                return this._numberOfBeams;
            }

            set
            {
                this._numberOfBeams = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
        public ushort EmissionsPadding2
        {
            get
            {
                return this._emissionsPadding2;
            }

            set
            {
                this._emissionsPadding2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify information about a particular emitter system
        /// </summary>
        [XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
        public EmitterSystem EmitterSystem
        {
            get
            {
                return this._emitterSystem;
            }

            set
            {
                this._emitterSystem = value;
            }
        }

        /// <summary>
        /// Gets or sets the Location with respect to the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
        public Vector3Float Location
        {
            get
            {
                return this._location;
            }

            set
            {
                this._location = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of beam data records
        /// </summary>
        [XmlElement(ElementName = "beamDataRecordsList", Type = typeof(List<ElectronicEmissionBeamData>))]
        public List<ElectronicEmissionBeamData> BeamDataRecords
        {
            get
            {
                return this._beamDataRecords;
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
                    dos.WriteUnsignedByte((byte)this._systemDataLength);
                    dos.WriteUnsignedByte((byte)this._beamDataRecords.Count);
                    dos.WriteUnsignedShort((ushort)this._emissionsPadding2);
                    this._emitterSystem.Marshal(dos);
                    this._location.Marshal(dos);

                    for (int idx = 0; idx < this._beamDataRecords.Count; idx++)
                    {
                        ElectronicEmissionBeamData aElectronicEmissionBeamData = (ElectronicEmissionBeamData)this._beamDataRecords[idx];
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
                    this._systemDataLength = dis.ReadUnsignedByte();
                    this._numberOfBeams = dis.ReadUnsignedByte();
                    this._emissionsPadding2 = dis.ReadUnsignedShort();
                    this._emitterSystem.Unmarshal(dis);
                    this._location.Unmarshal(dis);

                    for (int idx = 0; idx < this.NumberOfBeams; idx++)
                    {
                        ElectronicEmissionBeamData anX = new ElectronicEmissionBeamData();
                        anX.Unmarshal(dis);
                        this._beamDataRecords.Add(anX);
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
            sb.AppendLine("<ElectronicEmissionSystemData>");
            try
            {
                sb.AppendLine("<systemDataLength type=\"byte\">" + this._systemDataLength.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
                sb.AppendLine("<beamDataRecords type=\"byte\">" + this._beamDataRecords.Count.ToString(CultureInfo.InvariantCulture) + "</beamDataRecords>");
                sb.AppendLine("<emissionsPadding2 type=\"ushort\">" + this._emissionsPadding2.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
                sb.AppendLine("<emitterSystem>");
                this._emitterSystem.Reflection(sb);
                sb.AppendLine("</emitterSystem>");
                sb.AppendLine("<location>");
                this._location.Reflection(sb);
                sb.AppendLine("</location>");
                for (int idx = 0; idx < this._beamDataRecords.Count; idx++)
                {
                    sb.AppendLine("<beamDataRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionBeamData\">");
                    ElectronicEmissionBeamData aElectronicEmissionBeamData = (ElectronicEmissionBeamData)this._beamDataRecords[idx];
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
            return this == obj as ElectronicEmissionSystemData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ElectronicEmissionSystemData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._systemDataLength != obj._systemDataLength)
            {
                ivarsEqual = false;
            }

            if (this._numberOfBeams != obj._numberOfBeams)
            {
                ivarsEqual = false;
            }

            if (this._emissionsPadding2 != obj._emissionsPadding2)
            {
                ivarsEqual = false;
            }

            if (!this._emitterSystem.Equals(obj._emitterSystem))
            {
                ivarsEqual = false;
            }

            if (!this._location.Equals(obj._location))
            {
                ivarsEqual = false;
            }

            if (this._beamDataRecords.Count != obj._beamDataRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._beamDataRecords.Count; idx++)
                {
                    if (!this._beamDataRecords[idx].Equals(obj._beamDataRecords[idx]))
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

            result = GenerateHash(result) ^ this._systemDataLength.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ this._emissionsPadding2.GetHashCode();
            result = GenerateHash(result) ^ this._emitterSystem.GetHashCode();
            result = GenerateHash(result) ^ this._location.GetHashCode();

            if (this._beamDataRecords.Count > 0)
            {
                for (int idx = 0; idx < this._beamDataRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._beamDataRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
