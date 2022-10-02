using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        public AuthorizationPageObject() : base()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='drawer__slide drawer__slide--active'] button:nth-child(2)")]
        public IWebElement _byEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='login']")]
        public IWebElement _loginInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='loginPassword']")]
        public IWebElement _passwordInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--action'] span[class='button__text']")]
        public IWebElement _logInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='error-message']")]
        public IWebElement _errorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='drawer__close']")]
        public IWebElement _closeAuthWondow { get; set; }
    }
}