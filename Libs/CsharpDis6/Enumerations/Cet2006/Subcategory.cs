using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable()]
    [DebuggerStepThrough()]
    public class Subcategory : GenericEntry
    {
		#region Fields (5) 

        private List<Specific> specificField;

        private byte id;
        private byte id2;
        private string id2Field;
        private string idField;

		#endregion Fields 

		#region Properties (5) 

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

        [XmlIgnore]
        public byte Id2
        {
            get
            {
                return this.id2;
            }

            set
            {
                if (this.id2 != value)
                {
                    this.RawId2 = ((byte)value).ToString(CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Id2");
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

        [XmlAttribute(AttributeName = "id2", DataType = "nonNegativeInteger")]
        public string RawId2
        {
            get
            {
                return this.id2Field;
            }

            set
            {
                if (this.id2Field != value)
                {
                    this.id2Field = value;
                    this.id2 = byte.Parse(value, CultureInfo.InvariantCulture);
                    this.RaisePropertyChanged("Id2");
                }
            }
        }

        [XmlElement("specific", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Specific> Specifices
        {
            get
            {
                return this.specificField;
            }

            set
            {
                if (this.specificField != value)
                {
                    this.specificField = value;
                    this.RaisePropertyChanged("Specifices");
                }
            }
        }

		#endregion Properties 
    }
}
