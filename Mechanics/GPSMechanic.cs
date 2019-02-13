using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Mechanics
{
    class GPSMechanic : IMechanic
    {
        public string FullName { get; set; }
        public Vector Position { get; set; }
        private Vector Velocity { get; set; }
        public Quadrocopter Quadrocopter { get; set; }
        public GPSMechanic(string fullname, Quadrocopter quadrocopter)
        {
            FullName = fullname;
            Position = new Vector(-75, 100);
            Velocity = Vector.Zero;
            Quadrocopter = quadrocopter;
        }
        public void Draw(Graphics g, ScreenConverter sc)
        {
            Point p = sc.R2S(Position);
            g.DrawImage(Properties.Resources.gps, p.X + 10, p.Y - 27);
            g.DrawImage(Properties.Resources.mechanic, p);
        }
        public async void RepairAsync(World w)
        {
            await Task.Run(() => Repair(w));
        }
        public void Repair(World w)
        {
            DateTime last = DateTime.Now;
            if (Position.X > Quadrocopter.Position.X)
            {
                Velocity.X = -40;
                while (Position.X > Quadrocopter.Position.X)
                    Update(ref last);
            }
            else
            {
                Velocity.X = 40;
                while (Position.X < Quadrocopter.Position.X)
                    Update(ref last);
            }
            while(Quadrocopter.Position.Y > w.Height * 0.2f)
            {
                last = DateTime.Now;
            }
            Repair();
            last = DateTime.Now;
            Velocity.X = -50;
            while (Position.X > -50 && Position.X < w.Width + 50)
                Update(ref last);
        }
        private void Repair()
        {
            Thread.Sleep(1000);
            Quadrocopter.GPS = true;
            if (Quadrocopter.Lights && Quadrocopter.Airscrew)
                Quadrocopter.State = State.OK;
            if (Quadrocopter.Velocity.Y < 0)
                Quadrocopter.Velocity.Y = -Quadrocopter.Velocity.Y;
            
        }
        public void Update(ref DateTime last)
        {
            
                DateTime current = DateTime.Now;
                float t = (current - last).Milliseconds * 0.001f;
                last = DateTime.Now;
                Position += Velocity * t;
                Thread.Sleep(30);
            
        }
    }
}
