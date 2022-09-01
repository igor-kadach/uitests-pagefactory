using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
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

      //  [Test]
        public void CheckFavorite()
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

            var addToBookmarks = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addToBookmarks);
            wait.Until(ExpectedConditions.ElementToBeClickable(addToBookmarks._bookmark)).Click();            

            var profile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, profile);
            wait.Until(ExpectedConditions.ElementToBeClickable(profile._profile)).Click();            

            var openBookmarks = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openBookmarks);
            wait.Until(ExpectedConditions.ElementToBeClickable(openBookmarks._bookmarks)).Click();
            
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var IsAudiDispayed = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, IsAudiDispayed);
            IsAudiDispayed.IsAudiDispayed();

            var actualResult = openBookmarks.IsAudiDispayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!Audi not found!");
        }
    }
}
