using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class PageHeader : BasePage
    {
        private HomePage homePage;
        private User user;

        public PageHeader(IWebDriver driver) : base(driver)
        {
            homePage = new HomePage(driver);
        }
        public IWebElement WelcomeLabel => Driver.FindElement(By.CssSelector(".welcome"));
        public IWebElement HomeLink => Driver.FindElement(By.LinkText("Home"));
        public IWebElement LogOutLink => Driver.FindElement(By.LinkText("Logout"));
        public IWebElement AllLink => Driver.FindElement(By.LinkText("All"));
        public IWebElement NavigationMenu => Driver.FindElement(By.ClassName("navigation"));
        public IWebElement MyApplicationsLink => Driver.FindElement(By.PartialLinkText("My applications"));
        public IWebElement jsTestPageLink => Driver.FindElement(By.PartialLinkText("JS test page"));

        public string MyAppsText => MyApplicationsLink.Text;
        public string GetWelcomeText => WelcomeLabel.Text;
        public string GetNavigationText => NavigationMenu.Text;

        #region Methods
        public JSPage NavigateToJSPage(IWebDriver driver)
        {
            jsTestPageLink.Click();
            return new JSPage(Driver);
        }

        public LoginPage Logout()
        {
            LogOutLink.Click();
            return new LoginPage(Driver);
        }
        public PageHeader ClickAll()
        {
            AllLink.Click();
            return new PageHeader(Driver);
        }
        public bool CheckMyAppsContainer(string text)
        {
            return homePage
                .OnMyApps()
                .GetMyApplicationsText
                .Contains(text);
        }
        public bool CheckNavigationContainer(string text)
        {
            return homePage
                .OnHeader()
                .GetNavigationText
                .Contains(text);
                //.Contains(MyAppsText);
        }
        public bool CheckHeaderContainer(string text)
        {
            return homePage
                .OnHeader()
                .GetWelcomeText
                .Contains(text);
        }
        #endregion
    }
}