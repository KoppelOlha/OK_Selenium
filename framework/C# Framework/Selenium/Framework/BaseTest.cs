using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Selenium.Framework;
using Selenium.Pages;
using System;
using System.IO;

namespace Selenium.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver;
        public ILog Logger;
        public ITakesScreenshot Screenshot;
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
             Logger = LogManager.GetLogger(GetType());
             Logger.Info("log4net initialized");
             //Driver = Settings.GetDriver();
             Driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
             Driver.Manage().Window.Maximize();
             Logger.Info("Test started");
             //user = User.GetDefaultUser();
             //loginPage = SiteNavigator.NavigateToLoginPage(Driver);

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
            listenerTest.TestScreenshot();

            this.Driver.Quit();
         }
    }
}
