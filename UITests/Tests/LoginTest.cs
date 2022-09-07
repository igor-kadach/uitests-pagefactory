using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class LoginTest
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
        [Category("LoginToSite")]
        [Description("Test7")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void Login()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

                ///Login to website.
            Login login = new Login();
            login.LoginToSite();            

                ///Check if my profile icon is dispayed.
            var isProfileDisplayed = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, isProfileDisplayed);

            var actualResult = isProfileDisplayed.GetProfileMenu();
            var expectedResult = true;

            Assert.AreEqual(actualResult, expectedResult, "!wrong credential!");           
        }
    }
}
