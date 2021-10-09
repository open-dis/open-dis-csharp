using System;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010
{
    public class CetItem : ICetItem
    {
		#region Properties (10) 

        public Country Country { get; set; }

        public byte Domain { get; set; }

        public EntityKind Kind { get; set; }

        public byte Category { get; set; }

        public byte? Subcategory { get; set; }

        public byte? Specific { get; set; }

        public byte? Extra { get; set; }

        public uint? Maximum { get; set; }

        public string Description { get; set; }

		#endregion Properties 

		#region Methods (2) 

        public int CompareTo(ICetItem other)
        {
            // By definition, any object compares greater than a null reference 
            if (other == null)
            {
                return 1;
            }

            int countryCompare = this.Country.ToString().CompareTo(other.Country.ToString());
            if (countryCompare != 0)
            {
                return countryCompare;
            }

            int domainCompare = this.Domain.CompareTo(other.Domain);
            if (domainCompare != 0)
            {
                return domainCompare;
            }

            int kindCompare = this.Kind.ToString().CompareTo(other.Kind.ToString());
            if (kindCompare != 0)
            {
                return kindCompare;
            }

            int categoryCompare = this.Category.CompareTo(other.Category);
            if (categoryCompare != 0)
            {
                return categoryCompare;
            }

            if (this.Subcategory != null)
            {
                int subcategoryCompare = ((byte)this.Subcategory).CompareTo(other.Subcategory);
                if (subcategoryCompare != 0)
                {
                    return subcategoryCompare;
                }
            }
            else
            {
                if (other.Subcategory != null)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            if (this.Specific != null)
            {
                int specificCompare = ((byte)this.Specific).CompareTo(other.Specific);
                if (specificCompare != 0)
                {
                    return specificCompare;
                }
            }
            else
            {
                if (other.Specific != null)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            if (this.Extra != null)
            {
                int extraCompare = ((byte)this.Extra).CompareTo(other.Extra);
                if (extraCompare != 0)
                {
                    return extraCompare;
                }
            }
            else
            {
                if (other.Extra != null)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                return this.Description.CompareTo(other.Description);
            }
            else
            {
                return 0;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is CetItem)
            {
                return this.CompareTo((CetItem)obj);
            }
            else
            {
                throw new ArgumentException("Object is not of type CetItem.");
            }
        }

		#endregion Methods 
    }
}
