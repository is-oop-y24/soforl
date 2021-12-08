using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Classes
{
    public class BackupManager
    {
        public BackupManager(IRepository repository)
        {
            BackupJob = new BackupJob();
            Repository = repository;
        }

        public BackupJob BackupJob { get; }
        private IRepository Repository { get; }

        public void AddJobObject(JobObject jobObject)
        {
            BackupJob.JobObjects.Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            BackupJob.JobObjects.Remove(jobObject);
        }

        public void BeginBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            Repository.CreateBackupDir(restorePoint.DirectoryName);
            List<Storage> storages = Repository.CreateBackup(algorithm, BackupJob.JobObjects, restorePoint.DirectoryName, restorePoint.Id);
            restorePoint.Storages.AddRange(storages);
            BackupJob.AddRestorePoint(restorePoint);
        }
    }
}