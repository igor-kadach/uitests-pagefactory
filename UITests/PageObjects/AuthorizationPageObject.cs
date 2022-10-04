using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        private Settings _settings;

        public AuthorizationPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='drawer__slide drawer__slide--active'] button:nth-child(2)")]
        public IWebElement _byEmail { get; set; }

        public void ChooseMethodByEmail()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_byEmail)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='login']")]
        public IWebElement _loginInputField { get; set; }

        public void EnterEmailInLoginField()
        {
            _loginInputField.SendKeys(_settings.EmailAdress);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='loginPassword']")]
        public IWebElement _passwordInputField { get; set; }

        public void EnterPassInPasswordField()
        {
            _passwordInputField.SendKeys(_settings.Password);
        }

        public void EnterNewPassInPasswordField()
        {
            _passwordInputField.SendKeys(_settings.NewPasswordForTest);
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--action'] span[class='button__text']")]
        public IWebElement _logInButton { get; set; }

        public void ClickOnLogInButton()
        {
            _logInButton.Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='error-message']")]
        public IWebElement _errorMessage { get; set; }

        public void WaitErrorMessage()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.TextToBePresentInElement(_errorMessage, "Неверный логин"));
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='drawer__close']")]
        public IWebElement _closeAuthWondow { get; set; }

        public void CloseAuthWondow()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_closeAuthWondow)).Click();
        }
    }
}