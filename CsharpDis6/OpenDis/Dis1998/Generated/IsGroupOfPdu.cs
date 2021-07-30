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
    /// Section 5.3.9.2 Information about a particular group of entities grouped together for the purposes of netowrk bandwidth
    ///        reduction or aggregation. Needs manual cleanup. The GED size requires a database lookup. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class IsGroupOfPdu : EntityManagementFamilyPdu, IEquatable<IsGroupOfPdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsGroupOfPdu"/> class.
        /// </summary>
        public IsGroupOfPdu()
        {
            PduType = 34;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IsGroupOfPdu left, IsGroupOfPdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(IsGroupOfPdu left, IsGroupOfPdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += GroupEntityID.GetMarshalledSize();  // this._groupEntityID
            marshalSize += 1;  // this._groupedEntityCategory
            marshalSize += 1;  // this._numberOfGroupedEntities
            marshalSize += 4;  // this._pad2
            marshalSize += 8;  // this._latitude
            marshalSize += 8;  // this._longitude
            for (int idx = 0; idx < GroupedEntityDescriptions.Count; idx++)
            {
                var listElement = GroupedEntityDescriptions[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "groupEntityID")]
        public EntityID GroupEntityID { get; set; } = new EntityID();

        /// <summary>
        /// Gets or sets the type of entities constituting the group
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "groupedEntityCategory")]
        public byte GroupedEntityCategory { get; set; }

        /// <summary>
        /// Gets or sets the Number of individual entities constituting the group
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfGroupedEntities method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfGroupedEntities")]
        public byte NumberOfGroupedEntities { get; set; }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "pad2")]
        public uint Pad2 { get; set; }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets the GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find
        /// the actual size of the list elements
        /// </summary>
        [XmlElement(ElementName = "groupedEntityDescriptionsList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> GroupedEntityDescriptions { get; } = new();

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
                    GroupEntityID.Marshal(dos);
                    dos.WriteUnsignedByte(GroupedEntityCategory);
                    dos.WriteUnsignedByte((byte)GroupedEntityDescriptions.Count);
                    dos.WriteUnsignedInt(Pad2);
                    dos.WriteDouble((double)Latitude);
                    dos.WriteDouble((double)Longitude);

                    for (int idx = 0; idx < GroupedEntityDescriptions.Count; idx++)
                    {
                        var aVariableDatum = GroupedEntityDescriptions[idx];
                        aVariableDatum.Marshal(dos);
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
                    GroupEntityID.Unmarshal(dis);
                    GroupedEntityCategory = dis.ReadUnsignedByte();
                    NumberOfGroupedEntities = dis.ReadUnsignedByte();
                    Pad2 = dis.ReadUnsignedInt();
                    Latitude = dis.ReadDouble();
                    Longitude = dis.ReadDouble();

                    for (int idx = 0; idx < NumberOfGroupedEntities; idx++)
                    {
                        var anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        GroupedEntityDescriptions.Add(anX);
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
            sb.AppendLine("<IsGroupOfPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<groupEntityID>");
                GroupEntityID.Reflection(sb);
                sb.AppendLine("</groupEntityID>");
                sb.AppendLine("<groupedEntityCategory type=\"byte\">" + GroupedEntityCategory.ToString(CultureInfo.InvariantCulture) + "</groupedEntityCategory>");
                sb.AppendLine("<groupedEntityDescriptions type=\"byte\">" + GroupedEntityDescriptions.Count.ToString(CultureInfo.InvariantCulture) + "</groupedEntityDescriptions>");
                sb.AppendLine("<pad2 type=\"uint\">" + Pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<latitude type=\"double\">" + Latitude.ToString(CultureInfo.InvariantCulture) + "</latitude>");
                sb.AppendLine("<longitude type=\"double\">" + Longitude.ToString(CultureInfo.InvariantCulture) + "</longitude>");
                for (int idx = 0; idx < GroupedEntityDescriptions.Count; idx++)
                {
                    sb.AppendLine("<groupedEntityDescriptions" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    var aVariableDatum = GroupedEntityDescriptions[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</groupedEntityDescriptions" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IsGroupOfPdu>");
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
        public override bool Equals(object obj) => this == obj as IsGroupOfPdu;

        ///<inheritdoc/>
        public bool Equals(IsGroupOfPdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (!GroupEntityID.Equals(obj.GroupEntityID))
            {
                ivarsEqual = false;
            }

            if (GroupedEntityCategory != obj.GroupedEntityCategory)
            {
                ivarsEqual = false;
            }

            if (NumberOfGroupedEntities != obj.NumberOfGroupedEntities)
            {
                ivarsEqual = false;
            }

            if (Pad2 != obj.Pad2)
            {
                ivarsEqual = false;
            }

            if (Latitude != obj.Latitude)
            {
                ivarsEqual = false;
            }

            if (Longitude != obj.Longitude)
            {
                ivarsEqual = false;
            }

            if (GroupedEntityDescriptions.Count != obj.GroupedEntityDescriptions.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < GroupedEntityDescriptions.Count; idx++)
                {
                    if (!GroupedEntityDescriptions[idx].Equals(obj.GroupedEntityDescriptions[idx]))
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

            result = GenerateHash(result) ^ GroupEntityID.GetHashCode();
            result = GenerateHash(result) ^ GroupedEntityCategory.GetHashCode();
            result = GenerateHash(result) ^ NumberOfGroupedEntities.GetHashCode();
            result = GenerateHash(result) ^ Pad2.GetHashCode();
            result = GenerateHash(result) ^ Latitude.GetHashCode();
            result = GenerateHash(result) ^ Longitude.GetHashCode();

            if (GroupedEntityDescriptions.Count > 0)
            {
                for (int idx = 0; idx < GroupedEntityDescriptions.Count; idx++)
                {
                    result = GenerateHash(result) ^ GroupedEntityDescriptions[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
