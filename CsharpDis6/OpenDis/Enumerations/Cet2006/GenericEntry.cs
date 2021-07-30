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
    [Serializable]
    [DebuggerStepThrough]
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
            get => deletedField;

            set
            {
                if (deletedField != value)
                {
                    deletedField = value;
                    RaisePropertyChanged(nameof(Deleted));
                }
            }
        }

        [XmlIgnore]
        public bool DeletedSpecified
        {
            get => deletedFieldSpecified;

            set
            {
                if (deletedFieldSpecified != value)
                {
                    deletedFieldSpecified = value;
                    RaisePropertyChanged(nameof(DeletedSpecified));
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
                if (unusedFieldSpecified)
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
