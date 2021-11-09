using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Classes
{
    public class Repository
    {
        private string _directoryPath;

        public Repository(string path)
        {
            _directoryPath = path;
        }

        public string GetPath()
        {
            return _directoryPath;
        }

        public void CreateBackupDir(string directoryName)
        {
            Directory.CreateDirectory($@"{_directoryPath}/{directoryName}");
        }

        public List<Storage> CreateLocalBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
        {
            return algorithm.LocalBackup(jobObjects, _directoryPath, directoryName, id);
        }

        public List<Storage> CreateAbstractBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
        {
            return algorithm.AbstractBackup(jobObjects, _directoryPath, directoryName, id);
        }
    }
}