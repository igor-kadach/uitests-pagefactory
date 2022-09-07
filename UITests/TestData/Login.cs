using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.PageObjects;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using UITests.TestData;

namespace UITests
{
    public class Login
    {
        public void LoginToSite()
        {
            var _webDriver = WebDriverSingleton.GetInstance();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            var signInButtonClick = new MainMenuPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, signInButtonClick);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonClick._sighInButton)).Click();

            var login = new AuthorizationPageObject(_webDriver);
            PageFactory.InitElements(_webDriver, login);
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.password);
            login._logInButton.Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
    }
}
