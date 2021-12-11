using System.IO;
using Backups.Classes;
using Serilog;

namespace BackupsExtra.Logging
{
    public class FileLogger : ILogger
    {
        public void NotifyAddJobObject()
        {
            File.AppendAllText("NotifyFile.json", "Job object added");
        }

        public void NotifyAddRestorePoint()
        {
            File.AppendAllText("NotifyFile.json", "Restore Point added");
        }

        public void NotifyDeleteRestorePoint()
        {
            File.AppendAllText("NotifyFile.json", "Restore Point deleted");
        }

        public void NotifyDeleteJobObject()
        {
            File.AppendAllText("NotifyFile.json", "Job object deleted");
        }
    }
}