namespace Module33.AuthenticationService.BLL
{
    public interface ILogger
    {
        // void CreateFolder(string baseName);

        void WriteEvent(string eventMessage);

        void WriteError(string errorMessage);
    }
}
