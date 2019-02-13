using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quadrocopter.Mechanics
{
    interface IMechanic
    {
        string FullName { get; set; }
        Vector Position { get; set; }
        void Draw(Graphics g, ScreenConverter sc);
        void RepairAsync(World w, Quadrocopter q);
    }
}
