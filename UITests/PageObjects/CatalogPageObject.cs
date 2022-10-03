using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class CatalogPageObject : BasePageObject
    {
        private Settings _settings;

        public CatalogPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//*[name()='svg']")]
        public IWebElement _bookmark { get; set; }

        public void AddCarToBookmark()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_bookmark)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//div[1]//div[1]//h3[1]")]
        public IWebElement _openForExchange { get; set; }

        public void ClickOnOfferExchange()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_openForExchange)).Click();
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--default'] span[class='button__text']")]
        public IWebElement _openOffer { get; set; }

        public void OpenOfferForExchange()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_openOffer)).Click();
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='chats-subject__info'] div:nth-child(2)")]
        public IWebElement _myOffer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button:nth-child(3) > span:nth-child(2)")]
        public IWebElement _saveSearchButton { get; set; }

        public void ClickOnSaveSearchButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_saveSearchButton)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal modal--active']//*[name()='path']")]
        public IWebElement _closeSubscribing { get; set; }

        public void CloseSubscribingWindow()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_closeSubscribing)).Click();
        }
    }
}