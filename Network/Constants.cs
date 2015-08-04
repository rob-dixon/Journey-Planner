namespace Network.Constants
{
    public class Constants
    {
        public const string Embankment = "Embankment";
        public const string Temple = "Temple";
        public const string Blackfriars = "Blackfriars";
        public const string MansionHouse = "Mansion House";
        public const string CannonStreet = "Cannon Street";
        public const string Monument = "Monument";
        public const string Bank = "Bank";
        public const string StPauls = "St Pauls";
        public const string ChanceryLane = "Chancery Lane";
        public const string Holborn = "Holborn";
        public const string TottenhamCourtRoad = "Tottenham Court Road";
        public const string CoventGarden = "Covent Garden";
        public const string LeicesterSquare = "Leicester Square";
        public const string CharingCross = "Charing Cross";

        public string[] GetStations()
        {
            return new[]
            {
                Embankment, Temple, Blackfriars, MansionHouse, CannonStreet, Monument, Bank,
                StPauls, ChanceryLane, Holborn, CoventGarden, LeicesterSquare, TottenhamCourtRoad, CharingCross
            };
        }
    }
}
