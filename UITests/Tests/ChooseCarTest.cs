using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using UITests.PageObjects;
using UITests.TestDatas;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class ChooseCarTest
    {
        [SetUp]
        public void Setup()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            _webDriver.Navigate().GoToUrl(TestData.testUrl);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
            var _webDriver = WebDriverSingleton.GetInstance();
            _webDriver.Close();
            _webDriver.Quit();
            WebDriverSingleton.SetNull();
        }

        [Test(Author = "Igor_Kadach")]
        [Category("FindCar")]
        [Description("Test4")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChooseCart()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

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
