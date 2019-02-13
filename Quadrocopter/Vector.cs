using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrocopter
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float Modul { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public static Vector Zero { get { return new Vector(0, 0); } }
        public static Vector operator *(Vector v, float n)
        {
            return new Vector(v.X * n, v.Y * n);
        }
        public static Vector operator *(float n, Vector v)
        {
            return new Vector(v.X * n, v.Y * n);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public float DistanceTo(Vector v)
        {
            return (float)Math.Sqrt((v.X - X) * (v.X - X) + (v.Y - Y) * (v.Y - Y));
        }
    }
}
