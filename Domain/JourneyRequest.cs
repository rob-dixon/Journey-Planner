using System.Linq;
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
            var stations = new Constants().GetStations().ToList();

            StartStation = stations.First(x => System.String.Compare(x, startStation, System.StringComparison.OrdinalIgnoreCase) == 0);
            FinishStation = stations.First(x => System.String.Compare(x, finishStation, System.StringComparison.OrdinalIgnoreCase) == 0);

            if (!string.IsNullOrWhiteSpace(viaStation))
            {
                ViaStation =
                    stations.First(
                        x => System.String.Compare(x, viaStation, System.StringComparison.OrdinalIgnoreCase) == 0);
            }

            if (!string.IsNullOrWhiteSpace(excludingStation))
            {
                ExcludingStation =
                    stations.First(
                        x => System.String.Compare(x, excludingStation, System.StringComparison.OrdinalIgnoreCase) == 0);
            }
        }

      
    }
}