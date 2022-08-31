using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class PaymentIntegrationTest
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

        [Test]
        public void PaymentIntegration()
        {
            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byEmail.Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.password);
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
