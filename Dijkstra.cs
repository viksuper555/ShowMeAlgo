using System.Collections.Generic;
using System.Linq;

namespace ShowMeAlgo
{
    public class Dijkstra
    {
        public List<Node> PrioQueue { get; set; } = new();
        // public void DijkstraSearch(Node start)
        // {
        //     start.CostToStart = 0;
        //     PrioQueue.Add(start);
        //     do
        //     {
        //         PrioQueue = PrioQueue.OrderBy(x => x.CostToStart.HasValue).ThenBy(x => x.CostToStart).ToList();
        //         var node = PrioQueue.First();
        //         PrioQueue.Remove(node);
        //         foreach (var edge in node.Successors.OrderBy(x => x.Cost))
        //         {
        //             var childNode = edge.Node;
        //             if (childNode.Visited)
        //                 continue;
        //
        //             if (childNode.CostToStart == null ||
        //                 node.CostToStart + edge.Cost < childNode.CostToStart)
        //             {
        //                 childNode.CostToStart = node.CostToStart + edge.Cost;
        //
        //                 //childNode.NearestToStart = node;
        //                 if (!PrioQueue.Contains(childNode))
        //                     PrioQueue.Add(childNode);
        //             }
        //         }
        //         node.Visited = true;
        //     } while (PrioQueue.Any());
        // }

        // public void Initialize(Node start)
        // {
        //     if (start == null)
        //         return;
        //     PrioQueue = new List<Node>();
        //     start.CostToStart = 0;
        //     PrioQueue.Add(start);
        // }
        
        /// <summary>
        /// 
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
            return true;
        }
    }
}
