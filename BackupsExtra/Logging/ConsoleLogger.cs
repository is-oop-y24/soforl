using System;
using Serilog;
using Serilog.Core;

namespace BackupsExtra.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void NotifyChanges(string message)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information(message);
        }
    }
}