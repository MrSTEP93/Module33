using System;
using System.IO;

namespace Module33.AuthenticationService
{
    public class LoggerMy : ILogger
    {
        private readonly string folder;

        public LoggerMy()
        {
            folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(folder);
        }

        private string CombinePath(string eventType)
        {
            return Path.Combine(folder, eventType + ".txt");
        }

        public void WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);
            File.AppendAllText(CombinePath("events"), eventMessage + "\n");
        }

        public void WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            File.AppendAllText(CombinePath("errors"), errorMessage + "\n");
        }
    }
}
