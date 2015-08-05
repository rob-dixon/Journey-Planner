using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class TubeJourneyRequest
    {
        [DataMember]
        public string StartStation { get; private set; }
        [DataMember]
        public string FinishStation { get; set; }
        [DataMember]
        public string ViaStation { get; private set; }
        [DataMember]
        public string ExcludingStation { get; private set; }

        public TubeJourneyRequest(string startStation, string finishStation, string viaStation = null, string excludingStation = null)
        {
            StartStation = startStation;
            FinishStation = finishStation;
            ViaStation = viaStation;
            ExcludingStation = excludingStation;
        }
    }
}