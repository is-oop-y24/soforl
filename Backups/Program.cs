using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Ionic.Zip;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            IRepository repository = new LocalRepository(new DirectoryInfo(@"S:\FORSTUD\oopBackup"));
            var backupManager = new BackupManager(repository);
            JobObject jobObject1 = new JobObject(new FileInfo(@"S:\FORSTUD\oopBackup\File_A"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"S:\FORSTUD\oopBackup\File_B"));
            backupManager.AddJobObject(jobObject1);
            backupManager.AddJobObject(jobObject2);
            backupManager.BeginBackup(new SingleStorage());
        }
    }
}
