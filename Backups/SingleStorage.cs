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
                storage.JobObjects.Add(jobObject);
            }

            storages.Add(storage);
            return storages;
        }
    }
}