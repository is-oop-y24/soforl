using System.Collections.Generic;

namespace Backups.Classes
{
    public class BackupJob
    {
        public BackupJob()
        {
            JobObjects = new List<JobObject>();
            RestorePoints = new List<RestorePoint>();
        }

        public List<JobObject> JobObjects { get; }
        public List<RestorePoint> RestorePoints { get; }

        public void AddJobObject(JobObject jobObject)
        {
            JobObjects.Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            JobObjects.Remove(jobObject);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            RestorePoints.Remove(restorePoint);
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            RestorePoints.Add(restorePoint);
        }
    }
}