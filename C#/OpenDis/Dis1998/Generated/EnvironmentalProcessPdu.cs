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
    /// Section 5.3.11.1: Information about environmental effects and processes. This requires manual cleanup. the environmental        record is variable, as is the padding. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(Environment))]
    public partial class EnvironmentalProcessPdu : SyntheticEnvironmentFamilyPdu, IEquatable<EnvironmentalProcessPdu>
    {
        /// <summary>
        /// Environmental process ID
        /// </summary>
        private EntityID _environementalProcessID = new EntityID();

        /// <summary>
        /// Environment type
        /// </summary>
        private EntityType _environmentType = new EntityType();

        /// <summary>
        /// model type
        /// </summary>
        private byte _modelType;

        /// <summary>
        /// Environment status
        /// </summary>
        private byte _environmentStatus;

        /// <summary>
        /// number of environment records 
        /// </summary>
        private byte _numberOfEnvironmentRecords;

        /// <summary>
        /// PDU sequence number for the environmentla process if pdu sequencing required
        /// </summary>
        private ushort _sequenceNumber;

        /// <summary>
        /// environemt records
        /// </summary>
        private List<Environment> _environmentRecords = new List<Environment>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentalProcessPdu"/> class.
        /// </summary>
        public EnvironmentalProcessPdu()
        {
            PduType = (byte)41;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right)
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
        public static bool operator ==(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right)
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
            marshalSize += this._environementalProcessID.GetMarshalledSize();  // this._environementalProcessID
            marshalSize += this._environmentType.GetMarshalledSize();  // this._environmentType
            marshalSize += 1;  // this._modelType
            marshalSize += 1;  // this._environmentStatus
            marshalSize += 1;  // this._numberOfEnvironmentRecords
            marshalSize += 2;  // this._sequenceNumber
            for (int idx = 0; idx < this._environmentRecords.Count; idx++)
            {
                Environment listElement = (Environment)this._environmentRecords[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Environmental process ID
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "environementalProcessID")]
        public EntityID EnvironementalProcessID
        {
            get
            {
                return this._environementalProcessID;
            }

            set
            {
                this._environementalProcessID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Environment type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
        public EntityType EnvironmentType
        {
            get
            {
                return this._environmentType;
            }

            set
            {
                this._environmentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the model type
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modelType")]
        public byte ModelType
        {
            get
            {
                return this._modelType;
            }

            set
            {
                this._modelType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Environment status
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "environmentStatus")]
        public byte EnvironmentStatus
        {
            get
            {
                return this._environmentStatus;
            }

            set
            {
                this._environmentStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of environment records 
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfEnvironmentRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfEnvironmentRecords")]
        public byte NumberOfEnvironmentRecords
        {
            get
            {
                return this._numberOfEnvironmentRecords;
            }

            set
            {
                this._numberOfEnvironmentRecords = value;
            }
        }

        /// <summary>
        /// Gets or sets the PDU sequence number for the environmentla process if pdu sequencing required
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "sequenceNumber")]
        public ushort SequenceNumber
        {
            get
            {
                return this._sequenceNumber;
            }

            set
            {
                this._sequenceNumber = value;
            }
        }

        /// <summary>
        /// Gets the environemt records
        /// </summary>
        [XmlElement(ElementName = "environmentRecordsList", Type = typeof(List<Environment>))]
        public List<Environment> EnvironmentRecords
        {
            get
            {
                return this._environmentRecords;
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
                    this._environementalProcessID.Marshal(dos);
                    this._environmentType.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._modelType);
                    dos.WriteUnsignedByte((byte)this._environmentStatus);
                    dos.WriteUnsignedByte((byte)this._environmentRecords.Count);
                    dos.WriteUnsignedShort((ushort)this._sequenceNumber);

                    for (int idx = 0; idx < this._environmentRecords.Count; idx++)
                    {
                        Environment aEnvironment = (Environment)this._environmentRecords[idx];
                        aEnvironment.Marshal(dos);
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
                    this._environementalProcessID.Unmarshal(dis);
                    this._environmentType.Unmarshal(dis);
                    this._modelType = dis.ReadUnsignedByte();
                    this._environmentStatus = dis.ReadUnsignedByte();
                    this._numberOfEnvironmentRecords = dis.ReadUnsignedByte();
                    this._sequenceNumber = dis.ReadUnsignedShort();

                    for (int idx = 0; idx < this.NumberOfEnvironmentRecords; idx++)
                    {
                        Environment anX = new Environment();
                        anX.Unmarshal(dis);
                        this._environmentRecords.Add(anX);
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
            sb.AppendLine("<EnvironmentalProcessPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<environementalProcessID>");
                this._environementalProcessID.Reflection(sb);
                sb.AppendLine("</environementalProcessID>");
                sb.AppendLine("<environmentType>");
                this._environmentType.Reflection(sb);
                sb.AppendLine("</environmentType>");
                sb.AppendLine("<modelType type=\"byte\">" + this._modelType.ToString(CultureInfo.InvariantCulture) + "</modelType>");
                sb.AppendLine("<environmentStatus type=\"byte\">" + this._environmentStatus.ToString(CultureInfo.InvariantCulture) + "</environmentStatus>");
                sb.AppendLine("<environmentRecords type=\"byte\">" + this._environmentRecords.Count.ToString(CultureInfo.InvariantCulture) + "</environmentRecords>");
                sb.AppendLine("<sequenceNumber type=\"ushort\">" + this._sequenceNumber.ToString(CultureInfo.InvariantCulture) + "</sequenceNumber>");
                for (int idx = 0; idx < this._environmentRecords.Count; idx++)
                {
                    sb.AppendLine("<environmentRecords" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Environment\">");
                    Environment aEnvironment = (Environment)this._environmentRecords[idx];
                    aEnvironment.Reflection(sb);
                    sb.AppendLine("</environmentRecords" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</EnvironmentalProcessPdu>");
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
            return this == obj as EnvironmentalProcessPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EnvironmentalProcessPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._environementalProcessID.Equals(obj._environementalProcessID))
            {
                ivarsEqual = false;
            }

            if (!this._environmentType.Equals(obj._environmentType))
            {
                ivarsEqual = false;
            }

            if (this._modelType != obj._modelType)
            {
                ivarsEqual = false;
            }

            if (this._environmentStatus != obj._environmentStatus)
            {
                ivarsEqual = false;
            }

            if (this._numberOfEnvironmentRecords != obj._numberOfEnvironmentRecords)
            {
                ivarsEqual = false;
            }

            if (this._sequenceNumber != obj._sequenceNumber)
            {
                ivarsEqual = false;
            }

            if (this._environmentRecords.Count != obj._environmentRecords.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._environmentRecords.Count; idx++)
                {
                    if (!this._environmentRecords[idx].Equals(obj._environmentRecords[idx]))
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

            result = GenerateHash(result) ^ this._environementalProcessID.GetHashCode();
            result = GenerateHash(result) ^ this._environmentType.GetHashCode();
            result = GenerateHash(result) ^ this._modelType.GetHashCode();
            result = GenerateHash(result) ^ this._environmentStatus.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfEnvironmentRecords.GetHashCode();
            result = GenerateHash(result) ^ this._sequenceNumber.GetHashCode();

            if (this._environmentRecords.Count > 0)
            {
                for (int idx = 0; idx < this._environmentRecords.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._environmentRecords[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
