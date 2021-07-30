using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006
{
    [Serializable]
    [DebuggerStepThrough]
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

        #endregion Properties 
    }
}
