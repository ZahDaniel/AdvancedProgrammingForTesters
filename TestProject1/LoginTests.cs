using LoggerTests;
using Xunit.Abstractions;

namespace TestProject1
{
    public class LoginTests
    {
        //DIP
        //private readonly LoginTestLogger _logger;
        private readonly ILoginLogger _logger;

        public LoginTests(ITestOutputHelper output)
        {
            _logger = new LoginTestLogger(output);
        }

        [Fact]
        public void Should_Login_Successfully()
        {
            _logger.LogLoginStart("testUser");

            _logger.LogLoginSuccess();
        }
    }
}