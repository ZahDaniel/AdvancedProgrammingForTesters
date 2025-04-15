using UserTest;

namespace TestProject2
{
    public class UserTestHelper
    {
        //SRP
        //OCP

        public User GenerateValidUser()
        {
            return new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Age = 25
            };
        }

        [Fact]
        public void UserValidator_Should_Return_True_For_Valid_User()
        {
            var helper = new UserTestHelper();
            var user = helper.GenerateValidUser();
            var userValidator = new UserValidator();

            Assert.True(userValidator.IsUserValid(user));
        }
    }
}