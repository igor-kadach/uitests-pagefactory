using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using UITests.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class ChangePasswordTest
    {
        private Settings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            // Change password back to old.
            var changePassword = new Actions(_settings);
            changePassword.ChangePasswordBack();

            WebDriverSingleton.DriverQuit();
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
            var common = new Actions(_settings);
            common.LoginToSite();

            // WHEN: User open my profile to open settings.
            var goToMyProfile = new MainMenuPageObject();
            goToMyProfile.ClickOnProfileIcon();

            // THEN: User open settings to change password.
            var openSetting = new PersonalAreaPageObject();
            openSetting.ClickOnSettings();

            // THEN: User change old password to new.
            var changePass = new SettingsPageObject();
            changePass.ClickOnChangePasswordButton();
            changePass.WaitTitleOfNewPasswordPage();
            changePass.EnterOldPassword();
            changePass.EnterNewPassword();

            // AND: Save changes.
            changePass.ApplyChanges();
            changePass.ClickOnExitButton();
            changePass.ClickOnAVLogo();

            // THEN: Try to login with old password.
            common.LoginToSite();

            // AND: Error message statement check. 
            var actualResult = common.IsErrorMessageDisplayed();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changed!");
        }
    }
}