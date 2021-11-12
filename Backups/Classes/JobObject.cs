using System.IO;

namespace Backups.Classes
{
    public class JobObject
    {
        private FileInfo fileInfo;
        public JobObject(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }

        public string GetFilePath()
        {
            return $"{fileInfo.DirectoryName}/{fileInfo.Name}";
        }
    }
}