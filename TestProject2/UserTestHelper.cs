namespace TestProject2
{
    public class UserTestHelper
    {
        public User GenerateValidUser()
        {
            // Single Responsability Principle, separated methods for generating and validating the user
            User user = GenerateUser();

            ValidateUser(user);

            return user;
        }

        private static User GenerateUser()
        {
            return new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Age = 25
            };
        }

        private static void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || !user.Email.Contains("@") || user.Age < 18)
            {
                throw new ArgumentException("Invalid test user generated");
            }
        }
    }
}