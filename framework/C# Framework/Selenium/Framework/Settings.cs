using System;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;


namespace Selenium.Framework
{
    public class Settings
    {
        public static string GetRegularUrl()
        {
            return ConfigurationManager.AppSettings["regularUrl"];
        }
        public static string GetBasicUrl()
        {
            return ConfigurationManager.AppSettings["basicUrl"];
        }
        public static IWebDriver GetDriver()
        {
            string driversPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers");
            switch (GetBrowserType())
            {
                case "chrome":
                    return new ChromeDriver(driversPath);
                case "firefox":
                    return new FirefoxDriver(driversPath);
                default:
                    throw new Exception("Unknown browser type!");
            }
        }
        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}