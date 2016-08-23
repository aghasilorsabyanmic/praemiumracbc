using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Range(1, 100);
            Enumerable.Skip(range, 5);

            range.Skip(5).Take(10);

            var x = Enumerable
                .Range(0, 101)
                .Select(i => 2 * Math.PI * i / 100);
            var y = x.Select(Math.Sin);

            var yReduced = y.Where(i => i >= 0);

            var rnd = new Random();

            var dates = Enumerable.Range(1, 100)
                .Select(d => new DateTime(2016, rnd.Next(1, 13), rnd.Next(1, 29)));

            //var newDates = dates.Where(d => d.Day > 15).Count();
            var newDates = dates.Count(d => d.Day > 15);

            var test = Where(x, i => i <= Math.PI);

            Console.WriteLine(test.FirstOrDefault());
            Console.WriteLine(test.LastOrDefault());
        }

        static IEnumerable<T> Where<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }

        static IEnumerable<int> Range(int start, int count)
        {
            for (int i = 1; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}
