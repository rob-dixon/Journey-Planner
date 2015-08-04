namespace Domain
{
    public class TubeJourneyRequest
    {
        public string StartStation { get; private set; }
        public string FinishStation { get; private set; }
        public string ViaStation { get; private set; }
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