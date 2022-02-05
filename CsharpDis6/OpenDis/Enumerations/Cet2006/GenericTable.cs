using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006
{
    [XmlInclude(typeof(Cet))]
    [Serializable]
    [DebuggerStepThrough]
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
            get => cnameField;

            set
            {
                if (cnameField != value)
                {
                    cnameField = value;
                    RaisePropertyChanged(nameof(CName));
                }
            }
        }

        [XmlIgnore]
        public ulong Id
        {
            get => id;

            set
            {
                if (id != value)
                {
                    RawId = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        [XmlIgnore]
        public ulong Length
        {
            get => length;

            set
            {
                if (length != value)
                {
                    RawLength = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Length));
                }
            }
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name
        {
            get => nameField;

            set
            {
                if (nameField != value)
                {
                    nameField = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        [XmlAttribute(AttributeName = "id", DataType = "positiveInteger")]
        public string RawId
        {
            get => idField;

            set
            {
                if (idField != value)
                {
                    idField = value;
                    id = ulong.Parse(value, CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(RawId));
                }
            }
        }

        [XmlAttribute(AttributeName = "length", DataType = "positiveInteger")]
        public string RawLength
        {
            get => lengthField;

            set
            {
                if (lengthField != value)
                {
                    lengthField = value;
                    length = ulong.Parse(value, CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(RawLength));
                }
            }
        }

        [XmlAttribute(AttributeName = "source")]
        public string Source
        {
            get => sourceField;

            set
            {
                if (sourceField != value)
                {
                    sourceField = value;
                    RaisePropertyChanged(nameof(Source));
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
