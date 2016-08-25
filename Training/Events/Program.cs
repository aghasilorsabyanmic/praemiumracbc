using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        async static void Main(string[] args)
        {
            var hp = new Printer("HP");
            var canon = new Printer("Canon");

            hp.PrintStarted += PrintStartedHandler;
            hp.PrintFinished += PrintFinishedHandler;
            hp.Printing += PrintingHandler;
            hp.PrintFailed += PrintFailedHandler;

            canon.PrintStarted += PrintStartedHandler;
            canon.PrintFinished += PrintFinishedHandler;
            canon.Printing += PrintingHandler;
            canon.PrintFailed += PrintFailedHandler;

            hp.LoadPaper(10);
            var hpTask = Task.Run(()=> hp.Print(10));

            canon.LoadPaper(5);
            var canonTask = Task.Run(() => canon.Print(10));

            Task.WaitAll(hpTask, canonTask);
        }

        private static void PrintStartedHandler(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            if (printer != null)
            {
                Console.WriteLine($"{printer.Name} print started");
            }
        }

        private static void PrintFinishedHandler(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            if (printer != null)
            {
                Console.WriteLine($"{printer.Name} print finished");
            }
        }

        private static void PrintingHandler(object sender, PrintingEventArgs e)
        {
            var printer = sender as Printer;
            if (printer != null)
            {
                Console.WriteLine($"{printer.Name} printing {e.Current} out of {e.Total}");
            }
        }

        private static void PrintFailedHandler(object sender, PrintFailedEventArgs e)
        {
            var printer = sender as Printer;
            if (printer != null)
            {
                switch(e.Reason)
                {
                    case PrintFailReason.Mechanical:
                        Console.WriteLine("Oops!");
                        break;
                    case PrintFailReason.Toner:
                        Console.WriteLine("Please load toner");
                        break;
                    case PrintFailReason.Paper:
                        Console.WriteLine("Not enough paper to finish print");
                        Console.WriteLine($"Please load {e.MissingPapersCount} more papers");
                        //TODO: continue logic

                        break;
                }
            }
        }

        
    }
}
