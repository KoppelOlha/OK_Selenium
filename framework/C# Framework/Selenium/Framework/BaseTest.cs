using System;
using System.Threading;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.Pages;

namespace Selenium.Tests
{
    public class BaseTest
    {
        private ThreadLocal<IWebDriver> driver;
        public IWebDriver Driver => driver.Value;
        public ILog Logger;
        public HomePage homePage;
        public LoginPage loginPage;
        public AjaxPage ajaxPage;
        public ListenerTest listenerTest;
        public AppPage appPage;
        public AppsList apps;
        public AppJSON appJSON;
        public AddNewAppScreen addNewAppScreen;
        public MyApps myApps;
        public EditAppPage editAppPage;
        public User user;
        public JSPage JSPage;
        public PageHeader pageHeader;
        public TestHelper testHelper;
        public RegisterPage registerPage;

        [SetUp]
        public virtual void Init()
        {
            driver = new ThreadLocal<IWebDriver>(() => new Settings().GetDriver());
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("log4net initialized");
            Driver.Manage().Window.Maximize();
            Logger.Info("Test started");

            loginPage = new LoginPage(Driver);
            apps = new AppsList(Driver);
            appPage = new AppPage(Driver);
            appJSON = new AppJSON(Driver);
            addNewAppScreen = new AddNewAppScreen(Driver);
            myApps = new MyApps(Driver);
            editAppPage = new EditAppPage(Driver);
            listenerTest = new ListenerTest(Driver);
            ajaxPage = new AjaxPage(Driver);
            homePage = new HomePage(Driver);
            JSPage = new JSPage(Driver);
            pageHeader = new PageHeader(Driver);
            testHelper = new TestHelper();
            registerPage = new RegisterPage(Driver);
            Logger.Info("Test init finished");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            try
            {
                listenerTest.TestScreenshot();
            }
            catch (Exception ex)
            {
                Logger.Info($"??????: {ex.Message}");
            }
            finally
            {
                Driver.Quit();
            }
        }
    }
}
