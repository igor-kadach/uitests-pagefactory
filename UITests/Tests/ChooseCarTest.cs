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
    class ChooseCarTest
    {
        private Settings _settings;

        private MainMenuPageObject _openCatalogForSearching;

        private Actions _common;

        public ChooseCarTest()
        {
            _openCatalogForSearching = new MainMenuPageObject();
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
        [Category("FindCar")]
        [Description("Test4")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChooseCar()
        {
            // GIVEN: Open catalog to entry parametrs for looking.
            _openCatalogForSearching.ClickOnShowCalatogButton();

            // WHEN: Enter necessary parametrs for looking.     
            _common.EnterParametrsForSearching();
            _openCatalogForSearching.WaitCarNameAppeared();

            // THEN: Check if necessary car was found.
            var actualResult = _openCatalogForSearching.GetNameOfCar();
            var expectedResult = "Audi";
            Assert.That(actualResult, Does.Contain(expectedResult), "!wrong results of searching!");
        }
    }
}