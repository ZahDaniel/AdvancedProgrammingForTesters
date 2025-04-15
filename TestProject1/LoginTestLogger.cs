using Xunit.Abstractions;

namespace LoggerTests
{
    public class LoginTestLogger
    {

        private readonly ILogger _logger;

        public LoginTestLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogLoginStart(string username)
        {
            _logger.Log($"Starting login for user: {username}");
        }

        public void LogLoginSuccess()
        {
            _logger.Log("Login successful.");
        }

    }
}
