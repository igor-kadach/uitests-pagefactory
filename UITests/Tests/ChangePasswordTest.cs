using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
    [TestFixture]
    [AllureNUnit]
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

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byPhoneAfterChangePass)).Click();
            login._phoneFieldAfterChagePass.SendKeys(TestData.phoneNumber);
            login._newPassAfterChangePass.SendKeys(TestData.newPasswordForTest);
            login._logInButton.Click();

            var goToMyProfile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToMyProfile);
            Thread.Sleep(2000);
            goToMyProfile._profile.Click();

            var openSetting = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSetting);
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();

            var changePass = new SettingsPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, changePass);
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestData.newPasswordForTest);
            changePass._newPasswordField.SendKeys(TestData.password);
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();

            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }
        
        [Test(Author = "Igor_Kadach")]
        [Category("SampleTag")]
        [Description("PasswordChanging")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChangePassword()
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

            var openSetting = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSetting);
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();

            var changePass = new SettingsPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, changePass);
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestData.password);
            changePass._newPasswordField.SendKeys(TestData.newPasswordForTest);
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();

            var loginWithOldPass = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, loginWithOldPass);
            loginWithOldPass._byEmail.Click();
            loginWithOldPass._loginInputField.SendKeys(TestData.emailAdress);
            loginWithOldPass._newPasswordFieldForTest.SendKeys(TestData.password);
            loginWithOldPass._buttonForSubmitNewPassword.Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var errorMessage = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, errorMessage);
            errorMessage.IsErrorMessageDisplayed();

            var actualResult = errorMessage.IsErrorMessageDisplayed();

            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changed!");
        }
    }
}
