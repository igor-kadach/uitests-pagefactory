using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;


namespace UITests.Tests
{
    class ChangePasswordTest
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

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byPhoneAfterChangePass.Click();
            login._phoneFieldAfterChagePass.SendKeys(TestData.phoneNumber);
            login._newPassAfterChangePass.SendKeys(TestData.newPasswordForTest);
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
            changePass._oldPassworField.SendKeys(TestData.newPasswordForTest);
            changePass._newPasswordField.SendKeys(TestData.password);
            changePass._applyButton.Click();
            Thread.Sleep(2000);

            changePass._exitButton.Click();

            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }

        [Test]
        public void ChangePassword()
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

            var openSetting = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSetting);
            Thread.Sleep(2000);
            openSetting._settingsButton.Click();

            var changePass = new SettingsPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, changePass);
            Thread.Sleep(2000);
            changePass._changePassword.Click();
            changePass._oldPassworField.SendKeys(TestData.password);
            changePass._newPasswordField.SendKeys(TestData.newPasswordForTest);
            changePass._applyButton.Click();
            Thread.Sleep(2000);
            changePass._exitButton.Click();

            var loginWithOldPass = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, loginWithOldPass);
            loginWithOldPass._byEmail.Click();
            loginWithOldPass._loginInputField.SendKeys(TestData.emailAdress);
            loginWithOldPass._newPasswordFieldForTest.SendKeys(TestData.password);
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
