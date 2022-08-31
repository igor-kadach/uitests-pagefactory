using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;

namespace UITests.Tests
{
    class ChooseCarTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Close();
        }

        [Test]
        public void ChooseCart()
        {
            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, openCatalogForSearching);
            openCatalogForSearching._showCatalogButton.Click();

            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, chooseParametrsForSearching);
            chooseParametrsForSearching._carsName.Click();
            chooseParametrsForSearching._nameAudi.Click();
            chooseParametrsForSearching._transmissionAutomatic.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._benzinFuel.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._buttonShow.Click();

            var findCarByParametrs = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, findCarByParametrs);
            findCarByParametrs.GetNameOfCar();

            var actualResult = findCarByParametrs.GetNameOfCar();
            var expectedResult = "Audi";

            Assert.That(actualResult, Does.Contain(expectedResult), "!wrong results of searching!");
        }
    }
}
