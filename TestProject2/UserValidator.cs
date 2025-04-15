using TestProject2;

namespace UserTest
{
    public class UserValidator
    {
        public void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || !user.Email.Contains("@") || user.Age < 18)
            {
                throw new ArgumentException("Invalid test user generated");
            }
        }
    }
}
