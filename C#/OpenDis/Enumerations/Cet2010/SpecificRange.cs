using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable()]
    [DebuggerStepThrough()]
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
            get
            {
                return this.items1Field;
            }

            set
            {
                if (this.items1Field == value)
                {
                    return;
                }

                this.items1Field = value;
                this.RaisePropertyChanged("Extras");
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer - RAW value.
        /// </summary>
        /// <value>The RAW unique numeric identifer.</value>
        [XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
        public string RawUId
        {
            get
            {
                return this.uidField;
            }

            set
            {
                if (this.uidField == value)
                {
                    return;
                }

                this.uidField = value;
                this.uid = ulong.Parse(value, CultureInfo.InvariantCulture);
                this.RaisePropertyChanged("RawUId");
            }
        }

        /// <summary>
        /// Gets or sets the unique numeric identifer.
        /// </summary>
        /// <value>The unique numeric identifer.</value>
        [XmlIgnore]
        public ulong UId
        {
            get
            {
                return this.uid;
            }

            set
            {
                if (this.uid != value)
                {
                    this.RawUId = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("UId");
                }
            }
        }

		#endregion Properties 
    }
}
