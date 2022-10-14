using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using UITests.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class PaymentIntegrationTest
    {
        private Settings _settings;

        private Actions _common;

        private MainMenuPageObject _goToMyProfile;

        private PersonalAreaPageObject _buyPoints;

        public PaymentIntegrationTest()
        {
            _common = new Actions(_settings);
            _goToMyProfile = new MainMenuPageObject();
            _buyPoints = new PersonalAreaPageObject();
        }

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            BaseTest.DriverClose();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("PaymentByCard")]
        [Description("Test8")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void PaymentIntegration()
        {
            // GIVEN: User login to website.
            _common.LoginToSite();

            // WHEN: Open my profile to open adding points menu.
            _goToMyProfile.ClickOnProfileIcon();

            // THEN: Open adding points menu to choose payment method and buy points.
            _buyPoints.BuyPoints();
            _buyPoints.BuyPointsFor10Rubles();

            // AND: Choose payment method.
            _buyPoints.BuyByCard();
            _buyPoints.GoToPayService();

            // THEN: Check redirect to the payment page.
            var expectedResult = true;
            var actualResult = _buyPoints.IsLogoDisplayed();
            Assert.AreEqual(actualResult, expectedResult, "!can't redirect to payment method!");
        }
    }
}