
namespace Domain.TubeModel
{
    public class TubeGraphFactory
    {
        public Graph CreateTubeGraph()
        {
            var graph = new Graph();

            // add all the nodes here
            foreach (var station in new Constants().GetStations())
            {
                graph.AddNode(station);
            }

            // add the connections 


            graph.AddConnection(Constants.Embankment, Constants.Temple, 2, ConnectionMedium.DistrictAndCircle);
            graph.AddConnection(Constants.Embankment, Constants.CharingCross, 5, ConnectionMedium.Walking);
            graph.AddConnection(Constants.Embankment, Constants.CharingCross, 2, ConnectionMedium.Bakerloo);
            graph.AddConnection(Constants.Embankment, Constants.CharingCross, 2, ConnectionMedium.Northern);
            graph.AddConnection(Constants.Temple, Constants.Blackfriars, 2, ConnectionMedium.DistrictAndCircle);
            graph.AddConnection(Constants.Blackfriars, Constants.MansionHouse, 2, ConnectionMedium.DistrictAndCircle);
            graph.AddConnection(Constants.MansionHouse, Constants.CannonStreet, 2, ConnectionMedium.DistrictAndCircle);
            graph.AddConnection(Constants.CannonStreet, Constants.Monument, 2, ConnectionMedium.DistrictAndCircle);
            graph.AddConnection(Constants.Monument, Constants.Bank, 5, ConnectionMedium.Walking);
            graph.AddConnection(Constants.Bank, Constants.StPauls, 2, ConnectionMedium.Central);
            graph.AddConnection(Constants.StPauls, Constants.ChanceryLane, 2, ConnectionMedium.Central);
            graph.AddConnection(Constants.ChanceryLane, Constants.Holborn, 2, ConnectionMedium.Central);
            graph.AddConnection(Constants.Holborn, Constants.CoventGarden, 2, ConnectionMedium.Piccadilly);
            graph.AddConnection(Constants.CoventGarden, Constants.LeicesterSquare, 2, ConnectionMedium.Piccadilly);
            graph.AddConnection(Constants.LeicesterSquare, Constants.TottenhamCourtRoad, 2, ConnectionMedium.Northern);
            graph.AddConnection(Constants.LeicesterSquare, Constants.CharingCross, 2, ConnectionMedium.Northern);

            return graph;
        }
    }
}
