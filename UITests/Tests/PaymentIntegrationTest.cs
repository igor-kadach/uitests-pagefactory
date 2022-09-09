﻿using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using UITests.PageObjects;
using UITests.Utils;

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
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: User login to website.
            var login = new Login();
            login.LoginToSite();

            // WHEN: Open my profile to open adding points menu.
            var goToMyProfile = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();

            // THEN: Open adding points menu to choose payment method and buy points.
            var buyPoints = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._points)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._pointsFor10Rubles)).Click();

            // AND: Choose payment method.
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._payByCard)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(buyPoints._goToPayService)).Click();

            // THEN: Check redirect to the payment page.
            var actualResult = buyPoints.isLogoDisplayed();

            Assert.IsTrue(actualResult, "!can't redirect to payment method!");
        }
    }
}
