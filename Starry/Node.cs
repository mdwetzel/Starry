using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Starry
{
    public class Node
    {
        public const int Size = 32;
        public Color Color { get; set; }

        public Node()
        {
            Color = Color.Gray;
        }
    }
}
