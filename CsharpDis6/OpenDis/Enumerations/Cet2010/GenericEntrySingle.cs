using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Attributes and elements common to enumeration entries concerning a single integer value.
    /// </summary>
    [XmlInclude(typeof(Extra))]
    [XmlInclude(typeof(Specific))]
    [XmlInclude(typeof(Subcategory))]
    [XmlInclude(typeof(Category))]
    [Serializable]
    [DebuggerStepThrough]
    public class GenericEntrySingle : GenericEntryDescription
    {
        #region Fields (1) 

        private int valueField;

        #endregion Fields 

        #region Properties (1) 

        /// <summary>
        /// Gets or sets the enumerated value.
        /// </summary>
        [XmlAttribute(AttributeName = "value")]
        public int Value
        {
            get => valueField;

            set
            {
                if (valueField == value)
                {
                    return;
                }

                valueField = value;
                RaisePropertyChanged(nameof(Value));
            }
        }

        #endregion Properties 
    }
}
