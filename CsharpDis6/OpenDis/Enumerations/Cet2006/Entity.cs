using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable]
    [DebuggerStepThrough]
    public class Entity : CetBase, INotifyPropertyChanged
    {
        #region Fields (12) 

        private List<Category> categoryField;

        private Country country;
        private string countryField;
        private string descriptionField;
        private byte domain;
        private string domainField;
        private string footnoteField;
        private EntityKind kind;
        private string kindField;
        private bool unusedField;
        private bool unusedFieldSpecified;
        private string xrefField;

        #endregion Fields 

        #region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Delegates and Events 

        #region Properties (12) 

        [XmlElement("category", Form = XmlSchemaForm.Unqualified)]
        public List<Category> Categories
        {
            get => categoryField;

            set
            {
                if (categoryField != value)
                {
                    categoryField = value;
                    RaisePropertyChanged("Category");
                }
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

        [XmlAttribute(AttributeName = "description")]
        public string Description
        {
            get => descriptionField;

            set
            {
                if (descriptionField != value)
                {
                    descriptionField = value;
                    RaisePropertyChanged(nameof(Description));
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

        [XmlAttribute(AttributeName = "footnote")]
        public string Footnote
        {
            get => footnoteField;

            set
            {
                if (footnoteField != value)
                {
                    footnoteField = value;
                    RaisePropertyChanged(nameof(Footnote));
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

        [XmlAttribute(AttributeName = "unused")]
        public bool Unused
        {
            get => unusedField;

            set
            {
                if (unusedField != value)
                {
                    unusedField = value;
                    RaisePropertyChanged(nameof(Unused));
                }
            }
        }

        [XmlIgnore]
        public bool UnusedSpecified
        {
            get => unusedFieldSpecified;

            set
            {
                if (unusedFieldSpecified != value)
                {
                    unusedFieldSpecified = value;
                    RaisePropertyChanged(nameof(UnusedSpecified));
                }
            }
        }

        [XmlAttribute(AttributeName = "xref")]
        public string XRef
        {
            get => xrefField;

            set
            {
                if (xrefField != value)
                {
                    xrefField = value;
                    RaisePropertyChanged(nameof(XRef));
                }
            }
        }

        #endregion Properties 

        #region Methods (1) 

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods 
    }
}