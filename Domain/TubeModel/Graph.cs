using System.Collections.Generic;

namespace Domain.TubeModel
{
    public class Graph
    {
        public IDictionary<string, Node> Nodes { get; private set; }
 
        public Graph()
        {
            // initialize the node list
            this.Nodes = new Dictionary<string, Node>();
        }
 
        public void AddNode(string name)
        {
            // make sure this node has not been added
            if (this.Nodes.ContainsKey(name))
            {
                return;
            }

            // create the node object giving it a name
            var node = new Node(name);

            // name is the key in the dictionary (comes from constants), node is also created with this name value
            this.Nodes.Add(name, node);
        }
 
        /// <summary>
        /// Adds a node connection a node by key.
        /// 
        /// </summary>
        /// <param name="fromNode">Used to look up in node list</param>
        /// <param name="toNode"></param>
        /// <param name="distance"></param>
        /// <param name="connectionMedium"></param>
        /// <param name="twoWay"></param>
        public void AddConnection(string fromNode, string toNode, int distance, ConnectionMedium connectionMedium, bool twoWay = true)
        {
            if (!this.Nodes.ContainsKey(fromNode))
            {
                return;
            }
            this.Nodes[fromNode].AddConnection(new NodeConnection(Nodes[toNode], distance, connectionMedium), twoWay);
        }
    }
}