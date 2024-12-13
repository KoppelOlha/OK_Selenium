using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Runtime.Remoting.Messaging;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;

namespace Selenium.Pages
{
    public class JSPage : BasePage
    {
        public JSPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement topField => Driver.FindElement(By.Id("top"));
        public IWebElement leftField => Driver.FindElement(By.Id("left"));
        public IWebElement processButton => Driver.FindElement(By.Id("process"));
        public IWebElement flashMessage => Driver.FindElement(By.XPath("//div"));

        #region Methods
        public bool IsAllertTextAsExpected(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(Driver =>
            {
                return flashMessage.Displayed;
            });
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            var result = jsExecutor.ExecuteScript("return $(arguments[0]).position();", flashMessage);
            var position = (Dictionary<string, object>)result;
            var top = position["top"];
            var left = position["left"];
            string topCoordinate = (Convert.ToInt32(top)).ToString();
            string leftCoordinate = (Convert.ToInt32(left)).ToString();
            topField.SendKeys(topCoordinate);
            leftField.SendKeys(leftCoordinate);
            processButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            return alertText.Equals("Whoo Hoooo! Correct!");
        }
        #endregion
    }
}
