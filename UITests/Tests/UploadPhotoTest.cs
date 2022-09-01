using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
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

            var goToPerosonalArea = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToPerosonalArea);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToPerosonalArea._profile)).Click();
            goToPerosonalArea._profile.Click();

            var addPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addPhoto);
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

           // Thread.Sleep(1500);
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\{TestData.fileName}";

            addPhoto._buttonChoosePhoto.SendKeys(pathForPhoto);
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonSaveChanges)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var checkPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, checkPhoto);
            checkPhoto.isAddedPhotoDisplayed();

            var actualResult = checkPhoto.isAddedPhotoDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}
