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
    class CheckFavoriteTest
    {
        private Settings _settings;

        private MainMenuPageObject _openCatalogForSearching;

        private MainMenuPageObject _profile;

        private CatalogPageObject _addToBookmarks;

        private PersonalAreaPageObject _openBookmarks;

        private Actions _common;

        public CheckFavoriteTest()
        {
            _openCatalogForSearching = new MainMenuPageObject();
            _profile = new MainMenuPageObject();
            _addToBookmarks = new CatalogPageObject();
            _openBookmarks = new PersonalAreaPageObject();
            _common = new Actions(_settings);
        }

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            // Delete saved bookmarks.   
            _common.DeleteSavedBoormarks();
            _common.TitleNoBookmarks();
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SaveFavoriteCar")]
        [Description("Test3")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckFavorite()
        {
            // GIVEN: User login to website.
            var common = new Actions(_settings);
            common.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.
            _openCatalogForSearching.ClickOnShowCalatogButton();

            // THEN: Enter necessary parametrs for looking.         
            common.EnterParametrsForSearching();
            _openCatalogForSearching.WaitCarNameAppeared();

            // THEN: Add founded car to favorite bookmarks.
            _addToBookmarks.AddCarToBookmark();

            // AND: Open my profile to open favorite bookmarks.
            _profile.ClickOnProfileIcon();

            // THEN: Open bookmarks.
            _openBookmarks.OpenBookmarks();

            // AND: Check if car was added to bookmarks.
            var expectedResult = true;
            var actualResult = _openBookmarks.IsAudiDispayed();
            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");
        }
    }
}