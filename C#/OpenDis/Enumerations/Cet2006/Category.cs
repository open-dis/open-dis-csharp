using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable()]
    [DebuggerStepThrough()]
    public class Category : GenericEntry
    {
		#region Fields (3) 

        private List<Subcategory> subcategoryField;

        private byte id;
        private string idField;

		#endregion Fields 

		#region Properties (3) 

        [XmlIgnore]
        public byte Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.id != value)
                {
                    this.RawId = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        [XmlAttribute(AttributeName = "id", DataType = "nonNegativeInteger")]
        public string RawId
        {
            get
            {
                return this.idField;
            }

            set
            {
                this.VerifyNumericString(value, false);

                if (this.idField != value)
                {
                    this.idField = value;
                    this.id = byte.Parse(value, CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("RawId");
                }
            }
        }

        [XmlElement("subcategory", Form = XmlSchemaForm.Unqualified)]
        public List<Subcategory> Subcategories
        {
            get
            {
                return this.subcategoryField;
            }

            set
            {
                if (this.subcategoryField != value)
                {
                    this.subcategoryField = value;
                    this.RaisePropertyChanged("Subcategories");
                }
            }
        }

		#endregion Properties 
    }
}
