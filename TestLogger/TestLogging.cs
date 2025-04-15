using TestLogger;

namespace TestLogger
{
    public class TestLogging
    {
        //SRP
        //OCP
        //DIP
        private readonly ILogger _logger;

        public TestLogging(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }

        public void TestLog()
        {
           var consoleLogger = new TestLogging(new ConsoleLogger());
           consoleLogger.Log("This is a console log test");
           
           var fileLogger = new TestLogging(new FileLogger());
           fileLogger.Log("text123");
        }
    }
}
