using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Backups.Classes;
using Ionic.Zip;

namespace Backups
{
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> CreateStorages(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            foreach (JobObject jobObject in jobObjects)
            {
                storage.GetJobObjects().Add(jobObject);
            }

            storages.Add(storage);
            return storages;
        }

        /*public List<Storage> LocalBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            var zip = new ZipFile();
            foreach (JobObject jobObject in jobObjects)
            {
                string newPath =
                    @$"{repositoryPath}\{directoryName}\{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"\") + 1)}_{id}.zip";
                var job = new LocalJobObject(newPath);
                storage.GetJobObjects().Add(job);
                zip.AddFile(jobObject.GetFilePath(), "/");
            }

            storages.Add(storage);
            zip.Save($@"{repositoryPath}\{directoryName}\allArchive.zip");

            return storages;
        }

        public List<Storage> AbstractBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            foreach (JobObject jobObject in jobObjects)
            {
                string newPath =
                    $@"{repositoryPath}\{directoryName}\{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"\") + 1)}_{id}.zip";
                var job = new AbstractJobObject(jobObject.GetFilePath());
                job.ChangePath(newPath);
                storage.GetJobObjects().Add(job);
            }

            storages.Add(storage);

            return storages;
        }*/
    }
}