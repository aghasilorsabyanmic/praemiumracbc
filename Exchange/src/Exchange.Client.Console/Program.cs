using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Data;

namespace Exchange.Client.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();

            Console.ReadKey();
        }

        static async void DoWork()
        {
            var uri = new Uri("http://cb.am/latest.json.php");
            var ex = new ExchangeManager(uri);

            var result = await ex.Get("usd");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
