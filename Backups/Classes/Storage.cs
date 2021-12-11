using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        public Storage()
        {
            Id = Guid.NewGuid();
            JobObjects = new List<JobObject>();
        }

        public List<JobObject> JobObjects { get; }
        public Guid Id { get; }
    }
}