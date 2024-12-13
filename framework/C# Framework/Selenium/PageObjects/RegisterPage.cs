using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement NameBox => Driver.FindElement(By.XPath("//input[@name='name']"));
        public IWebElement FirstNameBox => Driver.FindElement(By.XPath("//input[@name='fname']"));
        public IWebElement LastNameBox => Driver.FindElement(By.XPath("//input[@name='lname']"));
        public IWebElement PasswordBox => Driver.FindElement(By.XPath("//input[@name='password']"));
        public IWebElement PasswordConfirmBox => Driver.FindElement(By.XPath("//input[@name='passwordConfirm']"));
        public IWebElement RoleDropdownList => Driver.FindElement(By.XPath("//select[@name='role']"));
        public IWebElement DeveloperRole => Driver.FindElement(By.XPath("//option[@value='DEVELOPER']"));
        public IWebElement UserRole => Driver.FindElement(By.XPath("//option[@value='USER']"));
        public IWebElement RegisterButton => Driver.FindElement(By.XPath("//input[@value='Register']"));

        #region Methods
        public void DeveloperRoleSelection()
        {
            SelectElement dropdownDeveloperRole = new SelectElement(RoleDropdownList);
            dropdownDeveloperRole.SelectByValue("DEVELOPER");
        }
        public void UserRoleSelection()
        {    
            SelectElement dropdownUserRole = new SelectElement(RoleDropdownList);
            dropdownUserRole.SelectByValue("USER");
        }
        public HomePage RegisterAsDeveloper(User user)
        {
            NameBox.SendKeys(user.Login);
            FirstNameBox.SendKeys(user.FirstName);
            LastNameBox.SendKeys(user.LastName);
            PasswordBox.SendKeys(user.Password);
            PasswordConfirmBox.SendKeys(user.Password);
            DeveloperRoleSelection();
            RegisterButton.Click();
            return new HomePage(Driver);
        }
        public HomePage RegisterAsUser(User user)
        {
            NameBox.SendKeys(user.Login);
            FirstNameBox.SendKeys(user.FirstName);
            LastNameBox.SendKeys(user.LastName);
            PasswordBox.SendKeys(user.Password);
            PasswordConfirmBox.SendKeys(user.Password);
            UserRoleSelection();
            RegisterButton.Click();
            return new HomePage(Driver);
        }
        #endregion
    }
}
