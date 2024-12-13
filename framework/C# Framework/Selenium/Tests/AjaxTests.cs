using NUnit.Framework;
using OpenQA.Selenium.DevTools.V128.Accessibility;
using Selenium.Framework;
using Selenium.Framework.Models;
using Selenium.Framework.TestData;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests
{
    public class AjaxTests : BaseTest
    {
        private static IEnumerable<User> usersTestData = UsersTestData.TestDataUsers();

        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                listenerTest.TestScreenshot();
            }
        }

        [Test]
        public void SumValidNumbersAjax()
        {
            string x = "7.5";
            string y = "2.3";
            loginPage.Login(user);
            homePage.NavigateToAjaxPage(Driver);
            float a = ajaxPage.ParseToFloat(x);
            float b = ajaxPage.ParseToFloat(y);
            float ajax = ajaxPage.GetSum(x, y);
            Assert.AreEqual((a + b), ajax);
        }
        [Test]
        public void SumInvalidNumbersAjax()
        {
            string x = "7.5";
            string y = "invalid";
            loginPage.Login(user);
            homePage.NavigateToAjaxPage(Driver);
            float a = ajaxPage.ParseToFloat(x);
            string textMessage = ajaxPage.MessageDisplayed(x, y);
            Assert.True(ajaxPage.IsValidationDisplayed());
        }
    }
}
