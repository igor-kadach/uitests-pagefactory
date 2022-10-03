﻿using Allure.Commons;
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
        [Category("FindCar")]
        [Description("Test4")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ChooseCar()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // GIVEN: Open catalog to entry parametrs for looking.
            var openCatalogForSearching = new MainMenuPageObject();
            openCatalogForSearching.ClickOnShowCalatogButton();

            // WHEN: Enter necessary parametrs for looking.     
            var common = new Actions(_settings);
            common.EnterParametrsForSearching();
            openCatalogForSearching.WaitCarNameAppeared();

            // THEN: Check if necessary car was found.
            var actualResult = common.GetNameOfCar();
            var expectedResult = "Audi";
            Assert.That(actualResult, Does.Contain(expectedResult), "!wrong results of searching!");
        }
    }
}