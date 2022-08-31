using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class CheckFavoriteTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            var deleteBookmark = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, deleteBookmark);
            deleteBookmark._deleteBookmark.Click();

            _webDriver.Close();
        }

     // [Test]
        public void CheckFavorite()
        {
            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            signInButtonClick._sighInButton.Click();
            Thread.Sleep(2000);

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            login._byEmail.Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.password);
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
            Thread.Sleep(2000);

            var addToBookmarks = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addToBookmarks);
            addToBookmarks._bookmark.Click();
            Thread.Sleep(2000);

            var profile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, profile);
            profile._profile.Click();

            var openBookmarks = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openBookmarks);
            openBookmarks._bookmarks.Click();
            Thread.Sleep(2000);

            var IsAudiDispayed = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, IsAudiDispayed);
            IsAudiDispayed.IsAudiDispayed();

            var actualResult = openBookmarks.IsAudiDispayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");
        }
    }
}
