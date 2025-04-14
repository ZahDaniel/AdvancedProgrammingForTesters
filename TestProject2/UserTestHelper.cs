using UserTest;

namespace TestProject2
{
    public class UserTestHelper
    {
        private readonly UserGenerator _generator = new UserGenerator();
        private readonly UserValidator _validator = new UserValidator();

        public User GenerateAndValidateUser()
        {
            var user = _generator.GenerateValidUser();
            _validator.Validate(user);
            return user;
        }
    }
}