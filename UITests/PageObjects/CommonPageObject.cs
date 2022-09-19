using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    public class CommonPageObject : BasePageObject
    {
        private readonly Settings _settings;

        public CommonPageObject(Settings settings) : base()
        {
            _settings = settings;
        }

        public void LoginToSite()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var signInButtonClick = new MainMenuPageObject();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonClick._sighInButton)).Click();

            var login = new AuthorizationPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            Thread.Sleep(2000);

            login._loginInputField.SendKeys(_settings.EmailAdress);
            login._passwordInputField.SendKeys(_settings.Password);
            login._logInButton.Click();
            Thread.Sleep(2000);
        }

        public bool isMyOfferDisplayed()
        {
            var offerDisplayed = new CatalogPageObject();
            Thread.Sleep(3000);
            var isMyOfferDisplayed = offerDisplayed._myOffer.Displayed;
            return isMyOfferDisplayed;
        }

        public bool IsErrorMessageDisplayed()
        {
            var errorMessage = new AuthorizationPageObject();
            var isErrorMessageDisplayed = errorMessage._errorMessage.Displayed;
            return isErrorMessageDisplayed;
        }

        public void EnterParametrsForSearching()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var parametrs = new ParametrsForSearchingPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._carsName)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._nameAudi)).Click();
            parametrs._transmissionAutomatic.Click();
            parametrs._chooseFuel.Click();
            parametrs._benzinFuel.Click();
            parametrs._chooseFuel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._buttonShow)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public bool IsAudiDispayed()
        {
            var getBookmarks = new PersonalAreaPageObject();
            Thread.Sleep(3000);
            var IsBookmarkDisplayed = getBookmarks._nameAudi.Displayed;
            return IsBookmarkDisplayed;
        }

        public bool isAddedPhotoDisplayed()
        {
            var getAddedPhoto = new PersonalAreaPageObject();
            Thread.Sleep(3000);
            var isAddedPhotoDisplayed = getAddedPhoto._findAddedPhoto.Displayed;
            return isAddedPhotoDisplayed;
        }

        public bool isSearchIsSaved()
        {
            var getSavedSearching = new PersonalAreaPageObject();
            var isSearchIsSaved = getSavedSearching._nameOfSearching.Displayed;
            return isSearchIsSaved;
        }

        public bool isLogoDisplayed()
        {
            var getLogo = new PersonalAreaPageObject();
            var isLogoDisplayed = getLogo._logoOfPayment.Displayed;
            return isLogoDisplayed;
        }

        public void DeleteSavedSerches()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var deleteSearching = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSearching._deleteSavedSearching)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSearching._acceptDeleting)).Click();
        }

        public void DeleteSavedBoormarks()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var deleteBookmark = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteBookmark._deleteBookmark)).Click();
        }

        public bool GetProfileMenu()
        {
            var getProfile = new MainMenuPageObject();
            var userName = getProfile._profile.Displayed;
            return userName;
        }
        public string GetNameOfCar()
        {
            var getNameOfCar = new MainMenuPageObject();
            var nameOfCar = getNameOfCar._nameOfCar.Text;
            return nameOfCar;
        }
        public string GetInstagramUrl()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);
            Thread.Sleep(3000);
            var url = _webDriver.Url;
            return url;
        }
        public bool IsLinkEnable()
        {
            var getLink = new MainMenuPageObject();
            var isLinkEnable = getLink._infoEmail.Enabled;
            return isLinkEnable;
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
            Thread.Sleep(3000);
            login._loginInputField.SendKeys(_settings.EmailAdress);
            login._passwordInputField.SendKeys(_settings.NewPasswordForTest);
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
            changePass._oldPassworField.SendKeys(_settings.NewPasswordForTest);
            changePass._newPasswordField.SendKeys(_settings.Password);
            // Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();
        }
    }
}