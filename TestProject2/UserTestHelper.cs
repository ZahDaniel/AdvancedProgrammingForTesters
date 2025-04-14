namespace TestProject2
{
    public class UserTestHelper
    {
        public User GenerateValidUser()
        {
            var user = new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Age = 25
            };

            if (string.IsNullOrEmpty(user.Username) || !user.Email.Contains("@") || user.Age < 18)
            {
                throw new ArgumentException("Invalid test user generated");
            }

            return user;
        }
    }
}