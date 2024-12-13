using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class MyApps : BasePage
    {
        public MyApps(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement addNewAppButton => Driver.FindElement(By.XPath("//div[@class='new-app-link']/a[@href='/new']"));

        #region Methods
        public AddNewAppScreen NavigateToAddNewApp(IWebDriver driver)
        {
            addNewAppButton.Click();
            return new AddNewAppScreen(driver);
        }
        #endregion
    }
}
