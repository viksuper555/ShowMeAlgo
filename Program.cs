using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowMeAlgo
{
    static class Program
    {

        //[STAThread]
        static void Main()
        {
            //var graph = Graph.InitGraph();
            //Dijkstra.DijkstraSearch(graph.First());
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            //Node node = new Node();
            //Node node2 = new Node();
            //node.Connections.Add(node2);
            //node2.Connections.Add(node);
            //node2.ConnectedNode = node;
            //Dijkstra algo = new Dijkstra();
            //algo.Start = node;
            //algo.End = node2;
            //var a = algo.GetShortestPathDijkstra();

            //Dijkstra(graph, 0, 9);
        }       
    }
}
