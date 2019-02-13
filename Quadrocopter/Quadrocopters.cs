using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Quadrocopter
{
    public partial class Quadrocopters : Form
    {
        private World w;
        private ScreenConverter sc;
        public Quadrocopters()
        {
            InitializeComponent();
            w = new World(new SizeF(pictureBox1.Width, pictureBox1.Height));
            sc = new ScreenConverter(new Size(pictureBox1.Width, pictureBox1.Height),
                new RectangleF(0, w.Height, w.Width, w.Height));
            drawTimer.Start();
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmp);
            w.DrawAll(g, sc);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }
        private DateTime last = DateTime.Now;
        private void drawTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void добавитьКвадрокоптерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w.AddQuadrocopter();
        }

        private void запуститьПультыДУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w.TurnOnRemoteControls();
        }

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            w.Clear();
        }
    }
}
