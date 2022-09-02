using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class InfoLinkTest
    {
        [SetUp]
        public void Setup()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            _webDriver.Navigate().GoToUrl(TestData.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            var _webDriver = WebDriverSingleton.GetInstance();
            _webDriver.Close();
            _webDriver.Quit();
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

            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.scrollTo(0, 50000)");

            var goToQuestions = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToQuestions);
            goToQuestions._askQuestion.Click();
            goToQuestions._mostPopularQuestions.Click();

            var checkInfoLink = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, checkInfoLink);
            checkInfoLink.IsLinkEnable();

            var actualResult = checkInfoLink.IsLinkEnable();

            Assert.IsTrue(actualResult);
        }
    }
}
