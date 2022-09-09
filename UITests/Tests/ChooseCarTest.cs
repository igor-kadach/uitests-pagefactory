using Allure.Commons;
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
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // WHEN: Open catalog to entry parametrs for looking.
            var openCatalogForSearching = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openCatalogForSearching._showCatalogButton)).Click();

            // THEN: Enter necessary parametrs for looking.     
            var chooseParametrsForSearching = new ParametrsForSearchingPageObject();
            chooseParametrsForSearching.EnterParametrsForSearching();

            // AND: Check if necessary car was found.
            var findCarByParametrs = new MainMenuPageObject();
            var actualResult = findCarByParametrs.GetNameOfCar();
            var expectedResult = "Audi";

            Assert.That(actualResult, Does.Contain(expectedResult), "!wrong results of searching!");
        }
    }
}
