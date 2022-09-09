using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Threading;
using UITests.PageObjects;
using UITests.Utils;

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
            var wait = WebDriverWaitUtils.GetWaiter(20);

            //GIVEN: Login to website.
            var login = new Login();
            login.LoginToSite();

            // THEN: Open my profile to open my sale ads.
            var goToPerosonalArea = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToPerosonalArea._profile)).Click();

            // WHEN: Open my ad.
            var addPhoto = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();
            Thread.Sleep(3000);

            // THEN: Add new photo.
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\{TestDatas.fileName}";
            addPhoto._buttonChoosePhoto.SendKeys(pathForPhoto);
            Thread.Sleep(5000);
            // THEN: Save adding photo.
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonSaveChanges)).Click();
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(addPhoto._buttonChange)).Click();

            // THEN: Check if photo was added.                
            var actualResult = addPhoto.isAddedPhotoDisplayed();
            var expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "!image not found!");
        }
    }
}
