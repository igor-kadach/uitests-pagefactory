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

        private ParametrsForSearchingPageObject _parametrs;

        private CatalogPageObject _myOfferToExchange;

        private Actions _common;

        public CarExchangeTest()
        {
            _parametrs = new ParametrsForSearchingPageObject();
            _myOfferToExchange = new CatalogPageObject();
            _common = new Actions(_settings);
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
        [Category("CarExchange")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]

        public void CarExchange()
        {
            // GIVEN: User login to website.
            _common.LoginToSite();

            // WHEN: Open catalog for enter necessary values.
            _parametrs.WaitAllParametrsButton();
            _parametrs.ClickOnAllParametrsButton();

            // THEN: Enter necessary values and find a car for exchange.
            _parametrs.EnterExchangeWord();
            _parametrs.ClickOnPopularParametrsButton();
            _parametrs.SearchingField();
            _parametrs.ClickOnShowButton();

            // THEN: Open the found offer. 
            _myOfferToExchange.ClickOnOfferExchange();

            // AND: Suggest my car for exchange.
            _myOfferToExchange.OpenOfferForExchange();

            // AND: Сheck if my offer for an exchange has appeared.
            var expectedResult = true;
            var actualResult = _myOfferToExchange.IsMyOfferDisplayed();
            Assert.AreEqual(actualResult, expectedResult, "!offer to exchange is not found!");
        }
    }
}