using System;
using OpenDis.Enumerations;
using OpenDis.Enumerations.EntityState.Type;
namespace OpenDis.Core
{
    /// <summary>
    /// Interface for tabelaric representation of comprehensive entity-type tables
    /// </summary>
    public interface ICetItem : IComparable<ICetItem>, IComparable
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        byte Category { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        Country Country { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>The domain.</value>
        byte Domain { get; set; }

        /// <summary>
        /// Gets or sets the extra.
        /// </summary>
        /// <value>The extra.</value>
        byte? Extra { get; set; }

        /// <summary>
        /// Gets or sets the maximum value of the range.
        /// </summary>
        /// <value>The maximum value of the range.</value>
        uint? Maximum { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>The kind.</value>
        EntityKind Kind { get; set; }

        /// <summary>
        /// Gets or sets the specific.
        /// </summary>
        /// <value>The specific.</value>
        byte? Specific { get; set; }

        /// <summary>
        /// Gets or sets the subcategory.
        /// </summary>
        /// <value>The subcategory.</value>
        byte? Subcategory { get; set; }
    }
}
