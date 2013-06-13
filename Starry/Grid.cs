using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Starry
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Node CurrentNode { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        private Node[,] nodes;

        public Grid(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            nodes = new Node[width, height];

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    nodes[x, y] = new Node(x, y);
                }
            }
        }

        public Node this[int x, int y]
        {
            get { return nodes[x, y]; }
        }

        public void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Brushes.Black, 1);
            int numOfCells = Width * Height;
            Font f = new Font("Arial", 10);
            // Draw the individual nodes.
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Node n = this[x, y];

                    graphics.FillRectangle(new SolidBrush(n.Color), new Rectangle(x * Node.Size, y * Node.Size, Node.Size, Node.Size));
                    graphics.DrawString(string.Format("G: {0}", n.G), f, new SolidBrush(Color.Black), n.X * Node.Size, n.Y * Node.Size);
                    graphics.DrawString(string.Format("H: {0}", n.H), f, new SolidBrush(Color.Black), n.X * Node.Size, n.Y * Node.Size + 20);
                    graphics.DrawString(string.Format("F: {0}", n.F), f, new SolidBrush(Color.Black), n.X * Node.Size, n.Y * Node.Size + 40);
                }
            }

            // Draw the grid's lines.
            for (int i = 0; i < numOfCells; i++) {
                graphics.DrawLine(pen, i * Node.Size, 0, i * Node.Size, numOfCells * Node.Size);

                graphics.DrawLine(pen, 0, i * Node.Size, numOfCells * Node.Size, i * Node.Size);
            }
        }
    }
}
