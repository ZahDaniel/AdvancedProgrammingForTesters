using Xunit.Abstractions;

namespace LoggerTests
{
    public class LoginTestLogger
    {
        private readonly ITestOutputHelper _output;

        public LoginTestLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        public void LogLoginStart(string username)
        {
            _output.WriteLine($"Starting login for user: {username}");
        }

        public void LogLoginSuccess()
        {
            _output.WriteLine("Login successful.");
        }
    }
}