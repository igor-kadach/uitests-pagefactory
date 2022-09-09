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
        [Category("SupportLink")]
        [Description("Test5")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void InfoLink()
        {
            // WHEN: Go to bottom of site to infolinks and choose support.
            var goToQuestions = new MainMenuPageObject();
            goToQuestions._askQuestion.Click();
            goToQuestions._mostPopularQuestions.Click();

            // THEN: Check if link to support is enable.
            var actualResult = goToQuestions.IsLinkEnable();

            Assert.IsTrue(actualResult, "!can't redirect to support!");
        }
    }
}
