using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Comprehensive entity types factory.
    /// </summary>
    public class CetFactory
    {
		#region Static methods (3) 

        /// <summary>
        /// Creates the aggregate types.
        /// </summary>
        /// <returns>Aggregate types</returns>
        public static Cet CreateAggregateTypes()
        {
            return CreateCet("OpenDis.Enumerations.Cet2010.AggregateTypes.xml");
        }

        /// <summary>
        /// Creates the comprehensive entity-type instance.
        /// </summary>
        /// <param name="resource">The resource from which the CET is extracted.</param>
        /// <returns>Comprehensive entity-type instance</returns>
        private static Cet CreateCet(string resource)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Cet));

            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            Cet et = (Cet)serializer.Deserialize(s);

            return et;
        }

        public static List<ICetItem> Transform(Cet c)
        {
            List<ICetItem> items = new List<ICetItem>();

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
                    Extra = (m is GenericEntryRange) ? (((GenericEntryRange)m).Min != 0 ? (byte?)((GenericEntryRange)m).Min : null) : (byte)((GenericEntrySingle)m).Value,
                    Maximum = (m is GenericEntryRange) ? (((GenericEntryRange)m).Max != 0 ? (byte?)((GenericEntryRange)m).Max : null) : null,
                    Kind = e.Kind,
                    Specific = (l is GenericEntryRange) ? (((GenericEntryRange)l).Min != 0 ? (byte?)((GenericEntryRange)l).Min : null) : (byte)((GenericEntrySingle)l).Value,
                    Subcategory = (k is GenericEntryRange) ? (((GenericEntryRange)k).Min != 0 ? (byte?)((GenericEntryRange)k).Min : null) : (byte)((GenericEntrySingle)k).Value
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
                    Specific = (l is GenericEntryRange) ? (((GenericEntryRange)l).Min != 0 ? (byte?)((GenericEntryRange)l).Min : null) : (byte)((GenericEntrySingle)l).Value,
                    Maximum = (l is GenericEntryRange) ? (((GenericEntryRange)l).Max != 0 ? (byte?)((GenericEntryRange)l).Max : null) : null,
                    Subcategory = (k is GenericEntryRange) ? (((GenericEntryRange)k).Min != 0 ? (byte?)((GenericEntryRange)k).Min : null) : (byte)((GenericEntrySingle)k).Value
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
                    Subcategory = (k is GenericEntryRange) ? (((GenericEntryRange)k).Min != 0 ? (byte?)((GenericEntryRange)k).Min : null) : (byte)((GenericEntrySingle)k).Value,
                    Maximum = (k is GenericEntryRange) ? (((GenericEntryRange)k).Max != 0 ? (byte?)((GenericEntryRange)k).Max : null) : null,
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

            items = items.Concat<ICetItem>(extras).Concat<ICetItem>(specifices).Concat<ICetItem>(subcategories).Concat<ICetItem>(categories).ToList<ICetItem>();
            items.Sort();

            return items;
        }

        /// <summary>
        /// Creates the entity types.
        /// </summary>
        /// <returns>Entity types.</returns>
        public static Cet CreateEntityTypes()
        {
            return CreateCet("OpenDis.Enumerations.Cet2010.EntityTypes.xml");
        }

		#endregion Static methods 
    }
}
