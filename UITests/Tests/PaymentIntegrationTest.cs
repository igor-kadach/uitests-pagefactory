using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class PaymentIntegrationTest
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
        public void PaymentIntegration()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byEmail.Click();
            login._loginInputField.SendKeys(TestData.emailAdress);
            login._passwordInputField.SendKeys(TestData.password);
            login._logInButton.Click();

            var goToMyProfile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToMyProfile);
            Thread.Sleep(2000);
            goToMyProfile._profile.Click();

            var buyPoints = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, buyPoints);
            buyPoints._points.Click();
            Thread.Sleep(2000);
            buyPoints._pointsFor10Rubles.Click();
            Thread.Sleep(2000);
            buyPoints._payByCard.Click();
            Thread.Sleep(1000);
            buyPoints._goToPayService.Click();

            var paymentByCard = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, paymentByCard);
            paymentByCard.isLogoDisplayed();

            var actualResult = paymentByCard.isLogoDisplayed();

            Assert.IsTrue(actualResult);
        }
    }
}
