using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.TestData;

namespace UITests.Utils
{
    public class WebDriverSingleton
    {
        private static IWebDriver _webDriver;

      //  private Settings _settings;

        
         
        

        public static IWebDriver GetInstance()
        {
            Settings _settings = SettingsHelper.GetSettings();

            if (_webDriver == null)
            {
                _webDriver = new ChromeDriver();
                _webDriver.Navigate().GoToUrl(_settings.TestUrl);
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