using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using Quadrocopter.Mechanics;

namespace Quadrocopter
{
    enum State
    {
        Waiting,// Color.Blue;
        OK,// Color.FromArgb(0,255,0);
        Crashed// Color.Red;
    }
    class Quadrocopter
    {
        public delegate void CrashHandler(World w, Quadrocopter q);
        public event CrashHandler GPSCrash;
        public event CrashHandler LightsAreOff;
        public event CrashHandler AirscrewCrashed;
        public int Number { get; set; }
        public bool RemoteControlIsOn { get; set; }
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public State State { get; set; }
        public Operator Operator { get; set; }
        public bool GPS { get; set; }
        public bool Lights { get; set; }
        public bool Airscrew { get; set; }
        private bool Up { get; set; }
        public Quadrocopter(Operator o, Vector position, int number)
        {
            Number = number;
            RemoteControlIsOn = false;
            Position = position;
            Velocity = Vector.Zero;
            State = State.Waiting;
            Operator = o;
            Operator.Quadrocopter = this;
            Operator.RCisOn += RCturnedOn;
            Operator.Position = position;
            GPS = true;
            Lights = true;
            Airscrew = true;
        }
        private void RCturnedOn()
        {

            State = State.OK;
            Velocity.X = 20;
            Velocity.Y = 20;
            
        }
        public void Draw(Graphics g, ScreenConverter sc)
        {
            Point p = sc.R2S(Position);
            g.DrawImage(Properties.Resources.copter, p);
            Color c = Color.Black;
            if (Lights)
            {
                switch (State)
                {
                    case State.Waiting:
                        {
                            c = Color.Blue;
                        }
                        break;
                    case State.OK:
                        {
                            c = Color.FromArgb(0, 255, 0);
                        }
                        break;
                    case State.Crashed:
                        {
                            c = Color.Red;
                        }
                        break;
                    default:
                        {
                            c = Color.Pink;
                        }
                        break;
                }
            }
            g.FillEllipse(new SolidBrush(c), p.X + 44, p.Y + 25, 10, 10);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericMonospace, 10), Brushes.Black, p.X + 44, p.Y + 10);
        }
        public void Update(World w)
        {
            DateTime last = DateTime.Now;
            while (true)
            {
                
                if (GPS && Lights && Airscrew)
                {
                    NormalUpdate(w, ref last);
                }
                else
                {
                    State = State.Crashed;
                    Up = false;
                    while (Position.Y > w.Height * 0.2f)
                    {
                        CrashedUpdate(w, ref last);
                    }
                }
                Thread.Sleep(30);
            }
        }
        private void NormalUpdate(World w, ref DateTime last)
        {
            DateTime current = DateTime.Now;
            float t = (current - last).Milliseconds * 0.001f;
            last = DateTime.Now;
            Position += Velocity * t;
            if (!Up)
                if (Position.Y > w.Height * 0.5f)
                    Up = true;
            if (Position.X < 0 || Position.X > w.Width - 100)
                Velocity.X = -Velocity.X;
            if (Up && (Position.Y < w.Height * 0.5f || Position.Y > w.Height))
                Velocity.Y = -Velocity.Y;
            Random r = new Random();
            if (r.Next(200) == 75)
            {
                GPS = false;
                GPSCrash(w, this);
            }
            if (r.Next(200) == 50)
            {
                Lights = false;
                LightsAreOff(w, this);
            }
            if (r.Next(100) == 25)
            {
                Airscrew = false;
                AirscrewCrashed(w, this);
            }
        }
        private void CrashedUpdate(World w, ref DateTime last)
        {
            DateTime current = DateTime.Now;
            float t = (current - last).Milliseconds * 0.001f;
            last = DateTime.Now;
            Position += new Vector(0, -40) * t;
        }
    }
}