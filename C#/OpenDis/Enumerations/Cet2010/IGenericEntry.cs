using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenDis.Enumerations.Cet2010
{
    public interface IGenericEntry : INotifyPropertyChanged
    {
        bool BaseUuid { get; set; }
        bool BaseUuidSpecified { get; set; }
        List<object> ChangeRequests { get; set; }
        bool Deprecated { get; set; }
        bool DeprecatedSpecified { get; set; }
        bool Draft1278 { get; set; }
        bool Draft1278Specified { get; set; }
        string Footnote { get; set; }
        GenericEntryStatus Status { get; set; }
        bool StatusSpecified { get; set; }
        string Uuid { get; set; }
        ulong XRef { get; set; }
    }
}
