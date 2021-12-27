namespace BackupsExtra.Logging
{
    public interface ILogger
    {
        void NotifyChanges(string message);
    }
}