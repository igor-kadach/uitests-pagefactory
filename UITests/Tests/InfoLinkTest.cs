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
    class InfoLinkTest
    {
        private MainMenuPageObject _goToQuestions;

        private Actions _getQuestions;

        public InfoLinkTest()
        {
            _goToQuestions = new MainMenuPageObject();
            _getQuestions = new Actions();
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
        [Category("SupportLink")]
        [Description("Test5")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void InfoLink()
        {
            // GIVEN: Go to bottom of site to infolinks and choose support.
            _goToQuestions.ClickOnAskQuestionsButton();
            _goToQuestions.ChooseMostPopularQuestions();

            // WHEN: Check if link to support is enable.
            var expectedResult = true;
            var actualResult = _goToQuestions.IsLinkEnable();
            Assert.AreEqual(actualResult, expectedResult, "!can't redirect to support!");
        }
    }
}