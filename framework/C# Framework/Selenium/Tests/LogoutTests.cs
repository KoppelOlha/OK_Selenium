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
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.Tests
{
    //[TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class LogoutTests : BaseTest
    {
        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                listenerTest.TestScreenshot();
            }
        }
        [Test]
        public void LogoutTest()
        {
            loginPage.Login(user);
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            IList<string> windowHandles = new List<string>(Driver.WindowHandles);
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
            var path = ConfigurationManager.AppSettings["regularUrl"];
            Driver.Navigate().GoToUrl(path);
            pageHeader.Logout();
            Logger.Info("User logged out");
            Driver.SwitchTo().Window(windowHandles[0]);
            Logger.Info("User returned to the previous page");
            pageHeader.ClickAll();
            Logger.Info("Checking login form is displayed");
            Assert.True(loginPage.PasswordBox.Displayed);
        }
    }
}
