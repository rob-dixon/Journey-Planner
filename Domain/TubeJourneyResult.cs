using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class TubeJourneyResult
    {
        [DataMember]
        public TubeJourneyRequest TubeJourneyRequest { get; set; }

        [DataMember]
        public List<RouteResult> RouteResult { get; set; }
    }
}
