using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    public class AuthorizationPageObject : BaseTest
    {
        private Settings _settings;

        public AuthorizationPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='drawer__slide drawer__slide--active'] button:nth-child(2)")]
        private IWebElement _byEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='login']")]
        private IWebElement _loginInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='loginPassword']")]
        private IWebElement _passwordInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--action'] span[class='button__text']")]
        private IWebElement _logInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='error-message']")]
        private IWebElement _errorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='drawer__close']")]
        private IWebElement _closeAuthWondow { get; set; }

        public void ChooseMethodByEmail()
        {
            _byEmail.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void EnterEmailInLoginField()
        {
            _loginInputField.SendKeys(_settings.EmailAdress);
        }

        public void EnterPassInPasswordField()
        {
            _passwordInputField.SendKeys(_settings.Password);
        }

        public void EnterNewPassInPasswordField()
        {
            _passwordInputField.SendKeys(_settings.NewPasswordForTest);
        }

        public void ClickOnLogInButton()
        {
            _logInButton.Click();
        }

        public void WaitErrorMessage()
        {
            var errorMessageElement = By.CssSelector(".error-message");
            errorMessageElement.WaitElementIsVisible(_webDriver, 10);
        }

        public bool IsErrorMessageDisplayed()
        {
            WaitErrorMessage();
            var isErrorMessageDisplayed = _errorMessage.Displayed;
            return isErrorMessageDisplayed;
        }

        public void CloseAuthWondow()
        {
            _closeAuthWondow.WaitElementToBeClickable(_webDriver, 10).Click();
        }
    }
}