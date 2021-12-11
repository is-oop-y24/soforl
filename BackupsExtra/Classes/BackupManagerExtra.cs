using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using Backups;
using Backups.Classes;
using BackupsExtra.CleaningAlgorithms;
using BackupsExtra.Logging;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace BackupsExtra.Classes
{
    public class BackupManagerExtra : BackupManager
    {
        public BackupManagerExtra(IRepository repository)
            : base(repository)
        {
        }

        public void AddExtraJobObject(JobObject jobObject, ILogger logger)
        {
            AddJobObject(jobObject);
            logger.NotifyAddJobObject();
        }

        public void RemoveExtraJobObject(JobObject jobObject, ILogger logger)
        {
            RemoveJobObject(jobObject);
            logger.NotifyDeleteJobObject();
        }

        public void BeginBackupExtra(IAlgorithm algorithm, ILogger logger)
        {
            BeginBackup(algorithm);
            logger.NotifyAddRestorePoint();
        }

        public void Serialize()
        {
            string json = JsonConvert.SerializeObject(BackupJob.RestorePoints, Formatting.Indented, new FileInfoConverter());
            File.AppendAllText("ExtraJJ.json", json);
        }

        public List<RestorePoint> Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            List<RestorePoint> restorePoints = JsonConvert.DeserializeObject<List<RestorePoint>>(json,  new FileInfoConverter());
            return restorePoints;
        }

        public void CleanPoints(ICleaningAlgorithm algorithm, DateTime? dateTime = null, int? count = null)
        {
            algorithm.CleanRestorePoints(BackupJob, dateTime, count);
        }

        public void RecoverOriginalLocation(RestorePoint restorePoint)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    foreach (JobObject newJobObject in BackupJob.JobObjects)
                    {
                        if (!newJobObject.FileInfo.Exists)
                        {
                            newJobObject.FileInfo.Replace(newJobObject.GetFilePath(), jobObject.GetFilePath());
                        }
                        else
                        {
                            jobObject.FileInfo.CopyTo(BackupJob.JobObjects.First().GetFilePath()
                                .Remove(BackupJob.JobObjects.First().GetFilePath().LastIndexOf(@"/"), BackupJob.JobObjects.First().GetFilePath().Substring(BackupJob.JobObjects.First().GetFilePath().LastIndexOf(@"/") + 1).Length));
                        }
                    }
                }
            }
        }

        public void RecoverDifferentLocation(RestorePoint restorePoint, string directory)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    jobObject.FileInfo.CopyTo(directory);
                }
            }
        }

        public RestorePoint GetLatestRestorePoint()
        {
            RestorePoint latestRestorePoint = BackupJob.RestorePoints.First();
            foreach (RestorePoint restorePoint in BackupJob.RestorePoints)
            {
                if (restorePoint.DateBackup >= latestRestorePoint.DateBackup)
                {
                    latestRestorePoint = restorePoint;
                }
            }

            return latestRestorePoint;
        }

        public void MergePointsOnlyOldHas()
        {
            bool checkContainingPoint = false;
            RestorePoint latestRestorePoint = GetLatestRestorePoint();
            foreach (RestorePoint restorePoint in BackupJob.RestorePoints)
            {
                if (restorePoint.Id != latestRestorePoint.Id)
                {
                    foreach (Storage storage in restorePoint.Storages)
                    {
                        foreach (JobObject jobObject in storage.JobObjects)
                        {
                            foreach (Storage latestStorage in latestRestorePoint.Storages)
                            {
                                if (latestStorage.JobObjects.Contains(jobObject))
                                {
                                    checkContainingPoint = true;
                                }
                            }

                            if (!checkContainingPoint)
                            {
                                Storage newStorage = new Storage();
                                newStorage.JobObjects.Add(jobObject);
                                latestRestorePoint.Storages.Add(newStorage);
                            }
                        }
                    }
                }
            }
        }

        public void MergePointsSingleStorage()
        {
            foreach (var restorePoint in BackupJob.RestorePoints)
            {
                if (restorePoint.Storages.Count == 1)
                {
                    BackupJob.RemoveRestorePoint(restorePoint);
                    break;
                }
            }
        }
    }
}