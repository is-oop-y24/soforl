namespace Backups.Classes
{
    public abstract class JobObject
    {
        private string _filePath;
        public JobObject(string path)
        {
            _filePath = path;
        }

        public string GetFilePath()
        {
            return _filePath;
        }

        public void ChangePath(string path)
        {
            _filePath = path;
        }
    }
}