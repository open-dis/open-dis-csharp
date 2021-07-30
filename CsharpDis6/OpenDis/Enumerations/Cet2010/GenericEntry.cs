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
    [Serializable]
    [DebuggerStepThrough]
    public abstract class GenericEntry : CetBase, INotifyPropertyChanged, IGenericEntry
    {
        #region Fields (14) 

        private static readonly Regex uuidRegEx = new("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");

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
            get => baseuuidField;

            set
            {
                if (baseuuidField == value)
                {
                    return;
                }

                baseuuidField = value;
                RaisePropertyChanged(nameof(BaseUuid));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Base UUID is specified
        /// </summary>
        /// <value><c>true</c> if base is UUID specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool BaseUuidSpecified
        {
            get => baseuuidFieldSpecified;

            set
            {
                if (baseuuidFieldSpecified == value)
                {
                    return;
                }

                baseuuidFieldSpecified = value;
                RaisePropertyChanged(nameof(BaseUuidSpecified));
            }
        }

        [XmlElement("cr", typeof(Cr), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("cr_range", typeof(CrRange), Form = XmlSchemaForm.Unqualified)]
        public List<object> ChangeRequests
        {
            get => itemsField;

            set
            {
                if (itemsField == value)
                {
                    return;
                }

                itemsField = value;
                RaisePropertyChanged(nameof(ChangeRequests));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry has been deprecated.
        /// </summary>
        /// <value><c>true</c> if deprecated; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "deprecated")]
        public bool Deprecated
        {
            get => deprecatedField;

            set
            {
                if (deprecatedField == value)
                {
                    return;
                }

                deprecatedField = value;
                RaisePropertyChanged(nameof(Deprecated));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether deprecated field is specified.
        /// </summary>
        /// <value><c>true</c> if deprecated field is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool DeprecatedSpecified
        {
            get => deprecatedFieldSpecified;

            set
            {
                if (deprecatedFieldSpecified == value)
                {
                    return;
                }

                deprecatedFieldSpecified = value;
                RaisePropertyChanged(nameof(DeprecatedSpecified));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry applies to a draft revision of IEEE 1278.
        /// </summary>
        /// <value><c>true</c> if the enumeration entry applies to a draft revision of IEEE 1278; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "draft1278")]
        public bool Draft1278
        {
            get => draft1278Field;

            set
            {
                if (draft1278Field == value)
                {
                    return;
                }

                draft1278Field = value;
                RaisePropertyChanged(nameof(Draft1278));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether the enumeration entry applies to a draft revision
        /// of IEEE 1278 is specified.
        /// </summary>
        /// <value><c>true</c> if the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278
        /// is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool Draft1278Specified
        {
            get => draft1278FieldSpecified;

            set
            {
                if (draft1278FieldSpecified == value)
                {
                    return;
                }

                draft1278FieldSpecified = value;
                RaisePropertyChanged(nameof(Draft1278Specified));
            }
        }

        /// <summary>
        /// Gets or sets any additional information pertaining to the enumeration entry.
        /// </summary>
        /// <value>The additional information pertaining to the enumeration entry.</value>
        [XmlAttribute(AttributeName = "footnote")]
        public string Footnote
        {
            get => footnoteField;

            set
            {
                if (footnoteField == value)
                {
                    return;
                }

                footnoteField = value;
                RaisePropertyChanged(nameof(Footnote));
            }
        }

        /// <summary>
        /// Gets or sets the cross-reference to another enumeration table (uid) - RAW value.
        /// </summary>
        /// <value>The RAW value for csross-reference to another enumeration table (uid).</value>
        [XmlAttribute(AttributeName = "xref", DataType = "positiveInteger")]
        public string RawXRef
        {
            get => xrefField;

            set
            {
                if (xrefField == value)
                {
                    return;
                }

                xrefField = value;
                xref = ulong.Parse(value, CultureInfo.InvariantCulture);
                RaisePropertyChanged("RawXRref");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating the approval status of the entry.
        /// </summary>
        /// <value>The value indicating the approval status of the entry.</value>
        [XmlAttribute(AttributeName = "status")]
        public GenericEntryStatus Status
        {
            get => statusField;

            set
            {
                if (statusField == value)
                {
                    return;
                }

                statusField = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the status is specified.
        /// </summary>
        /// <value><c>true</c> if the status is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool StatusSpecified
        {
            get => statusFieldSpecified;

            set
            {
                if (statusFieldSpecified == value)
                {
                    return;
                }

                statusFieldSpecified = value;
                RaisePropertyChanged(nameof(StatusSpecified));
            }
        }

        /// <summary>
        /// Gets or sets the RFC 4122 Universally Unique IDentifier (UUID)
        /// </summary>
        [XmlAttribute(AttributeName = "uuid")]
        public string Uuid
        {
            get => uuidField;

            set
            {
                if (uuidField == value)
                {
                    return;
                }

                if (!uuidRegEx.IsMatch(value, 0))
                {
                    throw new ArgumentException("Invalid value! Value must be conformant with RFC-4122.");
                }

                uuidField = value;
                RaisePropertyChanged(nameof(Uuid));
            }
        }

        /// <summary>
        /// Gets or sets the cross-reference to another enumeration table (uid).
        /// </summary>
        /// <value>The csross-reference to another enumeration table (uid).</value>
        [XmlIgnore]
        public ulong XRef
        {
            get => xref;

            set
            {
                if (xref != value)
                {
                    RawXRef = value.ToString(CultureInfo.InvariantCulture);
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