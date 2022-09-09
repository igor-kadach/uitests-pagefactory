using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace UITests.PageObjects
{
    class CatalogPageObject : BasePageObject
    {
        public CatalogPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public CatalogPageObject()
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//div[1]//div[1]//div[5]//button[1]//*[name()='svg']//*[name()='path' and contains(@class,'fill')]")]
        public IWebElement _bookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[4]/div[3]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/h3[1]/a[1]")]
        public IWebElement _openForExchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Предложить обмен…')]")]
        public IWebElement _openOffer { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'BMW 5')]")]
        public IWebElement _myOffer { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Сохранить поиск')]")]
        public IWebElement _saveSearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal modal--active']//*[name()='path' and contains(@d,'M13.414 12')]")]
        public IWebElement _closeSubscribing { get; set; }

        public bool isMyOfferDisplayed()
        {
            Thread.Sleep(3000);
            var isMyOfferDisplayed = _myOffer.Displayed;
            return isMyOfferDisplayed;
        }
    }
}


