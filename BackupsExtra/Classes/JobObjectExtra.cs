using System.IO;
using Backups.Classes;

namespace BackupsExtra.Classes
{
    public class JobObjectExtra : JobObject
    {
        public JobObjectExtra(FileInfo fileInfo)
            : base(fileInfo)
        {
            Path = fileInfo.ToString();
        }

        public string Path { get; }
    }
}