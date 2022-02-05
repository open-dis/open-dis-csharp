using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable]
    [DebuggerStepThrough]
    public class SubcategoryRange : GenericEntryRange, ISubcategoryOrSubcategoryRange
    {
        #region Fields (3) 

        private List<GenericEntryDescription> items1Field;

        private ulong uid;
        private string uidField;

        #endregion Fields 

        #region Properties (3) 

        /// <summary>
        /// Gets or sets the unique numeric identifer - RAW value.
        /// </summary>
        /// <value>The RAW unique numeric identifer.</value>
        [XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
        public string RawUId
        {
            get => uidField;

            set
            {
                if (uidField == value)
                {
                    return;
                }

                uidField = value;
                uid = ulong.Parse(value, CultureInfo.InvariantCulture);
                RaisePropertyChanged(nameof(RawUId));
            }
        }

        [XmlElement("specific", typeof(Specific), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("specific_range", typeof(SpecificRange), Form = XmlSchemaForm.Unqualified)]
        public List<GenericEntryDescription> Specifices
        {
            get => items1Field;

            set
            {
                if (items1Field == value)
                {
                    return;
                }

                items1Field = value;
                RaisePropertyChanged(nameof(Specifices));
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer.
        /// </summary>
        /// <value>The unique numeric identifer.</value>
        [XmlIgnore]
        public ulong UId
        {
            get => uid;

            set
            {
                if (uid != value)
                {
                    RawUId = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(UId));
                }
            }
        }

        #endregion Properties 
    }
}
