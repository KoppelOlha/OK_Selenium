using NUnit.Framework;
using Selenium.Framework.TestData;
using Selenium.Framework;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Framework.Models;

namespace Selenium.Tests
{
    public class ApplicationTests : BaseTest
    {
        public AppModel appModel1;
        public AppModel appModel2;

        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed) 
            {
                listenerTest.TestScreenshot();
            }
        }

        [Test]
        public void CompareDataWithJson()
        {
            loginPage.Login(user);
            apps.NavigateToAppPage(Driver);
            appModel1 = appPage.AppWebModel();
            appPage.NavigateToAppJSONPage(Driver);
            appModel2 = appJSON.AppJSONModel();
            Assert.True(appModel1.IsEqualAsNext(appModel2));
        }

        [Test]
        public void CreateNewApp()
        {
            loginPage.Login(user);
            apps.NavigateToMyAppsPage(Driver);
            myApps.NavigateToAddNewApp(Driver);
            Assert.True(addNewAppScreen.IsAppAdded());
            apps.NavigateToLastAppPage(Driver);
            Assert.True(appPage.IsDownloadButtonDisplayed());
        }

        [Test]
        public void EditApp()
        {
            loginPage.Login(user);
            apps.NavigateToMyAppsPage(Driver);
            myApps.NavigateToAddNewApp(Driver);
            addNewAppScreen.CreateDefaultNewApp(Driver);
            apps.NavigateToLastAppPage(Driver);
            appPage.NavigateToEditAppPage(Driver);
            Assert.True(editAppPage.IsAppUpdated());
        }

        [Test]
        public void DeleteApp()
        {
            loginPage.Login(user);
            apps.NavigateToMyAppsPage(Driver);
            myApps.NavigateToAddNewApp(Driver);
            addNewAppScreen.CreateDefaultNewApp(Driver);
            apps.NavigateToLastAppPage(Driver);
            Assert.True(appPage.IsAppDeleted(Driver));
        }
        [Test]
        public void CreateAppImageIcon()
        {
            loginPage.Login(user);
            apps.NavigateToMyAppsPage(Driver);
            myApps.NavigateToAddNewApp(Driver);
            addNewAppScreen.CreateAppWithImageAndIcon(Driver);
            apps.NavigateToLastAppPage(Driver);
            Assert.True(appPage.IsDownloadButtonDisplayed());
        }
        [Test]
        public void AddAppToPopular()
        {
            loginPage.Login(user);
            apps.NavigateToMyAppsPage(Driver);
            myApps.NavigateToAddNewApp(Driver);
            addNewAppScreen.CreateAppWithImageAndIcon(Driver);
            apps.NavigateToLastAppPage(Driver);
            Assert.True(appPage.IsAppPopular(Driver));
            Assert.True(appPage.IsPopAppPage(Driver));
        }
    }
}
