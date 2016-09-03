using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Data;

namespace Exchange.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
        }

        static async void DoWork()
        {
            var uri = new Uri("http://cb.am/latest.json.php");
            var ex = new ExchangeManager(uri);

            var result = await ex.Get();

            System.Console.WriteLine(result.Keys.Count);

            System.Console.ReadKey();
        }
    }
}
