using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Selenium.Framework.Models;
using Selenium.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.Log.Entry;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace Selenium.Pages
{
    public class AppPage : BasePage
    {
        public AppPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement DownloadAppButton => Driver.FindElement(By.XPath("//div[@class='download-button']//a"));
        public IWebElement DeleteAppButton => Driver.FindElement(By.XPath("//div[@class='edit-app-button']//a"));
        public IWebElement EditAppButton => Driver.FindElement(By.XPath("//div[@class='edit-app-button']//a[last()]"));
        public IWebElement ConfirmMessage => Driver.FindElement(By.XPath("//div[@class='edit-app-button']//a[@onclick='return confirmDelete']"));
        public IWebElement FlashDeleted => Driver.FindElement(By.XPath("//div[@class='content']//p"));
        public IWebElement AppNumDownloads => Driver.FindElement(By.XPath("//div[@class='downloads']"));
        public IWebElement AppImage => Driver.FindElement(By.XPath("//div[@class='application']/img[@alt='Application Information 1']"));
        public IWebElement PopularContainer => Driver.FindElement(By.ClassName("popular-container"));
        public IWebElement PopularApps => Driver.FindElement(By.ClassName("popular-app"));
        public IWebElement LastAddedPopularAppLink => Driver.FindElement(By.XPath("//div[@class='popular-app']//a"));
        public IWebElement LastAddedPopularAppTitle => Driver.FindElement(By.XPath("//div[@class='popular-app']//div"));
        public IWebElement AppName => Driver.FindElement(By.ClassName("name"));
        string GetAppTitleText => Driver.FindElement(By.ClassName("name")).Text;
        string GetAppDescriptionText => Driver.FindElement(By.XPath("//div[@class='description']")).Text.Remove(0,13);
        string GetAppCategoryText => Driver.FindElement(By.XPath("//div[@class='description']/following-sibling::div[@class='description']")).Text.Remove(0,10);
        string GetAppAuthorText => Driver.FindElement(By.XPath("//div[@class='description']/following-sibling::div[@class='description'][2]")).Text.Remove(0,8);
        string GetAppNumDowloads => AppNumDownloads.Text.Remove(0,16);
        string GetAppPopTitleText => LastAddedPopularAppTitle.Text;
        string GetAppName => AppName.Text;
        int NumberOfDownloads => int.Parse(GetAppNumDowloads);

        #region Methods
        public AppModel AppWebModel()
        {
          return new AppModel(
              GetAppTitleText, 
              GetAppDescriptionText, 
              new AppCategory(GetAppCategoryText), 
              new AppAuthor(GetAppAuthorText),
              NumberOfDownloads);
        }
        public AppJSON NavigateToAppJSONPage(IWebDriver driver)
        {
            DownloadAppButton.Click();
            return new AppJSON(driver);
        }
        public bool IsDownloadButtonDisplayed()
        {
            return DownloadAppButton.Displayed;
        }
        public EditAppPage NavigateToEditAppPage(IWebDriver driver)
        {
            EditAppButton.Click();
            return new EditAppPage(Driver);
        }
        public bool IsAppDeleted(IWebDriver driver)
        {
            DeleteAppButton.Click();
            driver.SwitchTo().Alert().Accept();
            return FlashDeleted.Displayed; 
        }
        public bool IsAppPopular(IWebDriver driver)
        {
            for (int i = 0; i < 10; i++)
            {
                DownloadAppButton.Click();
                AppJSON appJSON = new AppJSON(driver);
                appJSON.Driver.Navigate().Back();
            }
            
            driver.Navigate().Refresh();
            return GetAppPopTitleText.Equals(GetAppTitleText);
        }
        public bool IsPopAppPage(IWebDriver driver)
        {
            LastAddedPopularAppLink.Click();
            AppPage appPage = new AppPage(driver);
            return GetAppName.Equals(GetAppTitleText);
        }
        #endregion
    }
}
