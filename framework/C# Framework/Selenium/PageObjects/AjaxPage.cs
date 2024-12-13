using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;
using static System.Net.Mime.MediaTypeNames;

namespace Selenium.Pages
{
    public class AjaxPage : BasePage
    {
        public AjaxPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement xField => Driver.FindElement(By.XPath("//input[@id='x']"));
        public IWebElement yField => Driver.FindElement(By.Id("y"));
        public IWebElement SumButton => Driver.FindElement(By.Id("calc"));
        public IWebElement GoBackButton => Driver.FindElement(By.XPath("//a"));
        public IWebElement ResultField => Driver.FindElement(By.Id("result"));
        public string resultString => ResultField.Text;
        public float resultFloat => float.Parse(resultString.Remove(0, 11));

        public string validationText = "Result is: Incorrect data";
        public List<IWebElement> GetFields()
        {
            List<IWebElement> a = Driver.FindElements(By.XPath("//input[@type='text']")).ToList();
            return a;
        }

        #region Methods
        public void FillFields()
        {
            List<IWebElement> a = Driver.FindElements(By.XPath("//input[@type='text']")).ToList();
            var rendomNum = new Random().Next(0, 30);
            a.ForEach(el => el.SendKeys(new Random().Next(0, 30).ToString()));
        }
        public void ClickSum()
        {
            SumButton.Click();
        }
        public HomePage GoBackHomePage()
        {
            GoBackButton.Click();
            return new HomePage(Driver);
        }
        public float GetSum(string x, string y)
        {
            xField.SendKeys(x);
            yField.SendKeys(y);
            ClickSum();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(Driver =>
            {
                return ResultField.Displayed;
            });
            return resultFloat;
        }
        public string MessageDisplayed(string x, string y)
        {
            xField.SendKeys(x);
            yField.SendKeys(y);
            ClickSum();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(Driver =>
            {
                return ResultField.Displayed;
            });
           return resultString;
        }
        public bool IsValidationDisplayed()
        {
            return resultString.Contains(validationText);
        }
        public float ParseToFloat(string a)
        {
            float b = float.Parse(a);
            return b;
        }
        #endregion
    }
}


