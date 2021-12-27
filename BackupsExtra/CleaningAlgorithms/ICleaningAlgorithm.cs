using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.CleaningAlgorithms
{
    public interface ICleaningAlgorithm
    {
        void CleanRestorePoints(BackupJob backupJob, DateTime? dateTime = null, int? count = null);
    }
}