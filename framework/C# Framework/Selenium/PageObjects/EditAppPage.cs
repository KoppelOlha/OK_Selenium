using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class EditAppPage : BasePage
    {
        public EditAppPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement EditDescrField => Driver.FindElement(By.XPath("//div[@class='content']//table//tr//td[2]"));
        public IWebElement CategoryDropdown => Driver.FindElement(By.XPath("//div[@class='content']//select[@name='category']"));
        public IWebElement InfoOption => Driver.FindElement(By.XPath("//div[@class='content']//select/option[@value='673d0e4e6dde412d36843c2b']"));
        public IWebElement FunOption => Driver.FindElement(By.XPath("//div[@class='content']//select/option[@value='673d0e4e6dde412d36843c2c']"));
        public IWebElement MapsOption => Driver.FindElement(By.XPath("//div[@class='content']//select/option[@value='673d0e4e6dde412d36843c2d']"));
        public IWebElement GamesOption => Driver.FindElement(By.XPath("//div[@class='content']//select/option[@value='673d0e4e6dde412d36843c2e']"));
        public IWebElement NewsOption => Driver.FindElement(By.XPath("//div[@class='content']//select/option[@value='673d0e4e6dde412d36843c2f']"));
        public IWebElement DevelopmentOption => Driver.FindElement(By.XPath("//div[@class='content']//select//option[@value='673d0e4e6dde412d36843c30']"));
        public IWebElement ImageSelect => Driver.FindElement(By.XPath("//div[@class='content']//input[@name='image']"));
        public IWebElement IconSelect => Driver.FindElement(By.XPath("//div[@class='content']//input[@name='icon']"));
        public IWebElement UpdateButton => Driver.FindElement(By.XPath("//div[@class='content']//input[@value='Update']"));
        public IWebElement FlashMessage => Driver.FindElement(By.XPath("//div[@class='content']//p"));

        #region Methods
        public bool IsAppUpdated()
        {
            SelectElement categorySelect = new SelectElement(CategoryDropdown);
            categorySelect.SelectByText("Maps");
            UpdateButton.Click();
            return FlashMessage.Displayed;
        }
        #endregion
    }
}
