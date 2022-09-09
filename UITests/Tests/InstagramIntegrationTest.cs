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
        [Category("Instagram")]
        [Description("Test6")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void InstagramIntegration()
        {
            // WHEN: Click to instagram link.
            var linkIsAvailable = new MainMenuPageObject();
            linkIsAvailable._goToInstagram.Click();

            // THEN: Check redirect to instagram.
            var actualResult = linkIsAvailable.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!can't redirect to instagram!");
        }
    }
}
