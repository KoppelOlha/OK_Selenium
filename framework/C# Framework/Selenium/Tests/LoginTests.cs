using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Framework;
using Selenium.Framework.Constants;
using Selenium.Framework.TestData;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
        [Test]
        public void ValidLoginTest()
        {
            var drive = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
            var testUser = User.GetDefaultUser();
            loginPage = SiteNavigator.NavigateToLoginPage(drive);
            homePage = loginPage.Login(testUser);
            bool checkHeaderContain = homePage.OnHeader()
                .GetWelcomeText
                .Contains(testUser.FirstName);


            //homePage = loginPage.Login(user);
            //Logger.Info("Assert user login");
            //bool checkHeaderContain = homePage
            //    .OnHeader()
            //    .GetWelcomeText
            //    .Contains(user.FirstName);
            Assert.True(checkHeaderContain);
            Logger.Info("Checking user logged in");
        }

        [Test]
        public void InvalidLoginTest()
        {
            var drive = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
            var invalidUser = User.GetDefaultUser();
            invalidUser.Password = "invalid";
            loginPage = SiteNavigator.NavigateToLoginPage(drive);
            loginPage.Login(invalidUser);

            //user.Password = "invalid";
            //loginPage.Login(user);
            Logger.Info("Getting flash message");
            Assert.True(loginPage.GetFlashMessage().Contains("invalid username or password"));
        }
    }
}
    

        
    

