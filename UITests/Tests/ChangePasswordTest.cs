using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using UITests.PageObjects;
using UITests.Utils;

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
            // Change password back to old.
            var changePassword = new AuthorizationPageObject();
            changePassword.ChangePasswordBack();

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
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: User open my profile to open settings.
            var goToMyProfile = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();

            // THEN: User open settings to change password.
            var openSetting = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();

            // THEN: User change old password to new.
            var changePass = new SettingsPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestDatas.password);
            changePass._newPasswordField.SendKeys(TestDatas.newPasswordForTest);

            // AND: Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._logoButton)).Click();

            // THEN: Try to login with old password.
            login.LoginToSite();

            // AND: Error message statement check. 
            var loginWithOldPass = new AuthorizationPageObject();
            var actualResult = loginWithOldPass.IsErrorMessageDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changed!");
        }
    }
}
