using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        private Guid _id;
        private string _directoryName;
        private DateTime _dateBackup;

        public RestorePoint()
        {
            _dateBackup = DateTime.Now;
            _directoryName =
                $"Directory-{_dateBackup.Day}-{_dateBackup.Month}-{_dateBackup.Year}_{_dateBackup.Hour}_{_dateBackup.Minute}_{_dateBackup.Second}";
            _storages = new List<Storage>();
            _id = Guid.NewGuid();
        }

        public List<Storage> GetStorages()
        {
            return _storages;
        }

        public Guid GetRestorePointId()
        {
            return _id;
        }

        public string GetDirectoryName()
        {
            return _directoryName;
        }

        public DateTime GetDate()
        {
            return _dateBackup;
        }
    }
}