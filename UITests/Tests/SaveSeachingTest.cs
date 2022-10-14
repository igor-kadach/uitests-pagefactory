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
    class SaveSeachingTest
    {
        private Settings _settings;

        private Actions _common;

        private MainMenuPageObject _openCatalogForSearching;

        private CatalogPageObject _saveSearch;

        private PersonalAreaPageObject _showSearching;

        public SaveSeachingTest()
        {
            _common = new Actions(_settings);
            _openCatalogForSearching = new MainMenuPageObject();
            _saveSearch = new CatalogPageObject();
            _showSearching = new PersonalAreaPageObject();
        }

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            // Delete saved searches.
            var deleteSearches = new Actions(_settings);
            deleteSearches.DeleteSavedSerches();
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SavingSearch")]
        [Description("Test9")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void SaveSearching()
        {
            // GIVEN: User Login to website.
            _common.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.                        
            _openCatalogForSearching.ClickOnShowCalatogButton();

            // Then: Enter necessary parametrs for looking.            
            _common.EnterParametrsForSearching();

            // AND: Save choosen parametrs to favorite searching.
            _saveSearch.ClickOnSaveSearchButton();
            _saveSearch.CloseSubscribingWindow();

            // THEN: Open saved searches.
            _openCatalogForSearching.SaveSearchList();

            // AND: Check if saved searche is saved.
            var expectedResult = true;
            var actualResult = _showSearching.IsSearchIsSaved();
            Assert.AreEqual(actualResult, expectedResult, "!searching is not saved!");
        }
    }
}