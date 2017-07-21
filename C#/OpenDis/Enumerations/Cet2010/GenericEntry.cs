using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Attributes and elements common to all enumeration entries.
    /// </summary>
    [XmlInclude(typeof(Entity))]
    [XmlInclude(typeof(GenericEntryDescription))]
    [XmlInclude(typeof(GenericEntryRange))]
    [XmlInclude(typeof(ExtraRange))]
    [XmlInclude(typeof(SpecificRange))]
    [XmlInclude(typeof(SubcategoryRange))]
    [XmlInclude(typeof(CategoryRange))]
    [XmlInclude(typeof(GenericEntrySingle))]
    [XmlInclude(typeof(Extra))]
    [XmlInclude(typeof(Specific))]
    [XmlInclude(typeof(Subcategory))]
    [XmlInclude(typeof(Category))]
    [XmlInclude(typeof(GenericEntryString))]
    [Serializable()]
    [DebuggerStepThrough()]
    public abstract class GenericEntry : CetBase, INotifyPropertyChanged, OpenDis.Enumerations.Cet2010.IGenericEntry
    {
		#region Fields (14) 

        private static Regex uuidRegEx = new Regex("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");

        private List<object> itemsField;

        private bool baseuuidField;
        private bool baseuuidFieldSpecified;
        private bool deprecatedField;
        private bool deprecatedFieldSpecified;
        private bool draft1278Field;
        private bool draft1278FieldSpecified;
        private string footnoteField;
        private GenericEntryStatus statusField;
        private bool statusFieldSpecified;
        private string uuidField;
        private ulong xref;
        private string xrefField;

		#endregion Fields 

		#region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Properties (13) 

        /// <summary>
        /// Gets or sets a value indicating whether this entry was based on another enumeration entry UUID.
        /// </summary>
        /// <value><c>true</c> if base UUID; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "baseuuid")]
        public bool BaseUuid
        {
            get
            {
                return this.baseuuidField;
            }

            set
            {
                if (this.baseuuidField == value)
                {
                    return;
                }

                this.baseuuidField = value;
                this.RaisePropertyChanged("BaseUuid");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Base UUID is specified
        /// </summary>
        /// <value><c>true</c> if base is UUID specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool BaseUuidSpecified
        {
            get
            {
                return this.baseuuidFieldSpecified;
            }

            set
            {
                if (this.baseuuidFieldSpecified == value)
                {
                    return;
                }

                this.baseuuidFieldSpecified = value;
                this.RaisePropertyChanged("BaseUuidSpecified");
            }
        }

        [XmlElement("cr", typeof(Cr), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("cr_range", typeof(CrRange), Form = XmlSchemaForm.Unqualified)]
        public List<object> ChangeRequests
        {
            get
            {
                return this.itemsField;
            }

            set
            {
                if (this.itemsField == value)
                {
                    return;
                }

                this.itemsField = value;
                this.RaisePropertyChanged("ChangeRequests");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry has been deprecated.
        /// </summary>
        /// <value><c>true</c> if deprecated; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "deprecated")]
        public bool Deprecated
        {
            get
            {
                return this.deprecatedField;
            }

            set
            {
                if (this.deprecatedField == value)
                {
                    return;
                }

                this.deprecatedField = value;
                this.RaisePropertyChanged("Deprecated");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether deprecated field is specified.
        /// </summary>
        /// <value><c>true</c> if deprecated field is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool DeprecatedSpecified
        {
            get
            {
                return this.deprecatedFieldSpecified;
            }

            set
            {
                if (this.deprecatedFieldSpecified == value)
                {
                    return;
                }

                this.deprecatedFieldSpecified = value;
                this.RaisePropertyChanged("DeprecatedSpecified");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry applies to a draft revision of IEEE 1278.
        /// </summary>
        /// <value><c>true</c> if the enumeration entry applies to a draft revision of IEEE 1278; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "draft1278")]
        public bool Draft1278
        {
            get
            {
                return this.draft1278Field;
            }

            set
            {
                if (this.draft1278Field == value)
                {
                    return;
                }

                this.draft1278Field = value;
                this.RaisePropertyChanged("Draft1278");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278 is specified.
        /// </summary>
        /// <value><c>true</c> if the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278 is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool Draft1278Specified
        {
            get
            {
                return this.draft1278FieldSpecified;
            }

            set
            {
                if (this.draft1278FieldSpecified == value)
                {
                    return;
                }

                this.draft1278FieldSpecified = value;
                this.RaisePropertyChanged("Draft1278Specified");
            }
        }

        /// <summary>
        /// Gets or sets any additional information pertaining to the enumeration entry.
        /// </summary>
        /// <value>The additional information pertaining to the enumeration entry.</value>
        [XmlAttribute(AttributeName = "footnote")]
        public string Footnote
        {
            get
            {
                return this.footnoteField;
            }

            set
            {
                if (this.footnoteField == value)
                {
                    return;
                }

                this.footnoteField = value;
                this.RaisePropertyChanged("Footnote");
            }
        }

        /// <summary>
        /// Gets or sets the cross-reference to another enumeration table (uid) - RAW value.
        /// </summary>
        /// <value>The RAW value for csross-reference to another enumeration table (uid).</value>
        [XmlAttribute(AttributeName = "xref", DataType = "positiveInteger")]
        public string RawXRef
        {
            get
            {
                return this.xrefField;
            }

            set
            {
                if (this.xrefField == value)
                {
                    return;
                }

                this.xrefField = value;
                this.xref = ulong.Parse(value, CultureInfo.InvariantCulture);
                this.RaisePropertyChanged("RawXRref");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating the approval status of the entry.
        /// </summary>
        /// <value>The value indicating the approval status of the entry.</value>
        [XmlAttribute(AttributeName = "status")]
        public GenericEntryStatus Status
        {
            get
            {
                return this.statusField;
            }

            set
            {
                if (this.statusField == value)
                {
                    return;
                }

                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the status is specified.
        /// </summary>
        /// <value><c>true</c> if the status is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }

            set
            {
                if (this.statusFieldSpecified == value)
                {
                    return;
                }

                this.statusFieldSpecified = value;
                this.RaisePropertyChanged("StatusSpecified");
            }
        }

        /// <summary>
        /// Gets or sets the RFC 4122 Universally Unique IDentifier (UUID)
        /// </summary>
        [XmlAttribute(AttributeName = "uuid")]
        public string Uuid
        {
            get
            {
                return this.uuidField;
            }

            set
            {
                if (this.uuidField == value)
                {
                    return;
                }

                if (!uuidRegEx.IsMatch(value, 0))
                {
                    throw new ArgumentException("Invalid value! Value must be conformant with RFC-4122.");
                }

                this.uuidField = value;
                this.RaisePropertyChanged("Uuid");
            }
        }

        /// <summary>
        /// Gets or sets the cross-reference to another enumeration table (uid).
        /// </summary>
        /// <value>The csross-reference to another enumeration table (uid).</value>
        [XmlIgnore]
        public ulong XRef
        {
            get
            {
                return this.xref;
            }

            set
            {
                if (this.xref != value)
                {
                    this.RawXRef = ((ulong)value).ToString(CultureInfo.InvariantCulture);
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