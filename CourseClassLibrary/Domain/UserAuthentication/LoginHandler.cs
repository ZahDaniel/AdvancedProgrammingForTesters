namespace CourseClassLibrary.Domain.UserAuthentication
{
    public class LoginHandler
    {
        private readonly EnglishLoginMessageService _messageService = new EnglishLoginMessageService();

        public string Login(string username) => _messageService.GetWelcomeMessage(username);
    }
}