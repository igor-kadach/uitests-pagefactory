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

    class CarExchangeTest
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
        [Category("CarExchange")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]

        public void CarExchange()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: User login to website.
            var common = new Actions(_settings);
            common.LoginToSite();

            // WHEN: Open catalog for enter necessary values.
            var parametrs = new ParametrsForSearchingPageObject();
            parametrs.ClickOnAllParametrsButton();

            // THEN: Enter necessary values and find a car for exchange.
            parametrs.EnterExchangeWord();
            parametrs.ClickOnShowButton();

            // THEN: Open the found offer. 
            var myOfferToExchange = new CatalogPageObject();
            myOfferToExchange.ClickOnOfferExchange();

            // AND: Suggest my car for exchange.
            myOfferToExchange.OpenOfferForExchange();

            // AND: Сheck if my offer for an exchange has appeared.
            var actualResult = common.IsMyOfferDisplayed();
            Assert.IsTrue(actualResult, "!offer to exchange is not found!");
        }
    }
}