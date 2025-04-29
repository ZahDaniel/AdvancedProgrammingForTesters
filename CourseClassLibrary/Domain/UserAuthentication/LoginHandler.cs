using CourseClassLibrary.Interfaces;

namespace CourseClassLibrary.Domain.UserAuthentication
{
    public class LoginHandler
    {
        private readonly ILoginMessageService _messageService;

        public LoginHandler(ILoginMessageService messageService)
        {
             _messageService = messageService;
        }

        public string Login(string username)
        {
            return _messageService.GetWelcomeMessage(username);
        }
    }
}