using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable]
    [DebuggerStepThrough]
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
            get => id;

            set
            {
                if (id != value)
                {
                    RawId = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        [XmlIgnore]
        public byte Id2
        {
            get => id2;

            set
            {
                if (id2 != value)
                {
                    RawId2 = value.ToString(CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(Id2));
                }
            }
        }

        [XmlAttribute(AttributeName = "id", DataType = "nonNegativeInteger")]
        public string RawId
        {
            get => idField;

            set
            {
                VerifyNumericString(value, false);

                if (idField != value)
                {
                    idField = value;
                    id = byte.Parse(value, CultureInfo.InvariantCulture);
                    RaisePropertyChanged(nameof(RawId));
                }
            }
        }

        [XmlAttribute(AttributeName = "id2", DataType = "nonNegativeInteger")]
        public string RawId2
        {
            get => id2Field;

            set
            {
                if (id2Field != value)
                {
                    id2Field = value;
                    id2 = byte.Parse(value, CultureInfo.InvariantCulture);
                    RaisePropertyChanged("Id2");
                }
            }
        }

        [XmlElement("specific", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Specific> Specifices
        {
            get => specificField;

            set
            {
                if (specificField != value)
                {
                    specificField = value;
                    RaisePropertyChanged(nameof(Specifices));
                }
            }
        }

        #endregion Properties 
    }
}
