using System.Collections.Generic;
using Backups.Classes;
using Ionic.Zip;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var repository = new Repository(@"S:\FORSTUD\oopBackup");
            var backupManager = new BackupManager(repository.GetPath());
            JobObject jobObject1 = new LocalJobObject(@"S:\FORSTUD\oopBackup\File_A");
            JobObject jobObject2 = new LocalJobObject(@"S:\FORSTUD\oopBackup\File_B");
            backupManager.AddJobObject(jobObject1);
            backupManager.AddJobObject(jobObject2);
            backupManager.BeginLocalBackup(new SingleStorage());
        }
    }
}
