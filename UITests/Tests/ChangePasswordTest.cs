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

        private Actions _common;

        private MainMenuPageObject _goToMyProfile;

        private PersonalAreaPageObject _openSetting;

        private SettingsPageObject _changePass;

        private AuthorizationPageObject _authActions;

        public ChangePasswordTest()
        {
            _common = new Actions(_settings);
            _goToMyProfile = new MainMenuPageObject();
            _openSetting = new PersonalAreaPageObject();
            _changePass = new SettingsPageObject();
            _authActions = new AuthorizationPageObject();
        }

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            // Change password back to old.
            _common.ChangePasswordBack();
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SampleTag")]
        [Description("PasswordChanging")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChangePassword()
        {
            // GIVEN: User login to website.
            _common.LoginToSite();

            // WHEN: User open my profile to open settings.
            _goToMyProfile.ClickOnProfileIcon();

            // THEN: User open settings to change password.
            _openSetting.ClickOnSettings();

            // THEN: User change old password to new.
            _changePass.ClickOnChangePasswordButton();
            _changePass.WaitTitleOfNewPasswordPage();
            _changePass.EnterActualPassword();
            _changePass.EnterNewPassword();

            // AND: Save changes.
            _changePass.ApplyChanges();
            _changePass.ClickOnExitButton();
            _changePass.ClickOnAVLogo();

            // THEN: Try to login with old password.
            _common.LoginToSite();

            // AND: Error message statement check. 
            var actualResult = _authActions.IsErrorMessageDisplayed();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "!password wasn't changed!");
        }
    }
}