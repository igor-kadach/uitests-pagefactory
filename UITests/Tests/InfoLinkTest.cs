using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
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

        [Test]
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
