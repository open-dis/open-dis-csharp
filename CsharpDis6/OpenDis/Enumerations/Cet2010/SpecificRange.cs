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
    public class SpecificRange : GenericEntryRange, ISpecificOrSpecificRange
    {
        #region Fields (3) 

        private List<GenericEntryDescription> items1Field;

        private ulong uid;
        private string uidField;

        #endregion Fields 

        #region Properties (3) 

        [XmlElement("extra", typeof(Extra), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("extra_range", typeof(ExtraRange), Form = XmlSchemaForm.Unqualified)]
        public List<GenericEntryDescription> Extras
        {
            get => items1Field;

            set
            {
                if (items1Field == value)
                {
                    return;
                }

                items1Field = value;
                RaisePropertyChanged(nameof(Extras));
            }
        }

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
                    RawUId = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(UId));
                }
            }
        }

        #endregion Properties 
    }
}
