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

            int countryCompare = Country.ToString().CompareTo(other.Country.ToString());
            if (countryCompare != 0)
            {
                return countryCompare;
            }

            int domainCompare = Domain.CompareTo(other.Domain);
            if (domainCompare != 0)
            {
                return domainCompare;
            }

            int kindCompare = Kind.ToString().CompareTo(other.Kind.ToString());
            if (kindCompare != 0)
            {
                return kindCompare;
            }

            int categoryCompare = Category.CompareTo(other.Category);
            if (categoryCompare != 0)
            {
                return categoryCompare;
            }

            if (Subcategory != null)
            {
                int subcategoryCompare = ((byte)Subcategory).CompareTo(other.Subcategory);
                if (subcategoryCompare != 0)
                {
                    return subcategoryCompare;
                }
            }
            else
            {
                return other.Subcategory != null ? -1 : 0;
            }

            if (Specific != null)
            {
                int specificCompare = ((byte)Specific).CompareTo(other.Specific);
                if (specificCompare != 0)
                {
                    return specificCompare;
                }
            }
            else
            {
                return other.Specific != null ? -1 : 0;
            }

            if (Extra != null)
            {
                int extraCompare = ((byte)Extra).CompareTo(other.Extra);
                if (extraCompare != 0)
                {
                    return extraCompare;
                }
            }
            else
            {
                return other.Extra != null ? -1 : 0;
            }

            return !string.IsNullOrEmpty(Description) ? Description.CompareTo(other.Description) : 0;
        }

        public int CompareTo(object obj) => obj is CetItem item ? CompareTo(item) : throw new ArgumentException("Object is not of type CetItem.");

        #endregion Methods 
    }
}
