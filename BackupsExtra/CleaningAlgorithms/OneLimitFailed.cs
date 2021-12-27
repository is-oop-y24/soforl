using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Classes;

namespace BackupsExtra.CleaningAlgorithms
{
    public class OneLimitFailed : ICleaningAlgorithm
    {
        public void CleanRestorePoints(BackupJob backupJob, DateTime? dateTime, int? count)
        {
            List<RestorePoint> restorePoints = new List<RestorePoint>();
            foreach (RestorePoint restorePoint in backupJob.RestorePoints)
            {
                if (restorePoint.DateBackup <= dateTime)
                {
                    backupJob.RemoveRestorePoint(restorePoint);
                }
            }

            RestorePoint newRestorePoint;
            int? numberDeletePoints = backupJob.RestorePoints.Count - count;
            while (numberDeletePoints > 0)
            {
                for (int i = 0; i < numberDeletePoints; i++)
                {
                    DateTime date = backupJob.RestorePoints.First().DateBackup;
                    newRestorePoint = backupJob.RestorePoints.First();
                    foreach (RestorePoint restorePoint in backupJob.RestorePoints)
                    {
                        if (restorePoint.DateBackup <= date)
                        {
                            newRestorePoint = restorePoint;
                            date = restorePoint.DateBackup;
                        }
                    }

                    backupJob.RemoveRestorePoint(newRestorePoint);
                    numberDeletePoints -= 1;
                }
            }
        }
    }
}