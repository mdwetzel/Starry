using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Starry
{
    public class Node
    {
        public const int Size = 64;
        public Color Color { get; set; }
        public bool Walkable { get; set; }
        public bool IsStartNode { get; set; }
        public bool IsEndNode { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            Color = Color.Gray;
            Walkable = true;
            X = x;
            Y = y;
        }
    }
}
