using CourseClassLibrary.Interfaces;

namespace CourseClassLibrary.Domain.UserAuthentication
{
    public class FrenchLoginMessageService : ILoginMessageService
    {
        public string GetWelcomeMessage(string username)
        {
            return $"Bienvenue, {username}!";
        }
    }
}
