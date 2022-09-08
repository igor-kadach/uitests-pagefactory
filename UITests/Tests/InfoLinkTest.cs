using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestData;

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
            var _webDriver = WebDriverSingleton.GetInstance();

                ///Go to bottom of site to infolinks and choose support.
            var goToQuestions = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToQuestions);
            goToQuestions._askQuestion.Click();
            goToQuestions._mostPopularQuestions.Click();

                ///Check if link to support is enable.
            var actualResult = goToQuestions.IsLinkEnable();

            Assert.IsTrue(actualResult, "!can't redirect to support!");
        }
    }
}
