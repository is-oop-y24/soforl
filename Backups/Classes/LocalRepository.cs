using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace Backups.Classes
{
    public class LocalRepository : IRepository
    {
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

            DirectoryInfo = directoryInfo;
        }

        public DirectoryInfo DirectoryInfo { get; }

        public string GetPath()
        {
            return DirectoryInfo.FullName;
        }

        public void CreateBackupDir(string directoryName)
        {
            Directory.CreateDirectory($@"{DirectoryInfo.FullName}/{directoryName}");
        }

        public List<Storage> CreateBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id)
        {
            List<Storage> storages = algorithm.CreateStorages(jobObjects);
            foreach (Storage storage in storages)
            {
                var zip = new ZipFile();
                foreach (JobObject jobObject in storage.JobObjects.ToList())
                {
                    zip.AddFile(jobObject.GetFilePath(), "/");
                    string newPath =
                        @$"{DirectoryInfo.FullName}/{directoryName}/{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"/") + 1)}_{id}.zip";
                    var newJobObject = new JobObject(new FileInfo(newPath));
                    storage.JobObjects.Add(newJobObject);
                }

                zip.Save(@$"{DirectoryInfo.FullName}/{directoryName}/Archive{storage.Id}.zip");
            }

            return storages;
        }
    }
}