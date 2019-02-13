using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quadrocopter
{
    class ScreenConverter
    {
        private Size screensize;
        private RectangleF realspace;
        public Size Screen
        {
            get { return screensize; }
            set
            {
                if (value.Height <= 0 || value.Width <= 0)
                    throw new Exception("Попытка присвоить неположительные значения размеров!");
                screensize = value;
            }
        }
        public RectangleF Real
        {
            get { return realspace; }
            set
            {
                if (value.Height <= 0 || value.Width <= 0)
                    throw new Exception("Попытка присвоить неположительные значения размеров!");
                realspace = value;
            }
        }
        public ScreenConverter(Size sz, RectangleF r)
        {
            Screen = sz;
            Real = r;
        }

        public Point R2S(Vector p)
        {
            float x = (p.X - Real.X) / Real.Width * Screen.Width;
            float y = (Real.Y - p.Y) / Real.Height * Screen.Height;
            return new Point((int)x, (int)y);
        }
        public Vector S2R(Point p)
        {
            float x = Real.X + p.X * Real.Width / Screen.Width;
            float y = Real.Y - p.Y * Real.Height / Screen.Height;
            return new Vector(x, y);
        }
        public float R2S(float val)
        {
            return val / Real.Width * Screen.Width;
        }
    }
}
