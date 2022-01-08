using System.Collections.Generic;
using System.Linq;

namespace ShowMeAlgo
{
    public class Dijkstra : IAlgorithm
    {
        public List<Node> PrioQueue { get; set; } = new();
        public AlgorithmType Type { get => AlgorithmType.Dijkstra; }
        public Node Start { get; set; }

        public void AddNode(Node node)
        {
            PrioQueue.Add(node);
        }

        public void Clear()
        {
            PrioQueue.Clear();
        }

        public void Connect(Node first, Node second)
        {
            var existing = first.Successors
                            .FirstOrDefault(x => x.Node.Equals(second));
            if (existing != null)
                existing.Cost++;
            else
                first.Successors.Add(new(second));
        }

        /// <summary>
        /// </summary>
        /// <returns>True if there is a next step.</returns>
        public bool NextStep() 
        {
            if (PrioQueue == null || !PrioQueue.Any())
                return false;

            PrioQueue = PrioQueue.OrderBy(x => x.CostToStart.HasValue).ThenBy(x => x.CostToStart).ToList();
            var node = PrioQueue.First();
            PrioQueue.Remove(node);
            foreach (var edge in node.Successors.OrderBy(x => x.Cost))
            {
                var childNode = edge.Node;
                
                if (childNode.Visited)
                    continue;

                if (childNode.CostToStart == null ||
                    node.CostToStart + edge.Cost < childNode.CostToStart)
                {
                    childNode.CostToStart = node.CostToStart + edge.Cost;

                    //childNode.NearestToStart = node;
                    if (!PrioQueue.Contains(childNode))
                        PrioQueue.Add(childNode);
                }
            }
            node.Visited = true;
            return PrioQueue.Any();
        }

        public string Result() => $"Algorithm finished!";
    }
}
