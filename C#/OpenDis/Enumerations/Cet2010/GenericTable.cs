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
    [Serializable()]
    [DebuggerStepThrough()]
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
        /// Gets or sets the value denoting the table is to be used to define the allowed groups for elements of the enumeration table.
        /// </summary>
        /// <value>The group value defining the allowed groups for elements of the enumeration table.</value>
        [XmlAttribute(AttributeName = "group")]
        public int Group
        {
            get
            {
                return this.groupField;
            }

            set
            {
                if (this.groupField == value)
                {
                    return;
                }

                this.groupField = value;
                this.RaisePropertyChanged("Group");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether value for group is specified.
        /// </summary>
        /// <value><c>true</c> if value for group is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool GroupSpecified
        {
            get
            {
                return this.groupFieldSpecified;
            }

            set
            {
                if (this.groupFieldSpecified == value)
                {
                    return;
                }

                this.groupFieldSpecified = value;
                this.RaisePropertyChanged("GroupSpecified");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration entry applies to a draft revision of IEEE 1278.
        /// </summary>
        /// <value><c>true</c> if the enumeration entry applies to a draft revision of IEEE 1278; otherwise, <c>false</c>.</value>
        [XmlAttribute(AttributeName = "draft1278")]
        public bool IsDraft1278
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
                this.RaisePropertyChanged("IsDraft1278");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278 is specified.
        /// </summary>
        /// <value><c>true</c> if the value indicating whether the enumeration entry applies to a draft revision of IEEE 1278 is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore()]
        public bool IsDraft1278Specified
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
                this.RaisePropertyChanged("IsDraft1278Specified");
            }
        }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }

            set
            {
                if (this.nameField == value)
                {
                    return;
                }

                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets a value representing unique numeric identifier for the enumeration table - RAW value.
        /// </summary>
        /// <value>The RAW unique numeric identifier for the enumeration table.</value>
        [XmlAttribute(AttributeName = "uid", DataType = "positiveInteger")]
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
        /// Gets or sets a value representing unique numeric identifier for the enumeration table.
        /// </summary>
        /// <value>The unique numeric identifier for the enumeration table.</value>
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
