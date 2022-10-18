using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using UITests.PageObjects;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class UploadPhotoTest
    {
        private Actions _common;

        private MainMenuPageObject _goToPerosonalArea;

        private PersonalAreaPageObject _addPhoto;

        public UploadPhotoTest()
        {
            _common = new Actions();
            _goToPerosonalArea = new MainMenuPageObject();
            _addPhoto = new PersonalAreaPageObject();
        }

        [SetUp]
        public void Setup()
        {
            SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("UploadProto")]
        [Description("Test10")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckUploadPhotoTest()
        {
            //GIVEN: Login to website.
            _common.LoginToSite();

            // WHEN: Open my profile to open my sale ads.
            _goToPerosonalArea.ClickOnProfileIcon();

            // THEN: Open my ad.
            _addPhoto.ClickOnChangeButton();
            _addPhoto.WaitTiitlePhoto();

            // THEN: Add new photo.
            _addPhoto.ChoosePhoto();
            _addPhoto.WaitChoosePhotoButton();
            _addPhoto.TurnPhotoOfCar();

            // THEN: Save adding photo.
            _addPhoto.SavePhoto();
            _addPhoto.ClickOnChangeButton();
            _addPhoto.WaitChoosePhotoButton();

            // THEN: Check if photo was added.
            var actualResult = _addPhoto.IsAddedPhotoDisplayed();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}