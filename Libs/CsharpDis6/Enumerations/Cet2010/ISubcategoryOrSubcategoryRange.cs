using System;
using System.Collections.Generic;

namespace OpenDis.Enumerations.Cet2010
{
    public interface ISubcategoryOrSubcategoryRange : IGenericEntryDescription
    {
        //// List<ISpecificOrSpecificRange> Specifices { get; set; }
        List<GenericEntryDescription> Specifices { get; set; }
        ulong UId { get; set; }
    }
}
