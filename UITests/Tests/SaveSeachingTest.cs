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
    class SaveSeachingTest
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
            // Delete saved searches.
            var deleteSearching = new PersonalAreaPageObject(_webDriver);
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSearching._deleteSavedSearching)).Click();
            deleteSearching._acceptDeleting.Click();

            WebDriverSingleton.SetNull();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("SavingSearch")]
        [Description("Test9")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void SaveSearching()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            // GIVEN: User Login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.                        
            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // Then: Enter necessary parametrs for looking.            
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            chooseParametrsForSearching.EnterParametrsForSearching();

            // AND: Save choosen parametrs to favorite searching.
            var saveSearch = new CatalogPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._saveSearchButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._closeSubscribing)).Click();

            // THEN: Open saved searches.
            var openSearchList = new MainMenuPageObject(_webDriver);
            openSearchList._saveSearchList.Click();

            // AND: Check if saved searche is saved.
            var isSearhcIsDisplayed = new PersonalAreaPageObject(_webDriver);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult, "!searching is not saved!");
        }
    }
}
