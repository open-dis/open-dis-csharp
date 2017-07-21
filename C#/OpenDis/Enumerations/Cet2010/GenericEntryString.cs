using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Attributes and elements common to enumeration entries concerning a single string value.
    /// </summary>
    [Serializable()]
    [DebuggerStepThrough()]
    public class GenericEntryString : GenericEntryDescription
    {
		#region Fields (1) 

        private string valueField;

		#endregion Fields 

		#region Properties (1) 

        /// <summary>
        /// Gets or sets the enumerated value.
        /// </summary>
        [XmlAttribute(AttributeName = "value")]
        public string Value
        {
            get
            {
                return this.valueField;
            }

            set
            {
                if (this.valueField == value)
                {
                    return;
                }

                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }

		#endregion Properties 
    }
}
