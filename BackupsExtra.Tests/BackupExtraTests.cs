using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Backups;
using Backups.Classes;
using BackupsExtra.Classes;
using BackupsExtra.CleaningAlgorithms;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupExtraTests
    {
        private BackupManagerExtra _backupManager;
        private AbstractRepository _repository;
        
        [SetUp]
        public void Setup()
        {
            _repository = new AbstractRepository(new DirectoryInfo("../../../Backups"));
            _backupManager = new BackupManagerExtra(_repository);
        }

        [Test]
        public void CleanRestorePoints_AmountAlgorithm()
        {
            JobObject jobObject1 = new JobObject(new FileInfo(@"../../../FilesExtra/File_A"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"../../../FilesExtra/File_B"));
            _backupManager.AddJobObject(jobObject1);
            _backupManager.AddJobObject(jobObject2);
            _backupManager.BeginBackup(new SplitStorage());
            _backupManager.BeginBackup(new SplitStorage());
            _backupManager.BeginBackup(new SplitStorage());
            _backupManager.CleanPoints(new AmountCleaning(), null,2);
            Assert.AreEqual(_backupManager.BackupJob.RestorePoints.Count, 2);
        }

        [Test]
        public void MergeRestorePoints_SingleStorage()
        {
            JobObject jobObject1 = new JobObject(new FileInfo(@"../../../FilesExtra/File_A"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"../../../FilesExtra/File_B"));
            _backupManager.AddJobObject(jobObject1);
            _backupManager.AddJobObject(jobObject2);
            _backupManager.BeginBackup(new SplitStorage());
            _backupManager.BeginBackup(new SingleStorage());
            _backupManager.MergePointsSingleStorage();
            Assert.AreEqual(_backupManager.BackupJob.RestorePoints.Count, 1);
        }
    }
}