using NUnit.Framework;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework
{
    public class TestHelper
    {
        public TestHelper()
        {
        }
        public void RegisterUser(User testUser, HomePage homePage, RegisterPage registerPage)
        {
            bool isNavigationContain;

            switch (testUser.Role)
            {
                case "developer":
                    registerPage.RegisterAsDeveloper(testUser);
                    isNavigationContain = IsHeaderContainsText(homePage, "My applications");
                    Assert.True(isNavigationContain);
                    break;
                case "user":
                    registerPage.RegisterAsUser(testUser);
                    isNavigationContain = IsHeaderContainsText(homePage, "My applications");
                    Assert.False(isNavigationContain);
                    break;
            }
        }
        public bool IsHeaderContainsText(HomePage homePage, string text)
        {
            var navigationMenuSection = homePage.OnHeader().GetNavigationText;
            var isNavigationContain = navigationMenuSection.Contains(text);
            return isNavigationContain;
        }
    }
}
