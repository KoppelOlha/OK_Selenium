using System.Configuration;
using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium.Framework
{
    public class SiteNavigator
    {
        //МОЖНО УДАЛИТЬ
        public static void NavigateToLoginPage(IWebDriver driver)
        {
            bool useBasicUrl = bool.Parse(ConfigurationManager.AppSettings["UseBasicUrl"]);
            string url = useBasicUrl
                ? ConfigurationManager.AppSettings["basicUrl"]
                : ConfigurationManager.AppSettings["regularUrl"];            

            driver.Navigate().GoToUrl(url);
        }
    }
}