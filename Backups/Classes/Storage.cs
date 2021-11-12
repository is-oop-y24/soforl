using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        private List<JobObject> _jobObjects;
        private Guid _id;

        public Storage()
        {
            _id = Guid.NewGuid();
            _jobObjects = new List<JobObject>();
        }

        public List<JobObject> GetJobObjects()
        {
            return _jobObjects;
        }

        public Guid GetStorageId()
        {
            return _id;
        }
    }
}