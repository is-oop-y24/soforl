using System.IO;

namespace Backups.Classes
{
    public class AbstractJobObject : JobObject
    {
        private string _fileData;
        public AbstractJobObject(string path)
            : base(path)
        {
            _fileData = File.ReadAllText(path);
        }
    }
}