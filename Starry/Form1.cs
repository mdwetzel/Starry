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
        private int numOfCells = 100;
        private float cellSize = 32;

        Grid grid = new Grid(40, 40);

        public Form1()
        {
            InitializeComponent();
        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;




            grid.Draw(graphics);
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
