using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class LoginTest
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
        public void Login()
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

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var isProfileDisplayed = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isProfileDisplayed);
            isProfileDisplayed.GetProfileMenu();

            var actualResult = isProfileDisplayed.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(actualResult, expectedResult, "!wrong credential!");
        }
    }
}
