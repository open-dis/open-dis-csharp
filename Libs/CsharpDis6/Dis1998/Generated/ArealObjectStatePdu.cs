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
    /// Section 5.3.11.5: Information about the addition/modification of an oobject that is geometrically      achored to the terrain with a set of three or more points that come to a closure. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(EntityType))]
    [XmlInclude(typeof(SixByteChunk))]
    [XmlInclude(typeof(SimulationAddress))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class ArealObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<ArealObjectStatePdu>
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
        /// modifications enumeration
        /// </summary>
        private byte _modifications;

        /// <summary>
        /// Object type
        /// </summary>
        private EntityType _objectType = new EntityType();

        /// <summary>
        /// Object appearance
        /// </summary>
        private SixByteChunk _objectAppearance = new SixByteChunk();

        /// <summary>
        /// Number of points
        /// </summary>
        private ushort _numberOfPoints;

        /// <summary>
        /// requesterID
        /// </summary>
        private SimulationAddress _requesterID = new SimulationAddress();

        /// <summary>
        /// receiver ID
        /// </summary>
        private SimulationAddress _receivingID = new SimulationAddress();

        /// <summary>
        /// location of object
        /// </summary>
        private List<Vector3Double> _objectLocation = new List<Vector3Double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArealObjectStatePdu"/> class.
        /// </summary>
        public ArealObjectStatePdu()
        {
            PduType = (byte)45;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ArealObjectStatePdu left, ArealObjectStatePdu right)
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
        public static bool operator ==(ArealObjectStatePdu left, ArealObjectStatePdu right)
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
            marshalSize += this._objectAppearance.GetMarshalledSize();  // this._objectAppearance
            marshalSize += 2;  // this._numberOfPoints
            marshalSize += this._requesterID.GetMarshalledSize();  // this._requesterID
            marshalSize += this._receivingID.GetMarshalledSize();  // this._receivingID
            for (int idx = 0; idx < this._objectLocation.Count; idx++)
            {
                Vector3Double listElement = (Vector3Double)this._objectLocation[idx];
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
        /// Gets or sets the modifications enumeration
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
        [XmlElement(Type = typeof(EntityType), ElementName = "objectType")]
        public EntityType ObjectType
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
        /// Gets or sets the Object appearance
        /// </summary>
        [XmlElement(Type = typeof(SixByteChunk), ElementName = "objectAppearance")]
        public SixByteChunk ObjectAppearance
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
        /// Gets or sets the Number of points
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfPoints method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfPoints")]
        public ushort NumberOfPoints
        {
            get
            {
                return this._numberOfPoints;
            }

            set
            {
                this._numberOfPoints = value;
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
        /// Gets the location of object
        /// </summary>
        [XmlElement(ElementName = "objectLocationList", Type = typeof(List<Vector3Double>))]
        public List<Vector3Double> ObjectLocation
        {
            get
            {
                return this._objectLocation;
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
                    this._objectAppearance.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._objectLocation.Count);
                    this._requesterID.Marshal(dos);
                    this._receivingID.Marshal(dos);

                    for (int idx = 0; idx < this._objectLocation.Count; idx++)
                    {
                        Vector3Double aVector3Double = (Vector3Double)this._objectLocation[idx];
                        aVector3Double.Marshal(dos);
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
                    this._modifications = dis.ReadUnsignedByte();
                    this._objectType.Unmarshal(dis);
                    this._objectAppearance.Unmarshal(dis);
                    this._numberOfPoints = dis.ReadUnsignedShort();
                    this._requesterID.Unmarshal(dis);
                    this._receivingID.Unmarshal(dis);

                    for (int idx = 0; idx < this.NumberOfPoints; idx++)
                    {
                        Vector3Double anX = new Vector3Double();
                        anX.Unmarshal(dis);
                        this._objectLocation.Add(anX);
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
            sb.AppendLine("<ArealObjectStatePdu>");
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
                sb.AppendLine("<objectAppearance>");
                this._objectAppearance.Reflection(sb);
                sb.AppendLine("</objectAppearance>");
                sb.AppendLine("<objectLocation type=\"ushort\">" + this._objectLocation.Count.ToString(CultureInfo.InvariantCulture) + "</objectLocation>");
                sb.AppendLine("<requesterID>");
                this._requesterID.Reflection(sb);
                sb.AppendLine("</requesterID>");
                sb.AppendLine("<receivingID>");
                this._receivingID.Reflection(sb);
                sb.AppendLine("</receivingID>");
                for (int idx = 0; idx < this._objectLocation.Count; idx++)
                {
                    sb.AppendLine("<objectLocation" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Double\">");
                    Vector3Double aVector3Double = (Vector3Double)this._objectLocation[idx];
                    aVector3Double.Reflection(sb);
                    sb.AppendLine("</objectLocation" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ArealObjectStatePdu>");
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
            return this == obj as ArealObjectStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ArealObjectStatePdu obj)
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

            if (!this._objectAppearance.Equals(obj._objectAppearance))
            {
                ivarsEqual = false;
            }

            if (this._numberOfPoints != obj._numberOfPoints)
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

            if (this._objectLocation.Count != obj._objectLocation.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._objectLocation.Count; idx++)
                {
                    if (!this._objectLocation[idx].Equals(obj._objectLocation[idx]))
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
            result = GenerateHash(result) ^ this._modifications.GetHashCode();
            result = GenerateHash(result) ^ this._objectType.GetHashCode();
            result = GenerateHash(result) ^ this._objectAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfPoints.GetHashCode();
            result = GenerateHash(result) ^ this._requesterID.GetHashCode();
            result = GenerateHash(result) ^ this._receivingID.GetHashCode();

            if (this._objectLocation.Count > 0)
            {
                for (int idx = 0; idx < this._objectLocation.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._objectLocation[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
