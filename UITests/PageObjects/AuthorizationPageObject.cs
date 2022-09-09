using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using UITests.Utils;

namespace UITests.PageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        public AuthorizationPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public AuthorizationPageObject()
        {
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

        public void ChangePasswordBack()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // Close authWindow to sighIn again.
            var closeAuthWindow = new AuthorizationPageObject();
            closeAuthWindow._closeAuthWondow.Click();
            // Press button SighIn.
            var signInButtonClick = new MainMenuPageObject();
            signInButtonClick._sighInButton.Click();
            // Choose method by email and enter new credentials.
            var login = new AuthorizationPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.newPasswordForTest);
            login._logInButton.Click();
            // Go to my profile to open settings.
            var goToMyProfile = new MainMenuPageObject();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();
            // Open settings to change password.
            var openSetting = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();
            // Change password fron new to old password back.
            var changePass = new SettingsPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(TestDatas.newPasswordForTest);
            changePass._newPasswordField.SendKeys(TestDatas.password);
            // Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();
        }
    }
}
