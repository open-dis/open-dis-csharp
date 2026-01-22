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
// Author: werbaer-bot
// Modified for use with C#:
//  - Jan Birkmann (ELT Group Germany)

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;
using OpenDis.Core;

namespace DISnet
{
    /// <summary>
    /// This field shall specify information about a particular emitter system. Section 6.2.23.
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EmitterSystem))]
    [XmlInclude(typeof(Vector3Float))]
    [XmlInclude(typeof(Beam))]

    public partial class EmissionSystem
    {
        /// <summary>
        /// this field shall specify the length of this emitter system's data in 32-bit words.
        /// </summary>
        private byte _systemDataLength;

        /// <summary>
        /// the number of beams being described in the current PDU for the emitter system being described. 
        /// </summary>
        private byte _numberOfBeams;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _paddingForEmissionSystem1;

        /// <summary>
        ///  information about a particular emitter system and shall be represented by an Emitter System record (see 6.2.23).
        /// </summary>
        private EmitterSystem _emitterSystem = new EmitterSystem();

        /// <summary>
        /// the location of the antenna beam source with respect to the emitting entity's coordinate system. This location shall be the origin of the emitter coordinate system that shall have the same orientation as the entity coordinate system. This field shall be represented by an Entity Coordinate Vector record see 6.2.95 
        /// </summary>
        private Vector3Float _location = new Vector3Float();

        /// <summary>
        /// list of Beams
        /// </summary>
        private List<Beam> _beams = new List<Beam>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmissionSystem"/> class.
        /// </summary>
        public EmissionSystem()
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
        public static bool operator !=(EmissionSystem left, EmissionSystem right)
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
        public static bool operator ==(EmissionSystem left, EmissionSystem right)
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
            marshalSize += 2;  // this._paddingForEmissionSystem1
            marshalSize += this._emitterSystem.GetMarshalledSize();
            marshalSize += this._location.GetMarshalledSize();

            for (int idx = 0; idx < this._beams.Count; idx++)
            {
                marshalSize += this._beams[idx].GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// this field shall specify the length of this emitter system's data in 32-bit words.
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
        /// this field shall specify the number of beams being described in the current PDU for the system being described.
        /// </summary>
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
        /// this field shall specify information about a particular emitter system. 
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
        /// this field shall specify the location of the antenna beam source with respect to the emitting entity's coordinate system. This location shall be the origin of the emitter coordinate system which shall be parallel to the entity coordinate system. 
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
        /// list of Beams
        /// </summary>
        [XmlElement(ElementName = "beams")]
        public List<Beam> Beams
        {
            get 
            { 
                return this._beams;
            }

            set 
            {
                this._beams = value;
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
            if (dos == null) return;

            try
            {
                dos.WriteUnsignedByte(this._systemDataLength);
                dos.WriteUnsignedByte(this._numberOfBeams);
                dos.WriteUnsignedShort(this._paddingForEmissionSystem1);

                this._emitterSystem.Marshal(dos);
                this._location.Marshal(dos);

                for (int i = 0; i < this._beams.Count; i++)
                {
                    this._beams[i].Marshal(dos);
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
                this._systemDataLength = dis.ReadUnsignedByte();
                this._numberOfBeams = dis.ReadUnsignedByte();
                this._paddingForEmissionSystem1 = dis.ReadUnsignedShort();

                this._emitterSystem.Unmarshal(dis);
                this._location.Unmarshal(dis);

                this._beams.Clear();
                for (int i = 0; i < this._numberOfBeams; i++)
                {
                    Beam b = new Beam();
                    b.Unmarshal(dis);
                    this._beams.Add(b);
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
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<EmissionSystem>");
            try
            {
                sb.AppendLine("<systemDataLength type=\"byte\">" + this._systemDataLength + "</systemDataLength>");
                sb.AppendLine("<numberOfBeams type=\"byte\">" + this._numberOfBeams + "</numberOfBeams>");
                sb.AppendLine("<paddingForEmissionSystem1 type=\"ushort\">" + this._paddingForEmissionSystem1 + "</paddingForEmissionSystem1>");

                sb.AppendLine("<emitterSystem>");
                this._emitterSystem.Reflection(sb);
                sb.AppendLine("</emitterSystem>");

                sb.AppendLine("<location>");
                this._location.Reflection(sb);
                sb.AppendLine("</location>");

                sb.AppendLine("<beams count=\"" + this._beams.Count + "\">");
                for (int idx = 0; idx < this._beams.Count; idx++)
                {
                    sb.AppendLine("<beam index=\"" + idx + "\">");
                    this._beams[idx].Reflection(sb);
                    sb.AppendLine("</beam>");
                }
                sb.AppendLine("</beams>");
            }
            catch (Exception e)
            {
#if DEBUG
        Trace.WriteLine(e);
        Trace.Flush();
#endif
                this.OnException(e);
            }

            sb.AppendLine("</EmissionSystem>");
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
            return this == obj as EmissionSystem;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EmissionSystem obj)
        {
            bool ivarsEqual = true;

            if (obj == null)
            {
                return false;
            }

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

            if (this._paddingForEmissionSystem1 != obj._paddingForEmissionSystem1)
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

            if (this._beams.Count != obj._beams.Count)
            {
                ivarsEqual = false;
            }
            else
            {
                for (int idx = 0; idx < this._beams.Count; idx++)
                {
                    if (!this._beams[idx].Equals(obj._beams[idx]))
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
            result = GenerateHash(result) ^ this._paddingForEmissionSystem1.GetHashCode();

            if (this._emitterSystem != null)
            {
                result = GenerateHash(result) ^ this._emitterSystem.GetHashCode();
            }

            if (this._location != null)
            {
                result = GenerateHash(result) ^ this._location.GetHashCode();
            }

            for (int idx = 0; idx < this._beams.Count; idx++)
            {
                if (this._beams[idx] != null)
                {
                    result = GenerateHash(result) ^ this._beams[idx].GetHashCode();
                }
            }

            return result;
        }

    }
}
