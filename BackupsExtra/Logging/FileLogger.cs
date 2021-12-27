using System.IO;
using Backups.Classes;
using Serilog;

namespace BackupsExtra.Logging
{
    public class FileLogger : ILogger
    {
        public void NotifyChanges(string message)
        {
            File.AppendAllText("NotifyFile.json", message);
        }
    }
}