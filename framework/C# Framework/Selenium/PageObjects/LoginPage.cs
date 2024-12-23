using System.Configuration;
using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public IWebElement UsernameBox => Driver.FindElement(By.Id("j_username"));
        public IWebElement PasswordBox => Driver.FindElement(By.Id("j_password"));
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@value='Login']"));
        public IWebElement RegisterLink => Driver.FindElement(By.PartialLinkText("Register"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
            bool useBasicUrl = bool.Parse(ConfigurationManager.AppSettings["UseBasicUrl"]);
            string url = useBasicUrl
                ? ConfigurationManager.AppSettings["basicUrl"]
                : ConfigurationManager.AppSettings["regularUrl"];

            driver.Navigate().GoToUrl(url);
        }

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