namespace CourseClassLibrary.Domain.UserAuthentication
{
    public class EnglishLoginMessageService
    {
        public string GetWelcomeMessage(string username) => $"Welcome, {username}!";
    }
}