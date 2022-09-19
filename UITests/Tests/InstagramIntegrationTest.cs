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
    class InstagramIntegrationTest
    {

        private Settings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            WebDriverSingleton.SetNull();
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
            var linkIsAvailable = new MainMenuPageObject();
            linkIsAvailable._goToInstagram.Click();

            // WHEN: Check redirect to instagram.
            var getInstagramLink = new CommonPageObject(_settings);
            var actualResult = getInstagramLink.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!can't redirect to instagram!");
        }
    }
}