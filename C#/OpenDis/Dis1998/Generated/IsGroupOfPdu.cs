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
    /// Section 5.3.9.2 Information about a particular group of entities grouped together for the purposes of netowrk bandwidth         reduction or aggregation. Needs manual cleanup. The GED size requires a database lookup. UNFINISHED
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(VariableDatum))]
    public partial class IsGroupOfPdu : EntityManagementFamilyPdu, IEquatable<IsGroupOfPdu>
    {
        /// <summary>
        /// ID of aggregated entities
        /// </summary>
        private EntityID _groupEntityID = new EntityID();

        /// <summary>
        /// type of entities constituting the group
        /// </summary>
        private byte _groupedEntityCategory;

        /// <summary>
        /// Number of individual entities constituting the group
        /// </summary>
        private byte _numberOfGroupedEntities;

        /// <summary>
        /// padding
        /// </summary>
        private uint _pad2;

        /// <summary>
        /// latitude
        /// </summary>
        private double _latitude;

        /// <summary>
        /// longitude
        /// </summary>
        private double _longitude;

        /// <summary>
        /// GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements
        /// </summary>
        private List<VariableDatum> _groupedEntityDescriptions = new List<VariableDatum>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IsGroupOfPdu"/> class.
        /// </summary>
        public IsGroupOfPdu()
        {
            PduType = (byte)34;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(IsGroupOfPdu left, IsGroupOfPdu right)
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
        public static bool operator ==(IsGroupOfPdu left, IsGroupOfPdu right)
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
            marshalSize += this._groupEntityID.GetMarshalledSize();  // this._groupEntityID
            marshalSize += 1;  // this._groupedEntityCategory
            marshalSize += 1;  // this._numberOfGroupedEntities
            marshalSize += 4;  // this._pad2
            marshalSize += 8;  // this._latitude
            marshalSize += 8;  // this._longitude
            for (int idx = 0; idx < this._groupedEntityDescriptions.Count; idx++)
            {
                VariableDatum listElement = (VariableDatum)this._groupedEntityDescriptions[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the ID of aggregated entities
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "groupEntityID")]
        public EntityID GroupEntityID
        {
            get
            {
                return this._groupEntityID;
            }

            set
            {
                this._groupEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of entities constituting the group
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "groupedEntityCategory")]
        public byte GroupedEntityCategory
        {
            get
            {
                return this._groupedEntityCategory;
            }

            set
            {
                this._groupedEntityCategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the Number of individual entities constituting the group
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfGroupedEntities method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfGroupedEntities")]
        public byte NumberOfGroupedEntities
        {
            get
            {
                return this._numberOfGroupedEntities;
            }

            set
            {
                this._numberOfGroupedEntities = value;
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
        /// Gets or sets the latitude
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "latitude")]
        public double Latitude
        {
            get
            {
                return this._latitude;
            }

            set
            {
                this._latitude = value;
            }
        }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "longitude")]
        public double Longitude
        {
            get
            {
                return this._longitude;
            }

            set
            {
                this._longitude = value;
            }
        }

        /// <summary>
        /// Gets the GED records about each individual entity in the group. ^^^this is wrong--need a database lookup to find the actual size of the list elements
        /// </summary>
        [XmlElement(ElementName = "groupedEntityDescriptionsList", Type = typeof(List<VariableDatum>))]
        public List<VariableDatum> GroupedEntityDescriptions
        {
            get
            {
                return this._groupedEntityDescriptions;
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
                    this._groupEntityID.Marshal(dos);
                    dos.WriteUnsignedByte((byte)this._groupedEntityCategory);
                    dos.WriteUnsignedByte((byte)this._groupedEntityDescriptions.Count);
                    dos.WriteUnsignedInt((uint)this._pad2);
                    dos.WriteDouble((double)this._latitude);
                    dos.WriteDouble((double)this._longitude);

                    for (int idx = 0; idx < this._groupedEntityDescriptions.Count; idx++)
                    {
                        VariableDatum aVariableDatum = (VariableDatum)this._groupedEntityDescriptions[idx];
                        aVariableDatum.Marshal(dos);
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
                    this._groupEntityID.Unmarshal(dis);
                    this._groupedEntityCategory = dis.ReadUnsignedByte();
                    this._numberOfGroupedEntities = dis.ReadUnsignedByte();
                    this._pad2 = dis.ReadUnsignedInt();
                    this._latitude = dis.ReadDouble();
                    this._longitude = dis.ReadDouble();

                    for (int idx = 0; idx < this.NumberOfGroupedEntities; idx++)
                    {
                        VariableDatum anX = new VariableDatum();
                        anX.Unmarshal(dis);
                        this._groupedEntityDescriptions.Add(anX);
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
            sb.AppendLine("<IsGroupOfPdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<groupEntityID>");
                this._groupEntityID.Reflection(sb);
                sb.AppendLine("</groupEntityID>");
                sb.AppendLine("<groupedEntityCategory type=\"byte\">" + this._groupedEntityCategory.ToString(CultureInfo.InvariantCulture) + "</groupedEntityCategory>");
                sb.AppendLine("<groupedEntityDescriptions type=\"byte\">" + this._groupedEntityDescriptions.Count.ToString(CultureInfo.InvariantCulture) + "</groupedEntityDescriptions>");
                sb.AppendLine("<pad2 type=\"uint\">" + this._pad2.ToString(CultureInfo.InvariantCulture) + "</pad2>");
                sb.AppendLine("<latitude type=\"double\">" + this._latitude.ToString(CultureInfo.InvariantCulture) + "</latitude>");
                sb.AppendLine("<longitude type=\"double\">" + this._longitude.ToString(CultureInfo.InvariantCulture) + "</longitude>");
                for (int idx = 0; idx < this._groupedEntityDescriptions.Count; idx++)
                {
                    sb.AppendLine("<groupedEntityDescriptions" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
                    VariableDatum aVariableDatum = (VariableDatum)this._groupedEntityDescriptions[idx];
                    aVariableDatum.Reflection(sb);
                    sb.AppendLine("</groupedEntityDescriptions" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</IsGroupOfPdu>");
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
            return this == obj as IsGroupOfPdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IsGroupOfPdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (!this._groupEntityID.Equals(obj._groupEntityID))
            {
                ivarsEqual = false;
            }

            if (this._groupedEntityCategory != obj._groupedEntityCategory)
            {
                ivarsEqual = false;
            }

            if (this._numberOfGroupedEntities != obj._numberOfGroupedEntities)
            {
                ivarsEqual = false;
            }

            if (this._pad2 != obj._pad2)
            {
                ivarsEqual = false;
            }

            if (this._latitude != obj._latitude)
            {
                ivarsEqual = false;
            }

            if (this._longitude != obj._longitude)
            {
                ivarsEqual = false;
            }

            if (this._groupedEntityDescriptions.Count != obj._groupedEntityDescriptions.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._groupedEntityDescriptions.Count; idx++)
                {
                    if (!this._groupedEntityDescriptions[idx].Equals(obj._groupedEntityDescriptions[idx]))
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

            result = GenerateHash(result) ^ this._groupEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._groupedEntityCategory.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfGroupedEntities.GetHashCode();
            result = GenerateHash(result) ^ this._pad2.GetHashCode();
            result = GenerateHash(result) ^ this._latitude.GetHashCode();
            result = GenerateHash(result) ^ this._longitude.GetHashCode();

            if (this._groupedEntityDescriptions.Count > 0)
            {
                for (int idx = 0; idx < this._groupedEntityDescriptions.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._groupedEntityDescriptions[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
