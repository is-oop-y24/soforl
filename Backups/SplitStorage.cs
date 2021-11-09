using System;
using System.Collections.Generic;
using Backups.Classes;
using Ionic.Zip;

namespace Backups
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> LocalBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id)
        {
            var storages = new List<Storage>();
            foreach (JobObject jobObject in jobObjects)
            {
                var zip = new ZipFile();
                var storage = new Storage();
                storages.Add(storage);
                string newPath =
                    @$"{repositoryPath}\{directoryName}\{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"\") + 1)}_{id}.zip";
                var job = new LocalJobObject(newPath);
                storage.GetJobObjects().Add(job);
                zip.AddFile(jobObject.GetFilePath(), "/");
                zip.Save(newPath);
            }

            return storages;
        }

        public List<Storage> AbstractBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id)
        {
            var storages = new List<Storage>();
            foreach (JobObject jobObject in jobObjects)
            {
                var storage = new Storage();
                storages.Add(storage);
                string newPath =
                    $@"{repositoryPath}\{directoryName}\{jobObject.GetFilePath().Substring(jobObject.GetFilePath().LastIndexOf(@"\") + 1)}_{id}.zip";
                var job = new AbstractJobObject(jobObject.GetFilePath());
                job.ChangePath(newPath);
                storage.GetJobObjects().Add(job);
            }

            return storages;
        }
    }
}