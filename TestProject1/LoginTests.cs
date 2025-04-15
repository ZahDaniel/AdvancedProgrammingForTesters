using LoggerTests;
using Xunit.Abstractions;

namespace TestProject1
{
    public class LoginTests
    {
        private readonly LoginTestLogger _logger;

        public LoginTests(ITestOutputHelper output)
        {
            var testOutputLogger = new TestOutputLogger(output);
            _logger = new LoginTestLogger(testOutputLogger);
        }

        [Fact]
        public void Should_Login_Successfully()
        {
            _logger.LogLoginStart("testUser");

            _logger.LogLoginSuccess();
        }
    }
}