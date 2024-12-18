using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium.Framework
{
    public class Settings
    {
        public Settings()
        {
        }

        public IWebDriver GetDriver()
        {
            string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers");

            switch (GetBrowserType())
            {
                case "chrome":
                    return new ChromeDriver(driverPath);
                case "firefox":
                    return new FirefoxDriver(driverPath);
                default:
                    throw new Exception("Unknown browser type!");
            }
        }

        public static string GetRegularUrl()
        {
            return ConfigurationManager.AppSettings["regularUrl"];
        }

        public static string GetBasicUrl()
        {
            return ConfigurationManager.AppSettings["basicUrl"];
        }

        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}