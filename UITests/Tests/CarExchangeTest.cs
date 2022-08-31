using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class CarExchangeTest
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
   //   [Test]
        public void CarExchange()
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

            var offersForExchange = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, offersForExchange);
            offersForExchange._allParametrs.Click();
            offersForExchange._searchByWords.SendKeys(TestDatas.exchange);

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
