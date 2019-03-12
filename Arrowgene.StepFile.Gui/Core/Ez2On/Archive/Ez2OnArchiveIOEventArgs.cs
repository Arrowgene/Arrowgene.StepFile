using System;

namespace Arrowgene.StepFile.Core.Ez2On.Archive
{
    public class Ez2OnArchiveIOEventArgs : EventArgs
    {
        public Ez2OnArchiveIOEventArgs(string action, string message, int total, int current)
        {
            Action = action;
            Total = total;
            Current = current;
            Message = message;
        }

        public string Action { get; }
        public int Total { get; }
        public int Current { get; }
        public string Message { get; }
    }
}