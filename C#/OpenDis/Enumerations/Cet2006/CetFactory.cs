using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006
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
            return CreateCet("OpenDis.Enumerations.Cet2006.AggregateTypes.xml");
        }

        public static List<ICetItem> Transform(Cet c)
        {
            List<ICetItem> items = new List<ICetItem>();

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
                    Extra = m.Id != 0 ? (byte?)m.Id : null,
                    Kind = e.Kind,
                    Specific = l.Id != 0 ? (byte?)l.Id : null,
                    Subcategory = k.Id != 0 ? (byte?)k.Id : null
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
                    Specific = l.Id != 0 ? (byte?)l.Id : null,
                    Maximum = l.Id2 != 0 ? (byte?)l.Id2 : null,
                    Subcategory = k.Id != 0 ? (byte?)k.Id : null
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
                    Subcategory = k.Id != 0 ? (byte?)k.Id : null,
                    Maximum = k.Id2 != 0 ? (byte?)k.Id2 : null
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

            items = items.Concat<ICetItem>(extras).Concat<ICetItem>(specifices).Concat<ICetItem>(subcategories).Concat<ICetItem>(categories).ToList<ICetItem>();
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
            XmlSerializer serializer = new XmlSerializer(typeof(Cet));

            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            Cet et = (Cet)serializer.Deserialize(s);

            return et;
        }

        /// <summary>
        /// Creates the entity types.
        /// </summary>
        /// <returns>Entity types.</returns>
        public static Cet CreateEntityTypes()
        {
            return CreateCet("OpenDis.Enumerations.Cet2006.EntityTypes.xml");
        }

		#endregion Static methods 
    }
}
