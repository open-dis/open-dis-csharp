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
using System.Diagnostics.CodeAnalysis;

namespace DISnet
{
    /// <summary>
    /// This field shall specify information about a particular emitter system. Section 6.2.23.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class EmissionSystem
    {
        /// <summary>
        ///  this field shall specify the length of this emitter system's data in 32-bit words.
        /// </summary>
        private byte _systemDataLength;

        /// <summary>
        /// the number of beams being described in the current PDU for the emitter system being described. 
        /// </summary>
        private byte _numberOfBeams;

        /// <summary>
        ///  information about a particular emitter system and shall be represented by an Emitter System record (see 6.2.23).
        /// </summary>
        private EmitterSystem _emitterSystem = new EmitterSystem();

        /// <summary>
        /// the location of the antenna beam source with respect to the emitting entity's coordinate system. This location shall be the origin of the emitter coordinate system that shall have the same orientation as the entity coordinate system. This field shall be represented by an Entity Coordinate Vector record see 6.2.95 
        /// </summary>
        private Vector3Float _location = new Vector3Float();

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
        /// this field shall specify the function of a particular beam.
        /// </summary>
        private JammingTechnique _jammingMode;

        /// <summary>
        /// This field shall identify the targets in an emitter track or emitters a system is attempting to jam.
        /// </summary>
        private TrackJamData[] _trackJam = new TrackJamData[0];

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

            //marshalSize += 2;  // this._emitterName
            //marshalSize += 1;  // this._function
            //marshalSize += 1;  // this._emitterIdNumber
            return marshalSize;
        }

        ///// <summary>
        ///// Gets or sets the Name of the emitter, 16 bit enumeration
        ///// </summary>
        //[XmlElement(Type = typeof(ushort), ElementName = "emitterName")]
        //public ushort EmitterName
        //{
        //    get
        //    {
        //        return this._emitterName;
        //    }

        //    set
        //    {
        //        this._emitterName = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the function of the emitter, 8 bit enumeration
        ///// </summary>
        //[XmlElement(Type = typeof(byte), ElementName = "function")]
        //public byte Function
        //{
        //    get
        //    {
        //        return this._function;
        //    }

        //    set
        //    {
        //        this._function = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the emitter ID, 8 bit enumeration
        ///// </summary>
        //[XmlElement(Type = typeof(byte), ElementName = "emitterIdNumber")]
        //public byte EmitterIdNumber
        //{
        //    get
        //    {
        //        return this._emitterIdNumber;
        //    }

        //    set
        //    {
        //        this._emitterIdNumber = value;
        //    }
        //}

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
                    //dos.WriteUnsignedShort((ushort)this._emitterName);
                    //dos.WriteUnsignedByte((byte)this._function);
                    //dos.WriteUnsignedByte((byte)this._emitterIdNumber);
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
                    //this._emitterName = dis.ReadUnsignedShort();
                    //this._function = dis.ReadUnsignedByte();
                    //this._emitterIdNumber = dis.ReadUnsignedByte();
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
            sb.AppendLine("<EmissionSystem>");
            try
            {
                //sb.AppendLine("<emitterName type=\"ushort\">" + this._emitterName.ToString(CultureInfo.InvariantCulture) + "</emitterName>");
                //sb.AppendLine("<function type=\"byte\">" + this._function.ToString(CultureInfo.InvariantCulture) + "</function>");
                //sb.AppendLine("<emitterIdNumber type=\"byte\">" + this._emitterIdNumber.ToString(CultureInfo.InvariantCulture) + "</emitterIdNumber>");
                sb.AppendLine("</EmissionSystem>");
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

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            //if (this._emitterName != obj._emitterName)
            //{
            //    ivarsEqual = false;
            //}

            //if (this._function != obj._function)
            //{
            //    ivarsEqual = false;
            //}

            //if (this._emitterIdNumber != obj._emitterIdNumber)
            //{
            //    ivarsEqual = false;
            //}

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

            //result = GenerateHash(result) ^ this._emitterName.GetHashCode();
            //result = GenerateHash(result) ^ this._function.GetHashCode();
            //result = GenerateHash(result) ^ this._emitterIdNumber.GetHashCode();

            return result;
        }
    }
}
