using System;
using System.Collections.Generic;

namespace Domain.TubeModel
{
    public class Node
    {
        public List<NodeConnection> Connections { get; set; }
 
        public string Name { get; private set; }
 
        public double DistanceFromStart { get; set; } 

        public Node(string name)
        {
            this.Name = name;

            // intialize a node object with an empty list of collections
            this.Connections = new List<NodeConnection>();
        }
 
        public virtual void AddConnection(NodeConnection nodeConnection, bool twoWay = true) // overriden
        {
            if (nodeConnection == null)
            {
                throw new ArgumentNullException("nodeConnection");
            }

            if (nodeConnection.Target == null)
            {
                throw new InvalidOperationException("nodeConnection.Target");
            }

            if (nodeConnection.Target == this)
            {
                throw new InvalidOperationException("Node may not connect to itself.");
            }

            if (nodeConnection.Distance <= 0)
            {
                throw new InvalidOperationException("Distance must be positive.");
            }
 
            this.Connections.Add(nodeConnection);

            if (twoWay)
            {
                nodeConnection.Target.AddConnection(new NodeConnection(this, nodeConnection.Distance, nodeConnection.ConnectionMedium), false);
            }
        }
    }
}
