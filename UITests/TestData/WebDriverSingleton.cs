using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace UITests.TestDatas
{
    public class WebDriverSingleton
    {
        private static IWebDriver _webDriver;
                
        public static IWebDriver GetInstance()
        {
            if (_webDriver == null)
            {
                _webDriver = new ChromeDriver();
                _webDriver.Manage().Window.Maximize();
            }
            return _webDriver;
        }
        public static void SetNull()
        {
            _webDriver = null;
        }
    }
}