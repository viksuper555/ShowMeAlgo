using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeAlgo
{
    public enum AlgorithmType
    {
        Dijkstra,
        AStar
    }
    public interface IAlgorithm
    {
        public Node Start { get; set; }

        public AlgorithmType Type { get; }
        public string Name { get => Type.ToString(); }
        public bool NextStep();

        public void AddNode(Node node);

        public void Connect(Node first, Node second);

        public void Clear();
        public string Result();
    }
}
