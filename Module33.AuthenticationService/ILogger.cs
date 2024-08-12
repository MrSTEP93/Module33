namespace Module33.AuthenticationService
{
    public interface ILogger
    {
        // void CreateFolder(string baseName);

        void WriteEvent(string eventMessage);

        void WriteError(string errorMessage);
    }
}
