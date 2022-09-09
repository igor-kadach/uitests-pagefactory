﻿using Allure.Commons;
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
            // Delete saved searches.
            var deleteSearches = new PersonalAreaPageObject();
            deleteSearches.DeleteSavedSerches();
            Thread.Sleep(2000);
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
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: User Login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Open catalog to entry parametrs for looking.                        
            var openCatalogForSearching = new MainMenuPageObject();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // Then: Enter necessary parametrs for looking.            
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject();
            chooseParametrsForSearching.EnterParametrsForSearching();

            // AND: Save choosen parametrs to favorite searching.
            var saveSearch = new CatalogPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._saveSearchButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._closeSubscribing)).Click();

            // THEN: Open saved searches.
            var openSearchList = new MainMenuPageObject();
            openSearchList._saveSearchList.Click();

            // AND: Check if saved searche is saved.
            var isSearhcIsDisplayed = new PersonalAreaPageObject();
            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult, "!searching is not saved!");
        }
    }
}
