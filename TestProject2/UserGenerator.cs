using TestProject2;

namespace UserTest
{
    public class UserGenerator
    {
        public User GenerateNewUser()
        {
            return new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Age = 25
            };
        }
    }
}
