using TestProject2;

namespace UserTest
{
    public class UserValidator
    {
        public bool IsUserValid(User user)
        {
            return !string.IsNullOrEmpty(user.Username)
                 && user.Email.Contains("@")
                 && user.Age >= 18;
        }
    }
}