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
        public Node Start { get; set; }
        public Node Finish { get; set; }

		public AlgorithmType Type { get => AlgorithmType.AStar; }

        public void AddNode(Node node)
        {
			PrioQueue.Enqueue(node, 0);
		}

		/// <summary>
		/// </summary>
		/// <returns>True if there is a next step.</returns>
		public bool NextStep()
        {
			if (PrioQueue == null || PrioQueue.Count <= 0)
				return false;

			var node = PrioQueue.Dequeue();

			if (node == Finish)
				return false;

			Visited.Add(node);

			foreach (var successor in node.Successors)
			{
				if (Visited.Contains(successor.Node))
					continue;

				var sNode = successor.Node;
				sNode.CostToStart = node.CostToStart + successor.Cost;

				double heuristic = CalculateCost(sNode, Finish);
				PrioQueue.Enqueue(sNode, node.CostToStart.Value + heuristic);
			}

			return PrioQueue.Count > 0;
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

        public void Clear()
        {
			Visited.Clear();
			PrioQueue.Clear();
			Finish = null;
        }

        public string Result() => $"The distance from City {Start.Id} to City {Finish.Id} is {Finish.CostToStart} km!";
    }
}
