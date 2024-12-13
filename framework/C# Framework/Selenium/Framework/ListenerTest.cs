using Microsoft.Build.BuildEngine;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string testName = TestContext.CurrentContext.Test.Name;
                String imgpath = "C:\\Users\\okoppel\\Source\\Repos\\okoppel-aut15\\framework\\C# Framework\\Selenium\\Framework\\Screenshots\\" + testName + timestamp + ".jpg";
                ITakesScreenshot scrShot = (ITakesScreenshot)driver;
                Screenshot screenshot = scrShot.GetScreenshot();
                screenshot.SaveAsFile(imgpath); 
            }
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
