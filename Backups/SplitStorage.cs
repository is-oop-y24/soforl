using System;
using System.Collections.Generic;
using Backups.Classes;
using Ionic.Zip;

namespace Backups
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> CreateStorages(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            foreach (JobObject jobObject in jobObjects)
            {
                var storage = new Storage();
                storage.GetJobObjects().Add(jobObject);
                storages.Add(storage);
            }

            return storages;
        }
    }
}