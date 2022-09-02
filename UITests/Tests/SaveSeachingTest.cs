using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class SaveSeachingTest
    {
        [SetUp]
        public void Setup()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            _webDriver.Navigate().GoToUrl(TestData.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var deleteSearching = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, deleteSearching);
            deleteSearching._deleteSavedSearching.Click();
            deleteSearching._acceptDeleting.Click();

            _webDriver.Close();
            _webDriver.Quit();
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

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(TestData.emailAdress);
            login._passwordInputField.SendKeys(TestData.password);
            login._logInButton.Click();

            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openCatalogForSearching);
            openCatalogForSearching._showCatalogButton.Click();

            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, chooseParametrsForSearching);
            wait.Until(ExpectedConditions.ElementToBeClickable(chooseParametrsForSearching._carsName)).Click();
            chooseParametrsForSearching._nameAudi.Click();
            chooseParametrsForSearching._transmissionAutomatic.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._benzinFuel.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._buttonShow.Click();

            var saveSearch = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, saveSearch);            
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._saveSearchButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(saveSearch._closeSubscribing)).Click();

            var openSearchList = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSearchList);
            openSearchList._saveSearchList.Click();

            var isSearhcIsDisplayed = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isSearhcIsDisplayed);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            isSearhcIsDisplayed.isSearchIsSaved();

            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult);
        }
    }
}
