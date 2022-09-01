using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
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

     //   [Test]
        public void PaymentIntegration()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();         

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();                    
                        
            login._loginInputField.SendKeys(TestData.emailAdress);
            login._passwordInputField.SendKeys(TestData.password);
            login._logInButton.Click();

            var goToMyProfile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToMyProfile);
          
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();         

            var buyPoints = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, buyPoints);
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._points)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._pointsFor10Rubles)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._payByCard)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._goToPayService)).Click();                       

            var paymentByCard = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, paymentByCard);
            paymentByCard.isLogoDisplayed();

            var actualResult = paymentByCard.isLogoDisplayed();

            Assert.IsTrue(actualResult);
        }
    }
}
