using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;

namespace UITests.Tests
{
    class InfoLinkTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Close();
        }

    //  [Test]
        public void InfoLink()
        {
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
