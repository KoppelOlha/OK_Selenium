using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;

namespace Selenium.Pages
{
    public class BasePage
    {
        public IWebDriver Driver;

        public HttpClient client;
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            client = new HttpClient();
        }
        public IWebElement FlashMessage => Driver.FindElement(By.CssSelector(".flash"));
        public IWebElement Logout => Driver.FindElement(By.PartialLinkText("Logout"));
        public string GetFlashMessage() => FlashMessage.Text;

        #region Methods
        public PageHeader OnHeader()
        {
            return new PageHeader(Driver);
        }
        public LoginPage LogoutFromAccount()
        {
            Logout.Click();
            return new LoginPage(Driver);
        }
        public AppsList OnMyApps()
        {
            return new AppsList(Driver);
        }
        public async void GetJson()
        {            
            string url = Driver.Url;
            var json = await client.GetStringAsync(url);
        }
        #endregion
    }
}