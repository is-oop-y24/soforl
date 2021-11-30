using System.IO;
using Backups.Classes;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTests
    {
        private IRepository _repository;
        private BackupManager _backupManager;

        [SetUp]
        public void Setup()
        {
            _repository = new AbstractRepository(new DirectoryInfo("../../../Backups"));
            _backupManager = new BackupManager(_repository);
        }

        [Test]
        public void CreatingAbstractBackup()
        {
            
            JobObject jobObject1 = new JobObject(new FileInfo(@"../../../Files/File_A"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"../../../Files/File_B"));
            _backupManager.AddJobObject(jobObject1);
            _backupManager.AddJobObject(jobObject2);
            _backupManager.BeginBackup(new SplitStorage());
            _backupManager.RemoveJobObject(jobObject2);
            _backupManager.BeginBackup(new SplitStorage());

            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints().Count, 2);
            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints()[0].GetStorages().Count, 2);
            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints()[1].GetStorages().Count, 1);
        }
    }
}