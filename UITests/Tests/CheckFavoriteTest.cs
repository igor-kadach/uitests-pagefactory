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
    class CheckFavoriteTest
    {
        [SetUp]
        public void Setup()
        {
            WebDriverSingleton.GetInstance();
        }

        [TearDown]
        public void EndTest()
        {
            // Delete saved bookmarks.   
            var deleteBookmarks = new PersonalAreaPageObject();
            deleteBookmarks.DeleteSavedBoormarks();
            Thread.Sleep(2000);
            WebDriverSingleton.SetNull();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SaveFavoriteCar")]
        [Description("Test3")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckFavorite()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.
            var openCatalogForSearching = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // THEN: Enter necessary parametrs for looking.         
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject();
            chooseParametrsForSearching.EnterParametrsForSearching();

            // THEN: Add founded car to favorite bookmarks.
            var addToBookmarks = new CatalogPageObject();
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(addToBookmarks._bookmark)).Click();

            // AND: Open my profile to open favorite bookmarks.
            var profile = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(profile._profile)).Click();

            // THEN: Open bookmarks.
            var openBookmarks = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openBookmarks._bookmarks)).Click();

            // AND: Check if car was added to bookmarks.
            var actualResult = openBookmarks.IsAudiDispayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");
        }
    }
}
