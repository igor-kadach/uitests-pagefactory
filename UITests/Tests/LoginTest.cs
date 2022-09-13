using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using UITests.PageObjects;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class LoginTest
    {
        [SetUp]
        public void Setup()
        {
            WebDriverSingleton.GetInstance();
        }

        [TearDown]
        public void EndTest()
        {
            WebDriverSingleton.SetNull();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("LoginToSite")]
        [Description("Test7")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void Login()
        {
            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Check if my profile icon is dispayed.
            var isProfileDisplayed = new MainMenuPageObject();
            var actualResult = isProfileDisplayed.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(actualResult, expectedResult, "!wrong credential!");
        }
    }
}
