using LoggerTests;
using Xunit.Abstractions;

namespace TestProject1
{
    public class LoginTests
    {
        private readonly ILoginTestLogger _logger;

        // Dependency inversion principle, using an interface instead of a concrete class
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