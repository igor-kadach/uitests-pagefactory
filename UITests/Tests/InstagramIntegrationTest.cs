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
    class InstagramIntegrationTest
    {
        private MainMenuPageObject _linkIsAvailable;

        private Actions _getInstagramLink;

        public InstagramIntegrationTest()
        {
            _linkIsAvailable = new MainMenuPageObject();
            _getInstagramLink = new Actions();
        }

        [SetUp]
        public void Setup()
        {
            SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("Instagram")]
        [Description("Test6")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void InstagramIntegration()
        {
            // GIVEN: Click to instagram link.
            _linkIsAvailable.ClickOnInstagramm();

            // WHEN: Check redirect to instagram.
            var actualResult = _getInstagramLink.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";
            Assert.AreEqual(expectedResult, actualResult, "!can't redirect to instagram!");
        }
    }
}