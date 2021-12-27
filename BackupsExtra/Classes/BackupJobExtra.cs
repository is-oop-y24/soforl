using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Classes;
using BackupsExtra.Logging;

namespace BackupsExtra.Classes
{
    public class BackupJobExtra : BackupJob
    {
        public void DeleteRestorePoint(RestorePoint restorePoint, ILogger logger)
        {
            RemoveRestorePoint(restorePoint);
            logger.NotifyChanges("Restore point deleted");
        }

        public void AddRestorePoint(RestorePoint restorePoint, ILogger logger)
        {
            RestorePoints.Add(restorePoint);
            logger.NotifyChanges("Restore point added");
        }
    }
}