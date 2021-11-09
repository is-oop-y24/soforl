using Backups.Classes;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTests
    {
        private Repository _repository;
        private BackupManager _backupManager;

        [SetUp]
        public void Setup()
        {
            _repository = new Repository("../../../Backups");
            _backupManager = new BackupManager(_repository.GetPath());
        }

        [Test]
        public void CreatingAbstractBackup()
        {
            
            JobObject jobObject1 = new AbstractJobObject(@"../../../Files/File_A");
            JobObject jobObject2 = new AbstractJobObject(@"../../../Files/File_B");
            _backupManager.AddJobObject(jobObject1);
            _backupManager.AddJobObject(jobObject2);
            _backupManager.BeginAbstractBackup(new SplitStorage());
            _backupManager.RemoveJobObject(jobObject2);
            _backupManager.BeginAbstractBackup(new SplitStorage());

            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints().Count, 2);
            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints()[0].GetStorages().Count, 2);
            Assert.AreEqual(_backupManager.GetBackupJob().GetRestorePoints()[1].GetStorages().Count, 1);
        }
    }
}