using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        private List<JobObject> _jobObjects;

        public Storage()
        {
            _jobObjects = new List<JobObject>();
        }

        /*public List<JobObject> ChangePath(List<JobObject> jobObjects)
        {
            foreach (JobObject item in jobObjects)
            {
                item.ChangePath(this.GetPath());
            }

            return jobObjects;
        }*/

        public List<JobObject> GetJobObjects()
        {
            return _jobObjects;
        }
    }
}