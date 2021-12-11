using System;

namespace BackupsExtra.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void NotifyAddRestorePoint()
        {
            Console.WriteLine("Restore point created");
        }

        public void NotifyAddJobObject()
        {
            Console.WriteLine("Job object added");
        }

        public void NotifyDeleteRestorePoint()
        {
            Console.WriteLine("Restore point deleted");
        }

        public void NotifyDeleteJobObject()
        {
            Console.WriteLine("Job object deleted");
        }
    }
}