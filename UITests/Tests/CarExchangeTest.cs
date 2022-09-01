using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class CarExchangeTest
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
        public void CarExchange()
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

            var offersForExchange = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, offersForExchange);
            offersForExchange._allParametrs.Click();
            offersForExchange._searchByWords.SendKeys(TestData.exchange);

            Thread.Sleep(1500);
            offersForExchange._buttonShow.Click();

            var myOfferForExchange = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, myOfferForExchange);
            Thread.Sleep(1500);
            myOfferForExchange._openForExchange.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.scrollTo(0, 5000)");

            Thread.Sleep(1500);
            myOfferForExchange._openOffer.Click();

            var isMyOfferDisplayed = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isMyOfferDisplayed);
            Thread.Sleep(1500);
            isMyOfferDisplayed.isMyOfferDisplayed();

            var actualResult = isMyOfferDisplayed.isMyOfferDisplayed();

            Assert.IsTrue(actualResult);
        }
    }
}


