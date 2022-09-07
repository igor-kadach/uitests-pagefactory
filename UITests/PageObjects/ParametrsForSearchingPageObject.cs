﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.TestData;

namespace UITests.PageObjects
{
    class ParametrsForSearchingPageObject
    {
        private IWebDriver _webDriver;

        public ParametrsForSearchingPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//button[@title='Марка']")]
        public IWebElement _carsName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Audi']")]
        public IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'автомат')]")]
        public IWebElement _transmissionAutomatic { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='p-15-engine_type']//span[@class='dropdown-button__value']")]
        public IWebElement _chooseFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='p-15-engine_type']//li[1]//label[1]//span[1]")]
        public IWebElement _benzinFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Показать')]")]
        public IWebElement _buttonShow { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Все параметры')]")]
        public IWebElement _allParametrs { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-32-description']")]
        public IWebElement _searchByWords { get; set; }


        public void EnterParametrsForSearching()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            var chooseParametrsForSearching = new ParametrsForSearchingPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, chooseParametrsForSearching);
            wait.Until(ExpectedConditions.ElementToBeClickable(chooseParametrsForSearching._carsName)).Click();
            chooseParametrsForSearching._nameAudi.Click();
            chooseParametrsForSearching._transmissionAutomatic.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            chooseParametrsForSearching._benzinFuel.Click();
            chooseParametrsForSearching._chooseFuel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(chooseParametrsForSearching._buttonShow)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}
