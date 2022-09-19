using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.Utils;

namespace UITests.PageObjects
{
    public abstract class BasePageObject
    {
        protected readonly IWebDriver _webDriver;

        public BasePageObject()
        {
            _webDriver = WebDriverSingleton.GetInstance();
            PageFactory.InitElements(_webDriver, this);
        }
    }
}