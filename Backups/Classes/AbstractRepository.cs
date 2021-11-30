using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups.Classes
{
    public class AbstractRepository : IRepository
    {
        private DirectoryInfo _directoryInfo;

        public AbstractRepository(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.FullName == string.Empty)
            {
                throw new Exception("Invalid path");
            }

            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }

            _directoryInfo = directoryInfo;
        }

        public string GetPath()
        {
            return _directoryInfo.FullName;
        }

        public void CreateBackupDir(string directoryName)
        {
            Directory.CreateDirectory($@"{_directoryInfo.FullName}/{directoryName}");
        }

        public List<Storage> CreateBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
        {
            List<Storage> storages = algorithm.CreateStorages(jobObjects);
            foreach (Storage storage in storages)
            {
                foreach (JobObject jobObject in storage.GetJobObjects().ToList())
                {
                    string newPath =
                        @$"{_directoryInfo.FullName}/{directoryName}/{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"/") + 1)}_{id}.zip";
                    var newJobObject = new JobObject(new FileInfo(newPath));
                    storage.GetJobObjects().Add(newJobObject);
                }
            }

            return storages;
        }
    }
}