using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class CheckFavoriteTest
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
            var deleteBookmark = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, deleteBookmark);
            deleteBookmark._deleteBookmark.Click();

            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }

        [Test]
        public void CheckFavorite()
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
