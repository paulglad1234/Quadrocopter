using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Quadrocopter.Mechanics
{
    class LightsMechanic : IMechanic
    {
        public string FullName { get; set; }
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public object locker;
        public LightsMechanic(string fullname)
        {
            FullName = fullname;
            Position = new Vector(-75, 100);
            Velocity = Vector.Zero;
            locker = new object();
        }
        public void Draw(Graphics g, ScreenConverter sc)
        {
            Point p = sc.R2S(Position);
            g.DrawImage(Properties.Resources.lapm, p.X + 14, p.Y - 27);
            g.DrawImage(Properties.Resources.mechanic, p);
        }
        public async void RepairAsync(World w, Quadrocopter q)
        {
            await Task.Run(() => StartRepairing(w, q));
        }
        private void StartRepairing(World w, Quadrocopter q)
        {
            lock (locker)
            {
                DateTime last = DateTime.Now;
                if (Position.X > q.Position.X)
                {
                    Velocity.X = -40;
                    while (Position.X > q.Position.X)
                        Update(ref last);
                }
                else
                {
                    Velocity.X = 40;
                    while (Position.X < q.Position.X)
                        Update(ref last);
                }
                while (q.Position.Y > w.Height * 0.2f)
                {
                    last = DateTime.Now;
                }
                Repair(q);
                
            }
        }
        private void Repair(Quadrocopter q)
        {
            Thread.Sleep(1000);
            q.Lights = true;
            if (q.GPS && q.Airscrew)
                q.State = State.OK;
            if (q.Velocity.Y < 0)
                q.Velocity.Y = -q.Velocity.Y;

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
