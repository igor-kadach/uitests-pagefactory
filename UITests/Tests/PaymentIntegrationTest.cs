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

        [SetUp]
        public void Setup()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [TearDown]
        public void EndTest()
        {
            WebDriverSingleton.DriverQuit();
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
            var common = new Actions(_settings);
            common.LoginToSite();

            // WHEN: Open my profile to open adding points menu.
            var goToMyProfile = new MainMenuPageObject();
            goToMyProfile.ClickOnProfileIcon();

            // THEN: Open adding points menu to choose payment method and buy points.
            var buyPoints = new PersonalAreaPageObject();
            buyPoints.BuyPoints();
            buyPoints.BuyPointsFor10Rubles();

            // AND: Choose payment method.
            buyPoints.BuyByCard();
            buyPoints.GoToPayService();

            // THEN: Check redirect to the payment page.
            var actualResult = common.IsLogoDisplayed();
            Assert.IsTrue(actualResult, "!can't redirect to payment method!");
        }
    }
}