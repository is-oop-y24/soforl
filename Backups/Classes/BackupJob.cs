using System.Collections.Generic;

namespace Backups.Classes
{
    public class BackupJob
    {
        private List<JobObject> _jobObjects;
        private List<RestorePoint> _restorePoints;

        public BackupJob()
        {
            _jobObjects = new List<JobObject>();
            _restorePoints = new List<RestorePoint>();
        }

        public List<JobObject> GetJobObjects()
        {
            return _jobObjects;
        }

        public List<RestorePoint> GetRestorePoints()
        {
            return _restorePoints;
        }

        public void AddJobObject(JobObject jobObject)
        {
            _jobObjects.Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            _jobObjects.Remove(jobObject);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            _restorePoints.Remove(restorePoint);
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            _restorePoints.Add(restorePoint);
        }
    }
}