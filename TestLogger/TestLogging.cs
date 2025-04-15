namespace TestLogger
{
    public class TestLogging
    {
        private readonly ILogger _logger;
        public TestLogging(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }

    }
}
