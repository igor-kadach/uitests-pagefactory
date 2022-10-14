using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace UITests.Utils
{
    public static class WebElementExtensions
    {
        public static IWebElement WaitElementToBeClickable(this IWebElement element, IWebDriver _webDriver, int timeout = 10)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static IWebElement WaitElementIsVisible(this By locator, IWebDriver driver, int timeout = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static bool WaitInvisibilityOfElementLocated(this By locator, IWebDriver driver, int timeout = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}