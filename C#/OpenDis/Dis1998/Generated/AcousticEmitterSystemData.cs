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
    /// Used in the UA pdu; ties together an emmitter and a location. This requires manual cleanup; the beam data should not be attached to each emitter system.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(AcousticEmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(AcousticBeamData))]
    public partial class AcousticEmitterSystemData
    {
        /// <summary>
        /// Length of emitter system data
        /// </summary>
        private byte _emitterSystemDataLength;

        /// <summary>
        /// Number of beams
        /// </summary>
        private byte _numberOfBeams;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _pad2;

        /// <summary>
        /// This field shall specify the system for a particular UA emitter.
        /// </summary>
        private AcousticEmitterSystem _acousticEmitterSystem = new AcousticEmitterSystem();

        /// <summary>
        /// Represents the location wrt the entity
        /// </summary>
        private Vector3Float _emitterLocation = new Vector3Float();

        /// <summary>
        /// For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system.
        /// </summary>
        private List<AcousticBeamData> _beamRecords = new List<AcousticBeamData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AcousticEmitterSystemData"/> class.
        /// </summary>
        public AcousticEmitterSystemData()
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
        public static bool operator !=(AcousticEmitterSystemData left, AcousticEmitterSystemData right)
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
        public static bool operator ==(AcousticEmitterSystemData left, AcousticEmitterSystemData right)
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

            marshalSize += 1;  // this._emitterSystemDataLength
            marshalSize += 1;  // this._numberOfBeams
            marshalSize += 2;  // this._pad2
            marshalSize += this._acousticEmitterSystem.GetMarshalledSize();  // this._acousticEmitterSystem
            marshalSize += this._emitterLocation.GetMarshalledSize();  // this._emitterLocation
            for (int idx = 0; idx < this._beamRecords.Count; idx++)
            {
                AcousticBeamData listElement = (AcousticBeamData)this._beamRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Length of emitter system data
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "emitterSystemDataLength")]
        public byte EmitterSystemDataLength
        {
            get
            {
                return this._emitterSystemDataLength;
            }

            set
            {
                this._emitterSystemDataLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of beams
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
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "pad2")]
        public ushort Pad2
        {
            get
            {
                return this._pad2;
            }

            set
            {
                this._pad2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the This field shall specify the system for a particular UA emitter.
        /// </summary>
        [XmlElement(Type = typeof(AcousticEmitterSystem), ElementName = "acousticEmitterSystem")]
        public AcousticEmitterSystem AcousticEmitterSystem
        {
            get
            {
                return this._acousticEmitterSystem;
            }

            set
            {
                this._acousticEmitterSystem = value;
            }
        }

        /// <summary>
        /// Gets or sets the Represents the location wrt the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "emitterLocation")]
        public Vector3Float EmitterLocation
        {
            get
            {
                return this._emitterLocation;
            }

            set
            {
                this._emitterLocation = value;
            }
        }

        /// <summary>
        /// Gets the For each beam in numberOfBeams, an emitter system. This is not right--the beam records need to be at the end of the PDU, rather than attached to each system.
        /// </summary>
        [XmlElement(ElementName = "beamRecordsList", Type = typeof(List<AcousticBeamData>))]
        public List<AcousticBeamData> BeamRecords
        {
            get
            {
                return this._beamRecords;
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
                    dos.WriteUnsignedByte((byte)this._emitterSystemDataLength);
                    dos.WriteUnsignedByte((byte)this._beamRecords.Count);
                    dos.WriteUnsignedShort((ushort)this._pad2);
                    this._acousticEmitterSystem.Marshal(dos);
                    this._emitterLocation.Marshal(dos);

                    for (int idx = 0; idx < this._beamRecords.Count; idx++)
                    {
                        AcousticBeamData aAcousticBeamData = (AcousticBeamData)this._beamRecords[idx];
                        aAcousticBeamData.Marshal(dos);
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
                    this._emitterSystemDataLength = dis.ReadUnsignedByte();
                    this._numberOfBeams = dis.ReadUnsignedByte();
                    this._pad2 = dis.ReadUnsignedShort();
                    this._acousticEmitterSystem.Unmarshal(dis);
                    this._emitterLocation.Unmarshal(dis);

                    for (int idx = 0; idx < this.NumberOfBeams; idx++)
                    {
                        AcousticBeamData anX = new AcousticBeamData();
                        anX.Unmarshal(dis);
                        this._beamRecords.Add(anX);
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
            sb.AppendLine("<AcousticEmitterSystemData>");
            try
            {
                sb.AppendLine("<emitterSystemDataLength type=\"byte\">" + this._emitterSystemDataLength.ToString(CultureInfo.InvariantCulture) + "</emitterSystemDataLength>");
                sb.AppendLine("<beamRecords type=\"byte\">" + this._beamRecords.Count.ToString(CultureInfo.InvariantCulture) + "</beamRecords>");
                sb.AppendLine("<pad2 type=\"ushort\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<acousticEmitterSystem>");
                this._acousticEmitterSystem.Reflection(sb);
                sb.AppendLine("</acousticEmitterSystem>");
                sb.AppendLine("<emitterLocation>");
                this._emitterLocation.Reflection(sb);
                sb.AppendLine("</emitterLocation>");
                for (int idx = 0; idx < this._beamRecords.Count; idx++)
                {
                    sb.AppendLine("<beamRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticBeamData\">");
                    AcousticBeamData aAcousticBeamData = (AcousticBeamData)this._beamRecords[idx];
                    aAcousticBeamData.Reflection(sb);
                    sb.AppendLine("</beamRecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</AcousticEmitterSystemData>");
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
            return this == obj as AcousticEmitterSystemData;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(AcousticEmitterSystemData obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._emitterSystemDataLength != obj._emitterSystemDataLength)
            {
                ivarsEqual = false;
            }

            if (this._numberOfBeams != obj._numberOfBeams)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (!this._acousticEmitterSystem.Equals(obj._acousticEmitterSystem))
            {
                ivarsEqual = false;
            }

            if (!this._emitterLocation.Equals(obj._emitterLocation))
            {
                ivarsEqual = false;
            }

            if (this._beamRecords.Count != obj._beamRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._beamRecords.Count; idx++)
                {
                    if (!this._beamRecords[idx].Equals(obj._beamRecords[idx]))
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

            result = GenerateHash(result) ^ this._emitterSystemDataLength.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfBeams.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._acousticEmitterSystem.GetHashCode();
            result = GenerateHash(result) ^ this._emitterLocation.GetHashCode();

            if (this._beamRecords.Count > 0)
            {
                for (int idx = 0; idx < this._beamRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._beamRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
