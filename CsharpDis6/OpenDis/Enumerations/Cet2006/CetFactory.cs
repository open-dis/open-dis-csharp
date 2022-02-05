using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006
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
        public static Cet CreateAggregateTypes() => CreateCet("OpenDis.Enumerations.Cet2006.AggregateTypes.xml");

        public static List<ICetItem> Transform(Cet c)
        {
            var items = new List<ICetItem>();

            IEnumerable<ICetItem> extras =
                from e in c.Entities
                from j in e.Categories
                from k in j.Subcategories
                from l in k.Specifices
                from m in l.Extras
                select new CetItem()
                {
                    Category = j.Id,
                    Country = e.Country,
                    Description = m.Description,
                    Domain = e.Domain,
                    Extra = m.Id != 0 ? m.Id : null,
                    Kind = e.Kind,
                    Specific = l.Id != 0 ? l.Id : null,
                    Subcategory = k.Id != 0 ? k.Id : null
                };

            IEnumerable<ICetItem> specifices =
                from e in c.Entities
                from j in e.Categories
                from k in j.Subcategories
                from l in k.Specifices
                select new CetItem()
                {
                    Category = j.Id,
                    Country = e.Country,
                    Description = l.Description,
                    Domain = e.Domain,
                    Kind = e.Kind,
                    Specific = l.Id != 0 ? l.Id : null,
                    Maximum = l.Id2 != 0 ? l.Id2 : null,
                    Subcategory = k.Id != 0 ? k.Id : null
                };

            IEnumerable<ICetItem> subcategories =
                from e in c.Entities
                from j in e.Categories
                from k in j.Subcategories
                select new CetItem()
                {
                    Category = j.Id,
                    Country = e.Country,
                    Description = k.Description,
                    Domain = e.Domain,
                    Kind = e.Kind,
                    Subcategory = k.Id != 0 ? k.Id : null,
                    Maximum = k.Id2 != 0 ? k.Id2 : null
                };

            IEnumerable<ICetItem> categories =
                from e in c.Entities
                from j in e.Categories
                select new CetItem()
                {
                    Category = j.Id,
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

        /// <summary>
        /// Creates the entity types.
        /// </summary>
        /// <returns>Entity types.</returns>
        public static Cet CreateEntityTypes() => CreateCet("OpenDis.Enumerations.Cet2006.EntityTypes.xml");

        #endregion Static methods 
    }
}
