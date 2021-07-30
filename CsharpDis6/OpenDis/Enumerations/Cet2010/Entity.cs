using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable]
    [DebuggerStepThrough]
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
            get => categories;

            set
            {
                if (categories == value)
                {
                    return;
                }

                categories = value;
                RaisePropertyChanged(nameof(Categories));
            }
        }

        [XmlIgnore]
        public Country Country
        {
            get => country;

            set
            {
                if (country != value)
                {
                    RawCountry = ((int)value).ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Country));
                }
            }
        }

        [XmlIgnore]
        public byte Domain
        {
            get => domain;

            set
            {
                if (domain != value)
                {
                    RawDomain = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Domain));
                }
            }
        }

        [XmlIgnore]
        public EntityKind Kind
        {
            get => kind;

            set
            {
                if (kind != value)
                {
                    RawKind = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Kind));
                }
            }
        }

        [XmlAttribute(AttributeName = "country", DataType = "nonNegativeInteger")]
        public string RawCountry
        {
            get => countryField;

            set
            {
                VerifyNumericString(value, false);

                if (countryField != value)
                {
                    countryField = value;
                    int intValue = int.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    country = (Country)Enum.ToObject(typeof(Country), intValue);
                    RaisePropertyChanged(nameof(RawCountry));
                }
            }
        }

        [XmlAttribute(AttributeName = "domain", DataType = "nonNegativeInteger")]
        public string RawDomain
        {
            get => domainField;

            set
            {
                VerifyNumericString(value, false);

                if (domainField != value)
                {
                    domainField = value;
                    domain = byte.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(RawDomain));
                }
            }
        }

        [XmlAttribute(AttributeName = "kind", DataType = "nonNegativeInteger")]
        public string RawKind
        {
            get => kindField;

            set
            {
                if (kindField != value)
                {
                    kindField = value;
                    byte byteValue = byte.Parse(value, CultureInfo.InvariantCulture);
                    kind = (EntityKind)Enum.ToObject(typeof(EntityKind), byteValue);
                    RaisePropertyChanged(nameof(RawKind));
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
            get => uidField;

            set
            {
                if (uidField == value)
                {
                    return;
                }

                uidField = value;
                uid = ulong.Parse(value, CultureInfo.InvariantCulture);
                RaisePropertyChanged(nameof(RawUId));
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer.
        /// </summary>
        /// <value>The unique numeric identifer.</value>
        [XmlIgnore]
        public ulong UId
        {
            get => uid;

            set
            {
                if (uid != value)
                {
                    RawUId = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(UId));
                }
            }
        }

        #endregion Properties 
    }
}
