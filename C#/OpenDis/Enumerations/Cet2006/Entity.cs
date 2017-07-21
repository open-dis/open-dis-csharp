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
    [Serializable()]
    [DebuggerStepThrough()]
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
            get
            {
                return this.categoryField;
            }

            set
            {
                if (this.categoryField != value)
                {
                    this.categoryField = value;
                    this.RaisePropertyChanged("Category");
                }
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

        [XmlAttribute(AttributeName = "description")]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }

            set
            {
                if (this.descriptionField != value)
                {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("Description");
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

        [XmlAttribute(AttributeName = "footnote")]
        public string Footnote
        {
            get
            {
                return this.footnoteField;
            }

            set
            {
                if (this.footnoteField != value)
                {
                    this.footnoteField = value;
                    this.RaisePropertyChanged("Footnote");
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

        [XmlAttribute(AttributeName = "unused")]
        public bool Unused
        {
            get
            {
                return this.unusedField;
            }

            set
            {
                if (this.unusedField != value)
                {
                    this.unusedField = value;
                    this.RaisePropertyChanged("Unused");
                }
            }
        }

        [XmlIgnore()]
        public bool UnusedSpecified
        {
            get
            {
                return this.unusedFieldSpecified;
            }

            set
            {
                if (this.unusedFieldSpecified != value)
                {
                    this.unusedFieldSpecified = value;
                    this.RaisePropertyChanged("UnusedSpecified");
                }
            }
        }

        [XmlAttribute(AttributeName = "xref")]
        public string XRef
        {
            get
            {
                return this.xrefField;
            }

            set
            {
                if (this.xrefField != value)
                {
                    this.xrefField = value;
                    this.RaisePropertyChanged("XRef");
                }
            }
        }

		#endregion Properties 

		#region Methods (1) 

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

		#endregion Methods 
    }
}