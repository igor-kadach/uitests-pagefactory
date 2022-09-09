using UITests.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using UITests.Utils;

namespace UITests
{
    public class Login
    {
        public void LoginToSite()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var signInButtonClick = new MainMenuPageObject();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonClick._sighInButton)).Click();

            var login = new AuthorizationPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            Thread.Sleep(2000);
            login._loginInputField.SendKeys(TestDatas.emailAdress);
            login._passwordInputField.SendKeys(TestDatas.password);
            login._logInButton.Click();
            Thread.Sleep(2000);
        }
    }
}
