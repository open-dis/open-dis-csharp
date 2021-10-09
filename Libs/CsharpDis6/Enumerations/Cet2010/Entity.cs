using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable()]
    [DebuggerStepThrough()]
    public class Entity : GenericEntry
    {
		#region Fields (9) 

        private List<GenericEntryDescription> categories;

        private Country country;
        private string countryField;
        private byte domain;
        private string domainField;
        private EntityKind kind;
        private string kindField;
        private ulong uid;
        private string uidField;

		#endregion Fields 

		#region Properties (9) 

        [XmlElement("category", typeof(Category), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("category_range", typeof(CategoryRange), Form = XmlSchemaForm.Unqualified)]
        public List<GenericEntryDescription> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                if (this.categories == value)
                {
                    return;
                }

                this.categories = value;
                this.RaisePropertyChanged("Categories");
            }
        }

        [XmlIgnore]
        public Country Country
        {
            get
            {
                return this.country;
            }

            set
            {
                if (this.country != value)
                {
                    this.RawCountry = ((int)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Country");
                }
            }
        }

        [XmlIgnore]
        public byte Domain
        {
            get
            {
                return this.domain;
            }

            set
            {
                if (this.domain != value)
                {
                    this.RawDomain = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Domain");
                }
            }
        }

        [XmlIgnore]
        public EntityKind Kind
        {
            get
            {
                return this.kind;
            }

            set
            {
                if (this.kind != value)
                {
                    this.RawKind = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Kind");
                }
            }
        }

        [XmlAttribute(AttributeName = "country", DataType = "nonNegativeInteger")]
        public string RawCountry
        {
            get
            {
                return this.countryField;
            }

            set
            {
                this.VerifyNumericString(value, false);

                if (this.countryField != value)
                {
                    this.countryField = value;
                    int intValue = int.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    this.country = (Country)Enum.ToObject(typeof(Country), intValue);
                    this.RaisePropertyChanged("RawCountry");
                }
            }
        }

        [XmlAttribute(AttributeName = "domain", DataType = "nonNegativeInteger")]
        public string RawDomain
        {
            get
            {
                return this.domainField;
            }

            set
            {
                this.VerifyNumericString(value, false);

                if (this.domainField != value)
                {
                    this.domainField = value;
                    this.domain = byte.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("RawDomain");
                }
            }
        }

        [XmlAttribute(AttributeName = "kind", DataType = "nonNegativeInteger")]
        public string RawKind
        {
            get
            {
                return this.kindField;
            }

            set
            {
                if (this.kindField != value)
                {
                    this.kindField = value;
                    byte byteValue = byte.Parse(value, CultureInfo.InvariantCulture);
                    this.kind = (EntityKind)Enum.ToObject(typeof(EntityKind), byteValue);
                    this.RaisePropertyChanged("RawKind");
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer - RAW value.
        /// </summary>
        /// <value>The RAW unique numeric identifer.</value>
        [XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
        public string RawUId
        {
            get
            {
                return this.uidField;
            }

            set
            {
                if (this.uidField == value)
                {
                    return;
                }

                this.uidField = value;
                this.uid = ulong.Parse(value, CultureInfo.InvariantCulture);
                this.RaisePropertyChanged("RawUId");
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer.
        /// </summary>
        /// <value>The unique numeric identifer.</value>
        [XmlIgnore]
        public ulong UId
        {
            get
            {
                return this.uid;
            }

            set
            {
                if (this.uid != value)
                {
                    this.RawUId = ((ulong)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("UId");
                }
            }
        }

		#endregion Properties 
    }
}
