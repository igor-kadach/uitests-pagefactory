using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using UITests.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class LoginTest
    {
        private Settings _settings;

        private Actions _common;

        private MainMenuPageObject _getProfileIcon;

        public LoginTest()
        {
            _common = new Actions(_settings);
            _getProfileIcon = new MainMenuPageObject();
        }

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            BaseTest.DriverClose();
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
            _common.LoginToSite();

            // WHEN: Check if my profile icon is dispayed.
            var actualResult = _getProfileIcon.GetProfileMenu();
            var expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "!wrong credential!");
        }
    }
}