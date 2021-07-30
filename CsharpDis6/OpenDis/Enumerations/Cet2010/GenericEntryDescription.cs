using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    [XmlInclude(typeof(GenericEntryRange))]
    [XmlInclude(typeof(ExtraRange))]
    [XmlInclude(typeof(SpecificRange))]
    [XmlInclude(typeof(SubcategoryRange))]
    [XmlInclude(typeof(CategoryRange))]
    [XmlInclude(typeof(GenericEntrySingle))]
    [XmlInclude(typeof(Extra))]
    [XmlInclude(typeof(Specific))]
    [XmlInclude(typeof(Subcategory))]
    [XmlInclude(typeof(Category))]
    [XmlInclude(typeof(GenericEntryString))]
    [Serializable]
    [DebuggerStepThrough]
    public abstract class GenericEntryDescription : GenericEntry, IGenericEntryDescription
    {
        #region Fields (3) 

        private string descriptionField;
        private int groupField;
        private bool groupFieldSpecified;

        #endregion Fields 

        #region Properties (3) 

        /// <summary>
        /// Gets or sets the text description of the enumeration entry.
        /// </summary>
        [XmlAttribute(AttributeName = "description")]
        public string Description
        {
            get => descriptionField;

            set
            {
                if (descriptionField == value)
                {
                    return;
                }

                descriptionField = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Gets or sets the value which indicates which group, if any, the enumeration entry belongs to.
        /// </summary>
        [XmlAttribute(AttributeName = "group")]
        public int Group
        {
            get => groupField;

            set
            {
                if (groupField == value)
                {
                    return;
                }

                groupField = value;
                RaisePropertyChanged(nameof(Group));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the group is specified.
        /// </summary>
        /// <value><c>true</c> if group is specified; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool GroupSpecified
        {
            get => groupFieldSpecified;

            set
            {
                if (groupFieldSpecified == value)
                {
                    return;
                }

                groupFieldSpecified = value;
                RaisePropertyChanged(nameof(GroupSpecified));
            }
        }

        #endregion Properties 
    }
}
