using OpenQA.Selenium.Support.UI;
using System;

namespace UITests.Utils
{
    public static class WebDriverWaitUtils
    {
        public static WebDriverWait GetWaiter(int seconds)
        {
            var webDriver = WebDriverSingleton.GetInstance();
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
        }
    }
}
