using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.IO;
using System.Threading;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    class UploadPhotoTest
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

            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }

        [Test]
        public void CheckUploadPhotoTest()
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
            Thread.Sleep(1500);

            var goToPerosonalArea = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToPerosonalArea);
            goToPerosonalArea._profile.Click();
            Thread.Sleep(1500);

            var addPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addPhoto);
            addPhoto._buttonChange.Click();
            Thread.Sleep(1500);
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\{TestData.fileName}";
            addPhoto._buttonChoosePhoto.SendKeys(pathForPhoto);
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
