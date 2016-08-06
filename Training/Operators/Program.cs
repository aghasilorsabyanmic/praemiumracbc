using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new string(new char[] { 'a', 'b' });
            var s2 = new string(new char[] { 'a', 'b' });

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(ReferenceEquals(s1, s2));

            var p1 = new Point { X = 1 };
            var p2 = new Point { X = 1 };

            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(ReferenceEquals(p1, p2));
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Point;

            if (p == null)
            {
                return false;
            }

            return (p.X == X) && (p.Y == Y);
        }

        public bool Equals(Point p)
        {
            if (p == null)
            {
                return false;
            }

            return (p.X == X) && (p.Y == Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(Point a, Point b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if((object)a == null || (object)b == null)
            {
                return false;
            }

            return (a.X == b.X) && (a.Y == b.Y);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}
