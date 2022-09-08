using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    public class AuthorizationPageObject
    {
        private IWebDriver _webDriver;            

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'почте или логину')]")]
        public IWebElement _byEmail { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//input[@id='authPhone']")]
        public IWebElement _byPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'по телефону')]")]
        public IWebElement _byPhoneAfterChangePass { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone']")]
        public IWebElement _phoneFieldAfterChagePass { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='tabcontent']//input[@id='passwordPhone']")]
        public IWebElement _newPassAfterChangePass { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='login']")]
        public IWebElement _loginInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='loginPassword']")]
        public IWebElement _passwordInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='drawer__slide drawer__slide--active']//input[@id='passwordPhone']")]
        public IWebElement _passwordInputByPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='button__text'][contains(text(),'Войти')]")]
        public IWebElement _logInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='error-message']")]
        public IWebElement _errorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='tabcontent']//input[@id='passwordPhone']")]
        public IWebElement _newPasswordFieldForTest { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='tabcontent']//button[@type='submit']")]
        public IWebElement _buttonForSubmitNewPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='drawer__close']")]
        public IWebElement _closeAuthWondow { get; set; }


        public bool IsErrorMessageDisplayed()
        {
            var isErrorMessageDisplayed = _errorMessage.Displayed;

            return isErrorMessageDisplayed;
        }
    }
}
