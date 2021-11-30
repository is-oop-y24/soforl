using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Classes
{
    public class BackupManager
    {
        private BackupJob _backupJob;
        private IRepository _repository;

        public BackupManager(IRepository repository)
        {
            _backupJob = new BackupJob();
            _repository = repository;
        }

        public BackupJob GetBackupJob()
        {
            return _backupJob;
        }

        public void AddJobObject(JobObject jobObject)
        {
            _backupJob.GetJobObjects().Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            _backupJob.GetJobObjects().Remove(jobObject);
        }

        public void BeginBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            _repository.CreateBackupDir(restorePoint.GetDirectoryName());
            List<Storage> storages = _repository.CreateBackup(algorithm, _backupJob.GetJobObjects(), restorePoint.GetDirectoryName(), restorePoint.GetRestorePointId());
            restorePoint.GetStorages().AddRange(storages);
            _backupJob.AddRestorePoint(restorePoint);
        }
    }
}