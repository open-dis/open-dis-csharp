using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006
{
    [XmlInclude(typeof(Cet))]
    [Serializable()]
    [DebuggerStepThrough()]
    public class GenericTable : CetBase, INotifyPropertyChanged
    {
		#region Fields (7) 

        private string cnameField;
        private ulong id;
        private string idField;
        private ulong length;
        private string lengthField;
        private string nameField;
        private string sourceField;

		#endregion Fields 

		#region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Properties (7) 

        [XmlAttribute(AttributeName = "cname")]
        public string CName
        {
            get
            {
                return this.cnameField;
            }

            set
            {
                if (this.cnameField != value)
                {
                    this.cnameField = value;
                    this.RaisePropertyChanged("CName");
                }
            }
        }

        [XmlIgnore]
        public ulong Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.id != value)
                {
                    this.RawId = ((ulong)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        [XmlIgnore]
        public ulong Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (this.length != value)
                {
                    this.RawLength = ((ulong)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Length");
                }
            }
        }

        [XmlAttributeAttribute(AttributeName = "name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }

            set
            {
                if (this.nameField != value)
                {
                    this.nameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [XmlAttribute(AttributeName = "id", DataType = "positiveInteger")]
        public string RawId
        {
            get
            {
                return this.idField;
            }

            set
            {
                if (this.idField != value)
                {
                    this.idField = value;
                    this.id = ulong.Parse(value, CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("RawId");
                }
            }
        }

        [XmlAttributeAttribute(AttributeName = "length", DataType = "positiveInteger")]
        public string RawLength
        {
            get
            {
                return this.lengthField;
            }

            set
            {
                if (this.lengthField != value)
                {
                    this.lengthField = value;
                    this.length = ulong.Parse(value, CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("RawLength");
                }
            }
        }

        [XmlAttributeAttribute(AttributeName = "source")]
        public string Source
        {
            get
            {
                return this.sourceField;
            }

            set
            {
                if (this.sourceField != value)
                {
                    this.sourceField = value;
                    this.RaisePropertyChanged("Source");
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
