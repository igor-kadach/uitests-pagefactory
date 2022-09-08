using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]

    class CarExchangeTest
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
        [Category("CarExchange")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]  
        
        public void CarExchange()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

                ///Login to website.
            Login login = new Login();
            login.LoginToSite();           

                ///Open catalog for enter necessary values.
            var offersForExchange = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, offersForExchange);
            wait.Until(ExpectedConditions.ElementToBeClickable(offersForExchange._allParametrs)).Click();
                ///Enter necessary values and find a car for exchange.
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            offersForExchange._searchByWords.SendKeys(TestDatas.exchange);
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(offersForExchange._buttonShow)).Click();

                ///Open the found offer. 
            var myOfferForExchange = new CatalogPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, myOfferForExchange);
            wait.Until(ExpectedConditions.ElementToBeClickable(myOfferForExchange._openForExchange)).Click();
                ///And suggest my car for exchange.
            wait.Until(ExpectedConditions.ElementToBeClickable(myOfferForExchange._openOffer)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                ///Сhecking if my offer for an exchange has appeared.
            var actualResult = myOfferForExchange.isMyOfferDisplayed();

            Assert.IsTrue(actualResult, "!offer to exchange is not found!");
        }
    }
}


