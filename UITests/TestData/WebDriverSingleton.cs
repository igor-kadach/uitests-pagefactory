using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests.TestData
{
    public class WebDriverSingleton
    {
        private static IWebDriver _webDriver;
                
        public static IWebDriver GetInstance()
        {
            if (_webDriver == null)
            {
                _webDriver = new ChromeDriver();
                _webDriver.Navigate().GoToUrl(TestDatas.testUrl);
                _webDriver.Manage().Window.Maximize();
            }
            return _webDriver;
        }
        public static void SetNull()
        {
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver = null;
        }
    }
}