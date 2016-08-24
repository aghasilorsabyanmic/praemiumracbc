using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Printer
    {
        public Printer(string name)
        {
            throw new NotImplementedException();
        }

        #region Events
        public event EventHandler PrintStarted;

        public event EventHandler PrintFinished;

        public event EventHandler<PrintingEventArgs> Printing;

        public event EventHandler<PrintFailedEventArgs> PrintFailed;
        #endregion

        #region Event Raising
        protected virtual void OnPrintStarted(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPrintFinished(EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPrinting(PrintingEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPrintFailed(PrintFailedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Print(int count)
        {
            throw new NotImplementedException();
        }

        public string Name { get; private set; }

        public int RemainingPaperCount { get; private set; }

        public void LoadPaper(int count)
        {
            throw new NotImplementedException();
        }
    }
}
