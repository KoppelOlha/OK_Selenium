using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement ajaxTestPagebutton => Driver.FindElement(By.LinkText("Ajax test page"));
    
        #region Methods
        public AjaxPage NavigateToAjaxPage(IWebDriver driver)
        {
            ajaxTestPagebutton.Click();
            return new AjaxPage(Driver);
        }
        #endregion
    }
}