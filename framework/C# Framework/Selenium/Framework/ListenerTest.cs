using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Selenium.Framework
{
    public class ListenerTest : ITestListener
    {
        IWebDriver driver;

        public ListenerTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TestScreenshot()
        {
            string scrFormat = ".jpg";
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string testName = TestContext.CurrentContext.Test.Name;
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(folderPath);
            string filePath = folderPath + "\\" + testName + timestamp + scrFormat;

            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(filePath);
        }

        void ITestListener.SendMessage(TestMessage message)
        {
            throw new NotImplementedException();
        }
        void ITestListener.TestFinished(ITestResult result)
        {
            throw new NotImplementedException();
        }
        void ITestListener.TestOutput(TestOutput output)
        {
            throw new NotImplementedException();
        }
        void ITestListener.TestStarted(ITest test)
        {
            throw new NotImplementedException();
        }
    }
}
