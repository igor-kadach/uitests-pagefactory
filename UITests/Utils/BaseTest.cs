using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.Utils
{
    public class BaseTest
    {
        public static IWebDriver _webDriver;

        public BaseTest()
        {
            _webDriver = WebDriverSingleton.GetInstance();
            PageFactory.InitElements(_webDriver, this);
        }

        public static void DriverClose()
        {
            WebDriverSingleton.DriverQuit();
        }
    }
}