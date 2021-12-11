using System;
using Serilog;
using Serilog.Core;

namespace BackupsExtra.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void NotifyAddRestorePoint()
        {
            string message = "Restore point created";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information(message);
        }

        public void NotifyAddJobObject()
        {
            string message = "Job object added";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information(message);
        }

        public void NotifyDeleteRestorePoint()
        {
            string message = "Restore point deleted";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information(message);
        }

        public void NotifyDeleteJobObject()
        {
            string message = "Job object deleted";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information(message);
        }
    }
}