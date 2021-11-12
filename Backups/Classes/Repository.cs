using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace Backups.Classes
{
    public class Repository
    {
        private DirectoryInfo _directoryInfo;

        public Repository(DirectoryInfo directoryInfo)
        {
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

        public List<Storage> CreateLocalBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
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

        public List<Storage> CreateAbstractBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
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