using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Backups;
using Backups.Classes;
using BackupsExtra.Classes;
using BackupsExtra.Logging;
using Serilog;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            IRepository repository = new LocalRepository(new DirectoryInfo(@"S:\FORSTUD\oopBackup"));
            var backupManager = new BackupManagerExtra(repository);
            var jobObject1 = new JobObject(new FileInfo(@"S:\FORSTUD\oopBackup\File_A"));
            var jobObject2 = new JobObject(new FileInfo(@"S:\FORSTUD\oopBackup\File_B"));
            backupManager.AddExtraJobObject(jobObject1, new FileLogger());
            backupManager.AddExtraJobObject(jobObject2, new ConsoleLogger());
            backupManager.BeginBackup(new SplitStorage());
            backupManager.BeginBackup(new SingleStorage());
            backupManager.BeginBackup(new SingleStorage());

            backupManager.Serialize();
            List<RestorePoint> restorePoints = backupManager.Deserialize("ExtraJJ.json");
            Console.WriteLine(restorePoints[0].Storages[0].JobObjects[0].FileInfo.Name);
        }
    }
}
