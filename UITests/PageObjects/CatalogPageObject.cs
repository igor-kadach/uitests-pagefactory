using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class CatalogPageObject
    {
        private IWebDriver _webDriver;

        //   private readonly By _bookmark = By.XPath("//div[@class='listing__items']//div[1]//div[1]//div[5]//button[1]//*[name()='svg']//*[name()='path' and contains(@class,'fill')]");
        //    private readonly By _openForExchange = By.XPath("//div[@class='listing__items']/div[1]/div[1]/div[2]//span[1]");
        //    private readonly By _openOffer = By.XPath("//span[contains(text(),'Предложить обмен…')]");
        //    private readonly By _myOffer = By.XPath("//span[contains(text(),'BMW 5')]");
        //    private readonly By _saveSearchButton = By.XPath("//span[contains(text(),'Сохранить поиск')]");
        //    private readonly By _closeSubscribing = By.XPath("//div[@class='modal modal--active']/div[@class='modal__table']/div[@class='modal__cell']/div[@class='modal__dialog']/div[@class='modal__content']/button[1]");

        public CatalogPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
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


        //public ParametrsForSearchingPageObject AddToBookmark()
        //{
        //    _webDriver.FindElement(_bookmark).Click();

        //    return new ParametrsForSearchingPageObject(_webDriver);
        //}

        //public ParametrsForSearchingPageObject OpenCarForExchange()
        //{
        //    _webDriver.FindElement(_openForExchange).Click();
        //    _webDriver.FindElement(_openOffer).Click();

        //    return new ParametrsForSearchingPageObject(_webDriver);
        //}

        public bool isMyOfferDisplayed()
        {
            var isMyOfferDisplayed = _myOffer.Displayed;

            return isMyOfferDisplayed;
        }

        //    public MainMenuPageObject SaveSearch()
        //  {
        //    _webDriver.FindElement(_saveSearchButton).Click();
        //   _webDriver.FindElement(_closeSubscribing).Click();

        //            return new MainMenuPageObject(_webDriver);
        //       }
    }
}


