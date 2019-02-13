using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Quadrocopter.Mechanics;

namespace Quadrocopter
{
    class World
    {
        public SizeF Size { get; set; }
        public float Width { get { return Size.Width; } }
        public float Height { get { return Size.Height; } }
        public List<Quadrocopter> QuadrocoptersList { get; set; }
        public GPSMechanic GPSMechanic { get; private set; }
        public AirscrewMechanic AirscrewMechanic { get; private set; }
        public LightsMechanic LightsMechanic { get; private set; }
        
        List<Thread> Threads { get; set; }
        public World(SizeF sz)
        {
            Size = sz;
            QuadrocoptersList = new List<Quadrocopter>();
            GPSMechanic = new GPSMechanic("Пупкин Василий");
            AirscrewMechanic = new AirscrewMechanic("Петр Петрович");
            LightsMechanic = new LightsMechanic("Иван Иванович");
            Threads = new List<Thread>();
        }
        public void AddQuadrocopter()
        {
            Random r = new Random();
            Quadrocopter q = new Quadrocopter(new Operator("оператор " + QuadrocoptersList.Count.ToString()),
                new Vector(r.Next(0, (int)(Width * 0.4f)), r.Next(65, (int)(Height * 0.4f))), QuadrocoptersList.Count + 1);
            q.LightsAreOff += LightsMechanic.RepairAsync;
            q.GPSCrash += GPSMechanic.RepairAsync;
            q.AirscrewCrashed += AirscrewMechanic.RepairAsync;
            QuadrocoptersList.Add(q);
            Thread t = new Thread(() => q.Update(this))
            {
                IsBackground = true
            };
            Threads.Add(t);
        }
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            DrawOperators(g, sc);
            DrawMechanics(g, sc);
            DrawCopters(g, sc);
        }
        private void DrawOperators(Graphics g, ScreenConverter sc)
        {
            foreach (Quadrocopter q in QuadrocoptersList)
            {
                q.Operator.Draw(g, sc);
            }
        }
        private void DrawMechanics(Graphics g, ScreenConverter sc)
        {
            GPSMechanic.Draw(g, sc);
            AirscrewMechanic.Draw(g, sc);
            LightsMechanic.Draw(g, sc);
        }
        private void DrawCopters(Graphics g, ScreenConverter sc)
        {
            foreach (Quadrocopter q in QuadrocoptersList)
            {
                q.Draw(g, sc);
            }
        }
        public void TurnOnRemoteControls()
        {
            foreach (Quadrocopter q in QuadrocoptersList)
            {
                if (q.State == State.Waiting)
                {
                    q.Operator.TurnOnRemoteControl();
                }
            }
            foreach (Thread t in Threads)
                if(!t.IsAlive)
                    t.Start();
        }
        public void Clear()
        {
            
            QuadrocoptersList.Clear();
            Threads.Clear();
            GPSMechanic.Position = new Vector(-75, 100);
            GPSMechanic.Velocity = Vector.Zero;
            AirscrewMechanic.Position = new Vector(-75, 100);
            AirscrewMechanic.Velocity = Vector.Zero;
            LightsMechanic.Position = new Vector(-75, 100);
            LightsMechanic.Velocity = Vector.Zero;
            foreach (Thread t in Threads)
                t.Abort();
        }
    }
}
