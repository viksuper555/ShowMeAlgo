using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowMeAlgo
{
    public partial class Form1 : Form
    {
        private bool captureMouse;
        private Point captureLocation;
        private Point currentLocation;
        public bool Calculated { get; set; }
        public static int NextId { get; set; }
        public Node selectedNode { get; set; }
        private List<Node> nodes { get; set; } = new List<Node>();
        public Dijkstra Dijkstra { get; set; } = new Dijkstra();
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var node in nodes)
                node.Paint(e.Graphics, Calculated);

            using Pen pen = new(Color.DarkGray,3);
            if (captureMouse && !currentLocation.IsEmpty)
                e.Graphics.DrawLine(pen, Node.GetPointOnCircle(captureLocation, currentLocation), currentLocation);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            captureLocation = e.Location;
            captureMouse = true;

            Invalidate();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!captureMouse)
                return;

            currentLocation = e.Location;
            Invalidate();

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!captureMouse)
                return;

            if(e.Button == MouseButtons.Left)
            {
                ++NextId;
                nodes.Add(
                    new Node
                    {
                        Position = e.Location
                    });
                Calculated = false;
            }
            else if (e.Button == MouseButtons.Right && captureLocation != Point.Empty && currentLocation != Point.Empty)
            {
                var capture = nodes.Find(x => x.Contains(captureLocation));
                var current = nodes.Find(x => x.Contains(currentLocation));
                if(capture != null && current != null && capture != current)
                {
                    var existing = capture.Successors
                        .FirstOrDefault(x => x.Node.Equals(current));
                    if (existing != null)
                        existing.Cost++;
                    else
                        capture.Successors.Add(new(current));
                }
            }
            else if(e.Button == MouseButtons.Middle)
            {
                selectedNode = nodes.Find(x => x.Contains(captureLocation));
                if (selectedNode == null)
                    return;
                foreach (var node in nodes)
                {
                    node.FillColor = Color.LightSkyBlue;
                }
                selectedNode.FillColor = Color.LightCoral;
            }

            captureLocation = Point.Empty;
            currentLocation = Point.Empty;
            captureMouse = false;

            Invalidate();

        }

        private void btRun_Click(object sender, EventArgs e)
        {
            //Reset state
            foreach (var node in nodes)
            {
                node.Visited = false;
                node.CostToStart = null;
            }

            Calculated = true;
            Invalidate();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!Dijkstra.PrioQueue.Any() && selectedNode != null)
            {
                selectedNode.CostToStart = 0;
                Dijkstra.PrioQueue.Add(selectedNode);
            }

            Dijkstra.NextStep();
            Calculated = true;
            Invalidate();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            foreach (var node in nodes)
            {
                node.Visited = false;
                node.CostToStart = null;
            }
            Calculated = false;
            Invalidate();
        }
    }
}
