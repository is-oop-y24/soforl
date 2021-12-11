namespace BackupsExtra.Logging
{
    public interface ILogger
    {
        void NotifyAddJobObject();
        void NotifyAddRestorePoint();
        void NotifyDeleteRestorePoint();
        void NotifyDeleteJobObject();
    }
}