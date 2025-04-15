using TestLogger.Interfaces;

namespace TestLogger
{
    public class FileLogging : ILogging
    {
        public void Log(string message)
        {
            File.AppendAllText("testlog.txt", message + "\n");
        }
    }
}
