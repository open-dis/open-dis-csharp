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
    /// Section 5.3.11.3: Inormation abut the addition or modification of a synthecic enviroment object that is anchored      to the terrain with a single point. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(ObjectType))]
    [XmlInclude(typeof(Vector3Double))]
    [XmlInclude(typeof(Orientation))]
    [XmlInclude(typeof(SimulationAddress))]
    public partial class PointObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<PointObjectStatePdu>
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
        /// modifications
        /// </summary>
        private byte _modifications;

        /// <summary>
        /// Object type
        /// </summary>
        private ObjectType _objectType = new ObjectType();

        /// <summary>
        /// Object location
        /// </summary>
        private Vector3Double _objectLocation = new Vector3Double();

        /// <summary>
        /// Object orientation
        /// </summary>
        private Orientation _objectOrientation = new Orientation();

        /// <summary>
        /// Object apperance
        /// </summary>
        private double _objectAppearance;

        /// <summary>
        /// requesterID
        /// </summary>
        private SimulationAddress _requesterID = new SimulationAddress();

        /// <summary>
        /// receiver ID
        /// </summary>
        private SimulationAddress _receivingID = new SimulationAddress();

        /// <summary>
        /// padding
        /// </summary>
        private uint _pad2;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointObjectStatePdu"/> class.
        /// </summary>
        public PointObjectStatePdu()
        {
            PduType = (byte)43;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(PointObjectStatePdu left, PointObjectStatePdu right)
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
        public static bool operator ==(PointObjectStatePdu left, PointObjectStatePdu right)
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
            marshalSize += 1;  // this._modifications
            marshalSize += this._objectType.GetMarshalledSize();  // this._objectType
            marshalSize += this._objectLocation.GetMarshalledSize();  // this._objectLocation
            marshalSize += this._objectOrientation.GetMarshalledSize();  // this._objectOrientation
            marshalSize += 8;  // this._objectAppearance
            marshalSize += this._requesterID.GetMarshalledSize();  // this._requesterID
            marshalSize += this._receivingID.GetMarshalledSize();  // this._receivingID
            marshalSize += 4;  // this._pad2
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
        /// Gets or sets the modifications
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modifications")]
        public byte Modifications
        {
            get
            {
                return this._modifications;
            }

            set
            {
                this._modifications = value;
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
        /// Gets or sets the Object location
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "objectLocation")]
        public Vector3Double ObjectLocation
        {
            get
            {
                return this._objectLocation;
            }

            set
            {
                this._objectLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Object orientation
        /// </summary>
        [XmlElement(Type = typeof(Orientation), ElementName = "objectOrientation")]
        public Orientation ObjectOrientation
        {
            get
            {
                return this._objectOrientation;
            }

            set
            {
                this._objectOrientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Object apperance
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "objectAppearance")]
        public double ObjectAppearance
        {
            get
            {
                return this._objectAppearance;
            }

            set
            {
                this._objectAppearance = value;
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
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "pad2")]
        public uint Pad2
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
                    dos.WriteUnsignedByte((byte)this._modifications);
                    this._objectType.Marshal(dos);
                    this._objectLocation.Marshal(dos);
                    this._objectOrientation.Marshal(dos);
                    dos.WriteDouble((double)this._objectAppearance);
                    this._requesterID.Marshal(dos);
                    this._receivingID.Marshal(dos);
                    dos.WriteUnsignedInt((uint)this._pad2);
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
                    this._modifications = dis.ReadUnsignedByte();
                    this._objectType.Unmarshal(dis);
                    this._objectLocation.Unmarshal(dis);
                    this._objectOrientation.Unmarshal(dis);
                    this._objectAppearance = dis.ReadDouble();
                    this._requesterID.Unmarshal(dis);
                    this._receivingID.Unmarshal(dis);
                    this._pad2 = dis.ReadUnsignedInt();
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
            sb.AppendLine("<PointObjectStatePdu>");
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
                sb.AppendLine("<modifications type=\"byte\">" + this._modifications.ToString(CultureInfo.InvariantCulture) + "</modifications>");
                sb.AppendLine("<objectType>");
                this._objectType.Reflection(sb);
                sb.AppendLine("</objectType>");
                sb.AppendLine("<objectLocation>");
                this._objectLocation.Reflection(sb);
                sb.AppendLine("</objectLocation>");
                sb.AppendLine("<objectOrientation>");
                this._objectOrientation.Reflection(sb);
                sb.AppendLine("</objectOrientation>");
                sb.AppendLine("<objectAppearance type=\"double\">" + this._objectAppearance.ToString(CultureInfo.InvariantCulture) + "</objectAppearance>");
                sb.AppendLine("<requesterID>");
                this._requesterID.Reflection(sb);
                sb.AppendLine("</requesterID>");
                sb.AppendLine("<receivingID>");
                this._receivingID.Reflection(sb);
                sb.AppendLine("</receivingID>");
                sb.AppendLine("<pad2 type=\"uint\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("</PointObjectStatePdu>");
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
            return this == obj as PointObjectStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(PointObjectStatePdu obj)
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

            if (this._modifications != obj._modifications)
            {
                ivarsEqual = false;
            }

            if (!this._objectType.Equals(obj._objectType))
            {
                ivarsEqual = false;
            }

            if (!this._objectLocation.Equals(obj._objectLocation))
            {
                ivarsEqual = false;
            }

            if (!this._objectOrientation.Equals(obj._objectOrientation))
            {
                ivarsEqual = false;
            }

            if (this._objectAppearance != obj._objectAppearance)
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

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
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
            result = GenerateHash(result) ^ this._modifications.GetHashCode();
            result = GenerateHash(result) ^ this._objectType.GetHashCode();
            result = GenerateHash(result) ^ this._objectLocation.GetHashCode();
            result = GenerateHash(result) ^ this._objectOrientation.GetHashCode();
            result = GenerateHash(result) ^ this._objectAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._requesterID.GetHashCode();
            result = GenerateHash(result) ^ this._receivingID.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();

            return result;
        }
    }
}
