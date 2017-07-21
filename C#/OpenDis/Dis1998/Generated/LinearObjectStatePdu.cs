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
    /// Section 5.3.11.4: Information abut the addition or modification of a synthecic enviroment object that      is anchored to the terrain with a single point and has size or orientation. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(SimulationAddress))]
    [XmlInclude(typeof(ObjectType))]
    [XmlInclude(typeof(LinearSegmentParameter))]
    public partial class LinearObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<LinearObjectStatePdu>
    {
        /// <summary>
        /// Object in synthetic environment
        /// </summary>
        private EntityID _objectID = new EntityID();

        /// <summary>
        /// Object with which this point object is associated
        /// </summary>
        private EntityID _referencedObjectID = new EntityID();

        /// <summary>
        /// unique update number of each state transition of an object
        /// </summary>
        private ushort _updateNumber;

        /// <summary>
        /// force ID
        /// </summary>
        private byte _forceID;

        /// <summary>
        /// number of linear segment parameters
        /// </summary>
        private byte _numberOfSegments;

        /// <summary>
        /// requesterID
        /// </summary>
        private SimulationAddress _requesterID = new SimulationAddress();

        /// <summary>
        /// receiver ID
        /// </summary>
        private SimulationAddress _receivingID = new SimulationAddress();

        /// <summary>
        /// Object type
        /// </summary>
        private ObjectType _objectType = new ObjectType();

        /// <summary>
        /// Linear segment parameters
        /// </summary>
        private List<LinearSegmentParameter> _linearSegmentParameters = new List<LinearSegmentParameter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearObjectStatePdu"/> class.
        /// </summary>
        public LinearObjectStatePdu()
        {
            PduType = (byte)44;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LinearObjectStatePdu left, LinearObjectStatePdu right)
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
        public static bool operator ==(LinearObjectStatePdu left, LinearObjectStatePdu right)
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
            marshalSize += this._objectID.GetMarshalledSize();  // this._objectID
            marshalSize += this._referencedObjectID.GetMarshalledSize();  // this._referencedObjectID
            marshalSize += 2;  // this._updateNumber
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._numberOfSegments
            marshalSize += this._requesterID.GetMarshalledSize();  // this._requesterID
            marshalSize += this._receivingID.GetMarshalledSize();  // this._receivingID
            marshalSize += this._objectType.GetMarshalledSize();  // this._objectType
            for (int idx = 0; idx < this._linearSegmentParameters.Count; idx++)
            {
                LinearSegmentParameter listElement = (LinearSegmentParameter)this._linearSegmentParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Object in synthetic environment
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
        public EntityID ObjectID
        {
            get
            {
                return this._objectID;
            }

            set
            {
                this._objectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Object with which this point object is associated
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
        public EntityID ReferencedObjectID
        {
            get
            {
                return this._referencedObjectID;
            }

            set
            {
                this._referencedObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique update number of each state transition of an object
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
        public ushort UpdateNumber
        {
            get
            {
                return this._updateNumber;
            }

            set
            {
                this._updateNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the force ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceID")]
        public byte ForceID
        {
            get
            {
                return this._forceID;
            }

            set
            {
                this._forceID = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of linear segment parameters
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfSegments method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSegments")]
        public byte NumberOfSegments
        {
            get
            {
                return this._numberOfSegments;
            }

            set
            {
                this._numberOfSegments = value;
            }
        }

        /// <summary>
        /// Gets or sets the requesterID
        /// </summary>
        [XmlElement(Type = typeof(SimulationAddress), ElementName = "requesterID")]
        public SimulationAddress RequesterID
        {
            get
            {
                return this._requesterID;
            }

            set
            {
                this._requesterID = value;
            }
        }

        /// <summary>
        /// Gets or sets the receiver ID
        /// </summary>
        [XmlElement(Type = typeof(SimulationAddress), ElementName = "receivingID")]
        public SimulationAddress ReceivingID
        {
            get
            {
                return this._receivingID;
            }

            set
            {
                this._receivingID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Object type
        /// </summary>
        [XmlElement(Type = typeof(ObjectType), ElementName = "objectType")]
        public ObjectType ObjectType
        {
            get
            {
                return this._objectType;
            }

            set
            {
                this._objectType = value;
            }
        }

        /// <summary>
        /// Gets the Linear segment parameters
        /// </summary>
        [XmlElement(ElementName = "linearSegmentParametersList", Type = typeof(List<LinearSegmentParameter>))]
        public List<LinearSegmentParameter> LinearSegmentParameters
        {
            get
            {
                return this._linearSegmentParameters;
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
                    this._objectID.Marshal(dos);
                    this._referencedObjectID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._updateNumber);
                    dos.WriteUnsignedByte((byte)this._forceID);
                    dos.WriteUnsignedByte((byte)this._linearSegmentParameters.Count);
                    this._requesterID.Marshal(dos);
                    this._receivingID.Marshal(dos);
                    this._objectType.Marshal(dos);

                    for (int idx = 0; idx < this._linearSegmentParameters.Count; idx++)
                    {
                        LinearSegmentParameter aLinearSegmentParameter = (LinearSegmentParameter)this._linearSegmentParameters[idx];
                        aLinearSegmentParameter.Marshal(dos);
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
                    this._objectID.Unmarshal(dis);
                    this._referencedObjectID.Unmarshal(dis);
                    this._updateNumber = dis.ReadUnsignedShort();
                    this._forceID = dis.ReadUnsignedByte();
                    this._numberOfSegments = dis.ReadUnsignedByte();
                    this._requesterID.Unmarshal(dis);
                    this._receivingID.Unmarshal(dis);
                    this._objectType.Unmarshal(dis);

                    for (int idx = 0; idx < this.NumberOfSegments; idx++)
                    {
                        LinearSegmentParameter anX = new LinearSegmentParameter();
                        anX.Unmarshal(dis);
                        this._linearSegmentParameters.Add(anX);
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
            sb.AppendLine("<LinearObjectStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<objectID>");
                this._objectID.Reflection(sb);
                sb.AppendLine("</objectID>");
                sb.AppendLine("<referencedObjectID>");
                this._referencedObjectID.Reflection(sb);
                sb.AppendLine("</referencedObjectID>");
                sb.AppendLine("<updateNumber type=\"ushort\">" + this._updateNumber.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
                sb.AppendLine("<forceID type=\"byte\">" + this._forceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<linearSegmentParameters type=\"byte\">" + this._linearSegmentParameters.Count.ToString(CultureInfo.InvariantCulture) + "</linearSegmentParameters>");
                sb.AppendLine("<requesterID>");
                this._requesterID.Reflection(sb);
                sb.AppendLine("</requesterID>");
                sb.AppendLine("<receivingID>");
                this._receivingID.Reflection(sb);
                sb.AppendLine("</receivingID>");
                sb.AppendLine("<objectType>");
                this._objectType.Reflection(sb);
                sb.AppendLine("</objectType>");
                for (int idx = 0; idx < this._linearSegmentParameters.Count; idx++)
                {
                    sb.AppendLine("<linearSegmentParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"LinearSegmentParameter\">");
                    LinearSegmentParameter aLinearSegmentParameter = (LinearSegmentParameter)this._linearSegmentParameters[idx];
                    aLinearSegmentParameter.Reflection(sb);
                    sb.AppendLine("</linearSegmentParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</LinearObjectStatePdu>");
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
            return this == obj as LinearObjectStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LinearObjectStatePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._objectID.Equals(obj._objectID))
            {
                ivarsEqual = false;
            }

            if (!this._referencedObjectID.Equals(obj._referencedObjectID))
            {
                ivarsEqual = false;
            }

            if (this._updateNumber != obj._updateNumber)
            {
                ivarsEqual = false;
            }

            if (this._forceID != obj._forceID)
            {
                ivarsEqual = false;
            }

            if (this._numberOfSegments != obj._numberOfSegments)
            {
                ivarsEqual = false;
            }

            if (!this._requesterID.Equals(obj._requesterID))
            {
                ivarsEqual = false;
            }

            if (!this._receivingID.Equals(obj._receivingID))
            {
                ivarsEqual = false;
            }

            if (!this._objectType.Equals(obj._objectType))
            {
                ivarsEqual = false;
            }

            if (this._linearSegmentParameters.Count != obj._linearSegmentParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._linearSegmentParameters.Count; idx++)
                {
                    if (!this._linearSegmentParameters[idx].Equals(obj._linearSegmentParameters[idx]))
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

            result = GenerateHash(result) ^ this._objectID.GetHashCode();
            result = GenerateHash(result) ^ this._referencedObjectID.GetHashCode();
            result = GenerateHash(result) ^ this._updateNumber.GetHashCode();
            result = GenerateHash(result) ^ this._forceID.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfSegments.GetHashCode();
            result = GenerateHash(result) ^ this._requesterID.GetHashCode();
            result = GenerateHash(result) ^ this._receivingID.GetHashCode();
            result = GenerateHash(result) ^ this._objectType.GetHashCode();

            if (this._linearSegmentParameters.Count > 0)
            {
                for (int idx = 0; idx < this._linearSegmentParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._linearSegmentParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
