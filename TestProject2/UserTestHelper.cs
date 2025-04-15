using UserTest;

namespace TestProject2
{
    public class UserTestHelper
    {

        private readonly UserValidator validator = new UserValidator();

        public User GenerateValidUser()
        {
            var user = new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Age = 25
            };

            validator.Validate(user);

            return user;
        }

    }
}