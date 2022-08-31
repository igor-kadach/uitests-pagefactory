using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Threading;
using UITests.PageObjects;

namespace UITests.Tests
{
    class UploadPhotoTest
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
            _webDriver.Close();
        }

     // [Test]
        public void CheckUploadPhotoTest()
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
            Thread.Sleep(1500);

            var goToPerosonalArea = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToPerosonalArea);
            goToPerosonalArea._profile.Click();
            Thread.Sleep(1500);

            var addPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addPhoto);
            addPhoto._buttonChange.Click();
            Thread.Sleep(1500);
            addPhoto._buttonChoosePhoto.SendKeys(TestDatas.filePath);
            Thread.Sleep(3000);
            addPhoto._buttonSaveChanges.Click();
            Thread.Sleep(2000);
            addPhoto._buttonChange.Click();
            Thread.Sleep(2000);

            var checkPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, checkPhoto);
            checkPhoto.isAddedPhotoDisplayed();

            var actualResult = checkPhoto.isAddedPhotoDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}
