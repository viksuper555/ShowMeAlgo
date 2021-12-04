using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShowMeAlgo
{
    public partial class Form1 : Form
    {
        private bool _captureMouse;
        private Point _captureLocation;
        private Point _currentLocation;
        
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public static int NextId { get; set; }
        public Node SelectedNode { get; set; }
        private List<Node> Nodes { get; set; } = new();
        public Dijkstra Dijkstra { get; set; } = new();
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var node in Nodes)
                node.Paint(e.Graphics, Finished);

            using Pen pen = new(Color.DarkGray,3);
            if (_captureMouse && !_currentLocation.IsEmpty)
                e.Graphics.DrawLine(pen, Node.GetPointOnCircle(_captureLocation, _currentLocation), _currentLocation);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _captureLocation = e.Location;
            _captureMouse = true;

            Invalidate();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;

            _currentLocation = e.Location;
            Invalidate();

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    ++NextId;
                    Nodes.Add(
                        new Node
                        {
                            Position = e.Location
                        });
                    Finished = false;
                    break;
                case MouseButtons.Right when _captureLocation != Point.Empty && _currentLocation != Point.Empty:
                {
                    var capture = Nodes.Find(x => x.Contains(_captureLocation));
                    var current = Nodes.Find(x => x.Contains(_currentLocation));
                    if(capture != null && current != null && capture != current)
                    {
                        var existing = capture.Successors
                            .FirstOrDefault(x => x.Node.Equals(current));
                        if (existing != null)
                            existing.Cost++;
                        else
                            capture.Successors.Add(new(current));
                    }

                    break;
                }
                case MouseButtons.Middle:
                {
                    SelectedNode = Nodes.Find(x => x.Contains(_captureLocation));
                    if (SelectedNode == null)
                        return;
                    foreach (var node in Nodes)
                    {
                        node.CostToStart = null;
                        SelectedNode.Visited = false;
                    }
                    SelectedNode.CostToStart = 0;
                    SelectedNode.Visited = true;
                    break;
                }
            }

            _captureLocation = Point.Empty;
            _currentLocation = Point.Empty;
            _captureMouse = false;

            Invalidate();

        }

        private void btRun_Click(object sender, EventArgs e)
        {
            //Reset state
            foreach (var node in Nodes)
            {
                node.Visited = false;
                node.CostToStart = null;
            }

            Finished = true;
            Invalidate();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
            {
                MessageBox.Show("Please select a node using the mouse scroll button.", "No node selected.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Started)
            {
                Dijkstra.PrioQueue.Add(SelectedNode);
                Started = true;
            }

            Finished = !Dijkstra.NextStep();
            Invalidate();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            SelectedNode = null;
            foreach (var node in Nodes)
            {
                node.Visited = false;
                node.CostToStart = null;
            }
            Started = false;
            Finished = false;
            Invalidate();
        }
        private void btRestart_Click(object sender, EventArgs e)
        {
            Nodes = new List<Node>();
            btClear_Click(sender, e);
        }
    }
}
