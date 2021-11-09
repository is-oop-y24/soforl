using System;
using System.Collections.Generic;
using Backups.Classes;

namespace Backups
{
    public interface IAlgorithm
    {
        public List<Storage> LocalBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id);
        public List<Storage> AbstractBackup(List<JobObject> jobObjects, string repositoryPath, string directoryName, Guid id);
    }
}