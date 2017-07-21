using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    [Serializable()]
    [DebuggerStepThrough()]
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
            get
            {
                return this.entityField;
            }

            set
            {
                if (this.entityField == value)
                {
                    return;
                }

                this.entityField = value;
                this.RaisePropertyChanged("Entities");
            }
        }

		#endregion Properties 
    }
}
