using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesMathApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var g1 = Calculate(0.0, 2 * Math.PI, 100, Math.Sin);
            var g2 = Calculate(0.0, 2 * Math.PI, 100, x => Math.Sin(2 * x));
            var g3 = Calculate(-10.0, 10.0, 50, x => 5 * x * x + 2 * x + 1);

            Save(g1, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "sin.csv");
        }

        static IEnumerable<Point> Calculate(double xMin, double yMin, int pointsCount, Func<double, double> function)
        {
            throw new NotImplementedException();
        }

        static void Save(IEnumerable<Point> points, string path)
        {
            throw new NotImplementedException();
        }
    }
}
