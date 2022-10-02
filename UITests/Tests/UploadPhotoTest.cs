using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.IO;
using UITests.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class UploadPhotoTest
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
            WebDriverSingleton.DriverQuit();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("UploadProto")]
        [Description("Test10")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckUploadPhotoTest()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            //GIVEN: Login to website.
            var common = new Actions(_settings);
            common.LoginToSite();

            // WHEN: Open my profile to open my sale ads.
            var goToPerosonalArea = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToPerosonalArea._profile)).Click();

            // THEN: Open my ad.
            var addPhoto = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();

            // THEN: Add new photo.
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\FilesForTests"}\\{_settings.FileName}";
            wait.Until(ExpectedConditions.TextToBePresentInElement(addPhoto._titlePhoto, "Фотографии"));
            addPhoto._buttonChoosePhoto.SendKeys(pathForPhoto);
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._turnPhoto));

            // THEN: Save adding photo.
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonSaveChanges)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();
            wait.Until(ExpectedConditions.TextToBePresentInElement(addPhoto._titlePhoto, "Фотографии"));

            // THEN: Check if photo was added.
            var actualResult = common.IsAddedPhotoDisplayed();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}