using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quadrocopter
{
    class Operator
    {
        public string FullName { get; set; }
        public Quadrocopter Quadrocopter { get; set; }
        public Vector Position { get; set; }
        public Operator(string fullname)
        {
            FullName = fullname;
            Quadrocopter = null;
            Position = null;
        }
        public delegate void RConHandler();
        public event RConHandler RCisOn;
        public void TurnOnRemoteControl()
        {
            Quadrocopter.RemoteControlIsOn = true;
            RCisOn();
        }
        public void Draw(Graphics g, ScreenConverter sc)
        {
            Point p = sc.R2S(Position);
            g.DrawImage(Properties.Resources._operator, p);
            g.DrawString(Quadrocopter.Number.ToString(), new Font(FontFamily.GenericMonospace, 10), Brushes.Black, p.X + 20, p.Y + 25);
        }
    }
}