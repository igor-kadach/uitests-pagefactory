using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    public abstract class BasePageObject
    {
        protected readonly IWebDriver _webDriver;
        public BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

    }
}
