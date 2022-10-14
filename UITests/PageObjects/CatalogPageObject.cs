using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class CatalogPageObject : BaseTest
    {
        public CatalogPageObject() : base()
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//*[name()='svg']")]
        private IWebElement _bookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal modal--active']//*[name()='path']")]
        private IWebElement _closeSubscribing { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='listing__items'] div:nth-child(1) div:nth-child(1) a:nth-child(1) span:nth-child(1)")]
        private IWebElement _openForExchange { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--default'] span[class='button__text']")]
        private IWebElement _openOffer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='chats-subject__info'] div:nth-child(2)")]
        private IWebElement _myOffer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button:nth-child(3) > span:nth-child(2)")]
        private IWebElement _saveSearchButton { get; set; }

        public void AddCarToBookmark()
        {
            _bookmark.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnOfferExchange()
        {
            _openForExchange.WaitElementToBeClickable(_webDriver, 10);
            _openForExchange.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void OpenOfferForExchange()
        {
            _openOffer.WaitElementToBeClickable(_webDriver, 10);
            _openOffer.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnSaveSearchButton()
        {
            _saveSearchButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void CloseSubscribingWindow()
        {
            _closeSubscribing.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public bool IsMyOfferDisplayed()
        {
            _myOffer.WaitElementToBeClickable(_webDriver, 10);
            var isMyOfferDisplayed = _myOffer.Displayed;
            return isMyOfferDisplayed;
        }
    }
}