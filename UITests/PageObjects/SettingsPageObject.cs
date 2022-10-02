using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class SettingsPageObject : BasePageObject
    {
        public SettingsPageObject() : base()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(1) > a:nth-child(1) > span:nth-child(1)")]
        public IWebElement _changePassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='old-password']")]
        public IWebElement _oldPassworField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='new-password']")]
        public IWebElement _newPasswordField { get; set; }            

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'] span[class='button__text']")]
        public IWebElement _applyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='set-header__side'] span[class='button__text']")]
        public IWebElement _exitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='header__logo']")]
        public IWebElement _logoAVButton { get; set; }
    }
}