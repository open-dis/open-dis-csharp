using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Change request
    /// </summary>
    [Serializable]
    [DebuggerStepThrough]
    public class Cr : CetBase, INotifyPropertyChanged
    {
        #region Fields (2) 

        private ulong value;
        private string valueField;

        #endregion Fields 

        #region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Delegates and Events 

        #region Properties (2) 

        /// <summary>
        /// Gets or sets the change request number - RAW value.
        /// </summary>
        /// <value>The RAW change request number.</value>
        [XmlAttribute(AttributeName = "value", DataType = "positiveInteger")]
        public string RawValue
        {
            get => valueField;

            set
            {
                if (valueField == value)
                {
                    return;
                }

                valueField = value;
                this.value = ulong.Parse(value, CultureInfo.InvariantCulture);
                RaisePropertyChanged(nameof(RawValue));
            }
        }

        /// <summary>
        /// Gets or sets the change request number.
        /// </summary>
        /// <value>The change request number.</value>
        [XmlIgnore]
        public ulong Value
        {
            get => value;

            set
            {
                if (this.value != value)
                {
                    RawValue = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Value));
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
