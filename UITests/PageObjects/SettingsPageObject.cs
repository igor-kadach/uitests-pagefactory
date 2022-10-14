using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class SettingsPageObject : BaseTest
    {
        private Settings _settings;

        public SettingsPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(1) > a:nth-child(1) > span:nth-child(1)")]
        private IWebElement _changePassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[@class='heading__text']")]
        private IWebElement _newPasswordTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='old-password']")]
        private IWebElement _oldPassworField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='new-password']")]
        private IWebElement _newPasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'] span[class='button__text']")]
        private IWebElement _applyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='set-header__side'] span[class='button__text']")]
        private IWebElement _exitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='header__logo']")]
        private IWebElement _logoAVButton { get; set; }

        public void ClickOnChangePasswordButton()
        {
            _changePassword.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitTitleOfNewPasswordPage()
        {
            var titleOfNewPasswordPage = By.XPath("//h1[@class='heading__text']");
            titleOfNewPasswordPage.WaitElementIsVisible(_webDriver, 10);
        }

        public void EnterActualPassword()
        {
            _oldPassworField.SendKeys(_settings.Password);
        }

        public void EnterNewlPasswordForChange()
        {
            _oldPassworField.SendKeys(_settings.NewPasswordForTest);
        }

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

        public void ApplyChanges()
        {
            _applyButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnExitButton()
        {
            _exitButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnAVLogo()
        {
            _logoAVButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }
    }
}