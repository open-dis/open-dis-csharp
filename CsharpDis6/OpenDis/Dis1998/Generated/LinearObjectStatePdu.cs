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
    /// Section 5.3.11.4: Information abut the addition or modification of a synthecic enviroment object that     is anchored
    /// to the terrain with a single point and has size or orientation. COMPLETE
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
        /// Initializes a new instance of the <see cref="LinearObjectStatePdu"/> class.
        /// </summary>
        public LinearObjectStatePdu()
        {
            PduType = 44;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(LinearObjectStatePdu left, LinearObjectStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(LinearObjectStatePdu left, LinearObjectStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += ObjectID.GetMarshalledSize();  // this._objectID
            marshalSize += ReferencedObjectID.GetMarshalledSize();  // this._referencedObjectID
            marshalSize += 2;  // this._updateNumber
            marshalSize += 1;  // this._forceID
            marshalSize += 1;  // this._numberOfSegments
            marshalSize += RequesterID.GetMarshalledSize();  // this._requesterID
            marshalSize += ReceivingID.GetMarshalledSize();  // this._receivingID
            marshalSize += ObjectType.GetMarshalledSize();  // this._objectType
            for (int idx = 0; idx < LinearSegmentParameters.Count; idx++)
            {
                var listElement = LinearSegmentParameters[idx];
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
        /// Gets or sets the number of linear segment parameters
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfSegments method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfSegments")]
        public byte NumberOfSegments { get; set; }

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
        /// Gets or sets the Object type
        /// </summary>
        [XmlElement(Type = typeof(ObjectType), ElementName = "objectType")]
        public ObjectType ObjectType { get; set; } = new ObjectType();

        /// <summary>
        /// Gets the Linear segment parameters
        /// </summary>
        [XmlElement(ElementName = "linearSegmentParametersList", Type = typeof(List<LinearSegmentParameter>))]
        public List<LinearSegmentParameter> LinearSegmentParameters { get; } = new();

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
                    dos.WriteUnsignedByte((byte)LinearSegmentParameters.Count);
                    RequesterID.Marshal(dos);
                    ReceivingID.Marshal(dos);
                    ObjectType.Marshal(dos);

                    for (int idx = 0; idx < LinearSegmentParameters.Count; idx++)
                    {
                        var aLinearSegmentParameter = LinearSegmentParameters[idx];
                        aLinearSegmentParameter.Marshal(dos);
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
                    NumberOfSegments = dis.ReadUnsignedByte();
                    RequesterID.Unmarshal(dis);
                    ReceivingID.Unmarshal(dis);
                    ObjectType.Unmarshal(dis);

                    for (int idx = 0; idx < NumberOfSegments; idx++)
                    {
                        var anX = new LinearSegmentParameter();
                        anX.Unmarshal(dis);
                        LinearSegmentParameters.Add(anX);
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
            sb.AppendLine("<LinearObjectStatePdu>");
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
                sb.AppendLine("<linearSegmentParameters type=\"byte\">" + LinearSegmentParameters.Count.ToString(CultureInfo.InvariantCulture) + "</linearSegmentParameters>");
                sb.AppendLine("<requesterID>");
                RequesterID.Reflection(sb);
                sb.AppendLine("</requesterID>");
                sb.AppendLine("<receivingID>");
                ReceivingID.Reflection(sb);
                sb.AppendLine("</receivingID>");
                sb.AppendLine("<objectType>");
                ObjectType.Reflection(sb);
                sb.AppendLine("</objectType>");
                for (int idx = 0; idx < LinearSegmentParameters.Count; idx++)
                {
                    sb.AppendLine("<linearSegmentParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"LinearSegmentParameter\">");
                    var aLinearSegmentParameter = LinearSegmentParameters[idx];
                    aLinearSegmentParameter.Reflection(sb);
                    sb.AppendLine("</linearSegmentParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</LinearObjectStatePdu>");
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
        public override bool Equals(object obj) => this == obj as LinearObjectStatePdu;

        ///<inheritdoc/>
        public bool Equals(LinearObjectStatePdu obj)
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

            if (NumberOfSegments != obj.NumberOfSegments)
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

            if (!ObjectType.Equals(obj.ObjectType))
            {
                ivarsEqual = false;
            }

            if (LinearSegmentParameters.Count != obj.LinearSegmentParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < LinearSegmentParameters.Count; idx++)
                {
                    if (!LinearSegmentParameters[idx].Equals(obj.LinearSegmentParameters[idx]))
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
            result = GenerateHash(result) ^ NumberOfSegments.GetHashCode();
            result = GenerateHash(result) ^ RequesterID.GetHashCode();
            result = GenerateHash(result) ^ ReceivingID.GetHashCode();
            result = GenerateHash(result) ^ ObjectType.GetHashCode();

            if (LinearSegmentParameters.Count > 0)
            {
                for (int idx = 0; idx < LinearSegmentParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ LinearSegmentParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
