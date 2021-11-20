using System.Collections.Generic;

namespace ShowMeAlgo
{
    public class Graph
    {
        public static List<Node> InitGraph()
        {
            var nodes = new Dictionary<string, Node>();
            nodes.Add("1");
            nodes.Add("2");
            nodes.Add("3");
            nodes.Add("4");
            nodes.Add("5");

            nodes.Connect("1", "2", 5);
            nodes.Connect("1", "3", 15);
            nodes.Connect("2", "3", 6);
            nodes.Connect("3", "4", 2);

            var nodelist = new List<Node>(nodes.Values);
            return nodelist;
        }
    }

}