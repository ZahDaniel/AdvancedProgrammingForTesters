namespace TestLogger
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("testlog.txt", message + "\n");
        }
    }
}
