using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable]
    [DebuggerStepThrough]
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

        [XmlElement("subcategory", Form = XmlSchemaForm.Unqualified)]
        public List<Subcategory> Subcategories
        {
            get => subcategoryField;

            set
            {
                if (subcategoryField != value)
                {
                    subcategoryField = value;
                    RaisePropertyChanged(nameof(Subcategories));
                }
            }
        }

        #endregion Properties 
    }
}
