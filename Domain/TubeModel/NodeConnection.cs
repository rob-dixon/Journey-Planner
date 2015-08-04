using System.Security.AccessControl;

namespace Domain.TubeModel
{
    public class NodeConnection
    {
        public Node Target { get; private set; }
        public double Distance { get; private set; }
        public ConnectionMedium ConnectionMedium { get; private set; }
        public bool IsOnBestRoute { get; set; }
 
        public NodeConnection(Node target, double distance, ConnectionMedium connectionMedium)
        {
            this.Target = target;
            this.Distance = distance;
            this.ConnectionMedium = connectionMedium;
        }
    }
}