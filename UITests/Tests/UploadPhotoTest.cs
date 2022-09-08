using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class UploadPhotoTest
    {
        [SetUp]
        public void Setup()
        {        
            WebDriverSingleton.GetInstance();
        }

        [TearDown]
        public void EndTest()
        {         
            WebDriverSingleton.SetNull();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("UploadProto")]
        [Description("Test10")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void CheckUploadPhotoTest()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

                ///Login to website.
            Login login = new Login();
            login.LoginToSite();                       

                ///Open my profile to open my sale ads.
            var goToPerosonalArea = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToPerosonalArea);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToPerosonalArea._profile)).Click();
            goToPerosonalArea._profile.Click();

                ///Open my ad.
            var addPhoto = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, addPhoto);
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                ///Add new photo.
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\{TestDatas.fileName}";
            addPhoto._buttonChoosePhoto.SendKeys(pathForPhoto);
            Thread.Sleep(2000);
                ///Save adding photo.
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonSaveChanges)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                ///Check if photo was added.                
            var actualResult = addPhoto.isAddedPhotoDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}
