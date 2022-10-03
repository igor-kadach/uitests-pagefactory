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
            goToPerosonalArea.ClickOnProfileIcon();

            // THEN: Open my ad.
            var addPhoto = new PersonalAreaPageObject();
            addPhoto.ClickOnChangeButton();

            // THEN: Add new photo.
            addPhoto.WaitTitlePhoto();
            addPhoto.ChoosePhoto();
            addPhoto.TurnPhotoOfCar();

            // THEN: Save adding photo.
            addPhoto.SavePhoto();
            addPhoto.ClickOnChangeButton();
            addPhoto.WaitTitlePhoto();

            // THEN: Check if photo was added.
            var actualResult = common.IsAddedPhotoDisplayed();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}