using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class PaymentIntegrationTest
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
        [Category("PaymentByCard")]
        [Description("Test8")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void PaymentIntegration()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

                ///Login to website.
            Login login = new Login();
            login.LoginToSite();

                ///Open my profile to open adding points menu.
            var goToMyProfile = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, goToMyProfile);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();

                ///Open adding points menu to choose payment method and buy points.
            var buyPoints = new PersonalAreaPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, buyPoints);
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._points)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._pointsFor10Rubles)).Click();
                ///Choose payment method.
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._payByCard)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._goToPayService)).Click();

                ///Check redirect to the payment page.
            var actualResult = buyPoints.isLogoDisplayed();

            Assert.IsTrue(actualResult, "!can't redirect to payment method!");
        }
    }
}
