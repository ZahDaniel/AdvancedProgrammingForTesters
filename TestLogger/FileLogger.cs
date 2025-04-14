namespace TestLogger
{
    public class FileLogger : ILoggingMethod
    {
        public void Log(string message)
        {
            File.AppendAllText("testlog.txt", message + "\n");
        }
    }
}
