using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Comprehensive entity types factory.
    /// </summary>
    public static class CetFactory
    {
        #region Static methods (3) 

        /// <summary>
        /// Creates the aggregate types.
        /// </summary>
        /// <returns>Aggregate types</returns>
        public static Cet CreateAggregateTypes() => CreateCet("OpenDis.Enumerations.Cet2010.AggregateTypes.xml");

        /// <summary>
        /// Creates the comprehensive entity-type instance.
        /// </summary>
        /// <param name="resource">The resource from which the CET is extracted.</param>
        /// <returns>Comprehensive entity-type instance</returns>
        private static Cet CreateCet(string resource)
        {
            var serializer = new XmlSerializer(typeof(Cet));

            var s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            return (Cet)serializer.Deserialize(s);
        }

        public static List<ICetItem> Transform(Cet c)
        {
            var items = new List<ICetItem>();

            IEnumerable<ICetItem> extras =
                from e in c.Entities
                from j in e.Categories
                from k in ((ICategoryOrCategoryRange)j).Subcategories
                from l in ((ISubcategoryOrSubcategoryRange)k).Specifices
                from m in ((ISpecificOrSpecificRange)l).Extras
                select new CetItem()
                {
                    Category = (byte)((GenericEntrySingle)j).Value,
                    Country = e.Country,
                    Description = m.Description,
                    Domain = e.Domain,
                    Extra = (m is GenericEntryRange range) ? (range.Min != 0 ? (byte?)range.Min : null) : (byte)((GenericEntrySingle)m).Value,
                    Maximum = (m is GenericEntryRange range1) ? (range1.Max != 0 ? (byte?)range1.Max : null) : null,
                    Kind = e.Kind,
                    Specific = (l is GenericEntryRange range2) ? (range2.Min != 0 ? (byte?)range2.Min : null) : (byte)((GenericEntrySingle)l).Value,
                    Subcategory = (k is GenericEntryRange range3) ? (range3.Min != 0 ? (byte?)range3.Min : null) : (byte)((GenericEntrySingle)k).Value
                };

            IEnumerable<ICetItem> specifices =
                from e in c.Entities
                from j in e.Categories
                from k in ((ICategoryOrCategoryRange)j).Subcategories
                from l in ((ISubcategoryOrSubcategoryRange)k).Specifices
                select new CetItem()
                {
                    Category = (byte)((GenericEntrySingle)j).Value,
                    Country = e.Country,
                    Description = l.Description,
                    Domain = e.Domain,
                    Kind = e.Kind,
                    Specific = (l is GenericEntryRange range) ? (range.Min != 0 ? (byte?)range.Min : null) : (byte)((GenericEntrySingle)l).Value,
                    Maximum = (l is GenericEntryRange range1) ? (range1.Max != 0 ? (byte?)range1.Max : null) : null,
                    Subcategory = (k is GenericEntryRange range2) ? (range2.Min != 0 ? (byte?)range2.Min : null) : (byte)((GenericEntrySingle)k).Value
                };

            IEnumerable<ICetItem> subcategories =
                from e in c.Entities
                from j in e.Categories
                from k in ((ICategoryOrCategoryRange)j).Subcategories
                select new CetItem()
                {
                    Category = (byte)((GenericEntrySingle)j).Value,
                    Country = e.Country,
                    Description = k.Description,
                    Domain = e.Domain,
                    Kind = e.Kind,
                    Subcategory = (k is GenericEntryRange range) ? (range.Min != 0 ? (byte?)range.Min : null) : (byte)((GenericEntrySingle)k).Value,
                    Maximum = (k is GenericEntryRange range1) ? (range1.Max != 0 ? (byte?)range1.Max : null) : null,
                };

            IEnumerable<ICetItem> categories =
                from e in c.Entities
                from j in e.Categories
                select new CetItem()
                {
                    Category = (byte)((GenericEntrySingle)j).Value,
                    Country = e.Country,
                    Description = j.Description,
                    Domain = e.Domain,
                    Kind = e.Kind
                };

            items = items.Concat(extras).Concat(specifices).Concat(subcategories).Concat(categories).ToList();
            items.Sort();

            return items;
        }

        /// <summary>
        /// Creates the entity types.
        /// </summary>
        /// <returns>Entity types.</returns>
        public static Cet CreateEntityTypes() => CreateCet("OpenDis.Enumerations.Cet2010.EntityTypes.xml");

        #endregion Static methods 
    }
}
