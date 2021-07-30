using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Attributes and elements common to enumeration entries concerning a range of integer values.
    /// </summary>
    [XmlInclude(typeof(ExtraRange))]
    [XmlInclude(typeof(SpecificRange))]
    [XmlInclude(typeof(SubcategoryRange))]
    [XmlInclude(typeof(CategoryRange))]
    [Serializable]
    [DebuggerStepThrough]
    public abstract class GenericEntryRange : GenericEntryDescription
    {
        #region Fields (2) 

        private int value_maxField;
        private int value_minField;

        #endregion Fields 

        #region Properties (2) 

        /// <summary>
        /// Gets or sets the maximum value (inclusive) of the enumerated range.
        /// </summary>
        [XmlAttribute(AttributeName = "value_max")]
        public int Max
        {
            get => value_maxField;

            set
            {
                if (value_maxField == value)
                {
                    return;
                }

                value_maxField = value;
                RaisePropertyChanged(nameof(Max));
            }
        }

        /// <summary>
        /// Gets or sets the maximum value (inclusive) of the enumerated range.
        /// </summary>
        [XmlAttribute(AttributeName = "value_min")]
        public int Min
        {
            get => value_minField;

            set
            {
                if (value_minField == value)
                {
                    return;
                }

                value_minField = value;
                RaisePropertyChanged(nameof(Min));
            }
        }

        #endregion Properties 
    }
}
