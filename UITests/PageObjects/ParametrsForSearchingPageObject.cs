using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class ParametrsForSearchingPageObject : BaseTest
    {
        private Settings _settings;

        public ParametrsForSearchingPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.Name, Using = "p-6-0-2-brand")]
        private IWebElement _carsName { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='button button--secondary button--block']//span[@class='button__text']")]
        private IWebElement _buttonShow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@d,'M12 18a6 6')]")]
        private IWebElement _profile { get; set; }

        [FindsBy(How = How.CssSelector, Using = ":nth-child(2) > div:nth-child(1) > div:nth-child(1) > button:nth-child(1) > span:nth-child(1) ")]
        private IWebElement _allParametrs { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-32-description']")]
        private IWebElement _searchByWords { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(2) > div:nth-child(1) > button:nth-child(1) > span:nth-child(1) ")]
        private IWebElement _popularParametrs { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--secondary button--block']//span[@class='button__text']")]
        private IWebElement _buttonShowForBookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Audi']")]
        private IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[for= 'p-13-transmission_type_1'] span[class='button-group__text']")]
        private IWebElement _transmissionAutomatic { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='p-15-engine_type']")]
        private IWebElement _chooseFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='p-15-engine_type']//li[1]")]
        private IWebElement _benzinFuel { get; set; }

        public void ChooseCarName()
        {
            _carsName.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void CarName()
        {
            _nameAudi.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ChooseTramsmission()
        {
            _transmissionAutomatic.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ChooseFuel()
        {
            _chooseFuel.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void BenzinFuel()
        {
            _benzinFuel.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnShowButton()
        {
            _buttonShow.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnButtonShowForBookmark()
        {
            _buttonShowForBookmark.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitElementProfileIconIsPresent()
        {
            _allParametrs.WaitElementToBeClickable(_webDriver, 10);
        }

        public void ClickOnAllParametrsButton()
        {
            _allParametrs.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitAllParametrsButton()
        {
            var allParametrsButton = By.CssSelector(":nth-child(2) > div:nth-child(1) > div:nth-child(1) > button:nth-child(1) > span:nth-child(1)");
            allParametrsButton.WaitElementIsVisible(_webDriver, 10);
        }

        public void ClickOnPopularParametrsButton()
        {
            _popularParametrs.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void EnterExchangeWord()
        {
            _searchByWords.SendKeys(_settings.Exchange);
            Thread.Sleep(2000);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        public void SearchingField()
        {
            var fieldSearchByWord = By.XPath("//input[@id='p-32-description']");
            fieldSearchByWord.WaitInvisibilityOfElementLocated(_webDriver, 10);
        }
    }
}