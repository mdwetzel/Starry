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
        public static List<Node> Closed { get; set; }
        private static Node current;

        static Pathfinder()
        {
            Open = new List<Node>();
            Closed = new List<Node>();
        }

        public Pathfinder()
        {
            Open = new List<Node>();
            Closed = new List<Node>();
        }

        public static bool ProcessNode(Node end, Node current, Node nodeToCheck)
        {
            if (!nodeToCheck.Walkable || Closed.Contains(nodeToCheck)) {
                return false;
            }

            Color openColor = Color.Orange;


            if (Open.Contains(nodeToCheck)) {
                Node onList = Open.Find(n => n == nodeToCheck);

                if (onList.G > nodeToCheck.G + 10) {
                    onList.G = nodeToCheck.G + 10;
                    onList.H = (Math.Abs(nodeToCheck.X - end.X) + Math.Abs(nodeToCheck.Y - end.Y)) * 10;
                    onList.F = onList.G + onList.H;

                    onList.Parent = current;
                }
            } else {
                nodeToCheck.Color = openColor;
                nodeToCheck.G = current.G + 10;
                nodeToCheck.H = (Math.Abs(nodeToCheck.X - end.X) + Math.Abs(nodeToCheck.Y - end.Y)) * 10;
                nodeToCheck.F = nodeToCheck.G + nodeToCheck.H;
                nodeToCheck.Parent = current;
                Open.Add(nodeToCheck);
            }

            return true;
        }

        public static void Find(Grid grid, Node currentNode)
        {
            Node end = grid.EndNode;

            Color openColor = Color.Orange;

            int lowestScore = Int32.MaxValue;
            Node lowest = null;
            foreach (Node node in Open) {

                if (node.F <= lowestScore) {
                    lowestScore = node.F;
                    lowest = node;
                }

            }
            Open.Remove(lowest);

            Closed.Add(lowest);

            // Left.
            Node nodeToCheck = grid[currentNode.X - 1, currentNode.Y];
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);

            // Right.
            nodeToCheck = grid[currentNode.X + 1, currentNode.Y];
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);
            // Up
            nodeToCheck = grid[currentNode.X, currentNode.Y - 1];
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);
            // Down.
            nodeToCheck = grid[currentNode.X, currentNode.Y + 1];
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);

            nodeToCheck = grid[currentNode.X - 1, currentNode.Y - 1];
            // Up-left
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);


            nodeToCheck = grid[currentNode.X + 1, currentNode.Y - 1];
            // Up-right
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);

            nodeToCheck = grid[currentNode.X - 1, currentNode.Y + 1];
            // Down-left
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);


            nodeToCheck = grid[currentNode.X + 1, currentNode.Y + 1];
            // Down-right
            ProcessNode(grid.EndNode, currentNode, nodeToCheck);
            
            if (lowest == end) {
                return;
            }

            if (Open.Count == 0) {
                return;
            }

            Find(grid, lowest);
        }
    }
}
