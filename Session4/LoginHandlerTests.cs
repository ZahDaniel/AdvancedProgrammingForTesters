using CourseClassLibrary.Domain.UserAuthentication;
using Xunit.Abstractions;

namespace Session4
{
    public class LoginHandlerTests
    {
        private readonly ITestOutputHelper _output;

        public LoginHandlerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Login_ReturnsWelcomeMessage_InEnglish()
        {
            var englishService = new EnglishLoginMessageService();
            var loginHandler = new LoginHandler(englishService);

            var welcomeMessage = loginHandler.Login("Andrada");

            _output.WriteLine(welcomeMessage);

            Assert.Equal("Welcome, Andrada!", welcomeMessage);
        }

        [Fact]
        public void Login_ReturnsWelcomeMessage_InFrench()
        {
            var frenchService = new FrenchLoginMessageService();
            var loginHandler = new LoginHandler(frenchService);

            var result = loginHandler.Login("Maria");

            _output.WriteLine(result);
            Assert.Equal("Bienvenue, Maria!", result);
        }
    }
}