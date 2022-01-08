using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShowMeAlgo
{
    public class Edge
    {
        public Node Node { get; set; }
        public double Cost { get; set; }
        public double Heuristic { get; set; }
        public Edge(Node node, double cost = 1, double heuristic = 0)
        {
            Node = node;
            Cost = cost;
            Heuristic = heuristic;
        }
    }

    public class Node
    {
        public static readonly int Radius = 30;
        public Point Position { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Edge> Successors { get; set; } = new();
        public bool Visited { get; set; }
        public double? CostToStart { get; set; }

        public Color FillColor
        {
            get
            {
                if (CostToStart != null) 
                    return Color.Gold;
                return Color.LightSkyBlue;
            }
        }

        public Node()
        {
            Id = AlgorithmVisualiser.NextId;
            Name = Id.ToString();
        }

        public Node(string name) : this()
        {
            Name = name;
        }

        public void Paint(Graphics graphics, bool finished, Color? fillColor = null)
        {

            using (SolidBrush brush = new(fillColor ?? FillColor))
                graphics.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);

            using (Pen pen = new(Color.Black, 2))
                graphics.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);

            Font font = new("Arial", 16);
            using (SolidBrush brush = new(Color.Black))
            {
                int middle = Position.X - (int)(Radius / (3 - Math.Floor(Math.Log10(Id))));
                graphics.DrawString(Name, font, brush, middle, Position.Y - Radius/3);
                if(finished || CostToStart.HasValue)
                    graphics.DrawString(CostToStart.Print(), font, brush, Position.X - Radius / 2, Position.Y + Radius);
            }

            foreach(var edge in Successors)
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                using Pen pen = new(Color.Black, 3);
                pen.CustomEndCap = bigArrow;
                graphics.DrawLine(pen, GetPointOnCircle(Position,edge.Node.Position), GetPointOnCircle(edge.Node.Position,Position));
                var xOffset = Position.X - edge.Node.Position.X > 0 ? 15 : -15;

                var xDiffAbs = Math.Abs(Position.X - edge.Node.Position.X);
                var yDiffAbs = Math.Abs(Position.Y - edge.Node.Position.Y);
                bool isVertical = yDiffAbs > xDiffAbs;

                var xPos = Math.Min(Position.X, edge.Node.Position.X) + xDiffAbs / 2;
                var yPos = Math.Min(Position.Y, edge.Node.Position.Y) + yDiffAbs / 2;
                if(isVertical)
                {
                    xPos += 5;
                    yPos += (Position.X - edge.Node.Position.X > 0 ? 15 : -15);
                }
                else
                {
                    xPos += xOffset;
                    yPos += 5;
                }

                using (SolidBrush brush = new(Color.Black))
                {
                    graphics.DrawString(edge.Cost.ToString(), font, brush, xPos, yPos);
                    if (isVertical)
                        graphics.DrawString(Position.Y - edge.Node.Position.Y > 0 ? "↑" : "↓", font, brush, xPos+10, yPos);
                    else
                        graphics.DrawString(xOffset > 0 ? "←" : "→", font, brush, xPos-2, yPos+10);
                }
            }
        }
        public bool Contains(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X - Position.X, 2) + Math.Pow(p.Y - Position.Y, 2)) < Radius;
        }
        public static Point GetPointOnCircle(Point p1, Point p2)
        {
            Point pointref = Point.Subtract(p2, new Size(p1));
            double degrees = Math.Atan2(pointref.Y, pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            return new Point((int)(cosx1 * (float)(Radius) + (float)p1.X), (int)(siny1 * (float)(Radius) + (float)p1.Y));
        }
    }
    public static class NodeHelper
    {
        public static void Add(this Dictionary<string, Node> dict, string nodename, Point? position = null)
        {
            Node node = new(nodename);
            if (position != null)
                node.Position = position.Value;
            dict.Add(nodename, node);
        }
        public static void Connect(this Dictionary<string, Node> dict, string from, string to, int cost = 1)
        {
            dict[from].Successors.Add(new Edge(dict[to], cost));
            //dict[to].Predecessors.Add(new Edge(dict[from], cost));
        }

        public static string Print(this double? n)
        {
            return n.HasValue ? n.ToString() : "∞";
        }
    }
}
