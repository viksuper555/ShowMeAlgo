using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeAlgo
{
    public class AStar : IAlgorithm
	{
		public PriorityQueue<Node, double> PrioQueue { get; set; } = new();
		public HashSet<Node> Visited { get; set; } = new();
        public Node Finish { get; set; }
        public AlgorithmType Type { get => AlgorithmType.AStar; }

        public void AStarSearch()
        {
			while (PrioQueue.Count > 0)
			{
				var node = PrioQueue.Dequeue();

				if (node == Finish)
					return;

				Visited.Add(node);

				foreach (var successor in node.Successors)
				{
					if (Visited.Any(n => n == successor.Node))
						continue;

					PrioQueue.Enqueue(successor.Node, node.CostToStart.Value + successor.Heuristic);
					
					
					////It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
					//if (PrioQueue(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
					//{
					//var existingTile = PrioQueue.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
					//if (existingTile.CostDistance > node.CostDistance)
					//{
					//	PrioQueue.Remove(existingTile);
					//	PrioQueue.Add(walkableTile);
					//}
					//}
					//else
					//{
					//	PrioQueue.Add(walkableTile);
					//}

				}
			}

			Console.WriteLine("No Path Found!");
		}

        public void AddNode(Node node)
        {
			PrioQueue.Enqueue(node, 0);
		}

        public bool NextStep()
        {
			throw new NotImplementedException();
        }

        public void Connect(Node first, Node second)
        {
			var existing = first.Successors
						   .FirstOrDefault(x => x.Node.Equals(second));
			if (existing == null)
            {
				var cost = CalculateCost(first, second);
				first.Successors.Add(new(second, cost));
            }
		}

        public static double CalculateCost(Node first, Node second) =>
            Math.Round(Math.Sqrt(Math.Pow(first.Position.X - second.Position.X, 2) + Math.Pow(first.Position.Y - second.Position.Y, 2)),2);
    }
}
