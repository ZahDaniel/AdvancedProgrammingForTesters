using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2;

namespace UserTest
{
    public class UserValidator
    {

        public void Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || !user.Email.Contains("@") || user.Age < 18)
            {
                throw new ArgumentException("Invalid user");
            }
        }

    }
}
