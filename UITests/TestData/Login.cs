using System;
using UITests.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UITests.TestData;
using System.Threading;

namespace UITests
{
    public class Login 
    {
        public void LoginToSite()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonClick._sighInButton)).Click();

            var login = new AuthorizationPageObject(_webDriver);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.password);
            login._logInButton.Click();
            Thread.Sleep(2000);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
    }
}
