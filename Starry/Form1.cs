using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starry
{
    public partial class Form1 : Form
    {
        Grid grid = new Grid(40, 40);
        bool placing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            grid.Draw(graphics);
        }

        private void pnlGrid_MouseDown(object sender, MouseEventArgs e)
        {
            // Placing a barrier.
            if (e.Button == MouseButtons.Right) {

                Node n = grid[e.X / Node.Size, e.Y / Node.Size];

                n.Walkable = n.Walkable ? false : true;

                n.Color = n.Walkable ? Color.Gray : Color.Green;

                // Placing a starting/ending point. 
            } else if (e.Button == MouseButtons.Left) {
                Node n = grid[e.X / Node.Size, e.Y / Node.Size];

                if (!placing) {
                    grid[e.X / Node.Size, e.Y / Node.Size].IsStartNode = true;
                    placing = true;

                    grid.StartNode = grid[e.X / Node.Size, e.Y / Node.Size];

                } else {
                    grid[e.X / Node.Size, e.Y / Node.Size].IsEndNode = true;

                    grid.EndNode = grid[e.X / Node.Size, e.Y / Node.Size];

                    Pathfinder.Find(grid);
                }
            }

            // Force a redraw.
            pnlGrid.Invalidate();
        }

        private void pnlGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            Node n = grid[e.X / Node.Size, e.Y / Node.Size];

            n.Walkable = n.Walkable ? false : true;

            n.Color = n.Walkable ? Color.Gray : Color.Green;

            // Force a redraw.
            pnlGrid.Invalidate();
        }

        private void pnlGrid_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }
}
