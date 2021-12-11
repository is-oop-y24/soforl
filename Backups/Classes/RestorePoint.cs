using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class RestorePoint
    {
        public RestorePoint()
        {
            DateBackup = DateTime.Now;
            DirectoryName =
                $"Directory-{DateBackup.Day}-{DateBackup.Month}-{DateBackup.Year}_{DateBackup.Hour}_{DateBackup.Minute}_{DateBackup.Second}";
            Storages = new List<Storage>();
            Id = Guid.NewGuid();
        }

        public List<Storage> Storages { get; }
        public Guid Id { get; }
        public string DirectoryName { get; }
        public DateTime DateBackup { get; }
    }
}