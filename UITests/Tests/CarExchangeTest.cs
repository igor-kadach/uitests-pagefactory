using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Threading;
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
            WebDriverSingleton.SetNull();
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
            var common = new CommonPageObject(_settings);
            common.LoginToSite();

            // WHEN: Open catalog for enter necessary values.
            var parametrs = new ParametrsForSearchingPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._allParametrs)).Click();

            // THEN: Enter necessary values and find a car for exchange.
            parametrs._searchByWords.SendKeys(_settings.Exchange);
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._buttonShow)).Click();

            // THEN: Open the found offer. 
            var myOfferToExchange = new CatalogPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(myOfferToExchange._openForExchange)).Click();

            // AND: Suggest my car for exchange.
            wait.Until(ExpectedConditions.ElementToBeClickable(myOfferToExchange._openOffer)).Click();

            // AND: Сheck if my offer for an exchange has appeared.
            var actualResult = common.isMyOfferDisplayed();

            Assert.IsTrue(actualResult, "!offer to exchange is not found!");
        }
    }
}