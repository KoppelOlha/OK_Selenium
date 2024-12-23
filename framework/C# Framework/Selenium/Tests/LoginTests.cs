using NUnit.Framework;

namespace Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
        [Test]
        public void ValidLoginTest()
        {
            var testUser = User.GetDefaultUser();

            homePage = loginPage.Login(testUser);
            bool checkHeaderContain = homePage.OnHeader()
                .GetWelcomeText
                .Contains(testUser.FirstName);

            Logger.Info("Checking user logged in");
            Assert.True(checkHeaderContain);
        }

        [Test]
        public void InvalidLoginTest()
        {
            var invalidUser = User.GetDefaultUser();
            invalidUser.Password = "invalid";

            loginPage.Login(invalidUser);

            Logger.Info("Getting flash message");
            Assert.True(loginPage.GetFlashMessage().Contains("invalid username or password"));
        }
    }
}
    

        
    

