using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    [XmlInclude(typeof(Cet))]
    [Serializable]
    [DebuggerStepThrough]
    public abstract class GenericTable : CetBase, INotifyPropertyChanged
    {
        #region Fields (10) 

        private List<object> itemsField;

        private bool deprecatedField;
        private bool deprecatedFieldSpecified;
        private bool draft1278Field;
        private bool draft1278FieldSpecified;
        private int groupField;
        private bool groupFieldSpecified;
        private string nameField;
        private ulong uid;
        private string uidField;

        #endregion Fields 

        #region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Delegates and Events 

        #region Properties (10) 

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
        /// Gets or sets the value denoting the table is to be used to define the allowed groups for elements of the enumeration
        /// table.
        /// </summary>
        /// <value>The group value defining the allowed groups for elements of the enumeration table.</value>
        [XmlAttribute(AttributeName = "group")]
        public int Group
        {
            get => groupField;

            set
            {
                if (groupField == value)
                {
                    return;
                }

                groupField = value;
                RaisePropertyChanged(nameof(Group));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether value for group is specified.
        /// </summary>
        /// <value><c>true</c> if value for group is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool GroupSpecified
        {
            get => groupFieldSpecified;

            set
            {
                if (groupFieldSpecified == value)
                {
                    return;
                }

                groupFieldSpecified = value;
                RaisePropertyChanged(nameof(GroupSpecified));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry applies to a draft revision of IEEE 1278.
        /// </summary>
        /// <value><c>true</c> if the enumeration entry applies to a draft revision of IEEE 1278; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "draft1278")]
        public bool IsDraft1278
        {
            get => draft1278Field;

            set
            {
                if (draft1278Field == value)
                {
                    return;
                }

                draft1278Field = value;
                RaisePropertyChanged(nameof(IsDraft1278));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether the enumeration entry applies to a draft revision
        /// of IEEE 1278 is specified.
        /// </summary>
        /// <value><c>true</c> if the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278
        /// is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool IsDraft1278Specified
        {
            get => draft1278FieldSpecified;

            set
            {
                if (draft1278FieldSpecified == value)
                {
                    return;
                }

                draft1278FieldSpecified = value;
                RaisePropertyChanged(nameof(IsDraft1278Specified));
            }
        }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get => nameField;

            set
            {
                if (nameField == value)
                {
                    return;
                }

                nameField = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Gets or sets a value representing unique numeric identifier for the enumeration table - RAW value.
        /// </summary>
        /// <value>The RAW unique numeric identifier for the enumeration table.</value>
        [XmlAttribute(AttributeName = "uid", DataType = "positiveInteger")]
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
        /// Gets or sets a value representing unique numeric identifier for the enumeration table.
        /// </summary>
        /// <value>The unique numeric identifier for the enumeration table.</value>
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

        #region Methods (1) 

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods 
    }
}
