using Microsoft.Build.BuildEngine;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.VirtualAuth;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement UsernameBox => Driver.FindElement(By.Id("j_username"));
        public IWebElement PasswordBox => Driver.FindElement(By.Id("j_password"));
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@value='Login']"));
        public IWebElement RegisterLink => Driver.FindElement(By.PartialLinkText("Register"));

        #region Methods
        public HomePage Login(User user)
        {
            UsernameBox.SendKeys(user.Login);
            PasswordBox.SendKeys(user.Password);
            LoginButton.Click();
            return new HomePage(Driver);
        }
        public RegisterPage NavigateToRegisterPage(IWebDriver driver)
        {
            RegisterLink.Click();
            return new RegisterPage(Driver);
        }
       #endregion
    }
}