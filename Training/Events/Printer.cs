using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    public class Printer
    {
        public Printer(string name)
        {
            Name = name;
        }

        //This is for fun
        private Random rnd = new Random();

        #region Events
        public event EventHandler PrintStarted;

        public event EventHandler PrintFinished;

        public event EventHandler<PrintingEventArgs> Printing;

        public event EventHandler<PrintFailedEventArgs> PrintFailed;
        #endregion

        #region Event Raising
        protected virtual void OnPrintStarted()
        {
            Thread.Sleep(rnd.Next(500, 2000));
            PrintStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPrintFinished()
        {
            Thread.Sleep(rnd.Next(500, 2000));
            PrintFinished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPrinting(int current, int total)
        {
            var args = new PrintingEventArgs
            {
                Current = current,
                Total = total
            };

            Thread.Sleep(rnd.Next(500, 2000));
            Printing?.Invoke(this, args);
        }

        protected virtual void OnPrintFailed(int count, PrintFailReason reason)
        {
            var args = new PrintFailedEventArgs
            {
                MissingPapersCount = count,
                Reason = reason
            };

            Thread.Sleep(rnd.Next(500, 2000));
            PrintFailed?.Invoke(this, args);
        }
        #endregion

        public void Print(int count)
        {
            OnPrintStarted();

            for (int i = 1; i <= count; i++)
            {
                if(RemainingPaperCount == 0)
                {
                    Thread.Sleep(rnd.Next(500, 2000));
                    OnPrintFailed(count - i + 1, PrintFailReason.Paper);
                    break;
                }
                RemainingPaperCount--;

                Thread.Sleep(200);
                OnPrinting(i, count);
            }

            OnPrintFinished();
        }

        public string Name { get; private set; }

        public int RemainingPaperCount { get; private set; }

        public void LoadPaper(int count)
        {
            //TODO: argument check
            RemainingPaperCount += count;
        }

        internal void Continue()
        {
            throw new NotImplementedException();
        }
    }
}
