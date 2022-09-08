using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
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
                ///Delete saved searches.
            var deleteSearching = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, deleteSearching);
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

                ///Login to website.
            Login login = new Login();
            login.LoginToSite();

                ///Open catalog to entry parametrs for looking.                        
            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openCatalogForSearching);
            openCatalogForSearching._showCatalogButton.Click();

                ///Enter necessary parametrs for looking.            
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, chooseParametrsForSearching);
            chooseParametrsForSearching.EnterParametrsForSearching();

                ///Save choosen parametrs to favorite searching.
            var saveSearch = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, saveSearch);            
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._saveSearchButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._closeSubscribing)).Click();

                ///Open saved searches.
            var openSearchList = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSearchList);
            openSearchList._saveSearchList.Click();

                ///Check if saved searche is saved.
            var isSearhcIsDisplayed = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isSearhcIsDisplayed);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult, "!searching is not saved!");
        }
    }
}
