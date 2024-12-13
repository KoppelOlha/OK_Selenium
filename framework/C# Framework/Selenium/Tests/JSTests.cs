using NUnit.Framework;
using Selenium.Framework.Models;
using Selenium.Framework;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium.Tests
{
    [TestFixture]
    public class JSTests : BaseTest
    {
        [Test]
        public void CheckFindMeCoordinatesAreCorrect()
        {
            loginPage.Login(user);
            pageHeader.NavigateToJSPage(Driver);
            Logger.Info("User visits JSPage");
            bool areAlertTextsEqual = JSPage.IsAllertTextAsExpected(Driver);
            Logger.Info("User gets alert and checks text");
            Assert.True(areAlertTextsEqual);
        }
    }
}
