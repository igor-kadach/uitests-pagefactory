using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
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
            Thread.Sleep(3000);
            var deleteSearching = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, deleteSearching);
            deleteSearching._deleteSavedSearching.Click();
            deleteSearching._acceptDeleting.Click();

            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }

        [Test]
        public void SaveSearching()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byEmail.Click();
            login._loginInputField.SendKeys(TestData.emailAdress);
            login._passwordInputField.SendKeys(TestData.password);
            login._logInButton.Click();

            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openCatalogForSearching);
            openCatalogForSearching._showCatalogButton.Click();
            Thread.Sleep(2000);

            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, chooseParametrsForSearching);
            chooseParametrsForSearching._carsName.Click();
            chooseParametrsForSearching._nameAudi.Click();
            chooseParametrsForSearching._transmissionAutomatic.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._benzinFuel.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._buttonShow.Click();

            var saveSearch = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, saveSearch);
            saveSearch._saveSearchButton.Click();
            Thread.Sleep(2000);
            saveSearch._closeSubscribing.Click();

            var openSearchList = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openSearchList);
            openSearchList._saveSearchList.Click();

            var isSearhcIsDisplayed = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isSearhcIsDisplayed);
            Thread.Sleep(3000);
            isSearhcIsDisplayed.isSearchIsSaved();

            var actualResult = isSearhcIsDisplayed.isSearchIsSaved();

            Assert.IsTrue(actualResult);
        }
    }
}
