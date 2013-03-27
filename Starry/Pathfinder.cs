using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Starry
{
    public class Pathfinder
    {
        public static List<Node> Open { get; set; }
        private static Node current;

        static Pathfinder()
        {
            Open = new List<Node>();
        }

        public Pathfinder()
        {
            Open = new List<Node>();
        }

        public static void Find(Grid grid)
        {
            Open.Add(grid.StartNode);

            current = grid.StartNode;

            Node nodeToCheck;

            // Left.
            nodeToCheck = grid[current.X - 1, current.Y];
            if (current.X > 0 && nodeToCheck.Walkable) {
                nodeToCheck.Color = Color.Red;
                Open.Add(nodeToCheck);
                // Right.
            }

            nodeToCheck = grid[current.X + 1, current.Y];
            if (nodeToCheck.X < grid.Width && nodeToCheck.Walkable) {
                nodeToCheck.Color = Color.Plum;
                Open.Add(grid[current.X + 1, current.Y]);
            }

            // Up.
            if (current.Y > 0 && grid[current.X, current.Y - 1].Walkable) {
                Open.Add(grid[current.X, current.Y - 1]);
                // Down.
            }
            if (grid[current.X, current.Y + 1].Walkable) {
                Open.Add(grid[current.X, current.Y + 1]);
            }

            // Up-left
            if (current.X > 0 && current.Y > 0 && grid[current.X - 1, current.Y - 1].Walkable) {
                Open.Add(grid[current.X - 1, current.Y - 1]);
            }

            // Up-right
            if (current.X < grid.Width && current.Y > 0 && grid[current.X + 1, current.Y - 1].Walkable) {
                Open.Add(grid[current.X - 1, current.Y + 1]);
            }

            // Down-left
            if (current.X > 0 && current.Y < grid.Height && grid[current.X - 1, current.Y + 1].Walkable) {
                Open.Add(grid[current.X - 1, current.Y + 1]);
            }

            // Down-right
            if (current.X < grid.Width && current.Y < grid.Height && grid[current.X + 1, current.Y + 1].Walkable) {
                Open.Add(grid[current.X + 1, current.Y + 1]);
                grid[current.X + 1, current.Y + 1].Color = Color.Blue;
            }
        }
    }
}
