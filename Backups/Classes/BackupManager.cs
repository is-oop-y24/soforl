using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Classes
{
    public class BackupManager
    {
        private BackupJob _backupJob;
        private Repository _repository;

        public BackupManager(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.FullName == string.Empty)
            {
                throw new Exception("Invalid path");
            }

            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }

            _backupJob = new BackupJob();
            _repository = new Repository(directoryInfo);
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

        public void BeginLocalBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            _repository.CreateBackupDir(restorePoint.GetDirectoryName());
            List<Storage> storages = _repository.CreateLocalBackup(algorithm, _backupJob.GetJobObjects(), restorePoint.GetDirectoryName(), restorePoint.GetRestorePointId());
            restorePoint.GetStorages().AddRange(storages);
            _backupJob.AddRestorePoint(restorePoint);
        }

        public void BeginAbstractBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            List<Storage> storages = _repository.CreateAbstractBackup(algorithm, _backupJob.GetJobObjects(), restorePoint.GetDirectoryName(), restorePoint.GetRestorePointId());
            restorePoint.GetStorages().AddRange(storages);
            _backupJob.AddRestorePoint(restorePoint);
        }
    }
}