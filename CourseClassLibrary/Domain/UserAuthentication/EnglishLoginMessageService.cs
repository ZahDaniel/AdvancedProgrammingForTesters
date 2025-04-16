using CourseClassLibrary.Interfaces;

namespace CourseClassLibrary.Domain.UserAuthentication
{
    public class EnglishLoginMessageService : ILoginMessageService
    {
        public string GetWelcomeMessage(string username) => $"Welcome, {username}!";
    }
}