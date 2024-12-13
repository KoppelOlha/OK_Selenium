using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class AppsList : BasePage
    {
        public AppsList(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement AppsContainer => Driver.FindElement(By.ClassName("apps-container"));
        public IWebElement AppInfo_1 => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class='app'][1]"));
        public IWebElement AppInfo1Name => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class='app'][1]/div[@class='name']"));
        public IWebElement AppInfo1Descr => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class='app'][1]/div[@class='description']"));
        public IWebElement AppInfo1NumDownloads => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class='app'][1]/div[@class='downloads']"));
        public IWebElement DetailsLink => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class ='app'][1]/a[@href='/app?title=Application Information 1']"));
        public IWebElement LastAppDetailsLink => Driver.FindElement(By.XPath("//div[@class='apps']//div[@class='app'][last()]//a[@href]"));
        public IWebElement Image => Driver.FindElement(By.XPath("//div[@class='app']/following-sibling::div[@class ='app'][1]/img[@alt='Application Information 1']"));
        public IWebElement MyAppsLink => Driver.FindElement(By.XPath("//div[@class='navigation']/a[@href='/my']"));
        public string GetAppInfo1NameText => AppInfo1Name.Text;
        public string GetAppInfo1DescrText => AppInfo1Descr.Text;
        public string GetAppInfo1NumDownloads => AppInfo1NumDownloads.Text;
        public string GetMyApplicationsText => AppsContainer.Text;

        #region Methods
        public AppPage NavigateToAppPage(IWebDriver driver)
        {
            DetailsLink.Click();
            return new AppPage(Driver);
        }
        public MyApps NavigateToMyAppsPage(IWebDriver driver)
        {
            MyAppsLink.Click();
            return new MyApps(Driver);
        }
        public AppPage NavigateToLastAppPage(IWebDriver driver)
        {
            LastAppDetailsLink.Click();
            return new AppPage(Driver);
        }
        #endregion
    }
}
