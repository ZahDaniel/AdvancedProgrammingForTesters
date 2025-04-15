using LoggerTests.Interface;
using Xunit.Abstractions;

namespace TestProject1
{
    public class LoginTests
    {
        //Dependency Injection principle
        //private readonly LoginTestLogger _logger;
        private readonly ILoginTestLogger _logger;

        public LoginTests(ITestOutputHelper output, ILoginTestLogger loginTestLogger)
        {
            _logger = loginTestLogger;
        }

        [Fact]
        public void Should_Login_Successfully()
        {
            _logger.LogLoginStart("testUser");

            _logger.LogLoginSuccess();
        }
    }
}