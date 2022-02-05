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
    /// Section 5.3.11.5: Information about the addition/modification of an oobject that is geometrically     achored to
    /// the terrain with a set of three or more points that come to a closure. COMPLETE
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
        /// Initializes a new instance of the <see cref="ArealObjectStatePdu"/> class.
        /// </summary>
        public ArealObjectStatePdu()
        {
            PduType = 45;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ArealObjectStatePdu left, ArealObjectStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ArealObjectStatePdu left, ArealObjectStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += ObjectID.GetMarshalledSize();  // this._objectID
            marshalSize += ReferencedObjectID.GetMarshalledSize();  // this._referencedObjectID
            marshalSize += 2;  // this._updateNumber
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._modifications
            marshalSize += ObjectType.GetMarshalledSize();  // this._objectType
            marshalSize += ObjectAppearance.GetMarshalledSize();  // this._objectAppearance
            marshalSize += 2;  // this._numberOfPoints
            marshalSize += RequesterID.GetMarshalledSize();  // this._requesterID
            marshalSize += ReceivingID.GetMarshalledSize();  // this._receivingID
            for (int idx = 0; idx < ObjectLocation.Count; idx++)
            {
                var listElement = ObjectLocation[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Object in synthetic environment
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
        public EntityID ObjectID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the Object with which this point object is associated
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
        public EntityID ReferencedObjectID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the unique update number of each state transition of an object
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
        public ushort UpdateNumber { get; set; }

        /// <summary>
        /// Gets or sets the force ID
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceID")]
        public byte ForceID { get; set; }

        /// <summary>
        /// Gets or sets the modifications enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "modifications")]
        public byte Modifications { get; set; }

        /// <summary>
        /// Gets or sets the Object type
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "objectType")]
        public EntityType ObjectType { get; set; } = new EntityType();

        /// <summary>
        /// Gets or sets the Object appearance
        /// </summary>
        [XmlElement(Type = typeof(SixByteChunk), ElementName = "objectAppearance")]
        public SixByteChunk ObjectAppearance { get; set; } = new();

        /// <summary>
        /// Gets or sets the Number of points
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfPoints method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfPoints")]
        public ushort NumberOfPoints { get; set; }

        /// <summary>
        /// Gets or sets the requesterID
        /// </summary>
        [XmlElement(Type = typeof(SimulationAddress), ElementName = "requesterID")]
        public SimulationAddress RequesterID { get; set; } = new SimulationAddress();

        /// <summary>
        /// Gets or sets the receiver ID
        /// </summary>
        [XmlElement(Type = typeof(SimulationAddress), ElementName = "receivingID")]
        public SimulationAddress ReceivingID { get; set; } = new SimulationAddress();

        /// <summary>
        /// Gets the location of object
        /// </summary>
        [XmlElement(ElementName = "objectLocationList", Type = typeof(List<Vector3Double>))]
        public List<Vector3Double> ObjectLocation { get; } = new();

        ///<inheritdoc/>
        public override void MarshalAutoLengthSet(DataOutputStream dos)
        {
            // Set the length prior to marshalling data
            Length = (ushort)GetMarshalledSize();
            Marshal(dos);
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Marshal(DataOutputStream dos)
        {
            base.Marshal(dos);
            if (dos != null)
            {
                try
                {
                    ObjectID.Marshal(dos);
                    ReferencedObjectID.Marshal(dos);
                    dos.WriteUnsignedShort(UpdateNumber);
                    dos.WriteUnsignedByte(ForceID);
                    dos.WriteUnsignedByte(Modifications);
                    ObjectType.Marshal(dos);
                    ObjectAppearance.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)ObjectLocation.Count);
                    RequesterID.Marshal(dos);
                    ReceivingID.Marshal(dos);

                    for (int idx = 0; idx < ObjectLocation.Count; idx++)
                    {
                        var aVector3Double = ObjectLocation[idx];
                        aVector3Double.Marshal(dos);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
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
                    ObjectID.Unmarshal(dis);
                    ReferencedObjectID.Unmarshal(dis);
                    UpdateNumber = dis.ReadUnsignedShort();
                    ForceID = dis.ReadUnsignedByte();
                    Modifications = dis.ReadUnsignedByte();
                    ObjectType.Unmarshal(dis);
                    ObjectAppearance.Unmarshal(dis);
                    NumberOfPoints = dis.ReadUnsignedShort();
                    RequesterID.Unmarshal(dis);
                    ReceivingID.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfPoints; idx++)
                    {
                        var anX = new Vector3Double();
                        anX.Unmarshal(dis);
                        ObjectLocation.Add(anX);
                    }
                }
                catch (Exception e)
                {
                    if (TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public override void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<ArealObjectStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<objectID>");
                ObjectID.Reflection(sb);
                sb.AppendLine("</objectID>");
                sb.AppendLine("<referencedObjectID>");
                ReferencedObjectID.Reflection(sb);
                sb.AppendLine("</referencedObjectID>");
                sb.AppendLine("<updateNumber type=\"ushort\">" + UpdateNumber.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
                sb.AppendLine("<forceID type=\"byte\">" + ForceID.ToString(CultureInfo.InvariantCulture) + "</forceID>");
                sb.AppendLine("<modifications type=\"byte\">" + Modifications.ToString(CultureInfo.InvariantCulture) + "</modifications>");
                sb.AppendLine("<objectType>");
                ObjectType.Reflection(sb);
                sb.AppendLine("</objectType>");
                sb.AppendLine("<objectAppearance>");
                ObjectAppearance.Reflection(sb);
                sb.AppendLine("</objectAppearance>");
                sb.AppendLine("<objectLocation type=\"ushort\">" + ObjectLocation.Count.ToString(CultureInfo.InvariantCulture) + "</objectLocation>");
                sb.AppendLine("<requesterID>");
                RequesterID.Reflection(sb);
                sb.AppendLine("</requesterID>");
                sb.AppendLine("<receivingID>");
                ReceivingID.Reflection(sb);
                sb.AppendLine("</receivingID>");
                for (int idx = 0; idx < ObjectLocation.Count; idx++)
                {
                    sb.AppendLine("<objectLocation" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Double\">");
                    var aVector3Double = ObjectLocation[idx];
                    aVector3Double.Reflection(sb);
                    sb.AppendLine("</objectLocation" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</ArealObjectStatePdu>");
            }
            catch (Exception e)
            {
                if (TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as ArealObjectStatePdu;

        ///<inheritdoc/>
        public bool Equals(ArealObjectStatePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!ObjectID.Equals(obj.ObjectID))
            {
                ivarsEqual = false;
            }

            if (!ReferencedObjectID.Equals(obj.ReferencedObjectID))
            {
                ivarsEqual = false;
            }

            if (UpdateNumber != obj.UpdateNumber)
            {
                ivarsEqual = false;
            }

            if (ForceID != obj.ForceID)
            {
                ivarsEqual = false;
            }

            if (Modifications != obj.Modifications)
            {
                ivarsEqual = false;
            }

            if (!ObjectType.Equals(obj.ObjectType))
            {
                ivarsEqual = false;
            }

            if (!ObjectAppearance.Equals(obj.ObjectAppearance))
            {
                ivarsEqual = false;
            }

            if (NumberOfPoints != obj.NumberOfPoints)
            {
                ivarsEqual = false;
            }

            if (!RequesterID.Equals(obj.RequesterID))
            {
                ivarsEqual = false;
            }

            if (!ReceivingID.Equals(obj.ReceivingID))
            {
                ivarsEqual = false;
            }

            if (ObjectLocation.Count != obj.ObjectLocation.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ObjectLocation.Count; idx++)
                {
                    if (!ObjectLocation[idx].Equals(obj.ObjectLocation[idx]))
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

            result = GenerateHash(result) ^ base.GetHashCode();

            result = GenerateHash(result) ^ ObjectID.GetHashCode();
            result = GenerateHash(result) ^ ReferencedObjectID.GetHashCode();
            result = GenerateHash(result) ^ UpdateNumber.GetHashCode();
            result = GenerateHash(result) ^ ForceID.GetHashCode();
            result = GenerateHash(result) ^ Modifications.GetHashCode();
            result = GenerateHash(result) ^ ObjectType.GetHashCode();
            result = GenerateHash(result) ^ ObjectAppearance.GetHashCode();
            result = GenerateHash(result) ^ NumberOfPoints.GetHashCode();
            result = GenerateHash(result) ^ RequesterID.GetHashCode();
            result = GenerateHash(result) ^ ReceivingID.GetHashCode();

            if (ObjectLocation.Count > 0)
            {
                for (int idx = 0; idx < ObjectLocation.Count; idx++)
                {
                    result = GenerateHash(result) ^ ObjectLocation[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
