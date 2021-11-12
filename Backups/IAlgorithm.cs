using System;
using System.Collections.Generic;
using Backups.Classes;

namespace Backups
{
    public interface IAlgorithm
    {
        List<Storage> CreateStorages(List<JobObject> jobObjects);
    }
}