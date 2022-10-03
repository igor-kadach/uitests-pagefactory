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
    class InfoLinkTest
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
            WebDriverSingleton.DriverQuit();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SupportLink")]
        [Description("Test5")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void InfoLink()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: Go to bottom of site to infolinks and choose support.
            var goToQuestions = new MainMenuPageObject();
            goToQuestions.ClickOnAskQuestionsButton();
            goToQuestions.ChooseMostPopularQuestions();

            // WHEN: Check if link to support is enable.
            var getQuestions = new Actions(_settings);
            var actualResult = getQuestions.IsLinkEnable();
            Assert.IsTrue(actualResult, "!can't redirect to support!");
        }
    }
}