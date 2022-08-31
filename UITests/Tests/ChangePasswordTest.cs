using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class ChangePasswordTest
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
            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byPhoneAfterChangePass.Click();
            login._phoneFieldAfterChagePass.SendKeys(TestDatas.phoneNumber);
            login._newPassAfterChangePass.SendKeys(TestDatas.newPasswordForTest);
            login._logInButton.Click();

            var goToMyProfile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToMyProfile);
            Thread.Sleep(2000);
            goToMyProfile._profile.Click();

            var openSetting = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSetting);
            Thread.Sleep(2000);
            openSetting._settingsButton.Click();

            var changePass = new SettingsPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, changePass);
            Thread.Sleep(2000);
            changePass._changePassword.Click();
            changePass._oldPassworField.SendKeys(TestDatas.newPasswordForTest);
            changePass._newPasswordField.SendKeys(TestDatas.password);
            changePass._applyButton.Click();
            Thread.Sleep(2000);

            changePass._exitButton.Click();

            _webDriver.Close();
        }

        [Test]
        public void ChangePassword()
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

            var openSetting = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSetting);
            Thread.Sleep(2000);
            openSetting._settingsButton.Click();

            var changePass = new SettingsPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, changePass);
            Thread.Sleep(2000);
            changePass._changePassword.Click();
            changePass._oldPassworField.SendKeys(TestDatas.password);
            changePass._newPasswordField.SendKeys(TestDatas.newPasswordForTest);
            changePass._applyButton.Click();
            Thread.Sleep(2000);
            changePass._exitButton.Click();

            var loginWithOldPass = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, loginWithOldPass);
            loginWithOldPass._byEmail.Click();
            loginWithOldPass._loginInputField.SendKeys(TestDatas.emailAdress);
            loginWithOldPass._newPasswordFieldForTest.SendKeys(TestDatas.password);
            loginWithOldPass._buttonForSubmitNewPassword.Click();
            Thread.Sleep(2000);

            var errorMessage = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, errorMessage);
            errorMessage.IsErrorMessageDisplayed();

            var actualResult = errorMessage.IsErrorMessageDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changeg!");
        }
    }
}
