using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.PageObjects;
using UITests.TestData;

namespace UITests.Utils
{
    public class WebDriverSingleton
    {
        private static IWebDriver _webDriver;

        public static IWebDriver GetInstance()
        {
            SettingsHelper.GetSettings();

            if (_webDriver == null)
            {
                _webDriver = new ChromeDriver();
                _webDriver.Navigate().GoToUrl(Settings.TestUrl);
                var acceptCookie = new MainMenuPageObject();
                acceptCookie.AcceptCookie();
                _webDriver.Manage().Window.Maximize();
            }
            return _webDriver;
        }

        public static void DriverQuit()
        {
            _webDriver.Quit();
            _webDriver = null;
        }
    }
}