using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable()]
    [DebuggerStepThrough()]
    public class Extra : GenericEntry
    {
		#region Fields (2) 

        private byte id;
        private string idField;

		#endregion Fields 

		#region Properties (2) 

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

		#endregion Properties 
    }
}
