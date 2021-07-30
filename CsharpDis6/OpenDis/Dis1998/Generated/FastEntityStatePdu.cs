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
    /// Section 5.3.3.1. Represents the postion and state of one entity in the world. This is identical in function to
    /// entity state pdu, but generates less garbage to collect in the Java world. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class FastEntityStatePdu : EntityInformationFamilyPdu, IEquatable<FastEntityStatePdu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FastEntityStatePdu"/> class.
        /// </summary>
        public FastEntityStatePdu()
        {
            PduType = 1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FastEntityStatePdu left, FastEntityStatePdu right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(FastEntityStatePdu left, FastEntityStatePdu right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public override int GetMarshalledSize()
        {
            int marshalSize = base.GetMarshalledSize();
            marshalSize += 2;  // this._site
            marshalSize += 2;  // this._application
            marshalSize += 2;  // this._entity
            marshalSize += 1;  // this._forceId
            marshalSize += 1;  // this._numberOfArticulationParameters
            marshalSize += 1;  // this._entityKind
            marshalSize += 1;  // this._domain
            marshalSize += 2;  // this._country
            marshalSize += 1;  // this._category
            marshalSize += 1;  // this._subcategory
            marshalSize += 1;  // this._specific
            marshalSize += 1;  // this._extra
            marshalSize += 1;  // this._altEntityKind
            marshalSize += 1;  // this._altDomain
            marshalSize += 2;  // this._altCountry
            marshalSize += 1;  // this._altCategory
            marshalSize += 1;  // this._altSubcategory
            marshalSize += 1;  // this._altSpecific
            marshalSize += 1;  // this._altExtra
            marshalSize += 4;  // this._xVelocity
            marshalSize += 4;  // this._yVelocity
            marshalSize += 4;  // this._zVelocity
            marshalSize += 8;  // this._xLocation
            marshalSize += 8;  // this._yLocation
            marshalSize += 8;  // this._zLocation
            marshalSize += 4;  // this._psi
            marshalSize += 4;  // this._theta
            marshalSize += 4;  // this._phi
            marshalSize += 4;  // this._entityAppearance
            marshalSize += 1;  // this._deadReckoningAlgorithm
            marshalSize += 15 * 1;  // _otherParameters
            marshalSize += 4;  // this._xAcceleration
            marshalSize += 4;  // this._yAcceleration
            marshalSize += 4;  // this._zAcceleration
            marshalSize += 4;  // this._xAngularVelocity
            marshalSize += 4;  // this._yAngularVelocity
            marshalSize += 4;  // this._zAngularVelocity
            marshalSize += 12 * 1;  // _marking
            marshalSize += 4;  // this._capabilities
            for (int idx = 0; idx < ArticulationParameters.Count; idx++)
            {
                var listElement = ArticulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the site ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "site")]
        public ushort Site { get; set; }

        /// <summary>
        /// Gets or sets the application ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "application")]
        public ushort Application { get; set; }

        /// <summary>
        /// Gets or sets the entity ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "entity")]
        public ushort Entity { get; set; }

        /// <summary>
        /// Gets or sets the what force this entity is affiliated with, eg red, blue, neutral, etc
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceId")]
        public byte ForceId { get; set; }

        /// <summary>
        /// Gets or sets the How many articulation parameters are in the variable length list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used
        /// for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value.
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters { get; set; }

        /// <summary>
        /// Gets or sets the Kind of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "entityKind")]
        public byte EntityKind { get; set; }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "domain")]
        public byte Domain { get; set; }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "country")]
        public ushort Country { get; set; }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "category")]
        public byte Category { get; set; }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "subcategory")]
        public byte Subcategory { get; set; }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "specific")]
        public byte Specific { get; set; }

        /// <summary>
        /// Gets or sets the extra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "extra")]
        public byte Extra { get; set; }

        /// <summary>
        /// Gets or sets the Kind of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altEntityKind")]
        public byte AltEntityKind { get; set; }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altDomain")]
        public byte AltDomain { get; set; }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "altCountry")]
        public ushort AltCountry { get; set; }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altCategory")]
        public byte AltCategory { get; set; }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altSubcategory")]
        public byte AltSubcategory { get; set; }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altSpecific")]
        public byte AltSpecific { get; set; }

        /// <summary>
        /// Gets or sets the altExtra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altExtra")]
        public byte AltExtra { get; set; }

        /// <summary>
        /// Gets or sets the X velo
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xVelocity")]
        public float XVelocity { get; set; }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yVelocity")]
        public float YVelocity { get; set; }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zVelocity")]
        public float ZVelocity { get; set; }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "xLocation")]
        public double XLocation { get; set; }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "yLocation")]
        public double YLocation { get; set; }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "zLocation")]
        public double ZLocation { get; set; }

        /// <summary>
        /// Gets or sets the psi
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "psi")]
        public float Psi { get; set; }

        /// <summary>
        /// Gets or sets theta
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "theta")]
        public float Theta { get; set; }

        /// <summary>
        /// Gets or sets the phi
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "phi")]
        public float Phi { get; set; }

        /// <summary>
        /// Gets or sets the a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
        public int EntityAppearance { get; set; }

        /// <summary>
        /// Gets or sets the enumeration of what dead reckoning algorighm to use
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the other parameters to use in the dead reckoning algorithm
        /// </summary>
        [XmlArray(ElementName = "otherParameters")]
        public byte[] OtherParameters { get; set; } = new byte[15];

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xAcceleration")]
        public float XAcceleration { get; set; }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yAcceleration")]
        public float YAcceleration { get; set; }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zAcceleration")]
        public float ZAcceleration { get; set; }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xAngularVelocity")]
        public float XAngularVelocity { get; set; }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yAngularVelocity")]
        public float YAngularVelocity { get; set; }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zAngularVelocity")]
        public float ZAngularVelocity { get; set; }

        /// <summary>
        /// Gets or sets the characters that can be used for debugging, or to draw unique strings on the side of entities in
        /// the world
        /// </summary>
        [XmlArray(ElementName = "marking")]
        public byte[] Marking { get; set; } = new byte[12];

        /// <summary>
        /// Gets or sets the a series of bit flags
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "capabilities")]
        public int Capabilities { get; set; }

        /// <summary>
        /// Gets the variable length list of articulation parameters
        /// </summary>
        [XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters { get; } = new();

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
                    dos.WriteUnsignedShort(Site);
                    dos.WriteUnsignedShort(Application);
                    dos.WriteUnsignedShort(Entity);
                    dos.WriteUnsignedByte(ForceId);
                    dos.WriteByte((byte)ArticulationParameters.Count);
                    dos.WriteUnsignedByte(EntityKind);
                    dos.WriteUnsignedByte(Domain);
                    dos.WriteUnsignedShort(Country);
                    dos.WriteUnsignedByte(Category);
                    dos.WriteUnsignedByte(Subcategory);
                    dos.WriteUnsignedByte(Specific);
                    dos.WriteUnsignedByte(Extra);
                    dos.WriteUnsignedByte(AltEntityKind);
                    dos.WriteUnsignedByte(AltDomain);
                    dos.WriteUnsignedShort(AltCountry);
                    dos.WriteUnsignedByte(AltCategory);
                    dos.WriteUnsignedByte(AltSubcategory);
                    dos.WriteUnsignedByte(AltSpecific);
                    dos.WriteUnsignedByte(AltExtra);
                    dos.WriteFloat((float)XVelocity);
                    dos.WriteFloat((float)YVelocity);
                    dos.WriteFloat((float)ZVelocity);
                    dos.WriteDouble((double)XLocation);
                    dos.WriteDouble((double)YLocation);
                    dos.WriteDouble(ZLocation);
                    dos.WriteFloat((float)Psi);
                    dos.WriteFloat((float)Theta);
                    dos.WriteFloat(Phi);
                    dos.WriteInt(EntityAppearance);
                    dos.WriteUnsignedByte(DeadReckoningAlgorithm);

                    for (int idx = 0; idx < OtherParameters.Length; idx++)
                    {
                        dos.WriteByte(OtherParameters[idx]);
                    }

                    dos.WriteFloat((float)XAcceleration);
                    dos.WriteFloat((float)YAcceleration);
                    dos.WriteFloat((float)ZAcceleration);
                    dos.WriteFloat((float)XAngularVelocity);
                    dos.WriteFloat((float)YAngularVelocity);
                    dos.WriteFloat((float)ZAngularVelocity);

                    for (int idx = 0; idx < Marking.Length; idx++)
                    {
                        dos.WriteByte(Marking[idx]);
                    }

                    dos.WriteInt(Capabilities);

                    for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                    {
                        var aArticulationParameter = ArticulationParameters[idx];
                        aArticulationParameter.Marshal(dos);
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
                    Site = dis.ReadUnsignedShort();
                    Application = dis.ReadUnsignedShort();
                    Entity = dis.ReadUnsignedShort();
                    ForceId = dis.ReadUnsignedByte();
                    NumberOfArticulationParameters = dis.ReadByte();
                    EntityKind = dis.ReadUnsignedByte();
                    Domain = dis.ReadUnsignedByte();
                    Country = dis.ReadUnsignedShort();
                    Category = dis.ReadUnsignedByte();
                    Subcategory = dis.ReadUnsignedByte();
                    Specific = dis.ReadUnsignedByte();
                    Extra = dis.ReadUnsignedByte();
                    AltEntityKind = dis.ReadUnsignedByte();
                    AltDomain = dis.ReadUnsignedByte();
                    AltCountry = dis.ReadUnsignedShort();
                    AltCategory = dis.ReadUnsignedByte();
                    AltSubcategory = dis.ReadUnsignedByte();
                    AltSpecific = dis.ReadUnsignedByte();
                    AltExtra = dis.ReadUnsignedByte();
                    XVelocity = dis.ReadFloat();
                    YVelocity = dis.ReadFloat();
                    ZVelocity = dis.ReadFloat();
                    XLocation = dis.ReadDouble();
                    YLocation = dis.ReadDouble();
                    ZLocation = dis.ReadDouble();
                    Psi = dis.ReadFloat();
                    Theta = dis.ReadFloat();
                    Phi = dis.ReadFloat();
                    EntityAppearance = dis.ReadInt();
                    DeadReckoningAlgorithm = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < OtherParameters.Length; idx++)
                    {
                        OtherParameters[idx] = dis.ReadByte();
                    }

                    XAcceleration = dis.ReadFloat();
                    YAcceleration = dis.ReadFloat();
                    ZAcceleration = dis.ReadFloat();
                    XAngularVelocity = dis.ReadFloat();
                    YAngularVelocity = dis.ReadFloat();
                    ZAngularVelocity = dis.ReadFloat();

                    for (int idx = 0; idx < Marking.Length; idx++)
                    {
                        Marking[idx] = dis.ReadByte();
                    }

                    Capabilities = dis.ReadInt();

                    for (int idx = 0; idx < NumberOfArticulationParameters; idx++)
                    {
                        var anX = new ArticulationParameter();
                        anX.Unmarshal(dis);
                        ArticulationParameters.Add(anX);
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
            sb.AppendLine("<FastEntityStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<site type=\"ushort\">" + Site.ToString(CultureInfo.InvariantCulture) + "</site>");
                sb.AppendLine("<application type=\"ushort\">" + Application.ToString(CultureInfo.InvariantCulture) + "</application>");
                sb.AppendLine("<entity type=\"ushort\">" + Entity.ToString(CultureInfo.InvariantCulture) + "</entity>");
                sb.AppendLine("<forceId type=\"byte\">" + ForceId.ToString(CultureInfo.InvariantCulture) + "</forceId>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + ArticulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<entityKind type=\"byte\">" + EntityKind.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
                sb.AppendLine("<domain type=\"byte\">" + Domain.ToString(CultureInfo.InvariantCulture) + "</domain>");
                sb.AppendLine("<country type=\"ushort\">" + Country.ToString(CultureInfo.InvariantCulture) + "</country>");
                sb.AppendLine("<category type=\"byte\">" + Category.ToString(CultureInfo.InvariantCulture) + "</category>");
                sb.AppendLine("<subcategory type=\"byte\">" + Subcategory.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
                sb.AppendLine("<specific type=\"byte\">" + Specific.ToString(CultureInfo.InvariantCulture) + "</specific>");
                sb.AppendLine("<extra type=\"byte\">" + Extra.ToString(CultureInfo.InvariantCulture) + "</extra>");
                sb.AppendLine("<altEntityKind type=\"byte\">" + AltEntityKind.ToString(CultureInfo.InvariantCulture) + "</altEntityKind>");
                sb.AppendLine("<altDomain type=\"byte\">" + AltDomain.ToString(CultureInfo.InvariantCulture) + "</altDomain>");
                sb.AppendLine("<altCountry type=\"ushort\">" + AltCountry.ToString(CultureInfo.InvariantCulture) + "</altCountry>");
                sb.AppendLine("<altCategory type=\"byte\">" + AltCategory.ToString(CultureInfo.InvariantCulture) + "</altCategory>");
                sb.AppendLine("<altSubcategory type=\"byte\">" + AltSubcategory.ToString(CultureInfo.InvariantCulture) + "</altSubcategory>");
                sb.AppendLine("<altSpecific type=\"byte\">" + AltSpecific.ToString(CultureInfo.InvariantCulture) + "</altSpecific>");
                sb.AppendLine("<altExtra type=\"byte\">" + AltExtra.ToString(CultureInfo.InvariantCulture) + "</altExtra>");
                sb.AppendLine("<xVelocity type=\"float\">" + XVelocity.ToString(CultureInfo.InvariantCulture) + "</xVelocity>");
                sb.AppendLine("<yVelocity type=\"float\">" + YVelocity.ToString(CultureInfo.InvariantCulture) + "</yVelocity>");
                sb.AppendLine("<zVelocity type=\"float\">" + ZVelocity.ToString(CultureInfo.InvariantCulture) + "</zVelocity>");
                sb.AppendLine("<xLocation type=\"double\">" + XLocation.ToString(CultureInfo.InvariantCulture) + "</xLocation>");
                sb.AppendLine("<yLocation type=\"double\">" + YLocation.ToString(CultureInfo.InvariantCulture) + "</yLocation>");
                sb.AppendLine("<zLocation type=\"double\">" + ZLocation.ToString(CultureInfo.InvariantCulture) + "</zLocation>");
                sb.AppendLine("<psi type=\"float\">" + Psi.ToString(CultureInfo.InvariantCulture) + "</psi>");
                sb.AppendLine("<theta type=\"float\">" + Theta.ToString(CultureInfo.InvariantCulture) + "</theta>");
                sb.AppendLine("<phi type=\"float\">" + Phi.ToString(CultureInfo.InvariantCulture) + "</phi>");
                sb.AppendLine("<entityAppearance type=\"int\">" + EntityAppearance.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
                sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + DeadReckoningAlgorithm.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
                for (int idx = 0; idx < OtherParameters.Length; idx++)
                {
                    sb.AppendLine("<otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + OtherParameters[idx] + "</otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<xAcceleration type=\"float\">" + XAcceleration.ToString(CultureInfo.InvariantCulture) + "</xAcceleration>");
                sb.AppendLine("<yAcceleration type=\"float\">" + YAcceleration.ToString(CultureInfo.InvariantCulture) + "</yAcceleration>");
                sb.AppendLine("<zAcceleration type=\"float\">" + ZAcceleration.ToString(CultureInfo.InvariantCulture) + "</zAcceleration>");
                sb.AppendLine("<xAngularVelocity type=\"float\">" + XAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</xAngularVelocity>");
                sb.AppendLine("<yAngularVelocity type=\"float\">" + YAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</yAngularVelocity>");
                sb.AppendLine("<zAngularVelocity type=\"float\">" + ZAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</zAngularVelocity>");
                for (int idx = 0; idx < Marking.Length; idx++)
                {
                    sb.AppendLine("<marking" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + Marking[idx] + "</marking" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<capabilities type=\"int\">" + Capabilities.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    var aArticulationParameter = ArticulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</FastEntityStatePdu>");
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
        public override bool Equals(object obj) => this == obj as FastEntityStatePdu;

        ///<inheritdoc/>
        public bool Equals(FastEntityStatePdu obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            bool ivarsEqual = base.Equals(obj);
            if (Site != obj.Site)
            {
                ivarsEqual = false;
            }

            if (Application != obj.Application)
            {
                ivarsEqual = false;
            }

            if (Entity != obj.Entity)
            {
                ivarsEqual = false;
            }

            if (ForceId != obj.ForceId)
            {
                ivarsEqual = false;
            }

            if (NumberOfArticulationParameters != obj.NumberOfArticulationParameters)
            {
                ivarsEqual = false;
            }

            if (EntityKind != obj.EntityKind)
            {
                ivarsEqual = false;
            }

            if (Domain != obj.Domain)
            {
                ivarsEqual = false;
            }

            if (Country != obj.Country)
            {
                ivarsEqual = false;
            }

            if (Category != obj.Category)
            {
                ivarsEqual = false;
            }

            if (Subcategory != obj.Subcategory)
            {
                ivarsEqual = false;
            }

            if (Specific != obj.Specific)
            {
                ivarsEqual = false;
            }

            if (Extra != obj.Extra)
            {
                ivarsEqual = false;
            }

            if (AltEntityKind != obj.AltEntityKind)
            {
                ivarsEqual = false;
            }

            if (AltDomain != obj.AltDomain)
            {
                ivarsEqual = false;
            }

            if (AltCountry != obj.AltCountry)
            {
                ivarsEqual = false;
            }

            if (AltCategory != obj.AltCategory)
            {
                ivarsEqual = false;
            }

            if (AltSubcategory != obj.AltSubcategory)
            {
                ivarsEqual = false;
            }

            if (AltSpecific != obj.AltSpecific)
            {
                ivarsEqual = false;
            }

            if (AltExtra != obj.AltExtra)
            {
                ivarsEqual = false;
            }

            if (XVelocity != obj.XVelocity)
            {
                ivarsEqual = false;
            }

            if (YVelocity != obj.YVelocity)
            {
                ivarsEqual = false;
            }

            if (ZVelocity != obj.ZVelocity)
            {
                ivarsEqual = false;
            }

            if (XLocation != obj.XLocation)
            {
                ivarsEqual = false;
            }

            if (YLocation != obj.YLocation)
            {
                ivarsEqual = false;
            }

            if (ZLocation != obj.ZLocation)
            {
                ivarsEqual = false;
            }

            if (Psi != obj.Psi)
            {
                ivarsEqual = false;
            }

            if (Theta != obj.Theta)
            {
                ivarsEqual = false;
            }

            if (Phi != obj.Phi)
            {
                ivarsEqual = false;
            }

            if (EntityAppearance != obj.EntityAppearance)
            {
                ivarsEqual = false;
            }

            if (DeadReckoningAlgorithm != obj.DeadReckoningAlgorithm)
            {
                ivarsEqual = false;
            }

            if (obj.OtherParameters.Length != 15)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 15; idx++)
                {
                    if (OtherParameters[idx] != obj.OtherParameters[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (XAcceleration != obj.XAcceleration)
            {
                ivarsEqual = false;
            }

            if (YAcceleration != obj.YAcceleration)
            {
                ivarsEqual = false;
            }

            if (ZAcceleration != obj.ZAcceleration)
            {
                ivarsEqual = false;
            }

            if (XAngularVelocity != obj.XAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (YAngularVelocity != obj.YAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (ZAngularVelocity != obj.ZAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (obj.Marking.Length != 12)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 12; idx++)
                {
                    if (Marking[idx] != obj.Marking[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (Capabilities != obj.Capabilities)
            {
                ivarsEqual = false;
            }

            if (ArticulationParameters.Count != obj.ArticulationParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    if (!ArticulationParameters[idx].Equals(obj.ArticulationParameters[idx]))
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

            result = GenerateHash(result) ^ Site.GetHashCode();
            result = GenerateHash(result) ^ Application.GetHashCode();
            result = GenerateHash(result) ^ Entity.GetHashCode();
            result = GenerateHash(result) ^ ForceId.GetHashCode();
            result = GenerateHash(result) ^ NumberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ EntityKind.GetHashCode();
            result = GenerateHash(result) ^ Domain.GetHashCode();
            result = GenerateHash(result) ^ Country.GetHashCode();
            result = GenerateHash(result) ^ Category.GetHashCode();
            result = GenerateHash(result) ^ Subcategory.GetHashCode();
            result = GenerateHash(result) ^ Specific.GetHashCode();
            result = GenerateHash(result) ^ Extra.GetHashCode();
            result = GenerateHash(result) ^ AltEntityKind.GetHashCode();
            result = GenerateHash(result) ^ AltDomain.GetHashCode();
            result = GenerateHash(result) ^ AltCountry.GetHashCode();
            result = GenerateHash(result) ^ AltCategory.GetHashCode();
            result = GenerateHash(result) ^ AltSubcategory.GetHashCode();
            result = GenerateHash(result) ^ AltSpecific.GetHashCode();
            result = GenerateHash(result) ^ AltExtra.GetHashCode();
            result = GenerateHash(result) ^ XVelocity.GetHashCode();
            result = GenerateHash(result) ^ YVelocity.GetHashCode();
            result = GenerateHash(result) ^ ZVelocity.GetHashCode();
            result = GenerateHash(result) ^ XLocation.GetHashCode();
            result = GenerateHash(result) ^ YLocation.GetHashCode();
            result = GenerateHash(result) ^ ZLocation.GetHashCode();
            result = GenerateHash(result) ^ Psi.GetHashCode();
            result = GenerateHash(result) ^ Theta.GetHashCode();
            result = GenerateHash(result) ^ Phi.GetHashCode();
            result = GenerateHash(result) ^ EntityAppearance.GetHashCode();
            result = GenerateHash(result) ^ DeadReckoningAlgorithm.GetHashCode();

            for (int idx = 0; idx < 15; idx++)
            {
                result = GenerateHash(result) ^ OtherParameters[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ XAcceleration.GetHashCode();
            result = GenerateHash(result) ^ YAcceleration.GetHashCode();
            result = GenerateHash(result) ^ ZAcceleration.GetHashCode();
            result = GenerateHash(result) ^ XAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ YAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ ZAngularVelocity.GetHashCode();

            for (int idx = 0; idx < 12; idx++)
            {
                result = GenerateHash(result) ^ Marking[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ Capabilities.GetHashCode();

            if (ArticulationParameters.Count > 0)
            {
                for (int idx = 0; idx < ArticulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ ArticulationParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
