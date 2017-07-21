using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006
{
    [XmlInclude(typeof(Extra))]
    [XmlInclude(typeof(Specific))]
    [XmlInclude(typeof(Subcategory))]
    [XmlInclude(typeof(Category))]
    [Serializable()]
    [DebuggerStepThrough()]
    public class GenericEntry : CetBase, INotifyPropertyChanged
    {
		#region Fields (7) 

        private bool deletedField;
        private bool deletedFieldSpecified;
        private string descriptionField;
        private string footnoteField;
        private bool unusedField;
        private bool unusedFieldSpecified;
        private string xrefField;

		#endregion Fields 

		#region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Properties (7) 

        [XmlAttribute(AttributeName = "deleted")]
        public bool Deleted
        {
            get
            {
                return this.deletedField;
            }

            set
            {
                if (this.deletedField != value)
                {
                    this.deletedField = value;
                    this.RaisePropertyChanged("Deleted");
                }
            }
        }

        [XmlIgnore()]
        public bool DeletedSpecified
        {
            get
            {
                return this.deletedFieldSpecified;
            }

            set
            {
                if (this.deletedFieldSpecified != value)
                {
                    this.deletedFieldSpecified = value;
                    this.RaisePropertyChanged("DeletedSpecified");
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
                if (this.unusedFieldSpecified)
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
