using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class SettingsPageObject : BasePageObject
    {

        private Settings _settings;

        public SettingsPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(1) > a:nth-child(1) > span:nth-child(1)")]
        public IWebElement _changePassword { get; set; }

        public void ClickOnChangePasswordButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_changePassword)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//h1[@class='heading__text']")]
        public IWebElement _newPasswordTitle { get; set; }

        public void WaitTitleOfNewPasswordPage()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.TextToBePresentInElement(_newPasswordTitle, "Новый пароль"));
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='old-password']")]
        public IWebElement _oldPassworField { get; set; }

        public void EnterActualPassword()
        {
            _oldPassworField.SendKeys(_settings.Password);
        }

        public void EnterNewlPasswordForChange()
        {
            _oldPassworField.SendKeys(_settings.NewPasswordForTest);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='new-password']")]
        public IWebElement _newPasswordField { get; set; }

        public void EnterNewPassword()
        {
            _newPasswordField.SendKeys(_settings.NewPasswordForTest);
        }

        public void EnterNewPasswordForChange()
        {
            _newPasswordField.SendKeys(_settings.NewPasswordForTest);
        }

        public void EnterOldPasswordForChange()
        {
            _newPasswordField.SendKeys(_settings.Password);
        }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'] span[class='button__text']")]
        public IWebElement _applyButton { get; set; }

        public void ApplyChanges()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_applyButton)).Click();
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='set-header__side'] span[class='button__text']")]
        public IWebElement _exitButton { get; set; }

        public void ClickOnExitButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_exitButton)).Click();
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='header__logo']")]
        public IWebElement _logoAVButton { get; set; }

        public void ClickOnAVLogo()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_logoAVButton)).Click();
        }
    }
}