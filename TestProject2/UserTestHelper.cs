using UserTest;

namespace TestProject2
{
    public class UserTestHelper
    {
        private readonly UserGenerator _userGenerator = new UserGenerator();
        private readonly UserValidator _userValidator = new UserValidator();

        //public User GenerateValidUser()
        //{
        //    var user = new User
        //    {
        //        Username = "testuser",
        //        Email = "test@example.com",
        //        Age = 25
        //    };

        //    if (string.IsNullOrEmpty(user.Username) || !user.Email.Contains("@") || user.Age < 18)
        //    {
        //        throw new ArgumentException("Invalid test user generated");
        //    }

        //    return user;
        //}

        // Single Responsability Principle


        public User GenerateValidUser()
        {
            User user = _userGenerator.GenerateNewUser();
            _userValidator.ValidateUser(user);

            return user;
        }
    }
}