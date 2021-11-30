using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public interface IRepository
    {
        string GetPath();
        void CreateBackupDir(string directoryName);
        List<Storage> CreateBackup(IAlgorithm algorithm, List<JobObject> jobObjects, string directoryName, Guid id);
    }
}