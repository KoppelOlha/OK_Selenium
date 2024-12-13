using NUnit.Framework;
using Selenium.Framework.Constants;
using Selenium.Framework;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests
{
    public class RegistrationTests : BaseTest
    {
        [Test]
        public void RegisterNewUser()
        {
            loginPage.NavigateToRegisterPage(Driver);
            registerPage.RegisterAsUser(user);
            Logger.Info("Checking user registered");
            bool checkHeaderContain = homePage
                .OnHeader().GetWelcomeText
                .Contains(user.FirstName);
            Assert.True(checkHeaderContain);
        }

        [Test]
        public void RegisteredUserCanLogin()
        {
            loginPage.NavigateToRegisterPage(Driver);
            registerPage.RegisterAsUser(user);
            Logger.Info("User registered");
            loginPage = homePage.LogoutFromAccount();
            Logger.Info("User logged out");
            loginPage.Login(user);
            Logger.Info("User logged in");
            bool checkHeaderContain = homePage
                .OnHeader()
                .GetWelcomeText
                .Contains(user.FirstName);
            Assert.True(checkHeaderContain);
        }

        [Test]
        public void RegisteredDeveloperCanSeeUploadAppsPage()
        {
            loginPage.NavigateToRegisterPage(Driver);
            registerPage.RegisterAsDeveloper(user);
            Logger.Info("User registered as developer");
            bool checkNavigationContain = homePage
                .OnHeader()
                .GetNavigationText
                .Contains("My applications");
            Assert.True(checkNavigationContain);
        }

        [Test]
        public void RegularUserCannotUploadApps()
        {
            user = User.RegularUser();
            loginPage.NavigateToRegisterPage(Driver);
            registerPage.RegisterAsUser(user);
            Logger.Info("User registered as user");
            bool checkMyAppsContainer = pageHeader.CheckMyAppsContainer("Application Information 0");
            bool checkNavigationContain = pageHeader.CheckNavigationContainer("My applications");
            Logger.Info("Checking user cannot download apps");

            Assert.Multiple(() =>
            {
                Assert.True(checkMyAppsContainer);
                Assert.False(checkNavigationContain);
            });
        }

        [Test]
        public void ReadUsersFromFileImprovedVersion()
        {
            UserManager userManager = new UserManager(TestDataConstants.UsersTestData);
            Logger.Info("Checking users registered from file");

            foreach (var testUser in userManager.users)
            {
                loginPage.NavigateToRegisterPage(Driver);
                testHelper.RegisterUser(testUser, homePage, registerPage);
                pageHeader.Logout();
            }
        }
    }
}

