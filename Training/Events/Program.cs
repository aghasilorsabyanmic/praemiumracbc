using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var hp = new Printer("HP");
            var canon = new Printer("Canon");

            hp.Printing += Hp_Printing;
            // ......
            hp.PrintFailed += Hp_PrintFailed;

            hp.LoadPaper(10);
            hp.Print(5);
        }

        private static void Hp_PrintFailed(object sender, PrintFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Hp_Printing(object sender, PrintingEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
