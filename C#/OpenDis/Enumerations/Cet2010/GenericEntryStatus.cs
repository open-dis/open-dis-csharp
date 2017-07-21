using System;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010
{
    /// <summary>
    /// Flag to indicate the approval status of the entry.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true)]
    public enum GenericEntryStatus
    {
        /// <summary>
        /// Pending denotes that the enty has been proposed, but not yet approved by the EWG.
        /// </summary>
        pending,

        /// <summary>
        /// New means that the entry has been approved by the EWG since that last formal issue of the database.
        /// </summary>
        @new
    }
}
