using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;

namespace UITests.Tests
{
    class InstagramIntegrationTest
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
        public void InstagramIntegration()
        {
            var linkIsAvailable = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, linkIsAvailable);
            linkIsAvailable._goToInstagram.Click();

            var actualResult = linkIsAvailable.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!wrong url!");
        }
    }
}
