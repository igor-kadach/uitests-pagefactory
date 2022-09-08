using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using UITests.PageObjects;
using UITests.TestData;


namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class ChangePasswordTest
    {
        [SetUp]
        public void Setup()
        {
            WebDriverSingleton.GetInstance();
        }

        [TearDown]
        public void EndTest()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            // Close authWindow to sighIn again.
            var closeAuthWindow = new AuthorizationPageObject(_webDriver);
            closeAuthWindow._closeAuthWondow.Click();
            // Press button SighIn.
            var signInButtonClick = new MainMenuPageObject(_webDriver);
            signInButtonClick._sighInButton.Click();
            // Choose method by email and enter new credentials.
            var login = new AuthorizationPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.newPasswordForTest);
            login._logInButton.Click();
            // Go to my profile to open settings.
            var goToMyProfile = new MainMenuPageObject(_webDriver);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();
            // Open settings to change password.
            var openSetting = new PersonalAreaPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();
            // Change password fron new to old password back.
            var changePass = new SettingsPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestDatas.newPasswordForTest);
            changePass._newPasswordField.SendKeys(TestDatas.password);
            // Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();

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

            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: User open my profile to open settings.
            var goToMyProfile = new MainMenuPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();

            // THEN: User open settings to change password.
            var openSetting = new PersonalAreaPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();

            // THEN: User change old password to new.
            var changePass = new SettingsPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestDatas.password);
            changePass._newPasswordField.SendKeys(TestDatas.newPasswordForTest);

            // AND: Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._logoButton)).Click();

            // THEN: Try to login with old password.
            login.LoginToSite();

            // AND: Error message statement check. 
            var loginWithOldPass = new AuthorizationPageObject(_webDriver);

            var actualResult = loginWithOldPass.IsErrorMessageDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changed!");
        }
    }
}
