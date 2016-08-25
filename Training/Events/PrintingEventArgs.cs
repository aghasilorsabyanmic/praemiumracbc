using System;

namespace Events
{
    public class PrintingEventArgs : EventArgs
    {
        public int Total { get; set; }
        public int Current { get; set; }
    }
}