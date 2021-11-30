using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace Backups.Classes
{
    public class LocalRepository : IRepository
    {
        private DirectoryInfo _directoryInfo;

        public LocalRepository(DirectoryInfo directoryInfo)
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
                var zip = new ZipFile();
                foreach (JobObject jobObject in storage.GetJobObjects().ToList())
                {
                    zip.AddFile(jobObject.GetFilePath(), "/");
                    string newPath =
                        @$"{_directoryInfo.FullName}/{directoryName}/{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"/") + 1)}_{id}.zip";
                    var newJobObject = new JobObject(new FileInfo(newPath));
                    storage.GetJobObjects().Add(newJobObject);
                }

                zip.Save(@$"{_directoryInfo.FullName}/{directoryName}/Archive{storage.GetStorageId()}.zip");
            }

            return storages;
        }
    }
}