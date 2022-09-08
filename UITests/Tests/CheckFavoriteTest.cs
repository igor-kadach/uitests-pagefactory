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
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            // Delete saved bookmarks.            
            var deleteBookmark = new PersonalAreaPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteBookmark._deleteBookmark)).Click();

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
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.
            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // THEN: Enter necessary parametrs for looking.         
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            chooseParametrsForSearching.EnterParametrsForSearching();

            // THEN: Add founded car to favorite bookmarks.
            var addToBookmarks = new CatalogPageObject(_webDriver);
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(addToBookmarks._bookmark)).Click();

            // AND: Open my profile to open favorite bookmarks.
            var profile = new MainMenuPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(profile._profile)).Click();

            // THEN: Open bookmarks.
            var openBookmarks = new PersonalAreaPageObject(_webDriver);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            wait.Until(ExpectedConditions.ElementToBeClickable(openBookmarks._bookmarks)).Click();

            // AND: Check if car was added to bookmarks.
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var actualResult = openBookmarks.IsAudiDispayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");
        }
    }
}
