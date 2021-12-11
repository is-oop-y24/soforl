using System.IO;

namespace Backups.Classes
{
    public class JobObject
    {
        public JobObject(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        public FileInfo FileInfo { get; }

        public string GetFilePath()
        {
            return $"{FileInfo.DirectoryName}/{FileInfo.Name}";
        }
    }
}