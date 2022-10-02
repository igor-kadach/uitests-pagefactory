using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class CatalogPageObject : BasePageObject
    {
        public CatalogPageObject() : base()
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//*[name()='svg']")]
        public IWebElement _bookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//div[1]//div[1]//h3[1]")]
        public IWebElement _openForExchange { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--default'] span[class='button__text']")]
        public IWebElement _openOffer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='chats-subject__info'] div:nth-child(2)")]
        public IWebElement _myOffer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button:nth-child(3) > span:nth-child(2)")]
        public IWebElement _saveSearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal modal--active']//*[name()='path']")]
        public IWebElement _closeSubscribing { get; set; }
    }
}