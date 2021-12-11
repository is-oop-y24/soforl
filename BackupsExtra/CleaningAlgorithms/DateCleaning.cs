using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Classes;

namespace BackupsExtra.CleaningAlgorithms
{
    public class DateCleaning : ICleaningAlgorithm
    {
        public void CleanRestorePoints(BackupJob backupJob, DateTime? dateTime, int? count)
        {
            foreach (RestorePoint restorePoint in backupJob.RestorePoints)
            {
                if (restorePoint.DateBackup < dateTime)
                {
                    backupJob.RestorePoints.Remove(restorePoint);
                }
            }
        }
    }
}