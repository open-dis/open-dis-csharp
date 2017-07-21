using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Change request range
    /// </summary>
    [Serializable()]
    [DebuggerStepThrough()]
    public class CrRange : CetBase, INotifyPropertyChanged
    {
		#region Fields (2) 

        private int max;
        private int min;

		#endregion Fields 

		#region Delegates and Events (1) 

        public event PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Properties (2) 

        /// <summary>
        /// Gets or sets the maximum change request number (inclusive).
        /// </summary>
        /// <value>The maximum change request number (inclusive)..</value>
        [XmlAttribute(AttributeName = "value_max")]
        public int Max
        {
            get
            {
                return this.max;
            }

            set
            {
                if (this.max == value)
                {
                    return;
                }

                this.max = value;
                this.RaisePropertyChanged("Max");
            }
        }

        /// <summary>
        /// Gets or sets the minimum change request number (inclusive).
        /// </summary>
        /// <value>The minimum change request number (inclusive)..</value>
        [XmlAttribute(AttributeName = "value_min")]
        public int Min
        {
            get
            {
                return this.min;
            }

            set
            {
                if (this.min == value)
                {
                    return;
                }

                this.min = value;
                this.RaisePropertyChanged("Min");
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
