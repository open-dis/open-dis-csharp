using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable]
    [DebuggerStepThrough]
    [XmlRoot("cet", IsNullable = false)]
    public class Cet : GenericTable
    {
        #region Fields (1) 

        private List<Entity> entityField;

        #endregion Fields 

        #region Properties (1) 

        [XmlElement("entity", Form = XmlSchemaForm.Unqualified)]
        public List<Entity> Entities
        {
            get => entityField;

            set
            {
                if (entityField == value)
                {
                    return;
                }

                entityField = value;
                RaisePropertyChanged(nameof(Entities));
            }
        }

        #endregion Properties 
    }
}
