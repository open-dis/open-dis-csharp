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
    /// Section 5.3.3.1. Represents the postion and state of one entity in the world. This is identical in function to entity state pdu, but generates less garbage to collect in the Java world. COMPLETE
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(ArticulationParameter))]
    public partial class FastEntityStatePdu : EntityInformationFamilyPdu, IEquatable<FastEntityStatePdu>
    {
        /// <summary>
        /// The site ID
        /// </summary>
        private ushort _site;

        /// <summary>
        /// The application ID
        /// </summary>
        private ushort _application;

        /// <summary>
        /// the entity ID
        /// </summary>
        private ushort _entity;

        /// <summary>
        /// what force this entity is affiliated with, eg red, blue, neutral, etc
        /// </summary>
        private byte _forceId;

        /// <summary>
        /// How many articulation parameters are in the variable length list
        /// </summary>
        private byte _numberOfArticulationParameters;

        /// <summary>
        /// Kind of entity
        /// </summary>
        private byte _entityKind;

        /// <summary>
        /// Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        private byte _domain;

        /// <summary>
        /// country to which the design of the entity is attributed
        /// </summary>
        private ushort _country;

        /// <summary>
        /// category of entity
        /// </summary>
        private byte _category;

        /// <summary>
        /// subcategory of entity
        /// </summary>
        private byte _subcategory;

        /// <summary>
        /// specific info based on subcategory field
        /// </summary>
        private byte _specific;

        private byte _extra;

        /// <summary>
        /// Kind of entity
        /// </summary>
        private byte _altEntityKind;

        /// <summary>
        /// Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        private byte _altDomain;

        /// <summary>
        /// country to which the design of the entity is attributed
        /// </summary>
        private ushort _altCountry;

        /// <summary>
        /// category of entity
        /// </summary>
        private byte _altCategory;

        /// <summary>
        /// subcategory of entity
        /// </summary>
        private byte _altSubcategory;

        /// <summary>
        /// specific info based on subcategory field
        /// </summary>
        private byte _altSpecific;

        private byte _altExtra;

        /// <summary>
        /// X velo
        /// </summary>
        private float _xVelocity;

        /// <summary>
        /// y Value
        /// </summary>
        private float _yVelocity;

        /// <summary>
        /// Z value
        /// </summary>
        private float _zVelocity;

        /// <summary>
        /// X value
        /// </summary>
        private double _xLocation;

        /// <summary>
        /// y Value
        /// </summary>
        private double _yLocation;

        /// <summary>
        /// Z value
        /// </summary>
        private double _zLocation;

        private float _psi;

        private float _theta;

        private float _phi;

        /// <summary>
        /// a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        private int _entityAppearance;

        /// <summary>
        /// enumeration of what dead reckoning algorighm to use
        /// </summary>
        private byte _deadReckoningAlgorithm;

        /// <summary>
        /// other parameters to use in the dead reckoning algorithm
        /// </summary>
        private byte[] _otherParameters = new byte[15];

        /// <summary>
        /// X value
        /// </summary>
        private float _xAcceleration;

        /// <summary>
        /// y Value
        /// </summary>
        private float _yAcceleration;

        /// <summary>
        /// Z value
        /// </summary>
        private float _zAcceleration;

        /// <summary>
        /// X value
        /// </summary>
        private float _xAngularVelocity;

        /// <summary>
        /// y Value
        /// </summary>
        private float _yAngularVelocity;

        /// <summary>
        /// Z value
        /// </summary>
        private float _zAngularVelocity;

        /// <summary>
        /// characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        /// </summary>
        private byte[] _marking = new byte[12];

        /// <summary>
        /// a series of bit flags
        /// </summary>
        private int _capabilities;

        /// <summary>
        /// variable length list of articulation parameters
        /// </summary>
        private List<ArticulationParameter> _articulationParameters = new List<ArticulationParameter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FastEntityStatePdu"/> class.
        /// </summary>
        public FastEntityStatePdu()
        {
            PduType = (byte)1;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(FastEntityStatePdu left, FastEntityStatePdu right)
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
        public static bool operator ==(FastEntityStatePdu left, FastEntityStatePdu right)
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
            for (int idx = 0; idx < this._articulationParameters.Count; idx++)
            {
                ArticulationParameter listElement = (ArticulationParameter)this._articulationParameters[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the The site ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "site")]
        public ushort Site
        {
            get
            {
                return this._site;
            }

            set
            {
                this._site = value;
            }
        }

        /// <summary>
        /// Gets or sets the The application ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "application")]
        public ushort Application
        {
            get
            {
                return this._application;
            }

            set
            {
                this._application = value;
            }
        }

        /// <summary>
        /// Gets or sets the the entity ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "entity")]
        public ushort Entity
        {
            get
            {
                return this._entity;
            }

            set
            {
                this._entity = value;
            }
        }

        /// <summary>
        /// Gets or sets the what force this entity is affiliated with, eg red, blue, neutral, etc
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "forceId")]
        public byte ForceId
        {
            get
            {
                return this._forceId;
            }

            set
            {
                this._forceId = value;
            }
        }

        /// <summary>
        /// Gets or sets the How many articulation parameters are in the variable length list
        /// </summary>
        /// <remarks>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfArticulationParameters method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </remarks>
        [XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
        public byte NumberOfArticulationParameters
        {
            get
            {
                return this._numberOfArticulationParameters;
            }

            set
            {
                this._numberOfArticulationParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the Kind of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "entityKind")]
        public byte EntityKind
        {
            get
            {
                return this._entityKind;
            }

            set
            {
                this._entityKind = value;
            }
        }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "domain")]
        public byte Domain
        {
            get
            {
                return this._domain;
            }

            set
            {
                this._domain = value;
            }
        }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "country")]
        public ushort Country
        {
            get
            {
                return this._country;
            }

            set
            {
                this._country = value;
            }
        }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "category")]
        public byte Category
        {
            get
            {
                return this._category;
            }

            set
            {
                this._category = value;
            }
        }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "subcategory")]
        public byte Subcategory
        {
            get
            {
                return this._subcategory;
            }

            set
            {
                this._subcategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "specific")]
        public byte Specific
        {
            get
            {
                return this._specific;
            }

            set
            {
                this._specific = value;
            }
        }

        /// <summary>
        /// Gets or sets the extra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "extra")]
        public byte Extra
        {
            get
            {
                return this._extra;
            }

            set
            {
                this._extra = value;
            }
        }

        /// <summary>
        /// Gets or sets the Kind of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altEntityKind")]
        public byte AltEntityKind
        {
            get
            {
                return this._altEntityKind;
            }

            set
            {
                this._altEntityKind = value;
            }
        }

        /// <summary>
        /// Gets or sets the Domain of entity (air, surface, subsurface, space, etc)
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altDomain")]
        public byte AltDomain
        {
            get
            {
                return this._altDomain;
            }

            set
            {
                this._altDomain = value;
            }
        }

        /// <summary>
        /// Gets or sets the country to which the design of the entity is attributed
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "altCountry")]
        public ushort AltCountry
        {
            get
            {
                return this._altCountry;
            }

            set
            {
                this._altCountry = value;
            }
        }

        /// <summary>
        /// Gets or sets the category of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altCategory")]
        public byte AltCategory
        {
            get
            {
                return this._altCategory;
            }

            set
            {
                this._altCategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the subcategory of entity
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altSubcategory")]
        public byte AltSubcategory
        {
            get
            {
                return this._altSubcategory;
            }

            set
            {
                this._altSubcategory = value;
            }
        }

        /// <summary>
        /// Gets or sets the specific info based on subcategory field
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altSpecific")]
        public byte AltSpecific
        {
            get
            {
                return this._altSpecific;
            }

            set
            {
                this._altSpecific = value;
            }
        }

        /// <summary>
        /// Gets or sets the altExtra
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "altExtra")]
        public byte AltExtra
        {
            get
            {
                return this._altExtra;
            }

            set
            {
                this._altExtra = value;
            }
        }

        /// <summary>
        /// Gets or sets the X velo
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xVelocity")]
        public float XVelocity
        {
            get
            {
                return this._xVelocity;
            }

            set
            {
                this._xVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yVelocity")]
        public float YVelocity
        {
            get
            {
                return this._yVelocity;
            }

            set
            {
                this._yVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zVelocity")]
        public float ZVelocity
        {
            get
            {
                return this._zVelocity;
            }

            set
            {
                this._zVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "xLocation")]
        public double XLocation
        {
            get
            {
                return this._xLocation;
            }

            set
            {
                this._xLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "yLocation")]
        public double YLocation
        {
            get
            {
                return this._yLocation;
            }

            set
            {
                this._yLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(double), ElementName = "zLocation")]
        public double ZLocation
        {
            get
            {
                return this._zLocation;
            }

            set
            {
                this._zLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the psi
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "psi")]
        public float Psi
        {
            get
            {
                return this._psi;
            }

            set
            {
                this._psi = value;
            }
        }

        /// <summary>
        /// Gets or sets the theta
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "theta")]
        public float Theta
        {
            get
            {
                return this._theta;
            }

            set
            {
                this._theta = value;
            }
        }

        /// <summary>
        /// Gets or sets the phi
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "phi")]
        public float Phi
        {
            get
            {
                return this._phi;
            }

            set
            {
                this._phi = value;
            }
        }

        /// <summary>
        /// Gets or sets the a series of bit flags that are used to help draw the entity, such as smoking, on fire, etc.
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
        public int EntityAppearance
        {
            get
            {
                return this._entityAppearance;
            }

            set
            {
                this._entityAppearance = value;
            }
        }

        /// <summary>
        /// Gets or sets the enumeration of what dead reckoning algorighm to use
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm
        {
            get
            {
                return this._deadReckoningAlgorithm;
            }

            set
            {
                this._deadReckoningAlgorithm = value;
            }
        }

        /// <summary>
        /// Gets or sets the other parameters to use in the dead reckoning algorithm
        /// </summary>
        [XmlArray(ElementName = "otherParameters")]
        public byte[] OtherParameters
        {
            get
            {
                return this._otherParameters;
            }

            set
            {
                this._otherParameters = value;
            }
}

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xAcceleration")]
        public float XAcceleration
        {
            get
            {
                return this._xAcceleration;
            }

            set
            {
                this._xAcceleration = value;
            }
        }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yAcceleration")]
        public float YAcceleration
        {
            get
            {
                return this._yAcceleration;
            }

            set
            {
                this._yAcceleration = value;
            }
        }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zAcceleration")]
        public float ZAcceleration
        {
            get
            {
                return this._zAcceleration;
            }

            set
            {
                this._zAcceleration = value;
            }
        }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "xAngularVelocity")]
        public float XAngularVelocity
        {
            get
            {
                return this._xAngularVelocity;
            }

            set
            {
                this._xAngularVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the y Value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "yAngularVelocity")]
        public float YAngularVelocity
        {
            get
            {
                return this._yAngularVelocity;
            }

            set
            {
                this._yAngularVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the Z value
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "zAngularVelocity")]
        public float ZAngularVelocity
        {
            get
            {
                return this._zAngularVelocity;
            }

            set
            {
                this._zAngularVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the characters that can be used for debugging, or to draw unique strings on the side of entities in the world
        /// </summary>
        [XmlArray(ElementName = "marking")]
        public byte[] Marking
        {
            get
            {
                return this._marking;
            }

            set
            {
                this._marking = value;
            }
}

        /// <summary>
        /// Gets or sets the a series of bit flags
        /// </summary>
        [XmlElement(Type = typeof(int), ElementName = "capabilities")]
        public int Capabilities
        {
            get
            {
                return this._capabilities;
            }

            set
            {
                this._capabilities = value;
            }
        }

        /// <summary>
        /// Gets the variable length list of articulation parameters
        /// </summary>
        [XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
        public List<ArticulationParameter> ArticulationParameters
        {
            get
            {
                return this._articulationParameters;
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
                    dos.WriteUnsignedShort((ushort)this._site);
                    dos.WriteUnsignedShort((ushort)this._application);
                    dos.WriteUnsignedShort((ushort)this._entity);
                    dos.WriteUnsignedByte((byte)this._forceId);
                    dos.WriteByte((byte)this._articulationParameters.Count);
                    dos.WriteUnsignedByte((byte)this._entityKind);
                    dos.WriteUnsignedByte((byte)this._domain);
                    dos.WriteUnsignedShort((ushort)this._country);
                    dos.WriteUnsignedByte((byte)this._category);
                    dos.WriteUnsignedByte((byte)this._subcategory);
                    dos.WriteUnsignedByte((byte)this._specific);
                    dos.WriteUnsignedByte((byte)this._extra);
                    dos.WriteUnsignedByte((byte)this._altEntityKind);
                    dos.WriteUnsignedByte((byte)this._altDomain);
                    dos.WriteUnsignedShort((ushort)this._altCountry);
                    dos.WriteUnsignedByte((byte)this._altCategory);
                    dos.WriteUnsignedByte((byte)this._altSubcategory);
                    dos.WriteUnsignedByte((byte)this._altSpecific);
                    dos.WriteUnsignedByte((byte)this._altExtra);
                    dos.WriteFloat((float)this._xVelocity);
                    dos.WriteFloat((float)this._yVelocity);
                    dos.WriteFloat((float)this._zVelocity);
                    dos.WriteDouble((double)this._xLocation);
                    dos.WriteDouble((double)this._yLocation);
                    dos.WriteDouble((double)this._zLocation);
                    dos.WriteFloat((float)this._psi);
                    dos.WriteFloat((float)this._theta);
                    dos.WriteFloat((float)this._phi);
                    dos.WriteInt((int)this._entityAppearance);
                    dos.WriteUnsignedByte((byte)this._deadReckoningAlgorithm);

                    for (int idx = 0; idx < this._otherParameters.Length; idx++)
                    {
                        dos.WriteByte(this._otherParameters[idx]);
                    }

                    dos.WriteFloat((float)this._xAcceleration);
                    dos.WriteFloat((float)this._yAcceleration);
                    dos.WriteFloat((float)this._zAcceleration);
                    dos.WriteFloat((float)this._xAngularVelocity);
                    dos.WriteFloat((float)this._yAngularVelocity);
                    dos.WriteFloat((float)this._zAngularVelocity);

                    for (int idx = 0; idx < this._marking.Length; idx++)
                    {
                        dos.WriteByte(this._marking[idx]);
                    }

                    dos.WriteInt((int)this._capabilities);

                    for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                    {
                        ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                        aArticulationParameter.Marshal(dos);
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
                    this._site = dis.ReadUnsignedShort();
                    this._application = dis.ReadUnsignedShort();
                    this._entity = dis.ReadUnsignedShort();
                    this._forceId = dis.ReadUnsignedByte();
                    this._numberOfArticulationParameters = dis.ReadByte();
                    this._entityKind = dis.ReadUnsignedByte();
                    this._domain = dis.ReadUnsignedByte();
                    this._country = dis.ReadUnsignedShort();
                    this._category = dis.ReadUnsignedByte();
                    this._subcategory = dis.ReadUnsignedByte();
                    this._specific = dis.ReadUnsignedByte();
                    this._extra = dis.ReadUnsignedByte();
                    this._altEntityKind = dis.ReadUnsignedByte();
                    this._altDomain = dis.ReadUnsignedByte();
                    this._altCountry = dis.ReadUnsignedShort();
                    this._altCategory = dis.ReadUnsignedByte();
                    this._altSubcategory = dis.ReadUnsignedByte();
                    this._altSpecific = dis.ReadUnsignedByte();
                    this._altExtra = dis.ReadUnsignedByte();
                    this._xVelocity = dis.ReadFloat();
                    this._yVelocity = dis.ReadFloat();
                    this._zVelocity = dis.ReadFloat();
                    this._xLocation = dis.ReadDouble();
                    this._yLocation = dis.ReadDouble();
                    this._zLocation = dis.ReadDouble();
                    this._psi = dis.ReadFloat();
                    this._theta = dis.ReadFloat();
                    this._phi = dis.ReadFloat();
                    this._entityAppearance = dis.ReadInt();
                    this._deadReckoningAlgorithm = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < this._otherParameters.Length; idx++)
                    {
                        this._otherParameters[idx] = dis.ReadByte();
                    }

                    this._xAcceleration = dis.ReadFloat();
                    this._yAcceleration = dis.ReadFloat();
                    this._zAcceleration = dis.ReadFloat();
                    this._xAngularVelocity = dis.ReadFloat();
                    this._yAngularVelocity = dis.ReadFloat();
                    this._zAngularVelocity = dis.ReadFloat();

                    for (int idx = 0; idx < this._marking.Length; idx++)
                    {
                        this._marking[idx] = dis.ReadByte();
                    }

                    this._capabilities = dis.ReadInt();

                    for (int idx = 0; idx < this.NumberOfArticulationParameters; idx++)
                    {
                        ArticulationParameter anX = new ArticulationParameter();
                        anX.Unmarshal(dis);
                        this._articulationParameters.Add(anX);
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
            sb.AppendLine("<FastEntityStatePdu>");
            base.Reflection(sb);
            try
            {
                sb.AppendLine("<site type=\"ushort\">" + this._site.ToString(CultureInfo.InvariantCulture) + "</site>");
                sb.AppendLine("<application type=\"ushort\">" + this._application.ToString(CultureInfo.InvariantCulture) + "</application>");
                sb.AppendLine("<entity type=\"ushort\">" + this._entity.ToString(CultureInfo.InvariantCulture) + "</entity>");
                sb.AppendLine("<forceId type=\"byte\">" + this._forceId.ToString(CultureInfo.InvariantCulture) + "</forceId>");
                sb.AppendLine("<articulationParameters type=\"byte\">" + this._articulationParameters.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
                sb.AppendLine("<entityKind type=\"byte\">" + this._entityKind.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
                sb.AppendLine("<domain type=\"byte\">" + this._domain.ToString(CultureInfo.InvariantCulture) + "</domain>");
                sb.AppendLine("<country type=\"ushort\">" + this._country.ToString(CultureInfo.InvariantCulture) + "</country>");
                sb.AppendLine("<category type=\"byte\">" + this._category.ToString(CultureInfo.InvariantCulture) + "</category>");
                sb.AppendLine("<subcategory type=\"byte\">" + this._subcategory.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
                sb.AppendLine("<specific type=\"byte\">" + this._specific.ToString(CultureInfo.InvariantCulture) + "</specific>");
                sb.AppendLine("<extra type=\"byte\">" + this._extra.ToString(CultureInfo.InvariantCulture) + "</extra>");
                sb.AppendLine("<altEntityKind type=\"byte\">" + this._altEntityKind.ToString(CultureInfo.InvariantCulture) + "</altEntityKind>");
                sb.AppendLine("<altDomain type=\"byte\">" + this._altDomain.ToString(CultureInfo.InvariantCulture) + "</altDomain>");
                sb.AppendLine("<altCountry type=\"ushort\">" + this._altCountry.ToString(CultureInfo.InvariantCulture) + "</altCountry>");
                sb.AppendLine("<altCategory type=\"byte\">" + this._altCategory.ToString(CultureInfo.InvariantCulture) + "</altCategory>");
                sb.AppendLine("<altSubcategory type=\"byte\">" + this._altSubcategory.ToString(CultureInfo.InvariantCulture) + "</altSubcategory>");
                sb.AppendLine("<altSpecific type=\"byte\">" + this._altSpecific.ToString(CultureInfo.InvariantCulture) + "</altSpecific>");
                sb.AppendLine("<altExtra type=\"byte\">" + this._altExtra.ToString(CultureInfo.InvariantCulture) + "</altExtra>");
                sb.AppendLine("<xVelocity type=\"float\">" + this._xVelocity.ToString(CultureInfo.InvariantCulture) + "</xVelocity>");
                sb.AppendLine("<yVelocity type=\"float\">" + this._yVelocity.ToString(CultureInfo.InvariantCulture) + "</yVelocity>");
                sb.AppendLine("<zVelocity type=\"float\">" + this._zVelocity.ToString(CultureInfo.InvariantCulture) + "</zVelocity>");
                sb.AppendLine("<xLocation type=\"double\">" + this._xLocation.ToString(CultureInfo.InvariantCulture) + "</xLocation>");
                sb.AppendLine("<yLocation type=\"double\">" + this._yLocation.ToString(CultureInfo.InvariantCulture) + "</yLocation>");
                sb.AppendLine("<zLocation type=\"double\">" + this._zLocation.ToString(CultureInfo.InvariantCulture) + "</zLocation>");
                sb.AppendLine("<psi type=\"float\">" + this._psi.ToString(CultureInfo.InvariantCulture) + "</psi>");
                sb.AppendLine("<theta type=\"float\">" + this._theta.ToString(CultureInfo.InvariantCulture) + "</theta>");
                sb.AppendLine("<phi type=\"float\">" + this._phi.ToString(CultureInfo.InvariantCulture) + "</phi>");
                sb.AppendLine("<entityAppearance type=\"int\">" + this._entityAppearance.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
                sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + this._deadReckoningAlgorithm.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
                for (int idx = 0; idx < this._otherParameters.Length; idx++)
                {
                    sb.AppendLine("<otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + this._otherParameters[idx] + "</otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
            }

                sb.AppendLine("<xAcceleration type=\"float\">" + this._xAcceleration.ToString(CultureInfo.InvariantCulture) + "</xAcceleration>");
                sb.AppendLine("<yAcceleration type=\"float\">" + this._yAcceleration.ToString(CultureInfo.InvariantCulture) + "</yAcceleration>");
                sb.AppendLine("<zAcceleration type=\"float\">" + this._zAcceleration.ToString(CultureInfo.InvariantCulture) + "</zAcceleration>");
                sb.AppendLine("<xAngularVelocity type=\"float\">" + this._xAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</xAngularVelocity>");
                sb.AppendLine("<yAngularVelocity type=\"float\">" + this._yAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</yAngularVelocity>");
                sb.AppendLine("<zAngularVelocity type=\"float\">" + this._zAngularVelocity.ToString(CultureInfo.InvariantCulture) + "</zAngularVelocity>");
                for (int idx = 0; idx < this._marking.Length; idx++)
                {
                    sb.AppendLine("<marking" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + this._marking[idx] + "</marking" + idx.ToString(CultureInfo.InvariantCulture) + ">");
            }

                sb.AppendLine("<capabilities type=\"int\">" + this._capabilities.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    sb.AppendLine("<articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
                    ArticulationParameter aArticulationParameter = (ArticulationParameter)this._articulationParameters[idx];
                    aArticulationParameter.Reflection(sb);
                    sb.AppendLine("</articulationParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</FastEntityStatePdu>");
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
            return this == obj as FastEntityStatePdu;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(FastEntityStatePdu obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ivarsEqual = base.Equals(obj);

            if (this._site != obj._site)
            {
                ivarsEqual = false;
            }

            if (this._application != obj._application)
            {
                ivarsEqual = false;
            }

            if (this._entity != obj._entity)
            {
                ivarsEqual = false;
            }

            if (this._forceId != obj._forceId)
            {
                ivarsEqual = false;
            }

            if (this._numberOfArticulationParameters != obj._numberOfArticulationParameters)
            {
                ivarsEqual = false;
            }

            if (this._entityKind != obj._entityKind)
            {
                ivarsEqual = false;
            }

            if (this._domain != obj._domain)
            {
                ivarsEqual = false;
            }

            if (this._country != obj._country)
            {
                ivarsEqual = false;
            }

            if (this._category != obj._category)
            {
                ivarsEqual = false;
            }

            if (this._subcategory != obj._subcategory)
            {
                ivarsEqual = false;
            }

            if (this._specific != obj._specific)
            {
                ivarsEqual = false;
            }

            if (this._extra != obj._extra)
            {
                ivarsEqual = false;
            }

            if (this._altEntityKind != obj._altEntityKind)
            {
                ivarsEqual = false;
            }

            if (this._altDomain != obj._altDomain)
            {
                ivarsEqual = false;
            }

            if (this._altCountry != obj._altCountry)
            {
                ivarsEqual = false;
            }

            if (this._altCategory != obj._altCategory)
            {
                ivarsEqual = false;
            }

            if (this._altSubcategory != obj._altSubcategory)
            {
                ivarsEqual = false;
            }

            if (this._altSpecific != obj._altSpecific)
            {
                ivarsEqual = false;
            }

            if (this._altExtra != obj._altExtra)
            {
                ivarsEqual = false;
            }

            if (this._xVelocity != obj._xVelocity)
            {
                ivarsEqual = false;
            }

            if (this._yVelocity != obj._yVelocity)
            {
                ivarsEqual = false;
            }

            if (this._zVelocity != obj._zVelocity)
            {
                ivarsEqual = false;
            }

            if (this._xLocation != obj._xLocation)
            {
                ivarsEqual = false;
            }

            if (this._yLocation != obj._yLocation)
            {
                ivarsEqual = false;
            }

            if (this._zLocation != obj._zLocation)
            {
                ivarsEqual = false;
            }

            if (this._psi != obj._psi)
            {
                ivarsEqual = false;
            }

            if (this._theta != obj._theta)
            {
                ivarsEqual = false;
            }

            if (this._phi != obj._phi)
            {
                ivarsEqual = false;
            }

            if (this._entityAppearance != obj._entityAppearance)
            {
                ivarsEqual = false;
            }

            if (this._deadReckoningAlgorithm != obj._deadReckoningAlgorithm)
            {
                ivarsEqual = false;
            }

            if (obj._otherParameters.Length != 15) 
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 15; idx++)
                {
                    if (this._otherParameters[idx] != obj._otherParameters[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._xAcceleration != obj._xAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._yAcceleration != obj._yAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._zAcceleration != obj._zAcceleration)
            {
                ivarsEqual = false;
            }

            if (this._xAngularVelocity != obj._xAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (this._yAngularVelocity != obj._yAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (this._zAngularVelocity != obj._zAngularVelocity)
            {
                ivarsEqual = false;
            }

            if (obj._marking.Length != 12) 
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 12; idx++)
                {
                    if (this._marking[idx] != obj._marking[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (this._capabilities != obj._capabilities)
            {
                ivarsEqual = false;
            }

            if (this._articulationParameters.Count != obj._articulationParameters.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    if (!this._articulationParameters[idx].Equals(obj._articulationParameters[idx]))
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

            result = GenerateHash(result) ^ this._site.GetHashCode();
            result = GenerateHash(result) ^ this._application.GetHashCode();
            result = GenerateHash(result) ^ this._entity.GetHashCode();
            result = GenerateHash(result) ^ this._forceId.GetHashCode();
            result = GenerateHash(result) ^ this._numberOfArticulationParameters.GetHashCode();
            result = GenerateHash(result) ^ this._entityKind.GetHashCode();
            result = GenerateHash(result) ^ this._domain.GetHashCode();
            result = GenerateHash(result) ^ this._country.GetHashCode();
            result = GenerateHash(result) ^ this._category.GetHashCode();
            result = GenerateHash(result) ^ this._subcategory.GetHashCode();
            result = GenerateHash(result) ^ this._specific.GetHashCode();
            result = GenerateHash(result) ^ this._extra.GetHashCode();
            result = GenerateHash(result) ^ this._altEntityKind.GetHashCode();
            result = GenerateHash(result) ^ this._altDomain.GetHashCode();
            result = GenerateHash(result) ^ this._altCountry.GetHashCode();
            result = GenerateHash(result) ^ this._altCategory.GetHashCode();
            result = GenerateHash(result) ^ this._altSubcategory.GetHashCode();
            result = GenerateHash(result) ^ this._altSpecific.GetHashCode();
            result = GenerateHash(result) ^ this._altExtra.GetHashCode();
            result = GenerateHash(result) ^ this._xVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._yVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._zVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._xLocation.GetHashCode();
            result = GenerateHash(result) ^ this._yLocation.GetHashCode();
            result = GenerateHash(result) ^ this._zLocation.GetHashCode();
            result = GenerateHash(result) ^ this._psi.GetHashCode();
            result = GenerateHash(result) ^ this._theta.GetHashCode();
            result = GenerateHash(result) ^ this._phi.GetHashCode();
            result = GenerateHash(result) ^ this._entityAppearance.GetHashCode();
            result = GenerateHash(result) ^ this._deadReckoningAlgorithm.GetHashCode();

            for (int idx = 0; idx < 15; idx++)
            {
                result = GenerateHash(result) ^ this._otherParameters[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ this._xAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._yAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._zAcceleration.GetHashCode();
            result = GenerateHash(result) ^ this._xAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._yAngularVelocity.GetHashCode();
            result = GenerateHash(result) ^ this._zAngularVelocity.GetHashCode();

            for (int idx = 0; idx < 12; idx++)
            {
                result = GenerateHash(result) ^ this._marking[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ this._capabilities.GetHashCode();

            if (this._articulationParameters.Count > 0)
            {
                for (int idx = 0; idx < this._articulationParameters.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._articulationParameters[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
