using System;
using System.Text;

namespace DelegatesAndEvents.CustomEvents
{
    public class FileArgs : EventArgs
    {
        public StringBuilder Message { get; set; }

        public bool IsAborted { get; set; }

        public FileArgs(StringBuilder notificationMessage)
        {
            Message = notificationMessage;
        }

        public FileArgs(bool isAborted)
        {
            IsAborted = isAborted;
        }
    }

    public delegate void FileStatusEventHandler(object sender, FileArgs e);
}