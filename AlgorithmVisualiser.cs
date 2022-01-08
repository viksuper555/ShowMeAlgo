using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShowMeAlgo;

public partial class AlgorithmVisualiser : Form
{
    private bool _captureMouse;
    private Point _captureLocation;
    private Point _currentLocation;
    private Point _hoverLocation;
    private static readonly int XOffset = 50;
    public bool Started { get; set; }
    public bool Finished { get; set; }
    public static int NextId { get; set; }
    public Node StartNode { get; set; }
    public Node EndNode { get; set; }
    private List<Node> Nodes { get; set; } = new();
    public IAlgorithm Algorithm { get; set; } = new Dijkstra();
    public AlgorithmVisualiser()
    {
        InitializeComponent();
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        foreach (var node in Nodes)
            node.Paint(e.Graphics, Finished);
        StartNode?.Paint(e.Graphics, Finished, Color.LightCoral);
        EndNode?.Paint(e.Graphics, Finished, Color.Purple);

        using Pen pen = new(Color.DarkGray, 3);
        if (_captureMouse && !_currentLocation.IsEmpty)
        {
            var circlePoint = Node.GetPointOnCircle(_captureLocation, _currentLocation);
            e.Graphics.DrawLine(pen, circlePoint, _currentLocation);
        }
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
        {
            _hoverLocation = e.Location;
            return;
        }


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
                    if (capture != null && current != null && capture != current)
                        Algorithm.Connect(capture, current);

                    break;
                }
            case MouseButtons.Middle:
                {
                    var selectedNode = Nodes.Find(x => x.Contains(_captureLocation));
                    if (selectedNode == null)
                    {
                        if (StartNode != null)
                        { 
                            StartNode.CostToStart = null;
                            StartNode.Visited = false;
                        }
                        StartNode = null;
                        EndNode = null;
                        break;
                    }

                    if (StartNode != null && Algorithm.Type == AlgorithmType.AStar)
                    {
                        if (selectedNode == StartNode)
                            break;
                        EndNode = selectedNode;
                    }
                    else
                    {
                        foreach (var node in Nodes)
                        {
                            node.CostToStart = null;
                            node.Visited = false;
                        }

                        StartNode = selectedNode;
                        StartNode.CostToStart = 0;
                        StartNode.Visited = true;
                    }

                    break;
                }
        }

        _captureLocation = Point.Empty;
        _currentLocation = Point.Empty;
        _captureMouse = false;

        Invalidate();

    }

    private void btNext_Click(object sender, EventArgs e)
    {
        if (StartNode == null)
        {
            MessageBox.Show("Please select a start node using the mouse scroll button.", "No node selected.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        else if(EndNode == null && Algorithm.Type == AlgorithmType.AStar)
        {
            MessageBox.Show("Please select a finish node using the mouse scroll button.", "No node selected.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Started)
        {
            Algorithm.AddNode(StartNode);
            Started = true;
            Algorithm.Start = StartNode;
            if(Algorithm.Type == AlgorithmType.AStar)
                ((AStar)Algorithm).Finish = EndNode;
        }

        Finished = !Algorithm.NextStep();
        if (Finished)
            MessageBox.Show(Algorithm.Result(), "Finished!");
        Invalidate();
    }

    private void btClear_Click(object sender, EventArgs e)
    {
        Algorithm.Clear();

        StartNode = null;
        EndNode = null;
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
        Algorithm.Clear();

        Nodes = new List<Node>();
        NextId = 0;
        btClear_Click(sender, e);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            for (int i = Nodes.Count() - 1; i >= 0; i--)
            {
                if (Nodes[i].Contains(_hoverLocation))
                    Nodes.RemoveAt(i);
            }
        }
        Invalidate();
    }

    private void btGenerate_Click(object sender, EventArgs e)
    {
        var form = new GenerateForm();
        Random rnd = new Random();
        if (form.ShowDialog() == DialogResult.OK)
        {
            int nodeCount = form.NodeCount;
            int edgeDepth = form.EdgeDepth;
            int maxWeight = form.MaxEdgeWeight;
            var nodes = new Dictionary<string, Node>();
            int xMax = Width - 10;

            int curX = XOffset, curY = 200;

            NextId = 0;
            for (int i = 1; i <= nodeCount; i++)
            {
                NextId++;
                nodes.Add(i.ToString(), new Point(curX, curY + i / 2 * 10 + (i % 2 == 0 ? Node.Radius * 4 : 0)));

                curX += Node.Radius * 6;
                if (curX >= xMax)
                {
                    curX = XOffset;
                    curY += Node.Radius * 6;
                }
            }

            //Edge creation done by partially using the Fisher–Yates shuffle
            for (int i = nodeCount; i > 0; i--)
            {
                for (int n = 0; n < edgeDepth; n++)
                {
                    int j = rnd.Next(1, nodeCount + 1);
                    int weight = rnd.Next(1, maxWeight + 1);

                    if (i != j)
                        nodes.Connect(i.ToString(), j.ToString(), weight);
                }

            }

            var nodelist = new List<Node>(nodes.Values);
            Nodes = nodelist;
        }
        Invalidate();
    }

    private void btSwitchAlgorithm_Click(object sender, EventArgs e)
    {
        Algorithm = Algorithm.Type == AlgorithmType.Dijkstra ? new AStar() : new Dijkstra();
        labelCurrentAlgo.Text = $"{Algorithm.Name}";
    }
}
