using Selenium.Framework.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.TestData
{
    public class UsersTestData
    {
        private static IEnumerable<User> usersTestData = UsersTestData.TestDataUsers();

        public static List<User> TestDataUsers()
        {
            UserManager userManager = new UserManager(TestDataConstants.UsersTestData);

            return userManager.users;
        }
    }
}
