using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class ChooseCarTest
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
        [Category("FindCar")]
        [Description("Test4")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChooseCar()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            // WHEN: Open catalog to entry parametrs for looking.
            var openCatalogForSearching = new MainMenuPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // THEN: Enter necessary parametrs for looking.     
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            chooseParametrsForSearching.EnterParametrsForSearching();

            // AND: Check if necessary car was found.
            var findCarByParametrs = new MainMenuPageObject(_webDriver);

            var actualResult = findCarByParametrs.GetNameOfCar();
            var expectedResult = "Audi";

            Assert.That(actualResult, Does.Contain(expectedResult), "!wrong results of searching!");
        }
    }
}
