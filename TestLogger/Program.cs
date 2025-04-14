namespace TestLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger consoleLogger = new ConsoleLogger();
            TestLogging consoleLogging = new TestLogging(consoleLogger);
            consoleLogging.Log("Logging to console");

            ILogger fileLogger = new FileLogger();
            TestLogging fileLogging = new TestLogging(fileLogger);
            fileLogging.Log("Logging to file");
        }
    }
}