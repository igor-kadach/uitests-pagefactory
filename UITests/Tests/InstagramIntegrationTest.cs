using NUnit.Framework;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class InstagramIntegrationTest
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

  //      [Test]
        public void InstagramIntegration()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var linkIsAvailable = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, linkIsAvailable);
            linkIsAvailable._goToInstagram.Click();

            var actualResult = linkIsAvailable.GetInstagramUrl();
            var expectedResult = "https://www.instagram.com/insta_avby/";

            Assert.AreEqual(expectedResult, actualResult, "!wrong url!");
        }
    }
}
