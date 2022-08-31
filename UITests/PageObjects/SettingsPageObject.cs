using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class SettingsPageObject
    {
        private IWebDriver _webDriver;


        public SettingsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/settings/password']//span[contains(text(),'Изменить')]")]
        public IWebElement _changePassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='old-password']")]
        public IWebElement _oldPassworField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='new-password']")]
        public IWebElement _newPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[6]//a")]
        public IWebElement _settingsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Применить')]")]
        public IWebElement _applyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='set-header__side']//span[contains(text(),'Выйти')]")]
        public IWebElement _exitButton { get; set; }
            
    }
}
