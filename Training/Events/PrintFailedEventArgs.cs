using System;

namespace Events
{
    public class PrintFailedEventArgs : EventArgs
    {
        public PrintFailReason Reason { get; set; }
        public int MissingPapersCount { get; set; }
    }
}